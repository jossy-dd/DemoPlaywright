using System;
using Demo.Pages;
using Microsoft.Playwright.NUnit;
namespace Demo.Test;

public class SignInTest: PageTest
{
    [SetUp]
    public async Task Setup()
    {
        await Page.GotoAsync(url:"https://rahulshettyacademy.com/locatorspractice/");
    }

    [Test]
    public async Task LogInWithForgotPassword()
    {
        SignInPage signInPage = new SignInPage(Page);
        await signInPage.LogInWithForgotPassword("jossy","admin123", "Jossy", "jossy@gmail.com", "5417807965");
    }
}
