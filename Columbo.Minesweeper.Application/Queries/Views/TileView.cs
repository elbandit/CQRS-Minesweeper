using System;

namespace Columbo.Minesweeper.Application.Queries.Views
{
    public class TileView
    {
        public Guid tile_id { get; set; }
        public Guid game_id { get; set; }
        public int row { get; set; }
        public int column { get; set; }
        public bool has_been_revealed { get; set; }
        public string tile_image { get; set; }

// revealed_empty, not_revealed, revealed_surrounded_by_X_mines, mine_exploded
    }
}