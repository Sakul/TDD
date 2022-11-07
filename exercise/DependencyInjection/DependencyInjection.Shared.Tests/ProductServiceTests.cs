using DependencyInjection.Shared.Models;
using DependencyInjection.Shared.Repositories;
using DependencyInjection.Shared.Services;
using FluentAssertions;
using Microsoft.Extensions.Logging;
using Moq;

namespace DependencyInjection.Shared.Tests
{
    public class ProductServiceTests
    {
        private readonly Mock<ILogger> mockLogger;
        private readonly Mock<IOrderRepository> mockOrderRepository;
        private readonly Mock<IProductRepository> mockProductRepository;

        public ProductServiceTests()
        {
            mockLogger = new Mock<ILogger>();
            mockOrderRepository = new Mock<IOrderRepository>();
            mockProductRepository = new Mock<IProductRepository>();
        }

        [Theory]
        [InlineData("iPhone X", 8900, "iPhone X", 8900)]
        public void CreateNewProduct_AllParametersAreValid_ThenCreateSuccess(string productName,
           double productPrice,
           string expectedProductName,
           double expectedProductPrice)
        {
            var sut = new ProductService(mockLogger.Object,
                mockOrderRepository.Object,
                mockProductRepository.Object);

            var result = sut.CreateNewProduct(productName, productPrice);
            result.Name.Should().Be(expectedProductName);
            result.Price.Should().Be(expectedProductPrice);
        }

        [Theory]
        [ClassData(typeof(EmptyProductScenarios))]
        [ClassData(typeof(SingleProductScenarios))]
        public void GetAllProducts(IEnumerable<ProductInfo> products, IEnumerable<ProductInfo> expectedResult)
        {
            mockProductRepository
                .Setup(it => it.GetAll())
                .Returns(products);

            var sut = new ProductService(mockLogger.Object,
                mockOrderRepository.Object,
                mockProductRepository.Object);

            var result = sut.GetAllProducts();
            result.Should().BeEquivalentTo(expectedResult);
        }
        class EmptyProductScenarios : TheoryData<IEnumerable<ProductInfo>, IEnumerable<ProductInfo>>
        {
            public EmptyProductScenarios()
            {
                Add(Enumerable.Empty<ProductInfo>(), Enumerable.Empty<ProductInfo>());
            }
        }
        class SingleProductScenarios : TheoryData<IEnumerable<ProductInfo>, IEnumerable<ProductInfo>>
        {
            public SingleProductScenarios()
            {
                var products = new[]
                {
                    new ProductInfo
                    {
                        Id = Guid.NewGuid().ToString(),
                        Price = 44_900.00,
                        Name = "iPhone 14 Pro Max",
                        CreatedDate = DateTime.Now,
                    }
                };
                Add(products, products);
            }
        }
    }
}