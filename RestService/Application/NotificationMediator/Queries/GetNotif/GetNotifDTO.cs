using System;
using RestService.Models;

namespace RestService.Application.NotificationMediator.Queries.GetNotif
{
    public class GetNotifDTO : BaseDTO
    {
        public NotifData Data { get; set; }
    }
}
