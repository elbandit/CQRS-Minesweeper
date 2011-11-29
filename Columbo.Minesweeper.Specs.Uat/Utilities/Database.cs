using System;
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
                                      "delete Games;" + 
                                      "DELETE MinefieldViews; " +
                                      "DELETE GameViews;";                                  
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

        public static void set_number_of_mines_surrounding_tile(Guid game_id, int row, int column, int surrounded_by)
        {
            using (var conn = new SqlConnection(@"Data Source=.;Initial Catalog=Minesweeper;Integrated Security=True"))
            {
                using (var cmd = conn.CreateCommand())
                {
                    conn.Open();
                    cmd.CommandText = "UPDATE Minefields " +
                                      "SET Number_Of_Mines_Surrounding = @surrounded_by " +
                                      "WHERE Game_ID = @GameID " +
                                      "AND Row = @Row " +
                                      "AND Col = @Col";
                    cmd.Parameters.AddWithValue("GameID", game_id);
                    cmd.Parameters.AddWithValue("Row", row);
                    cmd.Parameters.AddWithValue("Col", column);
                    cmd.Parameters.AddWithValue("surrounded_by", surrounded_by);
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
