using MediatR;
using Shared.BaseModels.Exceptions;
using Signal.App.Application.DataAccess;
using Signal.App.Application.Jwt;
using Signal.App.Application.Services;

namespace Signal.App.Application.Actions.Auth;

public static class Login
{
    public sealed record Query(string Email, string Password) : IRequest<GeneratedToken>;

    public class Handler : IRequestHandler<Query, GeneratedToken>
    {
        private readonly IJwtAuth _jwtAuth;
        private readonly IUnitOfWork _unitOfWork;

        public Handler(IUnitOfWork unitOfWork, IJwtAuth jwtAuth)
        {
            _unitOfWork = unitOfWork;
            _jwtAuth = jwtAuth;
        }

        public async Task<GeneratedToken> Handle(Query request, CancellationToken cancellationToken)
        {
            var user = await _unitOfWork.Users.GetByLoginAsync(request.Email, cancellationToken);
            if (user is null) throw new EntityNotFoundException("User not found");
            if (!BCrypt.Net.BCrypt.Verify(request.Password, user.Password)) throw new BadPassword("Bad password");
            
            return await _jwtAuth.GenerateJwt(user.Id, user.Email, user.Username);
        }
    }
}