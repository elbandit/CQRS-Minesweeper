using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Columbo.Minesweeper.Application.Domain
{
    public interface ITileFactory
    {
        ITile create_for(Coordinate coordiante, IMinesweeper minesweeper);
    }
}
