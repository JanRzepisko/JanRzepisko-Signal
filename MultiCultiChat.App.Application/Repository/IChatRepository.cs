using Shared.BaseModels.BaseEntities;
using Signal.App.Domain.Entities;

namespace Signal.App.Application.Repository;

public interface IChatRepository : IBaseRepository<Chat>
{
    Task<List<Chat>> GetChatsByUserIdAsync(Guid userId, int page, int pageSize, CancellationToken cancellationToken);
}