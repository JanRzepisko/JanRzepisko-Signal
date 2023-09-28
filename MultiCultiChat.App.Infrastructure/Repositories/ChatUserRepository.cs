using Microsoft.EntityFrameworkCore;
using Shared.BaseModels.BaseEntities;
using Signal.App.Application.Repository;
using Signal.App.Domain.Entities;

namespace Signal.App.Infrastructure.Repositories;

public class ChatUserRepository : BaseRepository<ChatUser>, IChatUserRepository 
{
    public ChatUserRepository(DbSet<ChatUser>? entities) : base(entities)
    {
    }

    
    
    
}