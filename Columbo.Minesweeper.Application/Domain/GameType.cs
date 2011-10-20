using System;

namespace Columbo.Minesweeper.Application.Domain
{
    public class GameOptions
    {
        public GameOptions(GameDifficulty game_difficulty, Guid game_id)
        {
            this.game_difficulty = game_difficulty;
            this.player_id = game_id;            
        }
        
        public GameDifficulty game_difficulty { get; private set; }        
        public Guid player_id { get; private set; }
    }
}