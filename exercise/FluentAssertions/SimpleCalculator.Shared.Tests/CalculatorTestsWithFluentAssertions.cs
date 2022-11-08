using FluentAssertions;

namespace SimpleCalculator.Shared.Tests
{
    public class CalculatorTestsWithFluentAssertions
    {
        [Theory(DisplayName = "นำตัวเลขที่บวกสองตัวไปรวมกัน ผลลัพท์ต้องเป็นบวก")]
        [InlineData(3, 5, 8)]
        [InlineData(2, 8, 10)]
        public void Add_TwoPositiveValues_TheResultMustBePositive(int input1, int input2, int expected)
        {
            var calculator = new Calculator();
            var result = calculator.Add(input1, input2);
            result.Should().BePositive();
        }
    }
}