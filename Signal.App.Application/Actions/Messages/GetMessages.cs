using FluentValidation;
using MediatR;
using Shared.Service.Interfaces;
using Signal.App.Application.DataAccess;
using Signal.App.Domain.DTOs;

namespace Signal.App.Application.Actions.Messages;

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

            
            
            return null;
        }

        public sealed class Validator : AbstractValidator<Command>
        {
            public Validator()
            {

            }
        }
    }
}