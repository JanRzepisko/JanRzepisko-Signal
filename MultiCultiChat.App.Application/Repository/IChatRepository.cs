using MultiCultiChat.App.Domain.Entities;
using Shared.BaseModels.BaseEntities;

namespace MultiCultiChat.App.Application.Repository;

public interface IChatRepository : IBaseRepository<Chat>
{
    Task<List<Chat>> GetChatsByUserIdAsync(Guid userId, int page, int pageSize, CancellationToken cancellationToken);
}