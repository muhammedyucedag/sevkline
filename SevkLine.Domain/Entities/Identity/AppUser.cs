using Microsoft.AspNetCore.Identity;
using SevkLine.Domain.Common;

namespace SevkLine.Domain.Entities.Identity
{
    public class AppUser : IdentityUser<string>, ISoftDeleteEntity
    {
        public Guid DepartmentId { get; set; }

        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required string PartyIdentification { get; set; }
        public required string Address { get; set; }
        public required string CityName { get; set; }
        public string? RefreshToken { get; set; }
        public string? EmergencyContactNumber { get; set; }
        public DateTime? RefreshTokenEndDate { get; set; }

        public bool IsDeleted { get; set; }
        public DateTimeOffset? DeletedAt { get; set; }
        public Guid? DeletedBy { get; set; }
        
        //Relations
        public required Department Department { get; set; }
    }
}
