using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Columbo.Minesweeper.Application.Queries.Views
{
    public class MinefieldModel
    {
        public bool game_won { get; set; }
        public bool game_lost { get; set; }

        public bool game_has_finished()
        {
            return game_won == true || game_lost == true;
        }

        public IEnumerable<IEnumerable<TileModel>> tiles { get; set; }

        public IEnumerable<TileModel> raw_tiles { get; set; }

        public Guid game_id { get; set; }        

        public IEnumerable<IEnumerable<TileModel>> rows_of_tiles()
        {
            return raw_tiles.OrderBy(x => x.column).GroupBy(x => x.row).ToList<IEnumerable<TileModel>>();
        }
    }
}