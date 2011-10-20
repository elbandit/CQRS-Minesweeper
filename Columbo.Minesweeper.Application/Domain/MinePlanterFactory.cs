using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Columbo.Minesweeper.Application.Domain
{
    public class MinePlanterFactory : IMinePlanterFactory
    {
        private ITilePicker _tile_picker;

        public MinePlanterFactory(ITilePicker tile_picker)
        {
            _tile_picker = tile_picker;
        }

        public IMinePlanter create(int number_of_mines_to_plant)
        {
            return new MinePlanter(_tile_picker, number_of_mines_to_plant);
        }
    }
}
