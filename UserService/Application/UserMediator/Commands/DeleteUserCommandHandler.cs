using System.Threading;
using System.Threading.Tasks;
using MediatR;
using UserService.Models;
using UserService.Application.UserMediator.Request;

namespace UserService.Application.NotificationMediator.Commands
{
    public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, UserDTO>
    {
        private readonly USContext _context;
        public DeleteUserCommandHandler(USContext context)
        {
            _context = context;
        }

        public async Task<UserDTO> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            var data = await _context.userModels.FindAsync(request.Id);

            if (data == null)
            {
                return null;
            }

            _context.userModels.Remove(data);
            await _context.SaveChangesAsync();

            return new UserDTO { Message = "Successfull", Success = true };
        }
    }
}
