using NotificationService.Application.NotificationMediator.Request;
using NotificationService.Models;

namespace NotificationService.Application.NotificationMediator.Queries.GetNotif
{
    public class GetNotifDTO : BaseDTO
    {
        public NotifDTO data { get; set; }
    }
}
