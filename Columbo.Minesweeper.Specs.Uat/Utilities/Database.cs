using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace Columbo.Minesweeper.Specs.Uat.Utilities
{
    public static class Database
    {        
        public static void clear()
        {            
            using (var conn = new SqlConnection(@"Data Source=.;Initial Catalog=Minesweeper;Integrated Security=True"))
            {
                using (var cmd = conn.CreateCommand())
                {
                    conn.Open();
                    cmd.CommandText = "delete Minefields;" +
                                      "delete Games;";                                  
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();
                }
            }            
        }

        public static void clear_mines_for_game_with_id_of(Guid game_id)
        {
            using (var conn = new SqlConnection(@"Data Source=.;Initial Catalog=Minesweeper;Integrated Security=True"))
            {
                using (var cmd = conn.CreateCommand())
                {
                    conn.Open();
                    cmd.CommandText = "UPDATE Minefields " +
                                      "SET Contains_Mine = 0,  " +
                                      "Number_Of_Mines_Surrounding = 0 " +
                                      "WHERE Game_ID = @GameID";
                    cmd.Parameters.AddWithValue("GameID", game_id);
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();
                }
            }         
        }

        public static void add_mine_to_game(Guid game_id, int row, int column)
        {
            using (var conn = new SqlConnection(@"Data Source=.;Initial Catalog=Minesweeper;Integrated Security=True"))
            {
                using (var cmd = conn.CreateCommand())
                {
                    conn.Open();
                    cmd.CommandText = "UPDATE Minefields " +
                                      "SET Contains_Mine = 1 " +
                                      "WHERE Game_ID = @GameID " +
                                      "AND Row = @Row " +
                                      "AND Col = @Col";
                    cmd.Parameters.AddWithValue("GameID", game_id);
                    cmd.Parameters.AddWithValue("Row", row);
                    cmd.Parameters.AddWithValue("Col", column);
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();

                    //TODO update all tiles to show extra mine
                }
            }
        }
    }
}
