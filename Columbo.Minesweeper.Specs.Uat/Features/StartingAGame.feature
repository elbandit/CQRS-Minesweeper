Feature: Starting a game
	In order to play a game of Minesweeper
	As a player 
	I want to be able to view the minefield

Scenario: Start an easy game
	Given I have not started a game		
	When I navigate to the home page
	And click "minefield size of 9 x 9 (10 mines)"	
	Then I should see a minefield containing "9" x "9" mines all unrevealed

Scenario: Start a medium game
	Given I have not started a game		
	When I navigate to the home page
	And click "minefield size of 16 x 16 (40 mines)"	
	Then I should see a minefield containing "16" x "16" mines all unrevealed

Scenario: Start a difficult game
	Given I have not started a game		
	When I navigate to the home page
	And click "minefield size of 30 x 16 (99 mines)"
	Then I should see a minefield containing "30" x "16" mines all unrevealed