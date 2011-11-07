using System;
using System.Collections.Generic;
using System.Linq;

namespace Columbo.Minesweeper.Application.Domain
{
    public class RandomCoordinatePicker : ICoordinatePicker
    {
        public IEnumerable<Coordinate> pick_coordinates_from(MinefieldSize minefield_size, int number_of_coordinates_to_pick)
        {
            IList<Coordinate> _coordinates = new List<Coordinate>();

            // create a list of coordinates
            populate_list_of_coordinates(minefield_size, _coordinates);

            // put in a random order
            _coordinates = _coordinates.OrderBy(a => Guid.NewGuid()).ToList<Coordinate>();

            return _coordinates.Take(number_of_coordinates_to_pick);
        }

        private void populate_list_of_coordinates(MinefieldSize minefield_size, IList<Coordinate> _coordinates)
        {
            var row_count = 0;
            while (row_count < minefield_size.rows)
            {
                var column_count = 0;
                while (column_count < minefield_size.columns)
                {
                    _coordinates.Add(new Coordinate(row_count, column_count));
                    column_count++;
                }
                row_count++;
            }
        }
    }
}
