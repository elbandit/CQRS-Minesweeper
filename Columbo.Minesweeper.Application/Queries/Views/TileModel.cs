using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Columbo.Minesweeper.Application.Queries.Views
{
    public class TileModel
    {
        private int tile_id { get; set; }
        public int row { get; set; }
        public int column { get; set; }
        public bool is_revealed { get; set; }
        public int number_of_mines_surrounding { get; set; }
        public bool contains_mine { get; set; }  
    }
}