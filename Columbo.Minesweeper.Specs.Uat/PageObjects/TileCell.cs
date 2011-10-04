using System;
using NUnit.Framework;
using WatiN.Core;

namespace Columbo.Minesweeper.Specs.Uat.PageObjects
{
    public class TileCell
    {
        private bool _is_empty;
        private bool _is_unrevealed;

        public TileCell(bool isEmpty, bool isUnrevealed)
        {
            _is_empty = isEmpty;
            _is_unrevealed = isUnrevealed;
        }
        
        public static TileCell convert_to_tile(TableCell cell)
        {
            var is_empty = cell.Image("EmptyTile").Exists;
            var is_unrevealed = cell.Image("UnrevealedTile").Exists;

            return new TileCell(is_empty, is_unrevealed);
        }

        public bool is_empty()
        {
            return _is_empty;
        }

        public bool is_unrevealed()
        {
            return _is_unrevealed;
        }
    }
}