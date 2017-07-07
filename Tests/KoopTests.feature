Feature: koop Tests

Background: 
	Given browser local data is cleared
	And there is internet connection

@koopFlows
Scenario: City, default radius and default price search
	Given funda website is opened on "koop" tab
	When I fill in "Koop" search form "Amsterdam", "+ 0 km", "€ 0", "Geen maximum"
	And  I click Search
	Then the page title will show the search result for "Amsterdam"
	When I go to funda homepage on "koop" tab
	Then I see last search as "Amsterdam"

@koopFlows
Scenario: City, radius and default price search
	Given funda website is opened on "koop" tab
	When I fill in "Koop" search form "Vught", "+ 5 km", "€ 0", "Geen maximum"
	When  I click Search
	Then the page title will show the search result for "Amsterdam"
	When I go to funda homepage on "koop" tab
	Then I see last search as "Vught, +5 km"

@koopFlows
Scenario: City, radius and price range search
	Given funda website is opened on "koop" tab
	When I fill in "Koop" search form "Vught", "+ 5 km", "€ 400.000", "€ 1.250.000"
	When  I click Search
	Then the page title will show the search result for "Amsterdam"
	When I go to funda homepage on "koop" tab
	Then I see last search as "Vught, +5 km, € 400.000 - € 1.250.000"

@koopFlows
Scenario: City, radius and minimum price range search
	Given funda website is opened on "koop" tab
	When I fill in "Koop" search form "Amsterdam", "+ 2 km", "€ 400.000", "Geen maximum"
	When  I click Search
	Then the page title will show the search result for "Amsterdam"
	When I go to funda homepage on "koop" tab
	Then I see last search as "Amsterdam, +2 km, € 400.000+"

@koopFlows
Scenario: City, radius and maximum price range search
	Given funda website is opened on "koop" tab
	When I fill in "Koop" search form "Amsterdam", "+ 2 km", "€ 0", "€ 400.000"
	When  I click Search
	Then the page title will show the search result for "Amsterdam"
	When I go to funda homepage on "koop" tab
	Then I see last search as "Amsterdam, +2 km, € 0 - € 400.000"

@koopFlows
Scenario: City, default radius and price range search
	Given funda website is opened on "koop" tab
	When I fill in "Koop" search form "Amsterdam", "+ 0 km", "€ 400.000", "€ 1.250.000"
	When  I click Search
	Then the page title will show the search result for "Amsterdam"
	When I go to funda homepage on "koop" tab
	Then I see last search as "Amsterdam, € 400.000 - € 1.250.000"

@koopFlows
Scenario: City, default radius and minimum price range search
	Given funda website is opened on "koop" tab
	When I fill in "Koop" search form "Vught", "+ 2 km", "€ 400.000", "Geen maximum"
	When  I click Search
	Then the page title will show the search result for "Amsterdam"
	When I go to funda homepage on "koop" tab
	Then I see last search as "Vught, +2 km, € 400.000+"

@koopFlows
Scenario: City, default radius and maximum price range search
	Given funda website is opened on "koop" tab
	When I fill in "Koop" search form "Amsterdam", "+ 2 km", "€ 0", "€ 400.000"
	When  I click Search
	Then the page title will show the search result for "Amsterdam"
	When I go to funda homepage on "koop" tab
	Then I see last search as "Amsterdam, +2 km, € 0 - € 400.000"