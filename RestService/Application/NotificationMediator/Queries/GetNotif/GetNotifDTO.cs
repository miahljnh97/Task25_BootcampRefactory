using RestService.Application.NotificationMediator.Request;
using RestService.Models;

namespace RestService.Application.NotificationMediator.Queries.GetNotif
{
    public class GetNotifDTO : BaseDTO
    {
        public NotifDTO data { get; set; }
    }
}
