using Columbo.Minesweeper.Application.Domain;

namespace Columbo.Minesweeper.Application.Commands.Infrastructure
{
    public interface IGameTypeMapper
    {
        GameOptions map_from(CreateGameCommand command);
    }
}
