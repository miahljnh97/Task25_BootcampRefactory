using System.Collections.Generic;
using RestService.Application.NotificationMediator.Request;
using RestService.Models;

namespace RestService.Application.NotificationMediator.Queries.GetNotifs
{
    public class GetNotifsDTO : BaseDTO
    {
        public List<NotifData> Data { get; set; }
    }
}
