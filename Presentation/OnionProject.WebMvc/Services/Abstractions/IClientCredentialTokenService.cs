namespace OnionProject.WebMvc.Services.Abstractions
{
    public interface IClientCredentialTokenService
    {
        Task<string> GetToken();

        string GetUserName();

        Task<string> GetRefreshToken();
    }
}
