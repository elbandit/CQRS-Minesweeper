namespace Columbo.Minesweeper.Domain.Model
{
    public interface IMinesweeper
    {
        void reveal_tile_at(Coordinate coordinate);
    }
}