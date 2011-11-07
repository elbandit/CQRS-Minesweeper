namespace Columbo.Minesweeper.Application.Domain
{
    public interface IMinePlanterFactory
    {
        IMinePlanter create_for(GameDifficulty game_difficulty);
    }
}