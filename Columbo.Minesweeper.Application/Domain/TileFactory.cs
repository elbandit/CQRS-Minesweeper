using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Columbo.Minesweeper.Application.Domain
{
    public class TileFactory : ITileFactory
    {
        public ITile create_for(Coordinate coordiante, Guid game_id)
        {
            return new Tile(Guid.NewGuid(), coordiante, game_id);
        }
    }
}
