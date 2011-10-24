Feature: Resuming A Game
	In order to complete the game in more than one sitting
	As a player
	I want to be able to resume my unfinished game

Scenario: Resuming a game
	Given I have started a new game "minefield size of 9 x 9 (10 mines)"		
	And the minefield contains the following mines: 
		| Row | Column |
		| 0   | 1      |
	When I navigate to the game play page
	And I click on the tile at coordinate 0,0
	Then the following tiles should be revealed:
		| Row | Column | NumberOfMinesSurroundedBy |
		| 0   | 0      | 1                         |
	When I return to the home page
	Then I should see an option to resume my game
	When I click resume
	Then the following tiles should be revealed:
		| Row | Column | NumberOfMinesSurroundedBy |
		| 0   | 0      | 1                         |

Scenario: Start a new game rather than finishing a current game	
	Given I have started a new game "minefield size of 9 x 9 (10 mines)"		
	And the minefield contains the following mines: 
		| Row | Column |
		| 0   | 1      |
	When I navigate to the game play page
	And I click on the tile at coordinate 0,0
	Then the following tiles should be revealed:
		| Row | Column | NumberOfMinesSurroundedBy |
		| 0   | 0      | 1                         |
	When I return to the home page	
	When I click "minefield size of 16 x 16 (40 mines)"	
	Then I should see a minefield containing "16" x "16" mines all unrevealed
