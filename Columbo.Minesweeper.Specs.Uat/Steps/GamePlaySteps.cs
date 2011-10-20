using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Columbo.Minesweeper.Specs.Uat.Utilities;
using OpenQA.Selenium.Remote;
using TechTalk.SpecFlow;
using NUnit.Framework;
using Columbo.Minesweeper.Specs.Uat.PageObjects;
using Coypu;

namespace Columbo.Minesweeper.Specs.Uat.Steps
{
    [Binding]
    public class GamePlaySteps
    {
        [Given(@"I have not started a game")]
        public void GivenIHaveNotStartedAGame()
        {            
           // nothing to do
        }
        
        [Then(@"I should see a minefield containing ""(.*)"" x ""(.*)"" mines all unrevealed")]
        public void ThenIShouldSeeAMinefieldFullOfTiles(int row, int cols)
        {            
            var total_number_of_tiles = row * cols;

            var tiles = GamePlayPage.get_all_tiles();

            Assert.That(tiles.Count(), Is.EqualTo(total_number_of_tiles));

            foreach (var tile in tiles)
                Assert.That(tile.is_unrevealed(), Is.True); 
        }

        [When(@"click ""(.*)""")]
        public void WhenClickMinefieldSizeOf(string button_text)
        {                      
           new StartPage().click_on_the_button_labelled(button_text);
        }

        [When(@"I navigate to the game play page")]
        public void WhenINavigateToTheGamePlayPage()
        {            
            new GamePlayPage().open();            
        }

        [When(@"I navigate to the home page")]
        public void WhenINavigateToTheHomePage()
        {
            new StartPage().open();            
        }

        [Then(@"all the tiles should be revealed")]
        public void ThenAllTheTilesShouldBeRevealed()
        {
            var tiles = GamePlayPage.get_all_tiles();
            foreach( var tile in tiles)
                Assert.That(tile.is_empty(), Is.True); 
        }

        [Then(@"I should be asked whether I would like to start a new game")]
        public void IShouldBeAskedWhetherIWouldLikeToStartANewGame()
        {
            Assert.Fail();
        }

        [When(@"I click on the tile at coordinate (.*),(.*)")]
        public void WhenIClickOnTheTileAtCoordinate(int col, int row)
        {
            GamePlayPage.click_tile_at(col, row);
        }

        [Then(@"the following tiles should not be revealed:")]
        public void ThenTheFollowingTilesShouldNotBeRevealed(Table table)
        {
            var tiles = GamePlayPage.get_all_tiles();

            foreach (var tiles_to_find in table.Rows)
            {
                var tile = new { row = int.Parse(tiles_to_find["Row"]), col = int.Parse(tiles_to_find["Column"]) };

                Assert.That(tiles.First(x => x.row == tile.row && x.column == tile.col).is_unrevealed(), Is.True); 
            }
        }

        [Then(@"the following tiles should be revealed:")]
        public void ThenTheFollowingTilesShouldBeRevealed(Table table)
        {
            var tiles = GamePlayPage.get_all_tiles();

            // TODO: Map the table automatically

            foreach (var tiles_to_find in table.Rows)
            {
                var tile = new { row = int.Parse(tiles_to_find["Row"]), col = int.Parse(tiles_to_find["Column"]), number_of_mines_surrounding_by = int.Parse(tiles_to_find["NumberOfMinesSurroundedBy"]) };

                Assert.That(tiles.First(x => x.row == tile.row && x.column == tile.col).is_revealed(), Is.True);
                Assert.That(tiles.First(x => x.row == tile.row && x.column == tile.col).number_of_mines_surrounding_by(), Is.EqualTo(tile.number_of_mines_surrounding_by));
            }
        }

        [Then(@"I should see a message telling me that ""(.*)""")]
        public void IShouldSeeAMessageTellingMeThat(string message)
        {
            Assert.That(GamePlayPage.information(), Is.EqualTo(message));
        }

        [Then(@"I should see an option to resume my game")]
        public void ThenIShouldSeeAnOptionToResumeMyGame()
        {
            ScenarioContext.Current.Pending();
        }

        [When(@"I click resume")]
        public void WhenIClickResume()
        {
            ScenarioContext.Current.Pending();
        }

        [When(@"I return to the home page")]
        public void WhenIReturnToTheHomePage()
        {
            ScenarioContext.Current.Pending();
        }

        [When(@"I click ""(.*)""")]
        public void WhenIClickMinefieldSizeOf16X1640Mines()
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"I should see an option to start a new game")]
        public void ThenIShouldSeeAnOptionToStartANewGame()
        {
            ScenarioContext.Current.Pending();
        }
    }
}
