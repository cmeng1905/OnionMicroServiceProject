using MediatR;
using OnionProject.Application.Abstractions.Services;
using OnionProject.Application.Dtos.Response;
using OnionProject.Application.Features.Commands.LoginUser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace OnionProject.Application.Features.Commands.RefreshLoginUser
{
    public class RefreshLoginUserCommandHandler : IRequestHandler<RefreshLoginUserCommandRequest, Response<RefreshLoginUserCommandResponse>>
    {
        private readonly IAuthService _authService;

        public RefreshLoginUserCommandHandler(IAuthService authService)
        {
            _authService = authService;
        }

        public async Task<Response<RefreshLoginUserCommandResponse>> Handle(RefreshLoginUserCommandRequest request, CancellationToken cancellationToken)
        {
            var response = await _authService.RefreshAsync(request.UserName, request.RefreshToken);
            if (response != null)
            {
                return Response<RefreshLoginUserCommandResponse>.Success(response, (int)HttpStatusCode.OK);
            }
            return Response<RefreshLoginUserCommandResponse>.Fail("Refresh Token hatalı ya da süresi geçmiş", (int)HttpStatusCode.BadRequest);
        }
    }
}
