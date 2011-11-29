using Columbo.Minesweeper.Application.Infrastructure;
using Columbo.Minesweeper.Application.Queries.Views;

namespace Columbo.Minesweeper.Application.Events
{
    public class TileRevealedHandler : IDomainEventHandler<TileRevealed>
    {
        public void handle(TileRevealed domain_event)
        {
            // save into the game view table
            using (var session = SessionFactory.GetNewSession())
            {
                using (var trans = session.BeginTransaction())
                {
                    
                    var tile = session.Get<TileView>(domain_event.tile_id);

                    tile.has_been_revealed = true;

                    if (domain_event.contains_mine)
                    {
                        tile.tile_image = "mine_exploded";
                    }
                    else
                    {
                        tile.tile_image = string.Format("revealed_surrounded_by_{0}_mines", domain_event.number_of_mines_surrounding);
                    }

                    session.Update(tile);
                   
                    trans.Commit();
                }
            }
        }

    }
}