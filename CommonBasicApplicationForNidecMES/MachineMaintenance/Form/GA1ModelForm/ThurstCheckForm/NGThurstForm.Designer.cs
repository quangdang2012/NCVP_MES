namespace Com.Nidec.Mes.Common.Basic.MachineMaintenance.Form
{
    partial class NGThurstForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_barcode = new Com.Nidec.Mes.Framework.TextBoxCommon();
            this.lbl_timer = new System.Windows.Forms.Label();
            this.lbl_barcode = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.pnlSetting = new System.Windows.Forms.TableLayoutPanel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_timer = new Com.Nidec.Mes.Framework.TextBoxCommon();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblCount = new System.Windows.Forms.Label();
            this.splitContainer4 = new System.Windows.Forms.SplitContainer();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dgv_thurst = new Com.Nidec.Mes.Framework.DataGridViewCommon();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Barcode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lbl_status = new Com.Nidec.Mes.Framework.LabelCommon();
            this.pb_NoData = new System.Windows.Forms.PictureBox();
            this.pb_NG = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.pnlSetting.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer4)).BeginInit();
            this.splitContainer4.Panel1.SuspendLayout();
            this.splitContainer4.Panel2.SuspendLayout();
            this.splitContainer4.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_thurst)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_NoData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_NG)).BeginInit();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(4, 5);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 20);
            this.label3.TabIndex = 16;
            this.label3.Text = "Count: ";
            // 
            // txt_barcode
            // 
            this.txt_barcode.ControlId = null;
            this.txt_barcode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txt_barcode.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_barcode.InputType = Com.Nidec.Mes.Framework.TextBoxCommon.InputTypeList.All;
            this.txt_barcode.Location = new System.Drawing.Point(105, 3);
            this.txt_barcode.MaxLength = 8;
            this.txt_barcode.Name = "txt_barcode";
            this.txt_barcode.Size = new System.Drawing.Size(241, 29);
            this.txt_barcode.TabIndex = 13;
            this.txt_barcode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_barcode_KeyDown);
            // 
            // lbl_timer
            // 
            this.lbl_timer.AutoSize = true;
            this.lbl_timer.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_timer.Location = new System.Drawing.Point(3, 43);
            this.lbl_timer.Margin = new System.Windows.Forms.Padding(3, 5, 3, 0);
            this.lbl_timer.Name = "lbl_timer";
            this.lbl_timer.Size = new System.Drawing.Size(52, 20);
            this.lbl_timer.TabIndex = 10;
            this.lbl_timer.Text = "Timer:";
            // 
            // lbl_barcode
            // 
            this.lbl_barcode.AutoSize = true;
            this.lbl_barcode.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_barcode.Location = new System.Drawing.Point(3, 5);
            this.lbl_barcode.Margin = new System.Windows.Forms.Padding(3, 5, 3, 0);
            this.lbl_barcode.Name = "lbl_barcode";
            this.lbl_barcode.Size = new System.Drawing.Size(73, 20);
            this.lbl_barcode.TabIndex = 9;
            this.lbl_barcode.Text = "Barcode:";
            // 
            // timer1
            // 
            this.timer1.Interval = 5000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.IsSplitterFixed = true;
            this.splitContainer1.Location = new System.Drawing.Point(0, 107);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer4);
            this.splitContainer1.Size = new System.Drawing.Size(1284, 563);
            this.splitContainer1.SplitterDistance = 77;
            this.splitContainer1.TabIndex = 17;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.IsSplitterFixed = true;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.pnlSetting);
            this.splitContainer2.Size = new System.Drawing.Size(1284, 77);
            this.splitContainer2.SplitterDistance = 624;
            this.splitContainer2.TabIndex = 19;
            // 
            // pnlSetting
            // 
            this.pnlSetting.ColumnCount = 3;
            this.pnlSetting.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 29.3578F));
            this.pnlSetting.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70.6422F));
            this.pnlSetting.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 274F));
            this.pnlSetting.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.pnlSetting.Controls.Add(this.panel3, 0, 1);
            this.pnlSetting.Controls.Add(this.txt_barcode, 1, 0);
            this.pnlSetting.Controls.Add(this.lbl_timer, 0, 1);
            this.pnlSetting.Controls.Add(this.lbl_barcode, 0, 0);
            this.pnlSetting.Controls.Add(this.panel1, 1, 1);
            this.pnlSetting.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlSetting.Location = new System.Drawing.Point(0, 0);
            this.pnlSetting.Name = "pnlSetting";
            this.pnlSetting.RowCount = 2;
            this.pnlSetting.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.pnlSetting.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.pnlSetting.Size = new System.Drawing.Size(624, 77);
            this.pnlSetting.TabIndex = 18;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.label1);
            this.panel3.Controls.Add(this.txt_timer);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(105, 41);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(241, 33);
            this.panel3.TabIndex = 16;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(104, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 20);
            this.label1.TabIndex = 16;
            this.label1.Text = "seconds";
            // 
            // txt_timer
            // 
            this.txt_timer.ControlId = null;
            this.txt_timer.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_timer.InputType = Com.Nidec.Mes.Framework.TextBoxCommon.InputTypeList.Numeric;
            this.txt_timer.Location = new System.Drawing.Point(3, 2);
            this.txt_timer.Name = "txt_timer";
            this.txt_timer.Size = new System.Drawing.Size(95, 29);
            this.txt_timer.TabIndex = 15;
            this.txt_timer.Text = "5";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblCount);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(352, 41);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(269, 33);
            this.panel1.TabIndex = 15;
            // 
            // lblCount
            // 
            this.lblCount.AutoSize = true;
            this.lblCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCount.Location = new System.Drawing.Point(59, 6);
            this.lblCount.Name = "lblCount";
            this.lblCount.Size = new System.Drawing.Size(18, 20);
            this.lblCount.TabIndex = 17;
            this.lblCount.Text = "0";
            // 
            // splitContainer4
            // 
            this.splitContainer4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer4.Location = new System.Drawing.Point(0, 0);
            this.splitContainer4.Name = "splitContainer4";
            // 
            // splitContainer4.Panel1
            // 
            this.splitContainer4.Panel1.Controls.Add(this.panel2);
            // 
            // splitContainer4.Panel2
            // 
            this.splitContainer4.Panel2.Controls.Add(this.pb_NoData);
            this.splitContainer4.Panel2.Controls.Add(this.pb_NG);
            this.splitContainer4.Size = new System.Drawing.Size(1284, 482);
            this.splitContainer4.SplitterDistance = 361;
            this.splitContainer4.TabIndex = 9;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dgv_thurst);
            this.panel2.Controls.Add(this.lbl_status);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(361, 482);
            this.panel2.TabIndex = 8;
            // 
            // dgv_thurst
            // 
            this.dgv_thurst.AllowUserToAddRows = false;
            this.dgv_thurst.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_thurst.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(232)))), ((int)(((byte)(180)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_thurst.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv_thurst.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.Barcode,
            this.Column1});
            this.dgv_thurst.ControlId = null;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_thurst.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgv_thurst.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_thurst.Location = new System.Drawing.Point(0, 0);
            this.dgv_thurst.Name = "dgv_thurst";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(232)))), ((int)(((byte)(180)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Arial Black", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_thurst.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgv_thurst.RowHeadersVisible = false;
            this.dgv_thurst.Size = new System.Drawing.Size(361, 482);
            this.dgv_thurst.TabIndex = 9;
            // 
            // id
            // 
            this.id.HeaderText = "Stt";
            this.id.Name = "id";
            this.id.Visible = false;
            // 
            // Barcode
            // 
            this.Barcode.HeaderText = "Barcode";
            this.Barcode.Name = "Barcode";
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Thurst NG";
            this.Column1.Name = "Column1";
            // 
            // lbl_status
            // 
            this.lbl_status.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.lbl_status.AutoSize = true;
            this.lbl_status.ControlId = null;
            this.lbl_status.Font = new System.Drawing.Font("Arial", 72F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_status.Location = new System.Drawing.Point(-76, 130);
            this.lbl_status.Name = "lbl_status";
            this.lbl_status.Size = new System.Drawing.Size(513, 107);
            this.lbl_status.TabIndex = 7;
            this.lbl_status.Text = "CHECKED";
            // 
            // pb_NoData
            // 
            this.pb_NoData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pb_NoData.Image = global::Com.Nidec.Mes.Common.Basic.MachineMaintenance.Properties.Resources.NoDaTa;
            this.pb_NoData.Location = new System.Drawing.Point(0, 0);
            this.pb_NoData.Name = "pb_NoData";
            this.pb_NoData.Size = new System.Drawing.Size(919, 482);
            this.pb_NoData.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pb_NoData.TabIndex = 5;
            this.pb_NoData.TabStop = false;
            // 
            // pb_NG
            // 
            this.pb_NG.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pb_NG.Image = global::Com.Nidec.Mes.Common.Basic.MachineMaintenance.Properties.Resources.NG;
            this.pb_NG.Location = new System.Drawing.Point(0, 0);
            this.pb_NG.Name = "pb_NG";
            this.pb_NG.Size = new System.Drawing.Size(919, 482);
            this.pb_NG.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pb_NG.TabIndex = 6;
            this.pb_NG.TabStop = false;
            // 
            // NGThurstForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1284, 670);
            this.Controls.Add(this.splitContainer1);
            this.Name = "NGThurstForm";
            this.Text = "NGThurstForm";
            this.TitleText = "FormCommon";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.NGThurstForm_Load);
            this.Controls.SetChildIndex(this.splitContainer1, 0);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.pnlSetting.ResumeLayout(false);
            this.pnlSetting.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.splitContainer4.Panel1.ResumeLayout(false);
            this.splitContainer4.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer4)).EndInit();
            this.splitContainer4.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_thurst)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_NoData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_NG)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label lbl_barcode;
        private System.Windows.Forms.Label lbl_timer;
        private System.Windows.Forms.Timer timer1;
        private Framework.TextBoxCommon txt_barcode;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TableLayoutPanel pnlSetting;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.SplitContainer splitContainer4;
        private System.Windows.Forms.Panel panel2;
        private Framework.DataGridViewCommon dgv_thurst;
        private Framework.LabelCommon lbl_status;
        private System.Windows.Forms.PictureBox pb_NoData;
        private System.Windows.Forms.PictureBox pb_NG;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label1;
        private Framework.TextBoxCommon txt_timer;
        private System.Windows.Forms.Label lblCount;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Barcode;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
    }
}