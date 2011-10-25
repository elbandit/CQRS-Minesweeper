namespace Columbo.Minesweeper.Application.Commands.Infrastructure
{
    public interface IBus
    {
        void send<TCommand>(TCommand command) where TCommand : ICommand;
    }
}
