using System;
using UserService.Models;

namespace UserService.Application.UserMediator.Queries.GetUser
{
    public class GetUserDTO : BaseDTO
    {
        public userModel Data { get; set; } 
    }
}
