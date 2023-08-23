using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace SchoolApplication.Models
{
       public abstract class ApplicationUsers : IdentityUser
        {
            // Common properties for all user types
            public abstract string Name { get; set; }
            public abstract int Id { get; set; }
            public abstract string Email { get; set; }
            public abstract string Phone { get; set; }
        }
   
}
