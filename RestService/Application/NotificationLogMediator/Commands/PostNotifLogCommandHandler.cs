using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using RestService.Application.NotificationLogMediator.Queries.GetNotifLog;
using RestService.Models;

namespace RestService.Application.NotificationLogMediator.Commands
{
    public class PostNotifLogCommandHandler : IRequestHandler<PostNotifLogCommand, GetNotifLogDTO>
    {
        private readonly RSContext _context;

        public PostNotifLogCommandHandler(RSContext context)
        {
            _context = context;
        }

        public async Task<GetNotifLogDTO> Handle(PostNotifLogCommand request, CancellationToken cancellationToken)
        {
            _context.notifLogs.Add(request.Data.Attributes);
            await _context.SaveChangesAsync();


            return new GetNotifLogDTO
            {
                Message = "Successfully Added",
                Success = true,
                Data = new NotifLogData
                {
                    Id = request.Data.Attributes.Id,
                    Notification_id = request.Data.Attributes.Notification_id,
                    Type = request.Data.Attributes.Type,
                    From = request.Data.Attributes.From,
                    Target = request.Data.Attributes.Target,
                    Email_destination = request.Data.Attributes.Email_destination,
                    Read_at = request.Data.Attributes.Read_at
                }
            };
        }
    }
}
