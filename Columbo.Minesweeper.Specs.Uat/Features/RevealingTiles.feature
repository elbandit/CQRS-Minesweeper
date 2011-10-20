Feature: Revealing Tiles
	In order to identify mines
	As a player 
	I want to be able to click on a tile
	and see how many mines surround that tile

Scenario: Click a tile that is next to a mine on a minefield that contains one mine
	Given I have started a new game "minefield size of 9 x 9 (10 mines)"
	And the minefield contains the following mines: 
		| Row | Column |
		| 1   | 1      |
	When I navigate to the game play page
	And I click on the tile at coordinate 0,0
	Then the following tiles should be revealed:
		| Row | Column | NumberOfMinesSurroundedBy |
		| 0   | 0      | 1                         |
	And the following tiles should not be revealed:
		| Row | Column |
		| 1   | 1      |
		| 0   | 1      | 
		| 0   | 2      | 
		| 1   | 0      | 
		| 1   | 2      | 
		| 2   | 0      | 
		| 2   | 1      | 
		| 2   | 2      | 

Scenario: Click a tile that is not next to a minefield that contains one mine
	Given I have started a new game "minefield size of 9 x 9 (10 mines)"
	And the minefield contains the following mines: 
		| Row | Column |
		| 2   | 2      |
	When I navigate to the game play page
	And I click on the tile at coordinate 0,0
	Then the following tiles should be revealed:
		| Row | Column | NumberOfMinesSurroundedBy |
		| 0   | 0      | 0                         |
		| 0   | 1      | 0                         |
		| 0   | 2      | 0                         |
		| 1   | 0      | 0                         |
		| 1   | 1      | 1                         |
		| 1   | 2      | 1                         |
		| 2   | 0      | 0                         |
		| 2   | 1      | 1                         |
	And the following tiles should not be revealed:
		| Row | Column |
		| 2   | 2      | 