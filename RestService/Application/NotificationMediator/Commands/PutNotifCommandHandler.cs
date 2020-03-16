using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using RestService.Application.NotificationMediator.Queries.GetNotif;
using RestService.Models;

namespace RestService.Application.NotificationMediator.Commands
{
    public class PutNotifCommandHandler : IRequestHandler<PutNotifCommand, GetNotifDTO>
    {
        private readonly RSContext _context;

        public PutNotifCommandHandler(RSContext context)
        {
            _context = context;
        }

        public async Task<GetNotifDTO> Handle(PutNotifCommand request, CancellationToken cancellationToken)
        {
            var data = await _context.notifs.FindAsync(request.Data.Attributes.Id);

            data.Title = request.Data.Attributes.Title;
            data.Message = request.Data.Attributes.Message;
            _context.SaveChanges();


            return new GetNotifDTO
            {
                Message = "Success retreiving data",
                Success = true,
                Data = new NotifData
                {
                    Id = data.Id,
                    Title = data.Title,
                    Message = data.Message
                }
            };
        }
    }
}
