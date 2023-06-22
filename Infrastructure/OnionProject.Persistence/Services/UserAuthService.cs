using Microsoft.IdentityModel.Tokens;
using OnionProject.Application.Abstractions.Services;
using OnionProject.Application.Abstractions.UnitOfWork;
using OnionProject.Application.Exceptions;
using OnionProject.Application.Features.Queries.LoginUser;
using OnionProject.Application.Repositories.User;
using OnionProject.Domain.Entities.User;
using OnionProject.Persistence.Configurations;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace OnionProject.Persistence.Services
{
    public class UserAuthService : IUserAuthService
    {
        private IUnitOfWorkRepo _unitOfWork;
        private readonly AppSettings _appSettings;

        public UserAuthService(AppSettings appSettings, IUnitOfWorkRepo unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _appSettings = appSettings;
        }

        private static string GenerateRefreshToken()
        {
            var randomNumber = new byte[64];
            using var rng = RandomNumberGenerator.Create();
            rng.GetBytes(randomNumber);
            return Convert.ToBase64String(randomNumber);
        }

        public async Task<LoginUserQueryResponse> Authenticate(LoginUserQueryRequest userAuthRequestDto)
        {
            Claim[] GetClaimsIdentity(User user)
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

            var user = await _unitOfWork.UserReadRepository.GetAsync(s => s.UserName == userAuthRequestDto.Username && s.Password == userAuthRequestDto.Password);
            if (user == null)
                //throw new NotFoundUserException();
                return null;

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes(_appSettings.JWTSecret);
            var claims = GetClaimsIdentity(user);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddSeconds(30),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var refreshToken = GenerateRefreshToken();
            var tokenStr = tokenHandler.WriteToken(token);
            LoginUserQueryResponse userAuthResponseDto = new()
            {
                Username = user.UserName,
                Token = tokenStr,
                RefreshToken = refreshToken,
                RefreshTokenExpireDate = tokenDescriptor.Expires.Value.AddMinutes(5)
            };
            user.RefreshToken = userAuthResponseDto.RefreshToken;
            user.RefreshTokenExpireDate = userAuthResponseDto.RefreshTokenExpireDate;
            _unitOfWork.Save();
            return userAuthResponseDto;
        }
    }
}
