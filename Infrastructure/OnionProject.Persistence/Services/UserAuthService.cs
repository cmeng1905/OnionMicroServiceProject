﻿using Microsoft.IdentityModel.Tokens;
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
using System.Text;
using System.Threading.Tasks;

namespace OnionProject.Persistence.Services
{
    public class UserAuthService : IUserAuthService
    {
        private IUnitOfWorkRepo _unitOfWork;
        private readonly AppSettings _appSettings;

        public UserAuthService(AppSettings appSettings,IUnitOfWorkRepo unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _appSettings = appSettings;
        }

        public async Task<LoginUserQueryResponse> Authenticate(LoginUserQueryRequest userAuthRequestDto)
        {
            Claim[] GetClaimsIdentity(User user)
            {
                return GetClaims();
                Claim[] GetClaims()
                {
                    var claims = new List<Claim> { new Claim(ClaimTypes.Name, user.UserName) };
                    foreach (var item in user.AspNetUserRoles)
                    {
                        claims.Add(new Claim(ClaimsIdentity.DefaultRoleClaimType, item.AspNetRole.Name));
                    }
                    return claims.ToArray();
                }
            }

            var user = await _unitOfWork.UserReadRepository.GetAsync(s => s.UserName == userAuthRequestDto.Username);
            if (user == null)
                //throw new NotFoundUserException();
                return null;

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes(_appSettings.JWTSecret);
            var claims = GetClaimsIdentity(user);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenStr = tokenHandler.WriteToken(token);
            LoginUserQueryResponse userAuthResponseDto = new()
            {
                Username=user.UserName,
                Token= tokenStr
            };
            return userAuthResponseDto;
        }
    }
}