using MultiCultiChat.App.Application.Repository;

namespace MultiCultiChat.App.Application.DataAccess;

public interface IUnitOfWork
{
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    IUserRepository Users { get; }
    IChatRepository Chats { get; }
    IMessageRepository Messages { get; }
    IChatUserRepository ChatUsers { get; }
    IUnreadChatRepository UnreadChat { get; }
    
}