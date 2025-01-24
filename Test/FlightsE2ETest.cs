using System;
using Demo.Pages;
using Microsoft.Playwright.NUnit;
namespace Demo.Test;

public class FlightsE2ETest: PageTest
{
     [SetUp]
    public async Task Setup()
    {
        await Page.GotoAsync(url:"https://rahulshettyacademy.com/dropdownsPractise/");
    }

    [Test]
    public async Task SearchForAFligth(){
        FlightsPage flightsPage = new FlightsPage(Page);
        await flightsPage.SearchForAFlight();
    }
}
