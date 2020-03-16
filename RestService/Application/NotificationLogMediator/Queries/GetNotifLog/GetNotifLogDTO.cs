using System;
using RestService.Models;

namespace RestService.Application.NotificationLogMediator.Queries.GetNotifLog
{
    public class GetNotifLogDTO : BaseDTO
    {
        public NotifLogData Data { get; set; }
    }
}
