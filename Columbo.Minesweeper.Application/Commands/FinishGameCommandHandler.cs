using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Columbo.Minesweeper.Application.Commands.Infrastructure;
using Columbo.Minesweeper.Application.Events;

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

            if (game != null)
            {
                _game_repository.delete(game);

                DomainEvents.raise(new MinesweeperGameFinished(command.player_id));
            }
        }
    }
}
