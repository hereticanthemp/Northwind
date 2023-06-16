using FluentValidation;

namespace Northwind.Application.Category.Commands.UpdateCategory;

public class UpdateCategoryCommandValidator : AbstractValidator<UpdateCategoryCommand>
{
    public UpdateCategoryCommandValidator()
    {
        RuleFor(x => x.CategoryId).Must(i => i > 0);

        RuleFor(x => x.Name).NotEmpty();
    }
}