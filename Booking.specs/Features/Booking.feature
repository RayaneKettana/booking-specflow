Feature: Booking

    Background: Init
        Given the following customers exist
          | Firstname | LastName | Birthday    | DatePermitObtained | DrivingLicenceNumber | Password     |
          | John      | Smith    | Dec 4, 1998 | Feb 5, 2018        | 1234565431           | password1234 |
          | Mike      | Adams    | Dec 4, 1995 | Oct 5, 2014        | 1987214312           | password4321 |
        And the following cars exists
          | color | brand | model   |
          | black | BMW   | Serie 3 |
          | grey  | DACIA | Duster  |
        And the following booking exists
          | customer | from  | to      |
          | John    |    | Serie 3 |
        And the client initialized

    @Booking
    Scenario: The customer can book a car
        Given I Login with a valid account
        And I insert a start and end date
        When I book a car
        Then The car is booked

    Scenario: The logged out customer cannot display cars list
        Given I'm disconnected
        When ask the available cars
        Then I get an empty list

    Scenario: A customer whom book a car can return it and get billed
        Given I'm connected
        And I insert a start and end date
        And I book a car
        And I take the car
        When I return it
        Then I receive a bill