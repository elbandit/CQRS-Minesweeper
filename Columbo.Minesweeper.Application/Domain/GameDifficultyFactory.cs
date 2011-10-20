using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Columbo.Minesweeper.Application.Domain
{
    public class GameDifficultyFactory
    {
        public GameDifficulty find_game_difficulty_by(string difficulty_name)
        { 
            GameDifficulty game_difficulty;

            switch (difficulty_name)
            {
                case  "easy" :
                    game_difficulty = new GameDifficulty(9, 9, 10);
                    break;
                case "medium":
                    game_difficulty = new GameDifficulty(16, 16, 40);
                    break;
                case "hard":
                    game_difficulty = new GameDifficulty(30, 16, 99);
                    break;
                default :
                    game_difficulty = new GameDifficulty(9, 9, 10);
                    break;
            }

            return game_difficulty;
        }
    }
}
