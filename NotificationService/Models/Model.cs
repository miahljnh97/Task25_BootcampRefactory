using System;
namespace NotificationService.Models
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

    public class userModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Address { get; set; }
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
