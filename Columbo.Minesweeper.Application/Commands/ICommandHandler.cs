namespace Columbo.Minesweeper.Application.Commands
{
    public interface ICommandHandler<T> where T : ICommand
    {
        void handle(T command);
    }
}