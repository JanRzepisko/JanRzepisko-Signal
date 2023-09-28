using Microsoft.EntityFrameworkCore;
using Shared.BaseModels.BaseEntities;
using Signal.App.Application.Repository;
using Signal.App.Domain.Entities;

namespace Signal.App.Infrastructure.Repositories;

public class ChatRepository : BaseRepository<Chat>, IChatRepository 
{
    public ChatRepository(DbSet<Chat>? entities) : base(entities)
    {
    }

    public Task<List<Chat>> GetChatsByUserIdAsync(Guid userId, int page, int pageSize,
        CancellationToken cancellationToken) =>
        _entities
            .Include(c => c.ChatUsers)
            .ThenInclude(c => c.User)
            .Include(c => c.Messages.Take(50))
            .Where(c => c.ChatUsers.Any(c => c.UserId == userId))
            .Skip(page * pageSize).Take(pageSize)
            .ToListAsync(cancellationToken);
    
    
}