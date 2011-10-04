namespace Columbo.Minesweeper.Application.Commands
{
    public interface IBus
    {
        void send(ICommand command);
    }
}
