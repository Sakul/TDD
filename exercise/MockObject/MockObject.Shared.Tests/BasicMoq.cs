using Moq;

namespace MockObject.Shared.Tests
{
    public interface IDemoService
    {
        int DoSomething(string input);
    }

    public class BasicMoq
    {
        [Fact]
        public void DefaultBehaviour()
        {
            var moqDemoService = new Mock<IDemoService>();
            IDemoService obj = moqDemoService.Object;
            var result = obj.DoSomething("A");
            Assert.Equal(default, result);
        }

        [Fact]
        public void StaticAgument()
        {
            var moqDemoService = new Mock<IDemoService>();
            moqDemoService
                .Setup(it => it.DoSomething("A"))
                .Returns<string>(input => 5);

            IDemoService obj = moqDemoService.Object;
            var result = obj.DoSomething("A");
            Assert.Equal(5, result);
        }

        [Fact]
        public void DynamicAgument()
        {
            var moqDemoService = new Mock<IDemoService>();
            moqDemoService
                .Setup(it => it.DoSomething(It.IsAny<string>()))
                .Returns<string>(input => 99);

            IDemoService obj = moqDemoService.Object;
            var result = obj.DoSomething(Guid.NewGuid().ToString());
            Assert.Equal(99, result);
        }

        [Fact]
        public void VerifyBehaviour()
        {
            var moqDemoService = new Mock<IDemoService>();
            moqDemoService
                .Setup(it => it.DoSomething(It.IsAny<string>()))
                .Returns<string>(input => 99);

            IDemoService obj = moqDemoService.Object;
            var result = obj.DoSomething("MyInput");
            Assert.Equal(99, result);

            moqDemoService
                .Verify(it => 
                    it.DoSomething(It.Is<string>(actual => actual == "MyInput")));
        }

        [Fact]
        public void ThowAnException()
        {
            var moqDemoService = new Mock<IDemoService>();
            moqDemoService
                .Setup(it => it.DoSomething(It.IsAny<string>()))
                .Returns<string>(input => throw new NotSupportedException());

            IDemoService obj = moqDemoService.Object;
            Assert.Throws<NotSupportedException>(() => obj.DoSomething(Guid.NewGuid().ToString()));
        }

        [Fact]
        public void StrictBehaviour()
        {
            var moqDemoService = new Mock<IDemoService>(MockBehavior.Strict);
            IDemoService obj = moqDemoService.Object;
            Assert.Throws<MockException>(() => obj.DoSomething(Guid.NewGuid().ToString()));
        }
    }
}
