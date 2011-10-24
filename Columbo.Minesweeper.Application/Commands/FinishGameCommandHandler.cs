using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Columbo.Minesweeper.Application.Commands
{
    public class FinishGameCommandHandler : ICommandHandler<FinishGameCommand>
    {
        private IGameRepository _game_repository;

        public FinishGameCommandHandler(IGameRepository game_repository)
        {
            _game_repository = game_repository;
        }

        public void handle(FinishGameCommand command)
        {
            var game = _game_repository.get_by(command.player_id);

            _game_repository.delete(game);
        }
    }
}
