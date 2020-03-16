using System.Threading;
using System.Threading.Tasks;
using MediatR;
using UserService.Application.UserMediator.Queries.GetUser;
using UserService.Models;

namespace UserService.Application.NotificationMediator.Commands
{
    public class PostUserCommandHandler : IRequestHandler<PostUserCommand, GetUserDTO>
    {
        private readonly USContext _context;

        public PostUserCommandHandler(USContext context)
        {
            _context = context;
        }

        public async Task<GetUserDTO> Handle(PostUserCommand request, CancellationToken cancellationToken)
        {
            _context.userModels.Add(request.Data.Attributes);
            await _context.SaveChangesAsync();


            return new GetUserDTO
            {
                Message = "Successfully Added",
                Success = true,
                Data = new userData
                {
                    Id = request.Data.Attributes.Id,
                    Name = request.Data.Attributes.Name,
                    Username = request.Data.Attributes.Username,
                    Email = request.Data.Attributes.Email,
                    Password = request.Data.Attributes.Password,
                    Address = request.Data.Attributes.Address
                }
            };
        }
    }
}
