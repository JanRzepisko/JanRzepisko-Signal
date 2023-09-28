using Shared.BaseModels.BaseEntities;
using Signal.App.Domain.Entities;

namespace Signal.App.Application.Repository;

public interface IUserRepository : IBaseRepository<User>
{
    Task<User?> GetByLoginAsync(string email, CancellationToken cancellationToken = default);
}