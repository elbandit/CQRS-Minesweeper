namespace Columbo.Minesweeper.Application.Commands
{
    public interface IBus
    {
        void send<TCommand>(TCommand command) where TCommand : ICommand;
    }
}
