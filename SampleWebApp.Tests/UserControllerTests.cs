using Microsoft.AspNetCore.Mvc;
using Moq;
using SampleWebApp.Controllers;
using SampleWebApp.Models;
using SampleWebApp.Repositories;
using System.Text.Json;

[TestFixture]
public class UserControllerTests
{
    private Mock<IRepository<User>> _mockRepository;
    private UserController _controller;

    [SetUp]
    public void SetUp()
    {
        _mockRepository = new Mock<IRepository<User>>();
        _controller = new UserController();
    }

    /// <summary>
    /// The testcase will fail because the UserController is directly instantiating the UserRepository instead of using dependency injection. 
    /// As a result, the mock repository we set up in the UserControllerTests is not being used.
    /// </summary>
    [Test]
    public void GetAllUser_ReturnsOkResult_WithUserList()
    {
        // Arrange
        var users = new List<User>
        {
            new User { Id=101, Name="Arjunan", Email="arjunan@gmail.com"}
        };
        _mockRepository.Setup(repo => repo.GetAll()).Returns(users);

        // Act
        var result = _controller.Index() as OkObjectResult;

        // Assert
        Assert.IsNotNull(result);
        Assert.AreEqual(200, result.StatusCode);

        var jsonResult = result.Value as string;
        var deserializedUsers = JsonSerializer.Deserialize<IEnumerable<User>>(jsonResult);
        Assert.AreEqual(1, deserializedUsers.Count());
    }
}
