using System;
using System.Linq;
using System.Collections.Generic;

namespace Columbo.Minesweeper.Application.Domain
{
    public class Grid : IGrid
    {
        private IList<ITile> _tiles;
        
        private Grid()
        {

        }

        public Grid(ITileFactory tile_factory, int number_of_rows, int number_of_columns, IMinesweeper minesweeper)
        {            
            _tiles = new List<ITile>();

            var row_count = 0;
            while (row_count < number_of_rows)
            {
                var column_count = 0;
                while (column_count < number_of_columns)
                {
                    _tiles.Add(tile_factory.create_for(new Coordinate(row_count, column_count), minesweeper));
                    column_count++;
                }
                row_count++;
            }
        }

        public bool mine_on_tile_at(Coordinate coordinate)
        {
            return _tiles.Where(x => x.is_at(coordinate)).FirstOrDefault().contains_mine();
        }

        public void reveal_tile_at(Coordinate coordinate)
        {
            _tiles.Where(x => x.is_at(coordinate)).FirstOrDefault().reveal();
        }

        public bool contains_tile_at(Coordinate coordinate)
        {
            return _tiles.Where(x => x.is_at(coordinate)).FirstOrDefault() != null;
        }

        public bool contains_unrevealed_tiles_with_no_mines()
        {
            return _tiles.Where(x => x.is_unrevealed_with_no_mine()).Count() > 0;
        }

        public void plant_mine_using(ITilePicker tile_picker)
        {
            tile_picker.select_tile_from(_tiles).plant_mine();                        
        }

        public bool mines_surrounding_tile_at(Coordinate coordinate)
        {
            return get_tile_at(coordinate).is_surrounded_by_mines_on(this);
        }

        private ITile get_tile_at(Coordinate coordinate)
        {
            return _tiles.Where(x => x.is_at(coordinate)).FirstOrDefault();
        }
    }
}