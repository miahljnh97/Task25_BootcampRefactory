using MediatR;
using UserService.Application.UserMediator.Request;

namespace UserService.Application.NotificationMediator.Commands
{
    public class DeleteUserCommand : IRequest<UserDTO>
    {
        public int Id { get; set; }
        public DeleteNotifCommand(int id)
        {
            Id = id;
        }
    }
}
