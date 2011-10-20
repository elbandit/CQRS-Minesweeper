using Columbo.Minesweeper.Application.Domain;

namespace Columbo.Minesweeper.Application.Commands
{
    public class RevealTileHandler : ICommandHandler<RevealTileCommand>
    {
        private IGameRepository _game_repository;

        public RevealTileHandler(IGameRepository game_repository)
        {
            _game_repository = game_repository;
        }

        public void handle(RevealTileCommand command)
        {
            var game = _game_repository.get_by(command.player_id);

            game.reveal_tile_at(command.coordinate);

            _game_repository.save(game);
        }
    }
}