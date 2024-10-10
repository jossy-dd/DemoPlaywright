using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;
using NUnit.Framework;

namespace Demo;

public class NUnitDemo : PageTest
{
    [SetUp]
    public async Task Setup()
    {
         await Page.GotoAsync(url:"http://www.eaapp.somee.com/");
         /*await Page.GotoAsync(url:"http://www.eaapp.somee.com/", new PageGotoOptions{
            WaitUntil = WaitUntilState.DOMContentLoaded
         });*/
    }

    [Test]
    public async Task Test1()
    {
        //Page.SetDefaultTimeout(10); <--- dar tiempo de espera default
        //Using locators
        //var lknLogin = Page.Locator(selector: "text=Login");
        //await lknLogin.ClickAsync();
        await Page.ClickAsync("text=Login");
        await Page.FillAsync(selector: "#UserName", value:"admin");
        await Page.FillAsync(selector: "#Password", value:"password");

        var btnLogin = Page.Locator(selector: "input", new PageLocatorOptions{ HasTextString = "Log in"});
        await btnLogin.ClickAsync();

        //await Page.ClickAsync("text=Log in");
        await Expect(Page.Locator(selector: "text='Employee Details'")).ToBeVisibleAsync();

        /*
        await Expect(Page.Locator(selector: "text='Employee Details'")).ToBeVisibleAsync(new LocatorAssertionsToBeVisibleOptions
        {
            Timeout = 10
        });
        */

        /*
        var isExist = await Page.Locator(selector: "text='Employee Details'").IsVisibleAsync();
        Assert.IsTrue(isExist);
        */
    }
}


/*
[Test]
    public async Task Test1()
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
*/