using Microsoft.Extensions.Configuration;

namespace BlackBoxTesting.Shared.Tests
{
    public class TestingEnvironmentTests
    {
        [Fact]
        public void Read_AppSettings_ShouldBeReadable()
        {
            var configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();

            var message = configuration.GetSection("Message").Value;
            Assert.Equal("Greeting!", message);
        }
    }
}