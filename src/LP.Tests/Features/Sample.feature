Feature: Sample
    Simple calculator for adding two numbers

    @mytag
    Scenario: Markdown body
        Given a blog post named "Random" with Markdown body
            """
            Some Title, Eh?
            ===============
            Here is the first paragraph of my blog post. Lorem ipsum dolor sit amet,
            consectetur adipiscing elit.
            """

    Scenario: Table example
        Given the following users exist:
            | name   | email              | twitter         |
            | Aslak  | aslak@cucumber.io  | @aslak_hellesoy |
            | Julien | julien@cucumber.io | @jbpros         |
            | Matt   | matt@cucumber.io   | @mattwynne      |

    Scenario: Alternatives
        When I have 42 cucumbers in my belly
        When I have 1 cucumber in my belly
        When I have 8 cucumbers in my tummy
