using MediatR;
using UserService.Application.UserMediator.Request;
using UserService.Models;

namespace UserService.Application.NotificationMediator.Commands
{
    public class PutUserCommand : CommandDTO<userModel>, IRequest<UserDTO>
    {
    }
}
