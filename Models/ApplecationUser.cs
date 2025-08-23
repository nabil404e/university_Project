using Microsoft.AspNetCore.Identity;

namespace university_Project.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string Address { get; set; }
       
    }
}
