Feature: Trying to Play a game that has not started
	In order to avoid confusing errors
	As a player
	I want to be redirected to the start page if I navigate to the game play page

Scenario: Navigate to the game play page before starting a game
	Given I have not started a game
	When I navigate to the game play page	
	Then I should be redirected back to the start page
