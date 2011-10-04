using System;
using Columbo.Minesweeper.Application.Domain;

namespace Columbo.Minesweeper.Application.Commands
{
    public class RevealTileHandler : ICommandHandler<RevealTileCommand>
    {
        private IGameCenter _game_center;

        public RevealTileHandler(IGameCenter game_center)
        {
            _game_center = game_center;
        }

        public void handle(RevealTileCommand command)
        {
            var game = _game_center.get_game_for(command.player_id);

            game.reveal_tile_at(command.coordinate);
        }
    }
}