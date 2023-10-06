using Shared.BaseModels.BaseEntities;

namespace MultiCultiChat.App.Domain.Entities;

public class UnreadChat : Entity
{
    public Guid UserId { get; set; }
    public User User { get; set; }
    public Guid ChatId { get; set; }
    public Chat Chat { get; set; }
}