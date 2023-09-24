
using Signal.App.Application.Jwt;

namespace Signal.App.Application.Services;

public interface IJwtAuth
{
    public Task<GeneratedToken> GenerateJwt(Guid id, string email, string name);
}