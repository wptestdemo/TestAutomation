Feature: HomePage
User should get all company related information when reach on landing page.

@SmokeTest
Scenario: Home page header
	Given User launch the browser
	When Navigate to landing page url
	Then Word Publishing - QA Expert header should be display

#Scenario: Great idea title is pressent and displaying as a header
#	Given User launch the browser
#	When Navigate to landing page url
#	Then Great Idea title header should be display
