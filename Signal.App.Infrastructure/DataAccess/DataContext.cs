using Microsoft.EntityFrameworkCore;
using Signal.App.Application.DataAccess;
using Signal.App.Application.Repository;
using Signal.App.Domain.Entities;
using Signal.App.Infrastructure.Repositories;

namespace Signal.App.Infrastructure.DataAccess;

public class DataContext : DbContext, IUnitOfWork
{
    private DbSet<User> _users { get; set; }
    
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(DataContext).Assembly);
        base.OnModelCreating(modelBuilder);
    }

    public IUserRepository Users => new UserRepository(_users);
}