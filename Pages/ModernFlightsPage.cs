using System.Data;
using Microsoft.Playwright;

namespace Demo.Pages;

public class ModernFlightsPage
{
    private IPage _page;
    public ModernFlightsPageMap Map;

    public ModernFlightsPage(IPage page){
        _page = page;
        Map = new ModernFlightsPageMap(_page);
    }

    public async Task SearchFlight(){
        string? styleValue = await Map.returnDateCalendar.GetAttributeAsync("style");
        if(styleValue != null && styleValue.Contains("background-color: rgb(238, 238, 238);")){
            Assert.True(true);
        }else{
            Assert.True(false);
        }
        await Map.roundTripRadioButton.ClickAsync();
        await Map.fromDropDownList.ClickAsync();
        await Map.originPlaceOption.ClickAsync(new() {Timeout = 5000});
        await Map.internationalButton.ClickAsync(new() {Timeout = 5000});
        await Map.destinyPlaceOption.ClickAsync(new() {Timeout = 5000});
      
    }

    public class ModernFlightsPageMap(IPage page){
        public ILocator roundTripRadioButton = page.Locator("xpath=(//*[name()='circle'])[2]");
        public ILocator fromDropDownList = page.Locator("xpath=//div[@class='r-1862ga2 r-1loqt21 r-1enofrn r-tceitz r-u8s1d css-76zvg2'][normalize-space()='From']");
        public ILocator originPlaceOption = page.Locator("xpath=//div[contains(@class, 'r-cqee49') and text()='Belagavi']");
        public ILocator internationalButton = page.Locator("xpath=//div[contains(@class,'css-76zvg2 r-cqee49 r-ubezar r-1ozqkpa') and text()='International']");
        public ILocator destinyPlaceOption = page.Locator("xpath=//div[text()='Dubai']/following-sibling::div[text()=', United Arab Emirates']");
        public ILocator departDateCalendar = page.Locator("css=.css-1dbjc4n.r-1awozwy.r-19m6qjp.r-156aje7.r-y47klf.r-1phboty.r-1d6rzhh.r-1pi2tsx.r-1777fci.r-13qz1uu");
        public ILocator returnDateCalendar = page.Locator("div[data-testid='return-date-dropdown-label-test-id']");


    }
}
