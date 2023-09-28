using Microsoft.EntityFrameworkCore;
using Shared.BaseModels.BaseEntities;
using Signal.App.Application.Repository;
using Signal.App.Domain.Entities;

namespace Signal.App.Infrastructure.Repositories;

public class MessagesRepository : BaseRepository<Message>, IMessageRepository
{
    public MessagesRepository(DbSet<Message>? entities) : base(entities)
    {
    }

    public Task<List<Message>> GetMessagesByChatId(Guid chatId, int page, int pageSize) =>
        _entities.Where(c => c.ChatId == chatId)
            .Include(c => c.Sender)
            .Skip(pageSize * page)
            .Take(pageSize)
            .ToListAsync();
}