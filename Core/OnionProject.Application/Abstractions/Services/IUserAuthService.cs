using OnionProject.Application.Features.Queries.LoginUser;

namespace OnionProject.Application.Abstractions.Services
{
    public interface IUserAuthService
    {
        Task<LoginUserQueryResponse> Authenticate(LoginUserQueryRequest userAuthRequestDto);
    }
}
