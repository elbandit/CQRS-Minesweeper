using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Columbo.Minesweeper.Application.Domain;

namespace Columbo.Minesweeper.Application.Commands
{
    public class GameTypeMapper : IGameTypeMapper
    {
        public Domain.GameOptions map_from(CreateGameCommand command)
        {
            return new GameOptions(command.game_difficulty, command.player_id);
        }
    }
}
