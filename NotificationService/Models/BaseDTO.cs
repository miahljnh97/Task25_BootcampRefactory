
namespace NotificationService.Models
{
    public class BaseDTO
    {
        public bool Success { get; set; }
        public string Message { get; set; }
    }

    public class CommandDTO<T>
    {
        public Attribute<T> Data { get; set; }
    }

    public class Attribute<T>
    {
        public T Attributes { get; set; }
    }
}
