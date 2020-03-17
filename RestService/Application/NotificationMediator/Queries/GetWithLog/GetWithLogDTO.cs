using System.Collections.Generic;
using RestService.Application.NotificationMediator.Request;
using RestService.Models;

namespace RestService.Application.NotificationMediator.Queries.GetWithLog
{
    public class GetWithLogDTO : BaseDTO
    {
        public List<NotifDTO> Data { get; set; }
    }
}
