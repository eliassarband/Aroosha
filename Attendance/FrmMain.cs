using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using Attendance.Classes;
using System.Runtime.InteropServices;
using System.IO;
using ArooshaPOS;
using Stimulsoft.Report;

namespace Attendance
{

    public partial class FrmMain : Telerik.WinControls.UI.RadForm
    {

        long Count = 0;
        long GetCount = 0;
        int Counter = 1;
        public FrmMain()
        {
            InitializeComponent();
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            CheckDatabaseConnection();

            timer_Req.Interval = Convert.ToInt32(DBConnect.GetKeyValue("CardReaderTimerInterval")); 
            timer_Time.Enabled = true;
            timer_Req.Enabled = true;

        }

        protected void CheckDatabaseConnection()
        {
            if (!DBConnect.CheckServerDBConnection())
            {
                LblServerConnectionStatus.Text = "ارتباط با بانک اطلاعاتی سرور مقدور نمی باشد";
            }
            else
            {
                LblServerConnectionStatus.Text = "";
            }

            if(!DBConnect.CheckAttendanceDBConnection())
            {
                LblAttendanceConnectionStatus.Text = "ارتباط با بانک اطلاعاتی محلی مقدور نمی باشد";
            }
            else
            {
                LblAttendanceConnectionStatus.Text = "";
            }
        
        }

