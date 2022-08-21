using Attendance.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Attendance
{
    public partial class FrmCardReaderSetting : Telerik.WinControls.UI.RadForm
    {
        public FrmCardReaderSetting()
        {
            InitializeComponent();
        }

        private void FrmCardReaderSetting_Load(object sender, EventArgs e)
        {
            LoadCardReaderData();
        }

        protected void LoadCardReaderData()
        {
            txtComPortName.Text = DBConnect.GetKeyValue("CardReaderComPortName");
            txtComBaudRate.Text = DBConnect.GetKeyValue("CardReaderComBuadRate");
            txtTimerInterval.Text = DBConnect.GetKeyValue("CardReaderTimerInterval");
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            if (txtComPortName.Text != "" && txtComBaudRate.Text != "" && txtTimerInterval.Text != "")
            {
                int Result = 0;

                Result = DBConnect.SaveSettingKey("CardReaderComPortName", txtComPortName.Text);

                if (Result == 1)
                    Result = DBConnect.SaveSettingKey("CardReaderComBuadRate", txtComBaudRate.Text);

                if (Result == 1)
                    Result = DBConnect.SaveSettingKey("CardReaderTimerInterval", txtTimerInterval.Text);

                if (Result == 1)
                {
                    MessageBox.Show("تنظیمات Card Reader با موفقیت ذخیره گردید", "تنظیمات CardReader", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    this.Close();
                }
                else
                {
                    MessageBox.Show("خطا در ذخیره تنظیمات Card Reader", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("لطفا اطلاعات Card Reader را تکمیل نمایید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
 