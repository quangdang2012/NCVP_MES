namespace Com.Nidec.Mes.GlobalMasterMaintenance
{
    partial class ModelForm
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
            this.ModelCode_txt = new Com.Nidec.Mes.Framework.TextBoxCommon();
            this.ModelName_lbl = new Com.Nidec.Mes.Framework.LabelCommon();
            this.ModelName_txt = new Com.Nidec.Mes.Framework.TextBoxCommon();
            this.ModelCode_lbl = new Com.Nidec.Mes.Framework.LabelCommon();
            this.Clear_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.Exit_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.Delete_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.Update_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.Add_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.Search_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.Model_dgv = new Com.Nidec.Mes.Framework.DataGridViewCommon();
            this.colModelId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colModelCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colModelName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.Model_dgv)).BeginInit();
            this.SuspendLayout();
            // 
            // ModelCode_txt
            // 
            this.ModelCode_txt.ControlId = null;
            this.ModelCode_txt.Font = new System.Drawing.Font("Arial", 9F);
            this.ModelCode_txt.InputType = Com.Nidec.Mes.Framework.TextBoxCommon.InputTypeList.All;
            this.ModelCode_txt.Location = new System.Drawing.Point(125, 118);
            this.ModelCode_txt.MaxLength = 32;
            this.ModelCode_txt.Name = "ModelCode_txt";
            this.ModelCode_txt.Size = new System.Drawing.Size(187, 21);
            this.ModelCode_txt.TabIndex = 13;
            // 
            // ModelName_lbl
            // 
            this.ModelName_lbl.AutoSize = true;
            this.ModelName_lbl.ControlId = null;
            this.ModelName_lbl.Font = new System.Drawing.Font("Arial", 9F);
            this.ModelName_lbl.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.ModelName_lbl.Location = new System.Drawing.Point(332, 121);
            this.ModelName_lbl.Name = "ModelName_lbl";
            this.ModelName_lbl.Size = new System.Drawing.Size(77, 15);
            this.ModelName_lbl.TabIndex = 14;
            this.ModelName_lbl.Text = "Model Name";
            // 
            // ModelName_txt
            // 
            this.ModelName_txt.ControlId = null;
            this.ModelName_txt.Font = new System.Drawing.Font("Arial", 9F);
            this.ModelName_txt.InputType = Com.Nidec.Mes.Framework.TextBoxCommon.InputTypeList.All;
            this.ModelName_txt.Location = new System.Drawing.Point(443, 118);
            this.ModelName_txt.MaxLength = 64;
            this.ModelName_txt.Name = "ModelName_txt";
            this.ModelName_txt.Size = new System.Drawing.Size(187, 21);
            this.ModelName_txt.TabIndex = 15;
            // 
            // ModelCode_lbl
            // 
            this.ModelCode_lbl.AutoSize = true;
            this.ModelCode_lbl.ControlId = null;
            this.ModelCode_lbl.Font = new System.Drawing.Font("Arial", 9F);
            this.ModelCode_lbl.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.ModelCode_lbl.Location = new System.Drawing.Point(14, 121);
            this.ModelCode_lbl.Name = "ModelCode_lbl";
            this.ModelCode_lbl.Size = new System.Drawing.Size(73, 15);
            this.ModelCode_lbl.TabIndex = 12;
            this.ModelCode_lbl.Text = "Model Code";
            // 
            // Clear_btn
            // 
            this.Clear_btn.BackColor = System.Drawing.SystemColors.Control;
            this.Clear_btn.ControlId = null;
            this.Clear_btn.Font = new System.Drawing.Font("Arial", 9F);
            this.Clear_btn.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.Clear_btn.Location = new System.Drawing.Point(659, 152);
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
            this.Exit_btn.Location = new System.Drawing.Point(659, 455);
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
            this.Delete_btn.Location = new System.Drawing.Point(566, 455);
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
            this.Update_btn.Location = new System.Drawing.Point(473, 455);
            this.Update_btn.Name = "Update_btn";
            this.Update_btn.Size = new System.Drawing.Size(80, 33);
            this.Update_btn.TabIndex = 20;
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
            this.Add_btn.Location = new System.Drawing.Point(566, 152);
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
            this.Search_btn.Location = new System.Drawing.Point(473, 152);
            this.Search_btn.Name = "Search_btn";
            this.Search_btn.Size = new System.Drawing.Size(80, 33);
            this.Search_btn.TabIndex = 16;
            this.Search_btn.Text = "Search";
            this.Search_btn.UseVisualStyleBackColor = true;
            this.Search_btn.Click += new System.EventHandler(this.Search_btn_Click);
            // 
            // Model_dgv
            // 
            this.Model_dgv.AllowUserToAddRows = false;
            this.Model_dgv.AllowUserToDeleteRows = false;
            this.Model_dgv.AllowUserToOrderColumns = true;
            this.Model_dgv.AllowUserToResizeRows = false;
            this.Model_dgv.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)));
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(232)))), ((int)(((byte)(180)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.Model_dgv.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.Model_dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Model_dgv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colModelId,
            this.colModelCode,
            this.colModelName});
            this.Model_dgv.ControlId = null;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.Model_dgv.DefaultCellStyle = dataGridViewCellStyle2;
            this.Model_dgv.EnableHeadersVisualStyles = false;
            this.Model_dgv.Location = new System.Drawing.Point(4, 191);
            this.Model_dgv.MultiSelect = false;
            this.Model_dgv.Name = "Model_dgv";
            this.Model_dgv.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(232)))), ((int)(((byte)(180)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.Model_dgv.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.Model_dgv.RowHeadersVisible = false;
            this.Model_dgv.RowTemplate.Height = 21;
            this.Model_dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.Model_dgv.Size = new System.Drawing.Size(735, 258);
            this.Model_dgv.TabIndex = 19;
            this.Model_dgv.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Model_dgv_CellClick);
            this.Model_dgv.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Model_dgv_CellDoubleClick);
            // 
            // colModelId
            // 
            this.colModelId.DataPropertyName = "ModelId";
            this.colModelId.HeaderText = "Model Id";
            this.colModelId.Name = "colModelId";
            this.colModelId.ReadOnly = true;
            this.colModelId.Visible = false;
            // 
            // colModelCode
            // 
            this.colModelCode.DataPropertyName = "ModelCode";
            this.colModelCode.HeaderText = "Model Code";
            this.colModelCode.Name = "colModelCode";
            this.colModelCode.ReadOnly = true;
            this.colModelCode.Width = 366;
            // 
            // colModelName
            // 
            this.colModelName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colModelName.DataPropertyName = "ModelName";
            this.colModelName.HeaderText = "Model Name";
            this.colModelName.Name = "colModelName";
            this.colModelName.ReadOnly = true;
            // 
            // ModelForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(744, 493);
            this.Controls.Add(this.ModelCode_txt);
            this.Controls.Add(this.ModelName_lbl);
            this.Controls.Add(this.ModelName_txt);
            this.Controls.Add(this.ModelCode_lbl);
            this.Controls.Add(this.Clear_btn);
            this.Controls.Add(this.Exit_btn);
            this.Controls.Add(this.Delete_btn);
            this.Controls.Add(this.Update_btn);
            this.Controls.Add(this.Add_btn);
            this.Controls.Add(this.Search_btn);
            this.Controls.Add(this.Model_dgv);
            this.Name = "ModelForm";
            this.Text = "Model Master";
            this.TitleText = "FormCommon";
            this.Load += new System.EventHandler(this.ModelForm_Load);
            this.Controls.SetChildIndex(this.Model_dgv, 0);
            this.Controls.SetChildIndex(this.Search_btn, 0);
            this.Controls.SetChildIndex(this.Add_btn, 0);
            this.Controls.SetChildIndex(this.Update_btn, 0);
            this.Controls.SetChildIndex(this.Delete_btn, 0);
            this.Controls.SetChildIndex(this.Exit_btn, 0);
            this.Controls.SetChildIndex(this.Clear_btn, 0);
            this.Controls.SetChildIndex(this.ModelCode_lbl, 0);
            this.Controls.SetChildIndex(this.ModelName_txt, 0);
            this.Controls.SetChildIndex(this.ModelName_lbl, 0);
            this.Controls.SetChildIndex(this.ModelCode_txt, 0);
            ((System.ComponentModel.ISupportInitialize)(this.Model_dgv)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Framework.TextBoxCommon ModelCode_txt;
        private Framework.LabelCommon ModelName_lbl;
        private Framework.TextBoxCommon ModelName_txt;
        private Framework.LabelCommon ModelCode_lbl;
        private Framework.ButtonCommon Clear_btn;
        private Framework.ButtonCommon Exit_btn;
        private Framework.ButtonCommon Delete_btn;
        private Framework.ButtonCommon Update_btn;
        private Framework.ButtonCommon Add_btn;
        private Framework.ButtonCommon Search_btn;
        internal Framework.DataGridViewCommon Model_dgv;
        private System.Windows.Forms.DataGridViewTextBoxColumn colModelId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colModelCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn colModelName;
    }
}
