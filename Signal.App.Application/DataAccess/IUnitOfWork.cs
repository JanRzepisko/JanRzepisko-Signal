using Shared.BaseModels.BaseEntities;
using Signal.App.Application.Repository;
using Signal.App.Domain.Entities;

namespace Signal.App.Application.DataAccess;

public interface IUnitOfWork
{
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    IUserRepository Users { get; }
    IBaseRepository<Organization> Organizations { get; }
    IBaseRepository<Member> Members { get; }
    IBaseRepository<Event> Events { get; }
    IBaseRepository<MemberEvent> MemberEvents { get; }
}