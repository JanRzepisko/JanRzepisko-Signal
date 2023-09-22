using FluentValidation;
using MediatR;
using Shared.BaseModels.Exceptions;
using Shared.Service.Interfaces;
using Signal.App.Application.DataAccess;

namespace Signal.App.Application.Actions.Auth;

public static class Update
{
    public sealed record Command(string? Name, string? Surname, string? Email): IRequest<Unit>;

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
            var priest = await _unitOfWork.Users.GetByIdAsync(_userProvider.Id, cancellationToken);

            if (priest is null) throw new EntityNotFoundException($"user with id {_userProvider.Id} not found");
            priest.Name = request.Name ?? priest.Name;
            priest.Surname = request.Surname ?? priest.Surname;
            priest.Email = request.Email ?? priest.Email;

            await _unitOfWork.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }

        public sealed class Validator : AbstractValidator<Command>
        {
        }
    }
}