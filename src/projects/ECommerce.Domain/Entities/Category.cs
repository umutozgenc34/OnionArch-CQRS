using Core.Persistence.Repositories;
namespace ECommerce.Domain.Entities;

public class Category : Entity<int>
{
    public string Name { get; set; }
}
