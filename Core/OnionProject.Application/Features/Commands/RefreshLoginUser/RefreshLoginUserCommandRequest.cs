using MediatR;
using OnionProject.Application.Dtos.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionProject.Application.Features.Commands.RefreshLoginUser
{
    public class RefreshLoginUserCommandRequest : IRequest<Response<RefreshLoginUserCommandResponse>>
    {
        public string UserName { get; set; }

        public string RefreshToken { get; set; }
    }
}
