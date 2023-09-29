using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MultiCultiChat.App.Application.Repository;
using MultiCultiChat.App.Domain.Entities;
using Shared.BaseModels.BaseEntities;

namespace MultiCultiChat.App.Infrastructure.Repositories;

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