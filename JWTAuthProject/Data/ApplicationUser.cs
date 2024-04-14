using Microsoft.AspNetCore.Identity;

namespace JWTAuthProject.Data
{
    public class ApplicationUser : IdentityUser
    {
        public string? Name { get; set; }

    }
}
