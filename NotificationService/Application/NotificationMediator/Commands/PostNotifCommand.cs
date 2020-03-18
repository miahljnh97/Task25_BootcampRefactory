
using System.Collections.Generic;
using MediatR;
using NotificationService.Models;

namespace NotificationService.Application.NotificationMediator.Commands
{
    public class PostNotifCommand : CommandDTO<PostCommand>, IRequest<CommandsDTO>
    {
    }

    public class PostCommand
    {
        public string Title { get; set; }
        public string Message { get; set; }
        public string Type { get; set; }
        public int From { get; set; }
        public List<TargetCommand> Targets { get; set; }
    }

    public class TargetCommand
    {
        public int Id { get; set; }
        public string Email_destination { get; set; }
    }
}
