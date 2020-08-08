using LimKam.Domain.Communication;
using LimKam.Domain.Models;
using MediatR;

namespace LimKam.Domain.Commands.Users
{
    public class DeleteUserCommand : IRequest<Response<User>>
    {
        public int Id { get; private set; }

        public DeleteUserCommand(int id)
        {
            this.Id = id;
        }
    }
}