using Microsoft.AspNetCore.Identity;

namespace project_demo.NewFolder2
{
    public interface ItokenRepository
    {
        public string CreateJwtToken(IdentityUser user, string role);
    }
}
