using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MultiCultiChat.App.Application.Repository;
using MultiCultiChat.App.Domain.Entities;
using Shared.BaseModels.BaseEntities;

namespace MultiCultiChat.App.Infrastructure.Repositories;

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