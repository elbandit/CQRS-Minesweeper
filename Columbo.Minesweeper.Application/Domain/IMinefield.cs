using System.Collections.Generic;
using System.Linq;
using System.Text;
using System;

namespace Columbo.Minesweeper.Application.Domain
{
    public interface IMinefield
    {
        event EventHandler mine_exploded;
        event EventHandler minefield_cleared;

        void reveal_tile_at(Coordinate coordinate);      
    }
}
