Feature: Huur Tests

Background: 
	Given browser local data is cleared
	And there is internet connection

@huurFlows
Scenario: City, default radius and default price search
	Given funda website is opened on "huur" tab
	When I fill in "Huur" search form "Amsterdam", "+ 0 km", "€ 0", "Geen maximum"
	And  I click Search
	Then the page title will show the search result for "Amsterdam"
	When I go to funda homepage on "huur" tab
	Then I see last search as "Amsterdam"

@huurFlows
Scenario: City, radius and default price search
	Given funda website is opened on "huur" tab
	When I fill in "Huur" search form "Vught", "+ 5 km", "€ 0", "Geen maximum"
	When  I click Search
	Then the page title will show the search result for "Amsterdam"
	When I go to funda homepage on "huur" tab
	Then I see last search as "Vught, +5 km"

@huurFlows
Scenario: City, radius and price range search
	Given funda website is opened on "huur" tab
	When I fill in "Huur" search form "Vught", "+ 5 km", "€ 100", "€ 6.000"
	When  I click Search
	Then the page title will show the search result for "Amsterdam"
	When I go to funda homepage on "huur" tab
	Then I see last search as "Vught, +5 km, € 100 - € 6.000"

@huurFlows
Scenario: City, radius and minimum price range search
	Given funda website is opened on "huur" tab
	When I fill in "Huur" search form "Amsterdam", "+ 2 km", "€ 100", "Geen maximum"
	When  I click Search
	Then the page title will show the search result for "Amsterdam"
	When I go to funda homepage on "huur" tab
	Then I see last search as "Amsterdam, +2 km, € 100+"

@huurFlows
Scenario: City, radius and maximum price range search
	Given funda website is opened on "huur" tab
	When I fill in "Huur" search form "Amsterdam", "+ 2 km", "€ 0", "€ 6.000"
	When  I click Search
	Then the page title will show the search result for "Amsterdam"
	When I go to funda homepage on "huur" tab
	Then I see last search as "Amsterdam, +2 km, € 0 - € 6.000"

@huurFlows
Scenario: City, default radius and price range search
	Given funda website is opened on "huur" tab
	When I fill in "Huur" search form "Amsterdam", "+ 0 km", "€ 2.000", "€ 6.000"
	When  I click Search
	Then the page title will show the search result for "Amsterdam"
	When I go to funda homepage on "huur" tab
	Then I see last search as "Amsterdam, € 2.000 - € 6.000"

@huurFlows
Scenario: City, default radius and minimum price range search
	Given funda website is opened on "huur" tab
	When I fill in "Huur" search form "Vught", "+ 2 km", "€ 100", "Geen maximum"
	When  I click Search
	Then the page title will show the search result for "Amsterdam"
	When I go to funda homepage on "huur" tab
	Then I see last search as "Vught, +2 km, € 100+"

@huurFlows
Scenario: City, default radius and maximum price range search
	Given funda website is opened on "huur" tab
	When I fill in "Huur" search form "Amsterdam", "+ 2 km", "€ 0", "€ 2.000"
	When  I click Search
	Then the page title will show the search result for "Amsterdam"
	When I go to funda homepage on "huur" tab
	Then I see last search as "Amsterdam, +2 km, € 0 - € 2.000"