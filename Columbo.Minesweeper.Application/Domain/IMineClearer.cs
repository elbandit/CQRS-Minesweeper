namespace Columbo.Minesweeper.Application.Domain
{
    public interface IMineClearer
    {
        void reveal_all_tiles_near_mines_surrounding_tile_at(Coordinate coordinate, IGrid _grid);
    }
}