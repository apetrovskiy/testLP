// <copyright file="SimpleTest.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace LP.Tests;

using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

public class SimpleTest
{
    [Test]
    public void Test01()
    {
        // Create a driver instance for chromedriver
        IWebDriver driver = new ChromeDriver();

        // Navigate to google page
        driver.Navigate().GoToUrl("http:www.google.com");

        // Maximize the window
        driver.Manage().Window.Maximize();

        // Find the Search text box using xpath
        IWebElement element = driver.FindElement(By.XPath("//*[@title='Search']"));

        // Enter some text in search text box
        element.SendKeys("learn-automation");

        // Close the browser
        driver.Close();
    }
}
