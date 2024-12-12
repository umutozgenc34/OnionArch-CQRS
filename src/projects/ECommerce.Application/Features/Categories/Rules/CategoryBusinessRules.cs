

using Core.CrossCuttingConcerns.Exceptions.ExceptionTypes;
using ECommerce.Application.Features.Categories.Constants;
using ECommerce.Persistence.Abstracts;
using ECommerce.Persistence.Concretes;

namespace ECommerce.Application.Features.Categories.Rules;

public class CategoryBusinessRules(ICategoryRepository categoryRepository)
{
    public async Task CategoryIsPresentAsync(int id, CancellationToken cancellationToken)
    {
        bool isPresent = await categoryRepository.AnyAsync(
            predicate: x => x.Id == id,
            cancellationToken: cancellationToken
            );
        if (!isPresent)
            throw new BusinessException(CategoryMessages.CategoryNotFoundMessage);
    }
    public async Task CategoryNameMustBeUniqueAsync(string name, CancellationToken cancellationToken)
    {
        bool isPresent = await categoryRepository.AnyAsync(
      predicate: x => x.Name == name,
      cancellationToken: cancellationToken
      );
        if (isPresent)
            throw new BusinessException(CategoryMessages.CategoryNameMustBeUniqueMessage);
    }
}
