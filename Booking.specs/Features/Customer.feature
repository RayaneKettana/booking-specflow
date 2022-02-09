Feature: Customer
Customer scenario

    Scenario: The customer want to create a account
        When I create an account
        Then I'm connected

    Scenario: The customer adding a start and end date and the list of available vehicles appears
        Given I'm connected
        When I insert a start and end date
        Then The list of available vehicles appears

    Scenario: Le client sélectionne une voiture parmi la liste fournie
        Given I'm connected
        And I insert a start and end date
        And The list of available vehicles appears
        When I select the first car in the list
        Then The car is selected
        
        