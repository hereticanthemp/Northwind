using Northwind.Application.Abstractions.Messages;

namespace Northwind.Application.Category.Queries.GetCategoryById;

public sealed record GetCategoryByIdQuery (int CategoryId) : IQuery<CategoryResponse>
{
}
