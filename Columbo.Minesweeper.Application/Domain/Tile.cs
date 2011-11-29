using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Columbo.Minesweeper.Application.Events;

namespace Columbo.Minesweeper.Application.Domain
{
    public class Tile : ITile 
    {
        private int _number_of_mines_surrounding;        
        private bool _is_revealed = false;
        private bool _contains_mine = false;
        private readonly Guid _tile_id;
        private Coordinate _located_at;              
        private Guid _game_id;
        public event TileClearedEventHandler tile_cleared;
        public event EventHandler mine_exploded;

        public void set_number_of_mines_surrounding_on(IGrid grid)
        {
            set_number_of_tiles_with_mines_surrounding_this_tile_based_on(grid);
        }

        private Tile()
        {
        }

        public Tile(Guid tile_id, Coordinate location, Guid game_id)
        {
            _tile_id = tile_id;
            _located_at = location;
            _game_id = game_id;

            DomainEvents.raise(new TileCreated(_tile_id, _game_id, _located_at));
        }

        public void reveal()
        {
            _is_revealed = true;

            DomainEvents.raise(new TileRevealed(_tile_id, contains_mine(), _number_of_mines_surrounding));            
        }

        public bool contains_mine()
        {
            return _contains_mine;
        }

        public void plant_mine()
        {
            _contains_mine = true;
        }

        public bool is_unrevealed_with_no_mine()
        {
            return !contains_mine() && _is_revealed == false;
        }

        public bool is_surrounded_by_a_mine()
        {         
            return _number_of_mines_surrounding > 0;
        }

        private void set_number_of_tiles_with_mines_surrounding_this_tile_based_on(IGrid grid)
        {
            _number_of_mines_surrounding = 0;
            
            for (var row = _located_at.X - 1; row <= _located_at.X + 1; row++)
                for (var col = _located_at.Y - 1; col <= _located_at.Y + 1; col++)
                 {
                     var coord = new Coordinate(row, col);
                     if (!coord.Equals(this._located_at))
                         if (grid.contains_tile_at(coord))
                         {
                             if (grid.mine_on_tile_at(coord))
                                _number_of_mines_surrounding++;
                         }
                 }
        }

        public bool is_at(Coordinate coordinate)
        {
            return _located_at.Equals(coordinate);
        }
    }
}
