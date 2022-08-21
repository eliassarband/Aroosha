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
using Telerik.WinControls.UI;

namespace Attendance
{
    public partial class FrmPrinterSetting : Telerik.WinControls.UI.RadForm
    {
        public FrmPrinterSetting()
        {
            InitializeComponent();
        }

        private void PrmPrinterSetting_Load(object sender, EventArgs e)
        {
            LoadInstalledPrinters();
            
        }

        protected void LoadInstalledPrinters()
        {
            string DefaultPrinterName = DBConnect.GetKeyValue("DefaultPrinterName"); 

            Font oFont = new Font("Tahoma", 12);


            foreach (string printer in System.Drawing.Printing.PrinterSettings.InstalledPrinters)
            {
                RadListDataItem oItem = new RadListDataItem(printer);
                oItem.Value = printer;
                oItem.Font = oFont;

                if (printer == DefaultPrinterName)
                {
                    oItem.Selected = true;
                }

                lstPrinters.Items.Add(oItem);
            }

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string PrinterName = "";

            if (lstPrinters.SelectedItems.Count == 1)
            {
                PrinterName = lstPrinters.SelectedItem.Text;

                MessageBox.Show("اطلاعات پرینتر انتخاب شده با موفقیت ذخیره گردید", "انتخاب پرینتر", MessageBoxButtons.OK, MessageBoxIcon.Information);

                int Result = 0;

                Result = DBConnect.SaveSettingKey("DefaultPrinterName", PrinterName);

                if (Result == 1)
                {
                    MessageBox.Show("تنظیمات پرینتر با موفقیت ذخیره گردید", "تنظیمات CardReader", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    this.Close();
                }
                else
                {
                    MessageBox.Show("خطا در ذخیره تنظیمات پرینتر", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("لطفا یک پرینتر را از لیست انتخاب نمایید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
