using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using Renci.SshNet.Messages;
using Signal.App.Application.DataAccess;

namespace Signal.App.Application.Hubs;

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
        var msg = new Domain.Entities.Message
        {
            ChatId = chatId,
            Text = message,
            SenderId = Guid.Parse(Context.User.Claims.First(c => c.Type == "Id").Value)
        };
        
        await _unitOfWork.Messages.AddAsync(msg);
        await _unitOfWork.SaveChangesAsync();
        await Clients.Groups(chatId.ToString()).SendAsync("Message", chatId, message);
    }
}