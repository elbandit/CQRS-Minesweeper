namespace Columbo.Minesweeper.Domain.Commands
{
    public interface IBus
    {
        void send(ICommand command);
    }
}
