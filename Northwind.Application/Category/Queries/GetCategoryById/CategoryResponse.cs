namespace Northwind.Application.Category.Queries.GetCategoryById;

public sealed record CategoryResponse(int Id, string Name, string Description)
{
}