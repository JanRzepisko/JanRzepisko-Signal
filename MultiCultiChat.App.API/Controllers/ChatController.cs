using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MultiCultiChat.App.Application.Actions.Chat;
using Shared.BaseModels.ApiControllerModels;

namespace MultiCultiChat.App.API.Controllers;

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
    public Task<IActionResult> GetChats(int page) => Endpoint(new GetChats.Command(page));
    
}