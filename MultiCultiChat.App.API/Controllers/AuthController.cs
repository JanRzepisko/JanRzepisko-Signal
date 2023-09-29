using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MultiCultiChat.App.Application.Actions.Auth;
using Shared.BaseModels.ApiControllerModels;

namespace MultiCultiChat.App.API.Controllers;

[Authorize]
[ApiController]
[Route("auth")]
public class AuthController : BaseApiController
{
    public AuthController(IMediator mediator) : base(mediator)
    {
    }

    [AllowAnonymous]
    [HttpPost]
    [Route("Login")]
    public Task<IActionResult> Login(Login.Query request) => Endpoint(request);

    [AllowAnonymous]
    [HttpPost]
    public Task<IActionResult> RegisterUser(Register.Command request) => Endpoint(request);

    [HttpPost]
    [Route("RefreshToken")]
    public Task<IActionResult> RefreshToken(RefreshToken.Query request) => Endpoint(request);

    [HttpPut]
    public Task<IActionResult> UpdateUser(Update.Command request) => Endpoint(request);

    [HttpDelete]
    public Task<IActionResult> DeleteUser(Remove.Command request) => Endpoint(request);
}