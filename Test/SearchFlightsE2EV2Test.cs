using System;
using Demo.Pages;
using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;

namespace Demo.Test;

public class SearchFlightsE2EV2Test: PageTest
{
    [SetUp]
    public async Task Setup(){
            await Page.GotoAsync("https://www.spicejet.com/");
    }

    [Test]
    public async Task SearchFligth(){
        ModernFlightsPage page = new ModernFlightsPage(Page);
        await page.SearchFlight();
    }
}
