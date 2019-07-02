Feature: CertificationsFeature
	In order to update my profile
	As a skill trader
	I want to add, update, delete Certifications


@manual
Scenario: Check if user is able to add new certification
Given I clicked on the Certifications tab under Profile page
When I clicked on AddNew button 
And I enetered Certification, Certified from and Year of certification
Then the new certification should display on my listings
	
	
@manual
Scenario: Check if user is able to update the certification
Given I clicked on the Certifications tab under Profile page
When I clicked on pencil icon and update certification
Then the updated certification should display on my listings

@manual
Scenario: Check if user is able to delete the certification
Given I clicked on the Certifications tab under Profile page
When I clicked on delete icon
Then the deleted certification should not display on my listings
