using FluentValidation;
using MediatR;
using MultiCultiChat.App.Application.DataAccess;
using Shared.BaseModels.Exceptions;
using Shared.Service.Interfaces;

namespace MultiCultiChat.App.Application.Actions.Auth;

public static class Update
{
    public sealed record Command(string? Username, string? Email): IRequest<Unit>;

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
            var user = await _unitOfWork.Users.GetByIdAsync(_userProvider.Id, cancellationToken);

            if (user is null) throw new EntityNotFoundException($"user with id {_userProvider.Id} not found");
            user.Username = request.Username ?? user.Username;
            user.Email = request.Email ?? user.Email;

            await _unitOfWork.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }

        public sealed class Validator : AbstractValidator<Command>
        {
        }
    }
}