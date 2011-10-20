using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Columbo.Minesweeper.Application.Domain
{
    public class MinePlanter : IMinePlanter
    {
        private int _number_of_mines_to_plant;
        private ITilePicker _random_tile_picker;

        public MinePlanter(ITilePicker random_tile_picker, int number_of_mines_to_plant)
        {
            _number_of_mines_to_plant = number_of_mines_to_plant;
            _random_tile_picker = random_tile_picker;
        }

        public void plant_mines_on(IGrid grid)
        {
            var number_of_mines_planted = 0;

            while (number_of_mines_planted < _number_of_mines_to_plant)
            {
                grid.plant_mine_using(_random_tile_picker);

                number_of_mines_planted++;
            }
        }
    }
}
