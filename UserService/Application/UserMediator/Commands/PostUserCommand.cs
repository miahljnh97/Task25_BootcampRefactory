using MediatR;
using UserService.Models;
using UserService.Application.UserMediator.Queries.GetUser;

namespace UserService.Application.NotificationMediator.Commands
{
    public class PostUserCommand : CommandDTO<userModel>, IRequest<GetUserDTO>
    {
    }
}
