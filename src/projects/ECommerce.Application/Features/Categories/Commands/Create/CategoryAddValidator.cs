

using ECommerce.Application.Features.Categories.Constants;
using FluentValidation;

namespace ECommerce.Application.Features.Categories.Commands.Create;

public class CategoryAddValidator : AbstractValidator<CategoryAddCommand>
{
    public CategoryAddValidator()
    {
        RuleFor(x => x.Name).MinimumLength(3).WithMessage(CategoryMessages.CategoryNameMustBeMinimumThreeLength);
    }
}
