Feature: SkillsFeature
	In order to update my profile
	As a skill trader
	I want to be add, update, delete my skills

@automate
Scenario: Check if user is able to add new skill
Given I clicked on skills tab under profile page
When I add new skills
Then the skills should display on my listings

@automate
Scenario: Check if user is able to update the skill
Given I clicked on the skills tab under Profile page
When I clicked on pencil icon and update skills
Then the updated skills should display on my listings

@automate
Scenario: Check if user is able to delete the skill
Given I clicked on the skills tab under Profile page
When I clicked on delete icon
Then the deleted skill should not display on my listings

@manual
Scenario: Check if user is able to add skill without choosing the skill level
Given I clicked on the skill tab under Profile page
When I clicked on AddNew button 
And I entered the new skill
But I don't choose the skill level
Then I should not able to add skill







