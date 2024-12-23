﻿using AutoMapper;
using Core.Application.Pipelines.Caching;
using ECommerce.Application.Services.Repositories;
using MediatR;

namespace ECommerce.Application.Features.ProductImages.Queries;

public sealed class GetListProductImageQuery : IRequest<List<GetListProductImageResponse>>, ICachableRequest
{
    public string CacheKey => "ProductImages";
    public bool ByPassCache => false;
    public string? CacheGroupKey => "GetListProductImages";
    public TimeSpan? SlidingExpiration { get; }



    public sealed class GetListProductImageQueryHandler : IRequestHandler<GetListProductImageQuery, List<GetListProductImageResponse>>
    {
        private readonly IMapper _mapper;
        private readonly IProductImageRepository _productImageRepository;
        public GetListProductImageQueryHandler(IMapper mapper, IProductImageRepository productImageRepository)
        {
            _mapper = mapper;
            _productImageRepository = productImageRepository;
        }
        public async Task<List<GetListProductImageResponse>> Handle(GetListProductImageQuery request, CancellationToken cancellationToken)
        {
            var images = await _productImageRepository
                .GetListAsync(cancellationToken: cancellationToken, enableTracking: false);

            var response = _mapper.Map<List<GetListProductImageResponse>>(images);

            return response;
        }
    }

}