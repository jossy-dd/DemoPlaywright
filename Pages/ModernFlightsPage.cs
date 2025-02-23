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
        //verify that the field "Return Date" is inactive
        string? styleValue = await Map.returnDateCalendar.GetAttributeAsync("style");
        if(styleValue != null && styleValue.Contains("background-color: rgb(238, 238, 238);")){
            Assert.True(true);
        }else{
            Assert.True(false);
        }

        await Map.fromDropDownList.ClickAsync();
        await Map.originPlaceOption.ClickAsync(new() {Timeout = 5000});
        await Map.internationalButton.ClickAsync(new() {Timeout = 5000});
        await Map.destinyPlaceOption.ClickAsync(new() {Timeout = 5000});
        await Map.departDateCalendar.ClickAsync(new() {Timeout = 5000});
        await Map.passengersDropDownList.ClickAsync();
        int i= 0;
        while(i<4){
            await Map.adultButton.ClickAsync();
            i++;
        }
        await Map.childrenButton.ClickAsync();
        await Map.childrenButton.ClickAsync();
        await Map.infantButton.ClickAsync();
        await Map.doneButton.ScrollIntoViewIfNeededAsync();
        await Map.doneButton.ClickAsync();
        await Map.currencyDropDownList.ClickAsync();
        await Map.currencyOption.ClickAsync();
        await Map.familyAndFriendsRadioButton.ClickAsync();
        await Map.searchFlightButton.ClickAsync();
    }

    public class ModernFlightsPageMap(IPage page){
        public ILocator roundTripRadioButton = page.Locator("xpath=(//*[name()='circle'])[2]");
        public ILocator fromDropDownList = page.Locator("xpath=//div[@class='r-1862ga2 r-1loqt21 r-1enofrn r-tceitz r-u8s1d css-76zvg2'][normalize-space()='From']");
        public ILocator originPlaceOption = page.Locator("xpath=//div[contains(@class, 'r-cqee49') and text()='Belagavi']");
        public ILocator internationalButton = page.Locator("xpath=//div[contains(@class,'css-76zvg2 r-cqee49 r-ubezar r-1ozqkpa') and text()='International']");
        public ILocator destinyPlaceOption = page.Locator("xpath=//div[text()='Dubai']/following-sibling::div[text()=', United Arab Emirates']");
        public ILocator departDateCalendar = page.Locator("css=.css-1dbjc4n.r-1awozwy.r-19m6qjp.r-156aje7.r-y47klf.r-1phboty.r-1d6rzhh.r-1pi2tsx.r-1777fci.r-13qz1uu");
        public ILocator returnDateCalendar = page.Locator("div[data-testid='return-date-dropdown-label-test-id']");
        public ILocator passengersDropDownList = page.Locator("xpath=//div[normalize-space()='Passengers']");
        public ILocator adultButton = page.Locator("css=div[data-testid='Adult-testID-plus-one-cta']");
        public ILocator childrenButton = page.Locator("css=div[data-testid='Children-testID-plus-one-cta']");
        public ILocator infantButton = page.Locator("css=div[data-testid='Infant-testID-plus-one-cta']");
        public ILocator doneButton = page.Locator("css=div[data-testid='home-page-travellers-done-cta']");
        public ILocator currencyDropDownList = page.Locator("xpath=//div[normalize-space()='Currency']");
        public ILocator currencyOption = page.Locator("xpath=//div[contains(text(),'USD')]");
        public ILocator familyAndFriendsRadioButton = page.Locator("xpath=//div[contains(text(),'Family & Friends')]");
        public ILocator searchFlightButton = page.Locator("css=div[data-testid='home-page-flight-cta']");
    }
}
