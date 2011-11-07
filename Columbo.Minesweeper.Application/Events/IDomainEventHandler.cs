using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Columbo.Minesweeper.Application.Events
{
    public interface IDomainEventHandler<T> where T : IDomainEvent
    {
        void handle(T domain_event);
    }
}
