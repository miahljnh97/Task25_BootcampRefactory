using System;
namespace RestService.Models
{
    public class Notification
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Message { get; set; }
        public DateTime Created_at { get; set; } = DateTime.Now;
        public DateTime Update_at { get; set; } = DateTime.Now;
    }

    public class NotificationLogs
    {
        public int Id { get; set; }
        public int Notification_id { get; set; }
        public string Type { get; set; }
        public int From { get; set; }
        public int Target { get; set; }
        public string Email_destination { get; set; }
        public DateTime Read_at { get; set; }
        public DateTime Created_at { get; set; } = DateTime.Now;
        public DateTime Update_at { get; set; } = DateTime.Now;

        public Notification notif { get; set; }
    }

    public class RequestData<T>
    {
        public Data<T> data { get; set; }
    }

    public class Data<T>
    {
        public T attributes { get; set; }
    }
}
