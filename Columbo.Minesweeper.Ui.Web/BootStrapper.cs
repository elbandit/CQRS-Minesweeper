using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Columbo.Minesweeper.Application.Commands;
using Columbo.Minesweeper.Application.Commands.Infrastructure;
using Columbo.Minesweeper.Application.Domain;
using Columbo.Minesweeper.Application.Events;
using StructureMap;
using StructureMap.Configuration.DSL;
using Columbo.Minesweeper.Application.Queries;
using Columbo.Minesweeper.Ui.Web.Controllers;

namespace Columbo.Minesweeper.Ui.Web
{
    public static class BootStrapper
    {
        public static void configure_dependencies()
        {
            ObjectFactory.Initialize(x =>
            {
                x.AddRegistry<UiRegistry>();
                x.AddRegistry<DomainRegistry>();
                x.AddRegistry<CommandHandlerRegistry>();
                x.AddRegistry<EventHandlerRegistry>();
            });

            DomainEvents.DomainEventHandlerFactory = (IDomainEventHandlerFactory) ObjectFactory.GetInstance(typeof(IDomainEventHandlerFactory));
        }

        public class UiRegistry : Registry
        {
            public UiRegistry()
            {
                For<IBus>().Use<InProcessCommandBus>();
                For<IPresenter>().Use<Presenter>();
                For<IPlayerIdentifier>().Use<CookieIdentifier>();
            }
        }

        public class CommandHandlerRegistry : Registry
        {
            public CommandHandlerRegistry()
            {
                Scan(s =>
                {
                    s.Assembly("Columbo.Minesweeper.Application");
                    s.ConnectImplementationsToTypesClosing(typeof(ICommandHandler<>));
                });
            }
        }

        public class EventHandlerRegistry : Registry
        {
            public EventHandlerRegistry()
            {
                Scan(s =>
                {
                    s.Assembly("Columbo.Minesweeper.Application");
                    s.ConnectImplementationsToTypesClosing(typeof(IDomainEventHandler<>));
                });
            }
        }
        
        public class DomainRegistry : Registry
        {
            public DomainRegistry()
            {
                For<IMinesweeperFactory>().Use<MinesweeperFactory>();
                For<IMinefieldFactory>().Use<MinefieldFactory>();
                For<IMinePlanterFactory>().Use<MinePlanterFactory>();
                For<IGridFactory>().Use<GridFactory>();
                For<ITileFactory>().Use<TileFactory>();
                For<IGameTypeMapper>().Use<GameTypeMapper>();
                For<IMineClearer>().Use<MineClearer>();
                For<ICoordinatePicker>().Use<RandomCoordinatePicker>();

                For<IGameRepository>().Use<GameRepository>();

                For<ICommandHandlerRegistry>().Use<StructureMapCommandHandlerRegistry>();
                For<IDomainEventHandlerFactory>().Use<StructureMapDomainEventHandlerFactory>();
             
                //ForRequestedType<IDomainEventHandler<OrderSubmittedEvent>>().AddConcreteType<OrderSubmittedHandler>();
            }
        }
    }
}