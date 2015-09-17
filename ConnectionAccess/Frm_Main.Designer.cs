namespace ConnectionAccess
{
    partial class Frm_Main
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.DatePackage = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TekNum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BatchNum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.WeekNum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Serial = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PhoneNum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IMEI = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ICCID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IMSI = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FirmwareVer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BatteryVoltage = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TestPC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SettingsProfile = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Deleted = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Box = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.radioButtonRecount = new System.Windows.Forms.RadioButton();
            this.button2 = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.errorProviderText = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderText)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DatePackage,
            this.TekNum,
            this.BatchNum,
            this.WeekNum,
            this.Serial,
            this.PhoneNum,
            this.IMEI,
            this.ICCID,
            this.IMSI,
            this.FirmwareVer,
            this.BatteryVoltage,
            this.TestPC,
            this.SettingsProfile,
            this.Deleted,
            this.Box});
            this.dataGridView1.Location = new System.Drawing.Point(0, 45);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(1076, 608);
            this.dataGridView1.TabIndex = 4;
            // 
            // DatePackage
            // 
            this.DatePackage.HeaderText = "DatePackage";
            this.DatePackage.Name = "DatePackage";
            this.DatePackage.ReadOnly = true;
            // 
            // TekNum
            // 
            this.TekNum.HeaderText = "TekNum";
            this.TekNum.Name = "TekNum";
            this.TekNum.ReadOnly = true;
            // 
            // BatchNum
            // 
            this.BatchNum.HeaderText = "BatchNum";
            this.BatchNum.Name = "BatchNum";
            this.BatchNum.ReadOnly = true;
            // 
            // WeekNum
            // 
            this.WeekNum.HeaderText = "WeekNum";
            this.WeekNum.Name = "WeekNum";
            this.WeekNum.ReadOnly = true;
            // 
            // Serial
            // 
            this.Serial.HeaderText = "Serial";
            this.Serial.Name = "Serial";
            this.Serial.ReadOnly = true;
            // 
            // PhoneNum
            // 
            this.PhoneNum.HeaderText = "PhoneNum";
            this.PhoneNum.Name = "PhoneNum";
            this.PhoneNum.ReadOnly = true;
            // 
            // IMEI
            // 
            this.IMEI.HeaderText = "IMEI";
            this.IMEI.Name = "IMEI";
            this.IMEI.ReadOnly = true;
            // 
            // ICCID
            // 
            this.ICCID.HeaderText = "ICCID";
            this.ICCID.Name = "ICCID";
            this.ICCID.ReadOnly = true;
            // 
            // IMSI
            // 
            this.IMSI.HeaderText = "IMSI";
            this.IMSI.Name = "IMSI";
            this.IMSI.ReadOnly = true;
            // 
            // FirmwareVer
            // 
            this.FirmwareVer.HeaderText = "FirmwareVer";
            this.FirmwareVer.Name = "FirmwareVer";
            this.FirmwareVer.ReadOnly = true;
            // 
            // BatteryVoltage
            // 
            this.BatteryVoltage.HeaderText = "BatteryVoltage";
            this.BatteryVoltage.Name = "BatteryVoltage";
            this.BatteryVoltage.ReadOnly = true;
            // 
            // TestPC
            // 
            this.TestPC.HeaderText = "TestPC";
            this.TestPC.Name = "TestPC";
            this.TestPC.ReadOnly = true;
            // 
            // SettingsProfile
            // 
            this.SettingsProfile.HeaderText = "SettingsProfile";
            this.SettingsProfile.Name = "SettingsProfile";
            this.SettingsProfile.ReadOnly = true;
            // 
            // Deleted
            // 
            this.Deleted.HeaderText = "Deleted";
            this.Deleted.Name = "Deleted";
            this.Deleted.ReadOnly = true;
            // 
            // Box
            // 
            this.Box.HeaderText = "Box";
            this.Box.Name = "Box";
            this.Box.ReadOnly = true;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(218, 13);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 21);
            this.textBox1.TabIndex = 0;
            this.textBox1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox1_KeyPress);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(438, 13);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "上传数据";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // radioButtonRecount
            // 
            this.radioButtonRecount.AutoSize = true;
            this.radioButtonRecount.Location = new System.Drawing.Point(631, 16);
            this.radioButtonRecount.Name = "radioButtonRecount";
            this.radioButtonRecount.Size = new System.Drawing.Size(71, 16);
            this.radioButtonRecount.TabIndex = 2;
            this.radioButtonRecount.TabStop = true;
            this.radioButtonRecount.Text = "重新计数";
            this.radioButtonRecount.UseVisualStyleBackColor = true;
            this.radioButtonRecount.Click += new System.EventHandler(this.radioButtonRecount_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(827, 16);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 3;
            this.button2.Text = "导入数据";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // errorProviderText
            // 
            this.errorProviderText.ContainerControl = this;
            // 
            // Frm_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1076, 653);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.radioButtonRecount);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.dataGridView1);
            this.Name = "Frm_Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tek586&733包装扫描";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Frm_Main_FormClosed_1);
            this.Load += new System.EventHandler(this.Frm_Main_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderText)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.RadioButton radioButtonRecount;
        private System.Windows.Forms.DataGridViewTextBoxColumn DatePackage;
        private System.Windows.Forms.DataGridViewTextBoxColumn TekNum;
        private System.Windows.Forms.DataGridViewTextBoxColumn BatchNum;
        private System.Windows.Forms.DataGridViewTextBoxColumn WeekNum;
        private System.Windows.Forms.DataGridViewTextBoxColumn Serial;
        private System.Windows.Forms.DataGridViewTextBoxColumn PhoneNum;
        private System.Windows.Forms.DataGridViewTextBoxColumn IMEI;
        private System.Windows.Forms.DataGridViewTextBoxColumn ICCID;
        private System.Windows.Forms.DataGridViewTextBoxColumn IMSI;
        private System.Windows.Forms.DataGridViewTextBoxColumn FirmwareVer;
        private System.Windows.Forms.DataGridViewTextBoxColumn BatteryVoltage;
        private System.Windows.Forms.DataGridViewTextBoxColumn TestPC;
        private System.Windows.Forms.DataGridViewTextBoxColumn SettingsProfile;
        private System.Windows.Forms.DataGridViewTextBoxColumn Deleted;
        private System.Windows.Forms.DataGridViewTextBoxColumn Box;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.ErrorProvider errorProviderText;
    }
}

