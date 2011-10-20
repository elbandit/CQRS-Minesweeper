using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Columbo.Minesweeper.Specs.Uat.Utilities;
using Coypu;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;

namespace Columbo.Minesweeper.Specs.Uat.PageObjects
{
    public class GamePlayPage
    {
        public GamePlayPage open()
        {
            Coypu.Browser.Session.Visit("http://localhost:59174/Game");

            return this;
        }

        public static string information()
        {
            return Browser.Session.FindId("information").Text;
        }

        public static int no_of_tiles()
        {            
            return WebBrowser.Current.Table("minefield").TableCells.Count;
        }

        public static void click_tile_at(int col, int row)
        {
            //var minefield = WebBrowser.Current.Table("minefield");

            //minefield.TableRows[row].TableCells[col].Links[0].Click();

            Browser.Session.Click(() => Browser.Session.FindId((string.Format("{0}_{1}", col, row))));

        }

        public static IEnumerable<TileCell> get_all_tiles()
        {
            var all_tiles = new List<TileCell>();

            var driver = ((RemoteWebDriver) Browser.Session.Native);

            // Grab the table 
            var table = driver.FindElement(By.Id("minefield"));                                                  

            // Now get all the TR elements from the table 
            var allRows = table.FindElements(By.TagName("tr")); 


            // And iterate over them, getting the cells 
            foreach (var webElement in allRows)
            {
                var tablecells = webElement.FindElements(By.TagName("td"));
                foreach (var tablecell in tablecells)
                {
                    all_tiles.Add(TileCell.s_convert_to_tile(tablecell));
                }
            }




            //var minefield = WebBrowser.Current.Table("minefield");
            //foreach (var row in minefield.TableRows)
            //    foreach (var cell in row.TableCells)
            //        all_tiles.Add(TileCell.convert_to_tile(cell));


            return all_tiles;
        }
    }
}
