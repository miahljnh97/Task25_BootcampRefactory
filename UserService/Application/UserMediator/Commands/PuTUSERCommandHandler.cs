using System.Threading;
using System.Threading.Tasks;
using MediatR;
using UserService.Application.UserMediator.Queries.GetUser;
using UserService.Application.UserMediator.Request;
using UserService.Models;

namespace UserService.Application.NotificationMediator.Commands
{
    public class PutUserCommandHandler : IRequestHandler<PutUserCommand, UserDTO>
    {
        private readonly USContext _context;

        public PutUserCommandHandler(USContext context)
        {
            _context = context;
        }

        public async Task<UserDTO> Handle(PutUserCommand request, CancellationToken cancellationToken)
        {
            var data = await _context.userModels.FindAsync(request.Data.Attributes.Id);

            data.Name = request.Data.Attributes.Name;
            data.Username = request.Data.Attributes.Username;
            data.Email = request.Data.Attributes.Email;
            data.Password = request.Data.Attributes.Password;
            data.Address = request.Data.Attributes.Address;
            _context.SaveChanges();


            return new UserDTO
            {
                Message = "Success retreiving data",
                Success = true
            };
        }
    }
}
