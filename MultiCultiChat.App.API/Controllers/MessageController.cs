using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MultiCultiChat.App.Application.Actions.Messages;
using Shared.BaseModels.ApiControllerModels;

namespace MultiCultiChat.App.API.Controllers;

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