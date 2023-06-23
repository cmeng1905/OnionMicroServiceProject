using OnionProject.Application.Dtos.Token;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionProject.Application.Features.Commands.LoginUser
{
    public class LoginUserCommandResponse
    {
        public TokenDto TokenDto { get; set; }

    }
}
