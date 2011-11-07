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

        [Then(@"I should be redirected back to the start page")]
        public void ThenIShouldBeRedirectedBackToTheStartPage()
        {
            Assert.That(new StartPage().is_displayed(), Is.True);
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
            Assert.That(new GamePlayPage().message_displayed_with_text_of(message), Is.True);
        }

        [Then(@"I should see an option to resume my game")]
        public void ThenIShouldSeeAnOptionToResumeMyGame()
        {
            Assert.That(new GamePlayPage().resume_game_button_showing(), Is.True);
        }

        [When(@"I click resume")]
        public void WhenIClickResume()
        {
            new GamePlayPage().click_resume_game_button();
        }

        [When(@"I return to the home page")]
        public void WhenIReturnToTheHomePage()
        {
            new GamePlayPage().return_to_start_page();
        }

        [When(@"I click ""(.*)""")]
        public void WhenIClickOnTheButton(string button_text)
        {
            new StartPage().click_on_the_button_labelled(button_text);
        }

        [Then(@"I should see a button labelled ""(.*)""")]
        public void ThenIShouldSeeAButtonLabelled(string button_label)
        {
            Assert.That(new GamePlayPage().contains_a_button_with_a_label_of(button_label), Is.True);
        }
    }
}
