using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Columbo.Minesweeper.Application.Domain
{
    public delegate void TileClearedEventHandler(object sender, TileClearedEventArgs e);

    public class TileClearedEventArgs : EventArgs
    {
        public Coordinate coordinate { get; set; }
    }
}
