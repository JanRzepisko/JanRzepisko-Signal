using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shared.BaseModels.ApiControllerModels;
using Signal.App.Application.Actions.Chat;
using Signal.App.Application.Actions.Messages;

namespace Signal.App.API.Controllers;

[Authorize]
[ApiController]
[Route("message")]
public class MessageController : BaseApiController
{
    public MessageController(IMediator mediator) : base(mediator)
    {
    }
    
    [HttpGet]
    public Task<IActionResult> RegisterUser(Guid chatId, int page) => Endpoint(new GetMessages.Command(chatId, page));
    
}