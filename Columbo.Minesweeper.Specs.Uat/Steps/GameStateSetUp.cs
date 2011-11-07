using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Columbo.Minesweeper.Specs.Uat.Utilities;
using TechTalk.SpecFlow;
using Columbo.Minesweeper.Specs.Uat.PageObjects;

namespace Columbo.Minesweeper.Specs.Uat.Steps
{
    [Binding]
    public class GameStateSetUp
    {        
        [Given(@"I have started a new game ""(.*)""")]
        public void GivenIHaveStartedANewGame(string game_type)
        {            
            new StartPage().open().click_on_the_button_labelled(game_type);            
        }

        [Given(@"the minefield contains the following mines:")]
        public void GivenTheMinefieldContainsTheFollowingMines(Table table)
        {
            var game_id = new StartPage().get_player_identifier();
            
            Database.clear_mines_for_game_with_id_of(game_id);

            // TODO: Auto map with table

            foreach (var row in table.Rows)
            {
                var mine_row = int.Parse(row["Row"]);
                var mine_column = int.Parse(row["Column"]);

                Database.add_mine_to_game(game_id, mine_row, mine_column);
            }
        }

        [Given(@"the following tiles are surrounded by mines:")]
        public void GivenTheFollowingTilesAreSurroundedByMines(Table table)
        {
            var game_id = new StartPage().get_player_identifier();
            
            // TODO: Auto map with table

            foreach (var row in table.Rows)
            {
                var mine_row = int.Parse(row["Row"]);
                var mine_column = int.Parse(row["Column"]);
                var surrounded_by = int.Parse(row["NumberOfMinesSurroundedBy"]);

                Database.set_number_of_mines_surrounding_tile(game_id, mine_row, mine_column, surrounded_by);
            }
        }
    }
}
