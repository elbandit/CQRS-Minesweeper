using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Columbo.Minesweeper.Application.Queries.Views;

namespace Columbo.Minesweeper.Application.Queries
{
    public class Presenter : IPresenter
    {
        public MinefieldModel get_view_of_minefield()
        {
            var viewOfMinefield = new MinefieldModel();
            var tiles = new List<IEnumerable<TileModel>>();
            viewOfMinefield.tiles = tiles;

            tiles.Add(new List<TileModel>(){new TileModel(), new TileModel(), new TileModel()});
            tiles.Add(new List<TileModel>() { new TileModel(), new TileModel(), new TileModel() });
            tiles.Add(new List<TileModel>() { new TileModel(), new TileModel(), new TileModel() });

            return viewOfMinefield;
        }
    }
}
