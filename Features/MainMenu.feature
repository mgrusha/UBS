Feature: Main menu check
	In order to check the upper main manu
	As a guest user
	I want to click on it and do main actions


Scenario Outline: Check the language 
	Given I am on [Main] page for [<initialLanguage>]
	When I click on [<newLanguage>] button
	Then Page should be refreshed with [<newLanguage>]
	And title [<title>] is visible


	 Examples: 
        | initialLanguage | newLanguage | title          |
        | English         | German      | Globale Themen |
        | German          | English     | Global topics  |