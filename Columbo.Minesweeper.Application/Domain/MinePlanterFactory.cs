using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Columbo.Minesweeper.Application.Domain
{
    public class MinePlanterFactory : IMinePlanterFactory
    {
        private ICoordinatePicker _coordinatePicker;

        public MinePlanterFactory(ICoordinatePicker coordinate_picker)
        {
            _coordinatePicker = coordinate_picker;
        }

        public IMinePlanter create_for(GameDifficulty game_difficulty)
        {
            return new MinePlanter(_coordinatePicker, game_difficulty);
        }
    }
}
