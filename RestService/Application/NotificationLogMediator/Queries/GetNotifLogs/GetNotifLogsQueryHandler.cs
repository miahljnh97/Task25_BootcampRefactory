using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using RestService.Application.NotificationLogMediator.Queries.GetNotifLog;
using RestService.Application.NotificationLogMediator.Queries.GetNotifLogs;
using RestService.Models;

namespace RestService.Application.NotificationLogMediator.Queries.GetNotifs
{
    public class GetNotifLogsQueryHandler : IRequestHandler<GetNotifLogsQuery, GetNotifLogsDTO>
    {
        private readonly RSContext _context;
        public GetNotifLogsQueryHandler(RSContext context)
        {
            _context = context;
        }

        public async Task<GetNotifLogsDTO> Handle(GetNotifLogsQuery request, CancellationToken cancellationToken)
        {
            var data = await _context.notifLogs.ToListAsync();
            var result = new List<NotifLogData>();

            foreach (var x in data)
            {
                result.Add(new NotifLogData
                {
                    Id = x.Id,
                    Notification_id = x.Notification_id,
                    Type = x.Type,
                    From = x.From,
                    Target = x.Target,
                    Email_destination = x.Email_destination,
                    Read_at = x.Read_at
                });
            }

            return new GetNotifLogsDTO
            {
                Success = true,
                Message = "Success retreiving data",
                Data = result
            };
        }
    }
}
