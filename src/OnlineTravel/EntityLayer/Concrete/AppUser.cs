using Microsoft.AspNetCore.Identity;

namespace EntityLayer.Concrete
{
    public class AppUser : IdentityUser<int>
    {
        public string? Name { get; set; }

        public string? Surname { get; set; }

        public string? ImageUrl { get; set; }

        public bool Gender { get; set; }

        public List<Rezervation>? Rezervations { get; set; }

        public bool Status { get; set; }
    }
}
