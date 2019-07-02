Feature: LanguageFeature
	In order to update my profile
	As a skill trader
	I want to add, update, delete language

@autoamte
Scenario Outline: Check if user is able to add new language
	Given I clicked on the Languages tab under Profile page
	When I clicked on add <language>
    Then the new <language> should display on my listings
	Examples: 
	| language |
	| English  |
	| French   |
	| Hindi    |
	| German  |
	
@automate
Scenario: Check if user is able to update the language
Given I clicked on the Languages tab under Profile page
When I clicked on pencil icon and update language
Then the updated language should display on my listings

@automate
Scenario: Check if user is able to delete the language
Given I clicked on the Languages tab under Profile page
When I clicked on delete icon
Then the deleted language should not display on my listings

@manual
Scenario Outline: Check if user is able to add more than four language
Given I clicked on the Languages tab under Profile page
Given I have four <language> in my list
Then I should not able to add more language
Examples: 
| language |
| English  |
| French   |
| Hindi    |
| Irish    |
| German   |



@manual
Scenario: Check if user is able to add language without choosing the language level
Given I clicked on the Languages tab under Profile page
When I clicked on AddNew button 
And I entered the new language
But I don't choose the language level
Then I should not able to add language


	





