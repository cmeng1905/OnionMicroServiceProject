using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnionProject.Application.Abstractions.Services;
using OnionProject.Application.ControllerBases;
using OnionProject.Application.Features.Commands.LoginUser;
using OnionProject.Application.Features.Commands.RefreshLoginUser;
using OnionProject.Application.Repositories.User;

namespace OnionArchitecture.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : CustomBaseController
    {
        private IMediator _mediator;
        public AuthController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [AllowAnonymous]
        [HttpPost("Auth")]
        public async Task<IActionResult> Authenticate(LoginUserCommandRequest loginUserQueryRequest)
        {
            var response = await _mediator.Send(loginUserQueryRequest);
            return CreateActionResultInstance(response);
        }

        [AllowAnonymous]
        [HttpPost("Refresh")]
        public async Task<IActionResult> RefreshAuthenticate(RefreshLoginUserCommandRequest refreshLoginUserCommandRequest)
        {
            var response = await _mediator.Send(refreshLoginUserCommandRequest);
            return CreateActionResultInstance(response);
        }
    }
}
