using System;
using Columbo.Minesweeper.Application.Domain;

namespace Columbo.Minesweeper.Application.Events
{
    public class MinesweeperGameStarted : IDomainEvent
    {       
        public MinesweeperGameStarted(Guid game_id, MinefieldSize minefield_size)
        {
            this.game_id = game_id;
            this.minefield_size = minefield_size;
        }

        public Guid game_id { get; private set; }
        public MinefieldSize minefield_size { get; private set; }
    }
}