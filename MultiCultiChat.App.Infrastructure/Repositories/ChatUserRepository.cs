using Microsoft.EntityFrameworkCore;
using MultiCultiChat.App.Application.Repository;
using MultiCultiChat.App.Domain.Entities;
using Shared.BaseModels.BaseEntities;

namespace MultiCultiChat.App.Infrastructure.Repositories;

public class ChatUserRepository : BaseRepository<ChatUser>, IChatUserRepository 
{
    public ChatUserRepository(DbSet<ChatUser>? entities) : base(entities)
    {
    }

    
    
    
}