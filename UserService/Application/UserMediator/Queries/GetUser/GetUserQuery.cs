using System;
using MediatR;

namespace UserService.Application.UserMediator.Queries.GetUser
{
    public class GetUserQuery : IRequest<GetUserDTO>
    {
        public int Id { get; set; }
        public GetUserQuery(int id)
        {
            Id = id;
        }
    }
}
