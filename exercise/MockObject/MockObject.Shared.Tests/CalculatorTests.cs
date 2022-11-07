using MockObject.Shared.Models;
using MockObject.Shared.Services;
using Moq;

namespace MockObject.Shared.Tests
{
    public class CalculatorTests
    {
        [Theory]
        [InlineData(3, 5, 8)]
        [InlineData(2, 8, 10)]
        public void Add_TwoPositiveValues_MustBeWorkingCorrectly(int input1, int input2, int expected)
        {
            // Arrange
            var mockCalculationService = new Mock<ICalculationService>();
            mockCalculationService
                .Setup(it => it.SendRequest(It.IsAny<CalculationRequest>()))
                .Returns<CalculationRequest>(req =>
                {
                    var result = req.Operator switch
                    {
                        "+" => req.Operand1 + req.Operand2,
                        _ => new int?(),
                    };
                    return new CalculationResponse
                    {
                        Request = req,
                        Result = result.HasValue ? result.Value : default,
                        ErrorMessage = result.HasValue ? null : "Not support",
                    };
                });
            var sut = new Calculator
            {
                CalculationService = mockCalculationService.Object,
            };

            // Act
            var result = sut.Add(input1, input2);

            // Assert
            Assert.Equal(expected, result.Result);
            Func<CalculationRequest, bool> validateReq = req
                => req.Operand1 == input1 && req.Operand2 == input2 && req.Operator == "+";
            mockCalculationService
                .Verify(it => it.SendRequest(It.Is<CalculationRequest>(req => validateReq(req))), Times.Once());
        }

        [Fact]
        public void LooseBehaviour()
        {
            var mockCalculationService = new Mock<ICalculationService>(MockBehavior.Loose);
            var request = new CalculationRequest
            {
                Operand1 = 1,
                Operand2 = 2,
                Operator = "+",
            };
            var result = mockCalculationService.Object.SendRequest(request);
            Assert.Null(result);
        }

        [Fact]
        public void StrictBehaviour()
        {
            var mockCalculationService = new Mock<ICalculationService>(MockBehavior.Strict);
            var request = new CalculationRequest
            {
                Operand1 = 1,
                Operand2 = 2,
                Operator = "+",
            };
            Assert.Throws<MockException>(() => mockCalculationService.Object.SendRequest(request));
        }
    }
}