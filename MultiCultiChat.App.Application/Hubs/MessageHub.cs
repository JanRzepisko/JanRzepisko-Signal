using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using MultiCultiChat.App.Application.DataAccess;
using MultiCultiChat.App.Domain.DTOs;
using MultiCultiChat.App.Domain.Entities;

namespace MultiCultiChat.App.Application.Hubs;

public class MessageHub : Hub
{
    private readonly IUnitOfWork _unitOfWork;
    private List<ConnectionUserModel> _connectionUser  = new ();

    public MessageHub(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    public override async Task OnConnectedAsync()
    {
        await Clients.All.SendAsync("Hej");
    }
    
    [HubMethodName("Join")]
    public async Task Join(Guid userId)
    {
        var user = await _unitOfWork.Users.GetByIdAsync(userId);
        if (user is null)
            throw new Exception("User not found");

        foreach (var chat in user.ChatUsers)
        {
            _connectionUser.Add(new ConnectionUserModel(userId, Context.ConnectionId, chat.ChatId));
            await Groups.AddToGroupAsync(Context.ConnectionId, chat.ChatId.ToString());
        }
    }
    
    [HubMethodName("SendMessage")]
    public async Task SendMessage(string message, Guid chatId, Guid senderId)
    {
        var sender = await _unitOfWork.Users.GetByIdAsync(senderId);
        if (sender is null) throw new Exception("User not found");

        var msg = new Message
        {
            ChatId = chatId,
            Content = message,
            SenderId = senderId,
            Sender = sender
        };

        var chat = await _unitOfWork.Chats.GetByIdAsync(chatId);
        foreach (var chatUser in chat.ChatUsers)
        {
            var unreadChat = new UnreadChat()
            {
                ChatId = chatId,
                UserId = chatUser.UserId
            };
            await _unitOfWork.UnreadChat.AddAsync(unreadChat);
        }
        
        await _unitOfWork.Messages.AddAsync(msg);
        await _unitOfWork.SaveChangesAsync();
        await Clients.Group(chatId.ToString()).SendAsync("Sent", chatId, MessageDTO.FromEntity(msg));
    }
    
    [Authorize]
    [HubMethodName("RemoveMessage")]
    public async Task RemoveMessage(Guid messageId, Guid chatId)
    {
        _unitOfWork.Messages.RemoveById(messageId);
        await _unitOfWork.SaveChangesAsync();
        
        await Clients.Groups(chatId.ToString()).SendAsync("Removed", messageId);
    }
}