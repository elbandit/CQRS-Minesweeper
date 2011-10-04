using System.Collections.Generic;
using System.Linq;
using System.Text;
using Columbo.Minesweeper.Domain.Model;

namespace Columbo.Minesweeper.Domain.Commands
{
    public class CreateNewGameHandler : ICommandHandler<CreateGameCommand>
    {
        private IGameCenter _game_center;

        public CreateNewGameHandler(IGameCenter game_center)
        {
            _game_center = game_center;
        }

        public void handle(CreateGameCommand command)
        {
            // validate command

            // create new game and save
            _game_center.start_a_new_game_for(command.player_id);
        }
    }
}