        protected void SendDate()
        {
            
            

            if (DBConnect.CheckServerDBConnection())
            {
                if (DBConnect.CheckAttendanceDBConnection())
                {
                    DataTable dtA = DBConnect.GetAttendanceForSend();
                    DataTable dtC = DBConnect.GetCreditForSend();

                    int AttendanceSuccess = 0, AttendanceFaild = 0, CreditSuccess = 0, CreditFaild = 0;

                    foreach (DataRow dr in dtA.Rows)
                    {
                        PrgSendReceive.Minimum = 0;
                        PrgSendReceive.Maximum = dtA.Rows.Count;
                        PrgSendReceive.Text = "درحال ارسال اطلاعات ...";

                        if (DBConnect.InsertAttendanceFromApp(Convert.ToInt32(dr["Id"].ToString()), Convert.ToInt32(dr["CustomerId"].ToString()), Convert.ToInt32(dr["ShopId"].ToString()), dr["Date"].ToString(), Convert.ToInt32(dr["MarketScheduleDetailId"].ToString()), dr["Type"].ToString(), dr["Time"].ToString()) == 1)
                        {
                            if (DBConnect.ConfirmAttendanceSend(Convert.ToInt32(dr["Id"].ToString())) == 1)
                                ++AttendanceSuccess;
                            else
                                ++AttendanceFaild;
                        }

                        PrgSendReceive.Value1 = AttendanceSuccess+AttendanceFaild;
                        PrgSendReceive.Refresh();
                     
                    }

                    foreach (DataRow dr in dtC.Rows)
                    {
                        if (DBConnect.InsertCreditFromApp(Convert.ToInt32(dr["Id"].ToString()), Convert.ToInt32(dr["CustomerIdId"].ToString()), dr["Date"].ToString(), Convert.ToInt32(dr["PaymentTypeId"].ToString()), Convert.ToInt32(dr["Amount"].ToString()), Convert.ToBoolean(dr["Type"]), dr["ReceiptNumber"].ToString(), dr["Description"].ToString(), Convert.ToInt32(dr["AttendanceId"].ToString())) == 1)
                        {
                            if (DBConnect.ConfirmCreditSend(Convert.ToInt32(dr["Id"].ToString())) == 1)
                                ++CreditSuccess;
                            else
                                ++CreditFaild;
                        }
                    }

                    string AttendanceMessage = "از تعداد " + dtA.Rows.Count.ToString() + " تردد ثبت شده ، تعداد " + AttendanceSuccess.ToString() + " تردد با موفقیت به سرور ارسال و تعداد " + AttendanceFaild.ToString() + " تردد با خطا مواجه گردید.";

                    string CreditMessage = "از تعداد " + dtC.Rows.Count.ToString() + " پرداخت ثبت شده ، تعداد " + CreditSuccess.ToString() + " پرداخت با موفقیت به سرور ارسال و تعداد " + CreditFaild.ToString() + " پرداخت با خطا مواجه گردید.";


                    MessageBox.Show(AttendanceMessage, "ارسال اطلاعات تردد", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    MessageBox.Show(CreditMessage, "ارسال اطلاعات پرداخت", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("ارتباط با بانک اطلاعاتی محلی قطع می باشد", "ارتباط با بانک اطلاعاتی", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("ارتباط با بانک اطلاعاتی سرور قطع می باشد", "ارتباط با بانک اطلاعاتی", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            PrgSendReceive.Value1 = 0;
            PrgSendReceive.Text = "";

        }

        private void BtnSendData_Click(object sender, EventArgs e)
        {
            
            timer_Time.Enabled = false;
            timer_Req.Enabled = false;

            SendDate();
                        
            timer_Time.Enabled = true;
            timer_Req.Enabled = true;
        }

     
        protected void GetData()
        {

           

            if (DBConnect.CheckServerDBConnection())
            {
                if (DBConnect.CheckAttendanceDBConnection())
                {
                    DataTable dt = new DataTable();
                    dt = DBConnect.GetTodayData(null);

                    string Result = "warning";

                    int TotalRecord = 0;
                    int SuccessRecord = 0;
                    int ErrorRecord = 0;

                    if (dt.Rows.Count > 0)
                    {
                        TotalRecord = dt.Rows.Count;

                        PrgSendReceive.Minimum = 0;
                        PrgSendReceive.Maximum = TotalRecord;
                        PrgSendReceive.Text = "درحال دریافت اطلاعات ...";

                        for (int i = 0; i < dt.Rows.Count; ++i)
                        {
                            try
                            {
                                Result = DBConnect.InsertTodayData(Convert.ToInt32(dt.Rows[i]["Id"]), dt.Rows[i]["Date"].ToString(), Convert.ToInt32(dt.Rows[i]["MarketScheduleDetailId"]), Convert.ToInt32(dt.Rows[i]["WeekDay"]), dt.Rows[i]["MarketScheduleName"].ToString(), Convert.ToInt32(dt.Rows[i]["CustomerId"]), dt.Rows[i]["MobileNumber"].ToString(), Convert.ToInt32(dt.Rows[i]["CustomerCode"]), dt.Rows[i]["NationalCode"].ToString(), dt.Rows[i]["FirstName"].ToString(), dt.Rows[i]["LastName"].ToString(), dt.Rows[i]["CustomerName"].ToString(), Convert.ToBoolean(dt.Rows[i]["Gender"]), dt.Rows[i]["CardCode"].ToString(), Convert.ToInt32(dt.Rows[i]["JobId"]), dt.Rows[i]["JobName"].ToString(), Convert.ToInt32(dt.Rows[i]["JobGroupId"]), dt.Rows[i]["JobGroupName"].ToString(), Convert.ToInt32(dt.Rows[i]["ShopId"]), Convert.ToInt32(dt.Rows[i]["ShopCode"]), dt.Rows[i]["ShopName"].ToString(), dt.Rows[i]["ShopIdentifier"].ToString(), Convert.ToInt32(dt.Rows[i]["ShopTypeId"]), dt.Rows[i]["ShopTypeName"].ToString(), Convert.ToInt32(dt.Rows[i]["ShopGroupId"]), dt.Rows[i]["ShopGroupName"].ToString(), Convert.ToInt32(dt.Rows[i]["MarketStructureId"]), Convert.ToInt32(dt.Rows[i]["MarketStructureCode"]), dt.Rows[i]["MarketStructureName"].ToString(), Convert.ToInt32(dt.Rows[i]["MarketStructureTypeId"]), dt.Rows[i]["MarketStructureTypeName"].ToString(), Convert.ToInt32(dt.Rows[i]["Amount"]), Convert.ToInt32(dt.Rows[i]["DiscountId"]), dt.Rows[i]["DiscountName"].ToString(), Convert.ToInt32(dt.Rows[i]["DiscountPercent"]), Convert.ToInt32(dt.Rows[i]["DiscountAmount"]), Convert.ToInt32(dt.Rows[i]["TariffId"]), dt.Rows[i]["TariffName"].ToString(), Convert.ToInt32(dt.Rows[i]["TariffAmount"]), Convert.ToBoolean(dt.Rows[i]["Paid"]), dt.Rows[i]["Description"].ToString(), Convert.ToInt32(dt.Rows[i]["TenantId"]), Convert.ToInt32(dt.Rows[i]["TenantCode"]), dt.Rows[i]["TenantName"].ToString(), dt.Rows[i]["Type"].ToString(), Convert.ToInt32(dt.Rows[i]["Balance"]), Convert.ToInt32(dt.Rows[i]["DebtCeiling"]), false, dt.Rows[i]["StructureAddress"].ToString());
                                
                                if (Result == "success")
                                    ++SuccessRecord;
                                else
                                    ++ErrorRecord;
                            }
                            catch (Exception ex)
                            {
                                ++ErrorRecord;
                            }

                            
                            
                           
                        }
                    }

                    MessageBox.Show("از تعداد " + TotalRecord.ToString() + " رکورد دریافتی، تعداد " + SuccessRecord.ToString() + " با موفقیت دریافت و تعداد " + ErrorRecord.ToString() + " با خطا مواجه گردید");

                    

                    DataTable dtP = new DataTable();
                    dtP = DBConnect.GetServerPrintTemplate("RentReceipt");
                    int Received = 0;

                    if (dtP.Rows.Count == 1)
                    {
                        if (Convert.ToInt32(DBConnect.InsertPrintTemplate(dtP.Rows[0]["Code"].ToString(), dtP.Rows[0]["Name"].ToString(), dtP.Rows[0]["Content"].ToString())) == 1)
                            Received = 1;
                    }

                    MessageBox.Show("تعداد  " + Received.ToString() + " عدد فرمت رسید اجاره دریافت گردید");

                }
                else
                {
                    MessageBox.Show("ارتباط با بانک اطلاعاتی محلی قطع می باشد", "ارتباط با بانک اطلاعاتی", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    //MessageBox.Show(DBConnect.CheckAttendanceDBConnectionResult());
                }
            }
            else
            {
                MessageBox.Show("ارتباط با بانک اطلاعاتی سرور قطع می باشد", "ارتباط با بانک اطلاعاتی", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //MessageBox.Show(DBConnect.CheckServerDBConnectionResult());
            }

            PrgSendReceive.Value1 = 0;
            PrgSendReceive.Text = "";

            
            

        }

        private void BtnGetData_Click(object sender, EventArgs e)
        {
       
            timer_Time.Enabled = false;
            timer_Req.Enabled = false;

            GetData();

            timer_Time.Enabled = true;
            timer_Req.Enabled = true;
        }

        private void BindGrid(string CardCode, string NationalCode)
        {
            
            

            if (DBConnect.CheckAttendanceDBConnection())
            {
                if (CardCode != "")
                {
                    DataTable dt = new DataTable();
                    dt = DBConnect.GetCardCodeData(TxtCardCode.Text);

                    GrdAttendance.DataSource = dt;
                }
                else
                {
                    DataTable dt = new DataTable();
                    dt = DBConnect.GetNationalCodeData(TxtNationalCode.Text);

                    GrdAttendance.DataSource = dt;
                }
            }
            else
            {
                MessageBox.Show("ارتباط با بانک اطلاعاتی محلی قطع می باشد", "ارتباط با بانک اطلاعاتی", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void TxtCardCode_KeyDown(object sender, KeyEventArgs e)
        {
            
            timer_Time.Enabled = false;
            timer_Req.Enabled = false;

            if (e.KeyCode == Keys.Enter)
            {
                if (TxtCardCode.Text != "")
                {
                    BindGrid(TxtCardCode.Text, "");

                    TxtNationalCode.Text = "";

                }
                else
                {
                    DataTable dt = new DataTable();
                    GrdAttendance.DataSource = dt;
                }
            }
            

            timer_Time.Enabled = true;
            timer_Req.Enabled = true;

        }

        private void TxtNationalCode_KeyDown(object sender, KeyEventArgs e)
        {
            
            timer_Time.Enabled = false;
            timer_Req.Enabled = false;

            if (e.KeyCode == Keys.Enter)
            {
                if (TxtNationalCode.Text != "")
                {
                    BindGrid("", TxtNationalCode.Text);

                    TxtCardCode.Text = "";

                }
                else
                {
                    DataTable dt = new DataTable();
                    GrdAttendance.DataSource = dt;
                }
            }

            
            timer_Time.Enabled = true;
            timer_Req.Enabled = true;

        }

        private void FrmMain_KeyDown(object sender, KeyEventArgs e)
        {
            
            timer_Time.Enabled = false;
            timer_Req.Enabled = false;

            this.KeyPreview = false;

            if (e.Alt)
            {
                if (e.KeyCode == Keys.S)
                {
                    FrmDbConnectionSetting oFrm = new FrmDbConnectionSetting();
                    oFrm.ShowDialog();
                }
                else if (e.KeyCode == Keys.P)
                {
                    FrmPrinterSetting oFrm = new FrmPrinterSetting();
                    oFrm.ShowDialog();
                }
                else if (e.KeyCode == Keys.C)
                {
                    FrmPCPosSetting oFrm = new FrmPCPosSetting();
                    oFrm.ShowDialog();
                }
                else if (e.KeyCode == Keys.R)
                {
                    FrmCardReaderSetting oFrm = new FrmCardReaderSetting();
                    oFrm.ShowDialog();

                    timer_Req.Interval = Convert.ToInt32(DBConnect.GetKeyValue("CardReaderTimerInterval")); 
                                       
                }
            }
            else
            {
                if (e.KeyCode == Keys.F1)
                {
                    GetData();
                }
                else if (e.KeyCode == Keys.F2)
                {
                    SendDate();
                }
                else if (e.KeyCode == Keys.F3)
                {
                    TxtCardCode.Focus();
                }
                else if (e.KeyCode == Keys.F4)
                {
                    TxtNationalCode.Focus();
                }
                else if (e.KeyCode == Keys.F5)
                {
                    SaveAttendance();
                }
                else if (e.KeyCode == Keys.F6)
                {
                    ReadData();
                }
            }

            this.KeyPreview = true;

            
            timer_Time.Enabled = true;
            timer_Req.Enabled = true;
        }

        private void BtnSaveAttendance_Click(object sender, EventArgs e)
        {
           
            timer_Time.Enabled = false;
            timer_Req.Enabled = false;

            SaveAttendance();

            timer_Time.Enabled = true;
            timer_Req.Enabled = true;
        }

        private void SaveAttendance()
        {
            if (DBConnect.CheckServerDBConnection())
            {
                if (DBConnect.CheckAttendanceDBConnection())
                {
                    int Id = 0;
                    string Ids = "";
                    if (GrdAttendance.Rows.Count > 0)
                    {
                        for (int i = 0; i < GrdAttendance.SelectedRows.Count; ++i)
                        {
                            Ids += GrdAttendance.SelectedRows[i].Cells["Id"].Value.ToString() + ",";
                        }

                        Id = Convert.ToInt32(GrdAttendance.SelectedRows[0].Cells["Id"].Value);

                        if (MessageBox.Show("جهت ثبت تردد برای مشتری انتخاب شده مطمئن هستید؟", "ذخیره", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            DataTable dt = new DataTable();
                            dt = DBConnect.SaveAttendance(Ids, false);

                            if (dt.Rows.Count == 1)
                            {
                                switch (dt.Rows[0]["MessageType"].ToString())
                                {
                                    case "warning":
                                        MessageBox.Show(dt.Rows[0]["Message"].ToString(), "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                        break;
                                    case "error":
                                        MessageBox.Show(dt.Rows[0]["Message"].ToString(), "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        break;
                                    case "success":
                                        MessageBox.Show(dt.Rows[0]["Message"].ToString(), "ذخیره", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        if (TxtCardCode.Text != "")
                                        {
                                            BindGrid(TxtCardCode.Text, "");
                                        }
                                        else
                                        {
                                            BindGrid("", TxtNationalCode.Text);
                                        }

                                        PrintReceipt(Ids);
                                        break;
                                    case "Credit":
                                        if (MessageBox.Show("آیا مایل به افزایش اعتبار به میزان کسری " + dt.Rows[0]["Amount"].ToString() + " ریال می باشید؟", "افزایش اعتبار", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                                        {
                                            if (PCPosPayment(Id, Convert.ToInt32(dt.Rows[0]["Amount"].ToString())))
                                            {
                                                DataTable dtC = new DataTable();
                                                dtC = DBConnect.SaveAttendance(Ids, false);

                                                if (dtC.Rows.Count == 1)
                                                {
                                                    switch (dtC.Rows[0]["MessageType"].ToString())
                                                    {
                                                        case "warning":
                                                            MessageBox.Show(dtC.Rows[0]["Message"].ToString(), "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                                            break;
                                                        case "error":
                                                            MessageBox.Show(dtC.Rows[0]["Message"].ToString(), "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                                            break;
                                                        case "success":
                                                            MessageBox.Show(dtC.Rows[0]["Message"].ToString(), "ذخیره", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                                            if (TxtCardCode.Text != "")
                                                            {
                                                                BindGrid(TxtCardCode.Text, "");
                                                            }
                                                            else
                                                            {
                                                                BindGrid("", TxtNationalCode.Text);
                                                            }

                                                            PrintReceipt(Ids);
                                                            break;
                                                        default:
                                                            MessageBox.Show(dtC.Rows[0]["Message"].ToString(), "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                                            break;
                                                    }
                                                }
                                            }
                                            else
                                            {
                                                MessageBox.Show("خطا در پرداخت الکترونیک", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                                if (MessageBox.Show(dt.Rows[0]["Message"].ToString() + " ، آیا همچنان مایل به ثبت تردد مشتری انتخاب شده هستید؟", "کمبود اعتبار", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                                                {
                                                    DataTable dtC = new DataTable();
                                                    dtC = DBConnect.SaveAttendance(Ids, true);

                                                    if (dtC.Rows.Count == 1)
                                                    {
                                                        switch (dtC.Rows[0]["MessageType"].ToString())
                                                        {
                                                            case "warning":
                                                                MessageBox.Show(dtC.Rows[0]["Message"].ToString(), "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                                                break;
                                                            case "error":
                                                                MessageBox.Show(dtC.Rows[0]["Message"].ToString(), "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                                                break;
                                                            case "success":
                                                                MessageBox.Show(dtC.Rows[0]["Message"].ToString(), "ذخیره", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                                                if (TxtCardCode.Text != "")
                                                                {
                                                                    BindGrid(TxtCardCode.Text, "");
                                                                }
                                                                else
                                                                {
                                                                    BindGrid("", TxtNationalCode.Text);
                                                                }

                                                                PrintReceipt(Ids);
                                                                break;
                                                            default:
                                                                MessageBox.Show(dtC.Rows[0]["Message"].ToString(), "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                                                break;
                                                        }
                                                    }
                                                }
                                                break;
                                            }
                                        }
                                        else if (MessageBox.Show(dt.Rows[0]["Message"].ToString() + " ، آیا همچنان مایل به ثبت تردد مشتری انتخاب شده هستید؟", "کمبود اعتبار", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                                        {
                                            DataTable dtC = new DataTable();
                                            dtC = DBConnect.SaveAttendance(Ids, true);

                                            if (dtC.Rows.Count == 1)
                                            {
                                                switch (dtC.Rows[0]["MessageType"].ToString())
                                                {
                                                    case "warning":
                                                        MessageBox.Show(dtC.Rows[0]["Message"].ToString(), "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                                        break;
                                                    case "error":
                                                        MessageBox.Show(dtC.Rows[0]["Message"].ToString(), "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                                        break;
                                                    case "success":
                                                        MessageBox.Show(dtC.Rows[0]["Message"].ToString(), "ذخیره", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                                        if (TxtCardCode.Text != "")
                                                        {
                                                            BindGrid(TxtCardCode.Text, "");
                                                        }
                                                        else
                                                        {
                                                            BindGrid("", TxtNationalCode.Text);
                                                        }

                                                        PrintReceipt(Ids);
                                                        break;
                                                    default:
                                                        MessageBox.Show(dtC.Rows[0]["Message"].ToString(), "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                                        break;
                                                }
                                            }
                                        }
                                        break;
                                    default:
                                        MessageBox.Show(dt.Rows[0]["Message"].ToString(), "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                        break;
                                }
                            }
                            else
                            {
                                MessageBox.Show("خطا در اجرای عملیات", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("اطلاعات وارد شده نادرست می باشد", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }

                }
                else
                {
                    MessageBox.Show("ارتباط با بانک اطلاعاتی محلی قطع می باشد", "ارتباط با بانک اطلاعاتی", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("ارتباط با بانک اطلاعاتی سرور قطع می باشد", "ارتباط با بانک اطلاعاتی", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }


        }

        protected void PrintReceipt(string Ids)
        {
            DataTable dtP = new DataTable();
            dtP = DBConnect.GetPrintTemplate("RentReceipt");

            if (dtP.Rows.Count == 1)
            {
                var stiReport = new StiReport();
                stiReport.LoadFromString(dtP.Rows[0]["Content"].ToString());

                stiReport.Dictionary.Synchronize();

                DataTable dt = new DataTable("OutputData");

                dt = DBConnect.GetReceipt(Ids);

                stiReport.RegData("receipts",dt);

                stiReport.Dictionary.Synchronize();

                string PrinterName = DBConnect.GetKeyValue("DefaultPrinterName");

                if (PrinterName != "")
                {
                    System.Drawing.Printing.PrinterSettings oSet = new System.Drawing.Printing.PrinterSettings();

                    oSet.PrinterName = PrinterName;

                    stiReport.Print(false, oSet);
                }
                else
                {
                    stiReport.Print(true);
                }
            }

        }

        protected bool PCPosPayment(int AttendanceId, int Amount)
        {
            bool success = false;
            ArooshaPosResult Result;
            SyncPurchase PcPos;

            if (DBConnect.GetKeyValue("ConnectionType") != "" && ((DBConnect.GetKeyValue("IPAddress") != "" && Convert.ToInt32(DBConnect.GetKeyValue("PortNumber")) > 0) || (DBConnect.GetKeyValue("ComPortName") != "")) && Convert.ToInt32(DBConnect.GetKeyValue("ConnectionTimeOut")) > 0)
            {
                PcPos = new SyncPurchase(DBConnect.GetKeyValue("PosType"), DBConnect.GetKeyValue("ConnectionType"), DBConnect.GetKeyValue("IPAddress"), Convert.ToInt32(DBConnect.GetKeyValue("PortNumber")), Convert.ToInt32(DBConnect.GetKeyValue("ComBaudRate")), DBConnect.GetKeyValue("ComPortName"),"", "", "", Convert.ToInt32(DBConnect.GetKeyValue("ConnectionTimeOut")), Convert.ToInt32(DBConnect.GetKeyValue("ResponceTimeOut")), Amount, "");

                try
                {
                    Result = PcPos.StartPurchase();


                    if (Result.ResponceCode == 0)
                    {
                        success = true;
                        DataTable dt = DBConnect.InsertCredit(AttendanceId, Amount, Result.TransactionNo);
                        if (dt.Rows.Count == 1)
                        {
                            switch (dt.Rows[0]["MessageType"].ToString())
                            {
                                case "warning":
                                    MessageBox.Show(dt.Rows[0]["Message"].ToString(), "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    success = false;
                                    break;
                                case "error":
                                    MessageBox.Show(dt.Rows[0]["Message"].ToString(), "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    success = false;
                                    break;
                                case "success":
                                    MessageBox.Show(dt.Rows[0]["Message"].ToString(), "ذخیره", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    break;
                            }
                        }
                    }
                    else
                    {
                        success = false;
                    }
                }
                catch (Exception ex)
                {
                    success = false;
                }
            }
            else
            {
                success = false;
            }

            return success;
        }

        protected void ReadData()
        {
            timer_Time.Enabled = true;
            timer_Req.Enabled = true;
        }

        private void timer_Time_Tick(object sender, EventArgs e)
        {
            Count++;
            
            if (Count - GetCount > 1)
            {
                timer_Req.Enabled = true;
            }
        }

        private void timer_Req_Tick(object sender, EventArgs e)
        {
            GetCount = Count;
            try
            {
                if (OpenPort())
                {
                    byte[] TypeCard = new byte[2];
                    if (Classes.RFT_230.MF_Request(0, 0, ref TypeCard[0]) == 0)
                    {
                        timer_Req.Enabled = false;
                        byte[] tmpSnr = new byte[4];
                        if (Classes.RFT_230.MF_Anticoll(0, ref tmpSnr[0]) == 0)
                        {
                            string SNR = tmpSnr[3].ToString("X") + tmpSnr[2].ToString("X") + tmpSnr[1].ToString("X") + tmpSnr[0].ToString("X");
                            
                            TxtCardCode.Text = SNR;
                            BindGrid(TxtCardCode.Text, "");

                            Counter++;

                        }

                    }

                    ClosePort();
                }
                else
                { 
                
                }
            }
            catch (Exception ee)
            {

            }
        }

        protected bool OpenPort()
        {
            bool portOpened = false;
            string ComPort = DBConnect.GetKeyValue("CardReaderComPortName");
            int ComBaudRate = Convert.ToInt32(DBConnect.GetKeyValue("CardReaderComBuadRate"));
            try
            {
                if (Classes.RFT_230.MF_InitComm(ComPort, ComBaudRate) == 0)
                {
                    portOpened = true;
                    LblCardReaderStatus.Text = "";
                    LblCardReaderStatus.Refresh();
                }
                else
                {
                    portOpened = false;
                    LblCardReaderStatus.Text = "برقراری ارتباط با کارتخوان مقدور نمی باشد";
                    LblCardReaderStatus.Refresh();
                }
            }
            catch (Exception ee)
            {
                portOpened = false;
                LblCardReaderStatus.Text = "برقراری ارتباط با کارتخوان مقدور نمی باشد";
                LblCardReaderStatus.Refresh();
            }

            return portOpened;
        }

        protected bool ClosePort()
        {
            bool portClosed = false;
            try
            {
                if (Classes.RFT_230.MF_ExitComm() == 0)
                {
                    portClosed = true;
                }
                else
                {
                    portClosed = false;
                }
            }
            catch (Exception ee)
            {
                portClosed = false;
            }

            return portClosed;
        }

        
    }
}
