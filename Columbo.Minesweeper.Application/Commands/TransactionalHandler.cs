using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Columbo.Minesweeper.Application.Commands
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
