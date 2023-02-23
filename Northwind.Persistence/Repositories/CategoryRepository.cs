using Microsoft.EntityFrameworkCore;
using Northwind.Domain.Entities;
using Northwind.Domain.Repositories;
using Northwind.Persistence.Data;

namespace Northwind.Persistence.Repositories;

public class CategoryRepository : ICategoryRepository
{
    private readonly MasterContext _dbContext;

    public CategoryRepository(MasterContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public async Task<Category?> GetById(int id, CancellationToken ctx)
    {
        var category = await _dbContext.Set<Models.Category>()
            .FirstOrDefaultAsync(c => c.CategoryId == id, ctx);
        if (category != null)
            return new Category()
            {
                Id = category.CategoryId,
                Name = category.CategoryName,
                Description = category.Description,
            };
        return null;
    }

    public async Task Update(int id, string name, string description, CancellationToken ctx)
    {
        var category = await _dbContext.Set<Models.Category>()
            .FirstOrDefaultAsync(c => c.CategoryId == id, ctx);
        if (category != null)
        {
            if (name != string.Empty) category.CategoryName = name;
            if (description != string.Empty) category.Description = description;
            await _dbContext.SaveChangesAsync(ctx);
        }
    }
}