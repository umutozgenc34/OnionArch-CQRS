using AutoMapper;
using Core.Persistence.Extensions;
using ECommerce.Application.Features.Categories.Commands.Create;
using ECommerce.Application.Features.Categories.Queries.GetList;
using ECommerce.Application.Features.Categories.Queries.GetListByPaginate;
using ECommerce.Domain.Entities;

namespace ECommerce.Application.Features.Categories.Profiles;

public class CategoriesMapper : Profile
{

    public CategoriesMapper()
    {
        CreateMap<CategoryAddCommand, Category>();
        CreateMap<Category, CategoryAddedResponseDto>();

        CreateMap<Category,GetListCategoryResponseDto>();

        CreateMap<Category, GetListByPaginateCategoryResponseDto>();
        CreateMap<Paginate<Category>, Paginate<GetListByPaginateCategoryResponseDto>>();
    }
}
