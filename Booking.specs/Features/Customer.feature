Feature: Customer
Customer scenario

    Background: Init
        Given the following customers exist
          | Firstname | LastName | Birthday    | DatePermitObtained | DrivingLicenceNumber | Password     |
          | John      | Smith    | Dec 4, 1998 | Feb 5, 2018        | 1234565431           | password1234 |
          | Mike      | Adams    | Dec 4, 1995 | Oct 5, 2014        | 1987214312           | password4321 |
        And the following cars exists
          | color | brand | model   | Cv | base price | price / km |
          | black | BMW   | Serie 3 | 16 | 60.99      | 3.0        |
          | grey  | DACIA | Duster  | 7  | 36.98      | 1.3        |
          And the client initialized

    Scenario: The customer want to create a account
        When I create an account
        Then I'm connected

    Scenario: The customer can login
        Given I'm connected with "John" and "password1234"
        Then I'm connected

    Scenario: The logged customer can logout
        Given I'm connected with "John" and "password1234"
        When I logout
        Then I'm disconnected

    Scenario: The customer adding a start and end date and the list of available vehicles appears
        Given I'm connected
        When I insert a start and end date
        Then The list of available vehicles appears
        
         