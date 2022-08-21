using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ArooshaPOS;
using Attendance.Classes;
using Telerik.WinControls.UI;

namespace Attendance
{
    public partial class FrmPCPosSetting : Telerik.WinControls.UI.RadForm
    {
        public FrmPCPosSetting()
        {
            InitializeComponent();
        }

        private void FrmPCPosSetting_Load(object sender, EventArgs e)
        {
            LoadPosType();
            LoadConnectionType();

            LoadPosData();
            
        }

        protected void LoadPosData()
        {
            drpPosType.SelectedValue = DBConnect.GetKeyValue("PosType"); 
            drpConnectionType.SelectedValue = DBConnect.GetKeyValue("ConnectionType"); 
            txtIPAddress.Text = DBConnect.GetKeyValue("IPAddress");
            txtPortNumber.Text = DBConnect.GetKeyValue("PortNumber");
            txtComPortName.Text = DBConnect.GetKeyValue("ComPortName");
            txtComBuadRate.Text = DBConnect.GetKeyValue("ComBaudRate"); 
            txtConnectionTimeOut.Text = DBConnect.GetKeyValue("ConnectionTimeOut");
            txtResponceTimeout.Text = DBConnect.GetKeyValue("ResponceTimeOut");
        }

        protected void LoadPosType()
        {
            Font oFont = new Font("Tahoma", 12);

            SyncPurchase oSet = new SyncPurchase();

            var posList = oSet.GetPosType();

            foreach (var pos in posList)
            {
                RadListDataItem item = new RadListDataItem();
                item.Value = pos.PosType;
                item.Text = pos.PosTypeName;
                item.Font = oFont;

                drpPosType.Items.Add(item);
            }
        }

        protected void LoadConnectionType()
        {
            Font oFont = new Font("Tahoma", 12);

            RadListDataItem item = new RadListDataItem();
            item.Value = "LAN";
            item.Text = "LAN";
            item.Font = oFont;

            drpConnectionType.Items.Add(item);

            item = new RadListDataItem();
            item.Value = "SERIAL";
            item.Text = "SERIAL";
            item.Font = oFont;

            drpConnectionType.Items.Add(item);

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (drpPosType.SelectedItems.Count == 1 && drpConnectionType.SelectedItems.Count == 1 && txtIPAddress.Text != "" && txtPortNumber.Text != "" && txtComPortName.Text != "" && txtComBuadRate.Text != "" && txtConnectionTimeOut.Text != "" && txtResponceTimeout.Text != "")
            {
                
                int Result = 0;

                Result = DBConnect.SaveSettingKey("PosType", drpPosType.SelectedValue.ToString());

                if (Result == 1)
                    Result = DBConnect.SaveSettingKey("ConnectionType", drpConnectionType.SelectedValue.ToString());

                if (Result == 1)
                    Result = DBConnect.SaveSettingKey("IPAddress", txtIPAddress.Text);

                if (Result == 1)
                    Result = DBConnect.SaveSettingKey("PortNumber", txtPortNumber.Text);

                if (Result == 1)
                    Result = DBConnect.SaveSettingKey("ComPortName", txtComPortName.Text);

                if (Result == 1)
                    Result = DBConnect.SaveSettingKey("ComBaudRate", txtComBuadRate.Text);

                if (Result == 1)
                    Result = DBConnect.SaveSettingKey("ConnectionTimeOut", txtConnectionTimeOut.Text);

                if (Result == 1)
                    Result = DBConnect.SaveSettingKey("ResponceTimeOut", txtResponceTimeout.Text);

                if (Result == 1)
                {
                    MessageBox.Show("تنظیمات کارتخوان با موفقیت ذخیره گردید", "تنظیمات CardReader", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    this.Close();
                }
                else
                {
                    MessageBox.Show("خطا در ذخیره تنظیمات کارتخوان", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("لطفا اطلاعات PC Pos را تکمیل نمایید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
