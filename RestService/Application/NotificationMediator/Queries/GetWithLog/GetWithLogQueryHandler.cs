using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using RestService.Application.NotificationMediator.Request;
using RestService.Models;

namespace RestService.Application.NotificationMediator.Queries.GetWithLog
{
    public class GetWithLogQueryHandler : IRequestHandler<GetWithLogQuery, GetWithLogDTO>
    {
        private RSContext _context;
        public GetWithLogQueryHandler(RSContext context)
        {
            _context = context;
        }

        public async Task<GetWithLogDTO> Handle(GetWithLogQuery request, CancellationToken cancellationToken)
        {
            var notifData = await _context.notifs.ToListAsync();
            var notifLogData = await _context.notifLogs.ToListAsync();

            var notifList = new List<NotifDTO>();


            foreach (var k in notifData)
            {
                var logList = new List<NotifLogData>();
                var logs = notifLogData.Where(x => x.Id == k.Id);

                foreach(var l in logs)
                {
                    logList.Add(new NotifLogData()
                    {
                        Notification_id = l.Notification_id,
                        From = l.From,
                        Read_at = l.Read_at,
                        Target = l.Target
                    });
                }

                notifList.Add(new NotifDTO()
                {
                    Notifications = new NotifData()
                    {
                        Id = k.Id,
                        Title = k.Title,
                        Message = k.Message
                    },

                    Notification_logs = logList
                });
            }


            if (notifData == null)
            {
                return null;
            }
            else
            {
                return new GetWithLogDTO
                {
                    Success = true,
                    Message = "Success retreiving data",
                    Data = notifList
                };
            }
        }
    }
}
