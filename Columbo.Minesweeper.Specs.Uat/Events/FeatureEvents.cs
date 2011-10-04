using Columbo.Minesweeper.Specs.Uat.Utilities;
using TechTalk.SpecFlow;
using Coypu;

namespace Columbo.Minesweeper.Specs.Uat.Events
{
    [Binding]
    public class FeatureEvents
    {
        [BeforeTestRun]
        public static void BeforeTestRun()
        {
           
        }

        [BeforeFeature]
        public static void BeforeFeature()
        {

        }

        [AfterFeature]
        public static void AfterFeature()
        {

        }

        [BeforeScenario]
        public void BeforeScenario()
        {
            WebBrowser.InitializeBrowser();            
        }

        [AfterScenario]
        public void AfterScenario()
        {
            WebBrowser.Current.Close();
            WebBrowser.ShutdownBrowser();
        }
    }    
}
