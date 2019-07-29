namespace Com.Nidec.Mes.GlobalMasterMaintenance
{
    partial class DefectiveReasonForm:FormCommonMaster
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DefectiveReasonForm));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.DefectiveReasonCode_txt = new Com.Nidec.Mes.Framework.TextBoxCommon();
            this.DefectiveReasonName_lbl = new Com.Nidec.Mes.Framework.LabelCommon();
            this.DefectiveReasonName_txt = new Com.Nidec.Mes.Framework.TextBoxCommon();
            this.DefectiveReasonCode_lbl = new Com.Nidec.Mes.Framework.LabelCommon();
            this.Clear_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.Exit_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.Delete_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.Update_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.Add_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.Search_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.DefectiveReason_dgv = new Com.Nidec.Mes.Framework.DataGridViewCommon();
            this.DefectiveCategory_lbl = new Com.Nidec.Mes.Framework.LabelCommon();
            this.DefectiveCategory_cmb = new Com.Nidec.Mes.Framework.ComboBoxCommon();
            this.ExcelUpload_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.Download_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.ExcelExport_sfdlg = new System.Windows.Forms.SaveFileDialog();
            this.AddExcel_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.colDefectiveReasonId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDefectiveReasonCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDefectiveReasonName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDefectiveCategoryName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDisplayOrder = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colRemarks = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.DefectiveReason_dgv)).BeginInit();
            this.SuspendLayout();
            // 
            // DefectiveReasonCode_txt
            // 
            this.DefectiveReasonCode_txt.ControlId = null;
            resources.ApplyResources(this.DefectiveReasonCode_txt, "DefectiveReasonCode_txt");
            this.DefectiveReasonCode_txt.InputType = Com.Nidec.Mes.Framework.TextBoxCommon.InputTypeList.All;
            this.DefectiveReasonCode_txt.Name = "DefectiveReasonCode_txt";
            // 
            // DefectiveReasonName_lbl
            // 
            resources.ApplyResources(this.DefectiveReasonName_lbl, "DefectiveReasonName_lbl");
            this.DefectiveReasonName_lbl.ControlId = null;
            this.DefectiveReasonName_lbl.Name = "DefectiveReasonName_lbl";
            // 
            // DefectiveReasonName_txt
            // 
            this.DefectiveReasonName_txt.ControlId = null;
            resources.ApplyResources(this.DefectiveReasonName_txt, "DefectiveReasonName_txt");
            this.DefectiveReasonName_txt.InputType = Com.Nidec.Mes.Framework.TextBoxCommon.InputTypeList.All;
            this.DefectiveReasonName_txt.Name = "DefectiveReasonName_txt";
            // 
            // DefectiveReasonCode_lbl
            // 
            resources.ApplyResources(this.DefectiveReasonCode_lbl, "DefectiveReasonCode_lbl");
            this.DefectiveReasonCode_lbl.ControlId = null;
            this.DefectiveReasonCode_lbl.Name = "DefectiveReasonCode_lbl";
            // 
            // Clear_btn
            // 
            this.Clear_btn.BackColor = System.Drawing.SystemColors.Control;
            this.Clear_btn.ControlId = null;
            resources.ApplyResources(this.Clear_btn, "Clear_btn");
            this.Clear_btn.Name = "Clear_btn";
            this.Clear_btn.UseVisualStyleBackColor = true;
            this.Clear_btn.Click += new System.EventHandler(this.Clear_btn_Click);
            // 
            // Exit_btn
            // 
            resources.ApplyResources(this.Exit_btn, "Exit_btn");
            this.Exit_btn.BackColor = System.Drawing.SystemColors.Control;
            this.Exit_btn.ControlId = null;
            this.Exit_btn.Name = "Exit_btn";
            this.Exit_btn.UseVisualStyleBackColor = true;
            this.Exit_btn.Click += new System.EventHandler(this.Exit_btn_Click);
            // 
            // Delete_btn
            // 
            resources.ApplyResources(this.Delete_btn, "Delete_btn");
            this.Delete_btn.BackColor = System.Drawing.SystemColors.Control;
            this.Delete_btn.ControlId = null;
            this.Delete_btn.Name = "Delete_btn";
            this.Delete_btn.UseVisualStyleBackColor = true;
            this.Delete_btn.Click += new System.EventHandler(this.Delete_btn_Click);
            // 
            // Update_btn
            // 
            resources.ApplyResources(this.Update_btn, "Update_btn");
            this.Update_btn.BackColor = System.Drawing.SystemColors.Control;
            this.Update_btn.ControlId = null;
            this.Update_btn.Name = "Update_btn";
            this.Update_btn.UseVisualStyleBackColor = true;
            this.Update_btn.Click += new System.EventHandler(this.Update_btn_Click);
            // 
            // Add_btn
            // 
            this.Add_btn.BackColor = System.Drawing.SystemColors.Control;
            this.Add_btn.ControlId = null;
            resources.ApplyResources(this.Add_btn, "Add_btn");
            this.Add_btn.Name = "Add_btn";
            this.Add_btn.UseVisualStyleBackColor = true;
            this.Add_btn.Click += new System.EventHandler(this.Add_btn_Click);
            // 
            // Search_btn
            // 
            this.Search_btn.BackColor = System.Drawing.SystemColors.Control;
            this.Search_btn.ControlId = null;
            resources.ApplyResources(this.Search_btn, "Search_btn");
            this.Search_btn.Name = "Search_btn";
            this.Search_btn.UseVisualStyleBackColor = true;
            this.Search_btn.Click += new System.EventHandler(this.Search_btn_Click);
            // 
            // DefectiveReason_dgv
            // 
            this.DefectiveReason_dgv.AllowUserToAddRows = false;
            this.DefectiveReason_dgv.AllowUserToDeleteRows = false;
            this.DefectiveReason_dgv.AllowUserToOrderColumns = true;
            this.DefectiveReason_dgv.AllowUserToResizeRows = false;
            resources.ApplyResources(this.DefectiveReason_dgv, "DefectiveReason_dgv");
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(232)))), ((int)(((byte)(180)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DefectiveReason_dgv.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.DefectiveReason_dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DefectiveReason_dgv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colDefectiveReasonId,
            this.colDefectiveReasonCode,
            this.colDefectiveReasonName,
            this.colDefectiveCategoryName,
            this.colDisplayOrder,
            this.colRemarks});
            this.DefectiveReason_dgv.ControlId = null;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DefectiveReason_dgv.DefaultCellStyle = dataGridViewCellStyle3;
            this.DefectiveReason_dgv.EnableHeadersVisualStyles = false;
            this.DefectiveReason_dgv.MultiSelect = false;
            this.DefectiveReason_dgv.Name = "DefectiveReason_dgv";
            this.DefectiveReason_dgv.ReadOnly = true;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(232)))), ((int)(((byte)(180)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DefectiveReason_dgv.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.DefectiveReason_dgv.RowHeadersVisible = false;
            this.DefectiveReason_dgv.RowTemplate.Height = 21;
            this.DefectiveReason_dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.DefectiveReason_dgv.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DefectiveReason_dgv_CellClick);
            this.DefectiveReason_dgv.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DefectiveReason_dgv_CellDoubleClick);
            // 
            // DefectiveCategory_lbl
            // 
            resources.ApplyResources(this.DefectiveCategory_lbl, "DefectiveCategory_lbl");
            this.DefectiveCategory_lbl.ControlId = null;
            this.DefectiveCategory_lbl.Name = "DefectiveCategory_lbl";
            // 
            // DefectiveCategory_cmb
            // 
            this.DefectiveCategory_cmb.ControlId = null;
            resources.ApplyResources(this.DefectiveCategory_cmb, "DefectiveCategory_cmb");
            this.DefectiveCategory_cmb.FormattingEnabled = true;
            this.DefectiveCategory_cmb.Name = "DefectiveCategory_cmb";
            // 
            // ExcelUpload_btn
            // 
            resources.ApplyResources(this.ExcelUpload_btn, "ExcelUpload_btn");
            this.ExcelUpload_btn.BackColor = System.Drawing.SystemColors.Control;
            this.ExcelUpload_btn.ControlId = null;
            this.ExcelUpload_btn.Name = "ExcelUpload_btn";
            this.ExcelUpload_btn.UseVisualStyleBackColor = true;
            this.ExcelUpload_btn.Click += new System.EventHandler(this.ExcelUpload_btn_Click);
            // 
            // Download_btn
            // 
            resources.ApplyResources(this.Download_btn, "Download_btn");
            this.Download_btn.BackColor = System.Drawing.SystemColors.Control;
            this.Download_btn.ControlId = null;
            this.Download_btn.Name = "Download_btn";
            this.Download_btn.UseVisualStyleBackColor = true;
            this.Download_btn.Click += new System.EventHandler(this.Download_btn_Click);
            // 
            // AddExcel_btn
            // 
            resources.ApplyResources(this.AddExcel_btn, "AddExcel_btn");
            this.AddExcel_btn.BackColor = System.Drawing.SystemColors.Control;
            this.AddExcel_btn.ControlId = null;
            this.AddExcel_btn.Name = "AddExcel_btn";
            this.AddExcel_btn.UseVisualStyleBackColor = true;
            this.AddExcel_btn.Click += new System.EventHandler(this.AddExcel_btn_Click);
            // 
            // colDefectiveReasonId
            // 
            this.colDefectiveReasonId.DataPropertyName = "DefectiveReasonId";
            resources.ApplyResources(this.colDefectiveReasonId, "colDefectiveReasonId");
            this.colDefectiveReasonId.Name = "colDefectiveReasonId";
            this.colDefectiveReasonId.ReadOnly = true;
            // 
            // colDefectiveReasonCode
            // 
            this.colDefectiveReasonCode.DataPropertyName = "DefectiveReasonCode";
            resources.ApplyResources(this.colDefectiveReasonCode, "colDefectiveReasonCode");
            this.colDefectiveReasonCode.Name = "colDefectiveReasonCode";
            this.colDefectiveReasonCode.ReadOnly = true;
            // 
            // colDefectiveReasonName
            // 
            this.colDefectiveReasonName.DataPropertyName = "DefectiveReasonName";
            resources.ApplyResources(this.colDefectiveReasonName, "colDefectiveReasonName");
            this.colDefectiveReasonName.Name = "colDefectiveReasonName";
            this.colDefectiveReasonName.ReadOnly = true;
            // 
            // colDefectiveCategoryName
            // 
            this.colDefectiveCategoryName.DataPropertyName = "DefectiveCategoryName";
            resources.ApplyResources(this.colDefectiveCategoryName, "colDefectiveCategoryName");
            this.colDefectiveCategoryName.Name = "colDefectiveCategoryName";
            this.colDefectiveCategoryName.ReadOnly = true;
            // 
            // colDisplayOrder
            // 
            this.colDisplayOrder.DataPropertyName = "DisplayOrder";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.colDisplayOrder.DefaultCellStyle = dataGridViewCellStyle2;
            resources.ApplyResources(this.colDisplayOrder, "colDisplayOrder");
            this.colDisplayOrder.Name = "colDisplayOrder";
            this.colDisplayOrder.ReadOnly = true;
            // 
            // colRemarks
            // 
            this.colRemarks.DataPropertyName = "Remarks";
            resources.ApplyResources(this.colRemarks, "colRemarks");
            this.colRemarks.Name = "colRemarks";
            this.colRemarks.ReadOnly = true;
            // 
            // DefectiveReasonForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ControlId = "bpmf013";
            this.Controls.Add(this.AddExcel_btn);
            this.Controls.Add(this.Download_btn);
            this.Controls.Add(this.ExcelUpload_btn);
            this.Controls.Add(this.DefectiveCategory_lbl);
            this.Controls.Add(this.DefectiveCategory_cmb);
            this.Controls.Add(this.DefectiveReasonCode_txt);
            this.Controls.Add(this.DefectiveReasonName_lbl);
            this.Controls.Add(this.DefectiveReasonName_txt);
            this.Controls.Add(this.DefectiveReasonCode_lbl);
            this.Controls.Add(this.Clear_btn);
            this.Controls.Add(this.Exit_btn);
            this.Controls.Add(this.Delete_btn);
            this.Controls.Add(this.Update_btn);
            this.Controls.Add(this.Add_btn);
            this.Controls.Add(this.Search_btn);
            this.Controls.Add(this.DefectiveReason_dgv);
            this.Name = "DefectiveReasonForm";
            this.TitleText = "FormCommon";
            this.Load += new System.EventHandler(this.DefectiveReasonForm_Load);
            this.Controls.SetChildIndex(this.DefectiveReason_dgv, 0);
            this.Controls.SetChildIndex(this.Search_btn, 0);
            this.Controls.SetChildIndex(this.Add_btn, 0);
            this.Controls.SetChildIndex(this.Update_btn, 0);
            this.Controls.SetChildIndex(this.Delete_btn, 0);
            this.Controls.SetChildIndex(this.Exit_btn, 0);
            this.Controls.SetChildIndex(this.Clear_btn, 0);
            this.Controls.SetChildIndex(this.DefectiveReasonCode_lbl, 0);
            this.Controls.SetChildIndex(this.DefectiveReasonName_txt, 0);
            this.Controls.SetChildIndex(this.DefectiveReasonName_lbl, 0);
            this.Controls.SetChildIndex(this.DefectiveReasonCode_txt, 0);
            this.Controls.SetChildIndex(this.DefectiveCategory_cmb, 0);
            this.Controls.SetChildIndex(this.DefectiveCategory_lbl, 0);
            this.Controls.SetChildIndex(this.ExcelUpload_btn, 0);
            this.Controls.SetChildIndex(this.Download_btn, 0);
            this.Controls.SetChildIndex(this.AddExcel_btn, 0);
            ((System.ComponentModel.ISupportInitialize)(this.DefectiveReason_dgv)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Com.Nidec.Mes.Framework.TextBoxCommon DefectiveReasonCode_txt;
        private Com.Nidec.Mes.Framework.LabelCommon DefectiveReasonName_lbl;
        private Com.Nidec.Mes.Framework.TextBoxCommon DefectiveReasonName_txt;
        private Com.Nidec.Mes.Framework.LabelCommon DefectiveReasonCode_lbl;
        private Com.Nidec.Mes.Framework.ButtonCommon Clear_btn;
        private Com.Nidec.Mes.Framework.ButtonCommon Exit_btn;
        private Com.Nidec.Mes.Framework.ButtonCommon Delete_btn;
        private Com.Nidec.Mes.Framework.ButtonCommon Update_btn;
        private Com.Nidec.Mes.Framework.ButtonCommon Add_btn;
        private Com.Nidec.Mes.Framework.ButtonCommon Search_btn;
        internal Com.Nidec.Mes.Framework.DataGridViewCommon DefectiveReason_dgv;
        protected Framework.LabelCommon DefectiveCategory_lbl;
        protected Framework.ComboBoxCommon DefectiveCategory_cmb;
        private Framework.ButtonCommon ExcelUpload_btn;
        private Framework.ButtonCommon Download_btn;
        private System.Windows.Forms.SaveFileDialog ExcelExport_sfdlg;
        private Framework.ButtonCommon AddExcel_btn;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDefectiveReasonId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDefectiveReasonCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDefectiveReasonName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDefectiveCategoryName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDisplayOrder;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRemarks;
    }
}