using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Columbo.Minesweeper.Specs.Uat.Utilities
{
    public class WebSiteFileLocation
    {
        private const string relative_path = @"Columbo.Minesweeper.Ui.Web";

        public static string get_physical_path()
        {
            var dir = Directory.GetCurrentDirectory();

            var index = dir.LastIndexOf("Columbo.Minesweeper.Specs.Uat");

            dir = dir.Remove(index);

            return Path.Combine(dir, relative_path);
        }
    }
}
