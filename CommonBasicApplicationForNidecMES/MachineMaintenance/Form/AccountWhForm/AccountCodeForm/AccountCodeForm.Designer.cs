namespace Com.Nidec.Mes.Common.Basic.MachineMaintenance.Form.AccountWhForm.AccountCodeForm
{
    partial class AccountCodeForm
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
            this.AccountDetails_dgv = new Com.Nidec.Mes.Framework.DataGridViewCommon();
            this.colAccountCodeId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAccountCodeCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAccountCodeName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Clear_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.Exit_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.Delete_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.Update_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.Add_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.Search_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.AccountName_txt = new Com.Nidec.Mes.Framework.TextBoxCommon();
            this.AccountName_lbl = new Com.Nidec.Mes.Framework.LabelCommon();
            this.AccountCode_txt = new Com.Nidec.Mes.Framework.TextBoxCommon();
            this.AccountCode_lbl = new Com.Nidec.Mes.Framework.LabelCommon();
            ((System.ComponentModel.ISupportInitialize)(this.AccountDetails_dgv)).BeginInit();
            this.SuspendLayout();
            // 
            // AccountDetails_dgv
            // 
            this.AccountDetails_dgv.AllowUserToAddRows = false;
            this.AccountDetails_dgv.AllowUserToDeleteRows = false;
            this.AccountDetails_dgv.AllowUserToOrderColumns = true;
            this.AccountDetails_dgv.AllowUserToResizeRows = false;
            this.AccountDetails_dgv.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(232)))), ((int)(((byte)(180)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.AccountDetails_dgv.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.AccountDetails_dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.AccountDetails_dgv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colAccountCodeId,
            this.colAccountCodeCode,
            this.colAccountCodeName});
            this.AccountDetails_dgv.ControlId = null;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.AccountDetails_dgv.DefaultCellStyle = dataGridViewCellStyle2;
            this.AccountDetails_dgv.EnableHeadersVisualStyles = false;
            this.AccountDetails_dgv.Location = new System.Drawing.Point(0, 183);
            this.AccountDetails_dgv.MultiSelect = false;
            this.AccountDetails_dgv.Name = "AccountDetails_dgv";
            this.AccountDetails_dgv.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(232)))), ((int)(((byte)(180)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.AccountDetails_dgv.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.AccountDetails_dgv.RowHeadersVisible = false;
            this.AccountDetails_dgv.RowTemplate.Height = 21;
            this.AccountDetails_dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.AccountDetails_dgv.Size = new System.Drawing.Size(788, 257);
            this.AccountDetails_dgv.TabIndex = 33;
            this.AccountDetails_dgv.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.AccountDetails_dgv_CellClick);
            this.AccountDetails_dgv.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.AccountDetails_dgv_CellDoubleClick);
            // 
            // colAccountCodeId
            // 
            this.colAccountCodeId.DataPropertyName = "AccountCodeId";
            this.colAccountCodeId.HeaderText = "Account Code Id";
            this.colAccountCodeId.Name = "colAccountCodeId";
            this.colAccountCodeId.ReadOnly = true;
            this.colAccountCodeId.Visible = false;
            // 
            // colAccountCodeCode
            // 
            this.colAccountCodeCode.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colAccountCodeCode.DataPropertyName = "AccountCodeCode";
            this.colAccountCodeCode.HeaderText = "Account Code";
            this.colAccountCodeCode.Name = "colAccountCodeCode";
            this.colAccountCodeCode.ReadOnly = true;
            // 
            // colAccountCodeName
            // 
            this.colAccountCodeName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colAccountCodeName.DataPropertyName = "AccountCodeName";
            this.colAccountCodeName.HeaderText = "Account Name";
            this.colAccountCodeName.Name = "colAccountCodeName";
            this.colAccountCodeName.ReadOnly = true;
            // 
            // Clear_btn
            // 
            this.Clear_btn.BackColor = System.Drawing.SystemColors.Control;
            this.Clear_btn.ControlId = null;
            this.Clear_btn.Font = new System.Drawing.Font("Arial", 9F);
            this.Clear_btn.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.Clear_btn.Location = new System.Drawing.Point(675, 147);
            this.Clear_btn.Name = "Clear_btn";
            this.Clear_btn.Size = new System.Drawing.Size(80, 33);
            this.Clear_btn.TabIndex = 29;
            this.Clear_btn.Text = "Clear";
            this.Clear_btn.UseVisualStyleBackColor = true;
            this.Clear_btn.Click += new System.EventHandler(this.Clear_btn_Click);
            // 
            // Exit_btn
            // 
            this.Exit_btn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Exit_btn.BackColor = System.Drawing.SystemColors.Control;
            this.Exit_btn.ControlId = null;
            this.Exit_btn.Font = new System.Drawing.Font("Arial", 9F);
            this.Exit_btn.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.Exit_btn.Location = new System.Drawing.Point(675, 443);
            this.Exit_btn.Name = "Exit_btn";
            this.Exit_btn.Size = new System.Drawing.Size(80, 33);
            this.Exit_btn.TabIndex = 32;
            this.Exit_btn.Text = "Exit";
            this.Exit_btn.UseVisualStyleBackColor = true;
            this.Exit_btn.Click += new System.EventHandler(this.Exit_btn_Click);
            // 
            // Delete_btn
            // 
            this.Delete_btn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Delete_btn.BackColor = System.Drawing.SystemColors.Control;
            this.Delete_btn.ControlId = null;
            this.Delete_btn.Font = new System.Drawing.Font("Arial", 9F);
            this.Delete_btn.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.Delete_btn.Location = new System.Drawing.Point(581, 443);
            this.Delete_btn.Name = "Delete_btn";
            this.Delete_btn.Size = new System.Drawing.Size(80, 33);
            this.Delete_btn.TabIndex = 31;
            this.Delete_btn.Text = "Delete";
            this.Delete_btn.UseVisualStyleBackColor = true;
            this.Delete_btn.Click += new System.EventHandler(this.Delete_btn_Click);
            // 
            // Update_btn
            // 
            this.Update_btn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Update_btn.BackColor = System.Drawing.SystemColors.Control;
            this.Update_btn.ControlId = null;
            this.Update_btn.Font = new System.Drawing.Font("Arial", 9F);
            this.Update_btn.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.Update_btn.Location = new System.Drawing.Point(487, 443);
            this.Update_btn.Name = "Update_btn";
            this.Update_btn.Size = new System.Drawing.Size(80, 33);
            this.Update_btn.TabIndex = 30;
            this.Update_btn.Text = "Update";
            this.Update_btn.UseVisualStyleBackColor = true;
            this.Update_btn.Click += new System.EventHandler(this.Update_btn_Click);
            // 
            // Add_btn
            // 
            this.Add_btn.BackColor = System.Drawing.SystemColors.Control;
            this.Add_btn.ControlId = null;
            this.Add_btn.Font = new System.Drawing.Font("Arial", 9F);
            this.Add_btn.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.Add_btn.Location = new System.Drawing.Point(581, 147);
            this.Add_btn.Name = "Add_btn";
            this.Add_btn.Size = new System.Drawing.Size(80, 33);
            this.Add_btn.TabIndex = 28;
            this.Add_btn.Text = "Add";
            this.Add_btn.UseVisualStyleBackColor = true;
            this.Add_btn.Click += new System.EventHandler(this.Add_btn_Click);
            // 
            // Search_btn
            // 
            this.Search_btn.BackColor = System.Drawing.SystemColors.Control;
            this.Search_btn.ControlId = null;
            this.Search_btn.Font = new System.Drawing.Font("Arial", 9F);
            this.Search_btn.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.Search_btn.Location = new System.Drawing.Point(487, 147);
            this.Search_btn.Name = "Search_btn";
            this.Search_btn.Size = new System.Drawing.Size(80, 33);
            this.Search_btn.TabIndex = 27;
            this.Search_btn.Text = "Search";
            this.Search_btn.UseVisualStyleBackColor = true;
            this.Search_btn.Click += new System.EventHandler(this.Search_btn_Click);
            // 
            // AccountName_txt
            // 
            this.AccountName_txt.ControlId = null;
            this.AccountName_txt.Font = new System.Drawing.Font("Arial", 9F);
            this.AccountName_txt.InputType = Com.Nidec.Mes.Framework.TextBoxCommon.InputTypeList.All;
            this.AccountName_txt.Location = new System.Drawing.Point(118, 153);
            this.AccountName_txt.MaxLength = 32;
            this.AccountName_txt.Name = "AccountName_txt";
            this.AccountName_txt.Size = new System.Drawing.Size(187, 21);
            this.AccountName_txt.TabIndex = 26;
            // 
            // AccountName_lbl
            // 
            this.AccountName_lbl.AutoSize = true;
            this.AccountName_lbl.ControlId = null;
            this.AccountName_lbl.Font = new System.Drawing.Font("Arial", 9F);
            this.AccountName_lbl.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.AccountName_lbl.Location = new System.Drawing.Point(32, 156);
            this.AccountName_lbl.Name = "AccountName_lbl";
            this.AccountName_lbl.Size = new System.Drawing.Size(87, 15);
            this.AccountName_lbl.TabIndex = 25;
            this.AccountName_lbl.Text = "Account Name";
            // 
            // AccountCode_txt
            // 
            this.AccountCode_txt.ControlId = null;
            this.AccountCode_txt.Font = new System.Drawing.Font("Arial", 9F);
            this.AccountCode_txt.InputType = Com.Nidec.Mes.Framework.TextBoxCommon.InputTypeList.All;
            this.AccountCode_txt.Location = new System.Drawing.Point(118, 123);
            this.AccountCode_txt.MaxLength = 32;
            this.AccountCode_txt.Name = "AccountCode_txt";
            this.AccountCode_txt.Size = new System.Drawing.Size(187, 21);
            this.AccountCode_txt.TabIndex = 24;
            // 
            // AccountCode_lbl
            // 
            this.AccountCode_lbl.AutoSize = true;
            this.AccountCode_lbl.ControlId = null;
            this.AccountCode_lbl.Font = new System.Drawing.Font("Arial", 9F);
            this.AccountCode_lbl.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.AccountCode_lbl.Location = new System.Drawing.Point(32, 126);
            this.AccountCode_lbl.Name = "AccountCode_lbl";
            this.AccountCode_lbl.Size = new System.Drawing.Size(83, 15);
            this.AccountCode_lbl.TabIndex = 23;
            this.AccountCode_lbl.Text = "Account Code";
            // 
            // AccountCodeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(788, 480);
            this.Controls.Add(this.AccountDetails_dgv);
            this.Controls.Add(this.Clear_btn);
            this.Controls.Add(this.Exit_btn);
            this.Controls.Add(this.Delete_btn);
            this.Controls.Add(this.Update_btn);
            this.Controls.Add(this.Add_btn);
            this.Controls.Add(this.Search_btn);
            this.Controls.Add(this.AccountName_txt);
            this.Controls.Add(this.AccountName_lbl);
            this.Controls.Add(this.AccountCode_txt);
            this.Controls.Add(this.AccountCode_lbl);
            this.Name = "AccountCodeForm";
            this.Text = "Account Code";
            this.TitleText = "Account Code";
            this.Controls.SetChildIndex(this.AccountCode_lbl, 0);
            this.Controls.SetChildIndex(this.AccountCode_txt, 0);
            this.Controls.SetChildIndex(this.AccountName_lbl, 0);
            this.Controls.SetChildIndex(this.AccountName_txt, 0);
            this.Controls.SetChildIndex(this.Search_btn, 0);
            this.Controls.SetChildIndex(this.Add_btn, 0);
            this.Controls.SetChildIndex(this.Update_btn, 0);
            this.Controls.SetChildIndex(this.Delete_btn, 0);
            this.Controls.SetChildIndex(this.Exit_btn, 0);
            this.Controls.SetChildIndex(this.Clear_btn, 0);
            this.Controls.SetChildIndex(this.AccountDetails_dgv, 0);
            ((System.ComponentModel.ISupportInitialize)(this.AccountDetails_dgv)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal Framework.DataGridViewCommon AccountDetails_dgv;
        private Framework.ButtonCommon Clear_btn;
        private Framework.ButtonCommon Exit_btn;
        private Framework.ButtonCommon Delete_btn;
        private Framework.ButtonCommon Update_btn;
        private Framework.ButtonCommon Add_btn;
        private Framework.ButtonCommon Search_btn;
        private Framework.TextBoxCommon AccountName_txt;
        private Framework.LabelCommon AccountName_lbl;
        private Framework.TextBoxCommon AccountCode_txt;
        private Framework.LabelCommon AccountCode_lbl;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAccountCodeId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAccountCodeCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAccountCodeName;
    }
}
