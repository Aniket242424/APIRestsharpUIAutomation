Feature: DataValidation
	Simple calculator for adding two numbers

@mytag
Scenario:  Verify Infected Cases
	Given I open Covid live data WebApp
	When I click on 'Home' Tab
	And get request is made to api for 'Infected' cases
	Then the 'Infected' cases data from UI is same as from API

@mytag
Scenario:  Verify Deaths Cases
	Given I open Covid live data WebApp
	When I click on 'Home' Tab
	And get request is made to api for 'Deaths' cases
	Then the 'Deaths' cases data from UI is same as from API

@mytag
Scenario Outline: Verify country wise Infected cases
	Given I open Covid live data WebApp
	When I click on 'Home' Tab
	And I select "<Country>" from dropdown
	Then the 'Infected' cases data of "<Country>" from UI is same as from API
Examples: 
 | Country     |
 | India       |
 | Afghanistan |
 | Australia   |

