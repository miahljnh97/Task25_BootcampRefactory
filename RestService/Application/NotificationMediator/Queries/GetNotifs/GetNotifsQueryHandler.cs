using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using RestService.Application.NotificationMediator.Queries.GetNotif;
using RestService.Models;

namespace RestService.Application.NotificationMediator.Queries.GetNotifs
{
    public class GetNotifsQueryHandler : IRequestHandler<GetNotifsQuery, GetNotifsDTO>
    {
        private readonly RSContext _context;
        public GetNotifsQueryHandler(RSContext context)
        {
            _context = context;
        }

        public async Task<GetNotifsDTO> Handle(GetNotifsQuery request, CancellationToken cancellationToken)
        {
            var data = await _context.notifs.ToListAsync();
            var result = new List<NotifData>();

            foreach (var x in data)
            {
                result.Add(new NotifData
                {
                    Id = x.Id,
                    Title = x.Title,
                    Message = x.Message
                });
            }

            return new GetNotifsDTO
            {
                Success = true,
                Message = "Success retreiving data",
                Data = result
            };
        }
    }
}
