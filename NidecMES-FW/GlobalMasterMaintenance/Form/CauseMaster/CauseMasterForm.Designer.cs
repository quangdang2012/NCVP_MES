namespace Com.Nidec.Mes.GlobalMasterMaintenance
{
    partial class CauseMasterForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CauseMasterForm));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.Update_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.MachineName_cmb = new Com.Nidec.Mes.Framework.ComboBoxCommon();
            this.MachineName_lbl = new Com.Nidec.Mes.Framework.LabelCommon();
            this.Cause_dgv = new Com.Nidec.Mes.Framework.DataGridViewCommon();
            this.colSelected = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colDefectiveCd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColDefectiveName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.Cause_dgv)).BeginInit();
            this.SuspendLayout();
            // 
            // Update_btn
            // 
            this.Update_btn.BackColor = System.Drawing.SystemColors.Control;
            this.Update_btn.ControlId = null;
            resources.ApplyResources(this.Update_btn, "Update_btn");
            this.Update_btn.Name = "Update_btn";
            this.Update_btn.UseVisualStyleBackColor = true;
            this.Update_btn.Click += new System.EventHandler(this.Update_btn_Click);
            // 
            // MachineName_cmb
            // 
            this.MachineName_cmb.ControlId = null;
            resources.ApplyResources(this.MachineName_cmb, "MachineName_cmb");
            this.MachineName_cmb.FormattingEnabled = true;
            this.MachineName_cmb.Name = "MachineName_cmb";
            this.MachineName_cmb.SelectedIndexChanged += new System.EventHandler(this.MachineName_cmb_SelectedIndexChanged);
            // 
            // MachineName_lbl
            // 
            resources.ApplyResources(this.MachineName_lbl, "MachineName_lbl");
            this.MachineName_lbl.ControlId = null;
            this.MachineName_lbl.Name = "MachineName_lbl";
            // 
            // Cause_dgv
            // 
            this.Cause_dgv.AllowUserToAddRows = false;
            this.Cause_dgv.AllowUserToDeleteRows = false;
            this.Cause_dgv.AllowUserToOrderColumns = true;
            this.Cause_dgv.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(232)))), ((int)(((byte)(180)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.Cause_dgv.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.Cause_dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Cause_dgv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colSelected,
            this.colDefectiveCd,
            this.ColDefectiveName});
            this.Cause_dgv.ControlId = null;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.Cause_dgv.DefaultCellStyle = dataGridViewCellStyle2;
            this.Cause_dgv.EnableHeadersVisualStyles = false;
            resources.ApplyResources(this.Cause_dgv, "Cause_dgv");
            this.Cause_dgv.MultiSelect = false;
            this.Cause_dgv.Name = "Cause_dgv";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(232)))), ((int)(((byte)(180)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.Cause_dgv.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.Cause_dgv.RowHeadersVisible = false;
            this.Cause_dgv.RowTemplate.Height = 21;
            this.Cause_dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.Cause_dgv.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.Cause_dgv_CellBeginEdit);
            // 
            // colSelected
            // 
            this.colSelected.DataPropertyName = "Selected";
            resources.ApplyResources(this.colSelected, "colSelected");
            this.colSelected.Name = "colSelected";
            // 
            // colDefectiveCd
            // 
            this.colDefectiveCd.DataPropertyName = "DefectiveCode";
            resources.ApplyResources(this.colDefectiveCd, "colDefectiveCd");
            this.colDefectiveCd.Name = "colDefectiveCd";
            this.colDefectiveCd.ReadOnly = true;
            // 
            // ColDefectiveName
            // 
            this.ColDefectiveName.DataPropertyName = "DefectiveName";
            resources.ApplyResources(this.ColDefectiveName, "ColDefectiveName");
            this.ColDefectiveName.Name = "ColDefectiveName";
            this.ColDefectiveName.ReadOnly = true;
            // 
            // CauseMasterForm
            // 
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.Cause_dgv);
            this.Controls.Add(this.Update_btn);
            this.Controls.Add(this.MachineName_cmb);
            this.Controls.Add(this.MachineName_lbl);
            this.Name = "CauseMasterForm";
            this.TitleText = "FormCommon";
            this.Load += new System.EventHandler(this.CauseMasterForm_Load);
            this.Controls.SetChildIndex(this.MachineName_lbl, 0);
            this.Controls.SetChildIndex(this.MachineName_cmb, 0);
            this.Controls.SetChildIndex(this.Update_btn, 0);
            this.Controls.SetChildIndex(this.Cause_dgv, 0);
            ((System.ComponentModel.ISupportInitialize)(this.Cause_dgv)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Framework.ButtonCommon Update_btn;
        private Framework.ComboBoxCommon MachineName_cmb;
        private Framework.LabelCommon MachineName_lbl;
        internal Framework.DataGridViewCommon Cause_dgv;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colSelected;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDefectiveCd;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColDefectiveName;
    }
}
