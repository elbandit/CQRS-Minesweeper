using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using StructureMap;
using StructureMap.Configuration.DSL;
using Columbo.Minesweeper.Domain;
using Columbo.Minesweeper.Domain.Presentation;

namespace Columbo.Minesweeper.Ui.Web
{
    public static class BootStrapper
    {
        public static void configure_dependencies()
        {
            ObjectFactory.Initialize(x =>
            {
                x.AddRegistry<UiRegistry>();
            });
        }

        public class UiRegistry : Registry
        {
            public UiRegistry()
            {
                For<IBus>().Use<InProcessCommandBus>();
                For<IPresenter>().Use<Presenter>();
            }
        }
    }
}