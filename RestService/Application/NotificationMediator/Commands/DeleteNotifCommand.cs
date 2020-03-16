using System;
using RestService.Application.NotificationMediator.Request;
using MediatR;

namespace RestService.Application.NotificationMediator.Commands
{
    public class DeleteNotifCommand : IRequest<NotifDTO>
    {
        public int Id { get; set; }
        public DeleteNotifCommand(int id)
        {
            Id = id;
        }
    }
}
