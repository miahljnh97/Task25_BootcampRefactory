using System;
using RestService.Application.NotificationMediator.Queries.GetNotif;
using MediatR;
using RestService.Models;

namespace RestService.Application.NotificationMediator.Commands
{
    public class PostNotifCommand : CommandDTO<Notification>, IRequest<GetNotifDTO>
    {
    }
}
