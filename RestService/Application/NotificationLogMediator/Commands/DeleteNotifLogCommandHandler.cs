using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using RestService.Models;
using RestService.Application.NotificationLogMediator.Commands;
using RestService.Application.NotificationLogMediator.Request;

namespace RestService.Application.NotificationMediator.Commands
{
    public class DeleteNotifLogCommandHandler : IRequestHandler<DeleteNotifLogCommand, NotifLogsDTO>
    {
        private readonly RSContext _context;
        public DeleteNotifLogCommandHandler(RSContext context)
        {
            _context = context;
        }

        public async Task<NotifLogsDTO> Handle(DeleteNotifLogCommand request, CancellationToken cancellationToken)
        {
            var data = await _context.notifLogs.FindAsync(request.Id);

            if (data == null)
            {
                return null;
            }

            _context.notifLogs.Remove(data);
            await _context.SaveChangesAsync();

            return new NotifLogsDTO { Message = "Successfull", Success = true };
        }
    }
}
