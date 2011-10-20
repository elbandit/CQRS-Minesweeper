using Columbo.Minesweeper.Specs.Uat.Utilities;
using TechTalk.SpecFlow;
using System.IO;
using System;
using System.Linq;
using Coypu;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Firefox;
using System.Drawing.Imaging;
using System.Reflection;
using System.Runtime.InteropServices.Expando;
using System.Diagnostics;

namespace Columbo.Minesweeper.Specs.Uat.Events
{
    [Binding]
    public class FeatureEvents
    {
        [BeforeTestRun]
        public static void BeforeTestRun()
        {
            // I'm using the Dev Studio cassini server;
            Configuration.AppHost = "localhost";
            Configuration.Port = 59174;
        }
        
        [AfterScenario]
        public static void AfterScenario()
        {
            if (ScenarioContext.Current.TestError != null)
            {                
                //ScenarioContext.Current.ScenarioInfo.Title

                var screen_shot = ((FirefoxDriver)Browser.Session.Native).GetScreenshot();

                var gg = ScenarioContext.Current.ScenarioInfo.Title;

                //Guid guid = Guid.NewGuid();
                //string pageScreenshotPath = Path.Combine(GetTempPath(), guid.ToString() + "-full-page-screenshot.png");
                //string screenshotPath = Path.Combine(GetTempPath(), guid.ToString() + "-screenshot.png");

                screen_shot.SaveAsFile(@".\" + ScenarioContext.Current.ScenarioInfo.Title + ".jpg", ImageFormat.Jpeg);                                
            }

            Coypu.Browser.EndSession();
        }

             
        //[BeforeTestRun]
        //public static void BeforeTestRun()
        //{
           
        //}

        [BeforeFeature]
        public static void BeforeFeature()
        {
            WebBrowser.initialise_local_Web_server();
        }

        [AfterFeature]
        public static void AfterFeature()
        {
            WebBrowser.stop_local_web_server();
        }

        [BeforeScenario]
        public void BeforeScenario()
        {
            Database.clear();
            //WebBrowser.InitializeBrowser();
        }

        //[AfterScenario]
        //public void AfterScenario()
        //{
        //    WebBrowser.Current.Close();
        //    WebBrowser.ShutdownBrowser();
        //}
    }    
}
