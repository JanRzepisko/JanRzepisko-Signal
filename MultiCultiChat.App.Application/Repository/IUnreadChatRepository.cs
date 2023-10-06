using MultiCultiChat.App.Domain.Entities;
using Shared.BaseModels.BaseEntities;

namespace MultiCultiChat.App.Application.Repository;

public interface IUnreadChatRepository : IBaseRepository<UnreadChat>
{
    Task<List<UnreadChat>> GetByUserIdAsync(Guid userId, CancellationToken cancellationToken);
}