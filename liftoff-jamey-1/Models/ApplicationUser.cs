using Microsoft.AspNetCore.Identity;

namespace liftoff_jamey_1.Models
{
    public class ApplicationUser:IdentityUser
    {
        public string? UserName { get; set; }
        
    }
}