Feature: Customer
Customer scenario

    Background: Init
        Given the following customers exist
          | Firstname | LastName | Birthday    | DatePermitObtained | DrivingLicenceNumber | Password     |
          | John      | Smith    | Dec 4, 1998 | Feb 5, 2018        | 1234565431           | password1234 |
          | Mike      | Adams    | Dec 4, 1995 | Oct 5, 2014        | 1987214312           | password4321 |
          And the client initialized

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