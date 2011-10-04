using System;

namespace Columbo.Minesweeper.Application.Domain
{
    public class Minefield : IMinefield
    {
        private IGrid _grid;

        public Minefield(IGrid grid)
        {
            _grid = grid;
            // add mine planter
        }

        public void reveal_tile_at(Coordinate coordinate)
        {
            var selected_tile = _grid.get_tile_at(coordinate);

            selected_tile.reveal();

            reveal_all_tiles_near_mines_surrounding_tile_at(coordinate);
        }

        private void reveal_all_tiles_near_mines_surrounding_tile_at(Coordinate coordinate)
        {
            var selected_tile = _grid.get_tile_at(coordinate);

            selected_tile.reveal();

            // if is next to a mine display the number and stop looking.

            for (var row = coordinate.X - 1; row <= coordinate.X + 1; row++)
                for (var col = coordinate.Y - 1; col <= coordinate.Y + 1; col++)
                    if (_grid.contains(Coordinate.new_coord(row, col)) && !_grid.get_tile_at(coordinate).contains_mine())
                    {
                        // Its on the grid and doesn't contain a mine..

                        // check to see how many mines are next to it. IF at least one don't keep looking.
                    }
        }
    }
}