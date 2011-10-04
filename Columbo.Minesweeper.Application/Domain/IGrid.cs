namespace Columbo.Minesweeper.Application.Domain
{
    public interface IGrid
    {
        ITile get_tile_at(Coordinate coordinate);
        bool contains(Coordinate newCoord);
    }
}