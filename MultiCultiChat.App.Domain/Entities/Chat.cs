using Shared.BaseModels.BaseEntities;

namespace MultiCultiChat.App.Domain.Entities;

public class Chat : Entity
{
    public string ChatName { get; set; }
    public string PhotoPath { get; set; }
    public ICollection<ChatUser> ChatUsers { get; set; }
    public ICollection<Message> Messages { get; set; }
    public ICollection<UnreadChat> UnreadMessages { get; set; }
}