using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using RestService.Models;

namespace RestService.Application.NotificationMediator.Queries.GetNotif
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
            var data = await _context.notifs.FindAsync(request.Id);

            if (data == null)
            {
                return null;
            }
            else
            {
                return new GetNotifDTO
                {
                    Success = true,
                    Message = "Success retreiving data",
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
}
