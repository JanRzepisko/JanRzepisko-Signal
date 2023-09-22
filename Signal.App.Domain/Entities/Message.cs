using Shared.BaseModels.BaseEntities;

namespace Signal.App.Domain.Entities;

public class Messages : Entity
{
    public Guid SenderId { get; set; }
    public User Sender { get; set; }
    public Guid ChatId { get; set; }
    public Chat Chat { get; set; }
    public string Text { get; set; }
}