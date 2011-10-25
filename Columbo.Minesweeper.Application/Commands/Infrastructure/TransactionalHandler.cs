namespace Columbo.Minesweeper.Application.Commands.Infrastructure
{
    public abstract class TransactionalHandler<T> : ICommandHandler<T> where T : ICommand 
    {
        public void handle(T command)
        {
 	        // Start Transaction

            // End Transaction
        }
    }
}
