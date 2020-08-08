using System;
using System.Threading;
using System.Threading.Tasks;
using LimKam.Domain.Models;
using LimKam.Domain.Repositories;
using MediatR;

namespace LimKam.Domain.Queries.Users
{
    public class GetUserQueryHandler : IRequestHandler<GetUserQuery, User>
    {
        private readonly IUserRepository _userRepository;

        public GetUserQueryHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<User> Handle(GetUserQuery request, CancellationToken cancellationToken)
        {
            if (request.UserId <= 0)
            {
                throw new ArgumentException(nameof(request.UserId));
            }

            return await _userRepository.FindByIdAsync(request.UserId);
        }
    }
}