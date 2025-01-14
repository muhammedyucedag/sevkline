using SevkLine.Domain.Common;

namespace SevkLine.Domain.Entities;

public class Employee : BaseEntity, ISoftDeleteEntity
{
    public required string PartyIdentification { get; set; }
    public required string FirstName { get; set; }
    public required string FamilyName { get; set; }
    public required string Telephone { get; set; }
    public required string? EmergencyContactNumber { get; set; }
    public DateTimeOffset BirthDate { get; set; }
    public required string Address { get; set; }
    public required string ElectronicMail { get; set; }
    
    public bool IsDeleted { get; set; }
    public DateTimeOffset? DeletedAt { get; set; }
    public Guid? DeletedBy { get; set; }
}