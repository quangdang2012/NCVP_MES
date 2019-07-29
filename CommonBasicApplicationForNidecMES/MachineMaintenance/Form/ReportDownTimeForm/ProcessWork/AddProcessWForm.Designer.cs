namespace Com.Nidec.Mes.Common.Basic.MachineMaintenance
{
    partial class AddProcessWForm
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
            this.UpdateText_lbl = new Com.Nidec.Mes.Framework.LabelCommon();
            this.labelCommon1 = new Com.Nidec.Mes.Framework.LabelCommon();
            this.labelCommon2 = new Com.Nidec.Mes.Framework.LabelCommon();
            this.Exit_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.Ok_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.ProcessName_txt = new Com.Nidec.Mes.Framework.TextBoxCommon();
            this.ProcessName_lbl = new Com.Nidec.Mes.Framework.LabelCommon();
            this.ProcessCode_txt = new Com.Nidec.Mes.Framework.TextBoxCommon();
            this.ProcessCode_lbl = new Com.Nidec.Mes.Framework.LabelCommon();
            this.Model_lbl = new Com.Nidec.Mes.Framework.LabelCommon();
            this.Assy_lbl = new Com.Nidec.Mes.Framework.LabelCommon();
            this.Machine_lbl = new Com.Nidec.Mes.Framework.LabelCommon();
            this.Model_cmb = new Com.Nidec.Mes.Framework.ComboBoxCommon();
            this.Assy_cmb = new Com.Nidec.Mes.Framework.ComboBoxCommon();
            this.Machine_cmb = new Com.Nidec.Mes.Framework.ComboBoxCommon();
            this.labelCommon3 = new Com.Nidec.Mes.Framework.LabelCommon();
            this.labelCommon4 = new Com.Nidec.Mes.Framework.LabelCommon();
            this.labelCommon5 = new Com.Nidec.Mes.Framework.LabelCommon();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // UpdateText_lbl
            // 
            this.UpdateText_lbl.AutoSize = true;
            this.UpdateText_lbl.ControlId = null;
            this.UpdateText_lbl.Font = new System.Drawing.Font("Arial", 9F);
            this.UpdateText_lbl.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.UpdateText_lbl.Location = new System.Drawing.Point(3, 3);
            this.UpdateText_lbl.Name = "UpdateText_lbl";
            this.UpdateText_lbl.Size = new System.Drawing.Size(96, 15);
            this.UpdateText_lbl.TabIndex = 32;
            this.UpdateText_lbl.Text = "Update Process";
            this.UpdateText_lbl.Visible = false;
            // 
            // labelCommon1
            // 
            this.labelCommon1.AutoSize = true;
            this.labelCommon1.ControlId = null;
            this.labelCommon1.Font = new System.Drawing.Font("Arial", 9F);
            this.labelCommon1.ForeColor = System.Drawing.Color.DarkRed;
            this.labelCommon1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.labelCommon1.Location = new System.Drawing.Point(420, 75);
            this.labelCommon1.Name = "labelCommon1";
            this.labelCommon1.Size = new System.Drawing.Size(27, 15);
            this.labelCommon1.TabIndex = 30;
            this.labelCommon1.Text = "(＊)";
            this.labelCommon1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelCommon2
            // 
            this.labelCommon2.AutoSize = true;
            this.labelCommon2.ControlId = null;
            this.labelCommon2.Font = new System.Drawing.Font("Arial", 9F);
            this.labelCommon2.ForeColor = System.Drawing.Color.DarkRed;
            this.labelCommon2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.labelCommon2.Location = new System.Drawing.Point(420, 50);
            this.labelCommon2.Name = "labelCommon2";
            this.labelCommon2.Size = new System.Drawing.Size(27, 15);
            this.labelCommon2.TabIndex = 31;
            this.labelCommon2.Text = "(＊)";
            this.labelCommon2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Exit_btn
            // 
            this.Exit_btn.BackColor = System.Drawing.SystemColors.Control;
            this.Exit_btn.ControlId = null;
            this.Exit_btn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Exit_btn.Font = new System.Drawing.Font("Arial", 9F);
            this.Exit_btn.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.Exit_btn.Location = new System.Drawing.Point(138, 3);
            this.Exit_btn.Name = "Exit_btn";
            this.Exit_btn.Size = new System.Drawing.Size(82, 33);
            this.Exit_btn.TabIndex = 29;
            this.Exit_btn.Text = "Exit";
            this.Exit_btn.UseVisualStyleBackColor = true;
            this.Exit_btn.Click += new System.EventHandler(this.Exit_btn_Click);
            // 
            // Ok_btn
            // 
            this.Ok_btn.BackColor = System.Drawing.SystemColors.Control;
            this.Ok_btn.ControlId = null;
            this.Ok_btn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Ok_btn.Font = new System.Drawing.Font("Arial", 9F);
            this.Ok_btn.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.Ok_btn.Location = new System.Drawing.Point(3, 3);
            this.Ok_btn.Name = "Ok_btn";
            this.Ok_btn.Size = new System.Drawing.Size(81, 33);
            this.Ok_btn.TabIndex = 28;
            this.Ok_btn.Text = "OK";
            this.Ok_btn.UseVisualStyleBackColor = true;
            this.Ok_btn.Click += new System.EventHandler(this.Ok_btn_Click);
            // 
            // ProcessName_txt
            // 
            this.ProcessName_txt.ControlId = null;
            this.ProcessName_txt.Font = new System.Drawing.Font("Arial", 9F);
            this.ProcessName_txt.InputType = Com.Nidec.Mes.Framework.TextBoxCommon.InputTypeList.All;
            this.ProcessName_txt.Location = new System.Drawing.Point(110, 78);
            this.ProcessName_txt.MaxLength = 0;
            this.ProcessName_txt.Name = "ProcessName_txt";
            this.ProcessName_txt.Size = new System.Drawing.Size(304, 21);
            this.ProcessName_txt.TabIndex = 27;
            // 
            // ProcessName_lbl
            // 
            this.ProcessName_lbl.AutoSize = true;
            this.ProcessName_lbl.ControlId = null;
            this.ProcessName_lbl.Font = new System.Drawing.Font("Arial", 9F);
            this.ProcessName_lbl.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.ProcessName_lbl.Location = new System.Drawing.Point(3, 75);
            this.ProcessName_lbl.Name = "ProcessName_lbl";
            this.ProcessName_lbl.Size = new System.Drawing.Size(90, 15);
            this.ProcessName_lbl.TabIndex = 26;
            this.ProcessName_lbl.Text = "Process Name";
            // 
            // ProcessCode_txt
            // 
            this.ProcessCode_txt.ControlId = null;
            this.ProcessCode_txt.Font = new System.Drawing.Font("Arial", 9F);
            this.ProcessCode_txt.InputType = Com.Nidec.Mes.Framework.TextBoxCommon.InputTypeList.All;
            this.ProcessCode_txt.Location = new System.Drawing.Point(110, 53);
            this.ProcessCode_txt.MaxLength = 0;
            this.ProcessCode_txt.Name = "ProcessCode_txt";
            this.ProcessCode_txt.Size = new System.Drawing.Size(304, 21);
            this.ProcessCode_txt.TabIndex = 25;
            // 
            // ProcessCode_lbl
            // 
            this.ProcessCode_lbl.AutoSize = true;
            this.ProcessCode_lbl.ControlId = null;
            this.ProcessCode_lbl.Font = new System.Drawing.Font("Arial", 9F);
            this.ProcessCode_lbl.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.ProcessCode_lbl.Location = new System.Drawing.Point(3, 50);
            this.ProcessCode_lbl.Name = "ProcessCode_lbl";
            this.ProcessCode_lbl.Size = new System.Drawing.Size(86, 15);
            this.ProcessCode_lbl.TabIndex = 24;
            this.ProcessCode_lbl.Text = "Process Code";
            // 
            // Model_lbl
            // 
            this.Model_lbl.AutoSize = true;
            this.Model_lbl.ControlId = null;
            this.Model_lbl.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Model_lbl.Location = new System.Drawing.Point(3, 100);
            this.Model_lbl.Name = "Model_lbl";
            this.Model_lbl.Size = new System.Drawing.Size(40, 15);
            this.Model_lbl.TabIndex = 33;
            this.Model_lbl.Text = "Model";
            // 
            // Assy_lbl
            // 
            this.Assy_lbl.AutoSize = true;
            this.Assy_lbl.ControlId = null;
            this.Assy_lbl.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Assy_lbl.Location = new System.Drawing.Point(3, 125);
            this.Assy_lbl.Name = "Assy_lbl";
            this.Assy_lbl.Size = new System.Drawing.Size(33, 15);
            this.Assy_lbl.TabIndex = 34;
            this.Assy_lbl.Text = "Assy";
            // 
            // Machine_lbl
            // 
            this.Machine_lbl.AutoSize = true;
            this.Machine_lbl.ControlId = null;
            this.Machine_lbl.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Machine_lbl.Location = new System.Drawing.Point(3, 150);
            this.Machine_lbl.Name = "Machine_lbl";
            this.Machine_lbl.Size = new System.Drawing.Size(53, 15);
            this.Machine_lbl.TabIndex = 34;
            this.Machine_lbl.Text = "Machine";
            // 
            // Model_cmb
            // 
            this.Model_cmb.ControlId = null;
            this.Model_cmb.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Model_cmb.FormattingEnabled = true;
            this.Model_cmb.Location = new System.Drawing.Point(110, 103);
            this.Model_cmb.Name = "Model_cmb";
            this.Model_cmb.Size = new System.Drawing.Size(304, 23);
            this.Model_cmb.TabIndex = 35;
            // 
            // Assy_cmb
            // 
            this.Assy_cmb.ControlId = null;
            this.Assy_cmb.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Assy_cmb.FormattingEnabled = true;
            this.Assy_cmb.Location = new System.Drawing.Point(110, 128);
            this.Assy_cmb.Name = "Assy_cmb";
            this.Assy_cmb.Size = new System.Drawing.Size(304, 23);
            this.Assy_cmb.TabIndex = 36;
            // 
            // Machine_cmb
            // 
            this.Machine_cmb.ControlId = null;
            this.Machine_cmb.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Machine_cmb.FormattingEnabled = true;
            this.Machine_cmb.Location = new System.Drawing.Point(110, 153);
            this.Machine_cmb.Name = "Machine_cmb";
            this.Machine_cmb.Size = new System.Drawing.Size(304, 23);
            this.Machine_cmb.TabIndex = 37;
            // 
            // labelCommon3
            // 
            this.labelCommon3.AutoSize = true;
            this.labelCommon3.ControlId = null;
            this.labelCommon3.Font = new System.Drawing.Font("Arial", 9F);
            this.labelCommon3.ForeColor = System.Drawing.Color.DarkRed;
            this.labelCommon3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.labelCommon3.Location = new System.Drawing.Point(420, 125);
            this.labelCommon3.Name = "labelCommon3";
            this.labelCommon3.Size = new System.Drawing.Size(27, 15);
            this.labelCommon3.TabIndex = 38;
            this.labelCommon3.Text = "(＊)";
            this.labelCommon3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelCommon4
            // 
            this.labelCommon4.AutoSize = true;
            this.labelCommon4.ControlId = null;
            this.labelCommon4.Font = new System.Drawing.Font("Arial", 9F);
            this.labelCommon4.ForeColor = System.Drawing.Color.DarkRed;
            this.labelCommon4.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.labelCommon4.Location = new System.Drawing.Point(420, 100);
            this.labelCommon4.Name = "labelCommon4";
            this.labelCommon4.Size = new System.Drawing.Size(27, 15);
            this.labelCommon4.TabIndex = 39;
            this.labelCommon4.Text = "(＊)";
            this.labelCommon4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelCommon5
            // 
            this.labelCommon5.AutoSize = true;
            this.labelCommon5.ControlId = null;
            this.labelCommon5.Font = new System.Drawing.Font("Arial", 9F);
            this.labelCommon5.ForeColor = System.Drawing.Color.DarkRed;
            this.labelCommon5.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.labelCommon5.Location = new System.Drawing.Point(420, 150);
            this.labelCommon5.Name = "labelCommon5";
            this.labelCommon5.Size = new System.Drawing.Size(27, 15);
            this.labelCommon5.TabIndex = 38;
            this.labelCommon5.Text = "(＊)";
            this.labelCommon5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 23.3211F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 67.58799F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 9.090908F));
            this.tableLayoutPanel1.Controls.Add(this.labelCommon5, 2, 6);
            this.tableLayoutPanel1.Controls.Add(this.ProcessCode_lbl, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.labelCommon3, 2, 5);
            this.tableLayoutPanel1.Controls.Add(this.ProcessName_lbl, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.labelCommon4, 2, 4);
            this.tableLayoutPanel1.Controls.Add(this.Model_lbl, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.labelCommon1, 2, 3);
            this.tableLayoutPanel1.Controls.Add(this.Machine_cmb, 1, 6);
            this.tableLayoutPanel1.Controls.Add(this.labelCommon2, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.Assy_lbl, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.Assy_cmb, 1, 5);
            this.tableLayoutPanel1.Controls.Add(this.Machine_lbl, 0, 6);
            this.tableLayoutPanel1.Controls.Add(this.Model_cmb, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.ProcessCode_txt, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.ProcessName_txt, 1, 3);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 9;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(459, 227);
            this.tableLayoutPanel1.TabIndex = 40;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 107);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.tableLayoutPanel1);
            this.splitContainer1.Panel1.Controls.Add(this.UpdateText_lbl);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tableLayoutPanel2);
            this.splitContainer1.Size = new System.Drawing.Size(459, 300);
            this.splitContainer1.SplitterDistance = 227;
            this.splitContainer1.TabIndex = 41;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.tableLayoutPanel2.ColumnCount = 3;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 39.06705F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 21.86589F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 39.06705F));
            this.tableLayoutPanel2.Controls.Add(this.Ok_btn, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.Exit_btn, 2, 0);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(120, 15);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(223, 39);
            this.tableLayoutPanel2.TabIndex = 30;
            // 
            // AddProcessWForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(459, 407);
            this.Controls.Add(this.splitContainer1);
            this.Name = "AddProcessWForm";
            this.Text = "Add Process Work";
            this.TitleText = "FormCommon";
            this.Load += new System.EventHandler(this.AddProcessWForm_Load);
            this.Controls.SetChildIndex(this.splitContainer1, 0);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Framework.LabelCommon UpdateText_lbl;
        private Framework.LabelCommon labelCommon1;
        private Framework.LabelCommon labelCommon2;
        private Framework.ButtonCommon Exit_btn;
        private Framework.ButtonCommon Ok_btn;
        private Framework.TextBoxCommon ProcessName_txt;
        private Framework.LabelCommon ProcessName_lbl;
        private Framework.TextBoxCommon ProcessCode_txt;
        private Framework.LabelCommon ProcessCode_lbl;
        private Framework.LabelCommon Model_lbl;
        private Framework.LabelCommon Assy_lbl;
        private Framework.LabelCommon Machine_lbl;
        private Framework.ComboBoxCommon Model_cmb;
        private Framework.ComboBoxCommon Assy_cmb;
        private Framework.ComboBoxCommon Machine_cmb;
        private Framework.LabelCommon labelCommon3;
        private Framework.LabelCommon labelCommon4;
        private Framework.LabelCommon labelCommon5;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
    }
}
