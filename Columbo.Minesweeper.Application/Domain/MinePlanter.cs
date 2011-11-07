using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Columbo.Minesweeper.Application.Domain
{
    public class MinePlanter : IMinePlanter
    {
        private readonly GameDifficulty _game_difficulty;
        private readonly ICoordinatePicker _random_coordinate_picker;

        public MinePlanter(ICoordinatePicker random_coordinate_picker, GameDifficulty game_difficulty)
        {
            _game_difficulty = game_difficulty;
            _random_coordinate_picker = random_coordinate_picker;
        }

        public void plant_mines_on(IGrid grid)
        {
            var coordinates = _random_coordinate_picker.pick_coordinates_from(_game_difficulty.minefield_size, _game_difficulty.number_of_mines);

            foreach(var coordinate in coordinates)
                grid.plant_mine_at(coordinate);           
        }
    }
}
