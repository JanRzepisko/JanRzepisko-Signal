using Shared.BaseModels.BaseEntities;
using Signal.App.Domain.Enums;

namespace Signal.App.Domain.Entities;

public class ChatUser : Entity
{
    public Guid ChatId { get; set; }
    public Chat Chat { get; set; }
    public Guid UserId { get; set; }
    public User User { get; set; }
    public Role Role { get; set; }
}