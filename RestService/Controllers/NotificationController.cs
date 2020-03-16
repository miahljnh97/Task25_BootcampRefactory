using System;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using RestService.Application.NotificationMediator.Commands;
using RestService.Application.NotificationMediator.Queries.GetNotif;
using RestService.Application.NotificationMediator.Queries.GetNotifs;

namespace RestService.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class NotificationController : ControllerBase
    {
        private IMediator _mediatr;
        public NotificationController(IMediator mediator)
        {
            _mediatr = mediator;
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var notif = new GetNotifsQuery();

            return Ok(await _mediatr.Send(notif));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(int id)
        {
            var notif = new GetNotifQuery(id);

            return Ok(await _mediatr.Send(notif));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteById(int id)
        {
            var notif = new DeleteNotifCommand(id);
            var result = await _mediatr.Send(notif);
            return result != null ? (IActionResult)Ok(new { Message = "success" }) : NotFound(new { Message = "Notification not found" });
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, PutNotifCommand data)
        {
            data.Data.Attributes.Id = id;
            var result = await _mediatr.Send(data);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync(PostNotifCommand data)
        {
            var result = await _mediatr.Send(data);
            return Ok(result);
        }
    }
}
