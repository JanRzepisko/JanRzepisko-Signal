namespace Signal.App.Domain.DTOs;

public class MessageDTO
{
    public Guid Id { get; set; }
    public UserDTO Sender { get; set; }
    public string Content { get; set; }
    
}