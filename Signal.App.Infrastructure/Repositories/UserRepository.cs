using Microsoft.EntityFrameworkCore;
using Shared.BaseModels.BaseEntities;
using Signal.App.Application.Repository;
using Signal.App.Domain.Entities;

namespace Signal.App.Infrastructure.Repositories;

public class UserRepository : BaseRepository<User>, IUserRepository 
{
    public UserRepository(DbSet<User>? entities) : base(entities)
    {
    }

    public Task<User?> GetByLoginAsync(string email, CancellationToken cancellationToken)
    {
        return _entities.FirstOrDefaultAsync(x => x.Email == email, cancellationToken);
    }
}