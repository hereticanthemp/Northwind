using Northwind.Application.Abstractions.Messages;
using Northwind.Domain.Repositories;
using Northwind.Domain.Shared;

namespace Northwind.Application.Category.Commands.UpdateCategory;

public class UpdateCategoryCommandHandler : ICommandHandler<UpdateCategoryCommand>
{
    private readonly ICategoryRepository _categoryRepository;

    public UpdateCategoryCommandHandler(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }

    public async Task<Result> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
    {
        await _categoryRepository.Update(request.CategoryId, request.Name, request.Description, cancellationToken);
        return Result.Success;
    }
}