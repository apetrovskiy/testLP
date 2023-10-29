// <copyright file="CalculatorStepDefinitions.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace LP.Tests.Steps;

using FluentAssertions;
using LP.Core.Drivers;
using LP.Core.Pages;
using TechTalk.SpecFlow;

[Binding]
public sealed class CalculatorStepDefinitions
{
    // Page Object for Calculator
    private readonly CalculatorPageObject calculatorPageObject;

    public CalculatorStepDefinitions(BrowserDriver browserDriver)
    {
        this.calculatorPageObject = new CalculatorPageObject(browserDriver.Current);
    }

    [Given("the first number is (.*)")]
    public void GivenTheFirstNumberIs(int number)
    {
        // delegate to Page Object
        this.calculatorPageObject.EnterFirstNumber(number.ToString());
    }

    [Given("the second number is (.*)")]
    public void GivenTheSecondNumberIs(int number)
    {
        // delegate to Page Object
        this.calculatorPageObject.EnterSecondNumber(number.ToString());
    }

    [When("the two numbers are added")]
    public void WhenTheTwoNumbersAreAdded()
    {
        // delegate to Page Object
        this.calculatorPageObject.ClickAdd();
    }

    [Then("the result should be (.*)")]
    public void ThenTheResultShouldBe(int expectedResult)
    {
        // delegate to Page Object
        var actualResult = this.calculatorPageObject.WaitForNonEmptyResult();

        actualResult.Should().Be(expectedResult.ToString());
    }
}
