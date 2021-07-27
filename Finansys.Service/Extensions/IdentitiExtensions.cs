using System.Linq;
using System.Security.Claims;
using System.Security.Principal;

namespace System
{
    public static class IdentitiExtensions
    {
        public static String GetuserName(this ClaimsPrincipal user)
        {
            if (user == null)
                return null;
            return user.Claims.FirstOrDefault(c => c.Type == "username")?.Value;
        }
    }
}
