using Microsoft.EntityFrameworkCore;
using Northwind.Persistence.Data;

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
    public void Foo_DoesBar_WhenBaz()
    {
        var options = new DbContextOptionsBuilder<MasterContext>()
            .UseInMemoryDatabase(databaseName: "foo_bar_baz")
            .Options;

        using (var context = new MasterContext(options))
        {
        }
    }
}