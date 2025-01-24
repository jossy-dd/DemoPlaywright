using System;
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
        await Map.departDateCalendar.ClickAsync();
        string? styleValue = await Map.returnDateCalendar.GetAttributeAsync("style");
        if(styleValue != null && styleValue.Contains("0.5")){
            Assert.True(true);
        }else{
            Assert.True(false);
        }
    }


    public class FlightsPageMap(IPage page){
        public ILocator fromDropDownList = page.Locator("#ctl00_mainContent_ddl_originStation1_CTXT");
        public ILocator originPlaceOption = page.Locator("xpath=//a[@value='BLR']");
        public ILocator destinyPlaceOption = page.Locator("xpath=//div[@id='glsctl00_mainContent_ddl_destinationStation1_CTNR'] //a[@value='MAA']"); 
        public ILocator departDateCalendar = page.Locator("css=.ui-state-default.ui-state-active");
        public ILocator returnDateCalendar = page.Locator("Div1");
    }
}
