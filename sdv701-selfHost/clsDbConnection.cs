﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace sdv701_selfHost
{
    static class clsDbConnection
    {
        private static ConnectionStringSettings ConnectionStringSettings = ConfigurationManager.ConnectionStrings["cameraco"];
        private static DbProviderFactory ProviderFactory = DbProviderFactories.GetFactory(ConnectionStringSettings.ProviderName);
        private static string ConnectionStr = ConnectionStringSettings.ConnectionString;

        public static DataTable GetDataTable(string prSQL, Dictionary<string, Object> prPars)
        {
            using (DataTable lcDataTable = new DataTable("TheTable"))
            using (DbConnection lcDataConnection = ProviderFactory.CreateConnection())

            using (DbCommand lcCommand = lcDataConnection.CreateCommand())
            {
                lcDataConnection.ConnectionString = ConnectionStr;
                lcDataConnection.Open();
                lcCommand.CommandText = prSQL; setPars(lcCommand, prPars);
                using (DbDataReader lcDataReader = lcCommand.ExecuteReader(CommandBehavior.CloseConnection)) lcDataTable.Load(lcDataReader);
                return lcDataTable;
            }
        }

        public static int Execute(string prSQL, Dictionary<string, Object> prPars)
        {
            using (DbConnection lcDataConnection = ProviderFactory.CreateConnection())
            using (DbCommand lcCommand = lcDataConnection.CreateCommand())
            {
                lcDataConnection.ConnectionString = ConnectionStr;
                lcDataConnection.Open();
                lcCommand.CommandText = prSQL;
                setPars(lcCommand, prPars);
                return lcCommand.ExecuteNonQuery();
            }
        }

        public static string ExecuteStoredProcedure(string prProcedureName, Dictionary<string, Object> prPars)
        {
            using (SqlConnection con = new SqlConnection(ConnectionStr))
            {
                using (SqlCommand cmd = new SqlCommand(prProcedureName, con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    setPars(cmd, prPars);
                    con.Open();
                    int lcResult = cmd.ExecuteNonQuery();
                    return lcResult.ToString();
                }
            }
        }

        private static void setPars(DbCommand prCommand, Dictionary<string, Object> prPars)
        {
            // For most DBMS using @Name1, @Name2, @Name3 etc. 
            if (prPars != null)
                foreach (KeyValuePair<string, Object> lcItem in prPars)
                {
                    DbParameter lcPar = ProviderFactory.CreateParameter();
                    lcPar.Value = lcItem.Value == null ? DBNull.Value : lcItem.Value;
                    lcPar.ParameterName = '@' + lcItem.Key; prCommand.Parameters.Add(lcPar);
                }
        }

        // Not working, bad attempt at using stored procedure. Delete later
        public static int executeStoredProcedureAvailable(string prModelName)
        {
            using (SqlConnection con = new SqlConnection(ConnectionStr))
            {
                using (SqlCommand cmd = new SqlCommand("isCameraAvailable", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@prModelName", prModelName);
                    cmd.Parameters.AddWithValue("@prQuantity", 1);
                    con.Open();
                    return cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
