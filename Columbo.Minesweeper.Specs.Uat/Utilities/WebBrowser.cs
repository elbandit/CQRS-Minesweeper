using System;
using System.IO;
using Cassini;
using TechTalk.SpecFlow;
using WatiN.Core;

namespace Columbo.Minesweeper.Specs.Uat.Utilities
{
    public class WebBrowser
    {
        public const int Port = 59174;

        public static IE Current
        {
            get
            {
                if (!ScenarioContext.Current.ContainsKey("browser"))
                {
                    //var ie = new IE(String.Format("http://localhost:{0}/", Port.ToString()));
                    var ie = new IE(String.Format("http://127.0.0.1:{0}/", Port.ToString()));                    
                    ie.ClearCache();
                    ie.ClearCookies();
                    ScenarioContext.Current["browser"] = ie;
                }
                return (IE)ScenarioContext.Current["browser"];
            }
        }

        public static void Stop()
        {
            if (ScenarioContext.Current.ContainsKey("browser"))
                Current.Close();
        }

        protected static Server WebServer { get; private set; }

        public static void initialise_local_Web_server()
        {
            WebServer = new Server(Port, "/", WebSiteFileLocation.get_physical_path());

            WebServer.Start();
        }

        public static void stop_local_web_server()
        {
            WebServer.Stop();
        }
    }
}
