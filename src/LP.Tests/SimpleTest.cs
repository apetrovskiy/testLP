// <copyright file="SimpleTest.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace LP.Tests;

using LP.Core.Drivers;
using NUnit.Allure.Attributes;
using NUnit.Allure.Core;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

[TestFixture]
[NUnit.Allure.Core.AllureNUnit]

[AllureEpic("Unit testing in F#")]
[AllureFeature("Parameterized tests")]
[AllureStory("NUnit")]
[AllureSuite("NUnit")]
[AllureTag("NUnit")]
public class SimpleTest
{
    [Test]
    [AllureName("01")]
    public void Test01()
    {
        // Create a driver instance for chromedriver
        IWebDriver driver = new BrowserDriver().Current;

        // Navigate to google page
        driver.Navigate().GoToUrl("http:www.google.com");

        // Maximize the window
        driver.Manage().Window.Maximize();

        // Find the Search text box using xpath
        IWebElement element = driver.FindElement(By.XPath("//*[@title='Search']"));

        // Enter some text in search text box
        element.SendKeys("learn-automation");

        // Close the browser
        // driver.Close();
        driver.Quit();
    }

    [Test]
    [AllureName("02")]
    public void TestLoginOK()
    {
        var driver = new BrowserDriver().Current;
        driver.Navigate().GoToUrl("http://travel.agileway.net");
        driver.FindElement(By.Name("username")).SendKeys("agileway");
        driver.FindElement(By.Name("password")).SendKeys("testwise");
        driver.FindElement(By.Name("password")).Submit();
        Assert.IsTrue(driver.PageSource.Contains("Signed in!"));
        driver.Quit();
    }
}
