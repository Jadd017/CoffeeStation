using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace CoffeeStation
{
    internal class mysqlDB
    {
        static string connectionString = "server=localhost;user id=root;port=3306;database=coffeestationdb";
        static MySqlConnection connection = null;
        static MySqlDataAdapter adapter = null;
        static MySqlCommand command = null;


        public static void executeQuery(string sql)
        {
            try
            {
                connection = new MySqlConnection(connectionString);
                connection.Open();
                command = new MySqlCommand(sql, connection);
                command.ExecuteNonQuery();

            }
            catch (MySqlException ex) { throw ex; }
            finally { connection.Close(); }
        }
        public static DataTable getData(string sql)
        {
            DataSet ds = new DataSet();
            try
            {
                connection = new MySqlConnection(connectionString);
                connection.Open();
                adapter = new MySqlDataAdapter(sql, connection);
                adapter.Fill(ds, "table");
            }
            catch (MySqlException ex) { throw ex; }
            finally { connection.Close(); }
            return ds.Tables["table"];
        }
    }
}
