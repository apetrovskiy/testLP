# -- FILE: features/gherkin.rule_example.feature
Feature: Highlander

    Rule: There can be only One

        Scenario: Only One -- More than one alive
            Given there are 3 ninjas
            And there are more than one ninja alive
            When 2 ninjas meet, they will fight
            Then one ninja dies (but not me)
            And there is one ninja less alive

        Scenario: Only One -- One alive
            Given there is only 1 ninja alive
            Then he (or she) will live forever ;-)

        @edge_case
    Rule: There can be Two (in some cases)

        Scenario: Two -- Dead and Reborn as Phoenix
        #

        Scenario: Multiple Givens
            Given one thing
            And another thing
            And yet another thing
            When I open my eyes
            Then I should see something
            But I shouldn't see something else

        Scenario: All done
            Given I am out shopping
            * I have eggs
            * I have milk
            * I have butter
            When I check my list
            Then I don't need anything