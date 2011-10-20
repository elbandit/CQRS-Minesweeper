using System;

namespace Columbo.Minesweeper.Application.Domain
{
    public interface IMinesweeperFactory
    {
        IMinesweeper create_game_with(GameOptions game_options);
    }
}