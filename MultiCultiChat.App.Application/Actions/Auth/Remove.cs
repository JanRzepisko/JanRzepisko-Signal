using FluentValidation;
using MediatR;
using MultiCultiChat.App.Application.DataAccess;
using Shared.BaseModels.Exceptions;

namespace MultiCultiChat.App.Application.Actions.Auth;

public static class Remove
{
    public sealed record Command(Guid UserId) : IRequest<Unit>;

    public class Handler : IRequestHandler<Command, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;

        public Handler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
        {
            var exist = await _unitOfWork.Users.ExistsAsync(request.UserId, cancellationToken);
            if (!exist) throw new EntityNotFoundException("User not found");

            _unitOfWork.Users.RemoveById(request.UserId);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }

        public sealed class Validator : AbstractValidator<Command>
        {
            public Validator()
            {
                RuleFor(c => c.UserId).NotEqual(Guid.Empty);
            }
        }
    }
}