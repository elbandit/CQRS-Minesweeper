using Columbo.Minesweeper.Specs.Uat.Utilities;
using TechTalk.SpecFlow;

namespace Columbo.Minesweeper.Specs.Uat.Events
{
    [Binding]
    public class FeatureEvents
    {
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
