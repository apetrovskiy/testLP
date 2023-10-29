// <copyright file="CalculatorHooks.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace LP.Tests.Hooks;

using LP.Core.Drivers;
using LP.Core.Pages;
using TechTalk.SpecFlow;

/// <summary>
/// Calculator related hooks.
/// </summary>
[Binding]
public class CalculatorHooks
{
    /// <summary>
    ///  Reset the calculator before each scenario tagged with "Calculator".
    /// </summary>
    [BeforeScenario("Calculator")]
    public static void BeforeScenario(BrowserDriver browserDriver)
    {
        var calculatorPageObject = new CalculatorPageObject(browserDriver.Current);
        calculatorPageObject.EnsureCalculatorIsOpenAndReset();
    }
}
