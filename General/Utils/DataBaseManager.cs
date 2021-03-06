﻿using System;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace General.Utils
{
    public class DataBaseManager
    {
        public DataBaseManager(){ }
        
        #region Public Static Methods
        public static DataTable GetTable(string query)
        {
            try
            {
                DataTable Result = new DataTable();
                SqlConnection Connection = null;
                OpenConnection(out Connection);
                SqlCommand Command = new SqlCommand(query, Connection);
                SqlDataAdapter Adapter = new SqlDataAdapter(Command);
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
                SqlConnection Connection = null;
                OpenConnection(out Connection);
                SqlCommand Command = new SqlCommand(query, Connection);
                Result = Command.ExecuteScalar();
                CloseConnection(Connection);
                return Result;
            }
            catch { throw; }
        }
        #endregion

        #region Private Static Methods
        private static void OpenConnection(out SqlConnection connectiontoopen) //probar sin parametro  OUT
        {
            try
            {
                connectiontoopen = new SqlConnection(ConfigurationManager.ConnectionStrings["CAMSA_DB"].ToString());
                connectiontoopen.Open();
            }
            catch{ throw; }
        }

        private static void CloseConnection(SqlConnection connectiontoclose)  //probar sin parametro REF
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
