using System;
using UserService.Models;

namespace UserService.Application.UserMediator.Queries.GetUser
{
    public class GetUserDTO : BaseDTO
    {
        public userData Data { get; set; } 
    }
}
