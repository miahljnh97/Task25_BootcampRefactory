using MediatR;

namespace NotificationService.Application.NotificationMediator.Commands
{
    public class DeleteNotifCommand : IRequest<CommandsDTO>
    {
        public int Id { get; set; }
        public DeleteNotifCommand(int id)
        {
            Id = id;
        }
    }
}
