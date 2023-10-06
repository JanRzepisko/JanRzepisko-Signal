namespace MultiCultiChat.App.Application.Hubs;

public class ConnectionUserModel
{
    public ConnectionUserModel(Guid userId, string connectionId, Guid chatId)
    {
        UserId = userId;
        ConnectionId = connectionId;
        ChatId = chatId;
    }

    public Guid UserId { get; }
    public string ConnectionId { get; }
    public Guid ChatId { get; }
}