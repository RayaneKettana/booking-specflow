Feature: Booking

    Background: Init
        Given the following customers exist
          | Firstname | LastName | Birthday    | DatePermitObtained | DrivingLicenceNumber | Password     |
          | John      | Smith    | Dec 4, 1998 | Feb 5, 2018        | 1234565431           | password1234 |
          | Mike      | Adams    | Dec 4, 1995 | Oct 5, 2014        | 1987214312           | password4321 |
        And the client initialized

    @Booking
    Scenario: The customer can book a car
        Given I'm connected
        And I insert a start and end date
        And The list of available vehicles appears
        When I select the first car in the list
        Then The car is booked

    Scenario: The logged out customer cannot display cars list
        Given I'm disconnected
        When ask the available cars
        Then I get an empty list