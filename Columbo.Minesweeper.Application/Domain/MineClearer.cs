using System.Collections.Generic;

namespace Columbo.Minesweeper.Application.Domain
{
    public class MineClearer : IMineClearer
    {
        private IList<Coordinate> coordinates_checked = new List<Coordinate>(); 


        public void reveal_all_tiles_near_mines_surrounding_tile_at(Coordinate coordinate, IGrid _grid)
        {            
            // minefield.reveal

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
                                _grid.reveal_tile_at(coordinate_of_tile_under_inspection);

                                if (!_grid.mines_near_tile_at(coordinate_of_tile_under_inspection))
                                {
                                    reveal_all_tiles_near_mines_surrounding_tile_at(coordinate_of_tile_under_inspection, _grid);
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
    }
}