// <copyright file="CalculatorApi.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace LP.Tests.Specs.API;

using System.Net;
using System.Threading.Tasks;
using RestSharp;

public class CalculatorApi
{
    private readonly RestClient client;

    public CalculatorApi()
    {
        this.client = new RestClient("https://localhost:5001");

        ServicePointManager.ServerCertificateValidationCallback +=
            (sender, cert, chain, sslPolicyErrors) => true;
    }

    public int FirstNumber { get; set; }

    public int SecondNumber { get; set; }

    public async Task<int> AddAsync()
    {
        var request = new RestRequest("Calculator/Add").AddObject(this);

        var response = await this.client.GetAsync<CalculatorResponse>(request);

        return response.Result;
    }

    public async Task<int> SubtractAsync()
    {
        var request = new RestRequest("Calculator/Subtract").AddObject(this);

        var response = await this.client.GetAsync<CalculatorResponse>(request);

        return response.Result;
    }

    public async Task<int> MultiplyAsync()
    {
        var request = new RestRequest("Calculator/Multiply").AddObject(this);

        var response = await this.client.GetAsync<CalculatorResponse>(request);

        return response.Result;
    }

    public async Task<int> DivideAsync()
    {
        var request = new RestRequest("Calculator/Divide").AddObject(this);

        var response = await this.client.GetAsync<CalculatorResponse>(request);

        return response.Result;
    }
}
