Feature: Revealing Tiles
	In order to identify mines
	As a player 
	I want to be able to click on a tile
	and see how many mines surround that tile

Scenario: Click a tile on a minefield that contains no mines
	Given I have started a new game	with a minefield size of 9 x 9
	And the minefield contains no mines
	When I click on the tile at coordinate 3,3
	Then all the tiles should be revealed

##Scenario: Click a tile on a minefield that contains one mine
##	Given I have started a new game	
##	And the minefield size is 9 x 9
##	And the minefield contains a mine at: 
##		| Column | Row |
##		| 3      | 3   |
##	When I click on the tile at coordinate 1,1
##	Then the tiles at the following coordinates will contain a 1
##		| Column | Row |
##		| 3      | 1   |
##		| 3      | 4   |
##		| 2      | 3   |
##		| 4      | 3   |
##	And the tile at coordinate 3,3 will remain unrevealled

##Scenario: Click on a tile that is next to a mine
##	Given I have started a new game	
##	And the minefield size is 9 x 9
##	And the minefield contains a mine at: 
##		| Column | Row |
##		| 3      | 3   |
##	When I click on the tile at coordinate 4,3	
##	Then the tiles at the following coordinates will contain a 1
##		| Column | Row |
##		| 4      | 3   |
##	And the tile at coordinate 3,3 will remain unrevealled