using System;

namespace Columbo.Minesweeper.Application.Domain
{
    public interface IGameCenter
    {
        void start_a_new_game_for(Guid playerId);
        IMinesweeper get_game_for(Guid playerId);
    }
}