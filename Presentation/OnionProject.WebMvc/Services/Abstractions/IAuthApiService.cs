namespace OnionProject.WebMvc.Services.Abstractions
{
    public interface IAuthApiService
    {
         Task<bool> LoginAsync(string username, string password);
         Task<bool> RefreshLoginAsync(string username, string refreshToken);
        void Logout();
    }
}
