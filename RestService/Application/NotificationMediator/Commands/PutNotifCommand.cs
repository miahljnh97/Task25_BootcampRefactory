using System;
using MediatR;
using RestService.Application.NotificationMediator.Queries.GetNotif;
using RestService.Models;

namespace RestService.Application.NotificationMediator.Commands
{
    public class PutNotifCommand : CommandDTO<Notification>, IRequest<GetNotifDTO>
    {
    }
}
