
using AutoMapper;
using ECommerce.Application.Services.Repositories;
using MediatR;

namespace ECommerce.Application.Features.Categories.Queries.GetById;

public class GetByIdCategoryQuery : IRequest<GetByIdCategoryResponseDto>
{
    public int Id { get; set; }
    public sealed class GetByIdCategoryQueryHandler : IRequestHandler<GetByIdCategoryQuery, GetByIdCategoryResponseDto>
    {
        private readonly IMapper _mapper;
        private readonly ICategoryRepository _categoryRepository;
        public GetByIdCategoryQueryHandler(IMapper mapper, ICategoryRepository categoryRepository)
        {
            _mapper = mapper;
            _categoryRepository = categoryRepository;
        }
        public async Task<GetByIdCategoryResponseDto> Handle(GetByIdCategoryQuery request, CancellationToken cancellationToken)
        {
            var category = await _categoryRepository
                .GetAsync(predicate: x => x.Id == request.Id,
                enableTracking: false,
                include: false,
                cancellationToken: cancellationToken
                );
            var response = _mapper.Map<GetByIdCategoryResponseDto>(category);
            return response;
        }
    }
}
