Feature: google calculator

Scenario: Test 001 in Chrome
	Given the equation of 10*37
	When I request the result of the operation in the Chrome browser
	Then the result will be 370 

Scenario: Test 001 in Edge
	Given the equation of 10*37
	When I request the result of the operation in the Edge browser
	Then the result will be 370 

Scenario: Test 001 in InternetExplorer
	Given the equation of 10*37
	When I request the result of the operation in the InternetExplorer browser
	Then the result will be 370 

