Feature: Test Log in for ERP Portal 

@mytag


Scenario Outline: Test the login with valid credentials for ERP 
	Given Open the google browser 
	And enter the URL 
	When I enter valid <username>
	And valid <password> to sign in
	Then <username> should be able to login successfully
	And user log out from the application
	
	Examples:
	|username| password|
	|dummycal81@gmail.com| envirocal|
	|dummycal82@gmail.com| envirocal|
	|dummycal83@gmail.com| envirocal|