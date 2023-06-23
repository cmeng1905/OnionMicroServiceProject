using Azure.Core;
using OnionProject.Application.Abstractions.Services;
using OnionProject.Application.Abstractions.UnitOfWork;
using OnionProject.Application.Dtos.Token;
using OnionProject.Application.Features.Commands.LoginUser;
using OnionProject.Application.Features.Commands.RefreshLoginUser;
using OnionProject.Domain.Entities.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace OnionProject.Persistence.Services
{
    public class AuthService : IAuthService
    {
        private IUnitOfWorkRepo _unitOfWork;
        private ITokenService _tokenService;
        public AuthService(IUnitOfWorkRepo unitOfWork, ITokenService tokenService)
        {
            _unitOfWork = unitOfWork;
            _tokenService = tokenService;
        }

        private Claim[] GetClaimsIdentity(User user)
        {
            return GetClaims();
            Claim[] GetClaims()
            {
                var claims = new List<Claim> { new Claim(ClaimTypes.Name, user.UserName) };
                foreach (var item in user.UserRoles)
                {
                    claims.Add(new Claim(ClaimsIdentity.DefaultRoleClaimType, item.AspNetRole.Name));
                }
                return claims.ToArray();
            }
        }

        public async Task<LoginUserCommandResponse> LoginAsync(string username, string password)
        {
            var user = await _unitOfWork.UserReadRepository.GetAsync(s => s.UserName == username && s.Password == password);
            if (user == null)
                return null;
            return new LoginUserCommandResponse
            {
                TokenDto = CreateToken(user)
            };
        }

        public async Task<RefreshLoginUserCommandResponse> RefreshAsync(string username, string refreshToken)
        {
            var user = await _unitOfWork.UserReadRepository.GetAsync(s => s.UserName == username &&
            s.RefreshToken == refreshToken && s.RefreshTokenExpireDate > DateTime.Now);
            if (user == null)
                return null;
            return new RefreshLoginUserCommandResponse
            {
                TokenDto = CreateToken(user)
            };
        }

        private TokenDto CreateToken(User user)
        {
            var claims = GetClaimsIdentity(user);
            var accessToken = _tokenService.GenerateAccessToken(claims);
            var refreshToken = _tokenService.GenerateRefreshToken();

            TokenDto userAuthResponseDto = new()
            {
                Username = user.UserName,
                Token = accessToken,
                RefreshToken = refreshToken,
                RefreshTokenExpireDate = DateTime.Now.AddMinutes(10)
            };
            user.RefreshToken = userAuthResponseDto.RefreshToken;
            user.RefreshTokenExpireDate = userAuthResponseDto.RefreshTokenExpireDate;
            _unitOfWork.Save();
            return userAuthResponseDto;
        }
    }
}
