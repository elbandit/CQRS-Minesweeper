using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Columbo.Minesweeper.Application.Events
{
    public class MinesweeperGameWon : IDomainEvent 
    {
        public MinesweeperGameWon(Guid game_id)
        {
            this.game_id = game_id;
        }

        public Guid game_id { get; private set; }
    }
}
