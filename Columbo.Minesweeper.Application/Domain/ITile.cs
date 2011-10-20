namespace Columbo.Minesweeper.Application.Domain
{
    public interface ITile
    {
        void reveal();
        bool contains_mine();
        void plant_mine();
        bool is_surrounded_by_mines_on(IGrid grid);
        bool is_at(Coordinate coordinate);
        bool is_unrevealed_with_no_mine();
    }
}