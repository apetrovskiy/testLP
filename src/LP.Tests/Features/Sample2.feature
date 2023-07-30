Feature: Sample 2
    Simple calculator for adding two numbers

    @mytag
    Scenario: Add two numbers 2
        Given the first number is 50
        And the second number is 70
        When the two numbers are added
        Then the result should be 120

        Given the following books
            | Author        | Title                          |
            | Martin Fowler | Analysis Patterns              |
            | Gojko Adzic   | Bridging the Communication Gap |