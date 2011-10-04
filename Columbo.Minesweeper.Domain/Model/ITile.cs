namespace Columbo.Minesweeper.Domain.Model
{
    public interface ITile
    {
        void reveal();
        bool contains_mine();
        void plant_mine();
        bool is_adjacent_by_a_mine();
        void reveal_number_of_adjacent_mines();
    }
}