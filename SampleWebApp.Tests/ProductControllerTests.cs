using Microsoft.AspNetCore.Mvc;
using Moq;
using SampleWebApp.Controllers;
using SampleWebApp.Models;
using SampleWebApp.Repositories;
using System.Text.Json;

[TestFixture]
public class ProductControllerTests
{
    private Mock<IRepository<Product>> _mockRepository;
    private ProductController _controller;

    [SetUp]
    public void SetUp()
    {
        _mockRepository = new Mock<IRepository<Product>>();
        _controller = new ProductController(_mockRepository.Object);
    }

    [Test]
    public void GetAllProducts_ReturnsOkResult_WithProductList()
    {
        // Arrange
        var products = new List<Product>
        {
            new Product { Id = 1, Name = "Product1", Price = 10.0m },
            new Product { Id = 2, Name = "Product2", Price = 20.0m }
        };
        _mockRepository.Setup(repo => repo.GetAll()).Returns(products);

        // Act
        var result = _controller.Index() as OkObjectResult;

        // Assert
        Assert.IsNotNull(result);
        Assert.AreEqual(200, result.StatusCode);

        var jsonResult = result.Value as string;
        var deserializedProducts = JsonSerializer.Deserialize<IEnumerable<Product>>(jsonResult);
        Assert.AreEqual(2, deserializedProducts.Count());
    }

    [Test]
    public void GetAllProducts_InternalServerError_ReturnsStatusCode404()
    {
        // Arrange
        _mockRepository.Setup(repo => repo.GetById(99)).Returns((Product)null);

        // Act
        var result = _controller.GetById(99);

        // Assert
        Assert.IsInstanceOf<NotFoundResult>(result);
    }
}
