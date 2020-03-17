using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using UserService.Application.UserMediator.Queries.GetUser;
using UserService.Models;

namespace RestService.Application.NotificationMediator.Queries.GetNotifs
{
    public class GetUsersQueryHandler : IRequestHandler<GetUsersQuery, GetUsersDTO>
    {
        private readonly USContext _context;
        public GetUsersQueryHandler(USContext context)
        {
            _context = context;
        }

        public async Task<GetUsersDTO> Handle(GetUsersQuery request, CancellationToken cancellationToken)
        {
            var data = await _context.userModels.ToListAsync();

            return new GetUsersDTO
            {
                Success = true,
                Message = "Success retreiving data",
                Data = data
            };
        }
    }
}
