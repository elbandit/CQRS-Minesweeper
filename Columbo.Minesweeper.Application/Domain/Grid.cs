using System;
using System.Linq;
using System.Collections.Generic;
using Columbo.Minesweeper.Application.Events;

namespace Columbo.Minesweeper.Application.Domain
{
    // Grid is a simple wrapper over a collection
    public class Grid : IGrid
    {
        private IList<ITile> _tiles;
               
        private Grid()
        {

        }

        public Grid(ITileFactory tile_factory, MinefieldSize minefield_size, Guid game_id)
        {
            create_grid(minefield_size, tile_factory, game_id);
        }

        private void create_grid(MinefieldSize minefield_size, ITileFactory tile_factory, Guid game_id)
        {
            _tiles = new List<ITile>();

            var row_count = 0;
            while (row_count < minefield_size.rows)
            {
                var column_count = 0;
                while (column_count < minefield_size.columns)
                {
                    _tiles.Add(tile_factory.create_for(new Coordinate(row_count, column_count),game_id));
                    column_count++;
                }
                row_count++;
            }
        }

        public bool mine_on_tile_at(Coordinate coordinate)
        {
            return tile_at(coordinate).contains_mine();
        }

        public void reveal_tile_at(Coordinate coordinate)
        {
            tile_at(coordinate).reveal();            
        }

        public bool contains_tile_at(Coordinate coordinate)
        {
            return _tiles.Where(x => x.is_at(coordinate)).FirstOrDefault() != null;
        }

        public bool contains_unrevealed_tiles_with_no_mines()
        {
            return _tiles.Where(x => x.is_unrevealed_with_no_mine()).Count() > 0;
        }

        public bool mines_near_tile_at(Coordinate coordinate)
        {
            return tile_at(coordinate).is_surrounded_by_a_mine();
        }

        public void plant_mine_at(Coordinate coordinate)
        {
            tile_at(coordinate).plant_mine();

            set_number_of_mines_surrounding_each_mine();
        }

        private void set_number_of_mines_surrounding_each_mine()
        {
            foreach (var tile in _tiles)
            {
                tile.set_number_of_mines_surrounding_on(this);
            }
        }

        private ITile tile_at(Coordinate coordinate)
        {
            return _tiles.Where(x => x.is_at(coordinate)).FirstOrDefault();
        }
    }
}