namespace OnionProject.WebMvc.Services.Abstractions
{
    public interface IAuthApiService
    {
        public Task<bool> Authenticate(string username, string password);
        void Logout();
    }
}
