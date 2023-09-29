using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using MultiCultiChat.App.Application.DataAccess;
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
    
    [Authorize]
    [HubMethodName("SendMessage")]
    public async Task SendMessage(string message, Guid chatId)
    {
        var msg = new Message
        {
            ChatId = chatId,
            Content = message,
            SenderId = Guid.Parse(Context.User.Claims.First(c => c.Type == "Id").Value)
        };
        
        await _unitOfWork.Messages.AddAsync(msg);
        await _unitOfWork.SaveChangesAsync();
        await Clients.Groups(chatId.ToString()).SendAsync("Sent", chatId, message);
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