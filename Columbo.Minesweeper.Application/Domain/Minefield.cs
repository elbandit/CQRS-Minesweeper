using System;
using System.Collections.Generic;

namespace Columbo.Minesweeper.Application.Domain
{
    public class Minefield : IMinefield
    {
        private IGrid _grid;
        private IList<Coordinate> coordinates_checked = new List<Coordinate>();
               
        //public event MinefieldClearHandler minefield_cleared;        
        //public event MineExplodedHandler mine_exploded;

        public event EventHandler minefield_cleared;
        public event EventHandler mine_exploded;

        private Minefield()
        { }

        public Minefield(IGrid grid)
        {
            _grid = grid;            
        }

        public void reveal_tile_at(Coordinate coordinate)
        {            
            _grid.reveal_tile_at(coordinate);

            if (_grid.mine_on_tile_at(coordinate))
                on_mine_exploded(new EventArgs());
            else
            {
                if (!_grid.mines_surrounding_tile_at(coordinate))
                {
                    reveal_all_tiles_near_mines_surrounding_tile_at(coordinate);
                }

                if (!_grid.contains_unrevealed_tiles_with_no_mines())
                {
                    on_minefield_cleared(new EventArgs());
                }
            }
        }

        private void on_mine_exploded(EventArgs e)           
        {
            if (mine_exploded != null)
                mine_exploded(this, e);
        }

        private void on_minefield_cleared(EventArgs e)
        {
            if (minefield_cleared != null)
                minefield_cleared(this, e);
        }

        private void reveal_all_tiles_near_mines_surrounding_tile_at(Coordinate coordinate)
        {                                   
            _grid.reveal_tile_at(coordinate);

            for (var row = coordinate.X - 1; row <= coordinate.X + 1; row++)
                for (var col = coordinate.Y - 1; col <= coordinate.Y + 1; col++)
                {
                    var coordinate_of_tile_under_inspection = Coordinate.new_coord(row, col);

                    if (!coordinate_of_tile_under_inspection.Equals(coordinate))
                    {
                        if (!has_already_been_checked(coordinate_of_tile_under_inspection))
                        {
                            coordinates_checked.Add(coordinate_of_tile_under_inspection); 

                            if (_grid.contains_tile_at(coordinate_of_tile_under_inspection) &&
                                !_grid.mine_on_tile_at(coordinate_of_tile_under_inspection))
                            {                                
                                if (_grid.mines_surrounding_tile_at(coordinate_of_tile_under_inspection))
                                {
                                    _grid.reveal_tile_at(coordinate_of_tile_under_inspection);
                                }
                                else
                                {
                                    reveal_all_tiles_near_mines_surrounding_tile_at(coordinate_of_tile_under_inspection);
                                }
                            }
                        }
                    }
                }
        }

        private bool has_already_been_checked(Coordinate coordinate)
        {
            return coordinates_checked.Contains(coordinate);
        }

        public void plant_mines_with(IMinePlanter mine_planter)
        {
            mine_planter.plant_mines_on(this._grid);
        }
    }
}