using Microsoft.AspNetCore.Identity;

namespace SevkLine.Domain.Entities.Identity
{
    public class AppRole : IdentityRole<string>
    {
        public Guid Id { get; set; }
        public ICollection<AppUserRole> UserRoles { get; set; }
    }
}
