using MultiCultiChat.App.Domain.Entities;
using Shared.BaseModels.BaseEntities;

namespace MultiCultiChat.App.Application.Repository;

public interface IUserRepository : IBaseRepository<User>
{
    Task<User?> GetByLoginAsync(string email, CancellationToken cancellationToken = default);
}