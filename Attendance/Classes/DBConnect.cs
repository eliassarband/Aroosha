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
        public static string AttendanceConnectionString = "";

        public static string GenerateServerConnectionString()
        {
            string InstanceName = GetKeyValue("ServerInstanceName");
            string DatabaseName = GetKeyValue("ServerDatabaseName");
            string LoginName = GetKeyValue("ServerLoginName");
            string LoginPassword = GetKeyValue("ServerLoginPassword");

            ServerConnectionString = "Data Source=" + InstanceName + ";Initial Catalog=" + DatabaseName + ";Persist Security Info=True;User ID="+LoginName+";Password="+LoginPassword;

            return ServerConnectionString;
        }

        public static string GenerateAttendanceConnectionString()
        {
            string AttendanceInstanceName = Attendance.Properties.Settings.Default.AttendanceInstanceName;

            AttendanceConnectionString = "Data Source=" + AttendanceInstanceName + ";Initial Catalog=Attendance;Persist Security Info=True;User ID=Aroosha;Password=Aroosha8831";

            return AttendanceConnectionString;
        }

        public static bool CheckServerDBConnection()
        {
            bool IsConnected = false;

            GenerateServerConnectionString();

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

        public static string CheckServerDBConnectionResult()
        {
            string result= "success";

            GenerateServerConnectionString();

            string ConnectionStr = "";
            ConnectionStr = ServerConnectionString;

            SqlConnection connect = null;

            try
            {
                connect = new SqlConnection(ConnectionStr);
                connect.Open();
                

            }
            catch (Exception e)
            {
                result = e.Message;
            }
            finally
            {
                if (connect != null)
                    connect.Close();


            }


            return result;
        }

        public static bool CheckAttendanceDBConnection()
        {
            bool IsConnected = false;

            GenerateAttendanceConnectionString();

            string ConnectionStr = "";
            ConnectionStr = AttendanceConnectionString;

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

        public static string CheckAttendanceDBConnectionResult()
        {
            string result= "success";

            GenerateAttendanceConnectionString();

            string ConnectionStr = "";
            ConnectionStr = AttendanceConnectionString;

            SqlConnection connect = null;

            try
            {
                connect = new SqlConnection(ConnectionStr);
                connect.Open();
                
            }
            catch (Exception e)
            {
                result = e.Message;
            }
            finally
            {
                if (connect != null)
                    connect.Close();
            }


            return result;
        }


        public static string GetKeyValue(string KeyName)
        {
            string KeyValue= "";

            GenerateAttendanceConnectionString();

            SqlConnection DbConn = new SqlConnection();
            DbConn.ConnectionString = AttendanceConnectionString;

            SqlParameter PrmKeyName = new SqlParameter();
            PrmKeyName.ParameterName = "@KeyName";
            PrmKeyName.Direction = ParameterDirection.Input;
            PrmKeyName.SqlDbType = SqlDbType.VarChar;
            PrmKeyName.Value = KeyName;


            DbConn.Open();

            SqlCommand SCmd = new SqlCommand();
            SqlDataAdapter da = new SqlDataAdapter();
            SCmd.Connection = DbConn;
            SCmd.CommandType = CommandType.StoredProcedure;
            SCmd.CommandTimeout = 120000000;

            SCmd.CommandText = "[dbo].[GetKeyValue]";

            SCmd.Parameters.Add(PrmKeyName);

            KeyValue = SCmd.ExecuteScalar().ToString();


            DbConn.Close();


            return KeyValue;
        }

        public static int SaveSettingKey(string KeyName,string KeyValue)
        {
            int Result = 0;

            GenerateAttendanceConnectionString();

            SqlConnection DbConn = new SqlConnection();
            DbConn.ConnectionString = AttendanceConnectionString;

            SqlParameter PrmKeyName = new SqlParameter();
            PrmKeyName.ParameterName = "@KeyName";
            PrmKeyName.Direction = ParameterDirection.Input;
            PrmKeyName.SqlDbType = SqlDbType.VarChar;
            PrmKeyName.Value = KeyName;

            SqlParameter PrmKeyValue = new SqlParameter();
            PrmKeyValue.ParameterName = "@KeyValue";
            PrmKeyValue.Direction = ParameterDirection.Input;
            PrmKeyValue.SqlDbType = SqlDbType.NVarChar;
            PrmKeyValue.Value = KeyValue;

            DbConn.Open();

            SqlCommand SCmd = new SqlCommand();
            SqlDataAdapter da = new SqlDataAdapter();
            SCmd.Connection = DbConn;
            SCmd.CommandType = CommandType.StoredProcedure;
            SCmd.CommandTimeout = 120000000;

            SCmd.CommandText = "[dbo].[SaveSettingKey]";

            SCmd.Parameters.Add(PrmKeyName);
            SCmd.Parameters.Add(PrmKeyValue);

            Result = Convert.ToInt32(SCmd.ExecuteScalar().ToString());


            DbConn.Close();


            return Result;
        }

        public static DataTable GetTodayData(string Date)
        {

            GenerateServerConnectionString();

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

        public static string InsertTodayData(int Id, string Date, int MarketScheduleDetailId, int WeekDay, string MarketScheduleName, int CustomerId, string MobileNumber, int CustomerCode, string NationalCode, string FirstName, string LastName, string CustomerName, bool Gender, string CardCode, int jobId, string JobName, int JobGroupId, string JobGroupName, int ShopId, int ShopCode, string ShopName, string ShopIdentifier, int ShopTypeId, string ShopTypeName, int ShopGroupId, string ShopGroupName, int MarketStructureId, int MarketStructureCode, string MarketStructureName, int MarketStructureTypeId, string MarketStructureTypeName, int Amount, int DiscountId, string DiscountName, int DiscountPercent, int DiscountAmount, int TariffId, string TariffName, int TariffAmount, bool Paid, string Description, int TenantId, int TenantCode, string TenantName, string Type, int Balance, int DebtCeiling,bool Sent,string StructureAddress)
        {
            string Result = "warning";

            GenerateAttendanceConnectionString();

            SqlConnection DbConn = new SqlConnection();
            DbConn.ConnectionString = AttendanceConnectionString;

            SqlParameter PrmId = new SqlParameter();
            PrmId.ParameterName = "@Id";
            PrmId.Direction = ParameterDirection.Input;
            PrmId.SqlDbType = SqlDbType.Int;
            PrmId.Value = Id;

            SqlParameter PrmDate = new SqlParameter();
            PrmDate.ParameterName = "@Date";
            PrmDate.Direction = ParameterDirection.Input;
            PrmDate.SqlDbType = SqlDbType.VarChar;
            PrmDate.Value = Date;

            SqlParameter PrmMarketScheduleDetailId = new SqlParameter();
            PrmMarketScheduleDetailId.ParameterName = "@MarketScheduleDetailId";
            PrmMarketScheduleDetailId.Direction = ParameterDirection.Input;
            PrmMarketScheduleDetailId.SqlDbType = SqlDbType.Int;
            PrmMarketScheduleDetailId.Value = MarketScheduleDetailId;


            SqlParameter PrmWeekDay = new SqlParameter();
            PrmWeekDay.ParameterName = "@WeekDay";
            PrmWeekDay.Direction = ParameterDirection.Input;
            PrmWeekDay.SqlDbType = SqlDbType.Int;
            PrmWeekDay.Value = WeekDay;

            SqlParameter PrmMarketScheduleName = new SqlParameter();
            PrmMarketScheduleName.ParameterName = "@MarketScheduleName";
            PrmMarketScheduleName.Direction = ParameterDirection.Input;
            PrmMarketScheduleName.SqlDbType = SqlDbType.NVarChar;
            PrmMarketScheduleName.Value = MarketScheduleName;

            SqlParameter PrmCustomerId = new SqlParameter();
            PrmCustomerId.ParameterName = "@CustomerId";
            PrmCustomerId.Direction = ParameterDirection.Input;
            PrmCustomerId.SqlDbType = SqlDbType.Int;
            PrmCustomerId.Value = CustomerId;


            SqlParameter PrmMobileNumber = new SqlParameter();
            PrmMobileNumber.ParameterName = "@MobileNumber";
            PrmMobileNumber.Direction = ParameterDirection.Input;
            PrmMobileNumber.SqlDbType = SqlDbType.VarChar;
            PrmMobileNumber.Value = MobileNumber;

            SqlParameter PrmCustomerCode = new SqlParameter();
            PrmCustomerCode.ParameterName = "@CustomerCode";
            PrmCustomerCode.Direction = ParameterDirection.Input;
            PrmCustomerCode.SqlDbType = SqlDbType.Int;
            PrmCustomerCode.Value = CustomerCode;

            SqlParameter PrmNationalCode = new SqlParameter();
            PrmNationalCode.ParameterName = "@NationalCode";
            PrmNationalCode.Direction = ParameterDirection.Input;
            PrmNationalCode.SqlDbType = SqlDbType.VarChar;
            PrmNationalCode.Value = NationalCode;


            SqlParameter PrmFirstName = new SqlParameter();
            PrmFirstName.ParameterName = "@FirstName";
            PrmFirstName.Direction = ParameterDirection.Input;
            PrmFirstName.SqlDbType = SqlDbType.NVarChar;
            PrmFirstName.Value = FirstName;

            SqlParameter PrmLastName = new SqlParameter();
            PrmLastName.ParameterName = "@LastName";
            PrmLastName.Direction = ParameterDirection.Input;
            PrmLastName.SqlDbType = SqlDbType.NVarChar;
            PrmLastName.Value = LastName;

            SqlParameter PrmCustomerName = new SqlParameter();
            PrmCustomerName.ParameterName = "@CustomerName";
            PrmCustomerName.Direction = ParameterDirection.Input;
            PrmCustomerName.SqlDbType = SqlDbType.NVarChar;
            PrmCustomerName.Value = CustomerName;


            SqlParameter PrmGender = new SqlParameter();
            PrmGender.ParameterName = "@Gender";
            PrmGender.Direction = ParameterDirection.Input;
            PrmGender.SqlDbType = SqlDbType.Bit;
            PrmGender.Value = Gender;

            SqlParameter PrmCardCode = new SqlParameter();
            PrmCardCode.ParameterName = "@CardCode";
            PrmCardCode.Direction = ParameterDirection.Input;
            PrmCardCode.SqlDbType = SqlDbType.VarChar;
            PrmCardCode.Value = CardCode;

            SqlParameter PrmJobId = new SqlParameter();
            PrmJobId.ParameterName = "@jobId";
            PrmJobId.Direction = ParameterDirection.Input;
            PrmJobId.SqlDbType = SqlDbType.Int;
            PrmJobId.Value = jobId;


            SqlParameter PrmJobName = new SqlParameter();
            PrmJobName.ParameterName = "@JobName";
            PrmJobName.Direction = ParameterDirection.Input;
            PrmJobName.SqlDbType = SqlDbType.NVarChar;
            PrmJobName.Value = JobName;

            SqlParameter PrmJobGroupId = new SqlParameter();
            PrmJobGroupId.ParameterName = "@JobGroupId";
            PrmJobGroupId.Direction = ParameterDirection.Input;
            PrmJobGroupId.SqlDbType = SqlDbType.Int;
            PrmJobGroupId.Value = JobGroupId;

            SqlParameter PrmJobGroupName = new SqlParameter();
            PrmJobGroupName.ParameterName = "@JobGroupName";
            PrmJobGroupName.Direction = ParameterDirection.Input;
            PrmJobGroupName.SqlDbType = SqlDbType.NVarChar;
            PrmJobGroupName.Value = JobGroupName;


            SqlParameter PrmShopId = new SqlParameter();
            PrmShopId.ParameterName = "@ShopId";
            PrmShopId.Direction = ParameterDirection.Input;
            PrmShopId.SqlDbType = SqlDbType.Int;
            PrmShopId.Value = ShopId;

            SqlParameter PrmShopCode = new SqlParameter();
            PrmShopCode.ParameterName = "@ShopCode";
            PrmShopCode.Direction = ParameterDirection.Input;
            PrmShopCode.SqlDbType = SqlDbType.Int;
            PrmShopCode.Value = ShopCode;

            SqlParameter PrmShopName = new SqlParameter();
            PrmShopName.ParameterName = "@ShopName";
            PrmShopName.Direction = ParameterDirection.Input;
            PrmShopName.SqlDbType = SqlDbType.NVarChar;
            PrmShopName.Value = ShopName;


            SqlParameter PrmShopIdentifier = new SqlParameter();
            PrmShopIdentifier.ParameterName = "@ShopIdentifier";
            PrmShopIdentifier.Direction = ParameterDirection.Input;
            PrmShopIdentifier.SqlDbType = SqlDbType.VarChar;
            PrmShopIdentifier.Value = ShopIdentifier;

            SqlParameter PrmShopTypeId = new SqlParameter();
            PrmShopTypeId.ParameterName = "@ShopTypeId";
            PrmShopTypeId.Direction = ParameterDirection.Input;
            PrmShopTypeId.SqlDbType = SqlDbType.Int;
            PrmShopTypeId.Value = ShopTypeId;

            SqlParameter PrmShopTypeName = new SqlParameter();
            PrmShopTypeName.ParameterName = "@ShopTypeName";
            PrmShopTypeName.Direction = ParameterDirection.Input;
            PrmShopTypeName.SqlDbType = SqlDbType.NVarChar;
            PrmShopTypeName.Value = ShopTypeName;


            SqlParameter PrmShopGroupId = new SqlParameter();
            PrmShopGroupId.ParameterName = "@ShopGroupId";
            PrmShopGroupId.Direction = ParameterDirection.Input;
            PrmShopGroupId.SqlDbType = SqlDbType.Int;
            PrmShopGroupId.Value = ShopGroupId;

            SqlParameter PrmShopGroupName = new SqlParameter();
            PrmShopGroupName.ParameterName = "@ShopGroupName";
            PrmShopGroupName.Direction = ParameterDirection.Input;
            PrmShopGroupName.SqlDbType = SqlDbType.NVarChar;
            PrmShopGroupName.Value = ShopGroupName;

            SqlParameter PrmMarketStructureId = new SqlParameter();
            PrmMarketStructureId.ParameterName = "@MarketStructureId";
            PrmMarketStructureId.Direction = ParameterDirection.Input;
            PrmMarketStructureId.SqlDbType = SqlDbType.Int;
            PrmMarketStructureId.Value = MarketStructureId;


            SqlParameter PrmMarketStructureCode = new SqlParameter();
            PrmMarketStructureCode.ParameterName = "@MarketStructureCode";
            PrmMarketStructureCode.Direction = ParameterDirection.Input;
            PrmMarketStructureCode.SqlDbType = SqlDbType.Int;
            PrmMarketStructureCode.Value = MarketStructureCode;

            SqlParameter PrmMarketStructureName = new SqlParameter();
            PrmMarketStructureName.ParameterName = "@MarketStructureName";
            PrmMarketStructureName.Direction = ParameterDirection.Input;
            PrmMarketStructureName.SqlDbType = SqlDbType.NVarChar;
            PrmMarketStructureName.Value = MarketStructureName;

            SqlParameter PrmMarketStructureTypeId = new SqlParameter();
            PrmMarketStructureTypeId.ParameterName = "@MarketStructureTypeId";
            PrmMarketStructureTypeId.Direction = ParameterDirection.Input;
            PrmMarketStructureTypeId.SqlDbType = SqlDbType.Int;
            PrmMarketStructureTypeId.Value = MarketStructureTypeId;


            SqlParameter PrmMarketStructureTypeName = new SqlParameter();
            PrmMarketStructureTypeName.ParameterName = "@MarketStructureTypeName";
            PrmMarketStructureTypeName.Direction = ParameterDirection.Input;
            PrmMarketStructureTypeName.SqlDbType = SqlDbType.NVarChar;
            PrmMarketStructureTypeName.Value = MarketStructureTypeName;

            SqlParameter PrmAmount = new SqlParameter();
            PrmAmount.ParameterName = "@Amount";
            PrmAmount.Direction = ParameterDirection.Input;
            PrmAmount.SqlDbType = SqlDbType.Int;
            PrmAmount.Value = Amount;

            SqlParameter PrmDiscountId = new SqlParameter();
            PrmDiscountId.ParameterName = "@DiscountId";
            PrmDiscountId.Direction = ParameterDirection.Input;
            PrmDiscountId.SqlDbType = SqlDbType.Int;
            PrmDiscountId.Value = DiscountId;


            SqlParameter PrmDiscountName = new SqlParameter();
            PrmDiscountName.ParameterName = "@DiscountName";
            PrmDiscountName.Direction = ParameterDirection.Input;
            PrmDiscountName.SqlDbType = SqlDbType.NVarChar;
            PrmDiscountName.Value = DiscountName;

            SqlParameter PrmDiscountPercent = new SqlParameter();
            PrmDiscountPercent.ParameterName = "@DiscountPercent";
            PrmDiscountPercent.Direction = ParameterDirection.Input;
            PrmDiscountPercent.SqlDbType = SqlDbType.Int;
            PrmDiscountPercent.Value = DiscountPercent;

            SqlParameter PrmDiscountAmount = new SqlParameter();
            PrmDiscountAmount.ParameterName = "@DiscountAmount";
            PrmDiscountAmount.Direction = ParameterDirection.Input;
            PrmDiscountAmount.SqlDbType = SqlDbType.Int;
            PrmDiscountAmount.Value = DiscountAmount;


            SqlParameter PrmTariffId = new SqlParameter();
            PrmTariffId.ParameterName = "@TariffId";
            PrmTariffId.Direction = ParameterDirection.Input;
            PrmTariffId.SqlDbType = SqlDbType.Int;
            PrmTariffId.Value = TariffId;

            SqlParameter PrmTariffName = new SqlParameter();
            PrmTariffName.ParameterName = "@TariffName";
            PrmTariffName.Direction = ParameterDirection.Input;
            PrmTariffName.SqlDbType = SqlDbType.NVarChar;
            PrmTariffName.Value = TariffName;

            SqlParameter PrmTariffAmount = new SqlParameter();
            PrmTariffAmount.ParameterName = "@TariffAmount";
            PrmTariffAmount.Direction = ParameterDirection.Input;
            PrmTariffAmount.SqlDbType = SqlDbType.Int;
            PrmTariffAmount.Value = TariffAmount;


            SqlParameter PrmPaid = new SqlParameter();
            PrmPaid.ParameterName = "@Paid";
            PrmPaid.Direction = ParameterDirection.Input;
            PrmPaid.SqlDbType = SqlDbType.Bit;
            PrmPaid.Value = Paid;

            SqlParameter PrmDescription = new SqlParameter();
            PrmDescription.ParameterName = "@Description";
            PrmDescription.Direction = ParameterDirection.Input;
            PrmDescription.SqlDbType = SqlDbType.NVarChar;
            PrmDescription.Value = Description;

            SqlParameter PrmTenantId = new SqlParameter();
            PrmTenantId.ParameterName = "@TenantId";
            PrmTenantId.Direction = ParameterDirection.Input;
            PrmTenantId.SqlDbType = SqlDbType.Int;
            PrmTenantId.Value = TenantId;


            SqlParameter PrmTenantCode = new SqlParameter();
            PrmTenantCode.ParameterName = "@TenantCode";
            PrmTenantCode.Direction = ParameterDirection.Input;
            PrmTenantCode.SqlDbType = SqlDbType.Int;
            PrmTenantCode.Value = TenantCode;

            SqlParameter PrmTenantName = new SqlParameter();
            PrmTenantName.ParameterName = "@TenantName";
            PrmTenantName.Direction = ParameterDirection.Input;
            PrmTenantName.SqlDbType = SqlDbType.NVarChar;
            PrmTenantName.Value = TenantName;

            SqlParameter PrmType = new SqlParameter();
            PrmType.ParameterName = "@Type";
            PrmType.Direction = ParameterDirection.Input;
            PrmType.SqlDbType = SqlDbType.VarChar;
            PrmType.Value = Type;


            SqlParameter PrmBalance = new SqlParameter();
            PrmBalance.ParameterName = "@Balance";
            PrmBalance.Direction = ParameterDirection.Input;
            PrmBalance.SqlDbType = SqlDbType.Int;
            PrmBalance.Value = Balance;

            SqlParameter PrmDebtCeiling = new SqlParameter();
            PrmDebtCeiling.ParameterName = "@DebtCeiling";
            PrmDebtCeiling.Direction = ParameterDirection.Input;
            PrmDebtCeiling.SqlDbType = SqlDbType.Int;
            PrmDebtCeiling.Value = DebtCeiling;

            SqlParameter PrmSent = new SqlParameter();
            PrmSent.ParameterName = "@Sent";
            PrmSent.Direction = ParameterDirection.Input;
            PrmSent.SqlDbType = SqlDbType.Bit;
            PrmSent.Value = Sent;

            SqlParameter PrmStructureAddress = new SqlParameter();
            PrmStructureAddress.ParameterName = "@StructureAddress";
            PrmStructureAddress.Direction = ParameterDirection.Input;
            PrmStructureAddress.SqlDbType = SqlDbType.NVarChar;
            PrmStructureAddress.Value = StructureAddress;



            DbConn.Open();

            SqlCommand SCmd = new SqlCommand();
            SqlDataAdapter da = new SqlDataAdapter();
            SCmd.Connection = DbConn;
            SCmd.CommandType = CommandType.StoredProcedure;
            SCmd.CommandTimeout = 120000000;

            SCmd.CommandText = "[dbo].[InsertTodayData]";

            SCmd.Parameters.Add(PrmId);
            SCmd.Parameters.Add(PrmDate);
            SCmd.Parameters.Add(PrmMarketScheduleDetailId);
            SCmd.Parameters.Add(PrmWeekDay);
            SCmd.Parameters.Add(PrmMarketScheduleName);
            SCmd.Parameters.Add(PrmCustomerId);
            SCmd.Parameters.Add(PrmMobileNumber);
            SCmd.Parameters.Add(PrmCustomerCode);
            SCmd.Parameters.Add(PrmNationalCode);
            SCmd.Parameters.Add(PrmFirstName);
            SCmd.Parameters.Add(PrmLastName);
            SCmd.Parameters.Add(PrmCustomerName);
            SCmd.Parameters.Add(PrmGender);
            SCmd.Parameters.Add(PrmCardCode);
            SCmd.Parameters.Add(PrmJobId);
            SCmd.Parameters.Add(PrmJobName);
            SCmd.Parameters.Add(PrmJobGroupId);
            SCmd.Parameters.Add(PrmJobGroupName);
            SCmd.Parameters.Add(PrmShopId);
            SCmd.Parameters.Add(PrmShopCode);
            SCmd.Parameters.Add(PrmShopName);
            SCmd.Parameters.Add(PrmShopIdentifier);
            SCmd.Parameters.Add(PrmShopTypeId);
            SCmd.Parameters.Add(PrmShopTypeName);
            SCmd.Parameters.Add(PrmShopGroupId);
            SCmd.Parameters.Add(PrmShopGroupName);
            SCmd.Parameters.Add(PrmMarketStructureId);
            SCmd.Parameters.Add(PrmMarketStructureCode);
            SCmd.Parameters.Add(PrmMarketStructureName);
            SCmd.Parameters.Add(PrmMarketStructureTypeId);
            SCmd.Parameters.Add(PrmMarketStructureTypeName);
            SCmd.Parameters.Add(PrmAmount);
            SCmd.Parameters.Add(PrmDiscountId);
            SCmd.Parameters.Add(PrmDiscountName);
            SCmd.Parameters.Add(PrmDiscountPercent);
            SCmd.Parameters.Add(PrmDiscountAmount);
            SCmd.Parameters.Add(PrmTariffId);
            SCmd.Parameters.Add(PrmTariffName);
            SCmd.Parameters.Add(PrmTariffAmount);
            SCmd.Parameters.Add(PrmPaid);
            SCmd.Parameters.Add(PrmDescription);
            SCmd.Parameters.Add(PrmTenantId);
            SCmd.Parameters.Add(PrmTenantCode);
            SCmd.Parameters.Add(PrmTenantName);
            SCmd.Parameters.Add(PrmType);
            SCmd.Parameters.Add(PrmBalance);
            SCmd.Parameters.Add(PrmDebtCeiling);
            SCmd.Parameters.Add(PrmSent);
            SCmd.Parameters.Add(PrmStructureAddress);


            Result = SCmd.ExecuteScalar().ToString();


            DbConn.Close();


            return Result;
        }

        public static DataTable GetCardCodeData(string CardCode)
        {

            GenerateAttendanceConnectionString();

            DataTable dt = new DataTable();

            SqlConnection DbConn = new SqlConnection();
            DbConn.ConnectionString = AttendanceConnectionString;

            SqlParameter PrmCardCode = new SqlParameter();
            PrmCardCode.ParameterName = "@CardCode";
            PrmCardCode.Direction = ParameterDirection.Input;
            PrmCardCode.SqlDbType = SqlDbType.VarChar;
            PrmCardCode.Value = CardCode;

            DbConn.Open();

            SqlCommand SCmd = new SqlCommand();
            SqlDataAdapter da = new SqlDataAdapter();
            SCmd.Connection = DbConn;
            SCmd.CommandType = CommandType.StoredProcedure;
            SCmd.CommandTimeout = 120000000;

            SCmd.CommandText = "[dbo].[GetCardCodeData]";

            SCmd.Parameters.Add(PrmCardCode);

            da.SelectCommand = SCmd;
            da.Fill(dt);

            DbConn.Close();

            return dt;

        }

        public static DataTable GetNationalCodeData(string NationalCode)
        {

            GenerateAttendanceConnectionString();

            DataTable dt = new DataTable();

            SqlConnection DbConn = new SqlConnection();
            DbConn.ConnectionString = AttendanceConnectionString;

            SqlParameter PrmNationalCode = new SqlParameter();
            PrmNationalCode.ParameterName = "@NationalCode";
            PrmNationalCode.Direction = ParameterDirection.Input;
            PrmNationalCode.SqlDbType = SqlDbType.VarChar;
            PrmNationalCode.Value = NationalCode;

            DbConn.Open();

            SqlCommand SCmd = new SqlCommand();
            SqlDataAdapter da = new SqlDataAdapter();
            SCmd.Connection = DbConn;
            SCmd.CommandType = CommandType.StoredProcedure;
            SCmd.CommandTimeout = 120000000;

            SCmd.CommandText = "[dbo].[GetNationalCodeData]";

            SCmd.Parameters.Add(PrmNationalCode);

            da.SelectCommand = SCmd;
            da.Fill(dt);

            DbConn.Close();

            return dt;

        }

        public static DataTable SaveAttendance(string Ids,bool Credit)
        {

            GenerateAttendanceConnectionString();

            DataTable dt = new DataTable();

            SqlConnection DbConn = new SqlConnection();
            DbConn.ConnectionString = AttendanceConnectionString;

            SqlParameter PrmId = new SqlParameter();
            PrmId.ParameterName = "@Ids";
            PrmId.Direction = ParameterDirection.Input;
            PrmId.SqlDbType = SqlDbType.VarChar;
            PrmId.Value = Ids;

            SqlParameter PrmCredit = new SqlParameter();
            PrmCredit.ParameterName = "@Credit";
            PrmCredit.Direction = ParameterDirection.Input;
            PrmCredit.SqlDbType = SqlDbType.Bit;
            PrmCredit.Value = Credit;

            DbConn.Open();

            SqlCommand SCmd = new SqlCommand();
            SqlDataAdapter da = new SqlDataAdapter();
            SCmd.Connection = DbConn;
            SCmd.CommandType = CommandType.StoredProcedure;
            SCmd.CommandTimeout = 120000000;

            SCmd.CommandText = "[dbo].[SaveAttendance]";

            SCmd.Parameters.Add(PrmId);
            SCmd.Parameters.Add(PrmCredit);

            da.SelectCommand = SCmd;
            da.Fill(dt);

            DbConn.Close();

            return dt;

        }

        public static DataTable InsertCredit(int Id,int Amount,string ReceiptNumber)
        {

            GenerateAttendanceConnectionString();

            DataTable dt = new DataTable();

            SqlConnection DbConn = new SqlConnection();
            DbConn.ConnectionString = AttendanceConnectionString;

            SqlParameter PrmId = new SqlParameter();
            PrmId.ParameterName = "@Id";
            PrmId.Direction = ParameterDirection.Input;
            PrmId.SqlDbType = SqlDbType.Int;
            PrmId.Value = Id;

            SqlParameter PrmAmount = new SqlParameter();
            PrmAmount.ParameterName = "@Amount";
            PrmAmount.Direction = ParameterDirection.Input;
            PrmAmount.SqlDbType = SqlDbType.Int;
            PrmAmount.Value = Amount;

            SqlParameter PrmReceiptNumber = new SqlParameter();
            PrmReceiptNumber.ParameterName = "@ReceiptNumber";
            PrmReceiptNumber.Direction = ParameterDirection.Input;
            PrmReceiptNumber.SqlDbType = SqlDbType.NVarChar;
            PrmReceiptNumber.Value = ReceiptNumber;

            DbConn.Open();

            SqlCommand SCmd = new SqlCommand();
            SqlDataAdapter da = new SqlDataAdapter();
            SCmd.Connection = DbConn;
            SCmd.CommandType = CommandType.StoredProcedure;
            SCmd.CommandTimeout = 120000000;

            SCmd.CommandText = "[dbo].[InsertCredit]";

            SCmd.Parameters.Add(PrmId);
            SCmd.Parameters.Add(PrmAmount);
            SCmd.Parameters.Add(PrmReceiptNumber);

            da.SelectCommand = SCmd;
            da.Fill(dt);

            DbConn.Close();

            return dt;

        }

        public static DataTable GetAttendanceForSend()
        {

            GenerateAttendanceConnectionString();

            DataTable dt = new DataTable();

            SqlConnection DbConn = new SqlConnection();
            DbConn.ConnectionString = AttendanceConnectionString;

            DbConn.Open();

            SqlCommand SCmd = new SqlCommand();
            SqlDataAdapter da = new SqlDataAdapter();
            SCmd.Connection = DbConn;
            SCmd.CommandType = CommandType.StoredProcedure;
            SCmd.CommandTimeout = 120000000;

            SCmd.CommandText = "[dbo].[GetAttendanceForSend]";

            da.SelectCommand = SCmd;
            da.Fill(dt);

            DbConn.Close();

            return dt;

        }

        public static DataTable GetCreditForSend()
        {

            GenerateAttendanceConnectionString();

            DataTable dt = new DataTable();

            SqlConnection DbConn = new SqlConnection();
            DbConn.ConnectionString = AttendanceConnectionString;

            DbConn.Open();

            SqlCommand SCmd = new SqlCommand();
            SqlDataAdapter da = new SqlDataAdapter();
            SCmd.Connection = DbConn;
            SCmd.CommandType = CommandType.StoredProcedure;
            SCmd.CommandTimeout = 120000000;

            SCmd.CommandText = "[dbo].[GetCreditForSend]";

            da.SelectCommand = SCmd;
            da.Fill(dt);

            DbConn.Close();

            return dt;

        }

        public static int ConfirmAttendanceSend(int AttendanceId)
        {
            int Result = 0;

            GenerateAttendanceConnectionString();

            SqlConnection DbConn = new SqlConnection();
            DbConn.ConnectionString = AttendanceConnectionString;

            SqlParameter PrmId = new SqlParameter();
            PrmId.ParameterName = "@AttendanceId";
            PrmId.Direction = ParameterDirection.Input;
            PrmId.SqlDbType = SqlDbType.Int;
            PrmId.Value = AttendanceId;

            
            DbConn.Open();

            SqlCommand SCmd = new SqlCommand();
            SqlDataAdapter da = new SqlDataAdapter();
            SCmd.Connection = DbConn;
            SCmd.CommandType = CommandType.StoredProcedure;
            SCmd.CommandTimeout = 120000000;

            SCmd.CommandText = "[dbo].[ConfirmAttendanceSend]";

            SCmd.Parameters.Add(PrmId);
            
            Result = Convert.ToInt32(SCmd.ExecuteScalar().ToString());


            DbConn.Close();


            return Result;
        }

        public static int ConfirmCreditSend(int CreditId)
        {
            int Result = 0;

            GenerateAttendanceConnectionString();

            SqlConnection DbConn = new SqlConnection();
            DbConn.ConnectionString = AttendanceConnectionString;

            SqlParameter PrmId = new SqlParameter();
            PrmId.ParameterName = "@CreditId";
            PrmId.Direction = ParameterDirection.Input;
            PrmId.SqlDbType = SqlDbType.Int;
            PrmId.Value = CreditId;


            DbConn.Open();

            SqlCommand SCmd = new SqlCommand();
            SqlDataAdapter da = new SqlDataAdapter();
            SCmd.Connection = DbConn;
            SCmd.CommandType = CommandType.StoredProcedure;
            SCmd.CommandTimeout = 120000000;

            SCmd.CommandText = "[dbo].[ConfirmCreditSend]";

            SCmd.Parameters.Add(PrmId);

            Result = Convert.ToInt32(SCmd.ExecuteScalar().ToString());


            DbConn.Close();


            return Result;
        }


        public static int InsertAttendanceFromApp(int AttendanceId,int CustomerId,int ShopId,string Date,int MarketScheduleDetailId,string Type,string Time)
        {
            int Result = 0;

            GenerateServerConnectionString();

            SqlConnection DbConn = new SqlConnection();
            DbConn.ConnectionString = ServerConnectionString;

            SqlParameter PrmAttendanceId = new SqlParameter();
            PrmAttendanceId.ParameterName = "@AttendanceId";
            PrmAttendanceId.Direction = ParameterDirection.Input;
            PrmAttendanceId.SqlDbType = SqlDbType.Int;
            PrmAttendanceId.Value = AttendanceId;

            SqlParameter PrmCustomerId = new SqlParameter();
            PrmCustomerId.ParameterName = "@CustomerId";
            PrmCustomerId.Direction = ParameterDirection.Input;
            PrmCustomerId.SqlDbType = SqlDbType.Int;
            PrmCustomerId.Value = CustomerId;

            SqlParameter PrmShopId = new SqlParameter();
            PrmShopId.ParameterName = "@ShopId";
            PrmShopId.Direction = ParameterDirection.Input;
            PrmShopId.SqlDbType = SqlDbType.Int;
            PrmShopId.Value = ShopId;

            SqlParameter PrmDate = new SqlParameter();
            PrmDate.ParameterName = "@Date";
            PrmDate.Direction = ParameterDirection.Input;
            PrmDate.SqlDbType = SqlDbType.VarChar;
            PrmDate.Value = Date;

            SqlParameter PrmMarketScheduleDetailId = new SqlParameter();
            PrmMarketScheduleDetailId.ParameterName = "@MarketScheduleDetailId";
            PrmMarketScheduleDetailId.Direction = ParameterDirection.Input;
            PrmMarketScheduleDetailId.SqlDbType = SqlDbType.Int;
            PrmMarketScheduleDetailId.Value = MarketScheduleDetailId;

            SqlParameter PrmType = new SqlParameter();
            PrmType.ParameterName = "@Type";
            PrmType.Direction = ParameterDirection.Input;
            PrmType.SqlDbType = SqlDbType.VarChar;
            PrmType.Value = Type;

            SqlParameter PrmTime = new SqlParameter();
            PrmTime.ParameterName = "@Time";
            PrmTime.Direction = ParameterDirection.Input;
            PrmTime.SqlDbType = SqlDbType.VarChar;
            PrmTime.Value = Time;


            DbConn.Open();

            SqlCommand SCmd = new SqlCommand();
            SqlDataAdapter da = new SqlDataAdapter();
            SCmd.Connection = DbConn;
            SCmd.CommandType = CommandType.StoredProcedure;
            SCmd.CommandTimeout = 120000000;

            SCmd.CommandText = "[Mrk].[InsertAttendanceFromApp]";

            SCmd.Parameters.Add(PrmAttendanceId);
            SCmd.Parameters.Add(PrmCustomerId);
            SCmd.Parameters.Add(PrmShopId);
            SCmd.Parameters.Add(PrmDate);
            SCmd.Parameters.Add(PrmMarketScheduleDetailId);
            SCmd.Parameters.Add(PrmType);
            SCmd.Parameters.Add(PrmTime);

            Result = Convert.ToInt32(SCmd.ExecuteScalar().ToString());


            DbConn.Close();


            return Result;
        }

        public static int InsertCreditFromApp(int CreditId, int CustomerId,  string Date, int PaymentTypeId,int Amount,bool Type,string ReceiptNumber,string Description,int AttendanceId)
        {
            int Result = 0;

            GenerateServerConnectionString();

            SqlConnection DbConn = new SqlConnection();
            DbConn.ConnectionString = ServerConnectionString;

            SqlParameter PrmCreditId = new SqlParameter();
            PrmCreditId.ParameterName = "@CreditId";
            PrmCreditId.Direction = ParameterDirection.Input;
            PrmCreditId.SqlDbType = SqlDbType.Int;
            PrmCreditId.Value = CreditId;

            SqlParameter PrmCustomerId = new SqlParameter();
            PrmCustomerId.ParameterName = "@CustomerId";
            PrmCustomerId.Direction = ParameterDirection.Input;
            PrmCustomerId.SqlDbType = SqlDbType.Int;
            PrmCustomerId.Value = CustomerId;

            SqlParameter PrmDate = new SqlParameter();
            PrmDate.ParameterName = "@Date";
            PrmDate.Direction = ParameterDirection.Input;
            PrmDate.SqlDbType = SqlDbType.VarChar;
            PrmDate.Value = Date;

            SqlParameter PrmPaymentTypeId = new SqlParameter();
            PrmPaymentTypeId.ParameterName = "@PaymentTypeId";
            PrmPaymentTypeId.Direction = ParameterDirection.Input;
            PrmPaymentTypeId.SqlDbType = SqlDbType.Int;
            PrmPaymentTypeId.Value = PaymentTypeId;

            SqlParameter PrmAmount = new SqlParameter();
            PrmAmount.ParameterName = "@Amount";
            PrmAmount.Direction = ParameterDirection.Input;
            PrmAmount.SqlDbType = SqlDbType.Int;
            PrmAmount.Value = Amount;

            SqlParameter PrmType = new SqlParameter();
            PrmType.ParameterName = "@Type";
            PrmType.Direction = ParameterDirection.Input;
            PrmType.SqlDbType = SqlDbType.Bit;
            PrmType.Value = Type;

            SqlParameter PrmReceiptNumber = new SqlParameter();
            PrmReceiptNumber.ParameterName = "@ReceiptNumber";
            PrmReceiptNumber.Direction = ParameterDirection.Input;
            PrmReceiptNumber.SqlDbType = SqlDbType.NVarChar;
            PrmReceiptNumber.Value = ReceiptNumber;

            SqlParameter PrmDescription = new SqlParameter();
            PrmDescription.ParameterName = "@Description";
            PrmDescription.Direction = ParameterDirection.Input;
            PrmDescription.SqlDbType = SqlDbType.NVarChar;
            PrmDescription.Value = Description;

            SqlParameter PrmAttendanceId = new SqlParameter();
            PrmAttendanceId.ParameterName = "@AttendanceId";
            PrmAttendanceId.Direction = ParameterDirection.Input;
            PrmAttendanceId.SqlDbType = SqlDbType.Int;
            PrmAttendanceId.Value = AttendanceId;

            DbConn.Open();

            SqlCommand SCmd = new SqlCommand();
            SqlDataAdapter da = new SqlDataAdapter();
            SCmd.Connection = DbConn;
            SCmd.CommandType = CommandType.StoredProcedure;
            SCmd.CommandTimeout = 120000000;

            SCmd.CommandText = "[Mrk].[InsertCreditFromApp]";

            SCmd.Parameters.Add(PrmCreditId);
            SCmd.Parameters.Add(PrmCustomerId);
            SCmd.Parameters.Add(PrmDate);
            SCmd.Parameters.Add(PrmPaymentTypeId);
            SCmd.Parameters.Add(PrmAmount);
            SCmd.Parameters.Add(PrmType);
            SCmd.Parameters.Add(PrmReceiptNumber);
            SCmd.Parameters.Add(PrmDescription);
            SCmd.Parameters.Add(PrmAttendanceId);

            Result = Convert.ToInt32(SCmd.ExecuteScalar().ToString());


            DbConn.Close();


            return Result;
        }

        public static DataTable GetReceipt(string Ids)
        {

            GenerateAttendanceConnectionString();

            DataTable dt = new DataTable();

            SqlConnection DbConn = new SqlConnection();
            DbConn.ConnectionString = AttendanceConnectionString;

            SqlParameter PrmId = new SqlParameter();
            PrmId.ParameterName = "@Ids";
            PrmId.Direction = ParameterDirection.Input;
            PrmId.SqlDbType = SqlDbType.VarChar;
            PrmId.Value = Ids;

            DbConn.Open();

            SqlCommand SCmd = new SqlCommand();
            SqlDataAdapter da = new SqlDataAdapter();
            SCmd.Connection = DbConn;
            SCmd.CommandType = CommandType.StoredProcedure;
            SCmd.CommandTimeout = 120000000;

            SCmd.CommandText = "[dbo].[GetReceipt]";

            SCmd.Parameters.Add(PrmId);

            da.SelectCommand = SCmd;
            da.Fill(dt);

            DbConn.Close();

            return dt;

        }

        public static DataTable GetServerPrintTemplate(string Code)
        {

            GenerateServerConnectionString();

            DataTable dt = new DataTable();

            SqlConnection DbConn = new SqlConnection();
            DbConn.ConnectionString = ServerConnectionString;

            SqlParameter PrmCode = new SqlParameter();
            PrmCode.ParameterName = "@Code";
            PrmCode.Direction = ParameterDirection.Input;
            PrmCode.SqlDbType = SqlDbType.NVarChar;
            PrmCode.Value = Code;

            DbConn.Open();

            SqlCommand SCmd = new SqlCommand();
            SqlDataAdapter da = new SqlDataAdapter();
            SCmd.Connection = DbConn;
            SCmd.CommandType = CommandType.StoredProcedure;
            SCmd.CommandTimeout = 120000000;

            SCmd.CommandText = "[Gnr].[GetPrintTemplate]";

            SCmd.Parameters.Add(PrmCode);

            da.SelectCommand = SCmd;
            da.Fill(dt);

            DbConn.Close();

            return dt;

        }

        public static int InsertPrintTemplate(string Code, string Name, string Content)
        {
            int Result = 0;

            GenerateAttendanceConnectionString();

            SqlConnection DbConn = new SqlConnection();
            DbConn.ConnectionString = AttendanceConnectionString;

            SqlParameter PrmCode = new SqlParameter();
            PrmCode.ParameterName = "@Code";
            PrmCode.Direction = ParameterDirection.Input;
            PrmCode.SqlDbType = SqlDbType.NVarChar;
            PrmCode.Value = Code;

            SqlParameter PrmName = new SqlParameter();
            PrmName.ParameterName = "@Name";
            PrmName.Direction = ParameterDirection.Input;
            PrmName.SqlDbType = SqlDbType.NVarChar;
            PrmName.Value = Name;

            SqlParameter PrmContent = new SqlParameter();
            PrmContent.ParameterName = "@Content";
            PrmContent.Direction = ParameterDirection.Input;
            PrmContent.SqlDbType = SqlDbType.NVarChar;
            PrmContent.Value = Content;

            
            DbConn.Open();

            SqlCommand SCmd = new SqlCommand();
            SqlDataAdapter da = new SqlDataAdapter();
            SCmd.Connection = DbConn;
            SCmd.CommandType = CommandType.StoredProcedure;
            SCmd.CommandTimeout = 120000000;

            SCmd.CommandText = "[dbo].[InsertPrintTemplate]";

            SCmd.Parameters.Add(PrmCode);
            SCmd.Parameters.Add(PrmName);
            SCmd.Parameters.Add(PrmContent);
            
            Result = Convert.ToInt32(SCmd.ExecuteScalar().ToString());


            DbConn.Close();


            return Result;
        }

        public static DataTable GetPrintTemplate(string Code)
        {

            GenerateAttendanceConnectionString();

            DataTable dt = new DataTable();

            SqlConnection DbConn = new SqlConnection();
            DbConn.ConnectionString = AttendanceConnectionString;

            SqlParameter PrmCode = new SqlParameter();
            PrmCode.ParameterName = "@Code";
            PrmCode.Direction = ParameterDirection.Input;
            PrmCode.SqlDbType = SqlDbType.NVarChar;
            PrmCode.Value = Code;

            DbConn.Open();

            SqlCommand SCmd = new SqlCommand();
            SqlDataAdapter da = new SqlDataAdapter();
            SCmd.Connection = DbConn;
            SCmd.CommandType = CommandType.StoredProcedure;
            SCmd.CommandTimeout = 120000000;

            SCmd.CommandText = "[dbo].[GetPrintTemplate]";

            SCmd.Parameters.Add(PrmCode);

            da.SelectCommand = SCmd;
            da.Fill(dt);

            DbConn.Close();

            return dt;

        }
    }


}
