using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using NotificationService.Application.NotificationMediator.Request;
using NotificationService.Models;

namespace NotificationService.Application.NotificationMediator.Queries.GetNotif
{
    public class GetNotifQueryHandler : IRequestHandler< GetNotifQuery, GetNotifDTO>
    {
        private readonly RSContext _context;
        public GetNotifQueryHandler(RSContext context)
        {
            _context = context;
        }

        public async Task<GetNotifDTO> Handle(GetNotifQuery request, CancellationToken cancellationToken)
        {
            var notifData = await _context.notification.FirstAsync(x => x.Id == request.Id);
            var notifLogData = await _context.notificationLogs.Where(x => x.Id == request.Id).ToListAsync();

            var logList = new List<NotifLogData>();

            foreach (var k in notifLogData)
            {
                logList.Add(new NotifLogData()
                {
                    Notification_id = k.Notification_id,
                    From = k.From,
                    Read_at = k.Read_at,
                    Target = k.Target
                });

            }

            if (notifData == null)
            {
                return null;
            }
            else
            {
                return new GetNotifDTO
                {
                    Success = true,
                    Message = "Success retreiving data",
                    data = new NotifDTO
                    {
                        Notifications = new NotifData()
                        {
                            Id = notifData.Id,
                            Title = notifData.Title,
                            Message = notifData.Message
                        },

                        Notification_logs = logList
                    }
                };
            }
        }
    }
}
