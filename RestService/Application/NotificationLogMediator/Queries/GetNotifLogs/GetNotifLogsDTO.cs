using System;
using System.Collections.Generic;
using RestService.Application.NotificationLogMediator.Queries.GetNotifLog;
using RestService.Models;

namespace RestService.Application.NotificationLogMediator.Queries.GetNotifLogs
{
    public class GetNotifLogsDTO : BaseDTO
    {
        public List<NotifLogData> Data { get; set; }
    }
}
