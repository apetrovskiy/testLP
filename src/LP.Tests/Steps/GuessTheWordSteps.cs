// <copyright file="GuessTheWordSteps.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace LP.Tests.Steps;

using TechTalk.SpecFlow;

[Binding]
public class GuessTheWordSteps
{
    private string word;
    private int wordLength;
    private bool isGameStarted;
    private bool waitForBreaker;
    private bool isBreakerJoined;

    [Given($"the Maker has started a game with the word \"silky\"")]
    public void GivenTheMakerHasStartedGameWithTheWord(string word)
    {
        this.word = word;
    }

    [When("the Maker starts a game")]
    public void WhenTheMakerStartsGame()
    {
        this.isGameStarted = true;
    }

    [Then("the Maker waits for a Breaker to join")]
    public void ThenTheMakerWaitsForBreakerToJoin()
    {
        this.waitForBreaker = true;
    }

    [When("the Breaker joins the Maker's game")]
    public void WhenTheBreakerJoinsTheMakersGame()
    {
        this.isBreakerJoined = true;
    }

    [Then("the Breaker must guess a word with {int} characters")]
    public void ThenTheBreakerMustGuessWordWithCharacters(int numberOfCharacters)
    {
        this.wordLength = numberOfCharacters;
    }
}
