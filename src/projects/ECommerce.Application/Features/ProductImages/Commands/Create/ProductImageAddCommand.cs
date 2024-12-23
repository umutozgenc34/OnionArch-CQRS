using AutoMapper;
using Core.Application.Pipelines.Caching;
using ECommerce.Application.Services.Infrastructure;
using ECommerce.Application.Services.Repositories;
using ECommerce.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace ECommerce.Application.Features.ProductImages.Commands.Create;

public sealed class ProductImageAddCommand : IRequest<ProductImageAddedResponseDto>, ICacheRemoverRequest
{
    public Guid ProductId { get; set; }
    public IFormFile File { get; set; }
    public string CacheKey => "ProductImages";
    public bool ByPassCache => false;
    public string? CacheGroupKey => "";


    public sealed class ProductImageAddCommandHandler : IRequestHandler<ProductImageAddCommand, ProductImageAddedResponseDto>
    {
        private readonly IMapper _mapper;
        private readonly IProductImageRepository _productImageRepository;
        private readonly ICloudinaryService _cloudinaryService;
        public ProductImageAddCommandHandler(IMapper mapper, IProductImageRepository productImageRepository, ICloudinaryService cloudinaryService)
        {
            _mapper = mapper;
            _productImageRepository = productImageRepository;
            _cloudinaryService = cloudinaryService;
        }
        public async Task<ProductImageAddedResponseDto> Handle(ProductImageAddCommand request, CancellationToken cancellationToken)
        {
            var url = await _cloudinaryService.UploadImage(request.File, "E-commerce-product-images");
            var productImage = _mapper.Map<ProductImage>(request);
            productImage.Url = url;

            var created = await _productImageRepository.AddAsync(productImage);
            var response = _mapper.Map<ProductImageAddedResponseDto>(created);
            return response;
        }
    }
}