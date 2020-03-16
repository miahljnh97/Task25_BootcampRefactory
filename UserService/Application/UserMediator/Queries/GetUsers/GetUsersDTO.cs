using System;
using System.Collections.Generic;
using UserService.Application.UserMediator.Queries.GetUser;
using UserService.Models;

namespace RestService.Application.NotificationMediator.Queries.GetNotifs
{
    public class GetUsersDTO : BaseDTO
    {
        public List<userData> Data { get; set; }
    }
}
