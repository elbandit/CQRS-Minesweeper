using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Columbo.Minesweeper.Application.Infrastructure;
using Columbo.Minesweeper.Application.Queries.Views;
using NHibernate.Linq;

namespace Columbo.Minesweeper.Application.Queries
{
    public class Presenter : IPresenter
    {
        public MinefieldView get_view_of_minefield_for(Guid game_id)
        {
            using (var session = SessionFactory.GetNewSession())
            {
                var minefield_view =  session.Query<MinefieldView>().Where(x => x.game_id == game_id).FirstOrDefault();

                if (minefield_view != null)
                    minefield_view.tile_grid = minefield_view.tiles.OrderBy(x => x.column).GroupBy(x => x.row).ToList<IEnumerable<TileView>>();

                return minefield_view;
            } 
        }
    }
}
