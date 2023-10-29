// <copyright file="MyHooks.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace LP.Tests.Hooks;

using TechTalk.SpecFlow;
using static System.Console;

[Binding]
public class MyHooks
{
    private ScenarioContext scenarioContext;

    public MyHooks(ScenarioContext scenarioContext)
    {
        this.scenarioContext = scenarioContext;

        WriteLine("MyHooks()");
    }

    [BeforeFeature]
    public static void SetupStuffForFeatures(FeatureContext featureContext)
    {
        WriteLine("Starting " + featureContext.FeatureInfo.Title);
    }

    [BeforeTestRun]
    public static void BeforeTestRunInjection(ITestRunnerManager testRunnerManager, ITestRunner testRunner)
    {
        // All parameters are resolved from the test thread container automatically.
        // Since the global container is the base container of the test thread container, globally registered services can be also injected.

        // ITestRunManager from global container
        var location = testRunnerManager.TestAssembly.Location;

        // ITestRunner from test thread container
        // TODO: 20231030 var threadId = testRunner.ThreadId;
    }

    [BeforeScenario]
    public void SetupTestUsers()
    {
        // _scenarioContext...
        WriteLine("[BeforeScenario] SetupTestUsers");
    }

    [BeforeScenario]
    public void SetupTestUsers(ScenarioContext scenarioContext)
    {
        // scenarioContext...
        WriteLine("[BeforeScenario] SetupTestUsers");
    }
}
