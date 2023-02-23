using System.Text.Json.Serialization;
using Northwind.Application.Abstractions.Messages;

namespace Northwind.Application.Category.Commands.UpdateCategory;

public sealed record UpdateCategoryCommand([property: JsonIgnore]int CategoryId, string Name, string Description) : ICommand
{
}