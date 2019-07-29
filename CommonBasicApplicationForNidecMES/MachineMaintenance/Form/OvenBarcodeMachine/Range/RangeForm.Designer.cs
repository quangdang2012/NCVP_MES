namespace Com.Nidec.Mes.Common.Basic.MachineMaintenance
{
    partial class RangeForm
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
            this.Exit_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.Delete_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.Update_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.RangeOven_dgv = new Com.Nidec.Mes.Framework.DataGridViewCommon();
            this.Add_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.Search_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.line_lbl = new Com.Nidec.Mes.Framework.LabelCommon();
            this.RankCode_lbl = new Com.Nidec.Mes.Framework.LabelCommon();
            this.range_model_cbm = new Com.Nidec.Mes.Framework.ComboBoxCommon();
            this.range_line_cbm = new Com.Nidec.Mes.Framework.ComboBoxCommon();
            this.colRangeId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colModel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLine = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBarcode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLower = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colUpper = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.RangeOven_dgv)).BeginInit();
            this.SuspendLayout();
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
            // RangeOven_dgv
            // 
            this.RangeOven_dgv.AllowUserToAddRows = false;
            this.RangeOven_dgv.AllowUserToDeleteRows = false;
            this.RangeOven_dgv.AllowUserToOrderColumns = true;
            this.RangeOven_dgv.AllowUserToResizeRows = false;
            this.RangeOven_dgv.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(232)))), ((int)(((byte)(180)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.RangeOven_dgv.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.RangeOven_dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.RangeOven_dgv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colRangeId,
            this.colModel,
            this.colLine,
            this.colBarcode,
            this.colLower,
            this.colUpper});
            this.RangeOven_dgv.ControlId = null;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.RangeOven_dgv.DefaultCellStyle = dataGridViewCellStyle2;
            this.RangeOven_dgv.EnableHeadersVisualStyles = false;
            this.RangeOven_dgv.Location = new System.Drawing.Point(-2, 176);
            this.RangeOven_dgv.MultiSelect = false;
            this.RangeOven_dgv.Name = "RangeOven_dgv";
            this.RangeOven_dgv.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(232)))), ((int)(((byte)(180)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.RangeOven_dgv.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.RangeOven_dgv.RowHeadersVisible = false;
            this.RangeOven_dgv.RowTemplate.Height = 21;
            this.RangeOven_dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.RangeOven_dgv.Size = new System.Drawing.Size(737, 252);
            this.RangeOven_dgv.TabIndex = 19;
            this.RangeOven_dgv.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.RankDetails_dgv_CellClick);
            this.RangeOven_dgv.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.RankDetails_dgv_CellDoubleClick);
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
            // line_lbl
            // 
            this.line_lbl.AutoSize = true;
            this.line_lbl.ControlId = null;
            this.line_lbl.Font = new System.Drawing.Font("Arial", 9F);
            this.line_lbl.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.line_lbl.Location = new System.Drawing.Point(34, 146);
            this.line_lbl.Name = "line_lbl";
            this.line_lbl.Size = new System.Drawing.Size(31, 15);
            this.line_lbl.TabIndex = 14;
            this.line_lbl.Text = "Line";
            // 
            // RankCode_lbl
            // 
            this.RankCode_lbl.AutoSize = true;
            this.RankCode_lbl.ControlId = null;
            this.RankCode_lbl.Font = new System.Drawing.Font("Arial", 9F);
            this.RankCode_lbl.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.RankCode_lbl.Location = new System.Drawing.Point(25, 116);
            this.RankCode_lbl.Name = "RankCode_lbl";
            this.RankCode_lbl.Size = new System.Drawing.Size(40, 15);
            this.RankCode_lbl.TabIndex = 12;
            this.RankCode_lbl.Text = "Model";
            // 
            // range_model_cbm
            // 
            this.range_model_cbm.ControlId = null;
            this.range_model_cbm.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.range_model_cbm.FormattingEnabled = true;
            this.range_model_cbm.Location = new System.Drawing.Point(71, 113);
            this.range_model_cbm.Name = "range_model_cbm";
            this.range_model_cbm.Size = new System.Drawing.Size(152, 23);
            this.range_model_cbm.TabIndex = 79;
            this.range_model_cbm.SelectedIndexChanged += new System.EventHandler(this.range_model_cbm_SelectedIndexChanged);
            // 
            // range_line_cbm
            // 
            this.range_line_cbm.ControlId = null;
            this.range_line_cbm.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.range_line_cbm.FormattingEnabled = true;
            this.range_line_cbm.Location = new System.Drawing.Point(71, 142);
            this.range_line_cbm.Name = "range_line_cbm";
            this.range_line_cbm.Size = new System.Drawing.Size(152, 23);
            this.range_line_cbm.TabIndex = 80;
            // 
            // colRangeId
            // 
            this.colRangeId.DataPropertyName = "RangeId";
            this.colRangeId.HeaderText = "RangeID";
            this.colRangeId.Name = "colRangeId";
            this.colRangeId.ReadOnly = true;
            this.colRangeId.Visible = false;
            // 
            // colModel
            // 
            this.colModel.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colModel.DataPropertyName = "Model";
            this.colModel.HeaderText = "Model";
            this.colModel.Name = "colModel";
            this.colModel.ReadOnly = true;
            // 
            // colLine
            // 
            this.colLine.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colLine.DataPropertyName = "Line";
            this.colLine.HeaderText = "Line";
            this.colLine.Name = "colLine";
            this.colLine.ReadOnly = true;
            // 
            // colBarcode
            // 
            this.colBarcode.DataPropertyName = "Barcode";
            this.colBarcode.HeaderText = "Barcode";
            this.colBarcode.Name = "colBarcode";
            this.colBarcode.ReadOnly = true;
            // 
            // colLower
            // 
            this.colLower.DataPropertyName = "Lower";
            this.colLower.HeaderText = "t° Lower";
            this.colLower.Name = "colLower";
            this.colLower.ReadOnly = true;
            // 
            // colUpper
            // 
            this.colUpper.DataPropertyName = "Upper";
            this.colUpper.HeaderText = "t° Upper";
            this.colUpper.Name = "colUpper";
            this.colUpper.ReadOnly = true;
            // 
            // RangeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(735, 479);
            this.Controls.Add(this.range_line_cbm);
            this.Controls.Add(this.range_model_cbm);
            this.Controls.Add(this.Exit_btn);
            this.Controls.Add(this.Delete_btn);
            this.Controls.Add(this.Update_btn);
            this.Controls.Add(this.RangeOven_dgv);
            this.Controls.Add(this.Add_btn);
            this.Controls.Add(this.Search_btn);
            this.Controls.Add(this.line_lbl);
            this.Controls.Add(this.RankCode_lbl);
            this.Name = "RangeForm";
            this.TitleText = "FormCommon";
            this.Load += new System.EventHandler(this.RankForm_Load);
            this.Controls.SetChildIndex(this.RankCode_lbl, 0);
            this.Controls.SetChildIndex(this.line_lbl, 0);
            this.Controls.SetChildIndex(this.Search_btn, 0);
            this.Controls.SetChildIndex(this.Add_btn, 0);
            this.Controls.SetChildIndex(this.RangeOven_dgv, 0);
            this.Controls.SetChildIndex(this.Update_btn, 0);
            this.Controls.SetChildIndex(this.Delete_btn, 0);
            this.Controls.SetChildIndex(this.Exit_btn, 0);
            this.Controls.SetChildIndex(this.range_model_cbm, 0);
            this.Controls.SetChildIndex(this.range_line_cbm, 0);
            ((System.ComponentModel.ISupportInitialize)(this.RangeOven_dgv)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        
        private Framework.ButtonCommon Exit_btn;
        private Framework.ButtonCommon Delete_btn;
        private Framework.ButtonCommon Update_btn;
        internal Framework.DataGridViewCommon RangeOven_dgv;
        private Framework.ButtonCommon Add_btn;
        private Framework.ButtonCommon Search_btn;
        private Framework.LabelCommon line_lbl;
        private Framework.LabelCommon RankCode_lbl;
        private Framework.ComboBoxCommon range_model_cbm;
        private Framework.ComboBoxCommon range_line_cbm;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRangeId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colModel;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLine;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBarcode;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLower;
        private System.Windows.Forms.DataGridViewTextBoxColumn colUpper;
    }
}
