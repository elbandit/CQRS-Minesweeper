namespace Columbo.Minesweeper.Application.Domain
{
    public interface IMinesweeper
    {
        void reveal_tile_at(Coordinate coordinate);
    }
}