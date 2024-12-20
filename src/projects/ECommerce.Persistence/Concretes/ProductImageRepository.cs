﻿using Core.Persistence.Repositories;
using ECommerce.Application.Services.Repositories;
using ECommerce.Domain.Entities;
using ECommerce.Persistence.Contexts;

namespace ECommerce.Persistence.Concretes;

public class ProductImageRepository(BaseDbContext context) : EfRepositoryBase<ProductImage,int,BaseDbContext>(context) , IProductImageRepository
{
}
