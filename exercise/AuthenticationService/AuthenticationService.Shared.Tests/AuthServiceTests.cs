using AuthenticationService.Shared.Services;
using FluentAssertions;

namespace AuthenticationService.Shared.Tests
{
    public class AuthServiceTests
    {
        [Fact]
        public async Task Login_ValidUsernameAndPassword_ThenLoginSuccess()
        {
            var sut = new AuthService();
            var result = await sut.Login("admin1", "P@ssw0rd");
            result.Should().NotBeNull();
        }

        [Fact]
        public async Task Logout_ValidUserIdAndToken_ThenLogoutSuccess()
        {
            var sut = new AuthService();
            var userToken = await sut.Login("admin1", "P@ssw0rd");
            var result = await sut.Logout(userToken);
            result.Should().BeTrue();
        }

        // Normal cases
        // Alternative cases
        // Exceptional cases
    }
}