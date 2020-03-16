using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using RestService.Models;

namespace RestService.Application.NotificationLogMediator.Queries.GetNotifLog
{
    public class GetNotifLogQueryHandler : IRequestHandler< GetNotifLogQuery, GetNotifLogDTO>
    {
        private readonly RSContext _context;
        public GetNotifLogQueryHandler(RSContext context)
        {
            _context = context;
        }

        public async Task<GetNotifLogDTO> Handle(GetNotifLogQuery request, CancellationToken cancellationToken)
        {
            var data = await _context.notifLogs.FindAsync(request.Id);

            if (data == null)
            {
                return null;
            }
            else
            {
                return new GetNotifLogDTO
                {
                    Success = true,
                    Message = "Success retreiving data",
                    Data = new NotifLogData
                    {
                        Id = data.Id,
                        Notification_id = data.Notification_id,
                        Type = data.Type,
                        From = data.From,
                        Target = data.Target,
                        Email_destination = data.Email_destination,
                        Read_at = data.Read_at
                    }
                };
            }
        }
    }
}
