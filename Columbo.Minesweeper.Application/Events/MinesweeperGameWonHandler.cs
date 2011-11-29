using Columbo.Minesweeper.Application.Infrastructure;
using Columbo.Minesweeper.Application.Queries.Views;

namespace Columbo.Minesweeper.Application.Events
{
    public class MinesweeperGameWonHandler : IDomainEventHandler<MinesweeperGameWon>
    {
        public void handle(MinesweeperGameWon domain_event)
        {
            using (var session = SessionFactory.GetNewSession())
            {
                using (var trans = session.BeginTransaction())
                {
                    var game = session.Get<MinefieldView>(domain_event.game_id);

                    game.game_won = true;

                    session.Update(game);

                    trans.Commit();
                }
            }
        }
    }
}