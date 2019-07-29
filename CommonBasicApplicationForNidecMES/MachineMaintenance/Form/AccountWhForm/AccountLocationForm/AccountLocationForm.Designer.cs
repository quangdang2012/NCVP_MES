namespace Com.Nidec.Mes.Common.Basic.MachineMaintenance.Form.AccountWhForm.AccountLocationForm
{
    partial class AccountLocationForm
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
            this.AccountLocationDetails_dgv = new Com.Nidec.Mes.Framework.DataGridViewCommon();
            this.Clear_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.Exit_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.Delete_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.Update_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.Add_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.Search_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.AccountLocationName_txt = new Com.Nidec.Mes.Framework.TextBoxCommon();
            this.AccountLocationName_lbl = new Com.Nidec.Mes.Framework.LabelCommon();
            this.AccountLocationCode_txt = new Com.Nidec.Mes.Framework.TextBoxCommon();
            this.AccountLocationCode_lbl = new Com.Nidec.Mes.Framework.LabelCommon();
            this.colAccountLocationCodeId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAccountLocationCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAccountLocationName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAccountlocationtype = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.AccountLocationDetails_dgv)).BeginInit();
            this.SuspendLayout();
            // 
            // AccountLocationDetails_dgv
            // 
            this.AccountLocationDetails_dgv.AllowUserToAddRows = false;
            this.AccountLocationDetails_dgv.AllowUserToDeleteRows = false;
            this.AccountLocationDetails_dgv.AllowUserToOrderColumns = true;
            this.AccountLocationDetails_dgv.AllowUserToResizeRows = false;
            this.AccountLocationDetails_dgv.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.AccountLocationDetails_dgv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(232)))), ((int)(((byte)(180)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.AccountLocationDetails_dgv.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.AccountLocationDetails_dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.AccountLocationDetails_dgv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colAccountLocationCodeId,
            this.colAccountLocationCode,
            this.colAccountLocationName,
            this.colAccountlocationtype});
            this.AccountLocationDetails_dgv.ControlId = null;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.AccountLocationDetails_dgv.DefaultCellStyle = dataGridViewCellStyle2;
            this.AccountLocationDetails_dgv.EnableHeadersVisualStyles = false;
            this.AccountLocationDetails_dgv.Location = new System.Drawing.Point(0, 170);
            this.AccountLocationDetails_dgv.MultiSelect = false;
            this.AccountLocationDetails_dgv.Name = "AccountLocationDetails_dgv";
            this.AccountLocationDetails_dgv.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(232)))), ((int)(((byte)(180)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.AccountLocationDetails_dgv.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.AccountLocationDetails_dgv.RowHeadersVisible = false;
            this.AccountLocationDetails_dgv.RowTemplate.Height = 21;
            this.AccountLocationDetails_dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.AccountLocationDetails_dgv.Size = new System.Drawing.Size(800, 239);
            this.AccountLocationDetails_dgv.TabIndex = 44;
            this.AccountLocationDetails_dgv.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.AccountLocationDetails_dgv_CellClick);
            this.AccountLocationDetails_dgv.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.AccountLocationDetails_dgv_CellDoubleClick);
            // 
            // Clear_btn
            // 
            this.Clear_btn.BackColor = System.Drawing.SystemColors.Control;
            this.Clear_btn.ControlId = null;
            this.Clear_btn.Font = new System.Drawing.Font("Arial", 9F);
            this.Clear_btn.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.Clear_btn.Location = new System.Drawing.Point(687, 134);
            this.Clear_btn.Name = "Clear_btn";
            this.Clear_btn.Size = new System.Drawing.Size(80, 33);
            this.Clear_btn.TabIndex = 40;
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
            this.Exit_btn.Location = new System.Drawing.Point(687, 415);
            this.Exit_btn.Name = "Exit_btn";
            this.Exit_btn.Size = new System.Drawing.Size(80, 33);
            this.Exit_btn.TabIndex = 43;
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
            this.Delete_btn.Location = new System.Drawing.Point(593, 415);
            this.Delete_btn.Name = "Delete_btn";
            this.Delete_btn.Size = new System.Drawing.Size(80, 33);
            this.Delete_btn.TabIndex = 42;
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
            this.Update_btn.Location = new System.Drawing.Point(499, 415);
            this.Update_btn.Name = "Update_btn";
            this.Update_btn.Size = new System.Drawing.Size(80, 33);
            this.Update_btn.TabIndex = 41;
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
            this.Add_btn.Location = new System.Drawing.Point(593, 134);
            this.Add_btn.Name = "Add_btn";
            this.Add_btn.Size = new System.Drawing.Size(80, 33);
            this.Add_btn.TabIndex = 39;
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
            this.Search_btn.Location = new System.Drawing.Point(499, 134);
            this.Search_btn.Name = "Search_btn";
            this.Search_btn.Size = new System.Drawing.Size(80, 33);
            this.Search_btn.TabIndex = 38;
            this.Search_btn.Text = "Search";
            this.Search_btn.UseVisualStyleBackColor = true;
            this.Search_btn.Click += new System.EventHandler(this.Search_btn_Click);
            // 
            // AccountLocationName_txt
            // 
            this.AccountLocationName_txt.ControlId = null;
            this.AccountLocationName_txt.Font = new System.Drawing.Font("Arial", 9F);
            this.AccountLocationName_txt.InputType = Com.Nidec.Mes.Framework.TextBoxCommon.InputTypeList.All;
            this.AccountLocationName_txt.Location = new System.Drawing.Point(183, 143);
            this.AccountLocationName_txt.MaxLength = 32;
            this.AccountLocationName_txt.Name = "AccountLocationName_txt";
            this.AccountLocationName_txt.Size = new System.Drawing.Size(187, 21);
            this.AccountLocationName_txt.TabIndex = 37;
            // 
            // AccountLocationName_lbl
            // 
            this.AccountLocationName_lbl.AutoSize = true;
            this.AccountLocationName_lbl.ControlId = null;
            this.AccountLocationName_lbl.Font = new System.Drawing.Font("Arial", 9F);
            this.AccountLocationName_lbl.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.AccountLocationName_lbl.Location = new System.Drawing.Point(44, 143);
            this.AccountLocationName_lbl.Name = "AccountLocationName_lbl";
            this.AccountLocationName_lbl.Size = new System.Drawing.Size(137, 15);
            this.AccountLocationName_lbl.TabIndex = 36;
            this.AccountLocationName_lbl.Text = "Account Location Name";
            // 
            // AccountLocationCode_txt
            // 
            this.AccountLocationCode_txt.ControlId = null;
            this.AccountLocationCode_txt.Font = new System.Drawing.Font("Arial", 9F);
            this.AccountLocationCode_txt.InputType = Com.Nidec.Mes.Framework.TextBoxCommon.InputTypeList.All;
            this.AccountLocationCode_txt.Location = new System.Drawing.Point(183, 110);
            this.AccountLocationCode_txt.MaxLength = 32;
            this.AccountLocationCode_txt.Name = "AccountLocationCode_txt";
            this.AccountLocationCode_txt.Size = new System.Drawing.Size(187, 21);
            this.AccountLocationCode_txt.TabIndex = 35;
            // 
            // AccountLocationCode_lbl
            // 
            this.AccountLocationCode_lbl.AutoSize = true;
            this.AccountLocationCode_lbl.ControlId = null;
            this.AccountLocationCode_lbl.Font = new System.Drawing.Font("Arial", 9F);
            this.AccountLocationCode_lbl.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.AccountLocationCode_lbl.Location = new System.Drawing.Point(44, 113);
            this.AccountLocationCode_lbl.Name = "AccountLocationCode_lbl";
            this.AccountLocationCode_lbl.Size = new System.Drawing.Size(133, 15);
            this.AccountLocationCode_lbl.TabIndex = 34;
            this.AccountLocationCode_lbl.Text = "Account Location Code";
            // 
            // colAccountLocationCodeId
            // 
            this.colAccountLocationCodeId.DataPropertyName = "AccountLocationId";
            this.colAccountLocationCodeId.HeaderText = "Account Location Code Id";
            this.colAccountLocationCodeId.Name = "colAccountLocationCodeId";
            this.colAccountLocationCodeId.ReadOnly = true;
            this.colAccountLocationCodeId.Visible = false;
            // 
            // colAccountLocationCode
            // 
            this.colAccountLocationCode.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colAccountLocationCode.DataPropertyName = "AccountLocationCode";
            this.colAccountLocationCode.HeaderText = "Account Location Code";
            this.colAccountLocationCode.Name = "colAccountLocationCode";
            this.colAccountLocationCode.ReadOnly = true;
            // 
            // colAccountLocationName
            // 
            this.colAccountLocationName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colAccountLocationName.DataPropertyName = "AccountLocationName";
            this.colAccountLocationName.HeaderText = "Account Location Name";
            this.colAccountLocationName.Name = "colAccountLocationName";
            this.colAccountLocationName.ReadOnly = true;
            // 
            // colAccountlocationtype
            // 
            this.colAccountlocationtype.DataPropertyName = "AccountLocationType";
            this.colAccountlocationtype.HeaderText = "Account Location Type";
            this.colAccountlocationtype.Name = "colAccountlocationtype";
            this.colAccountlocationtype.ReadOnly = true;
            this.colAccountlocationtype.Width = 153;
            // 
            // AccountLocationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(800, 460);
            this.Controls.Add(this.AccountLocationDetails_dgv);
            this.Controls.Add(this.Clear_btn);
            this.Controls.Add(this.Exit_btn);
            this.Controls.Add(this.Delete_btn);
            this.Controls.Add(this.Update_btn);
            this.Controls.Add(this.Add_btn);
            this.Controls.Add(this.Search_btn);
            this.Controls.Add(this.AccountLocationName_txt);
            this.Controls.Add(this.AccountLocationName_lbl);
            this.Controls.Add(this.AccountLocationCode_txt);
            this.Controls.Add(this.AccountLocationCode_lbl);
            this.Name = "AccountLocationForm";
            this.Text = "Account Location";
            this.TitleText = "Account Location";
            this.Controls.SetChildIndex(this.AccountLocationCode_lbl, 0);
            this.Controls.SetChildIndex(this.AccountLocationCode_txt, 0);
            this.Controls.SetChildIndex(this.AccountLocationName_lbl, 0);
            this.Controls.SetChildIndex(this.AccountLocationName_txt, 0);
            this.Controls.SetChildIndex(this.Search_btn, 0);
            this.Controls.SetChildIndex(this.Add_btn, 0);
            this.Controls.SetChildIndex(this.Update_btn, 0);
            this.Controls.SetChildIndex(this.Delete_btn, 0);
            this.Controls.SetChildIndex(this.Exit_btn, 0);
            this.Controls.SetChildIndex(this.Clear_btn, 0);
            this.Controls.SetChildIndex(this.AccountLocationDetails_dgv, 0);
            ((System.ComponentModel.ISupportInitialize)(this.AccountLocationDetails_dgv)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal Framework.DataGridViewCommon AccountLocationDetails_dgv;
        private Framework.ButtonCommon Clear_btn;
        private Framework.ButtonCommon Exit_btn;
        private Framework.ButtonCommon Delete_btn;
        private Framework.ButtonCommon Update_btn;
        private Framework.ButtonCommon Add_btn;
        private Framework.ButtonCommon Search_btn;
        private Framework.TextBoxCommon AccountLocationName_txt;
        private Framework.LabelCommon AccountLocationName_lbl;
        private Framework.TextBoxCommon AccountLocationCode_txt;
        private Framework.LabelCommon AccountLocationCode_lbl;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAccountLocationCodeId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAccountLocationCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAccountLocationName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAccountlocationtype;
    }
}
