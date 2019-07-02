Feature: AddLanguageFeature
	In order to update my profile
	As a skill trader
	I want to be add, update, delete language

@mytag
Scenario: Check if user is able to add new language
	Given I clicked on the Language tab under Profile page
	When I clicked on add language under profile page
    Then the new language should display on my listings

@mytag
Scenario: Check if user us able to update the existing language
Given I clicked on the Language tab under Profile page
When I clicked on Write icon 
And I update the existing language
Then the updated language should display on my listings



