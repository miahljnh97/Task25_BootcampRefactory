using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using NotificationService.Application.NotificationMediator.Request;
using NotificationService.Models;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace NotificationService.Application.NotificationMediator.Queries.GetNotifs
{
    public class GetNotifsQueryHandler : IRequestHandler<GetNotifsQuery, GetNotifsDTO>
    {
        private readonly RSContext _context;
        public GetNotifsQueryHandler(RSContext context)
        {
            _context = context;
        }

        public async Task<GetNotifsDTO> Handle(GetNotifsQuery request, CancellationToken cancellationToken)
        {
            var data = await _context.notification.ToListAsync();
            var result = new List<NotifData>();

            foreach (var x in data)
            {
                result.Add(new NotifData
                {
                    Id = x.Id,
                    Title = x.Title,
                    Message = x.Message
                });
            }

            return new GetNotifsDTO
            {
                Success = true,
                Message = "Success retreiving data",
                Data = result
            };
        }
    }
}