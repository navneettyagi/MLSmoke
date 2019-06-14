Feature: SearchBy_Feature
	Description: This feature will test the Search Page functionality

@smoke
Scenario: Verify the loading of APP with valid APP number
	 Given User Login successfully
     When User select the Loan APP Number from the drop down
	 And User enters valid APP number and Click Search 
     Then Same APP number should be displayed in the loaded Application

Scenario: Verify the loading of APP with invalid APP number
	 Given User Login successfully
     When User select the Loan APP Number from the drop down
	 And User enters invalid APP number and Click Search 
     Then Pop up should be displayed as No Results found

Scenario: Verify the loading of APP with valid first name
	 Given User Login successfully
     When User select the First Name from the drop down
	 And User enters valid first name and Click Search 
     Then Same first name APP should be displayed in the name column of the results found

Scenario: Verify the loading of APP with invalid first name
	 Given User Login successfully
     When User select the First Name from the drop down
	 And User enters invalid first name and Click Search 
     Then Pop up should be displayed as No Results found

Scenario: Verify the loading of APP with valid last name
	 Given User Login successfully
     When User select the Last Name from the drop down
	 And User enters valid lasst name and Click Search 
     Then Same last name APP should be displayed in the name column of the results found

Scenario: Verify the loading of APP with invalid last name
	 Given User Login successfully
     When User select the Last Name from the drop down
	 And User enters invalid last name and Click Search 
     Then Pop up should be displayed as No Results found




	