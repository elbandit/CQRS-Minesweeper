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
        public MinefieldModel get_view_of_minefield_for(Guid game_id)
        {
            using (var session = SessionFactory.GetNewSession())
            {
                return session.Query<MinefieldModel>().Where(x => x.game_id == game_id).FirstOrDefault();
            } 
        }
    }
}
