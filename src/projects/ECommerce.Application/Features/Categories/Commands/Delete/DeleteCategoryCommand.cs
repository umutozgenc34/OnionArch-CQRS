using ECommerce.Application.Features.Categories.Rules;
using ECommerce.Application.Services.Repositories;
using MediatR;

namespace ECommerce.Application.Features.Categories.Commands.Delete;

public class DeleteCategoryCommand : IRequest
{
    public int Id { get; set; }
    public sealed class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommand>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly CategoryBusinessRules _categoryBusinessRules;
        public DeleteCategoryCommandHandler(ICategoryRepository categoryRepository, CategoryBusinessRules categoryBusinessRules)
        {
            _categoryRepository = categoryRepository;
            _categoryBusinessRules = categoryBusinessRules;
        }
        public async Task Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
        {
            
            await _categoryBusinessRules.CategoryIsPresentAsync(request.Id, cancellationToken);
            var category = await _categoryRepository.GetAsync(x => x.Id == request.Id, cancellationToken: cancellationToken);
            await _categoryRepository.DeleteAsync(category!, true);
        }
    }
}
