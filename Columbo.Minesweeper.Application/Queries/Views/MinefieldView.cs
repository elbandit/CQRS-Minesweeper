using System;
using System.Collections.Generic;

namespace Columbo.Minesweeper.Application.Queries.Views
{
    public class MinefieldView
    {
        public Guid game_id { get; set; }  
        public bool game_won { get; set; }
        public bool game_lost { get; set; }
        public bool game_has_finished { get; set; }

        public IEnumerable<TileView> tiles { get; set; }

        public IEnumerable<IEnumerable<TileView>> tile_grid { get; set; }
    }
}