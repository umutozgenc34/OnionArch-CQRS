using AutoMapper;
using Core.Application.Requests;
using Core.Persistence.Extensions;
using ECommerce.Application.Services.Repositories;
using MediatR;

namespace ECommerce.Application.Features.Categories.Queries.GetListByPaginate;

public sealed class GetListByPaginateCategoryQuery  : IRequest<Paginate<GetListByPaginateCategoryResponseDto>>
{
    public PageRequest PageRequest { get; set; }


    public sealed class GetListByPaginateCategoryQueryHandler : IRequestHandler<GetListByPaginateCategoryQuery, Paginate<GetListByPaginateCategoryResponseDto>>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public GetListByPaginateCategoryQueryHandler(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<Paginate<GetListByPaginateCategoryResponseDto>> Handle(GetListByPaginateCategoryQuery request, CancellationToken cancellationToken)
        {
            var categories = await _categoryRepository.GetPaginateAsync(
                include: false,
                enableTracking: false,
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize,
                cancellationToken: cancellationToken
                );
            var response = _mapper.Map<Paginate<GetListByPaginateCategoryResponseDto>>(categories);

            return response;
        }
    }

}
