namespace Com.Nidec.Mes.Common.Basic.MachineMaintenance.Form
{
    partial class NoiseCheckForm
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.txtBarcode = new Com.Nidec.Mes.Framework.TextBoxCommon();
            this.groupBoxCommon1 = new Com.Nidec.Mes.Framework.GroupBoxCommon();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblteach = new Com.Nidec.Mes.Framework.LabelCommon();
            this.btnResetCount = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.lbldatetime = new Com.Nidec.Mes.Framework.LabelCommon();
            this.lblCount = new Com.Nidec.Mes.Framework.LabelCommon();
            this.labelCommon5 = new Com.Nidec.Mes.Framework.LabelCommon();
            this.lbl = new Com.Nidec.Mes.Framework.LabelCommon();
            this.txtBrowser = new Com.Nidec.Mes.Framework.TextBoxCommon();
            this.btnBrowser = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.dgvNoise = new Com.Nidec.Mes.Framework.DataGridViewCommon();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.groupBoxCommon2 = new Com.Nidec.Mes.Framework.GroupBoxCommon();
            this.lblcountThurst = new Com.Nidec.Mes.Framework.LabelCommon();
            this.lblThurst = new Com.Nidec.Mes.Framework.LabelCommon();
            this.labelCommon4 = new Com.Nidec.Mes.Framework.LabelCommon();
            this.labelCommon3 = new Com.Nidec.Mes.Framework.LabelCommon();
            this.lblNoise = new Com.Nidec.Mes.Framework.LabelCommon();
            this.groupBoxCommon3 = new Com.Nidec.Mes.Framework.GroupBoxCommon();
            this.timerOff = new System.Windows.Forms.Timer(this.components);
            this.timerOffBarcodenull = new System.Windows.Forms.Timer(this.components);
            this.btnExport = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.groupBoxCommon4 = new Com.Nidec.Mes.Framework.GroupBoxCommon();
            this.cmb_Machine = new Com.Nidec.Mes.Framework.ComboBoxCommon();
            this.labelCommon6 = new Com.Nidec.Mes.Framework.LabelCommon();
            this.labelCommon2 = new Com.Nidec.Mes.Framework.LabelCommon();
            this.labelCommon1 = new Com.Nidec.Mes.Framework.LabelCommon();
            this.dtp_From = new System.Windows.Forms.DateTimePicker();
            this.dtp_To = new System.Windows.Forms.DateTimePicker();
            this.groupBoxCommon1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNoise)).BeginInit();
            this.groupBoxCommon2.SuspendLayout();
            this.groupBoxCommon3.SuspendLayout();
            this.groupBoxCommon4.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtBarcode
            // 
            this.txtBarcode.ControlId = null;
            this.txtBarcode.Font = new System.Drawing.Font("Arial", 26F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBarcode.InputType = Com.Nidec.Mes.Framework.TextBoxCommon.InputTypeList.All;
            this.txtBarcode.Location = new System.Drawing.Point(101, 33);
            this.txtBarcode.MaxLength = 8;
            this.txtBarcode.Name = "txtBarcode";
            this.txtBarcode.Size = new System.Drawing.Size(212, 47);
            this.txtBarcode.TabIndex = 2;
            this.txtBarcode.TextChanged += new System.EventHandler(this.txtBarcode_TextChanged);
            // 
            // groupBoxCommon1
            // 
            this.groupBoxCommon1.ControlId = null;
            this.groupBoxCommon1.Controls.Add(this.panel1);
            this.groupBoxCommon1.Controls.Add(this.lbl);
            this.groupBoxCommon1.Controls.Add(this.txtBarcode);
            this.groupBoxCommon1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBoxCommon1.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxCommon1.Location = new System.Drawing.Point(0, 107);
            this.groupBoxCommon1.Name = "groupBoxCommon1";
            this.groupBoxCommon1.Size = new System.Drawing.Size(460, 105);
            this.groupBoxCommon1.TabIndex = 4;
            this.groupBoxCommon1.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.lblteach);
            this.panel1.Controls.Add(this.btnResetCount);
            this.panel1.Controls.Add(this.lbldatetime);
            this.panel1.Controls.Add(this.lblCount);
            this.panel1.Controls.Add(this.labelCommon5);
            this.panel1.Location = new System.Drawing.Point(319, 6);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(138, 99);
            this.panel1.TabIndex = 9;
            // 
            // lblteach
            // 
            this.lblteach.AutoSize = true;
            this.lblteach.ControlId = null;
            this.lblteach.Font = new System.Drawing.Font("Arial", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblteach.Location = new System.Drawing.Point(12, 49);
            this.lblteach.Name = "lblteach";
            this.lblteach.Size = new System.Drawing.Size(11, 15);
            this.lblteach.TabIndex = 121;
            this.lblteach.Text = "-";
            // 
            // btnResetCount
            // 
            this.btnResetCount.BackColor = System.Drawing.SystemColors.Control;
            this.btnResetCount.ControlId = null;
            this.btnResetCount.Font = new System.Drawing.Font("Arial", 9F);
            this.btnResetCount.Location = new System.Drawing.Point(0, 3);
            this.btnResetCount.Name = "btnResetCount";
            this.btnResetCount.Size = new System.Drawing.Size(136, 22);
            this.btnResetCount.TabIndex = 118;
            this.btnResetCount.Text = "Change Connector";
            this.btnResetCount.UseVisualStyleBackColor = false;
            this.btnResetCount.Click += new System.EventHandler(this.btnResetCount_Click);
            // 
            // lbldatetime
            // 
            this.lbldatetime.AutoSize = true;
            this.lbldatetime.ControlId = null;
            this.lbldatetime.Font = new System.Drawing.Font("Arial", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbldatetime.Location = new System.Drawing.Point(12, 30);
            this.lbldatetime.Name = "lbldatetime";
            this.lbldatetime.Size = new System.Drawing.Size(14, 15);
            this.lbldatetime.TabIndex = 120;
            this.lbldatetime.Text = "- ";
            // 
            // lblCount
            // 
            this.lblCount.AutoSize = true;
            this.lblCount.ControlId = null;
            this.lblCount.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCount.Location = new System.Drawing.Point(81, 71);
            this.lblCount.Name = "lblCount";
            this.lblCount.Size = new System.Drawing.Size(21, 22);
            this.lblCount.TabIndex = 7;
            this.lblCount.Text = "0";
            // 
            // labelCommon5
            // 
            this.labelCommon5.AutoSize = true;
            this.labelCommon5.ControlId = null;
            this.labelCommon5.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCommon5.Location = new System.Drawing.Point(17, 73);
            this.labelCommon5.Name = "labelCommon5";
            this.labelCommon5.Size = new System.Drawing.Size(63, 18);
            this.labelCommon5.TabIndex = 119;
            this.labelCommon5.Text = "Counter";
            // 
            // lbl
            // 
            this.lbl.AutoSize = true;
            this.lbl.ControlId = null;
            this.lbl.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl.Location = new System.Drawing.Point(13, 50);
            this.lbl.Name = "lbl";
            this.lbl.Size = new System.Drawing.Size(72, 18);
            this.lbl.TabIndex = 4;
            this.lbl.Text = "Barcode:";
            // 
            // txtBrowser
            // 
            this.txtBrowser.ControlId = null;
            this.txtBrowser.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBrowser.InputType = Com.Nidec.Mes.Framework.TextBoxCommon.InputTypeList.All;
            this.txtBrowser.Location = new System.Drawing.Point(153, 24);
            this.txtBrowser.Name = "txtBrowser";
            this.txtBrowser.Size = new System.Drawing.Size(231, 21);
            this.txtBrowser.TabIndex = 6;
            // 
            // btnBrowser
            // 
            this.btnBrowser.BackColor = System.Drawing.SystemColors.Control;
            this.btnBrowser.ControlId = null;
            this.btnBrowser.Font = new System.Drawing.Font("Arial", 9F);
            this.btnBrowser.Location = new System.Drawing.Point(49, 21);
            this.btnBrowser.Name = "btnBrowser";
            this.btnBrowser.Size = new System.Drawing.Size(74, 27);
            this.btnBrowser.TabIndex = 5;
            this.btnBrowser.Text = "Browser";
            this.btnBrowser.UseVisualStyleBackColor = false;
            this.btnBrowser.Click += new System.EventHandler(this.btnBrowser_Click);
            // 
            // dgvNoise
            // 
            this.dgvNoise.AllowUserToAddRows = false;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(232)))), ((int)(((byte)(180)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvNoise.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvNoise.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvNoise.ControlId = null;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvNoise.DefaultCellStyle = dataGridViewCellStyle5;
            this.dgvNoise.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgvNoise.Location = new System.Drawing.Point(0, 481);
            this.dgvNoise.Name = "dgvNoise";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(232)))), ((int)(((byte)(180)))));
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvNoise.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dgvNoise.RowHeadersVisible = false;
            this.dgvNoise.Size = new System.Drawing.Size(460, 73);
            this.dgvNoise.TabIndex = 5;
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick_1);
            // 
            // groupBoxCommon2
            // 
            this.groupBoxCommon2.ControlId = null;
            this.groupBoxCommon2.Controls.Add(this.lblcountThurst);
            this.groupBoxCommon2.Controls.Add(this.lblThurst);
            this.groupBoxCommon2.Controls.Add(this.labelCommon4);
            this.groupBoxCommon2.Controls.Add(this.labelCommon3);
            this.groupBoxCommon2.Controls.Add(this.lblNoise);
            this.groupBoxCommon2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBoxCommon2.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxCommon2.Location = new System.Drawing.Point(0, 212);
            this.groupBoxCommon2.Name = "groupBoxCommon2";
            this.groupBoxCommon2.Size = new System.Drawing.Size(460, 103);
            this.groupBoxCommon2.TabIndex = 7;
            this.groupBoxCommon2.TabStop = false;
            // 
            // lblcountThurst
            // 
            this.lblcountThurst.AutoSize = true;
            this.lblcountThurst.ControlId = null;
            this.lblcountThurst.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblcountThurst.Location = new System.Drawing.Point(365, 25);
            this.lblcountThurst.Name = "lblcountThurst";
            this.lblcountThurst.Size = new System.Drawing.Size(21, 22);
            this.lblcountThurst.TabIndex = 8;
            this.lblcountThurst.Text = "0";
            // 
            // lblThurst
            // 
            this.lblThurst.AutoSize = true;
            this.lblThurst.ControlId = null;
            this.lblThurst.Font = new System.Drawing.Font("Arial", 26F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblThurst.Location = new System.Drawing.Point(240, 51);
            this.lblThurst.Name = "lblThurst";
            this.lblThurst.Size = new System.Drawing.Size(0, 40);
            this.lblThurst.TabIndex = 7;
            // 
            // labelCommon4
            // 
            this.labelCommon4.AutoSize = true;
            this.labelCommon4.ControlId = null;
            this.labelCommon4.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCommon4.Location = new System.Drawing.Point(242, 25);
            this.labelCommon4.Name = "labelCommon4";
            this.labelCommon4.Size = new System.Drawing.Size(127, 22);
            this.labelCommon4.TabIndex = 6;
            this.labelCommon4.Text = "Thurst Check:";
            // 
            // labelCommon3
            // 
            this.labelCommon3.AutoSize = true;
            this.labelCommon3.ControlId = null;
            this.labelCommon3.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCommon3.Location = new System.Drawing.Point(12, 25);
            this.labelCommon3.Name = "labelCommon3";
            this.labelCommon3.Size = new System.Drawing.Size(123, 22);
            this.labelCommon3.TabIndex = 5;
            this.labelCommon3.Text = "Noise Check:";
            // 
            // lblNoise
            // 
            this.lblNoise.AutoSize = true;
            this.lblNoise.ControlId = null;
            this.lblNoise.Font = new System.Drawing.Font("Arial", 26F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNoise.Location = new System.Drawing.Point(13, 51);
            this.lblNoise.Name = "lblNoise";
            this.lblNoise.Size = new System.Drawing.Size(0, 40);
            this.lblNoise.TabIndex = 0;
            // 
            // groupBoxCommon3
            // 
            this.groupBoxCommon3.ControlId = null;
            this.groupBoxCommon3.Controls.Add(this.btnBrowser);
            this.groupBoxCommon3.Controls.Add(this.txtBrowser);
            this.groupBoxCommon3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBoxCommon3.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxCommon3.Location = new System.Drawing.Point(0, 418);
            this.groupBoxCommon3.Name = "groupBoxCommon3";
            this.groupBoxCommon3.Size = new System.Drawing.Size(460, 63);
            this.groupBoxCommon3.TabIndex = 8;
            this.groupBoxCommon3.TabStop = false;
            // 
            // timerOff
            // 
            this.timerOff.Interval = 2000;
            this.timerOff.Tick += new System.EventHandler(this.timerOff_Tick);
            // 
            // timerOffBarcodenull
            // 
            this.timerOffBarcodenull.Interval = 5000;
            this.timerOffBarcodenull.Tick += new System.EventHandler(this.timerOffBarcodenull_Tick);
            // 
            // btnExport
            // 
            this.btnExport.BackColor = System.Drawing.SystemColors.Control;
            this.btnExport.ControlId = null;
            this.btnExport.Font = new System.Drawing.Font("Arial", 9F);
            this.btnExport.Location = new System.Drawing.Point(362, 40);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(74, 39);
            this.btnExport.TabIndex = 7;
            this.btnExport.Text = "Export";
            this.btnExport.UseVisualStyleBackColor = false;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // groupBoxCommon4
            // 
            this.groupBoxCommon4.ControlId = null;
            this.groupBoxCommon4.Controls.Add(this.cmb_Machine);
            this.groupBoxCommon4.Controls.Add(this.labelCommon6);
            this.groupBoxCommon4.Controls.Add(this.labelCommon2);
            this.groupBoxCommon4.Controls.Add(this.labelCommon1);
            this.groupBoxCommon4.Controls.Add(this.dtp_From);
            this.groupBoxCommon4.Controls.Add(this.dtp_To);
            this.groupBoxCommon4.Controls.Add(this.btnExport);
            this.groupBoxCommon4.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBoxCommon4.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxCommon4.Location = new System.Drawing.Point(0, 315);
            this.groupBoxCommon4.Name = "groupBoxCommon4";
            this.groupBoxCommon4.Size = new System.Drawing.Size(460, 105);
            this.groupBoxCommon4.TabIndex = 9;
            this.groupBoxCommon4.TabStop = false;
            // 
            // cmb_Machine
            // 
            this.cmb_Machine.ControlId = null;
            this.cmb_Machine.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmb_Machine.FormattingEnabled = true;
            this.cmb_Machine.Location = new System.Drawing.Point(16, 75);
            this.cmb_Machine.Name = "cmb_Machine";
            this.cmb_Machine.Size = new System.Drawing.Size(149, 24);
            this.cmb_Machine.TabIndex = 117;
            // 
            // labelCommon6
            // 
            this.labelCommon6.AutoSize = true;
            this.labelCommon6.ControlId = null;
            this.labelCommon6.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCommon6.Location = new System.Drawing.Point(13, 58);
            this.labelCommon6.Name = "labelCommon6";
            this.labelCommon6.Size = new System.Drawing.Size(65, 16);
            this.labelCommon6.TabIndex = 116;
            this.labelCommon6.Text = "Machine:";
            // 
            // labelCommon2
            // 
            this.labelCommon2.AutoSize = true;
            this.labelCommon2.ControlId = null;
            this.labelCommon2.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCommon2.Location = new System.Drawing.Point(13, 12);
            this.labelCommon2.Name = "labelCommon2";
            this.labelCommon2.Size = new System.Drawing.Size(45, 16);
            this.labelCommon2.TabIndex = 113;
            this.labelCommon2.Text = "From:";
            // 
            // labelCommon1
            // 
            this.labelCommon1.AutoSize = true;
            this.labelCommon1.ControlId = null;
            this.labelCommon1.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCommon1.Location = new System.Drawing.Point(178, 12);
            this.labelCommon1.Name = "labelCommon1";
            this.labelCommon1.Size = new System.Drawing.Size(29, 16);
            this.labelCommon1.TabIndex = 112;
            this.labelCommon1.Text = "To:";
            // 
            // dtp_From
            // 
            this.dtp_From.Checked = false;
            this.dtp_From.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.dtp_From.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtp_From.Location = new System.Drawing.Point(13, 32);
            this.dtp_From.Name = "dtp_From";
            this.dtp_From.Size = new System.Drawing.Size(152, 21);
            this.dtp_From.TabIndex = 110;
            // 
            // dtp_To
            // 
            this.dtp_To.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.dtp_To.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtp_To.Location = new System.Drawing.Point(181, 31);
            this.dtp_To.Name = "dtp_To";
            this.dtp_To.Size = new System.Drawing.Size(152, 21);
            this.dtp_To.TabIndex = 111;
            // 
            // NoiseCheckForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(460, 554);
            this.Controls.Add(this.groupBoxCommon4);
            this.Controls.Add(this.groupBoxCommon3);
            this.Controls.Add(this.groupBoxCommon2);
            this.Controls.Add(this.dgvNoise);
            this.Controls.Add(this.groupBoxCommon1);
            this.Name = "NoiseCheckForm";
            this.Text = "Noise Check";
            this.TitleText = "FormCommon";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.NoiseCheckForm_FormClosing);
            this.Load += new System.EventHandler(this.NoiseCheckForm_Load);
            this.Controls.SetChildIndex(this.groupBoxCommon1, 0);
            this.Controls.SetChildIndex(this.dgvNoise, 0);
            this.Controls.SetChildIndex(this.groupBoxCommon2, 0);
            this.Controls.SetChildIndex(this.groupBoxCommon3, 0);
            this.Controls.SetChildIndex(this.groupBoxCommon4, 0);
            this.groupBoxCommon1.ResumeLayout(false);
            this.groupBoxCommon1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNoise)).EndInit();
            this.groupBoxCommon2.ResumeLayout(false);
            this.groupBoxCommon2.PerformLayout();
            this.groupBoxCommon3.ResumeLayout(false);
            this.groupBoxCommon3.PerformLayout();
            this.groupBoxCommon4.ResumeLayout(false);
            this.groupBoxCommon4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Framework.TextBoxCommon txtBarcode;
        private Framework.GroupBoxCommon groupBoxCommon1;
        private Framework.TextBoxCommon txtBrowser;
        private Framework.ButtonCommon btnBrowser;
        private Framework.LabelCommon lbl;
        private Framework.DataGridViewCommon dgvNoise;
        private System.Windows.Forms.Timer timer1;
        private Framework.GroupBoxCommon groupBoxCommon2;
        private Framework.GroupBoxCommon groupBoxCommon3;
        private Framework.LabelCommon lblThurst;
        private Framework.LabelCommon labelCommon4;
        private Framework.LabelCommon labelCommon3;
        private Framework.LabelCommon lblNoise;
        private System.Windows.Forms.Timer timerOff;
        private System.Windows.Forms.Timer timerOffBarcodenull;
        private Framework.LabelCommon lblcountThurst;
        private Framework.ButtonCommon btnExport;
        private Framework.GroupBoxCommon groupBoxCommon4;
        private Framework.LabelCommon labelCommon2;
        private Framework.LabelCommon labelCommon1;
        private System.Windows.Forms.DateTimePicker dtp_From;
        private System.Windows.Forms.DateTimePicker dtp_To;
        private Framework.ComboBoxCommon cmb_Machine;
        private Framework.LabelCommon labelCommon6;
        private Framework.LabelCommon lblCount;
        private Framework.ButtonCommon btnResetCount;
        private Framework.LabelCommon labelCommon5;
        private System.Windows.Forms.Panel panel1;
        private Framework.LabelCommon lblteach;
        private Framework.LabelCommon lbldatetime;
    }
}