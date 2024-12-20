

using Core.Persistence.Repositories;
using Core.Security.Entities;
using ECommerce.Application.Services.Repositories;
using ECommerce.Persistence.Contexts;

namespace ECommerce.Persistence.Concretes;

public class UserOperationClaimRepository(BaseDbContext context) : EfRepositoryBase<UserOperationClaim, int, BaseDbContext>(context), IUserOperationClaimRepository
{
}
