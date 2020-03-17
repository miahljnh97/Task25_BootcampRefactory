using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using UserService.Models;

namespace UserService.Application.UserMediator.Queries.GetUser
{
    public class GetUserQueryHandler : IRequestHandler<GetUserQuery, GetUserDTO>
    {
        private readonly USContext _context;
        public GetUserQueryHandler(USContext context)
        {
            _context = context;
        }

        public async Task<GetUserDTO> Handle(GetUserQuery request, CancellationToken cancellationToken)
        {
            var data = await _context.userModels.FindAsync(request.Id);

            if (data == null)
            {
                return null;
            }
            else
            {
                return new GetUserDTO
                {
                    Success = true,
                    Message = "Success retreiving data",
                    Data = data
                };
            }
        }
    }
}
