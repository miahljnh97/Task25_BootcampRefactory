using System.Collections.Generic;
using NotificationService.Application.NotificationMediator.Request;
using NotificationService.Models;

namespace NotificationService.Application.NotificationMediator.Queries.GetWithLog
{
    public class GetWithLogDTO : BaseDTO
    {
        public List<NotifDTO> Data { get; set; }
    }
}
