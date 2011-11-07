using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Columbo.Minesweeper.Application.Domain
{
    public class Tile : ITile 
    {
        private int? _number_of_mines_surrounding;        
        private bool _is_revealed = false;
        private bool _contains_mine = false;
        private Coordinate _located_at;        
        private int _id;
        private IMinesweeper _minesweeper;
        private readonly IGrid _grid;
        public event TileClearedEventHandler tile_cleared;
        public event EventHandler mine_exploded;

        public void set_number_of_mines_surrounding_on(IGrid grid)
        {
            set_number_of_tiles_with_mines_surrounding_this_tile_based_on(grid);
        }

        private Tile()
        {

        }

        public Tile(Coordinate location, IMinesweeper minesweeper, IGrid grid)
        {
            _located_at = location;
            _minesweeper = minesweeper;
            _grid = grid;
        }

        public void reveal()
        {
            _is_revealed = true;                         
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

        private bool have_not_checked_for_number_of_surrounding_mines()
        {
            return _number_of_mines_surrounding == null;
        }

        public bool is_at(Coordinate coordinate)
        {
            return _located_at.Equals(coordinate);
        }
    }
}
