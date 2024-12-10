using Core.Persistence.Repositories;
using ECommerce.Domain.Entities;
using ECommerce.Persistence.Abstracts;
using ECommerce.Persistence.Contexts;
namespace ECommerce.Persistence.Concretes;
public class CategoryRepository : EfRepositoryBase<Category, int, BaseDbContext>, ICategoryRepository
{
    public CategoryRepository(BaseDbContext context) : base(context)
    {

    }
}