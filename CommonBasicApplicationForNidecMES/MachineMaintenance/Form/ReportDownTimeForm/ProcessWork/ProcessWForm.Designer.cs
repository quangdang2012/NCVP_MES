namespace Com.Nidec.Mes.Common.Basic.MachineMaintenance
{
    partial class ProcessWForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.Clear_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.Exit_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.Delete_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.Update_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.ProcessWDetails_dgv = new Com.Nidec.Mes.Framework.DataGridViewCommon();
            this.colProcessWorkId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colProcessWorkCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colProcessWorkName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colModelCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAssy = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMachineName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Add_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.Search_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.ProcessWorkName_txt = new Com.Nidec.Mes.Framework.TextBoxCommon();
            this.RankName_lbl = new Com.Nidec.Mes.Framework.LabelCommon();
            this.ProcessWorkCode_txt = new Com.Nidec.Mes.Framework.TextBoxCommon();
            this.ProWCode_lbl = new Com.Nidec.Mes.Framework.LabelCommon();
            this.Machine_cmb = new Com.Nidec.Mes.Framework.ComboBoxCommon();
            this.Machine_lbl = new Com.Nidec.Mes.Framework.LabelCommon();
            ((System.ComponentModel.ISupportInitialize)(this.ProcessWDetails_dgv)).BeginInit();
            this.SuspendLayout();
            // 
            // Clear_btn
            // 
            this.Clear_btn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Clear_btn.BackColor = System.Drawing.SystemColors.Control;
            this.Clear_btn.ControlId = null;
            this.Clear_btn.Font = new System.Drawing.Font("Arial", 9F);
            this.Clear_btn.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.Clear_btn.Location = new System.Drawing.Point(794, 137);
            this.Clear_btn.Name = "Clear_btn";
            this.Clear_btn.Size = new System.Drawing.Size(80, 33);
            this.Clear_btn.TabIndex = 18;
            this.Clear_btn.Text = "Clear";
            this.Clear_btn.UseVisualStyleBackColor = true;
            this.Clear_btn.Click += new System.EventHandler(this.Clear_btn_Click);
            // 
            // Exit_btn
            // 
            this.Exit_btn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Exit_btn.BackColor = System.Drawing.SystemColors.Control;
            this.Exit_btn.ControlId = null;
            this.Exit_btn.Font = new System.Drawing.Font("Arial", 9F);
            this.Exit_btn.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.Exit_btn.Location = new System.Drawing.Point(791, 606);
            this.Exit_btn.Name = "Exit_btn";
            this.Exit_btn.Size = new System.Drawing.Size(80, 33);
            this.Exit_btn.TabIndex = 22;
            this.Exit_btn.Text = "Exit";
            this.Exit_btn.UseVisualStyleBackColor = true;
            this.Exit_btn.Click += new System.EventHandler(this.Exit_btn_Click);
            // 
            // Delete_btn
            // 
            this.Delete_btn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Delete_btn.BackColor = System.Drawing.SystemColors.Control;
            this.Delete_btn.ControlId = null;
            this.Delete_btn.Font = new System.Drawing.Font("Arial", 9F);
            this.Delete_btn.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.Delete_btn.Location = new System.Drawing.Point(697, 606);
            this.Delete_btn.Name = "Delete_btn";
            this.Delete_btn.Size = new System.Drawing.Size(80, 33);
            this.Delete_btn.TabIndex = 21;
            this.Delete_btn.Text = "Delete";
            this.Delete_btn.UseVisualStyleBackColor = true;
            this.Delete_btn.Click += new System.EventHandler(this.Delete_btn_Click);
            // 
            // Update_btn
            // 
            this.Update_btn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Update_btn.BackColor = System.Drawing.SystemColors.Control;
            this.Update_btn.ControlId = null;
            this.Update_btn.Font = new System.Drawing.Font("Arial", 9F);
            this.Update_btn.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.Update_btn.Location = new System.Drawing.Point(603, 606);
            this.Update_btn.Name = "Update_btn";
            this.Update_btn.Size = new System.Drawing.Size(80, 33);
            this.Update_btn.TabIndex = 20;
            this.Update_btn.Text = "Update";
            this.Update_btn.UseVisualStyleBackColor = true;
            this.Update_btn.Click += new System.EventHandler(this.Update_btn_Click);
            // 
            // ProcessWDetails_dgv
            // 
            this.ProcessWDetails_dgv.AllowUserToAddRows = false;
            this.ProcessWDetails_dgv.AllowUserToDeleteRows = false;
            this.ProcessWDetails_dgv.AllowUserToOrderColumns = true;
            this.ProcessWDetails_dgv.AllowUserToResizeRows = false;
            this.ProcessWDetails_dgv.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ProcessWDetails_dgv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.ProcessWDetails_dgv.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(232)))), ((int)(((byte)(180)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.ProcessWDetails_dgv.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.ProcessWDetails_dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ProcessWDetails_dgv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colProcessWorkId,
            this.colProcessWorkCode,
            this.colProcessWorkName,
            this.colModelCode,
            this.colAssy,
            this.colMachineName});
            this.ProcessWDetails_dgv.ControlId = null;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.ProcessWDetails_dgv.DefaultCellStyle = dataGridViewCellStyle2;
            this.ProcessWDetails_dgv.EnableHeadersVisualStyles = false;
            this.ProcessWDetails_dgv.Location = new System.Drawing.Point(0, 176);
            this.ProcessWDetails_dgv.MultiSelect = false;
            this.ProcessWDetails_dgv.Name = "ProcessWDetails_dgv";
            this.ProcessWDetails_dgv.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(232)))), ((int)(((byte)(180)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.ProcessWDetails_dgv.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.ProcessWDetails_dgv.RowHeadersVisible = false;
            this.ProcessWDetails_dgv.RowTemplate.Height = 21;
            this.ProcessWDetails_dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.ProcessWDetails_dgv.Size = new System.Drawing.Size(882, 424);
            this.ProcessWDetails_dgv.TabIndex = 19;
            this.ProcessWDetails_dgv.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.RankDetails_dgv_CellClick);
            this.ProcessWDetails_dgv.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.RankDetails_dgv_CellDoubleClick);
            // 
            // colProcessWorkId
            // 
            this.colProcessWorkId.DataPropertyName = "ProcessWorkId";
            this.colProcessWorkId.HeaderText = "Process Work Id";
            this.colProcessWorkId.Name = "colProcessWorkId";
            this.colProcessWorkId.ReadOnly = true;
            this.colProcessWorkId.Visible = false;
            this.colProcessWorkId.Width = 103;
            // 
            // colProcessWorkCode
            // 
            this.colProcessWorkCode.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colProcessWorkCode.DataPropertyName = "ProcessWorkCode";
            this.colProcessWorkCode.HeaderText = "Process Work Code";
            this.colProcessWorkCode.Name = "colProcessWorkCode";
            this.colProcessWorkCode.ReadOnly = true;
            // 
            // colProcessWorkName
            // 
            this.colProcessWorkName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colProcessWorkName.DataPropertyName = "ProcessWorkName";
            this.colProcessWorkName.HeaderText = "Process Work Name";
            this.colProcessWorkName.Name = "colProcessWorkName";
            this.colProcessWorkName.ReadOnly = true;
            // 
            // colModelCode
            // 
            this.colModelCode.DataPropertyName = "Model";
            this.colModelCode.HeaderText = "Model";
            this.colModelCode.Name = "colModelCode";
            this.colModelCode.ReadOnly = true;
            this.colModelCode.Width = 65;
            // 
            // colAssy
            // 
            this.colAssy.DataPropertyName = "Assy";
            this.colAssy.HeaderText = "Assy";
            this.colAssy.Name = "colAssy";
            this.colAssy.ReadOnly = true;
            this.colAssy.Width = 58;
            // 
            // colMachineName
            // 
            this.colMachineName.DataPropertyName = "Machine";
            this.colMachineName.HeaderText = "Machine";
            this.colMachineName.Name = "colMachineName";
            this.colMachineName.ReadOnly = true;
            this.colMachineName.Width = 78;
            // 
            // Add_btn
            // 
            this.Add_btn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Add_btn.BackColor = System.Drawing.SystemColors.Control;
            this.Add_btn.ControlId = null;
            this.Add_btn.Font = new System.Drawing.Font("Arial", 9F);
            this.Add_btn.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.Add_btn.Location = new System.Drawing.Point(700, 137);
            this.Add_btn.Name = "Add_btn";
            this.Add_btn.Size = new System.Drawing.Size(80, 33);
            this.Add_btn.TabIndex = 17;
            this.Add_btn.Text = "Add";
            this.Add_btn.UseVisualStyleBackColor = true;
            this.Add_btn.Click += new System.EventHandler(this.Add_btn_Click);
            // 
            // Search_btn
            // 
            this.Search_btn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Search_btn.BackColor = System.Drawing.SystemColors.Control;
            this.Search_btn.ControlId = null;
            this.Search_btn.Font = new System.Drawing.Font("Arial", 9F);
            this.Search_btn.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.Search_btn.Location = new System.Drawing.Point(606, 137);
            this.Search_btn.Name = "Search_btn";
            this.Search_btn.Size = new System.Drawing.Size(80, 33);
            this.Search_btn.TabIndex = 16;
            this.Search_btn.Text = "Search";
            this.Search_btn.UseVisualStyleBackColor = true;
            this.Search_btn.Click += new System.EventHandler(this.Search_btn_Click);
            // 
            // ProcessWorkName_txt
            // 
            this.ProcessWorkName_txt.ControlId = null;
            this.ProcessWorkName_txt.Font = new System.Drawing.Font("Arial", 9F);
            this.ProcessWorkName_txt.InputType = Com.Nidec.Mes.Framework.TextBoxCommon.InputTypeList.All;
            this.ProcessWorkName_txt.Location = new System.Drawing.Point(135, 143);
            this.ProcessWorkName_txt.MaxLength = 32;
            this.ProcessWorkName_txt.Name = "ProcessWorkName_txt";
            this.ProcessWorkName_txt.Size = new System.Drawing.Size(187, 21);
            this.ProcessWorkName_txt.TabIndex = 15;
            // 
            // RankName_lbl
            // 
            this.RankName_lbl.AutoSize = true;
            this.RankName_lbl.ControlId = null;
            this.RankName_lbl.Font = new System.Drawing.Font("Arial", 9F);
            this.RankName_lbl.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.RankName_lbl.Location = new System.Drawing.Point(12, 146);
            this.RankName_lbl.Name = "RankName_lbl";
            this.RankName_lbl.Size = new System.Drawing.Size(121, 15);
            this.RankName_lbl.TabIndex = 14;
            this.RankName_lbl.Text = "Process Work Name";
            // 
            // ProcessWorkCode_txt
            // 
            this.ProcessWorkCode_txt.ControlId = null;
            this.ProcessWorkCode_txt.Font = new System.Drawing.Font("Arial", 9F);
            this.ProcessWorkCode_txt.InputType = Com.Nidec.Mes.Framework.TextBoxCommon.InputTypeList.All;
            this.ProcessWorkCode_txt.Location = new System.Drawing.Point(135, 113);
            this.ProcessWorkCode_txt.MaxLength = 32;
            this.ProcessWorkCode_txt.Name = "ProcessWorkCode_txt";
            this.ProcessWorkCode_txt.Size = new System.Drawing.Size(187, 21);
            this.ProcessWorkCode_txt.TabIndex = 13;
            // 
            // ProWCode_lbl
            // 
            this.ProWCode_lbl.AutoSize = true;
            this.ProWCode_lbl.ControlId = null;
            this.ProWCode_lbl.Font = new System.Drawing.Font("Arial", 9F);
            this.ProWCode_lbl.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.ProWCode_lbl.Location = new System.Drawing.Point(12, 116);
            this.ProWCode_lbl.Name = "ProWCode_lbl";
            this.ProWCode_lbl.Size = new System.Drawing.Size(117, 15);
            this.ProWCode_lbl.TabIndex = 12;
            this.ProWCode_lbl.Text = "Process Work Code";
            // 
            // Machine_cmb
            // 
            this.Machine_cmb.ControlId = null;
            this.Machine_cmb.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Machine_cmb.FormattingEnabled = true;
            this.Machine_cmb.Location = new System.Drawing.Point(397, 113);
            this.Machine_cmb.Name = "Machine_cmb";
            this.Machine_cmb.Size = new System.Drawing.Size(187, 23);
            this.Machine_cmb.TabIndex = 39;
            // 
            // Machine_lbl
            // 
            this.Machine_lbl.AutoSize = true;
            this.Machine_lbl.ControlId = null;
            this.Machine_lbl.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Machine_lbl.Location = new System.Drawing.Point(338, 116);
            this.Machine_lbl.Name = "Machine_lbl";
            this.Machine_lbl.Size = new System.Drawing.Size(53, 15);
            this.Machine_lbl.TabIndex = 38;
            this.Machine_lbl.Text = "Machine";
            // 
            // ProcessWForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(882, 651);
            this.Controls.Add(this.Machine_cmb);
            this.Controls.Add(this.Machine_lbl);
            this.Controls.Add(this.Clear_btn);
            this.Controls.Add(this.Exit_btn);
            this.Controls.Add(this.Delete_btn);
            this.Controls.Add(this.Update_btn);
            this.Controls.Add(this.ProcessWDetails_dgv);
            this.Controls.Add(this.Add_btn);
            this.Controls.Add(this.Search_btn);
            this.Controls.Add(this.ProcessWorkName_txt);
            this.Controls.Add(this.RankName_lbl);
            this.Controls.Add(this.ProcessWorkCode_txt);
            this.Controls.Add(this.ProWCode_lbl);
            this.Name = "ProcessWForm";
            this.Text = "Process Work";
            this.TitleText = "FormCommon";
            this.Load += new System.EventHandler(this.ProcessWForm_Load);
            this.Controls.SetChildIndex(this.ProWCode_lbl, 0);
            this.Controls.SetChildIndex(this.ProcessWorkCode_txt, 0);
            this.Controls.SetChildIndex(this.RankName_lbl, 0);
            this.Controls.SetChildIndex(this.ProcessWorkName_txt, 0);
            this.Controls.SetChildIndex(this.Search_btn, 0);
            this.Controls.SetChildIndex(this.Add_btn, 0);
            this.Controls.SetChildIndex(this.ProcessWDetails_dgv, 0);
            this.Controls.SetChildIndex(this.Update_btn, 0);
            this.Controls.SetChildIndex(this.Delete_btn, 0);
            this.Controls.SetChildIndex(this.Exit_btn, 0);
            this.Controls.SetChildIndex(this.Clear_btn, 0);
            this.Controls.SetChildIndex(this.Machine_lbl, 0);
            this.Controls.SetChildIndex(this.Machine_cmb, 0);
            ((System.ComponentModel.ISupportInitialize)(this.ProcessWDetails_dgv)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Framework.ButtonCommon Clear_btn;
        private Framework.ButtonCommon Exit_btn;
        private Framework.ButtonCommon Delete_btn;
        private Framework.ButtonCommon Update_btn;
        internal Framework.DataGridViewCommon ProcessWDetails_dgv;
        private Framework.ButtonCommon Add_btn;
        private Framework.ButtonCommon Search_btn;
        private Framework.TextBoxCommon ProcessWorkName_txt;
        private Framework.LabelCommon RankName_lbl;
        private Framework.TextBoxCommon ProcessWorkCode_txt;
        private Framework.LabelCommon ProWCode_lbl;
        private Framework.ComboBoxCommon Machine_cmb;
        private Framework.LabelCommon Machine_lbl;
        private System.Windows.Forms.DataGridViewTextBoxColumn colProcessWorkId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colProcessWorkCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn colProcessWorkName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colModelCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAssy;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMachineName;
    }
}
