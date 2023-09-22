using Microsoft.EntityFrameworkCore;
using Shared.BaseModels.BaseEntities;
using Signal.App.Application.DataAccess;
using Signal.App.Application.Repository;
using Signal.App.Domain.Entities;
using Signal.App.Infrastructure.Repositories;

namespace Signal.App.Infrastructure.DataAccess;

public class DataContext : DbContext, IUnitOfWork
{
    private DbSet<User> _users { get; set; }
    private DbSet<Chat> _chats { get; set; }
    private DbSet<Message> _messages { get; set; }
    private DbSet<ChatUser> _chatUsers { get; set; }
    
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(DataContext).Assembly);
        base.OnModelCreating(modelBuilder);
    }

    public IUserRepository Users => new UserRepository(_users);
    public IBaseRepository<Chat> Chats => new BaseRepository<Chat>(_chats);
    public IBaseRepository<Message> Messages => new BaseRepository<Message>(_messages);
    public IBaseRepository<ChatUser> ChatUsers => new BaseRepository<ChatUser>(_chatUsers);
}