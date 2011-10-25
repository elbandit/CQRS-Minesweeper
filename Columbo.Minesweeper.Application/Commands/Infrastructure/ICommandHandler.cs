namespace Columbo.Minesweeper.Application.Commands.Infrastructure
{
    public interface ICommandHandler<T> where T : ICommand
    {
        void handle(T command);
    }
}