using System;
using Columbo.Minesweeper.Application.Domain;

namespace Columbo.Minesweeper.Application.Events
{
    public class TileRevealed : IDomainEvent
    {
        public Guid tile_id { get; private set; }        
        public bool contains_mine { get; private set; }
        public int number_of_mines_surrounding { get; private set; }

        public TileRevealed(Guid tile_id, bool contains_mine, int number_of_mines_surrounding)
        {
            this.tile_id = tile_id;
            this.contains_mine = contains_mine;
            this.number_of_mines_surrounding = number_of_mines_surrounding;
        }
    }
}