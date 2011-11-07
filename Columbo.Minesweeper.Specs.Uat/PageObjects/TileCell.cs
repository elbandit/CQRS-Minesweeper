using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;

namespace Columbo.Minesweeper.Specs.Uat.PageObjects
{
    public class TileCell
    {
        private bool _is_empty;
        private bool _is_unrevealed;
        private int _row;
        private int _column;
        private int _number_of_mines_surrounding_by;

        public TileCell(bool isEmpty, bool isUnrevealed, int row, int column, int number_of_mines_surrounding_by)
        {
            _is_empty = isEmpty;
            _is_unrevealed = isUnrevealed;
            _row = row;
            _column = column;
            _number_of_mines_surrounding_by = number_of_mines_surrounding_by;
        }
        
        public static TileCell s_convert_to_tile(IWebElement cell)
        {
            var is_empty = cell.FindElement(By.TagName("img")).GetAttribute("src").Contains("EmptyTile");
            var number_of_mines_surrounding_by = 0;

            if (is_empty)
            {
                var position_of_number_of_mines_surrounding = cell.FindElement(By.TagName("img")).GetAttribute("src").ToString().IndexOf("EmptyTile_near_");

                number_of_mines_surrounding_by = int.Parse(cell.FindElement(By.TagName("img")).GetAttribute("src").ToString().Substring(position_of_number_of_mines_surrounding + 15, 1));
            }                

            var is_unrevealed = cell.FindElement(By.TagName("img")).GetAttribute("src").Contains("UnrevealedTile");
            
          
            var coordinates = cell.FindElement(By.TagName("img")).GetAttribute("id").Split('_');            

            var row = int.Parse(coordinates[0].ToString());
            var column = int.Parse(coordinates[1].ToString());

            return new TileCell(is_empty, is_unrevealed, row, column, number_of_mines_surrounding_by);
        }

        public bool is_empty()
        {
            return _is_empty;
        }

        public bool is_unrevealed()
        {
            return _is_unrevealed;
        }

        public bool is_revealed()
        {
            return !is_unrevealed();
        }

        public int number_of_mines_surrounding_by()
        {
            return _number_of_mines_surrounding_by;
        }

         public int row
         {
            get {return _row ;}
         }

         public int column
         {
             get { return _column; }
         }
    }
}