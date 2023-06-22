namespace OnionProject.WebMvc.Models
{
    public class ServiceApiSettings
    {
        public string AuthBaseUri { get; set; }
        public string GatewayBaseUri { get; set; }
        public string ProductBaseUri { get; set; }
        public ServiceApi Auth { get; set; }
        public ServiceApi Product { get; set; }
    }

    public class ServiceApi
    {
        public string Path { get; set; }
    }
}
