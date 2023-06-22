using MediatR;
using OnionProject.Domain.Entities.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionProject.Application.Features.Queries.GetUser
{
    public class GetUserQueryRequest:IRequest<GetUserQueryResponse>
    {
        public string Username { get; set; }

        public string Password { get; set; }

    }
}
