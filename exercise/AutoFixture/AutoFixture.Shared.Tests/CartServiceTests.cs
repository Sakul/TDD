using AutoFixture.AutoMoq;
using AutoFixture.Shared.Models;
using AutoFixture.Shared.Services;
using AutoFixture.Xunit2;
using Moq;

namespace AutoFixture.Shared.Tests
{
    public class CartServiceTests
    {
        [Fact]
        public void AddProduct_WithoutCart()
        {
            // Arrange
            var fixture = new Fixture();
            var expectedProduct1 = fixture.Create<ProductInfo>();
            var expectedProduct2 = fixture.Create<ProductInfo>();
            var sut = fixture.Create<CartService>();

            // Act
            var result = sut.AddProduct(expectedProduct1, expectedProduct2);

            // Assert
            Assert.Contains(result.Products, it => it == expectedProduct1);
            Assert.Contains(result.Products, it => it == expectedProduct2);
            Assert.True(result.SubTotal > 0);
            Assert.True(result.Taxes > 0);
            Assert.True(result.Total > 0);
        }

        [Fact]
        public void AddProduct_WithCart()
        {
            // Arrange
            var fixture = new Fixture();
            var expectedCart = fixture.Create<CartInfo>();
            var expectedProduct1 = fixture.Create<ProductInfo>();
            var expectedProduct2 = fixture.Create<ProductInfo>();
            var sut = fixture.Create<CartService>();

            // Act
            var result = sut.AddProduct(expectedCart, expectedProduct1, expectedProduct2);

            // Assert
            Assert.Equal(expectedCart, result);
            Assert.Contains(result.Products, it => it == expectedProduct1);
            Assert.Contains(result.Products, it => it == expectedProduct2);
            Assert.True(result.SubTotal > 0);
            Assert.True(result.Taxes > 0);
            Assert.True(result.Total > 0);
        }

        [Fact]
        public void AddProduct_WithTheSameProduct()
        {
            // Arrange
            var fixture = new Fixture();
            var expectedProduct1 = fixture.Freeze<ProductInfo>();
            var expectedProduct2 = fixture.Create<ProductInfo>();
            var sut = fixture.Create<CartService>();

            // Act
            var result = sut.AddProduct(expectedProduct1, expectedProduct2);

            // Assert
            Assert.Contains(result.Products, it => it == expectedProduct1);
            Assert.Contains(result.Products, it => it == expectedProduct2);
            Assert.Same(expectedProduct1, expectedProduct2);
            Assert.True(null != result.Products.Single(it => it == expectedProduct1));
            Assert.True(result.SubTotal > 0);
            Assert.True(result.Taxes > 0);
            Assert.True(result.Total > 0);
        }

        [Theory]
        [InlineAutoData]
        [InlineAutoData("P001")]
        [InlineAutoData("P002", "iPhone X")]
        public void AddProduct_WithInlineAutoData(string productId, string productName, double productPrice)
        {
            // Arrange
            var fixture = new Fixture();
            var sut = fixture.Create<CartService>();
            var expectedProduct = new ProductInfo
            {
                Id = productId,
                Name = productName,
                Price = productPrice,
            };

            // Act
            var result = sut.AddProduct(expectedProduct);

            // Assert
            Assert.Contains(result.Products,
                it => it.Id == productId && it.Name == productName && it.Price == productPrice);
            Assert.True(result.SubTotal > 0);
            Assert.True(result.Taxes > 0);
            Assert.True(result.Total > 0);
        }

        [Theory, AutoData]
        public void AddProduct_WithAutoData(ProductInfo expectedProduct, CartService sut)
        {
            // Act
            var result = sut.AddProduct(expectedProduct);

            // Assert
            Assert.Contains(result.Products, it => it == expectedProduct);
            Assert.True(result.SubTotal > 0);
            Assert.True(result.Taxes > 0);
            Assert.True(result.Total > 0);
        }

        [Fact]
        public void AddProduct_WithAutoMoq()
        {
            // Arrange
            var fixture = new Fixture()
                .Customize(new AutoMoqCustomization()); // AutoMoq
            var expectedProduct = fixture.Create<ProductInfo>();
            var mockLogger = fixture.Freeze<Mock<ILogger>>();
            var sut = fixture.Create<CartService>();

            // Act
            var result = sut.AddProduct(expectedProduct);

            // Assert
            mockLogger.Verify(it => it.WriteLog(It.IsAny<string>()), Times.Once);
        }

        [Theory]
        [AutoInjection]
        public void AddProduct_WithAutoInjection([Frozen] Mock<ILogger> mockLogger, ProductInfo expectedProduct, CartService sut)
        {
            // Act
            var result = sut.AddProduct(expectedProduct);

            // Assert
            mockLogger.Verify(it => it.WriteLog(It.IsAny<string>()), Times.Once);
        }
    }

    public class AutoInjectionAttribute : AutoDataAttribute
    {
        public AutoInjectionAttribute()
          : base(() => new Fixture().Customize(new AutoMoqCustomization()))
        {
        }
    }
}