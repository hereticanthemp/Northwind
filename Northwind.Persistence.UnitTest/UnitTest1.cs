using Microsoft.EntityFrameworkCore;
using Northwind.Persistence.Data;
using Northwind.Persistence.Models;
using Northwind.Persistence.Repositories;

namespace Northwind.Persistence.UnitTest;

public class Tests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void Test1()
    {
        Assert.Pass();
    }
    
    [Test]
    public async Task Foo_DoesBar_WhenBaz()
    {
        var options = new DbContextOptionsBuilder<MasterContext>()
            .UseInMemoryDatabase(databaseName: "foo_bar_baz")
            .Options;

        using (var context = new MasterContext(options))
        {


           await context.Categories.AddAsync(new Category
            {
                CategoryId = 1,
                CategoryName = "Test",
                Description = "ttt",
            });

            await context.Products.AddAsync(new Product
            {
                ProductId = 1,
                ProductName = "Pro",
                SupplierId = 0,
                CategoryId = 1,
                UnitPrice = 1,
            });
            
            await context.SaveChangesAsync();
            
            
            var q = 
                from c in context.Categories
                where c.CategoryId > 0
                select new
                {
                    c.CategoryName,
                    c.Description
                };


            var jo =
                from p in context.Products
                join c in context.Categories on p.CategoryId equals c.CategoryId
                where c.CategoryName == "Test"
                select new
                {
                    c.CategoryName,
                    p.ProductName
                };
            var jo1 = jo.ToList();

            var jo2 = context.Products.Join(
                context.Categories,
                p => p.CategoryId,
                c => c.CategoryId,
                (p, c) => new
                {
                    c.CategoryName,
                    p.ProductName
                }
            ).ToList();
            
            
            var categoryRepository = new CategoryRepository(context);

            var byId = await categoryRepository.GetById(1,new CancellationToken());
            Assert.That(byId?.Name, Is.EqualTo("Test"));    
        }
    }
}