using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using RestService.Application.NotificationMediator.Queries.GetNotif;
using RestService.Models;

namespace RestService.Application.NotificationMediator.Commands
{
    public class PostNotifCommandHandler : IRequestHandler<PostNotifCommand, GetNotifDTO>
    {
        private readonly RSContext _context;

        public PostNotifCommandHandler(RSContext context)
        {
            _context = context;
        }

        public async Task<GetNotifDTO> Handle(PostNotifCommand request, CancellationToken cancellationToken)
        {
            _context.notifs.Add(request.Data.Attributes);
            await _context.SaveChangesAsync();


            return new GetNotifDTO
            {
                Message = "Successfully Added",
                Success = true,
                Data = new NotifData
                {
                    Id = request.Data.Attributes.Id,
                    Title = request.Data.Attributes.Title,
                    Message = request.Data.Attributes.Message
                }
            };
        }
    }
}
