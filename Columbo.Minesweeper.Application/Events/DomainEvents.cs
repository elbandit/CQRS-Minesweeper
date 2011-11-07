using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Columbo.Minesweeper.Application.Infrastructure;

namespace Columbo.Minesweeper.Application.Events
{
    public static class DomainEvents
    {
        public static IDomainEventHandlerFactory DomainEventHandlerFactory { get; set; }

        public static void raise<T>(T domainEvent) where T : IDomainEvent
        {
            DomainEventHandlerFactory.GetDomainEventHandlersFor(domainEvent).ForEach(h => h.handle(domainEvent));
        }
    }
}
