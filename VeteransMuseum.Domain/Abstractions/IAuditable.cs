namespace VeteransMuseum.Domain.Abstractions;

public interface IAuditable
{
    public DateTime CreatedAt { get; set; }
    
    public long CreatedBy { get; set; }
    
    public DateTime? UpdatedAt { get; set; }
    
    public long? UpdatedBy { get; set; }
}