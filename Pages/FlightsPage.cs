using Microsoft.Playwright;

namespace Demo.Pages;

public class FlightsPage
{
    private IPage _page;
    public FlightsPageMap Map;

    public FlightsPage(IPage page){
        _page = page;
        Map = new FlightsPageMap(_page);
    }

    public async Task SearchForAFlight(){
        await Map.fromDropDownList.ClickAsync();
        await Map.originPlaceOption.ClickAsync(new() {Timeout = 5000});
        await Map.destinyPlaceOption.ClickAsync();
        await Assertions.Expect(Map.fromDropDownList).ToHaveAttributeAsync("selectedtext", "Bengaluru (BLR)");
        await Assertions.Expect(Map.toDropDownList).ToHaveAttributeAsync("selectedtext", "Chennai (MAA)");
        await Map.departDateCalendar.ClickAsync();
        string? styleValue = await Map.returnDateCalendar.GetAttributeAsync("style");
        if(styleValue != null && styleValue.Contains("0.5")){
            Assert.True(true);
        }else{
            Assert.True(false);
        }
        await Map.familyAndFriendsCheckBox.CheckAsync();
        await Map.passengersDropDownList.ClickAsync();
        int i = 0;
        while(i<4){
            await Map.adultsButton.ClickAsync();
            i++;
        }
        await Map.childsButton.ClickAsync();
        await Map.childsButton.ClickAsync();
        await Map.infantButton.ClickAsync();
        await Map.DonePassangersButton.ClickAsync();
        await Assertions.Expect(Map.passengersDropDownList).ToHaveTextAsync("5 Adult, 2 Child, 1 Infant");
        await Map.currencyDropDownList.SelectOptionAsync("USD");
        await Map.searchButton.ClickAsync();
    }


    public class FlightsPageMap(IPage page){
        public ILocator fromDropDownList = page.Locator("#ctl00_mainContent_ddl_originStation1_CTXT");
        public ILocator originPlaceOption = page.Locator("xpath=//a[@value='BLR']");
        public ILocator toDropDownList = page.Locator("#ctl00_mainContent_ddl_destinationStation1_CTXT");
        public ILocator destinyPlaceOption = page.Locator("xpath=//div[@id='glsctl00_mainContent_ddl_destinationStation1_CTNR'] //a[@value='MAA']"); 
        public ILocator departDateCalendar = page.Locator("css=.ui-state-default.ui-state-active");
        public ILocator returnDateCalendar = page.Locator("#Div1");
        public ILocator familyAndFriendsCheckBox = page.Locator("css=input[id*='friendsandfamily']");
        public ILocator passengersDropDownList = page.Locator("#divpaxinfo");
        public ILocator adultsButton = page.Locator("#hrefIncAdt");
        public ILocator childsButton = page.Locator("#hrefIncChd");
        public ILocator infantButton = page.Locator("#hrefIncInf");
        public ILocator DonePassangersButton = page.Locator("#btnclosepaxoption");
        public ILocator currencyDropDownList = page.Locator("#ctl00_mainContent_DropDownListCurrency");
        public ILocator searchButton = page.Locator("#ctl00_mainContent_btn_FindFlights");

    }
}
