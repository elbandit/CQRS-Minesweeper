using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Columbo.Minesweeper.Application.Domain
{
    public interface ITilePicker
    {
        ITile select_tile_from(IList<ITile> tiles_to_select_from);
    }
}
