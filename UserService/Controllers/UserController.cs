using System;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using RestService.Application.NotificationMediator.Queries.GetNotifs;
using UserService.Application.NotificationMediator.Commands;
using UserService.Application.UserMediator.Queries.GetUser;

namespace UserService.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class UserController : ControllerBase
    {
        private IMediator _mediatr;
        public UserController(IMediator mediator)
        {
            _mediatr = mediator;
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var notif = new GetUsersQuery();

            return Ok(await _mediatr.Send(notif));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(int id)
        {
            var notif = new GetUserQuery(id);

            return Ok(await _mediatr.Send(notif));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteById(int id)
        {
            var notif = new DeleteUserCommand(id);
            var result = await _mediatr.Send(notif);
            return result != null ? (IActionResult)Ok(new { Message = "success" }) : NotFound(new { Message = "Notification not found" });
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, PutUserCommand data)
        {
            data.Data.Attributes.Id = id;
            var result = await _mediatr.Send(data);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync(PostUserCommand data)
        {
            var result = await _mediatr.Send(data);
            return Ok(result);
        }
    }
}
