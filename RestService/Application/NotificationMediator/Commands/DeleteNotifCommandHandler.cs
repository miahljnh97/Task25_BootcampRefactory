using System;
using System.Threading;
using System.Threading.Tasks;
using RestService.Application.NotificationMediator.Request;
using MediatR;
using RestService.Models;

namespace RestService.Application.NotificationMediator.Commands
{
    public class DeleteNotifCommandHandler : IRequestHandler<DeleteNotifCommand, NotifDTO>
    {
        private readonly RSContext _context;
        public DeleteNotifCommandHandler(RSContext context)
        {
            _context = context;
        }

        public async Task<NotifDTO> Handle(DeleteNotifCommand request, CancellationToken cancellationToken)
        {
            var data = await _context.notifs.FindAsync(request.Id);

            if (data == null)
            {
                return null;
            }

            _context.notifs.Remove(data);
            await _context.SaveChangesAsync();

            return new NotifDTO { Message = "Successfull", Success = true };
        }
    }
}
