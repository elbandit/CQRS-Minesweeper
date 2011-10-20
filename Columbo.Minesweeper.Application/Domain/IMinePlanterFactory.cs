namespace Columbo.Minesweeper.Application.Domain
{
    public interface IMinePlanterFactory
    {
        IMinePlanter create(int number_of_mines_to_plant);
    }
}