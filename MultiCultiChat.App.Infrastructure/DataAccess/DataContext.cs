using Microsoft.EntityFrameworkCore;
using MultiCultiChat.App.Application.DataAccess;
using MultiCultiChat.App.Application.Repository;
using MultiCultiChat.App.Domain.Entities;
using MultiCultiChat.App.Infrastructure.Repositories;

namespace MultiCultiChat.App.Infrastructure.DataAccess;

public class DataContext : DbContext, IUnitOfWork
{
    private DbSet<User> _users { get; set; }
    private DbSet<Chat> _chats { get; set; }
    private DbSet<Message> _messages { get; set; }
    private DbSet<ChatUser> _chatUsers { get; set; }
    private DbSet<UnreadChat> _unreadChats { get; set; }
    
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(DataContext).Assembly);
        base.OnModelCreating(modelBuilder);
    }

    public IUserRepository Users => new UserRepository(_users);
    public IChatRepository Chats => new ChatRepository(_chats);
    public IMessageRepository Messages => new MessagesRepository(_messages);
    public IChatUserRepository ChatUsers => new ChatUserRepository(_chatUsers);
    public IUnreadChatRepository UnreadChat => new UnreadChatRepository(_unreadChats);
}