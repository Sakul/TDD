namespace GradeCalculator.Shared.Tests
{
    public class GradeCalculatorTests
    {
        #region Normal cases

        [Fact]
        public void ConvertScoreToGrade_InputScore_10_ThenTheGradeShouldBe_F()
        {
            var sut = new GradeCalculator();
            var result = sut.ConvertScoreToGrade(10);
            Assert.Equal("F", result);
        }
        [Fact]
        public void ConvertScoreToGrade_InputScore_30_ThenTheGradeShouldBe_F()
        {
            var sut = new GradeCalculator();
            var result = sut.ConvertScoreToGrade(30);
            Assert.Equal("F", result);
        }
        [Fact]
        public void ConvertScoreToGrade_InputScore_50_ThenTheGradeShouldBe_F()
        {
            var sut = new GradeCalculator();
            var result = sut.ConvertScoreToGrade(50);
            Assert.Equal("F", result);
        }

        [Fact]
        public void ConvertScoreToGrade_InputScore_51_ThenTheGradeShouldBe_D()
        {
            var sut = new GradeCalculator();
            var result = sut.ConvertScoreToGrade(51);
            Assert.Equal("D", result);
        }
        [Fact]
        public void ConvertScoreToGrade_InputScore_60_ThenTheGradeShouldBe_D()
        {
            var sut = new GradeCalculator();
            var result = sut.ConvertScoreToGrade(60);
            Assert.Equal("D", result);
        }

        [Fact]
        public void ConvertScoreToGrade_InputScore_61_ThenTheGradeShouldBe_C()
        {
            var sut = new GradeCalculator();
            var result = sut.ConvertScoreToGrade(61);
            Assert.Equal("C", result);
        }
        [Fact]
        public void ConvertScoreToGrade_InputScore_70_ThenTheGradeShouldBe_C()
        {
            var sut = new GradeCalculator();
            var result = sut.ConvertScoreToGrade(70);
            Assert.Equal("C", result);
        }

        [Fact]
        public void ConvertScoreToGrade_InputScore_71_ThenTheGradeShouldBe_B()
        {
            var sut = new GradeCalculator();
            var result = sut.ConvertScoreToGrade(71);
            Assert.Equal("B", result);
        }
        [Fact]
        public void ConvertScoreToGrade_InputScore_85_ThenTheGradeShouldBe_B()
        {
            var sut = new GradeCalculator();
            var result = sut.ConvertScoreToGrade(85);
            Assert.Equal("B", result);
        }

        [Fact]
        public void ConvertScoreToGrade_InputScore_86_ThenTheGradeShouldBe_A()
        {
            var sut = new GradeCalculator();
            var result = sut.ConvertScoreToGrade(86);
            Assert.Equal("A", result);
        }

        #endregion


        #region Alternative cases

        [Fact]
        public void ConvertScoreToGrade_InputScore_0_ThenTheGradeShouldBe_F()
        {
            var sut = new GradeCalculator();
            var result = sut.ConvertScoreToGrade(0);
            Assert.Equal("F", result);
        }

        [Fact]
        public void ConvertScoreToGrade_InputScore_100_ThenTheGradeShouldBe_A()
        {
            var sut = new GradeCalculator();
            var result = sut.ConvertScoreToGrade(100);
            Assert.Equal("A", result);
        }

        #endregion

        #region Exceptional cases

        [Fact]
        public void ConvertScoreToGrade_InputNagativeScore_ThenTheGradeShouldBe_Null()
        {
            var sut = new GradeCalculator();
            var result = sut.ConvertScoreToGrade(-1);
            Assert.Null(result);
        }

        [Fact]
        public void ConvertScoreToGrade_InputScoreThatMoreThanHundred_ThenTheGradeShouldBe_Null()
        {
            var sut = new GradeCalculator();
            var result = sut.ConvertScoreToGrade(9999);
            Assert.Null(result);
        }

        #endregion

        // TODO: Prints
        // TODO: Change grading criteria
        // TODO: Read configuration from a json file
    }
}