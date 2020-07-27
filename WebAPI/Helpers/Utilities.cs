using System.Linq;
using System.Security.Claims;

namespace WebAPI.Helpers
{
    public static class Utilities
    {
        public static string GetUserId(this ClaimsPrincipal claimsPrincipal)
        {
            string id = claimsPrincipal.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            return id;
        }

        public static string GetSpecificClaim(this ClaimsPrincipal claimsPrincipal, string claimType)
        {
            Claim claim = claimsPrincipal.Claims.FirstOrDefault(x => x.Type == claimType);
            return (claim != null) ? claim.Value : string.Empty;
        }
    }
}
