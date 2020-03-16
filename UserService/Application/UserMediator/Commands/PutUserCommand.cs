using MediatR;
using UserService.Application.UserMediator.Queries.GetUser;
using UserService.Models;

namespace UserService.Application.NotificationMediator.Commands
{
    public class PutUserCommand : CommandDTO<userModel>, IRequest<GetUserDTO>
    {
    }
}
