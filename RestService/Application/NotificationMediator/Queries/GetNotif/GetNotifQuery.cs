﻿using MediatR;

namespace RestService.Application.NotificationMediator.Queries.GetNotif
{
    public class GetNotifQuery : IRequest<GetNotifDTO>
    {
        public int Id { get; set; }

        public GetNotifQuery(int id)
        {
            Id = id;
        }
    }
}
