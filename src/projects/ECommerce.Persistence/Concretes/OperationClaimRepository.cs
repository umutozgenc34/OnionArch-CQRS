using Core.Persistence.Repositories;
using Core.Security.Entities;
using ECommerce.Application.Services.Repositories;
using ECommerce.Persistence.Contexts;

namespace ECommerce.Persistence.Concretes;

public class OperationClaimRepository(BaseDbContext context) : EfRepositoryBase<OperationClaim,int,BaseDbContext>(context),IOperationClaimRepository
{
}
