using System;
using System.Collections.Generic;
using MediatR;
using RestService.Models;

namespace RestService.Application.NotificationMediator.Commands
{
    public class PutNotifCommand : CommandDTO<PutCommand>, IRequest<CommandsDTO>
    {
    }

    public class PutCommand
    {
        public int Notification_id { get; set; }
        public DateTime Read_at { get; set; }
        public List<Target> Target { get; set; }
    }

    public class Target
    {
        public int Id { get; set; }
    }
}
