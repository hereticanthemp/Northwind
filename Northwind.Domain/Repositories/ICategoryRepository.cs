using Northwind.Domain.Entities;

namespace Northwind.Domain.Repositories;

public interface ICategoryRepository
{
    public Task<Category?> GetById(int id, CancellationToken ctx);
}