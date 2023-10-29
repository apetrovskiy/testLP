// <copyright file="CalculatorPageObject.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace LP.Core.Pages;

using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

/// <summary>
/// Calculator Page Object.
/// </summary>
public class CalculatorPageObject
{
    // The default wait time in seconds for wait.Until
    public const int DefaultWaitInSeconds = 5;

    // The URL of the calculator to be opened in the browser
    private const string CalculatorUrl = "https://specflowoss.github.io/Calculator-Demo/Calculator.html";

    // The Selenium web driver to automate the browser
    private readonly IWebDriver webDriver;

    public CalculatorPageObject(IWebDriver webDriver)
    {
        this.webDriver = webDriver;
    }

    // Finding elements by ID
    private IWebElement FirstNumberElement => this.webDriver.FindElement(By.Id("first-number"));

    private IWebElement SecondNumberElement => this.webDriver.FindElement(By.Id("second-number"));

    private IWebElement AddButtonElement => this.webDriver.FindElement(By.Id("add-button"));

    private IWebElement ResultElement => this.webDriver.FindElement(By.Id("result"));

    private IWebElement ResetButtonElement => this.webDriver.FindElement(By.Id("reset-button"));

    public void EnterFirstNumber(string number)
    {
        // Clear text box
        this.FirstNumberElement.Clear();

        // Enter text
        this.FirstNumberElement.SendKeys(number);
    }

    public void EnterSecondNumber(string number)
    {
        // Clear text box
        this.SecondNumberElement.Clear();

        // Enter text
        this.SecondNumberElement.SendKeys(number);
    }

    public void ClickAdd()
    {
        // Click the add button
        this.AddButtonElement.Click();
    }

    public void EnsureCalculatorIsOpenAndReset()
    {
        // Open the calculator page in the browser if not opened yet
        if (this.webDriver.Url != CalculatorUrl)
        {
            this.webDriver.Url = CalculatorUrl;
        }

        // Otherwise reset the calculator by clicking the reset button
        else
        {
            // Click the rest button
            this.ResetButtonElement.Click();

            // Wait until the result is empty again
            this.WaitForEmptyResult();
        }
    }

    public string WaitForNonEmptyResult()
    {
        // Wait for the result to be not empty
        return this.WaitUntil(
            () => this.ResultElement.GetAttribute("value"),
            result => !string.IsNullOrEmpty(result));
    }

    public string WaitForEmptyResult()
    {
        // Wait for the result to be empty
        return this.WaitUntil(
            () => this.ResultElement.GetAttribute("value"),
            result => result == string.Empty);
    }

    /// <summary>
    /// Helper method to wait until the expected result is available on the UI.
    /// </summary>
    /// <typeparam name="T">The type of result to retrieve.</typeparam>
    /// <param name="getResult">The function to poll the result from the UI.</param>
    /// <param name="isResultAccepted">The function to decide if the polled result is accepted.</param>
    /// <returns>An accepted result returned from the UI. If the UI does not return an accepted result within the timeout an exception is thrown.</returns>
    private T WaitUntil<T>(Func<T> getResult, Func<T, bool> isResultAccepted)
        where T : class
    {
        var wait = new WebDriverWait(this.webDriver, TimeSpan.FromSeconds(DefaultWaitInSeconds));
        return wait.Until(driver =>
        {
            var result = getResult();
            if (!isResultAccepted(result))
            {
                return default;
            }

            return result;
        });
    }
}
