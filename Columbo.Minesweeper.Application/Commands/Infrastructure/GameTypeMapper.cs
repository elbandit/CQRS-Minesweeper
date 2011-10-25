using Columbo.Minesweeper.Application.Domain;

namespace Columbo.Minesweeper.Application.Commands.Infrastructure
{
    public class GameTypeMapper : IGameTypeMapper
    {
        public Domain.GameOptions map_from(CreateGameCommand command)
        {
            return new GameOptions(command.game_difficulty, command.player_id);
        }
    }
}
