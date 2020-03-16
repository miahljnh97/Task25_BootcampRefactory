using System;
using MediatR;
using RestService.Application.NotificationLogMediator.Queries.GetNotifLog;
using RestService.Models;

namespace RestService.Application.NotificationLogMediator.Commands
{
    public class PostNotifLogCommand : CommandDTO<NotificationLogs>, IRequest<GetNotifLogDTO>
    {
    }
}
