using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Columbo.Minesweeper.Application.Domain
{
    public class Coordinate : IEquatable<Coordinate>
    {
        public Coordinate(int x, int y)
        {
            X = x;
            Y = y;
        }

        public int X { get; private set; }
        public int Y { get; private set; }

        public bool Equals(Coordinate other)
        {
            return this.X == other.X && this.Y == other.Y;
        }

        public override string ToString()
        {
            return string.Format("{0},{1}", X, Y);
        }

        public static Coordinate parse(string move_coordinates)
        {
            var coordinates = move_coordinates.Split(',');

            return new Coordinate(int.Parse(coordinates[0].ToString()),
                                  int.Parse(coordinates[1].ToString()));
        }

        public static bool can_parse(string move_coordinates)
        {
            var coordinate_regular_expression = new Regex(@"^\d*,\d*$");

            return coordinate_regular_expression.IsMatch(move_coordinates);
        }

        public static Coordinate new_coord(int x, int y)
        {
            return new Coordinate(x,y);
        }
    }
}
