using System;
using System.Collections.Generic;

namespace NotificationService.Application.NotificationMediator.Request
{
    public class NotifDTO
    {
        public NotifData Notifications { get; set; }
        public List<NotifLogData> Notification_logs { get; set; }
    }

    public class NotifLogData
    {
        public int Notification_id { get; set; }
        public string Type { get; set; }
        public int From { get; set; }
        public int Target { get; set; }
        public DateTime Read_at { get; set; }
    }

    public class NotifData
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Message { get; set; }
    }
}
