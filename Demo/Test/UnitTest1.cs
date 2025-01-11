
/*using Microsoft.Playwright;

namespace Demo;

public class Tests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public async Task Test0()
    {
        //Playwright
        using var playw = await Playwright.CreateAsync();
        //Browser
        await using var browser = await playw.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
        {
            Headless = false
        });
        //Page
        var page = await browser.NewPageAsync();
        await page.GotoAsync("http://www.eaapp.somee.com");
        await page.ClickAsync("text=Login");
        await page.ScreenshotAsync(new PageScreenshotOptions
        {
            Path = "EAApp.jpg"
        });

        await page.FillAsync(selector: "#UserName", value:"admin");
        await page.FillAsync(selector: "#Password", value:"password");
        await page.ClickAsync("text=Log in");
        var isExist = await page.Locator(selector: "text='Employee Details'").IsVisibleAsync();
        Assert.IsTrue(isExist);

    }

    [Test]
    public async Task WaitTest()
    { 
        using var playw = await Playwright.CreateAsync();
        await using var browser = await playw.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
        {
            Headless = false
        });
        var context = await browser.NewContextAsync();
        var page = await context.NewPageAsync();
        await page.GotoAsync(url:"https://demos.telerik.com/kendo-ui/window/angular");
    }
}
*/