Feature: Winning A Game
	In order to win a game
	As a player
	I need to remove all tiles that aren't mines

Scenario: Reveal all tiles that aren't mines and win the game
	Given I have started a new game "minefield size of 9 x 9 (10 mines)"
	And the minefield contains the following mines: 
		| Row | Column |
		| 2   | 2      |
	And the following tiles are surrounded by mines:
		| Row | Column | NumberOfMinesSurroundedBy |
		| 1   | 1      | 1                         |
		| 1   | 2      | 1                         |
		| 2   | 1      | 1                         |
	When I navigate to the game play page
	And I click on the tile at coordinate 0,0
	Then the following tiles should be revealed:
		| Row | Column | NumberOfMinesSurroundedBy |
		| 0   | 0      | 0                         |
		| 1   | 1      | 1                         |
		| 0   | 1      | 0                         |
		| 0   | 2      | 0                         |
		| 1   | 0      | 0                         |
		| 1   | 2      | 1                         |
		| 2   | 0      | 0                         |
		| 2   | 1      | 1                         |
	And the following tiles should not be revealed:
		| Row | Column |		
		| 2   | 2      | 
	And I should see a message telling me that "You have won!"
	And I should see a button labelled "Start New Game"	
