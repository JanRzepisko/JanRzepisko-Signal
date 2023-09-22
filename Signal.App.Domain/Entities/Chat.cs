using Shared.BaseModels.BaseEntities;

namespace Signal.App.Domain.Entities;

public class Chat : Entity
{
    public string ChatName { get; set; }
    public string PhotoPath { get; set; }
    public ICollection<ChatUser> ChatUsers { get; set; }
}