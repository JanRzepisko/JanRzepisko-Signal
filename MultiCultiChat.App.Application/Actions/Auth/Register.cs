using FluentValidation;
using MediatR;
using Signal.App.Application.DataAccess;
using Signal.App.Domain.Entities;

namespace Signal.App.Application.Actions.Auth;

public static class Register
{
    public sealed record Command(string Username, string Password, string Email) : IRequest<Unit>;

    public class Handler : IRequestHandler<Command, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;

        public Handler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
        {
            var priest = await _unitOfWork.Users.GetByLoginAsync(request.Email, cancellationToken);
            if (priest != null) throw new Exception("Priest already exists");

            var id = Guid.NewGuid();
            var newPriest = new User
            {
                Email = request.Email,
                Id = id,
                Username = request.Username,
                PhotoPath = "",
                Password = BCrypt.Net.BCrypt.HashPassword(request.Password),
            };

            await _unitOfWork.Users.AddAsync(newPriest, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }

        public sealed class Validator : AbstractValidator<Command>
        {
            public Validator()
            {
                RuleFor(c => c.Username).MinimumLength(3).MaximumLength(20);
                RuleFor(c => c.Email).EmailAddress();
                RuleFor(c => c.Password)
                    .MinimumLength(8)
                    .Matches("[A-Z]")
                    .Matches("[a-z]")
                    .Matches("[0-9]")
                    .Matches("[^a-zA-Z0-9]");
            }
        }
    }
}