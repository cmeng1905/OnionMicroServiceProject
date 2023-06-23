using MediatR;
using OnionProject.Application.Dtos.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionProject.Application.Features.Commands.LoginUser
{
    public class LoginUserCommandRequest : IRequest<Response<LoginUserCommandResponse>>
    {
        public string Username { get; set; }

        public string Password { get; set; }
    }
}
