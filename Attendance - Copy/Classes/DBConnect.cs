using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace Attendance.Classes
{
    public static class DBConnect
    {

        public static string ServerConnectionString = "";

        public static void GenerateConnectionString()
        {
            
            ServerConnectionString=Attendance.Properties.Settings.Default.ServerConnectionString;

            
        }
        public static bool CheckDBConnection()
        {
            bool IsConnected = false;

            GenerateConnectionString();

            string ConnectionStr = "";
            ConnectionStr = ServerConnectionString;

            SqlConnection connect = null;

            try
            {
                connect = new SqlConnection(ConnectionStr);
                connect.Open();
                IsConnected = true;

            }
            catch (Exception e)
            {
                IsConnected = false;

            }
            finally
            {
                if (connect != null)
                    connect.Close();
            }


            return IsConnected;
        }

        public static DataTable GetTodayData(string Date)
        {
          
            GenerateConnectionString();

            DataTable dt = new DataTable();

            SqlConnection DbConn = new SqlConnection();
            DbConn.ConnectionString = ServerConnectionString;

            SqlParameter PrmDate = new SqlParameter();
            PrmDate.ParameterName = "@Today";
            PrmDate.Direction = ParameterDirection.Input;
            PrmDate.SqlDbType = SqlDbType.VarChar;
            PrmDate.Value = Date;

            DbConn.Open();

            SqlCommand SCmd = new SqlCommand();
            SqlDataAdapter da = new SqlDataAdapter();
            SCmd.Connection = DbConn;
            SCmd.CommandType = CommandType.StoredProcedure;
            SCmd.CommandTimeout = 120000000;

            SCmd.CommandText = "[Mrk].[GetTodayData]";

            SCmd.Parameters.Add(PrmDate);
            
            da.SelectCommand = SCmd;
            da.Fill(dt);

            DbConn.Close();

            return dt;

        }
    }
}
