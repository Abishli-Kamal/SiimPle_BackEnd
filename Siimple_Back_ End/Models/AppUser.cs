using Microsoft.AspNetCore.Identity;

namespace Siimple_Back__End.Models
{
    public class AppUser:IdentityUser
    {
        public string Name { get; set; }
        public string Surname { get; set; }
    }
}
