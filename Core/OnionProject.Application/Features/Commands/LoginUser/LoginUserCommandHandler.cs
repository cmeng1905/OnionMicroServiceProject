using MediatR;
using OnionProject.Application.Abstractions.Services;
using OnionProject.Application.Dtos.Response;
using OnionProject.Application.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace OnionProject.Application.Features.Commands.LoginUser
{
    public class LoginUserCommandHandler : IRequestHandler<LoginUserCommandRequest, Response<LoginUserCommandResponse>>
    {
        private IAuthService _authService;
        public LoginUserCommandHandler(IAuthService authService, IUserService userService)
        {
            _authService = authService;
        }

        public async Task<Response<LoginUserCommandResponse>> Handle(LoginUserCommandRequest request, CancellationToken cancellationToken)
        {

            var response = await _authService.LoginAsync(request.Username, request.Password);
            if (response != null)
                return Response<LoginUserCommandResponse>.Success(response, (int)HttpStatusCode.OK);
            //throw new AuthenticationErrorException();            
            return Response<LoginUserCommandResponse>.Fail("Kullanıcı adı veya şifre yanlış", (int)HttpStatusCode.BadRequest);
        }
    }
}
