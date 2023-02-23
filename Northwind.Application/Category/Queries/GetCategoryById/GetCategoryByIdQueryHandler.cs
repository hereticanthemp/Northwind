using Northwind.Application.Abstractions.Messages;
using Northwind.Domain.Repositories;
using Northwind.Domain.Shared;

namespace Northwind.Application.Category.Queries.GetCategoryById;

public class GetCategoryByIdQueryHandler : IQueryHandler<GetCategoryByIdQuery,CategoryResponse>
{
    private readonly ICategoryRepository _categoryRepository;

    public GetCategoryByIdQueryHandler(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }

    public async Task<Result<CategoryResponse>> Handle(GetCategoryByIdQuery request, CancellationToken cancellationToken)
    {
        var category = await _categoryRepository.GetById(request.CategoryId, cancellationToken);
        if (category is null)
        {
            return Result<CategoryResponse>.Failure(
                new Error("Category.NotFound", $"Category with Id {request.CategoryId} was not found"));
        }

        return new CategoryResponse(category.Id, category.Name, category.Description);
    }
}