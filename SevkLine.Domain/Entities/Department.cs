using SevkLine.Domain.Common;
using SevkLine.Domain.Entities.Identity;

namespace SevkLine.Domain.Entities;

public class Department : AuditableEntity, ISoftDeleteEntity
{
    public required string Name { get; set; }
    
    public bool IsDeleted { get; set; }
    public DateTimeOffset? DeletedAt { get; set; }
    
    //Releations
    public ICollection<AppUser> AppUsers { get; set; } = new HashSet<AppUser>();

}