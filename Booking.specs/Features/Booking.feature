Feature: Booking

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
        
    Scenario: The underage customer cannot book a car
        Given I Login with a valid account
        And I insert a start and end date
        When I book a car
        Then I receive a message "You should be 18 years old to book a car"
        
    Scenario: A customer without licence drive cannot book a car
        Given I Login with a valid account
        And I insert a start and end date
        When I book a car
        Then I receive a message "You need a licence driver to book a car"

        
    Scenario: A customer under 21 years old cannot book a  car more or equal than 8 horses
        Given I Login with a valid account
        And I insert a start and end date
        When I book a car
        Then I receive a message "You should be 21 yeard old for book this car"
        
    Scenario: A customer between 21 and 25 years old cannot a car more or equal than 16 horses
        Given I Login with a valid account
        And I insert a start and end date
        When I book a car
        Then I receive a message "You should be more than 25 years for book this car"


        
        