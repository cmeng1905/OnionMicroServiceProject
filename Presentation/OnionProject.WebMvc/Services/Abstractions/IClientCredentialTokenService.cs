namespace OnionProject.WebMvc.Services.Abstractions
{
    public interface IClientCredentialTokenService
    {
        string GetToken();

        string GetUserName();

        string GetRefreshToken();
    }
}
