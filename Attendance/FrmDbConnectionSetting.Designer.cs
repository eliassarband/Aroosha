
namespace Attendance
{
    partial class FrmDbConnectionSetting
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmDbConnectionSetting));
            this.radLabel2 = new Telerik.WinControls.UI.RadLabel();
            this.txtInstanceName = new Telerik.WinControls.UI.RadTextBox();
            this.radLabel3 = new Telerik.WinControls.UI.RadLabel();
            this.txtDatabaseName = new Telerik.WinControls.UI.RadTextBox();
            this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
            this.txtLoginName = new Telerik.WinControls.UI.RadTextBox();
            this.radLabel4 = new Telerik.WinControls.UI.RadLabel();
            this.txtLoginPassword = new Telerik.WinControls.UI.RadTextBox();
            this.btnSave = new Telerik.WinControls.UI.RadButton();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtInstanceName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDatabaseName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLoginName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLoginPassword)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSave)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // radLabel2
            // 
            this.radLabel2.Font = new System.Drawing.Font("Tahoma", 12F);
            this.radLabel2.Location = new System.Drawing.Point(92, 71);
            this.radLabel2.Name = "radLabel2";
            this.radLabel2.Size = new System.Drawing.Size(117, 23);
            this.radLabel2.TabIndex = 3;
            this.radLabel2.Text = "Instance Name";
            this.radLabel2.TextAlignment = System.Drawing.ContentAlignment.TopRight;
            // 
            // txtInstanceName
            // 
            this.txtInstanceName.AutoSize = false;
            this.txtInstanceName.Font = new System.Drawing.Font("Tahoma", 12F);
            this.txtInstanceName.Location = new System.Drawing.Point(216, 66);
            this.txtInstanceName.Name = "txtInstanceName";
            this.txtInstanceName.Size = new System.Drawing.Size(250, 30);
            this.txtInstanceName.TabIndex = 2;
            this.txtInstanceName.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // radLabel3
            // 
            this.radLabel3.Font = new System.Drawing.Font("Tahoma", 12F);
            this.radLabel3.Location = new System.Drawing.Point(87, 118);
            this.radLabel3.Name = "radLabel3";
            this.radLabel3.Size = new System.Drawing.Size(123, 23);
            this.radLabel3.TabIndex = 5;
            this.radLabel3.Text = "Database Name";
            this.radLabel3.TextAlignment = System.Drawing.ContentAlignment.TopRight;
            // 
            // txtDatabaseName
            // 
            this.txtDatabaseName.AutoSize = false;
            this.txtDatabaseName.Font = new System.Drawing.Font("Tahoma", 12F);
            this.txtDatabaseName.Location = new System.Drawing.Point(216, 113);
            this.txtDatabaseName.Name = "txtDatabaseName";
            this.txtDatabaseName.Size = new System.Drawing.Size(250, 30);
            this.txtDatabaseName.TabIndex = 4;
            this.txtDatabaseName.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // radLabel1
            // 
            this.radLabel1.Font = new System.Drawing.Font("Tahoma", 12F);
            this.radLabel1.Location = new System.Drawing.Point(116, 167);
            this.radLabel1.Name = "radLabel1";
            this.radLabel1.Size = new System.Drawing.Size(94, 23);
            this.radLabel1.TabIndex = 7;
            this.radLabel1.Text = "Login Name";
            this.radLabel1.TextAlignment = System.Drawing.ContentAlignment.TopRight;
            // 
            // txtLoginName
            // 
            this.txtLoginName.AutoSize = false;
            this.txtLoginName.Font = new System.Drawing.Font("Tahoma", 12F);
            this.txtLoginName.Location = new System.Drawing.Point(216, 162);
            this.txtLoginName.Name = "txtLoginName";
            this.txtLoginName.Size = new System.Drawing.Size(250, 30);
            this.txtLoginName.TabIndex = 6;
            this.txtLoginName.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // radLabel4
            // 
            this.radLabel4.Font = new System.Drawing.Font("Tahoma", 12F);
            this.radLabel4.Location = new System.Drawing.Point(89, 214);
            this.radLabel4.Name = "radLabel4";
            this.radLabel4.Size = new System.Drawing.Size(121, 23);
            this.radLabel4.TabIndex = 9;
            this.radLabel4.Text = "Login Password";
            this.radLabel4.TextAlignment = System.Drawing.ContentAlignment.TopRight;
            // 
            // txtLoginPassword
            // 
            this.txtLoginPassword.AutoSize = false;
            this.txtLoginPassword.Font = new System.Drawing.Font("Tahoma", 12F);
            this.txtLoginPassword.Location = new System.Drawing.Point(216, 209);
            this.txtLoginPassword.Name = "txtLoginPassword";
            this.txtLoginPassword.Size = new System.Drawing.Size(250, 30);
            this.txtLoginPassword.TabIndex = 8;
            this.txtLoginPassword.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Tahoma", 12F);
            this.btnSave.Location = new System.Drawing.Point(188, 282);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(200, 40);
            this.btnSave.TabIndex = 10;
            this.btnSave.Text = "ذخیره تنظیمات";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnSave.GetChildAt(0))).Text = "ذخیره تنظیمات";
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnSave.GetChildAt(0))).Font = new System.Drawing.Font("Tahoma", 12F);
            // 
            // FrmDbConnectionSetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(574, 367);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.radLabel4);
            this.Controls.Add(this.radLabel1);
            this.Controls.Add(this.txtLoginPassword);
            this.Controls.Add(this.radLabel3);
            this.Controls.Add(this.txtLoginName);
            this.Controls.Add(this.radLabel2);
            this.Controls.Add(this.txtDatabaseName);
            this.Controls.Add(this.txtInstanceName);
            this.Font = new System.Drawing.Font("Tahoma", 12F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmDbConnectionSetting";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "تنظیمات ارتباط با بانک اطلاعاتی سرور";
            this.Load += new System.EventHandler(this.FrmDbConnectionSetting_Load);
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtInstanceName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDatabaseName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLoginName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLoginPassword)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSave)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.UI.RadLabel radLabel2;
        private Telerik.WinControls.UI.RadTextBox txtInstanceName;
        private Telerik.WinControls.UI.RadLabel radLabel3;
        private Telerik.WinControls.UI.RadTextBox txtDatabaseName;
        private Telerik.WinControls.UI.RadLabel radLabel1;
        private Telerik.WinControls.UI.RadTextBox txtLoginName;
        private Telerik.WinControls.UI.RadLabel radLabel4;
        private Telerik.WinControls.UI.RadTextBox txtLoginPassword;
        private Telerik.WinControls.UI.RadButton btnSave;
    }
}