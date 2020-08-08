using System.Collections.Generic;
using LimKam.Domain.Models;
using MediatR;

namespace LimKam.Domain.Queries.Users
{
    public class ListUsersQuery : IRequest<IEnumerable<User>>
    {
    }
}