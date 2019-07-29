namespace Com.Nidec.Mes.Common.Basic.MachineMaintenance.Form.AccountWhForm.DetailPositionForm
{
    partial class DetailPositionForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.Clear_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.Exit_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.Delete_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.Update_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.Detail_Position_dgv = new Com.Nidec.Mes.Framework.DataGridViewCommon();
            this.Add_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.Search_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.DetailPositionName_txt = new Com.Nidec.Mes.Framework.TextBoxCommon();
            this.DetailPositionName_lbl = new Com.Nidec.Mes.Framework.LabelCommon();
            this.DetailPositionCode_txt = new Com.Nidec.Mes.Framework.TextBoxCommon();
            this.DetailPositionCode_lbl = new Com.Nidec.Mes.Framework.LabelCommon();
            this.colDetailPositionId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_locationcd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPositionCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPositionName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.locationcd_cbm = new Com.Nidec.Mes.Framework.ComboBoxCommon();
            this.locationcd_lbl = new Com.Nidec.Mes.Framework.LabelCommon();
            ((System.ComponentModel.ISupportInitialize)(this.Detail_Position_dgv)).BeginInit();
            this.SuspendLayout();
            // 
            // Clear_btn
            // 
            this.Clear_btn.BackColor = System.Drawing.SystemColors.Control;
            this.Clear_btn.ControlId = null;
            this.Clear_btn.Font = new System.Drawing.Font("Arial", 9F);
            this.Clear_btn.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.Clear_btn.Location = new System.Drawing.Point(655, 137);
            this.Clear_btn.Name = "Clear_btn";
            this.Clear_btn.Size = new System.Drawing.Size(80, 33);
            this.Clear_btn.TabIndex = 18;
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
            this.Exit_btn.Location = new System.Drawing.Point(652, 434);
            this.Exit_btn.Name = "Exit_btn";
            this.Exit_btn.Size = new System.Drawing.Size(80, 33);
            this.Exit_btn.TabIndex = 22;
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
            this.Delete_btn.Location = new System.Drawing.Point(558, 434);
            this.Delete_btn.Name = "Delete_btn";
            this.Delete_btn.Size = new System.Drawing.Size(80, 33);
            this.Delete_btn.TabIndex = 21;
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
            this.Update_btn.Location = new System.Drawing.Point(464, 434);
            this.Update_btn.Name = "Update_btn";
            this.Update_btn.Size = new System.Drawing.Size(80, 33);
            this.Update_btn.TabIndex = 20;
            this.Update_btn.Text = "Update";
            this.Update_btn.UseVisualStyleBackColor = true;
            this.Update_btn.Click += new System.EventHandler(this.Update_btn_Click);
            // 
            // Detail_Position_dgv
            // 
            this.Detail_Position_dgv.AllowUserToAddRows = false;
            this.Detail_Position_dgv.AllowUserToDeleteRows = false;
            this.Detail_Position_dgv.AllowUserToOrderColumns = true;
            this.Detail_Position_dgv.AllowUserToResizeRows = false;
            this.Detail_Position_dgv.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(232)))), ((int)(((byte)(180)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.Detail_Position_dgv.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.Detail_Position_dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Detail_Position_dgv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colDetailPositionId,
            this.col_locationcd,
            this.colPositionCode,
            this.colPositionName});
            this.Detail_Position_dgv.ControlId = null;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.Detail_Position_dgv.DefaultCellStyle = dataGridViewCellStyle5;
            this.Detail_Position_dgv.EnableHeadersVisualStyles = false;
            this.Detail_Position_dgv.Location = new System.Drawing.Point(-2, 237);
            this.Detail_Position_dgv.MultiSelect = false;
            this.Detail_Position_dgv.Name = "Detail_Position_dgv";
            this.Detail_Position_dgv.ReadOnly = true;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(232)))), ((int)(((byte)(180)))));
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.Detail_Position_dgv.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.Detail_Position_dgv.RowHeadersVisible = false;
            this.Detail_Position_dgv.RowTemplate.Height = 21;
            this.Detail_Position_dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.Detail_Position_dgv.Size = new System.Drawing.Size(737, 191);
            this.Detail_Position_dgv.TabIndex = 19;
            this.Detail_Position_dgv.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Detail_Position_dgv_CellClick);
            this.Detail_Position_dgv.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Detail_Position_dgv_CellDoubleClick);
            // 
            // Add_btn
            // 
            this.Add_btn.BackColor = System.Drawing.SystemColors.Control;
            this.Add_btn.ControlId = null;
            this.Add_btn.Font = new System.Drawing.Font("Arial", 9F);
            this.Add_btn.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.Add_btn.Location = new System.Drawing.Point(561, 137);
            this.Add_btn.Name = "Add_btn";
            this.Add_btn.Size = new System.Drawing.Size(80, 33);
            this.Add_btn.TabIndex = 17;
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
            this.Search_btn.Location = new System.Drawing.Point(467, 137);
            this.Search_btn.Name = "Search_btn";
            this.Search_btn.Size = new System.Drawing.Size(80, 33);
            this.Search_btn.TabIndex = 16;
            this.Search_btn.Text = "Search";
            this.Search_btn.UseVisualStyleBackColor = true;
            this.Search_btn.Click += new System.EventHandler(this.Search_btn_Click);
            // 
            // DetailPositionName_txt
            // 
            this.DetailPositionName_txt.ControlId = null;
            this.DetailPositionName_txt.Font = new System.Drawing.Font("Arial", 9F);
            this.DetailPositionName_txt.InputType = Com.Nidec.Mes.Framework.TextBoxCommon.InputTypeList.All;
            this.DetailPositionName_txt.Location = new System.Drawing.Point(141, 170);
            this.DetailPositionName_txt.MaxLength = 32;
            this.DetailPositionName_txt.Name = "DetailPositionName_txt";
            this.DetailPositionName_txt.Size = new System.Drawing.Size(187, 21);
            this.DetailPositionName_txt.TabIndex = 15;
            // 
            // DetailPositionName_lbl
            // 
            this.DetailPositionName_lbl.AutoSize = true;
            this.DetailPositionName_lbl.ControlId = null;
            this.DetailPositionName_lbl.Font = new System.Drawing.Font("Arial", 9F);
            this.DetailPositionName_lbl.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.DetailPositionName_lbl.Location = new System.Drawing.Point(12, 172);
            this.DetailPositionName_lbl.Name = "DetailPositionName_lbl";
            this.DetailPositionName_lbl.Size = new System.Drawing.Size(127, 15);
            this.DetailPositionName_lbl.TabIndex = 14;
            this.DetailPositionName_lbl.Text = "Detail Position Name:";
            // 
            // DetailPositionCode_txt
            // 
            this.DetailPositionCode_txt.ControlId = null;
            this.DetailPositionCode_txt.Font = new System.Drawing.Font("Arial", 9F);
            this.DetailPositionCode_txt.InputType = Com.Nidec.Mes.Framework.TextBoxCommon.InputTypeList.All;
            this.DetailPositionCode_txt.Location = new System.Drawing.Point(141, 140);
            this.DetailPositionCode_txt.MaxLength = 32;
            this.DetailPositionCode_txt.Name = "DetailPositionCode_txt";
            this.DetailPositionCode_txt.Size = new System.Drawing.Size(187, 21);
            this.DetailPositionCode_txt.TabIndex = 13;
            // 
            // DetailPositionCode_lbl
            // 
            this.DetailPositionCode_lbl.AutoSize = true;
            this.DetailPositionCode_lbl.ControlId = null;
            this.DetailPositionCode_lbl.Font = new System.Drawing.Font("Arial", 9F);
            this.DetailPositionCode_lbl.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.DetailPositionCode_lbl.Location = new System.Drawing.Point(12, 142);
            this.DetailPositionCode_lbl.Name = "DetailPositionCode_lbl";
            this.DetailPositionCode_lbl.Size = new System.Drawing.Size(123, 15);
            this.DetailPositionCode_lbl.TabIndex = 12;
            this.DetailPositionCode_lbl.Text = "Detail Position Code:";
            // 
            // colDetailPositionId
            // 
            this.colDetailPositionId.DataPropertyName = "DetailPositionId";
            this.colDetailPositionId.HeaderText = "Detail Position";
            this.colDetailPositionId.Name = "colDetailPositionId";
            this.colDetailPositionId.ReadOnly = true;
            this.colDetailPositionId.Visible = false;
            // 
            // col_locationcd
            // 
            this.col_locationcd.DataPropertyName = "LocationCd";
            this.col_locationcd.HeaderText = "Location Code";
            this.col_locationcd.Name = "col_locationcd";
            this.col_locationcd.ReadOnly = true;
            // 
            // colPositionCode
            // 
            this.colPositionCode.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colPositionCode.DataPropertyName = "DetailPositionCode";
            this.colPositionCode.HeaderText = "Detail Position Code";
            this.colPositionCode.Name = "colPositionCode";
            this.colPositionCode.ReadOnly = true;
            // 
            // colPositionName
            // 
            this.colPositionName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colPositionName.DataPropertyName = "DetailPositionName";
            this.colPositionName.HeaderText = "Detail Position Name";
            this.colPositionName.Name = "colPositionName";
            this.colPositionName.ReadOnly = true;
            // 
            // locationcd_cbm
            // 
            this.locationcd_cbm.ControlId = null;
            this.locationcd_cbm.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.locationcd_cbm.FormattingEnabled = true;
            this.locationcd_cbm.Location = new System.Drawing.Point(141, 110);
            this.locationcd_cbm.Name = "locationcd_cbm";
            this.locationcd_cbm.Size = new System.Drawing.Size(187, 23);
            this.locationcd_cbm.TabIndex = 23;
            // 
            // locationcd_lbl
            // 
            this.locationcd_lbl.AutoSize = true;
            this.locationcd_lbl.ControlId = null;
            this.locationcd_lbl.Font = new System.Drawing.Font("Arial", 9F);
            this.locationcd_lbl.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.locationcd_lbl.Location = new System.Drawing.Point(12, 115);
            this.locationcd_lbl.Name = "locationcd_lbl";
            this.locationcd_lbl.Size = new System.Drawing.Size(90, 15);
            this.locationcd_lbl.TabIndex = 24;
            this.locationcd_lbl.Text = "Location Code:";
            // 
            // DetailPositionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(735, 479);
            this.Controls.Add(this.locationcd_lbl);
            this.Controls.Add(this.locationcd_cbm);
            this.Controls.Add(this.Clear_btn);
            this.Controls.Add(this.Exit_btn);
            this.Controls.Add(this.Delete_btn);
            this.Controls.Add(this.Update_btn);
            this.Controls.Add(this.Detail_Position_dgv);
            this.Controls.Add(this.Add_btn);
            this.Controls.Add(this.Search_btn);
            this.Controls.Add(this.DetailPositionName_txt);
            this.Controls.Add(this.DetailPositionName_lbl);
            this.Controls.Add(this.DetailPositionCode_txt);
            this.Controls.Add(this.DetailPositionCode_lbl);
            this.Name = "DetailPositionForm";
            this.Text = "Detail Position";
            this.TitleText = "Detail Position";
            this.Load += new System.EventHandler(this.DetailPositionForm_Load);
            this.Controls.SetChildIndex(this.DetailPositionCode_lbl, 0);
            this.Controls.SetChildIndex(this.DetailPositionCode_txt, 0);
            this.Controls.SetChildIndex(this.DetailPositionName_lbl, 0);
            this.Controls.SetChildIndex(this.DetailPositionName_txt, 0);
            this.Controls.SetChildIndex(this.Search_btn, 0);
            this.Controls.SetChildIndex(this.Add_btn, 0);
            this.Controls.SetChildIndex(this.Detail_Position_dgv, 0);
            this.Controls.SetChildIndex(this.Update_btn, 0);
            this.Controls.SetChildIndex(this.Delete_btn, 0);
            this.Controls.SetChildIndex(this.Exit_btn, 0);
            this.Controls.SetChildIndex(this.Clear_btn, 0);
            this.Controls.SetChildIndex(this.locationcd_cbm, 0);
            this.Controls.SetChildIndex(this.locationcd_lbl, 0);
            ((System.ComponentModel.ISupportInitialize)(this.Detail_Position_dgv)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Framework.ButtonCommon Clear_btn;
        private Framework.ButtonCommon Exit_btn;
        private Framework.ButtonCommon Delete_btn;
        private Framework.ButtonCommon Update_btn;
        internal Framework.DataGridViewCommon Detail_Position_dgv;
        private Framework.ButtonCommon Add_btn;
        private Framework.ButtonCommon Search_btn;
        private Framework.TextBoxCommon DetailPositionName_txt;
        private Framework.LabelCommon DetailPositionName_lbl;
        private Framework.TextBoxCommon DetailPositionCode_txt;
        private Framework.LabelCommon DetailPositionCode_lbl;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDetailPositionId;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_locationcd;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPositionCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPositionName;
        private Framework.ComboBoxCommon locationcd_cbm;
        private Framework.LabelCommon locationcd_lbl;
    }
}
