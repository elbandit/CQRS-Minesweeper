using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Columbo.Minesweeper.Specs.Uat.Utilities;
using NUnit.Framework;

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

        public static IEnumerable<TileCell> get_all_tiles()
        {
            var all_tiles = new List<TileCell>();

            var minefield = WebBrowser.Current.Table("minefield");
            foreach (var row in minefield.TableRows)
                foreach (var cell in row.TableCells)
                    all_tiles.Add(TileCell.convert_to_tile(cell));


            return all_tiles;
        }
    }
}
