using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Columbo.Minesweeper.Application.Queries.Views;

namespace Columbo.Minesweeper.Application.Queries
{
    public interface IPresenter
    {
        MinefieldView get_view_of_minefield_for(Guid game_id);
    }
}
