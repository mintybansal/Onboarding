Feature: EducationFeature
	In order to update my profile
	As a skill trader
	I want to add, update, delete Education

@manual
Scenario: Check if user is able to add new education
Given I clicked on the Education tab under Profile page
When I clicked on AddNew button 
And I enetered College/University name, Country of university/College, Title, Degree and year of graduation
Then the new education should display on my listings
	
	
@manual
Scenario: Check if user is able to update the education
Given I clicked on the Education tab under Profile page
When I clicked on pencil icon and update education
Then the updated education should display on my listings

@manual
Scenario: Check if user is able to delete the education
Given I clicked on the Education tab under Profile page
When I clicked on delete icon
Then the deleted education should not display on my listings

