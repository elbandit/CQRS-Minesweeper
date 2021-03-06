﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Columbo.Minesweeper.Application.Domain
{
    public interface IGridFactory
    {
        IGrid create_grid_with_size_of(MinefieldSize minefield_size, Guid game_id);
    }
}
