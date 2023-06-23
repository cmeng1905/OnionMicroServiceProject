using OnionProject.Application.Features.Commands.LoginUser;
using OnionProject.Domain.Entities.User;
using System.Security.Claims;

namespace OnionProject.Application.Abstractions.Services
{
    public interface ITokenService
    {
        string GenerateAccessToken(Claim[] claims);
        string GenerateRefreshToken();

    }
}
