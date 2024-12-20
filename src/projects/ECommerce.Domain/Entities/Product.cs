

using Core.Persistence.Repositories;

namespace ECommerce.Domain.Entities;

public sealed class Product : Entity<Guid>
{
    public string Name { get; set; }
    public decimal Price { get; set; }
    public string Description { get; set; }
    public int Stock { get; set; }
    public Category Category { get; set; }
    public int CategoryId { get; set; }
    public ICollection<ProductImage> ProductImages { get; set; }
}
