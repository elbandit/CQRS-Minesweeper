using NHibernate;
using NHibernate.Cfg;

namespace Columbo.Minesweeper.Application.Infrastructure
{
    public class SessionFactory
    {
        private static ISessionFactory _SessionFactory;

        public static void Init()
        {                       
            Configuration config = new Configuration();
            config.AddAssembly("Columbo.Minesweeper.Application");
            
            config.Configure();            

            _SessionFactory = config.BuildSessionFactory();
        }

        private static ISessionFactory GetSessionFactory()
        {
            if (_SessionFactory == null)
                Init();

            return _SessionFactory;
        }

        public static ISession GetNewSession()
        {
            return GetSessionFactory().OpenSession();
        }       
    }

}
