using Signal.App.Domain.Entities;

namespace Signal.App.Domain.DTOs;

public class MessageDTO
{
    public Guid Id { get; set; }
    public UserDTO Sender { get; set; }
    public string Content { get; set; }

    public static MessageDTO FromEntity(Message entity)
    {
        return new MessageDTO()
        {
            Content = entity.Content,
            Id = entity.Id,
            Sender = UserDTO.FromEntity(entity.Sender)
        };
    }
}