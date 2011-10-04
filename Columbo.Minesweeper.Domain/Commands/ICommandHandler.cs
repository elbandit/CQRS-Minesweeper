namespace Columbo.Minesweeper.Domain.Commands
{
    public interface ICommandHandler<T> where T : ICommand
    {
        void handle(T command);
    }
}