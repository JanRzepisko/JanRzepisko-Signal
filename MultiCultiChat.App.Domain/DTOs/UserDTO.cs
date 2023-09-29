using MultiCultiChat.App.Domain.Entities;

namespace MultiCultiChat.App.Domain.DTOs;

public class UserDTO
{
    public Guid Id { get; set; }
    public string Username { get; set; }
    public string PhotPath { get; set; }
    
    public static UserDTO FromEntity(User entity)
    {
        return new UserDTO
        {
            Username = entity.Username,
            Id = entity.Id,
            PhotPath = entity.PhotoPath
        };
    }
}