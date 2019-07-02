Feature: LoginFeature
	In order to access my account
	As a skill trader
	I want to log into the website

@manual
Scenario: Successful Login with Valid Credentials
 Given User is at the Home Page
 And Navigate to LogIn Page
 When User enter UserName and Password
 And Click on the LogIn button
 Then Successful LogIN message should display

 @manual
 Scenario: Successful LogOut
 When User LogOut from the Application
 Then Successful LogOut message should display
