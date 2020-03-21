using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Newtonsoft.Json;
using RabbitMQ.Client;
using UserService.Application.UserMediator.Request;
using UserService.Models;

namespace UserService.Application.NotificationMediator.Commands
{
    public class PostUserCommandHandler : IRequestHandler<PostUserCommand, UserDTO>
    {
        private readonly USContext _context;
        private static readonly HttpClient client = new HttpClient();

        public PostUserCommandHandler(USContext context)
        {
            _context = context;
        }

        public async Task<UserDTO> Handle(PostUserCommand request, CancellationToken cancellationToken)
        {
            var data = new userModel()
            {
                Name = request.Data.Attributes.Name,
                Username = request.Data.Attributes.Username,
                Email = request.Data.Attributes.Email,
                Password = request.Data.Attributes.Password,
                Address = request.Data.Attributes.Address
            };

            _context.Add(data);
            await _context.SaveChangesAsync();

            var user = _context.userModels.First(x => x.Username == request.Data.Attributes.Username);
            var target = new TargetCommand() { Id = user.Id, Email_destination = user.Email };

            var command = new PostCommand()
            {
                Title = "hello",
                Message = "this is message body",
                Type = "email",
                From = 123456,
                Targets = new List<TargetCommand>() { target }
            };

            var attributes = new Attribute<PostCommand>()
            {
                Attributes = command
            };

            var httpContent = new CommandDTO<PostCommand>()
            {
                Data = attributes
            };

            var jsonObject = JsonConvert.SerializeObject(httpContent);


            var factory = new ConnectionFactory() { HostName = "localhost" };
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.ExchangeDeclare("userExchange", "fanout");
                channel.QueueDeclare(
                    queue: "userQueue",
                    durable: false,
                    exclusive: false,
                    autoDelete: false,
                    arguments: null);

                channel.QueueBind(
                    queue: "userQueue",
                    exchange: "userExchange",
                    routingKey: string.Empty
                    );

                var body = Encoding.UTF8.GetBytes(jsonObject);

                var properties = channel.CreateBasicProperties();
                properties.Persistent = true;

                channel.BasicPublish(
                    exchange: "",
                    routingKey: "userQueue",
                    basicProperties: null,
                    body: body
                    );

                Console.WriteLine("User data has been forwarded");
            }

            return new UserDTO()
            {
                Message = "Successfully Added",
                Success = true
            };
        }
    }
}
