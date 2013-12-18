using System;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace General.Utils
{
    public class DataBaseManager
    {
        public DataBaseManager(){ }

        #region Public Methods

        public DataTable GetTable(string tablename)
        {
            try
            {
                DataTable Result = new DataTable();
                SqlConnection Connection = null;
                OpenConnection(out Connection);
                SqlCommand Command = new SqlCommand("SELECT * FROM USERS", Connection);                
                SqlDataAdapter Adapter = new SqlDataAdapter(Command);
                Adapter.Fill(Result);
                CloseConnection(Connection);
                return Result;
            }
            catch { throw; }
        }

        public void ExecuteStoredProcedure()
        {
            try
            { 
                //TODO
            }
            catch{ throw; }
        }
        #endregion

        #region Private Methods
        private void OpenConnection(out SqlConnection connectiontoopen) //probar sin parametro  OUT
        {
            try
            {
                connectiontoopen = new SqlConnection(ConfigurationManager.ConnectionStrings["CAMSA_DB"].ToString());
                connectiontoopen.Open();
            }
            catch{ throw; }
        }

        private void CloseConnection(SqlConnection connectiontoclose)  //probar sin parametro REF
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
