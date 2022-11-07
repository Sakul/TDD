namespace FizzBuzz.App.Tests
{
    public class FizzBuzzConverterTests
    {
        [Fact]
        public void Convert_TextValue1_TheResultShouldbe_1()
        {
            // Arrange
            var sut = new FizzBuzzConverter();

            // Act
            var result = sut.Convert("1");

            // Assert
            Assert.Equal("1", result);
        }

        [Fact]
        public void Convert_TextValue2_TheResultShouldbe_2()
        {
            // Arrange
            var sut = new FizzBuzzConverter();

            // Act
            var result = sut.Convert("2");

            // Assert
            Assert.Equal("2", result);
        }

        [Fact]
        public void Convert_TextValue3_TheResultShouldbe_Fizz()
        {
            // Arrange
            var sut = new FizzBuzzConverter();

            // Act
            var result = sut.Convert("3");

            // Assert
            Assert.Equal("Fizz", result);
        }

        [Fact]
        public void Convert_TextValue4_TheResultShouldbe_4()
        {
            // Arrange
            var sut = new FizzBuzzConverter();

            // Act
            var result = sut.Convert("4");

            // Assert
            Assert.Equal("4", result);
        }

        [Fact]
        public void Convert_TextValue5_TheResultShouldbe_Buzz()
        {
            // Arrange
            var sut = new FizzBuzzConverter();

            // Act
            var result = sut.Convert("5");

            // Assert
            Assert.Equal("Buzz", result);
        }
    }
}