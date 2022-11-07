using FluentAssertions;
using Microsoft.Playwright;

namespace PlaywrightDemo
{
    public class AuthenticationTests
    {
        [Theory]
        [InlineData("bob", "bob")]
        [InlineData("Bob", "bob")]
        [InlineData("alice", "alice")]
        public async Task Login_WithValidUsernameAndPassword_ThenGetAnIdentityToken(string username, string password)
        {
            var page = await getPage();

            await page.GotoAsync("https://localhost:5001");

            // Expect a title "to contain" a substring.
            var title = await page.TitleAsync();
            title.Should().Be("IdentityServer4");

            // Create a locator
            var locator = page.Locator("li:has-text(\"Click here to see the claims for your current session.\")")
                .GetByRole(AriaRole.Link, new() { NameString = "here" });
            await locator.ClickAsync();
            await page.WaitForURLAsync("https://localhost:5001/Account/Login?ReturnUrl=%2Fdiagnostics");

            // Fill form & submit
            await page.GetByPlaceholder("Username").FillAsync(username);
            await page.GetByPlaceholder("Password").FillAsync(password);
            await page.GetByRole(AriaRole.Button, new() { NameString = "Login" }).ClickAsync();
            await page.WaitForURLAsync("https://localhost:5001/diagnostics");

            // Take screenshot
            var bytes = await page.ScreenshotAsync(new PageScreenshotOptions
            {
                Path = $"{nameof(Login_WithValidUsernameAndPassword_ThenGetAnIdentityToken)}_{username}.png"
            });
        }

        [Theory]
        [InlineData("bob", "BOB")]
        [InlineData("unknow", "unknow")]
        public async Task Login_WithInvalidUsernameOrPassword_ThenAccessDeny(string username, string password)
        {
            var page = await getPage();

            await page.GotoAsync("https://localhost:5001");

            // Expect a title "to contain" a substring.
            var title = await page.TitleAsync();
            title.Should().Be("IdentityServer4");

            // Create a locator
            var locator = page.Locator("li:has-text(\"Click here to see the claims for your current session.\")")
                .GetByRole(AriaRole.Link, new() { NameString = "here" });
            await locator.ClickAsync();
            await page.WaitForURLAsync("https://localhost:5001/Account/Login?ReturnUrl=%2Fdiagnostics");

            // Fill form & submit
            await page.GetByPlaceholder("Username").FillAsync(username);
            await page.GetByPlaceholder("Password").FillAsync(password);
            await page.GetByRole(AriaRole.Button, new() { NameString = "Login" }).ClickAsync();
            await page.WaitForURLAsync("https://localhost:5001/Account/Login?ReturnUrl=%2Fdiagnostics");
            var errorLocator = await page.WaitForSelectorAsync("body > div.container.body-container > div > div.alert.alert-danger");
            var errorText = await errorLocator.TextContentAsync();
            errorText.Should().Contain("Invalid username or password");
        }

        async Task<IPage> getPage()
        {
            var playwright = await Playwright.CreateAsync();
            var browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
            {
                //Headless = false,
                //SlowMo = 500,
            });
            var ctx = await browser.NewContextAsync(new BrowserNewContextOptions
            {
                //RecordVideoDir = "videos/",
                //RecordVideoSize = new RecordVideoSize() { Width = 640, Height = 480 },
            });
            return await ctx.NewPageAsync();
        }
    }
}