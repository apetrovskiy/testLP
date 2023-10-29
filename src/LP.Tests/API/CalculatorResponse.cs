// <copyright file="CalculatorResponse.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace LP.Tests.Specs.API;

using System.Net;
using System.Threading.Tasks;
using RestSharp;

internal sealed class CalculatorResponse
{
    public int Result { get; set; }
}
