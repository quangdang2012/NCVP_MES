namespace Com.Nidec.Mes.GlobalMasterMaintenance
{
    partial class ResponseMachineMasterForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ResponseMachineMasterForm));
            this.RespMachine_dgv = new Com.Nidec.Mes.Framework.DataGridViewCommon();
            this.colSelect = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.col_prodution_work_content_cd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_prodution_work_content_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Update_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.machinename_cmb = new Com.Nidec.Mes.Framework.ComboBoxCommon();
            this.machinename_lbl = new Com.Nidec.Mes.Framework.LabelCommon();
            ((System.ComponentModel.ISupportInitialize)(this.RespMachine_dgv)).BeginInit();
            this.SuspendLayout();
            // 
            // RespMachine_dgv
            // 
            this.RespMachine_dgv.AllowUserToAddRows = false;
            this.RespMachine_dgv.AllowUserToDeleteRows = false;
            this.RespMachine_dgv.AllowUserToOrderColumns = true;
            this.RespMachine_dgv.AllowUserToResizeRows = false;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(232)))), ((int)(((byte)(180)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.RespMachine_dgv.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.RespMachine_dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.RespMachine_dgv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colSelect,
            this.col_prodution_work_content_cd,
            this.col_prodution_work_content_name});
            this.RespMachine_dgv.ControlId = null;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.RespMachine_dgv.DefaultCellStyle = dataGridViewCellStyle5;
            this.RespMachine_dgv.EnableHeadersVisualStyles = false;
            resources.ApplyResources(this.RespMachine_dgv, "RespMachine_dgv");
            this.RespMachine_dgv.MultiSelect = false;
            this.RespMachine_dgv.Name = "RespMachine_dgv";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(232)))), ((int)(((byte)(180)))));
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.RespMachine_dgv.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.RespMachine_dgv.RowHeadersVisible = false;
            this.RespMachine_dgv.RowTemplate.Height = 21;
            this.RespMachine_dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.RespMachine_dgv.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.RespMachine_dgv_CellBeginEdit);
            // 
            // colSelect
            // 
            this.colSelect.DataPropertyName = "Selected";
            resources.ApplyResources(this.colSelect, "colSelect");
            this.colSelect.Name = "colSelect";
            this.colSelect.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colSelect.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // col_prodution_work_content_cd
            // 
            this.col_prodution_work_content_cd.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.col_prodution_work_content_cd.DataPropertyName = "ProdWorkContCode";
            resources.ApplyResources(this.col_prodution_work_content_cd, "col_prodution_work_content_cd");
            this.col_prodution_work_content_cd.Name = "col_prodution_work_content_cd";
            this.col_prodution_work_content_cd.ReadOnly = true;
            // 
            // col_prodution_work_content_name
            // 
            this.col_prodution_work_content_name.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.col_prodution_work_content_name.DataPropertyName = "ProdWorkContName";
            resources.ApplyResources(this.col_prodution_work_content_name, "col_prodution_work_content_name");
            this.col_prodution_work_content_name.Name = "col_prodution_work_content_name";
            this.col_prodution_work_content_name.ReadOnly = true;
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
            // machinename_cmb
            // 
            this.machinename_cmb.ControlId = null;
            resources.ApplyResources(this.machinename_cmb, "machinename_cmb");
            this.machinename_cmb.FormattingEnabled = true;
            this.machinename_cmb.Name = "machinename_cmb";
            this.machinename_cmb.SelectedIndexChanged += new System.EventHandler(this.machinename_cmb_SelectedIndexChanged);
            // 
            // machinename_lbl
            // 
            resources.ApplyResources(this.machinename_lbl, "machinename_lbl");
            this.machinename_lbl.ControlId = null;
            this.machinename_lbl.Name = "machinename_lbl";
            // 
            // ResponseMachineMasterForm
            // 
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.RespMachine_dgv);
            this.Controls.Add(this.Update_btn);
            this.Controls.Add(this.machinename_cmb);
            this.Controls.Add(this.machinename_lbl);
            this.Name = "ResponseMachineMasterForm";
            this.TitleText = "FormCommon";
            this.Load += new System.EventHandler(this.ResponseMachineMasterForm_Load);
            this.Controls.SetChildIndex(this.machinename_lbl, 0);
            this.Controls.SetChildIndex(this.machinename_cmb, 0);
            this.Controls.SetChildIndex(this.Update_btn, 0);
            this.Controls.SetChildIndex(this.RespMachine_dgv, 0);
            ((System.ComponentModel.ISupportInitialize)(this.RespMachine_dgv)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal Framework.DataGridViewCommon RespMachine_dgv;
        private Framework.ButtonCommon Update_btn;
        private Framework.ComboBoxCommon machinename_cmb;
        private Framework.LabelCommon machinename_lbl;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colSelect;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_prodution_work_content_cd;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_prodution_work_content_name;
    }
}
