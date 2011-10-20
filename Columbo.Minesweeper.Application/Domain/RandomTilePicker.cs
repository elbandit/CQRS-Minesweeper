using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Columbo.Minesweeper.Application.Domain
{
    public class RandomTilePicker : ITilePicker
    {
        public ITile select_tile_from(IList<ITile> tiles_to_select_from)
        {
            var random_number = new Random().Next(tiles_to_select_from.Count -1);

            if (!tiles_to_select_from[random_number].contains_mine())
                return tiles_to_select_from[random_number];
            else
                return select_tile_from(tiles_to_select_from);
        }
    }
}
