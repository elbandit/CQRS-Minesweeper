using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Columbo.Minesweeper.Application.Domain
{
    public class TileFactory : ITileFactory
    {
        public ITile create_for(Coordinate coordiante, IMinesweeper minesweeper)
        {
            return new Tile(coordiante, minesweeper);
        }
    }
}
