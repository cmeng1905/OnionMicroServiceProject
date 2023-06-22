using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionProject.Application.Features.Queries.LoginUser
{
    public class LoginUserQueryResponse
    {
        public string Username { get; set; }

        public string Token { get; set; }

        public string RefreshToken { get; set; }

        public DateTime RefreshTokenExpireDate { get; set; }
    }
}
