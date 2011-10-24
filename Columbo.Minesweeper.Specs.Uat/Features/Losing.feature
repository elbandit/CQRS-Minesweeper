Feature: Losing A Game
	In order to lose a game
	As a player
	I need to reveal a tile that contains a mine

Scenario: Reveal all tiles that aren't mines and win the game
	Given I have started a new game "minefield size of 9 x 9 (10 mines)"
	And the minefield contains the following mines: 
		| Row | Column |
		| 2   | 2      |
	When I navigate to the game play page
	And I click on the tile at coordinate 2,2	
	Then I should see a message telling me that "You have lost!"
	And I should see a button labelled "Start New Game"
