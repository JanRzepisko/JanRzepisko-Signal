using FluentValidation;
using MediatR;
using Signal.App.Application.DataAccess;
using Signal.App.Domain.Entities;
using Signal.App.Domain.Enums;

namespace Signal.App.Application.Actions.Chat;

public static class AssignUserToChat
{

    public sealed record Command(Guid ChatId, Guid UserId) : IRequest<Unit>;

    public class Handler : IRequestHandler<Command, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        
        
        public Handler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
        {
            if (!await _unitOfWork.Users.ExistsAsync(request.UserId, cancellationToken))
                throw new Exception("User not found");

            var chat = await _unitOfWork.Chats.GetByIdAsync(request.ChatId, cancellationToken);
            
            if(chat is null)
                throw new Exception("Chat not found");
            
            if(chat.ChatUsers.Any(c => c.UserId == request.UserId))
                throw new Exception("User already in chat");

            await _unitOfWork.ChatUsers.AddAsync(new ChatUser
            {
                ChatId = request.ChatId,
                UserId = request.UserId,
                Role = Role.Member
            }, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);  

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