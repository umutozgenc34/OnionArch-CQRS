using Core.Persistence.Repositories;
using ECommerce.Application.Services.Repositories;
using ECommerce.Domain.Entities;
using ECommerce.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Persistence.Concretes;

public class ProductRepository(BaseDbContext context) : EfRepositoryBase<Product,Guid,BaseDbContext>(context) , IProductRepository
{
}
