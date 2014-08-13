using System;
using MySql.Data.MySqlClient;
using System.Data;
using System.Configuration;

namespace General.Utils
{
    public class DataBaseManagerMySQL
    {
        public DataBaseManagerMySQL() { }

        #region Public Static Methods
        public static DataTable GetTable(string query)
        {
            try
            {
                DataTable Result = new DataTable();
                MySqlConnection Connection = null;
                OpenConnection(out Connection);
                MySqlCommand Command = new MySqlCommand(query, Connection);
                MySqlDataAdapter Adapter = new MySqlDataAdapter(Command);
                Adapter.Fill(Result);
                CloseConnection(Connection);
                return Result;
            }
            catch { throw; }
        }

        public static object GetValue(string query)
        {
            try
            {
                object Result;
                MySqlConnection Connection = null;
                OpenConnection(out Connection);
                MySqlCommand Command = new MySqlCommand(query, Connection);
                Result = Command.ExecuteScalar();
                CloseConnection(Connection);
                return Result;
            }
            catch { throw; }
        }
        #endregion

        #region Private Static Methods
        private static void OpenConnection(out MySqlConnection connectiontoopen) //probar sin parametro  OUT
        {
            try
            {
                connectiontoopen = new MySqlConnection(ConfigurationManager.ConnectionStrings["CAMSA_DB"].ToString());
                connectiontoopen.Open();
            }
            catch { throw; }
        }

        private static void CloseConnection(MySqlConnection connectiontoclose)  //probar sin parametro REF
        {
            try
            {
                connectiontoclose.Close();
            }
            catch { throw; }
        }
        #endregion
    }
}
