namespace Com.Nidec.Mes.Common.Basic.MachineMaintenance.Form.AccountWhForm.InventoryForm
{
    partial class InvertoryTimeForm
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
            this.InvertoryTimeDetails_dgv = new Com.Nidec.Mes.Framework.DataGridViewCommon();
            this.colInvertoryTimeId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colInvertoryTimeCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colInvertoryTimeName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Add_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.Search_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.InvertoryTimeName_txt = new Com.Nidec.Mes.Framework.TextBoxCommon();
            this.InvertoryTimeName_lbl = new Com.Nidec.Mes.Framework.LabelCommon();
            this.InvertoryTimeCode_txt = new Com.Nidec.Mes.Framework.TextBoxCommon();
            this.InvertoryTimeCode_lbl = new Com.Nidec.Mes.Framework.LabelCommon();
            ((System.ComponentModel.ISupportInitialize)(this.InvertoryTimeDetails_dgv)).BeginInit();
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
            // InvertoryTimeDetails_dgv
            // 
            this.InvertoryTimeDetails_dgv.AllowUserToAddRows = false;
            this.InvertoryTimeDetails_dgv.AllowUserToDeleteRows = false;
            this.InvertoryTimeDetails_dgv.AllowUserToOrderColumns = true;
            this.InvertoryTimeDetails_dgv.AllowUserToResizeRows = false;
            this.InvertoryTimeDetails_dgv.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(232)))), ((int)(((byte)(180)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.InvertoryTimeDetails_dgv.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.InvertoryTimeDetails_dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.InvertoryTimeDetails_dgv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colInvertoryTimeId,
            this.colInvertoryTimeCode,
            this.colInvertoryTimeName});
            this.InvertoryTimeDetails_dgv.ControlId = null;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.InvertoryTimeDetails_dgv.DefaultCellStyle = dataGridViewCellStyle2;
            this.InvertoryTimeDetails_dgv.EnableHeadersVisualStyles = false;
            this.InvertoryTimeDetails_dgv.Location = new System.Drawing.Point(-2, 176);
            this.InvertoryTimeDetails_dgv.MultiSelect = false;
            this.InvertoryTimeDetails_dgv.Name = "InvertoryTimeDetails_dgv";
            this.InvertoryTimeDetails_dgv.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(232)))), ((int)(((byte)(180)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.InvertoryTimeDetails_dgv.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.InvertoryTimeDetails_dgv.RowHeadersVisible = false;
            this.InvertoryTimeDetails_dgv.RowTemplate.Height = 21;
            this.InvertoryTimeDetails_dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.InvertoryTimeDetails_dgv.Size = new System.Drawing.Size(737, 252);
            this.InvertoryTimeDetails_dgv.TabIndex = 19;
            this.InvertoryTimeDetails_dgv.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.RankDetails_dgv_CellClick);
            this.InvertoryTimeDetails_dgv.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.RankDetails_dgv_CellDoubleClick);
            // 
            // colInvertoryTimeId
            // 
            this.colInvertoryTimeId.DataPropertyName = "InvertoryTimeId";
            this.colInvertoryTimeId.HeaderText = "InvertoryTimeId";
            this.colInvertoryTimeId.Name = "colInvertoryTimeId";
            this.colInvertoryTimeId.ReadOnly = true;
            this.colInvertoryTimeId.Visible = false;
            // 
            // colInvertoryTimeCode
            // 
            this.colInvertoryTimeCode.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colInvertoryTimeCode.DataPropertyName = "InvertoryTimeCode";
            this.colInvertoryTimeCode.HeaderText = "Inventory Time Code";
            this.colInvertoryTimeCode.Name = "colInvertoryTimeCode";
            this.colInvertoryTimeCode.ReadOnly = true;
            // 
            // colInvertoryTimeName
            // 
            this.colInvertoryTimeName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colInvertoryTimeName.DataPropertyName = "InvertoryTimeName";
            this.colInvertoryTimeName.HeaderText = "Inventory Time Name";
            this.colInvertoryTimeName.Name = "colInvertoryTimeName";
            this.colInvertoryTimeName.ReadOnly = true;
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
            // InvertoryTimeName_txt
            // 
            this.InvertoryTimeName_txt.ControlId = null;
            this.InvertoryTimeName_txt.Font = new System.Drawing.Font("Arial", 9F);
            this.InvertoryTimeName_txt.InputType = Com.Nidec.Mes.Framework.TextBoxCommon.InputTypeList.All;
            this.InvertoryTimeName_txt.Location = new System.Drawing.Point(138, 143);
            this.InvertoryTimeName_txt.MaxLength = 32;
            this.InvertoryTimeName_txt.Name = "InvertoryTimeName_txt";
            this.InvertoryTimeName_txt.Size = new System.Drawing.Size(187, 21);
            this.InvertoryTimeName_txt.TabIndex = 15;
            // 
            // InvertoryTimeName_lbl
            // 
            this.InvertoryTimeName_lbl.AutoSize = true;
            this.InvertoryTimeName_lbl.ControlId = null;
            this.InvertoryTimeName_lbl.Font = new System.Drawing.Font("Arial", 9F);
            this.InvertoryTimeName_lbl.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.InvertoryTimeName_lbl.Location = new System.Drawing.Point(12, 146);
            this.InvertoryTimeName_lbl.Name = "InvertoryTimeName_lbl";
            this.InvertoryTimeName_lbl.Size = new System.Drawing.Size(123, 15);
            this.InvertoryTimeName_lbl.TabIndex = 14;
            this.InvertoryTimeName_lbl.Text = "Inventory Time Name";
            // 
            // InvertoryTimeCode_txt
            // 
            this.InvertoryTimeCode_txt.ControlId = null;
            this.InvertoryTimeCode_txt.Font = new System.Drawing.Font("Arial", 9F);
            this.InvertoryTimeCode_txt.InputType = Com.Nidec.Mes.Framework.TextBoxCommon.InputTypeList.All;
            this.InvertoryTimeCode_txt.Location = new System.Drawing.Point(138, 113);
            this.InvertoryTimeCode_txt.MaxLength = 32;
            this.InvertoryTimeCode_txt.Name = "InvertoryTimeCode_txt";
            this.InvertoryTimeCode_txt.Size = new System.Drawing.Size(187, 21);
            this.InvertoryTimeCode_txt.TabIndex = 13;
            // 
            // InvertoryTimeCode_lbl
            // 
            this.InvertoryTimeCode_lbl.AutoSize = true;
            this.InvertoryTimeCode_lbl.ControlId = null;
            this.InvertoryTimeCode_lbl.Font = new System.Drawing.Font("Arial", 9F);
            this.InvertoryTimeCode_lbl.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.InvertoryTimeCode_lbl.Location = new System.Drawing.Point(12, 116);
            this.InvertoryTimeCode_lbl.Name = "InvertoryTimeCode_lbl";
            this.InvertoryTimeCode_lbl.Size = new System.Drawing.Size(119, 15);
            this.InvertoryTimeCode_lbl.TabIndex = 12;
            this.InvertoryTimeCode_lbl.Text = "Inventory Time Code";
            // 
            // InvertoryTimeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(735, 479);
            this.Controls.Add(this.Clear_btn);
            this.Controls.Add(this.Exit_btn);
            this.Controls.Add(this.Delete_btn);
            this.Controls.Add(this.Update_btn);
            this.Controls.Add(this.InvertoryTimeDetails_dgv);
            this.Controls.Add(this.Add_btn);
            this.Controls.Add(this.Search_btn);
            this.Controls.Add(this.InvertoryTimeName_txt);
            this.Controls.Add(this.InvertoryTimeName_lbl);
            this.Controls.Add(this.InvertoryTimeCode_txt);
            this.Controls.Add(this.InvertoryTimeCode_lbl);
            this.Name = "InvertoryTimeForm";
            this.Text = "Equipment Inventory";
            this.TitleText = "Equipment Inventory";
            this.Load += new System.EventHandler(this.RankForm_Load);
            this.Controls.SetChildIndex(this.InvertoryTimeCode_lbl, 0);
            this.Controls.SetChildIndex(this.InvertoryTimeCode_txt, 0);
            this.Controls.SetChildIndex(this.InvertoryTimeName_lbl, 0);
            this.Controls.SetChildIndex(this.InvertoryTimeName_txt, 0);
            this.Controls.SetChildIndex(this.Search_btn, 0);
            this.Controls.SetChildIndex(this.Add_btn, 0);
            this.Controls.SetChildIndex(this.InvertoryTimeDetails_dgv, 0);
            this.Controls.SetChildIndex(this.Update_btn, 0);
            this.Controls.SetChildIndex(this.Delete_btn, 0);
            this.Controls.SetChildIndex(this.Exit_btn, 0);
            this.Controls.SetChildIndex(this.Clear_btn, 0);
            ((System.ComponentModel.ISupportInitialize)(this.InvertoryTimeDetails_dgv)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Framework.ButtonCommon Clear_btn;
        private Framework.ButtonCommon Exit_btn;
        private Framework.ButtonCommon Delete_btn;
        private Framework.ButtonCommon Update_btn;
        internal Framework.DataGridViewCommon InvertoryTimeDetails_dgv;
        private Framework.ButtonCommon Add_btn;
        private Framework.ButtonCommon Search_btn;
        private Framework.TextBoxCommon InvertoryTimeName_txt;
        private Framework.LabelCommon InvertoryTimeName_lbl;
        private Framework.TextBoxCommon InvertoryTimeCode_txt;
        private Framework.LabelCommon InvertoryTimeCode_lbl;
        private System.Windows.Forms.DataGridViewTextBoxColumn colInvertoryTimeId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colInvertoryTimeCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn colInvertoryTimeName;
    }
}
