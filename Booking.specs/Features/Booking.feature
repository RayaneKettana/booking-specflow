Feature: Booking

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
