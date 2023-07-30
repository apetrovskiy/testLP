// <copyright file="ManualSteps.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace LP.Tests.Steps;

using TechTalk.SpecFlow;

[Binding]
[Scope(Tag = "manual")]
public class ManualSteps
{
    [Given(".*")]
    [When(".*")]
    [Then(".*")]
    public void EmptyStep()
    {
    }

    [Given(".*")]
    [When(".*")]
    [Then(".*")]
    public void EmptyStep(string multiLineStringParam)
    {
    }

    [Given(".*")]
    [When(".*")]
    [Then(".*")]
    public void EmptyStep(Table tableParam)
    {
    }
}
