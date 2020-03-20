using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using NotificationService.Application.NotificationMediator.Request;
using NotificationService.Models;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace NotificationService.Application.NotificationMediator.Queries.GetNotifs
{
    public class GetNotifsQueryHandler : IRequestHandler<GetNotifsQuery, GetNotifsDTO>
    {
        private readonly RSContext _context;
        public GetNotifsQueryHandler(RSContext context)
        {
            _context = context;
        }

        public async Task<GetNotifsDTO> Handle(GetNotifsQuery request, CancellationToken cancellationToken)
        {
            var data = await _context.notification.ToListAsync();
            var result = new List<NotifData>();

            foreach (var x in data)
            {
                result.Add(new NotifData
                {
                    Id = x.Id,
                    Title = x.Title,
                    Message = x.Message
                });
            }

            return new GetNotifsDTO
            {
                Success = true,
                Message = "Success retreiving data",
                Data = result
            };
        }

        public void receive()
        {
            var _client = new HttpClient();
            var _factory = new ConnectionFactory() { HostName = "localhost" };
            using (var _connection = _factory.CreateConnection())
            using (var _channel = _connection.CreateModel())
            {
                //_channel.ExchangeDeclare("userDataExchange", "fanout");

                //var queueName = _channel.QueueDeclare();
                //_channel.QueueBind(queueName, "userDataExchange", string.Empty);

                var consumer = new EventingBasicConsumer(_channel);
                consumer.Received += async (model, ea) =>
                {
                    var body = ea.Body;
                    var message = Encoding.UTF8.GetString(body);
                    var content = new StringContent(message, Encoding.UTF8, "application/json");
                    Console.WriteLine($"Processing data from queue");
                    await _client.PostAsync("http://localhost:2000/notification", content);

                };
                _channel.BasicConsume(queue: "userData",
                                     autoAck: true,
                                     consumer: consumer);
                Console.ReadLine();
            }
        }
    }
}
