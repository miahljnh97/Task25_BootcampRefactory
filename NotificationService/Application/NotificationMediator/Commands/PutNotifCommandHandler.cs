using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using NotificationService.Models;

namespace NotificationService.Application.NotificationMediator.Commands
{
    public class PutNotifCommandHandler : IRequestHandler<PutNotifCommand, CommandsDTO>
    {
        private readonly RSContext _context;

        public PutNotifCommandHandler(RSContext context)
        {
            _context = context;
        }

        public async Task<CommandsDTO> Handle(PutNotifCommand request, CancellationToken cancellationToken)
        {
            var notifLog = _context.notificationLogs.ToList();

            var queri = notifLog.Where(x => x.Notification_id == request.Data.Attributes.Notification_id);

            foreach(var k in request.Data.Attributes.Target)
            {
                var data = queri.First(l => l.Target == k.Id).Id;
                var dataContext = await _context.notificationLogs.FindAsync(data);
                dataContext.Read_at = request.Data.Attributes.Read_at;
                await _context.SaveChangesAsync();

            }

            return new CommandsDTO
            {
                Message = "Success retreiving data",
                Success = true
            };
        }
    }
}
