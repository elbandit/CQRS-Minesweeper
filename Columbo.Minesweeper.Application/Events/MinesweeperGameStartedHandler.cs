using System.Collections.Generic;
using Columbo.Minesweeper.Application.Domain;
using Columbo.Minesweeper.Application.Infrastructure;
using Columbo.Minesweeper.Application.Queries.Views;

namespace Columbo.Minesweeper.Application.Events
{
    public class MinesweeperGameStartedHandler : IDomainEventHandler<MinesweeperGameStarted>
    {

        public void handle(MinesweeperGameStarted domain_event)
        {
            // save into the game view table
            var tiles = create_grid(domain_event);

            var game = new MinefieldView()
                           {game_id = domain_event.game_id, game_lost = false, game_won = false, tiles = tiles};

            // save game
            using (var session = SessionFactory.GetNewSession())
            {
                using (var trans = session.BeginTransaction())
                {
                    session.Save(game);

                    trans.Commit();
                }
            } 
        }

        private IEnumerable<TileView> create_grid(MinesweeperGameStarted domain_event)
        {
            var tiles = new List<TileView>();

            var row_count = 0;
            while (row_count < domain_event.minefield_size.rows)
            {
                var column_count = 0;
                while (column_count < domain_event.minefield_size.columns)
                {
                    tiles.Add(new TileView() { column = column_count, row = row_count, tile_image = "not_revealed", game_id = domain_event.game_id });
                    column_count++;
                }
                row_count++;
            }

            return tiles;
        }
    }
}