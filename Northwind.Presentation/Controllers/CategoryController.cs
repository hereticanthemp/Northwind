using MediatR;
using Microsoft.AspNetCore.Mvc;
using Northwind.Application.Category.Commands.UpdateCategory;
using Northwind.Application.Category.Queries.GetCategoryById;


namespace Northwind.Presentation.Controllers;

[Route("[controller]")]
[ApiController]
public class CategoryController: ControllerBase
{
    private readonly ISender _sender;

    public CategoryController(ISender sender)
    {
        _sender = sender;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Read(int id, CancellationToken ctx)
    {
        var result = await _sender.Send(new GetCategoryByIdQuery(id),ctx);

        return result.IsSuccess ? Ok(result.Value) : NotFound(result.Error);
    }
    
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, UpdateCategoryCommand cmd, CancellationToken ctx)
    {
        var result = await _sender.Send(cmd with { CategoryId = id },ctx);
        
        return result.IsSuccess ? Ok() : NotFound(result.Error);
    }
}