Feature: Customer
Customer scenario

    Scenario: The customer want to create a account
        When I create an account
        Then I'm connected

    Scenario: The customer can login
        When I Login with a valid account
        Then I'm connected

    Scenario: The logged customer can logout
        Given I Login with a valid account
        And I'm connected
        When I logout
        Then I'm disconnected
        

    Scenario: The customer adding a start and end date and the list of available vehicles appears
        Given I'm connected
        When I insert a start and end date
        Then The list of available vehicles appears