using System;
using RestService.Application.NotificationLogMediator.Request;
using MediatR;

namespace RestService.Application.NotificationLogMediator.Commands
{
    public class DeleteNotifLogCommand : IRequest<NotifLogsDTO>
    {
        public int Id { get; set; }
        public DeleteNotifLogCommand(int id)
        {
            Id = id;
        }
    }
}
