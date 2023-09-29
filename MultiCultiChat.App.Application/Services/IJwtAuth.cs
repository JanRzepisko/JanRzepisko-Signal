
using MultiCultiChat.App.Application.Jwt;

namespace MultiCultiChat.App.Application.Services;

public interface IJwtAuth
{
    public Task<GeneratedToken> GenerateJwt(Guid id, string email, string name);
}