Feature: Car
	Simple calculator for adding two numbers

@mytag
Scenario: A car has the unique id
	Given I get the list of vehicle
	And I take the first
	When I get registration id
	Then The id should be unique