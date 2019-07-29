namespace Com.Nidec.Mes.Common.Basic.MachineMaintenance.Form.AccountWhForm.UserLocation
{
    partial class UserLocationForm
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
            this.UserLocationDetails_dgv = new Com.Nidec.Mes.Framework.DataGridViewCommon();
            this.colUserLocationId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colUserLocationCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colUserLocationName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colUserLocationDeptCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Add_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.Search_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.UserLocationName_txt = new Com.Nidec.Mes.Framework.TextBoxCommon();
            this.UserLocationName_lbl = new Com.Nidec.Mes.Framework.LabelCommon();
            this.UserLocationCode_txt = new Com.Nidec.Mes.Framework.TextBoxCommon();
            this.UserLocationCode_lbl = new Com.Nidec.Mes.Framework.LabelCommon();
            ((System.ComponentModel.ISupportInitialize)(this.UserLocationDetails_dgv)).BeginInit();
            this.SuspendLayout();
            // 
            // Clear_btn
            // 
            this.Clear_btn.BackColor = System.Drawing.SystemColors.Control;
            this.Clear_btn.ControlId = null;
            this.Clear_btn.Font = new System.Drawing.Font("Arial", 9F);
            this.Clear_btn.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.Clear_btn.Location = new System.Drawing.Point(657, 151);
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
            this.Exit_btn.Location = new System.Drawing.Point(657, 445);
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
            this.Delete_btn.Location = new System.Drawing.Point(563, 445);
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
            this.Update_btn.Location = new System.Drawing.Point(469, 445);
            this.Update_btn.Name = "Update_btn";
            this.Update_btn.Size = new System.Drawing.Size(80, 33);
            this.Update_btn.TabIndex = 20;
            this.Update_btn.Text = "Update";
            this.Update_btn.UseVisualStyleBackColor = true;
            this.Update_btn.Click += new System.EventHandler(this.Update_btn_Click);
            // 
            // UserLocationDetails_dgv
            // 
            this.UserLocationDetails_dgv.AllowUserToAddRows = false;
            this.UserLocationDetails_dgv.AllowUserToDeleteRows = false;
            this.UserLocationDetails_dgv.AllowUserToOrderColumns = true;
            this.UserLocationDetails_dgv.AllowUserToResizeRows = false;
            this.UserLocationDetails_dgv.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(232)))), ((int)(((byte)(180)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.UserLocationDetails_dgv.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.UserLocationDetails_dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.UserLocationDetails_dgv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colUserLocationId,
            this.colUserLocationCode,
            this.colUserLocationName,
            this.colUserLocationDeptCode});
            this.UserLocationDetails_dgv.ControlId = null;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.UserLocationDetails_dgv.DefaultCellStyle = dataGridViewCellStyle2;
            this.UserLocationDetails_dgv.EnableHeadersVisualStyles = false;
            this.UserLocationDetails_dgv.Location = new System.Drawing.Point(0, 190);
            this.UserLocationDetails_dgv.MultiSelect = false;
            this.UserLocationDetails_dgv.Name = "UserLocationDetails_dgv";
            this.UserLocationDetails_dgv.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(232)))), ((int)(((byte)(180)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.UserLocationDetails_dgv.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.UserLocationDetails_dgv.RowHeadersVisible = false;
            this.UserLocationDetails_dgv.RowTemplate.Height = 21;
            this.UserLocationDetails_dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.UserLocationDetails_dgv.Size = new System.Drawing.Size(737, 235);
            this.UserLocationDetails_dgv.TabIndex = 19;
            this.UserLocationDetails_dgv.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.UserLocationDetails_dgv_CellClick);
            this.UserLocationDetails_dgv.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.UserLocationDetails_dgv_CellDoubleClick);
            // 
            // colUserLocationId
            // 
            this.colUserLocationId.DataPropertyName = "UserLocationId";
            this.colUserLocationId.HeaderText = "UserLocation Id";
            this.colUserLocationId.Name = "colUserLocationId";
            this.colUserLocationId.ReadOnly = true;
            this.colUserLocationId.Visible = false;
            // 
            // colUserLocationCode
            // 
            this.colUserLocationCode.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colUserLocationCode.DataPropertyName = "UserLocationCode";
            this.colUserLocationCode.HeaderText = "UserLocation Code";
            this.colUserLocationCode.Name = "colUserLocationCode";
            this.colUserLocationCode.ReadOnly = true;
            // 
            // colUserLocationName
            // 
            this.colUserLocationName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colUserLocationName.DataPropertyName = "UserLocationName";
            this.colUserLocationName.HeaderText = "UserLocation Name";
            this.colUserLocationName.Name = "colUserLocationName";
            this.colUserLocationName.ReadOnly = true;
            // 
            // colUserLocationDeptCode
            // 
            this.colUserLocationDeptCode.DataPropertyName = "DeptCode";
            this.colUserLocationDeptCode.HeaderText = "UserLocation DeptCode";
            this.colUserLocationDeptCode.Name = "colUserLocationDeptCode";
            this.colUserLocationDeptCode.ReadOnly = true;
            // 
            // Add_btn
            // 
            this.Add_btn.BackColor = System.Drawing.SystemColors.Control;
            this.Add_btn.ControlId = null;
            this.Add_btn.Font = new System.Drawing.Font("Arial", 9F);
            this.Add_btn.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.Add_btn.Location = new System.Drawing.Point(563, 151);
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
            this.Search_btn.Location = new System.Drawing.Point(469, 151);
            this.Search_btn.Name = "Search_btn";
            this.Search_btn.Size = new System.Drawing.Size(80, 33);
            this.Search_btn.TabIndex = 16;
            this.Search_btn.Text = "Search";
            this.Search_btn.UseVisualStyleBackColor = true;
            this.Search_btn.Click += new System.EventHandler(this.Search_btn_Click);
            // 
            // UserLocationName_txt
            // 
            this.UserLocationName_txt.ControlId = null;
            this.UserLocationName_txt.Font = new System.Drawing.Font("Arial", 9F);
            this.UserLocationName_txt.InputType = Com.Nidec.Mes.Framework.TextBoxCommon.InputTypeList.All;
            this.UserLocationName_txt.Location = new System.Drawing.Point(140, 157);
            this.UserLocationName_txt.MaxLength = 32;
            this.UserLocationName_txt.Name = "UserLocationName_txt";
            this.UserLocationName_txt.Size = new System.Drawing.Size(187, 21);
            this.UserLocationName_txt.TabIndex = 15;
            // 
            // UserLocationName_lbl
            // 
            this.UserLocationName_lbl.AutoSize = true;
            this.UserLocationName_lbl.ControlId = null;
            this.UserLocationName_lbl.Font = new System.Drawing.Font("Arial", 9F);
            this.UserLocationName_lbl.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.UserLocationName_lbl.Location = new System.Drawing.Point(14, 160);
            this.UserLocationName_lbl.Name = "UserLocationName_lbl";
            this.UserLocationName_lbl.Size = new System.Drawing.Size(118, 15);
            this.UserLocationName_lbl.TabIndex = 14;
            this.UserLocationName_lbl.Text = "UserLocation Name";
            // 
            // UserLocationCode_txt
            // 
            this.UserLocationCode_txt.ControlId = null;
            this.UserLocationCode_txt.Font = new System.Drawing.Font("Arial", 9F);
            this.UserLocationCode_txt.InputType = Com.Nidec.Mes.Framework.TextBoxCommon.InputTypeList.All;
            this.UserLocationCode_txt.Location = new System.Drawing.Point(140, 127);
            this.UserLocationCode_txt.MaxLength = 32;
            this.UserLocationCode_txt.Name = "UserLocationCode_txt";
            this.UserLocationCode_txt.Size = new System.Drawing.Size(187, 21);
            this.UserLocationCode_txt.TabIndex = 13;
            // 
            // UserLocationCode_lbl
            // 
            this.UserLocationCode_lbl.AutoSize = true;
            this.UserLocationCode_lbl.ControlId = null;
            this.UserLocationCode_lbl.Font = new System.Drawing.Font("Arial", 9F);
            this.UserLocationCode_lbl.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.UserLocationCode_lbl.Location = new System.Drawing.Point(14, 130);
            this.UserLocationCode_lbl.Name = "UserLocationCode_lbl";
            this.UserLocationCode_lbl.Size = new System.Drawing.Size(114, 15);
            this.UserLocationCode_lbl.TabIndex = 12;
            this.UserLocationCode_lbl.Text = "UserLocation Code";
            // 
            // UserLocationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(739, 488);
            this.Controls.Add(this.Clear_btn);
            this.Controls.Add(this.Exit_btn);
            this.Controls.Add(this.Delete_btn);
            this.Controls.Add(this.Update_btn);
            this.Controls.Add(this.UserLocationDetails_dgv);
            this.Controls.Add(this.Add_btn);
            this.Controls.Add(this.Search_btn);
            this.Controls.Add(this.UserLocationName_txt);
            this.Controls.Add(this.UserLocationName_lbl);
            this.Controls.Add(this.UserLocationCode_txt);
            this.Controls.Add(this.UserLocationCode_lbl);
            this.Name = "UserLocationForm";
            this.TitleText = "FormCommon";
            this.Controls.SetChildIndex(this.UserLocationCode_lbl, 0);
            this.Controls.SetChildIndex(this.UserLocationCode_txt, 0);
            this.Controls.SetChildIndex(this.UserLocationName_lbl, 0);
            this.Controls.SetChildIndex(this.UserLocationName_txt, 0);
            this.Controls.SetChildIndex(this.Search_btn, 0);
            this.Controls.SetChildIndex(this.Add_btn, 0);
            this.Controls.SetChildIndex(this.UserLocationDetails_dgv, 0);
            this.Controls.SetChildIndex(this.Update_btn, 0);
            this.Controls.SetChildIndex(this.Delete_btn, 0);
            this.Controls.SetChildIndex(this.Exit_btn, 0);
            this.Controls.SetChildIndex(this.Clear_btn, 0);
            ((System.ComponentModel.ISupportInitialize)(this.UserLocationDetails_dgv)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Framework.ButtonCommon Clear_btn;
        private Framework.ButtonCommon Exit_btn;
        private Framework.ButtonCommon Delete_btn;
        private Framework.ButtonCommon Update_btn;
        internal Framework.DataGridViewCommon UserLocationDetails_dgv;
        private Framework.ButtonCommon Add_btn;
        private Framework.ButtonCommon Search_btn;
        private Framework.TextBoxCommon UserLocationName_txt;
        private Framework.LabelCommon UserLocationName_lbl;
        private Framework.TextBoxCommon UserLocationCode_txt;
        private Framework.LabelCommon UserLocationCode_lbl;
        private System.Windows.Forms.DataGridViewTextBoxColumn colUserLocationId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colUserLocationCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn colUserLocationName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colUserLocationDeptCode;
    }
}
