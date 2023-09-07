using Microsoft.EntityFrameworkCore;
using Northwind.Persistence.Data;
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
            var categoryRepository = new CategoryRepository(context);

            var byId = await categoryRepository.GetById(1,new CancellationToken());
        }
    }
}