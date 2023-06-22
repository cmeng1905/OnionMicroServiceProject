using MediatR;
using OnionProject.Application.Dtos.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionProject.Application.Features.Queries.LoginUser
{
    public class LoginUserQueryRequest: IRequest<Response<LoginUserQueryResponse>>
    {
        public string Username { get; set; }

        public string Password { get; set; }
    }
}
