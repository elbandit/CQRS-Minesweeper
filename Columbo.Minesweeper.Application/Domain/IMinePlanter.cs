using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Columbo.Minesweeper.Application.Domain
{
    public interface IMinePlanter
    {
        void plant_mines_on(IGrid grid);
    }
}
