using System;

namespace RestService.Application.NotificationLogMediator.Queries.GetNotifLog
{
    public class NotifLogData
    {
        public int Id { get; set; }
        public int Notification_id { get; set; }
        public string Type { get; set; }
        public int From { get; set; }
        public int Target { get; set; }
        public string Email_destination { get; set; }
        public DateTime Read_at { get; set; }
    }
}