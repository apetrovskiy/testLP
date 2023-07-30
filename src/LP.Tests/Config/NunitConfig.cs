// <copyright file="NunitConfig.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace LP.Tests.Config;

using NUnit.Framework;

public class NunitConfig
{
    [OneTimeSetUp]
    public void Init()
    {
        Environment.CurrentDirectory = Path.GetDirectoryName(this.GetType().Assembly.Location);
    }
}
