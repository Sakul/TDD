using FluentAssertions;
using Microsoft.Playwright;

namespace Logout.Tests
{
    public class AuthenticationTesting
    {
        [Fact]
        public async Task Login_ThenLogout()
        {
            var playwright = await Playwright.CreateAsync();
            var browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
            {
                Headless = false,
                SlowMo = 500,
            });
            var page = await browser.NewPageAsync();

            await page.GotoAsync("https://localhost:5001");

            var title = await page.TitleAsync();
            title.Should().Be("IdentityServer4");

            // TODO: Login steps
            // TODO: Logout steps

            throw new NotImplementedException();
        }
    }
}