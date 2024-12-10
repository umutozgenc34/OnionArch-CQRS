using AutoMapper;
using ECommerce.Domain.Entities;
using ECommerce.Persistence.Abstracts;
using MediatR;

namespace ECommerce.Application.Features.Categories.Queries.GetList;

public sealed class GetListCategoryQuery : IRequest<List<GetListCategoryResponseDto>>
{


    public sealed class GetListCategoryQueryHandler : IRequestHandler<GetListCategoryQuery, List<GetListCategoryResponseDto>>
    {

        private readonly IMapper _mapper;
        private readonly ICategoryRepository _categoryRepository;

        public GetListCategoryQueryHandler(IMapper mapper, ICategoryRepository categoryRepository)
        {
            _mapper = mapper;
            _categoryRepository = categoryRepository;
        }

        public async Task<List<GetListCategoryResponseDto>> Handle(GetListCategoryQuery request, CancellationToken cancellationToken)
        {
            List<Category> categories = await _categoryRepository
                 .GetListAsync(include: false, enableTracking: false, cancellationToken: cancellationToken);
            List<GetListCategoryResponseDto> responses = _mapper.Map<List<GetListCategoryResponseDto>>(categories);

            return responses;
        }
    }

}
