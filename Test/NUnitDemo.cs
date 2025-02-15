using Demo.Pages;
using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;
using NUnit.Framework;

namespace Demo;

public class NUnitDemo : PageTest
{
    //[SetUp]
    public async Task Setup()
    {
         await Page.GotoAsync(url:"http://www.eaapp.somee.com/", new PageGotoOptions{
            WaitUntil = WaitUntilState.DOMContentLoaded
         });
    }

    //[Test]
    public async Task Test1()
    {
        await Page.ClickAsync("text=Login");
        await Page.FillAsync(selector: "#UserName", value:"admin");
        await Page.FillAsync(selector: "#Password", value:"password");
        await Page.ClickAsync(selector: "text=Log in");
        
        await Expect(Page.Locator(selector: "text='Employee Details'")).ToBeVisibleAsync();
    }

    //[Test]
    public async Task TestWithPOM(){
        LoginPage loginPage = new LoginPage(Page);
        await loginPage.ClickLogin();
        await loginPage.Login("admin", "password");
        await Expect(Page.Locator(selector: "text='Employee Details'")).ToBeVisibleAsync();
    }
}
