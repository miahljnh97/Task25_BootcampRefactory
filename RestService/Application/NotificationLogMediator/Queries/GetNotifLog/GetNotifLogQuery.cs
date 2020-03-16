using System;
using MediatR;

namespace RestService.Application.NotificationLogMediator.Queries.GetNotifLog
{
    public class GetNotifLogQuery : IRequest<GetNotifLogDTO>
    {
        public int Id { get; set; }

        public GetNotifLogQuery(int id)
        {
            Id = id;
        }
    }
}
