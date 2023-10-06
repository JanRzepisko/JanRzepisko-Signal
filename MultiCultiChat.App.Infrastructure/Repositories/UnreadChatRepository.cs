using Microsoft.EntityFrameworkCore;
using MultiCultiChat.App.Application.Repository;
using MultiCultiChat.App.Domain.Entities;
using Shared.BaseModels.BaseEntities;

namespace MultiCultiChat.App.Infrastructure.Repositories;

public class UnreadChatRepository :  BaseRepository<UnreadChat>, IUnreadChatRepository
{
    public UnreadChatRepository(DbSet<UnreadChat>? entities) : base(entities)
    {
    }

    public Task<List<UnreadChat>> GetByUserIdAsync(Guid userId, CancellationToken cancellationToken = default)
     => _entities.Where(c => c.UserId == userId).ToListAsync(cancellationToken);
    
}