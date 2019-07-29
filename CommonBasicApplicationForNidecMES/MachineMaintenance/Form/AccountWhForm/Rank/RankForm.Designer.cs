namespace Com.Nidec.Mes.Common.Basic.MachineMaintenance.Form.AccountWhForm.Rank
{
    partial class RankForm
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
            this.RankDetails_dgv = new Com.Nidec.Mes.Framework.DataGridViewCommon();
            this.colRankId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colRankCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colRankName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Add_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.Search_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.RankName_txt = new Com.Nidec.Mes.Framework.TextBoxCommon();
            this.RankName_lbl = new Com.Nidec.Mes.Framework.LabelCommon();
            this.RankCode_txt = new Com.Nidec.Mes.Framework.TextBoxCommon();
            this.RankCode_lbl = new Com.Nidec.Mes.Framework.LabelCommon();
            ((System.ComponentModel.ISupportInitialize)(this.RankDetails_dgv)).BeginInit();
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
            // RankDetails_dgv
            // 
            this.RankDetails_dgv.AllowUserToAddRows = false;
            this.RankDetails_dgv.AllowUserToDeleteRows = false;
            this.RankDetails_dgv.AllowUserToOrderColumns = true;
            this.RankDetails_dgv.AllowUserToResizeRows = false;
            this.RankDetails_dgv.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(232)))), ((int)(((byte)(180)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.RankDetails_dgv.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.RankDetails_dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.RankDetails_dgv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colRankId,
            this.colRankCode,
            this.colRankName});
            this.RankDetails_dgv.ControlId = null;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.RankDetails_dgv.DefaultCellStyle = dataGridViewCellStyle2;
            this.RankDetails_dgv.EnableHeadersVisualStyles = false;
            this.RankDetails_dgv.Location = new System.Drawing.Point(-2, 176);
            this.RankDetails_dgv.MultiSelect = false;
            this.RankDetails_dgv.Name = "RankDetails_dgv";
            this.RankDetails_dgv.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(232)))), ((int)(((byte)(180)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.RankDetails_dgv.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.RankDetails_dgv.RowHeadersVisible = false;
            this.RankDetails_dgv.RowTemplate.Height = 21;
            this.RankDetails_dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.RankDetails_dgv.Size = new System.Drawing.Size(737, 252);
            this.RankDetails_dgv.TabIndex = 19;
            this.RankDetails_dgv.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.RankDetails_dgv_CellClick);
            this.RankDetails_dgv.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.RankDetails_dgv_CellDoubleClick);
            // 
            // colRankId
            // 
            this.colRankId.DataPropertyName = "RankId";
            this.colRankId.HeaderText = "Rank Id";
            this.colRankId.Name = "colRankId";
            this.colRankId.ReadOnly = true;
            this.colRankId.Visible = false;
            // 
            // colRankCode
            // 
            this.colRankCode.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colRankCode.DataPropertyName = "RankCode";
            this.colRankCode.HeaderText = "Rank Code";
            this.colRankCode.Name = "colRankCode";
            this.colRankCode.ReadOnly = true;
            // 
            // colRankName
            // 
            this.colRankName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colRankName.DataPropertyName = "RankName";
            this.colRankName.HeaderText = "Rank Name";
            this.colRankName.Name = "colRankName";
            this.colRankName.ReadOnly = true;
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
            // RankName_txt
            // 
            this.RankName_txt.ControlId = null;
            this.RankName_txt.Font = new System.Drawing.Font("Arial", 9F);
            this.RankName_txt.InputType = Com.Nidec.Mes.Framework.TextBoxCommon.InputTypeList.All;
            this.RankName_txt.Location = new System.Drawing.Point(98, 143);
            this.RankName_txt.MaxLength = 32;
            this.RankName_txt.Name = "RankName_txt";
            this.RankName_txt.Size = new System.Drawing.Size(187, 21);
            this.RankName_txt.TabIndex = 15;
            // 
            // RankName_lbl
            // 
            this.RankName_lbl.AutoSize = true;
            this.RankName_lbl.ControlId = null;
            this.RankName_lbl.Font = new System.Drawing.Font("Arial", 9F);
            this.RankName_lbl.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.RankName_lbl.Location = new System.Drawing.Point(12, 146);
            this.RankName_lbl.Name = "RankName_lbl";
            this.RankName_lbl.Size = new System.Drawing.Size(73, 15);
            this.RankName_lbl.TabIndex = 14;
            this.RankName_lbl.Text = "Rank Name";
            // 
            // RankCode_txt
            // 
            this.RankCode_txt.ControlId = null;
            this.RankCode_txt.Font = new System.Drawing.Font("Arial", 9F);
            this.RankCode_txt.InputType = Com.Nidec.Mes.Framework.TextBoxCommon.InputTypeList.All;
            this.RankCode_txt.Location = new System.Drawing.Point(98, 113);
            this.RankCode_txt.MaxLength = 32;
            this.RankCode_txt.Name = "RankCode_txt";
            this.RankCode_txt.Size = new System.Drawing.Size(187, 21);
            this.RankCode_txt.TabIndex = 13;
            // 
            // RankCode_lbl
            // 
            this.RankCode_lbl.AutoSize = true;
            this.RankCode_lbl.ControlId = null;
            this.RankCode_lbl.Font = new System.Drawing.Font("Arial", 9F);
            this.RankCode_lbl.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.RankCode_lbl.Location = new System.Drawing.Point(12, 116);
            this.RankCode_lbl.Name = "RankCode_lbl";
            this.RankCode_lbl.Size = new System.Drawing.Size(69, 15);
            this.RankCode_lbl.TabIndex = 12;
            this.RankCode_lbl.Text = "Rank Code";
            // 
            // RankForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(735, 479);
            this.Controls.Add(this.Clear_btn);
            this.Controls.Add(this.Exit_btn);
            this.Controls.Add(this.Delete_btn);
            this.Controls.Add(this.Update_btn);
            this.Controls.Add(this.RankDetails_dgv);
            this.Controls.Add(this.Add_btn);
            this.Controls.Add(this.Search_btn);
            this.Controls.Add(this.RankName_txt);
            this.Controls.Add(this.RankName_lbl);
            this.Controls.Add(this.RankCode_txt);
            this.Controls.Add(this.RankCode_lbl);
            this.Name = "RankForm";
            this.TitleText = "FormCommon";
            this.Load += new System.EventHandler(this.RankForm_Load);
            this.Controls.SetChildIndex(this.RankCode_lbl, 0);
            this.Controls.SetChildIndex(this.RankCode_txt, 0);
            this.Controls.SetChildIndex(this.RankName_lbl, 0);
            this.Controls.SetChildIndex(this.RankName_txt, 0);
            this.Controls.SetChildIndex(this.Search_btn, 0);
            this.Controls.SetChildIndex(this.Add_btn, 0);
            this.Controls.SetChildIndex(this.RankDetails_dgv, 0);
            this.Controls.SetChildIndex(this.Update_btn, 0);
            this.Controls.SetChildIndex(this.Delete_btn, 0);
            this.Controls.SetChildIndex(this.Exit_btn, 0);
            this.Controls.SetChildIndex(this.Clear_btn, 0);
            ((System.ComponentModel.ISupportInitialize)(this.RankDetails_dgv)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Framework.ButtonCommon Clear_btn;
        private Framework.ButtonCommon Exit_btn;
        private Framework.ButtonCommon Delete_btn;
        private Framework.ButtonCommon Update_btn;
        internal Framework.DataGridViewCommon RankDetails_dgv;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRankId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRankCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRankName;
        private Framework.ButtonCommon Add_btn;
        private Framework.ButtonCommon Search_btn;
        private Framework.TextBoxCommon RankName_txt;
        private Framework.LabelCommon RankName_lbl;
        private Framework.TextBoxCommon RankCode_txt;
        private Framework.LabelCommon RankCode_lbl;
    }
}
