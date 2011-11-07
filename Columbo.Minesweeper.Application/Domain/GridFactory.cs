using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Columbo.Minesweeper.Application.Domain
{
    public class GridFactory : IGridFactory
    {
        private ITileFactory _tile_factory;

        public GridFactory(ITileFactory tile_factory)
        {
            _tile_factory = tile_factory;
        }

        public IGrid create_grid_with_size_of(MinefieldSize minefield_size, IMinesweeper minesweeper)
        {
            var grid = new Grid(_tile_factory, minefield_size, minesweeper);
           
            return grid;
        }
    }
}
