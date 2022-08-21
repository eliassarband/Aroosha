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
    public partial class FrmDbConnectionSetting : Telerik.WinControls.UI.RadForm
    {
        public FrmDbConnectionSetting()
        {
            InitializeComponent();
        }

        private void FrmDbConnectionSetting_Load(object sender, EventArgs e)
        {
            txtInstanceName.Text = DBConnect.GetKeyValue("ServerInstanceName"); 
            txtDatabaseName.Text = DBConnect.GetKeyValue("ServerDatabaseName"); 
            txtLoginName.Text = DBConnect.GetKeyValue("ServerLoginName");
            txtLoginPassword.Text = DBConnect.GetKeyValue("ServerLoginPassword");
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtInstanceName.Text != "" && txtDatabaseName.Text != "" && txtLoginName.Text != "" && txtLoginPassword.Text != "")
            {
                int Result = 0;

                Result = DBConnect.SaveSettingKey("ServerInstanceName", txtInstanceName.Text);

                if (Result == 1)
                    Result = DBConnect.SaveSettingKey("ServerDatabaseName", txtDatabaseName.Text);

                if (Result == 1)
                    Result = DBConnect.SaveSettingKey("ServerLoginName", txtLoginName.Text);

                if (Result == 1)
                    Result = DBConnect.SaveSettingKey("ServerLoginPassword", txtLoginPassword.Text);

                if (Result == 1)
                {
                    MessageBox.Show("تنظیمات ارتباط با بانک اطلاعاتی سرور با موفقیت ذخیره گردید", "تنظیمات CardReader", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    this.Close();
                }
                else
                {
                    MessageBox.Show("خطا در ذخیره تنظیمات ارتباط با بانک اطلاعاتی سرور", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                
            }
            else
            {
                MessageBox.Show("لطفا اطلاعات را کامل نمایید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
