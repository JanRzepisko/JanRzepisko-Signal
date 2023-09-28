using Shared.BaseModels.BaseEntities;
using Signal.App.Domain.Entities;

namespace Signal.App.Application.Repository;

public interface IMessageRepository : IBaseRepository<Message>
{
    Task<List<Message>> GetMessagesByChatId(Guid chatId, int page, int pageSize);
}