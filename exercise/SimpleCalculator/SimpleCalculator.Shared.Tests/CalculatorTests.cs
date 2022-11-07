namespace SimpleCalculator.Shared.Tests
{
    public class CalculatorTests
    {
        [Fact]
        public void Add_3And5_TheResultShouldBe_8()
        {
            var sut = new Calculator();
            var result = sut.Add(3, 5);
            Assert.Equal(8, result);
        }

        [Fact]
        public void Add_2And8_TheResultShouldBe_10()
        {
            var sut = new Calculator();
            var result = sut.Add(2, 8);
            Assert.Equal(10, result);
        }

        #region InlineData

        [Theory]
        [InlineData(3, 5, 8)]
        [InlineData(2, 8, 10)]
        public void Add_TwoPositiveValues_MustBeWorkingCorrectly_InlineData(int input1, int input2, int expected)
        {
            var sut = new Calculator();
            var result = sut.Add(input1, input2);
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(-7, -5, -12)]
        [InlineData(-9, -20, -29)]
        public void Add_TwoNegativeValues_MustBeWorkingCorrectly_InlineData(int input1, int input2, int expected)
        {
            var sut = new Calculator();
            var result = sut.Add(input1, input2);
            Assert.Equal(expected, result);
        }

        #endregion

        #region MemberData

        [Theory]
        [MemberData(nameof(AddPositiveValues))]
        [MemberData(nameof(AddNegativeValues))]
        public void Add_TwoValues_MustBeWorkingCorrectly_MemberData(int input1, int input2, int expected)
        {
            var sut = new Calculator();
            var result = sut.Add(input1, input2);
            Assert.Equal(expected, result);
        }

        public static IEnumerable<object[]> AddPositiveValues => new List<object[]>
        {
            new object[] { 3, 5, 8 },
            new object[] { 2, 8, 10 },
        };

        public static IEnumerable<object[]> AddNegativeValues => new List<object[]>
        {
            new object[] { -7, -5, -12 },
            new object[] { -9, -20, -29 },
        };

        #endregion

        #region ClassData

        [Theory]
        [ClassData(typeof(AddPositiveValueCases))]
        [ClassData(typeof(AddNegativeValueCases))]
        public void Add_TwoValues_MustBeWorkingCorrectly_ClassData(int input1, int input2, int expected)
        {
            var sut = new Calculator();
            var result = sut.Add(input1, input2);
            Assert.Equal(expected, result);
        }

        public class AddPositiveValueCases : TheoryData<int, int, int>
        {
            public AddPositiveValueCases()
            {
                Add(3, 5, 8);
                Add(2, 8, 10);
            }
        }

        public class AddNegativeValueCases : TheoryData<int, int, int>
        {
            public AddNegativeValueCases()
            {
                Add_1Digit_Negative();
                Add_2Digits_Negative();
            }

            void Add_1Digit_Negative()
            {
                Add(-7, -5, -12);
                Add(-8, -2, -10);
            }

            void Add_2Digits_Negative()
            {
                Add(-13, -27, -40);
                Add(-50, -19, -69);
            }
        }

        #endregion
    }
}