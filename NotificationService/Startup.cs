using System;
using System.Net.Http;
using System.Reflection;
using System.Text;
using System.Threading;
using Hangfire;
using Hangfire.PostgreSql;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NotificationService.Application.NotificationMediator.Queries.GetNotif;
using NotificationService.Models;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace NotificationService
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddMediatR(typeof(GetNotifQueryHandler).GetTypeInfo().Assembly);

            services.AddDbContext<RSContext>(opt =>
            opt.UseNpgsql(Configuration.GetConnectionString("NpgsqlConnection")));

            services.AddHangfire(opt =>
            opt.UsePostgreSqlStorage("Host = localhost; Username = postgres; Password = docker; Database = hangfire_db"));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        [Obsolete]
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseHangfireServer();

            app.UseHangfireDashboard();
            RecurringJob.AddOrUpdate<Listener>(x => x.Receive(), Cron.MinuteInterval(5));
        }
    }

    public class Listener
    {
        public void Receive()
        {
            var client = new HttpClient();
            var factory = new ConnectionFactory() { HostName = "localhost" };
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.ExchangeDeclare("userExchange", "fanout");

                var queueName = channel.QueueDeclare(
                    queue: "userQueue",
                    durable: false,
                    exclusive: false,
                    autoDelete: false,
                    arguments: null);

                channel.QueueBind(queueName, "userExchange", string.Empty);

                var consumer = new EventingBasicConsumer(channel);
                consumer.Received += async (model, ea) =>
                {
                    var body = ea.Body;
                    var message = Encoding.UTF8.GetString(body);
                    var content = new StringContent(message, Encoding.UTF8, "application/json");
                    Console.WriteLine($"Processing data from queue");
                    await client.PostAsync("http://localhost:5007/notification", content);

                };

                channel.BasicConsume(queue: "userQueue",
                                     autoAck: true,
                                     consumer: consumer);
                Console.ReadLine();
                Thread.Sleep(100);
            }
        }
    }
}
