using FluentValidation;
using MediatR;
using Shared.Service.Interfaces;
using Signal.App.Application.DataAccess;
using Signal.App.Domain.Entities;

namespace Signal.App.Application.Actions.Chat;

public static class CreateChat
{
    public sealed record Command(List<Guid> users, string chatName) : IRequest<Unit>;

    public class Handler : IRequestHandler<Command, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserProvider _userProvider;

        public Handler(IUnitOfWork unitOfWork, IUserProvider userProvider)
        {
            _unitOfWork = unitOfWork;
            _userProvider = userProvider;
        }

        public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
        {
            if (!await _unitOfWork.Users.ExistsAsync(_userProvider.Id, cancellationToken))
                throw new Exception("User not found");
            
            var chat = new Domain.Entities.Chat
            {
                ChatName = request.chatName,
                PhotoPath = ""
            };
            
            request.users.Add(_userProvider.Id);
            
            await _unitOfWork.Chats.AddAsync(chat, cancellationToken);
            foreach (var userId in request.users)
            {
                if(!await _unitOfWork.Users.ExistsAsync(userId, cancellationToken))
                    continue;
                chat.ChatUsers.Add(new ChatUser
                {
                    Chat = chat,
                    UserId = userId
                });                
            }
            
            return Unit.Value;
        }

        public sealed class Validator : AbstractValidator<Command>
        {
            public Validator()
            {

            }
        }
    }
}