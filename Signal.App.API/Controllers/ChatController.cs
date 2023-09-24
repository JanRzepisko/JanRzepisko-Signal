using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shared.BaseModels.ApiControllerModels;
using Signal.App.Application.Actions.Chat;

namespace Signal.App.API.Controllers;

[Authorize]
[ApiController]
[Route("chat")]
public class ChatController : BaseApiController
{
    public ChatController(IMediator mediator) : base(mediator)
    {
    }
    [HttpPost]
    public Task<IActionResult> CreateChat(CreateChat.Command request) => Endpoint(request);
    
    [HttpGet]
    public Task<IActionResult> RegisterUser(int page) => Endpoint(new GetChats.Command(page));
    
}