using FluentValidation;
using MediatR;
using MultiCultiChat.App.Application.DataAccess;
using MultiCultiChat.App.Domain.DTOs;
using Shared.Service.Interfaces;

namespace MultiCultiChat.App.Application.Actions.Messages;

public static class GetMessages
{
    public sealed record Command(Guid ChatId, int Page) : IRequest<List<MessageDTO>>;

    public class Handler : IRequestHandler<Command, List<MessageDTO>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserProvider _userProvider;
        private readonly int _pageSize = 10;

        public Handler(IUnitOfWork unitOfWork, IUserProvider userProvider)
        {
            _unitOfWork = unitOfWork;
            _userProvider = userProvider;
        }

        public async Task<List<MessageDTO>> Handle(Command request, CancellationToken cancellationToken)
        {
            if (!await _unitOfWork.Users.ExistsAsync(_userProvider.Id, cancellationToken))
                throw new Exception("User not found");

            var messages = await _unitOfWork.Messages.GetMessagesByChatId(request.ChatId, request.Page, _pageSize);
           
            return messages.Select(MessageDTO.FromEntity).ToList();
        }

        public sealed class Validator : AbstractValidator<Command>
        {
            public Validator()
            {

            }
        }
    }
}