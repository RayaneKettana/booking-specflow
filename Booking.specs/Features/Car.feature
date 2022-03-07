Feature: Car
Simple calculator for adding two numbers

    Background:
        Given the following cars exists
          | color | brand | model   | Cv | base price | price / km |
          | black | BMW   | Serie 3 | 16 | 60.99      | 3.0        |
          | grey  | DACIA | Duster  | 7  | 36.98      | 1.3        |
        And the following customers exist
          | Firstname | LastName | Birthday    | DatePermitObtained | DrivingLicenceNumber | Password     |
          | John      | Smith    | Dec 4, 1998 | Feb 5, 2018        | 1234565431           | password1234 |
          | Mike      | Adams    | Dec 4, 1995 | Oct 5, 2014        | 1987214312           | password4321 |
        And the client initialized

    @mytag
    Scenario: A car has the unique id
        Given I'm connected with "John" and "password1234"
        And I get the list of vehicle
        And I take the first
        When I get registration id
        Then The id should be unique

    Scenario: A car has the right attributes
        Given I'm connected with "John" and "password1234"
        And I get the list of vehicle
        When I take the first
        Then it has a brand
        And it has a model
        And it has a color
