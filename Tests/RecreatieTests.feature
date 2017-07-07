Feature: Recreatie Tests

Background: 
	Given browser local data is cleared
	And there is internet connection

@recreatieFlows
Scenario: City and default radius search
	Given funda website is opened on "recreatie" tab
	When I fill in "Nieuwbouw" search form "Amsterdam" and "+ 0 km"
	And  I click Search
	Then the page title will show the search result for "Amsterdam"
	When I go to funda homepage on "recreatie" tab
	Then I see last search as "Amsterdam"

@recreatieFlows
Scenario: City and radius search
	Given funda website is opened on "recreatie" tab
	When I fill in "Nieuwbouw" search form "Vught" and "+ 5 km"
	When  I click Search
	Then the page title will show the search result for "Amsterdam"
	When I go to funda homepage on "recreatie" tab
	Then I see last search as "Vught, +5 km"