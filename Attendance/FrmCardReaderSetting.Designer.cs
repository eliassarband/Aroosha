
namespace Attendance
{
    partial class FrmCardReaderSetting
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmCardReaderSetting));
            this.radLabel4 = new Telerik.WinControls.UI.RadLabel();
            this.txtComPortName = new Telerik.WinControls.UI.RadTextBox();
            this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
            this.txtComBaudRate = new Telerik.WinControls.UI.RadTextBox();
            this.radLabel2 = new Telerik.WinControls.UI.RadLabel();
            this.txtTimerInterval = new Telerik.WinControls.UI.RadTextBox();
            this.btnSave = new Telerik.WinControls.UI.RadButton();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtComPortName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtComBaudRate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTimerInterval)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSave)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // radLabel4
            // 
            this.radLabel4.Font = new System.Drawing.Font("Tahoma", 12F);
            this.radLabel4.Location = new System.Drawing.Point(411, 66);
            this.radLabel4.Name = "radLabel4";
            this.radLabel4.Size = new System.Drawing.Size(110, 23);
            this.radLabel4.TabIndex = 9;
            this.radLabel4.Text = "نام Port سریال";
            this.radLabel4.TextAlignment = System.Drawing.ContentAlignment.TopRight;
            // 
            // txtComPortName
            // 
            this.txtComPortName.AutoSize = false;
            this.txtComPortName.Font = new System.Drawing.Font("Tahoma", 12F);
            this.txtComPortName.Location = new System.Drawing.Point(105, 62);
            this.txtComPortName.Name = "txtComPortName";
            this.txtComPortName.Size = new System.Drawing.Size(300, 30);
            this.txtComPortName.TabIndex = 8;
            this.txtComPortName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // radLabel1
            // 
            this.radLabel1.Font = new System.Drawing.Font("Tahoma", 12F);
            this.radLabel1.Location = new System.Drawing.Point(411, 115);
            this.radLabel1.Name = "radLabel1";
            this.radLabel1.Size = new System.Drawing.Size(104, 23);
            this.radLabel1.TabIndex = 11;
            this.radLabel1.Text = "نرخ BaudRate";
            this.radLabel1.TextAlignment = System.Drawing.ContentAlignment.TopRight;
            // 
            // txtComBaudRate
            // 
            this.txtComBaudRate.AutoSize = false;
            this.txtComBaudRate.Font = new System.Drawing.Font("Tahoma", 12F);
            this.txtComBaudRate.Location = new System.Drawing.Point(105, 111);
            this.txtComBaudRate.Name = "txtComBaudRate";
            this.txtComBaudRate.Size = new System.Drawing.Size(300, 30);
            this.txtComBaudRate.TabIndex = 10;
            this.txtComBaudRate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // radLabel2
            // 
            this.radLabel2.Font = new System.Drawing.Font("Tahoma", 12F);
            this.radLabel2.Location = new System.Drawing.Point(411, 165);
            this.radLabel2.Name = "radLabel2";
            this.radLabel2.Size = new System.Drawing.Size(111, 23);
            this.radLabel2.TabIndex = 13;
            this.radLabel2.Text = "Timer Interval";
            this.radLabel2.TextAlignment = System.Drawing.ContentAlignment.TopRight;
            // 
            // txtTimerInterval
            // 
            this.txtTimerInterval.AutoSize = false;
            this.txtTimerInterval.Font = new System.Drawing.Font("Tahoma", 12F);
            this.txtTimerInterval.Location = new System.Drawing.Point(105, 161);
            this.txtTimerInterval.Name = "txtTimerInterval";
            this.txtTimerInterval.Size = new System.Drawing.Size(300, 30);
            this.txtTimerInterval.TabIndex = 12;
            this.txtTimerInterval.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Tahoma", 12F);
            this.btnSave.Location = new System.Drawing.Point(242, 222);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(150, 40);
            this.btnSave.TabIndex = 15;
            this.btnSave.Text = "ذخیره";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnSave.GetChildAt(0))).Text = "ذخیره";
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnSave.GetChildAt(0))).Font = new System.Drawing.Font("Tahoma", 12F);
            // 
            // FrmCardReaderSetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(628, 298);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.radLabel2);
            this.Controls.Add(this.txtTimerInterval);
            this.Controls.Add(this.radLabel1);
            this.Controls.Add(this.txtComBaudRate);
            this.Controls.Add(this.radLabel4);
            this.Controls.Add(this.txtComPortName);
            this.Font = new System.Drawing.Font("Tahoma", 12F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmCardReaderSetting";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "تنظیمات Card Reader";
            this.Load += new System.EventHandler(this.FrmCardReaderSetting_Load);
            ((System.ComponentModel.ISupportInitialize)(this.radLabel4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtComPortName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtComBaudRate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTimerInterval)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSave)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.UI.RadLabel radLabel4;
        private Telerik.WinControls.UI.RadTextBox txtComPortName;
        private Telerik.WinControls.UI.RadLabel radLabel1;
        private Telerik.WinControls.UI.RadTextBox txtComBaudRate;
        private Telerik.WinControls.UI.RadLabel radLabel2;
        private Telerik.WinControls.UI.RadTextBox txtTimerInterval;
        private Telerik.WinControls.UI.RadButton btnSave;
    }
}