using System;
using MediatR;
using RestService.Application.NotificationLogMediator.Queries.GetNotifLog;
using RestService.Models;

namespace RestService.Application.NotificationLogMediator.Commands
{
    public class PutNotifLogCommand : CommandDTO<NotificationLogs>, IRequest<GetNotifLogDTO>
    {
    }
}
