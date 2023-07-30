// <copyright file="CalculatorStepDefinitions.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace LP.Tests.Specs.Steps;

using System.Threading.Tasks;
using FluentAssertions;
using LP.Tests.Specs.API;
using TechTalk.SpecFlow;

[Binding]
public sealed class CalculatorStepDefinitions
{
    private readonly CalculatorApi calculator;
    private int result;

    public CalculatorStepDefinitions(CalculatorApi calculator)
    {
        this.calculator = calculator;
    }

    [Given("the first number is (.*)")]
    public void GivenTheFirstNumberIs(int number)
    {
        this.calculator.FirstNumber = number;
    }

    [Given("the second number is (.*)")]
    public void GivenTheSecondNumberIs(int number)
    {
        this.calculator.SecondNumber = number;
    }

    [When("the two numbers are added")]
    public async Task WhenTheTwoNumbersAreAddedAsync()
    {
        this.result = await this.calculator.AddAsync();
    }

    [When(@"the two numbers are subtracted")]
    public async Task WhenTheTwoNumbersAreSubtractedAsync()
    {
        this.result = await this.calculator.SubtractAsync();
    }

    [When(@"the two numbers are divided")]
    public async Task WhenTheTwoNumbersAreDividedAsync()
    {
        this.result = await this.calculator.DivideAsync();
    }

    [When(@"the two numbers are multiplied")]
    public async Task WhenTheTwoNumbersAreMultiplied()
    {
        this.result = await this.calculator.MultiplyAsync();
    }

    [Then("the result should be (.*)")]
    public void ThenTheResultShouldBe(int result)
    {
        this.result.Should().Be(result);
    }
}
