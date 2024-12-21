
using AutoMapper;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Login;
using Core.Security.Constants;
using ECommerce.Application.Features.Categories.Rules;
using ECommerce.Application.Services.Repositories;
using ECommerce.Domain.Entities;
using MediatR;

namespace ECommerce.Application.Features.Categories.Commands.Create;

public sealed class CategoryAddCommand : IRequest<CategoryAddedResponseDto>,ISecuredRequest
{
    public string Name { get; set; }
    public string[] Roles => [GeneralOperationClaims.Admin];

    public sealed class CategoryAddCommandHandler(
        IMapper _mapper, ICategoryRepository _categoryRepository,CategoryBusinessRules businessRules
        )
        
        : IRequestHandler<CategoryAddCommand, CategoryAddedResponseDto>
    {


        public async Task<CategoryAddedResponseDto> Handle(CategoryAddCommand request, CancellationToken cancellationToken)
        {
            await businessRules.CategoryNameMustBeUniqueAsync(request.Name, cancellationToken);

            Category category = _mapper.Map<Category>(request);

            Category addedCategory = await _categoryRepository.AddAsync(category);
           
            CategoryAddedResponseDto response = _mapper.Map<CategoryAddedResponseDto>(addedCategory);

            return response;
        }
    }
}
