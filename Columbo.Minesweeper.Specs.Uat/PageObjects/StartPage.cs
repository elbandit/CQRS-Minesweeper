using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Columbo.Minesweeper.Specs.Uat.Utilities;

namespace Columbo.Minesweeper.Specs.Uat.PageObjects
{
    public class StartPage
    {
        public static void start_game_with_minefield_of_9x9()
        {
            WebBrowser.Current.Button("btnStartGame9x9").Click();
        }

        public static string title
        {
            get { return WebBrowser.Current.Title; }
        }
    }
}
