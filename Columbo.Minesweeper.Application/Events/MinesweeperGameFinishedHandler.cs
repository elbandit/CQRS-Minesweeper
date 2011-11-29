using System.Collections.Generic;
using Columbo.Minesweeper.Application.Domain;
using Columbo.Minesweeper.Application.Infrastructure;
using Columbo.Minesweeper.Application.Queries.Views;
using NHibernate.Linq;

namespace Columbo.Minesweeper.Application.Events
{
    public class MinesweeperGameFinishedHandler : IDomainEventHandler<MinesweeperGameFinished>
    {
        public void handle(MinesweeperGameFinished domain_event)
        {              
            using (var session = SessionFactory.GetNewSession())
            {
                using (var trans = session.BeginTransaction())
                {
                    var game = session.Get<MinefieldView>(domain_event.game_id);

                    session.Delete(game);

                    trans.Commit();
                }
            } 
        }
    }
}