using VeteransMuseum.Domain.Abstractions;
using VeteransMuseum.Domain.Shared;

namespace VeteransMuseum.Domain.News;

public class News : Entity, IAuditable
{
    private News(
        Guid id,
        Title title,
        Content content,
        ImageUrl imageUrl,
        DateTime createdAt,
        long createdBy,
        DateTime? updatedAt,
        long? updatedBy)
        : base(id)
    {
        Title = title;
        Content = content;
        ImageUrl = imageUrl;
        CreatedAt = createdAt;
        CreatedBy = createdBy;
        UpdatedAt = updatedAt;
        UpdatedBy = updatedBy;
    }
    
    private News() {}
    
    public Title Title { get; private set; }
    
    public Content Content { get; private set; }
    
    public ImageUrl ImageUrl { get; private set; }
    
    public DateTime CreatedAt { get; set; }
    
    public long CreatedBy { get; set; }
    
    public DateTime? UpdatedAt { get; set; }
    
    public long? UpdatedBy { get; set; }
}