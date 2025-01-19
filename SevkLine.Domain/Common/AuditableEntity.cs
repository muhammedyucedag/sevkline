namespace SevkLine.Domain.Common;

public abstract class AuditableEntity : BaseEntity
{
    public DateTimeOffset Created { get; set; }
    public DateTimeOffset LastModified { get; set; }
}
