// <copyright file="BrowserDriver.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace LP.Core.Drivers;

using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

/// <summary>
/// Manages a browser instance using Selenium.
/// </summary>
public class BrowserDriver : IDisposable
{
    private readonly Lazy<IWebDriver> currentWebDriverLazy;
    private bool isDisposed;

    public BrowserDriver()
    {
        this.currentWebDriverLazy = new Lazy<IWebDriver>(this.CreateWebDriver);
    }

    /// <summary>
    /// Gets the Selenium IWebDriver instance.
    /// </summary>
    public IWebDriver Current => this.currentWebDriverLazy.Value;

    /// <summary>
    /// Disposes the Selenium web driver (closing the browser) after the Scenario completed.
    /// </summary>
    public void Dispose()
    {
        if (this.isDisposed)
        {
            return;
        }

        if (this.currentWebDriverLazy.IsValueCreated)
        {
            this.Current.Quit();
        }

        this.isDisposed = true;
    }

    /// <summary>
    /// Creates the Selenium web driver (opens a browser).
    /// </summary>
    /// <returns></returns>
    private IWebDriver CreateWebDriver()
    {
        // We use the Chrome browser
        var chromeDriverService = ChromeDriverService.CreateDefaultService();

        var chromeOptions = new ChromeOptions();

        var chromeDriver = new ChromeDriver(chromeDriverService, chromeOptions);

        return chromeDriver;
    }
}
