using FluentAssertions;
using NetArchTest.Rules;

namespace Northwind.ArchitectureTest;

public class ArchitectureTests
{
    private readonly string DomainNamespace = "Northwind.Domain";
    private readonly string ApplicationNamespace = "Northwind.Application";
    private readonly string PersistenceNamespace = "Northwind.Persistence";
    private readonly string PresentationNamespace = "Northwind.Presentation";
    private readonly string WebApiNamespace = "Northwind.WebApi";
    
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
     public void Domain_Should_Not_HaveDependencyOnOtherProjects()
     {
         // Arrange
         var assembly = typeof(Domain.AssemblyReference).Assembly;
 
         var otherProjects = new[]
         {
             ApplicationNamespace,
             PersistenceNamespace,
             PresentationNamespace,
             WebApiNamespace
         };
         
         // Act
         var testResult = Types
             .InAssembly(assembly)
             .ShouldNot()
             .HaveDependencyOnAll(otherProjects)
             .GetResult();
         
         // Assert
         testResult.IsSuccessful.Should().BeTrue();
     }   
     
    [Test]
    public void Application_Should_OnlyHaveDependencyOn_Domain()
    {
        // Arrange
        var assembly = typeof(Application.AssemblyReference).Assembly;

        var otherProjects = new[]
        {
            //DomainNamespace,
            PersistenceNamespace,
            PresentationNamespace,
            WebApiNamespace
        };
        
        // Act
        var testResult = Types
            .InAssembly(assembly)
            .ShouldNot()
            .HaveDependencyOnAny(otherProjects)
            .GetResult();
        
        // Assert
        testResult.IsSuccessful.Should().BeTrue();
    }
}