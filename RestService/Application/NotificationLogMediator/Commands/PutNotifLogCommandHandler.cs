using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using RestService.Application.NotificationLogMediator.Queries.GetNotifLog;
using RestService.Application.NotificationMediator.Queries.GetNotif;
using RestService.Models;

namespace RestService.Application.NotificationLogMediator.Commands
{
    public class PutNotifLogCommandHandler : IRequestHandler<PutNotifLogCommand, GetNotifLogDTO>
    {
        private readonly RSContext _context;

        public PutNotifLogCommandHandler(RSContext context)
        {
            _context = context;
        }

        public async Task<GetNotifLogDTO> Handle(PutNotifLogCommand request, CancellationToken cancellationToken)
        {
            var data = await _context.notifLogs.FindAsync(request.Data.Attributes.Id);

            
            data.Notification_id = request.Data.Attributes.Notification_id;
            data.Type = request.Data.Attributes.Type;
            data.From = request.Data.Attributes.From;
            data.Target = request.Data.Attributes.Target;
            data.Email_destination = request.Data.Attributes.Email_destination;
            data.Read_at = request.Data.Attributes.Read_at;
            _context.SaveChanges();


            return new GetNotifLogDTO
            {
                Message = "Success retreiving data",
                Success = true,
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
