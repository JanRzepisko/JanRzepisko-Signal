using MultiCultiChat.App.Domain.Entities;

namespace MultiCultiChat.App.Domain.DTOs;

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