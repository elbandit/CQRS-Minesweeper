using Columbo.Minesweeper.Application.Infrastructure;
using Columbo.Minesweeper.Application.Queries.Views;

namespace Columbo.Minesweeper.Application.Events
{
    public class TileCreatedHandler : IDomainEventHandler<TileCreated>
    {
        public void handle(TileCreated domain_event)
        {
            // save into the game view table
            using (var session = SessionFactory.GetNewSession())
            {
                using (var trans = session.BeginTransaction())
                {
                    var tile = new TileView();
                    tile.row = domain_event.coordinate.X;
                    tile.column = domain_event.coordinate.Y;

                    tile.game_id = domain_event.game_id;
                    tile.tile_id = domain_event.id;
                    tile.tile_image = "not_revealed";
                    session.Save(tile);
                                     
                    trans.Commit();
                }
            }
        }

    }
}