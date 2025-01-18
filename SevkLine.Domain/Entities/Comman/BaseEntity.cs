namespace SevkLine.Domain.Entities.Comman;

public class BaseEntity
{
    public Guid Id { get; set; }
    public DateTime CreatedDate { get; set; }
    public virtual DateTime UpdateDate { get; set; } // Ovverride ediliyor. (eziliyor)
}