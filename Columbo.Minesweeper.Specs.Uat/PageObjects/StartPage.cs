using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Columbo.Minesweeper.Specs.Uat.Utilities;
using Coypu;
using NUnit.Framework;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium;

namespace Columbo.Minesweeper.Specs.Uat.PageObjects
{
    public class StartPage
    {
        public StartPage open()
        {
            Coypu.Browser.Session.Visit("http://localhost:59174");

            return this;
        }

        public Guid get_player_identifier()
        {
            ICookieJar cookies = ((RemoteWebDriver)Browser.Session.Native).Manage().Cookies;

            var game_id = new Guid(cookies.GetCookieNamed("player_id").Value);

            return game_id;
        }

        public StartPage click_on_the_button_labelled(string button_label)
        {            
            Browser.Session.ClickButton(button_label);

            return this;
        }

        public string title
        {
            get { return WebBrowser.Current.Title; }
        }

        public bool is_displayed()
        {
            return title.Equals("Welcome to Columbo's Minesweeper!");
        }
    }
}
