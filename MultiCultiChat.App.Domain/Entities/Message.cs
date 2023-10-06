using Shared.BaseModels.BaseEntities;

namespace MultiCultiChat.App.Domain.Entities;

public class Message : Entity
{
    public Guid SenderId { get; set; }
    public User Sender { get; set; }
    public Guid ChatId { get; set; }
    public Chat Chat { get; set; }
    public string Content { get; set; }
    public DateTime SentDate { get; set; }
    public ICollection<UnreadChat> UnreadMessages { get; set; }
}