using System;

namespace Columbo.Minesweeper.Application.Events
{
    public class MinesweeperGameLost : IDomainEvent
    {
        public MinesweeperGameLost(Guid game_id)
        {
            this.game_id = game_id;
        }

        public Guid game_id { get; private set; }
    }
}