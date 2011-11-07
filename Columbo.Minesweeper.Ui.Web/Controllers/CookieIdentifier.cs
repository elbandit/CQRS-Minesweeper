using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Columbo.Minesweeper.Ui.Web.Controllers
{
    public class CookieIdentifier : IPlayerIdentifier
    {
        public Guid get_player_identifier()
        {
            Guid player_id = Guid.NewGuid();

            HttpCookie cookie = HttpContext.Current.Request.Cookies["player_id"];
            if (cookie != null)                                
                player_id = new Guid(cookie.Value);

            return player_id;
        }

        public void set_player_identifier(Guid player_id)
        {            
            HttpCookie hc3 = new HttpCookie("player_id", player_id.ToString());
            hc3.Expires = DateTime.Now.AddYears(1);
            System.Web.HttpContext.Current.Response.Cookies.Add(hc3);    
        }

        public bool has_indenitfier()
        {
            return HttpContext.Current.Request.Cookies["player_id"] != null;
        }
    }
}