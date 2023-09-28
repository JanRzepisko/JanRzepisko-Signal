using Signal.App.Domain.Entities;

namespace Signal.App.Domain.DTOs;

public class ChatDTO
{
    
    public Guid Id { get; set; }
    public string ChatName { get; set; }
    public string PhotoPath { get; set; }
    public ICollection<User> Users { get; set; }
    public ICollection<Message> Messages { get; set; }
    public static ChatDTO FromEntity(Chat chat)
    {
        var x = new ChatDTO()
        {
            Id = chat.Id,
            ChatName = chat.ChatName,
            PhotoPath = chat.PhotoPath,
            Users = chat.ChatUsers.Select(x => x.User).ToList(),
            Messages = (chat.Messages
                        ?? new List<Message>()).ToList()
        };
        
        return x;
    }
}