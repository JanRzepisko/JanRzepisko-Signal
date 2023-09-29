using MultiCultiChat.App.Domain.Entities;
using Shared.BaseModels.BaseEntities;

namespace MultiCultiChat.App.Application.Repository;

public interface IMessageRepository : IBaseRepository<Message>
{
    Task<List<Message>> GetMessagesByChatId(Guid chatId, int page, int pageSize);
}