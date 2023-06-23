using OnionProject.Application.Features.Commands.LoginUser;
using OnionProject.Application.Features.Commands.RefreshLoginUser;
using OnionProject.Domain.Entities.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionProject.Application.Abstractions.Services
{
    public interface IAuthService
    {
        Task<LoginUserCommandResponse> LoginAsync(string username, string password);

        Task<RefreshLoginUserCommandResponse> RefreshAsync(string username, string refreshToken);
    }
}
