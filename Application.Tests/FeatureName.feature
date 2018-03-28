Feature: google calculator

Scenario: Validate the multiplication operation
	Given the equation of 10*37
	When I request the result of the operation
	Then the result will be 370 

Scenario: Validate add operation
	Given the equation of 10+37
	When I request the result of the operation
	Then the result will be 47 

