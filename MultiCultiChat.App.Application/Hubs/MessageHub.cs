using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using MultiCultiChat.App.Application.DataAccess;
using MultiCultiChat.App.Domain.DTOs;
using MultiCultiChat.App.Domain.Entities;

namespace MultiCultiChat.App.Application.Hubs;

public class MessageHub : Hub
{
    private readonly IUnitOfWork _unitOfWork;

    public MessageHub(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    public override async Task OnConnectedAsync()
    {
        await Clients.All.SendAsync("Hej");
    }
    
    [HubMethodName("JoinRoom")]
    public Task JoinRoom(Guid chatId)
    {
        return Groups.AddToGroupAsync(Context.ConnectionId, chatId.ToString());
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
        
        await _unitOfWork.Messages.AddAsync(msg);
        await _unitOfWork.SaveChangesAsync();
        await Clients.All.SendAsync("Sent", chatId, MessageDTO.FromEntity(msg));
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