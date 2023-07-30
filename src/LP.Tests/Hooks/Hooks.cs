// <copyright file="Hooks.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace LP.Tests.Specs.Hooks;

// using Microsoft.Extensions.Hosting;
// using SpecFlowCalculatorAPI;
using TechTalk.SpecFlow;

[Binding]
public sealed class Hooks
{
    // private static IHost _host;
    [BeforeTestRun]
    public static void BeforeTestRun()
    {
        // _host = Program.CreateHostBuilder(null).Build();

        // _host.Start();
    }

    [AfterTestRun]
    public static void AfterTestRun()
    {
        // _host.StopAsync().Wait();
    }
}
