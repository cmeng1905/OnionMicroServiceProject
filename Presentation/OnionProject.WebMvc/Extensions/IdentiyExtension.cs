using System.Security.Claims;
using System.Security.Principal;

namespace OnionProject.WebMvc.Extensions
{
    public static class IdentiyExtension
    {
        public static string GetUserAuthAccessToken(this IIdentity identity)
        {
            return GetClaimValue(identity, "UserAuthToken");
        }

        public static string GetUserAuthRefreshToken(this IIdentity identity)
        {
            return GetClaimValue(identity, "UserAuthRefreshToken");
        }
        private static string GetClaimValue(IIdentity identity, string claimName)
        {
            try
            {
                var claim = ((ClaimsIdentity)identity).FindFirst(claimName);
                return (claim != null) ? claim.Value : string.Empty;
            }
            catch (Exception)
            {
                return string.Empty;
            }
        }
    }
}
