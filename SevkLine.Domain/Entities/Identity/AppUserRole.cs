using Microsoft.AspNetCore.Identity;

namespace SevkLine.Domain.Entities.Identity;

public class AppUserRole : IdentityUserRole<string>
{
    public Guid UserId { get; set; }
    public Guid RoleId { get; set; }
    
    public AppUser User { get; set; }
    public AppRole Role { get; set; }
}