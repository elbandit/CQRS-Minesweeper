using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
            // clear db?
        }

        [Given(@"that the default minefield size is 9 x 9")]
        public void GivenThatTheDefaultMinefieldSizeIs9X9()
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"I should see a minefield 3 x 3 full of tiles all unrevealed")]
        public void ThenIShouldSeeAMinefieldFullOfTiles()
        {
            Assert.That(GamePlayPage.no_of_tiles(), Is.EqualTo(9));

            var tiles = GamePlayPage.get_all_tiles();
            foreach (var tile in tiles)
                Assert.That(tile.is_unrevealed(), Is.True); 
        }        

        [When(@"click start a new game with a minefield size of 3 x 3")]
        public void WhenClickStartANewGame()
        {
            StartPage.start_game_with_minefield_of_9x9();
        }

        [When(@"I navigate to the game play page")]
        public void WhenINavigateToTheGamePlayPage()
        {
            Assert.That(StartPage.title, Is.EqualTo("Welcome to Columbo's Minesweeper!"));
        }

        [Given(@"I have started a new game\twith a minefield size of 9 x 9")]
        public void GivenIHaveStartedANewGameWithAMinefieldSizeOf9X9()
        {
            StartPage.start_game_with_minefield_of_9x9();
        }

        [Given(@"the minefield contains no mines")]
        public void GivenTheMinefieldContainsNoMines()
        {
            // clear the db of mines
        }

        [Then(@"all the tiles should be revealed")]
        public void ThenAllTheTilesShouldBeRevealed()
        {
            var tiles = GamePlayPage.get_all_tiles();
            foreach( var tile in tiles)
                Assert.That(tile.is_empty(), Is.True); 
        }

        [When(@"I click on the tile at coordinate (.*),(.*)")]
        public void WhenIClickOnTheTileAtCoordinate(int col, int row)
        {
            GamePlayPage.click_tile_at(col, row);
        }
    }
}
