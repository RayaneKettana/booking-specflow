Feature: Booking

    Background: Init
        Given the following customers exist
          | Firstname | LastName | Birthday    | DatePermitObtained | DrivingLicenceNumber | Password     |
          | John      | Smith    | Dec 4, 1992 | Feb 5, 2018        | 1234565431           | password1234 |
          | Mike      | Adams    | Dec 4, 1995 | Oct 5, 2014        | 1987214312           | password4321 |
          | Rayan     | Kley     | Dec 4, 2010 | Oct 5, 2014        | 1987214312           | password4321 |
          | Loic      | gluch    | Jan 4, 2002 | Oct 5, 2014        | null                 | password4321 |
          | Swan      | glowa    | Jan 4, 1998 | Oct 5, 2014        | 1987214312           | password4321 |
          | gyzo      | tchuk    | Jan 4, 1998 |                    |                      | password4321 |
          | Mike      | Adams    | Dec 4, 2013 | Oct 5, 2014        | 1987214312           | password4321 |
        And the following cars exists
          | color | brand   | model   | Cv | base price | price / km |
          | black | BMW     | Serie 3 | 16 | 60.99      | 3.0        |
          | green | Toyota  | Prius   | 9  | 45.99      | 2.3        |
          | jaune | Renault | Twingo  | 5  | 30.99      | 1.3        |
          | grey  | DACIA   | Duster  | 7  | 36.98      | 1.3        |
        And the client initialized

    @Booking
    Scenario: The customer can book a car
        Given I'm connected with "John" and "password1234"
        And I insert a start and end date
        When I book a "Prius"
        Then I receive the message "Réservation est un succès : Facture prévisionnel au nom de John Smith pour un montant de 390.99 €"

    Scenario: The logged out customer cannot display cars list
        Given I'm disconnected
        When ask the available cars
        Then I get an empty list

    Scenario: A customer whom book a car can return it and get billed
        Given I'm connected with "John" and "password1234"
        And I insert a start and end date
        And I book a "Prius"
        And I take the car
        When I return it
        Then I receive the message "Réservation cloturée : Facture au nom de John Smith pour un montant de 344.99 €"

    Scenario: A Customer cannot book two vehicle
        Given I'm connected with "John" and "password1234"
        And I insert a start and end date
        And I book a "Prius"
        When I book a "Twingo"
        Then I receive the message "Réservation impossible : Customer has already booked a car for the period"

    Scenario: The underage customer cannot book a car
        Given I'm connected with a underage account
        And I insert a start and end date
        And I book a "Prius"
        Then I receive the message "Réservation impossible"

    Scenario: A customer without drive licence cannot book a car
        Given I'm connected with a not licence user account
        And I insert a start and end date
        When I book a "Twingo"
        Then I receive the message "Réservation impossible"

    Scenario: A customer under 21 years old cannot book a  car more or equal than 8 horses
        Given I Login with a twenty years old account
        And I insert a start and end date
        When I book a car height cv
        Then I receive the message "Réservation impossible"

    Scenario: A customer between 21 and 25 years old cannot a car more or equal than 16 horses
        Given I Login with a twenty three years old account
        And I insert a start and end date
        When I book a car sixteen cv
        Then I receive the message "Réservation impossible"