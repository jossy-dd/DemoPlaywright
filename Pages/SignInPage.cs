using System;
using Microsoft.Playwright;

namespace Demo.Pages;

public class SignInPage
{
    private IPage _page;
    public SignInPageMap Map;

    public SignInPage(IPage page){
        _page = page;
        Map = new SignInPageMap(_page);
    }

    public async Task LogInWithForgotPassword(string userName, string password, string name, string email, string phone){
        await Map.userNameTexBox.FillAsync(userName);
        await Map.passwordTextBox.FillAsync(password);
        await Map.signInButton.ClickAsync();
        await Assertions.Expect(Map.incorrectCredentialsMessage).ToBeVisibleAsync(new() { Timeout = 5000});
        await Map.forgotPasswordLink.ClickAsync();
        await _page.WaitForSelectorAsync("//form[@action='#']", new() {Timeout = 5000});
        await Map.nameTextBox.FillAsync(name);
        await Map.emailTextBox.FillAsync(email);
        await Map.phoneNumberTextBox.FillAsync(phone);
        await Map.resetLoginButton.ClickAsync();
        await Assertions.Expect(Map.informativeMessage).ToBeVisibleAsync();
        Console.WriteLine(Map.informativeMessage.TextContentAsync());
    }
    

    public class SignInPageMap(IPage page){
        public ILocator userNameTexBox = page.Locator("#inputUsername");
        public ILocator passwordTextBox = page.Locator("[name='inputPassword']");
        public ILocator signInButton = page.Locator(".signInBtn");
        public ILocator incorrectCredentialsMessage = page.Locator("css=p.error");
        public ILocator forgotPasswordLink = page.Locator("text=Forgot your password?");
        public ILocator nameTextBox = page.Locator("xpath=//input[@placeholder='Name']");
        public ILocator emailTextBox = page.Locator("css=input[placeholder='Email']");
        public ILocator phoneNumberTextBox = page.Locator("xpath=//form/input[3]");
        public ILocator resetLoginButton =  page.Locator("css=.reset-pwd-btn");
        public ILocator informativeMessage = page.Locator("xpath=//p[@class='infoMsg']");
    }
}
