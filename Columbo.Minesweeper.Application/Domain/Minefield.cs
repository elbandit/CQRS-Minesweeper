using System;
using System.Linq;

namespace Columbo.Minesweeper.Application.Domain
{
    public class Minefield : IMinefield
    {
        private readonly IGrid _grid;           
        public event EventHandler minefield_cleared;
        public event EventHandler mine_exploded;
        public event EventHandler tile_cleared;

        private IMineClearer _mine_clearer;

        private Minefield()
        {
            _mine_clearer = new MineClearer();
        }
        
        public Minefield(IGrid grid, IMineClearer mine_clearer)
        {
            _grid = grid;
            _mine_clearer = mine_clearer;
        }

        public void reveal_tile_at(Coordinate coordinate)
        {                               
            _grid.reveal_tile_at(coordinate);

            if (_grid.mine_on_tile_at(coordinate))
                mine_exploded(this, new EventArgs());
            else
                clear_tiles_surrounding_tile_at(coordinate); 
        }

        private void clear_tiles_surrounding_tile_at(Coordinate coordinate)
        {
            if (!_grid.mines_near_tile_at(coordinate))
            {
                _mine_clearer.reveal_all_tiles_near_mines_surrounding_tile_at(coordinate, this._grid);
            }

            if (!_grid.contains_unrevealed_tiles_with_no_mines())
            {
                on_minefield_cleared(new EventArgs());
            }
        }
       
        private void on_minefield_cleared(EventArgs e)
        {
            if (minefield_cleared != null)
                minefield_cleared(this, e);
        }
    }
}