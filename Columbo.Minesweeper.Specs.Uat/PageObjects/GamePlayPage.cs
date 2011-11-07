using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Columbo.Minesweeper.Specs.Uat.Utilities;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using WatiN.Core;
using Browser = Coypu.Browser;

namespace Columbo.Minesweeper.Specs.Uat.PageObjects
{
    public class GamePlayPage
    {
        public GamePlayPage open()
        {
            Coypu.Browser.Session.Visit("http://localhost:59174/Game");

            return this;
        }

        public void return_to_start_page()
        {
            Coypu.Browser.Session.Visit("http://localhost:59174/");
        }

        public bool resume_game_button_showing()
        {            
            return Browser.Session.Has(() => Browser.Session.FindButton("resume game")); 
        }

        public void click_resume_game_button()
        {
            Browser.Session.ClickButton("btnResumeGame");
        }

        public bool message_displayed_with_text_of(string message_text)
        {
            return Browser.Session.HasContent(message_text);
        }

        public static int no_of_tiles()
        {
            System.Threading.Thread.Sleep(2000);

            return WebBrowser.Current.Table("minefield").TableCells.Count;
        }

        public static void click_tile_at(int col, int row)
        {            
            Browser.Session.Click(() => Browser.Session.FindId((string.Format("{0}_{1}", col, row))));

            System.Threading.Thread.Sleep(2000);
        }

        public static IEnumerable<TileCell> get_all_tiles()
        {
            System.Threading.Thread.Sleep(3000);

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

            return all_tiles;
        }

        public bool contains_a_button_with_a_label_of(string button_label)
        {
            return Browser.Session.Has(() => Browser.Session.FindButton(button_label));            
        }
    }
}
