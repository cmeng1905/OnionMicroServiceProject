using Microsoft.IdentityModel.Tokens;
using OnionProject.Application.Abstractions.Services;
using OnionProject.Application.Abstractions.UnitOfWork;
using OnionProject.Application.Exceptions;
using OnionProject.Application.Features.Commands.LoginUser;
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
    public class TokenService : ITokenService
    {
        private readonly AppSettings _appSettings;

        public TokenService(AppSettings appSettings, IUnitOfWorkRepo unitOfWork)
        {
            _appSettings = appSettings;
        }

        public string GenerateRefreshToken()
        {
            var randomNumber = new byte[64];
            using var rng = RandomNumberGenerator.Create();
            rng.GetBytes(randomNumber);
            return Convert.ToBase64String(randomNumber);
        }
       
        public string GenerateAccessToken(Claim[] claims)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes(_appSettings.JWTSecret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddMinutes(5),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenStr = tokenHandler.WriteToken(token);
            return tokenStr;
        }

    }
}
