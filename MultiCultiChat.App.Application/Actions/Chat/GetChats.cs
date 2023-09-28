using FluentValidation;
using MediatR;
using Shared.Service.Interfaces;
using Signal.App.Application.DataAccess;
using Signal.App.Domain.DTOs;

namespace Signal.App.Application.Actions.Chat;

public static class GetChats
{
    public sealed record Command(int page) : IRequest<List<ChatDTO>>;

    public class Handler : IRequestHandler<Command, List<ChatDTO>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserProvider _userProvider;
        private readonly int _pageSize = 10;

        public Handler(IUnitOfWork unitOfWork, IUserProvider userProvider)
        {
            _unitOfWork = unitOfWork;
            _userProvider = userProvider;
        }

        public async Task<List<ChatDTO>> Handle(Command request, CancellationToken cancellationToken)
        {
            if (!await _unitOfWork.Users.ExistsAsync(_userProvider.Id, cancellationToken))
                throw new Exception("User not found");
            
            var chats = await _unitOfWork.Chats.GetChatsByUserIdAsync(_userProvider.Id, request.page, _pageSize, cancellationToken);
            
            var x = chats.Select(ChatDTO.FromEntity).ToList();
            return x;
        }

        public sealed class Validator : AbstractValidator<Command>
        {
            public Validator()
            {

            }
        }
    }
}