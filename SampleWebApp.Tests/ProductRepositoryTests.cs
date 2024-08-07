using SampleWebApp.Repositories;
using SampleWebApp.Models;

namespace SampleWebApp.Tests
{
    [TestFixture]
    public class Tests
    {
        private ProductRepository _repository;

        [SetUp]
        public void Setup()
        {
            _repository = new ProductRepository();

            // Add some initial data for testing
            _repository.Add(new Product { Id = 1, Name = "Product1", Price = 10.0m });
            _repository.Add(new Product { Id = 2, Name = "Product2", Price = 20.0m });
        }

        [Test]
        public void GetAll_ShouldReturnAllProducts()
        {
            // Act
            var products = _repository.GetAll();

            // Assert
            Assert.AreEqual(2, products.Count());
        }

        [Test]
        public void GetById_ShouldReturnSpecificProduct()
        {
            var product = _repository.GetById(1);
            Assert.AreEqual(1, product.Id);
        }

        [Test]
        public void GetById_NonExistingId_ReturnsNull()
        {
            var product = _repository.GetById(99);
            Assert.IsNull(product);
        }

        [Test]
        public void Add_ProductIsAdded()
        {
            // Arrange
            var newProduct = new Product { Id = 3, Name = "Samsung galaxy", Price = 30.0m };

            // Act
            _repository.Add(newProduct);
            var products = _repository.GetAll();

            // Assert
            Assert.AreEqual(3, products.Count());
            Assert.IsNotNull(_repository.GetById(3));
        }

    }
}