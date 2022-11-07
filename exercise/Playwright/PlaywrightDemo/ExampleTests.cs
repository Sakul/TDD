using FluentAssertions;
using Microsoft.Playwright;

namespace PlaywrightDemo
{
    public class ExampleTests
    {
        [Fact]
        public async Task Test_PlaywrightPlugInCanWorkProperly()
        {
            var playwright = await Playwright.CreateAsync();
            var browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
            {
                //Headless = false,
                //SlowMo = 500,
            });
            var page = await browser.NewPageAsync();

            await page.GotoAsync("https://playwright.dev");

            // Expect a title "to contain" a substring.
            var title = await page.TitleAsync();
            title.Should().MatchRegex("Playwright");
            //await Expect(Page).ToHaveTitleAsync(new Regex("Playwright"));

            // create a locator
            var getStarted = page.Locator("text=Get Started");

            // Expect an attribute "to be strictly equal" to the value.
            var link = await getStarted.GetAttributeAsync("href");
            link.Should().Be("/docs/intro");

            // Click the get started link.
            await getStarted.ClickAsync();

            // Expects the URL to contain intro.
            page.Url.Should().MatchRegex(".*intro");
        }
    }
}