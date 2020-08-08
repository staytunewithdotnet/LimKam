using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using LimKam.Domain.Models;
using LimKam.Domain.Repositories;
using MediatR;

namespace LimKam.Domain.Queries.Users
{
    public class ListUsersQueryHandler : IRequestHandler<ListUsersQuery, IEnumerable<User>>
    {
        private readonly IUserRepository _userRepository;

        public ListUsersQueryHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<IEnumerable<User>> Handle(ListUsersQuery request, CancellationToken cancellationToken)
        {
            return await _userRepository.ListAsync();
        }
    }
}