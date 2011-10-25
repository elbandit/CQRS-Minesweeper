using System;
using Columbo.Minesweeper.Application.Commands.Infrastructure;
using Columbo.Minesweeper.Application.Domain;

namespace Columbo.Minesweeper.Application.Commands
{
    public class CreateGameCommand : ICommand
    {
        public Guid player_id { get; set; }
        public GameDifficulty game_difficulty { get; set; }

        public override string ToString()
        {
            return string.Format("player_id: {0}", player_id);
        }        
    }
}
