using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnionProject.Application.Abstractions.Services;
using OnionProject.Application.ControllerBases;
using OnionProject.Application.Features.Queries.LoginUser;
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
        [HttpPost]
        public async Task<IActionResult> Authenticate(LoginUserQueryRequest loginUserQueryRequest)
        {
            var user = await _mediator.Send(loginUserQueryRequest);
            return CreateActionResultInstance(user);
        }
    }
}
