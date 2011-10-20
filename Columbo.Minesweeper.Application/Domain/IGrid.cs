namespace Columbo.Minesweeper.Application.Domain
{
    public interface IGrid
    {
        bool mine_on_tile_at(Coordinate coordinate);
        void reveal_tile_at(Coordinate coordinate);
        bool contains_tile_at(Coordinate coordinate);        
        void plant_mine_using(ITilePicker tile_picker);
        bool mines_surrounding_tile_at(Coordinate coordinate);

        bool contains_unrevealed_tiles_with_no_mines();
    }
}