using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Columbo.Minesweeper.Ui.Web.Controllers
{
    public interface IPlayerIdentifier
    {
        Guid get_player_identifier();
        void set_player_identifier(Guid player_id);
        bool has_indenitfier();
    }
}