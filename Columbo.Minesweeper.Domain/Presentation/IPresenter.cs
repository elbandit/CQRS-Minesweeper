using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Columbo.Minesweeper.Domain.Presentation.Views;

namespace Columbo.Minesweeper.Domain.Presentation
{
    public interface IPresenter
    {
        MinefieldModel get_view_of_minefield();
    }
}
