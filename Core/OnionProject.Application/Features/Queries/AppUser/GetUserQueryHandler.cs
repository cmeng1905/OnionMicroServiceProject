using MediatR;
using OnionProject.Application.Abstractions.Services;
using OnionProject.Application.Abstractions.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionProject.Application.Features.Queries.GetUser
{
    public class GetUserQueryHandler : IRequestHandler<GetUserQueryRequest, GetUserQueryResponse>
    {
        private IAspNetUserService _aspNetUserService;

        public GetUserQueryHandler(IAspNetUserService aspNetUserService)
        {
            _aspNetUserService = aspNetUserService;
        }
        public async Task<GetUserQueryResponse> Handle(GetUserQueryRequest request, CancellationToken cancellationToken)
        {
            var user = await _aspNetUserService.GetAsync(request.Username);
            return new GetUserQueryResponse
            {
                User=user
            };
        }
    }
}
