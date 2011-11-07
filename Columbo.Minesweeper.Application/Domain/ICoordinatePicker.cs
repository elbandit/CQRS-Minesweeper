using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Columbo.Minesweeper.Application.Domain
{
    public interface ICoordinatePicker
    {
        IEnumerable<Coordinate> pick_coordinates_from(MinefieldSize minefield_size, int number_of_mines);
    }
}
