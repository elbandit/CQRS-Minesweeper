using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Columbo.Minesweeper.Specs.Uat.Utilities;

namespace Columbo.Minesweeper.Specs.Uat.PageObjects
{
    public class GamePlayPage
    {
        public static int no_of_tiles()
        {            
            return WebBrowser.Current.Table("minefield").TableCells.Count;
        }

        public static void click_tile_at(int col, int row)
        {
            var minefield = WebBrowser.Current.Table("minefield");

            minefield.TableRows[row].TableCells[col].Links[0].Click();                        
        }
    }
}
