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

namespace OnionProject.Application.Features.Queries.LoginUser
{
    public class LoginUserQueryHandler : IRequestHandler<LoginUserQueryRequest, Response<LoginUserQueryResponse>>
    {
        private IUserAuthService _userAuthService;

        public LoginUserQueryHandler(IUserAuthService userAuthService)
        {
            _userAuthService = userAuthService;
        }

        public async Task<Response<LoginUserQueryResponse>> Handle(LoginUserQueryRequest request, CancellationToken cancellationToken)
        {
            var response = await _userAuthService.Authenticate(request);
            if (response != null)
                return Response<LoginUserQueryResponse>.Success(response, (int)HttpStatusCode.OK);
            //throw new AuthenticationErrorException();
            return Response<LoginUserQueryResponse>.Fail("Kullanıcı adı veya şifre yanlış", (int)HttpStatusCode.BadRequest);
        }
    }
}
