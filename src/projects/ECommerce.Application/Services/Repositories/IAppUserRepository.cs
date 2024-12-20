

using Core.Persistence.Repositories;
using ECommerce.Domain.Entities;

namespace ECommerce.Application.Services.Repositories;

public interface IAppUserRepository : IAsyncRepository<AppUser,int>
{
}
