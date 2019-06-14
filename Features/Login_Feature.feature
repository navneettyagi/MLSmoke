Feature: Login_Feature
	Description: This feature will test a LogIn functionality

@mytag
Scenario: Successful Login with Valid Credentials
	 Given User is on Home Page
     When User enters UserName and Click Login
	 And User enters correct answer for given questions and click Continue
     And User enters Password and Click SignIn
     Then User's Home page will display with Welcome UserName message
