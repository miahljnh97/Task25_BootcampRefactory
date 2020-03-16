using System.Threading;
using System.Threading.Tasks;
using MediatR;
using UserService.Application.UserMediator.Queries.GetUser;
using UserService.Models;

namespace UserService.Application.NotificationMediator.Commands
{
    public class PutUserCommandHandler : IRequestHandler<PutUserCommand, GetUserDTO>
    {
        private readonly USContext _context;

        public PutUserCommandHandler(USContext context)
        {
            _context = context;
        }

        public async Task<GetUserDTO> Handle(PutUserCommand request, CancellationToken cancellationToken)
        {
            var data = await _context.userModels.FindAsync(request.Data.Attributes.Id);

            data.Name = request.Data.Attributes.Name;
            data.Username = request.Data.Attributes.Username;
            data.Email = request.Data.Attributes.Email;
            data.Password = request.Data.Attributes.Password;
            data.Address = request.Data.Attributes.Address;
            _context.SaveChanges();


            return new GetUserDTO
            {
                Message = "Success retreiving data",
                Success = true,
                Data = new userData
                {
                    Id = data.Id,
                    Name = data.Name,
                    Username = data.Username,
                    Email = data.Email,
                    Password = data.Password,
                    Address = data.Address
                }
            };
        }
    }
}
