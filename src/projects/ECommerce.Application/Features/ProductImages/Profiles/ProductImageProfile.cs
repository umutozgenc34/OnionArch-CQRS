using AutoMapper;
using ECommerce.Application.Features.ProductImages.Commands.Create;
using ECommerce.Application.Features.ProductImages.Queries;
using ECommerce.Domain.Entities;

namespace ECommerce.Application.Features.ProductImages.Profiles;

public class ProductImageProfile : Profile
{
    public ProductImageProfile()
    {
        CreateMap<ProductImageAddCommand, ProductImage>();
        CreateMap<ProductImage, ProductImageAddedResponseDto>();
        CreateMap<ProductImage, GetListProductImageResponse>();
    }
}