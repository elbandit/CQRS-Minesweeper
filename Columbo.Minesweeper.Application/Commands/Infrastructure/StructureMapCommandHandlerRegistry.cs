using StructureMap;

namespace Columbo.Minesweeper.Application.Commands.Infrastructure
{
    public class StructureMapCommandHandlerRegistry : ICommandHandlerRegistry
    {
        public ICommandHandler<TCommand> find_handler_for<TCommand>(TCommand command) where TCommand : ICommand
        {     
            return  ObjectFactory.TryGetInstance<ICommandHandler<TCommand>>();            
        }
    }
}