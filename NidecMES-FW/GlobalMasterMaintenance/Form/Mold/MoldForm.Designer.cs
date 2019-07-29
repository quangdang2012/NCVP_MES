namespace Com.Nidec.Mes.GlobalMasterMaintenance
{
    partial class MoldForm : FormCommonMaster
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MoldForm));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.MoldType_lbl = new Com.Nidec.Mes.Framework.LabelCommon();
            this.MoldType_cmb = new Com.Nidec.Mes.Framework.ComboBoxCommon();
            this.MoldCode_txt = new Com.Nidec.Mes.Framework.TextBoxCommon();
            this.MoldName_lbl = new Com.Nidec.Mes.Framework.LabelCommon();
            this.MoldName_txt = new Com.Nidec.Mes.Framework.TextBoxCommon();
            this.MoldCode_lbl = new Com.Nidec.Mes.Framework.LabelCommon();
            this.Clear_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.Exit_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.Delete_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.Update_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.Add_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.Search_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.Mold_dgv = new Com.Nidec.Mes.Framework.DataGridViewCommon();
            this.Upload_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.Download_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.ExcelExport_sfdlg = new System.Windows.Forms.SaveFileDialog();
            this.Save_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.colMoldId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMoldCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMoldName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMoldType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMoldTypeId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colWidth = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDepth = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHeight = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colWeight = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colProductionDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLifeShotCount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colComment = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colRemarks = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.Mold_dgv)).BeginInit();
            this.SuspendLayout();
            // 
            // MoldType_lbl
            // 
            resources.ApplyResources(this.MoldType_lbl, "MoldType_lbl");
            this.MoldType_lbl.ControlId = null;
            this.MoldType_lbl.Name = "MoldType_lbl";
            // 
            // MoldType_cmb
            // 
            resources.ApplyResources(this.MoldType_cmb, "MoldType_cmb");
            this.MoldType_cmb.ControlId = null;
            this.MoldType_cmb.FormattingEnabled = true;
            this.MoldType_cmb.Name = "MoldType_cmb";
            // 
            // MoldCode_txt
            // 
            resources.ApplyResources(this.MoldCode_txt, "MoldCode_txt");
            this.MoldCode_txt.ControlId = null;
            this.MoldCode_txt.InputType = Com.Nidec.Mes.Framework.TextBoxCommon.InputTypeList.All;
            this.MoldCode_txt.Name = "MoldCode_txt";
            // 
            // MoldName_lbl
            // 
            resources.ApplyResources(this.MoldName_lbl, "MoldName_lbl");
            this.MoldName_lbl.ControlId = null;
            this.MoldName_lbl.Name = "MoldName_lbl";
            // 
            // MoldName_txt
            // 
            resources.ApplyResources(this.MoldName_txt, "MoldName_txt");
            this.MoldName_txt.ControlId = null;
            this.MoldName_txt.InputType = Com.Nidec.Mes.Framework.TextBoxCommon.InputTypeList.All;
            this.MoldName_txt.Name = "MoldName_txt";
            // 
            // MoldCode_lbl
            // 
            resources.ApplyResources(this.MoldCode_lbl, "MoldCode_lbl");
            this.MoldCode_lbl.ControlId = null;
            this.MoldCode_lbl.Name = "MoldCode_lbl";
            // 
            // Clear_btn
            // 
            resources.ApplyResources(this.Clear_btn, "Clear_btn");
            this.Clear_btn.BackColor = System.Drawing.SystemColors.Control;
            this.Clear_btn.ControlId = null;
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
            resources.ApplyResources(this.Add_btn, "Add_btn");
            this.Add_btn.BackColor = System.Drawing.SystemColors.Control;
            this.Add_btn.ControlId = null;
            this.Add_btn.Name = "Add_btn";
            this.Add_btn.UseVisualStyleBackColor = true;
            this.Add_btn.Click += new System.EventHandler(this.Add_btn_Click);
            // 
            // Search_btn
            // 
            resources.ApplyResources(this.Search_btn, "Search_btn");
            this.Search_btn.BackColor = System.Drawing.SystemColors.Control;
            this.Search_btn.ControlId = null;
            this.Search_btn.Name = "Search_btn";
            this.Search_btn.UseVisualStyleBackColor = true;
            this.Search_btn.Click += new System.EventHandler(this.Search_btn_Click);
            // 
            // Mold_dgv
            // 
            resources.ApplyResources(this.Mold_dgv, "Mold_dgv");
            this.Mold_dgv.AllowUserToAddRows = false;
            this.Mold_dgv.AllowUserToDeleteRows = false;
            this.Mold_dgv.AllowUserToOrderColumns = true;
            this.Mold_dgv.AllowUserToResizeRows = false;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(232)))), ((int)(((byte)(180)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.Mold_dgv.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.Mold_dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Mold_dgv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colMoldId,
            this.colMoldCode,
            this.colMoldName,
            this.colMoldType,
            this.colMoldTypeId,
            this.colWidth,
            this.colDepth,
            this.colHeight,
            this.colWeight,
            this.colProductionDate,
            this.colLifeShotCount,
            this.colComment,
            this.colRemarks});
            this.Mold_dgv.ControlId = null;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.Mold_dgv.DefaultCellStyle = dataGridViewCellStyle5;
            this.Mold_dgv.EnableHeadersVisualStyles = false;
            this.Mold_dgv.MultiSelect = false;
            this.Mold_dgv.Name = "Mold_dgv";
            this.Mold_dgv.ReadOnly = true;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(232)))), ((int)(((byte)(180)))));
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.Mold_dgv.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.Mold_dgv.RowHeadersVisible = false;
            this.Mold_dgv.RowTemplate.Height = 21;
            this.Mold_dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.Mold_dgv.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Mold_dgv_CellClick);
            this.Mold_dgv.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Mold_dgv_CellDoubleClick);
            this.Mold_dgv.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.Mold_dgv_ColumnHeaderMouseClick);
            // 
            // Upload_btn
            // 
            resources.ApplyResources(this.Upload_btn, "Upload_btn");
            this.Upload_btn.BackColor = System.Drawing.SystemColors.Control;
            this.Upload_btn.ControlId = null;
            this.Upload_btn.Name = "Upload_btn";
            this.Upload_btn.UseVisualStyleBackColor = true;
            this.Upload_btn.Click += new System.EventHandler(this.Upload_btn_Click);
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
            // ExcelExport_sfdlg
            // 
            resources.ApplyResources(this.ExcelExport_sfdlg, "ExcelExport_sfdlg");
            // 
            // Save_btn
            // 
            resources.ApplyResources(this.Save_btn, "Save_btn");
            this.Save_btn.BackColor = System.Drawing.SystemColors.Control;
            this.Save_btn.ControlId = null;
            this.Save_btn.Name = "Save_btn";
            this.Save_btn.UseVisualStyleBackColor = true;
            this.Save_btn.Click += new System.EventHandler(this.Save_btn_Click);
            // 
            // colMoldId
            // 
            this.colMoldId.DataPropertyName = "MoldId";
            resources.ApplyResources(this.colMoldId, "colMoldId");
            this.colMoldId.Name = "colMoldId";
            this.colMoldId.ReadOnly = true;
            // 
            // colMoldCode
            // 
            this.colMoldCode.DataPropertyName = "MoldCode";
            resources.ApplyResources(this.colMoldCode, "colMoldCode");
            this.colMoldCode.Name = "colMoldCode";
            this.colMoldCode.ReadOnly = true;
            // 
            // colMoldName
            // 
            this.colMoldName.DataPropertyName = "MoldName";
            resources.ApplyResources(this.colMoldName, "colMoldName");
            this.colMoldName.Name = "colMoldName";
            this.colMoldName.ReadOnly = true;
            // 
            // colMoldType
            // 
            this.colMoldType.DataPropertyName = "MoldTypeCode";
            resources.ApplyResources(this.colMoldType, "colMoldType");
            this.colMoldType.Name = "colMoldType";
            this.colMoldType.ReadOnly = true;
            // 
            // colMoldTypeId
            // 
            this.colMoldTypeId.DataPropertyName = "MoldTypeId";
            resources.ApplyResources(this.colMoldTypeId, "colMoldTypeId");
            this.colMoldTypeId.Name = "colMoldTypeId";
            this.colMoldTypeId.ReadOnly = true;
            // 
            // colWidth
            // 
            this.colWidth.DataPropertyName = "Width";
            resources.ApplyResources(this.colWidth, "colWidth");
            this.colWidth.Name = "colWidth";
            this.colWidth.ReadOnly = true;
            // 
            // colDepth
            // 
            this.colDepth.DataPropertyName = "Depth";
            resources.ApplyResources(this.colDepth, "colDepth");
            this.colDepth.Name = "colDepth";
            this.colDepth.ReadOnly = true;
            // 
            // colHeight
            // 
            this.colHeight.DataPropertyName = "Height";
            resources.ApplyResources(this.colHeight, "colHeight");
            this.colHeight.Name = "colHeight";
            this.colHeight.ReadOnly = true;
            // 
            // colWeight
            // 
            this.colWeight.DataPropertyName = "Weight";
            resources.ApplyResources(this.colWeight, "colWeight");
            this.colWeight.Name = "colWeight";
            this.colWeight.ReadOnly = true;
            // 
            // colProductionDate
            // 
            this.colProductionDate.DataPropertyName = "ProductionDate";
            resources.ApplyResources(this.colProductionDate, "colProductionDate");
            this.colProductionDate.Name = "colProductionDate";
            this.colProductionDate.ReadOnly = true;
            // 
            // colLifeShotCount
            // 
            this.colLifeShotCount.DataPropertyName = "LifeShotCount";
            resources.ApplyResources(this.colLifeShotCount, "colLifeShotCount");
            this.colLifeShotCount.Name = "colLifeShotCount";
            this.colLifeShotCount.ReadOnly = true;
            // 
            // colComment
            // 
            this.colComment.DataPropertyName = "Comment";
            resources.ApplyResources(this.colComment, "colComment");
            this.colComment.Name = "colComment";
            this.colComment.ReadOnly = true;
            // 
            // colRemarks
            // 
            this.colRemarks.DataPropertyName = "Remarks";
            resources.ApplyResources(this.colRemarks, "colRemarks");
            this.colRemarks.Name = "colRemarks";
            this.colRemarks.ReadOnly = true;
            // 
            // MoldForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ControlId = "bpmf012";
            this.Controls.Add(this.Save_btn);
            this.Controls.Add(this.Download_btn);
            this.Controls.Add(this.Upload_btn);
            this.Controls.Add(this.MoldType_lbl);
            this.Controls.Add(this.MoldType_cmb);
            this.Controls.Add(this.MoldCode_txt);
            this.Controls.Add(this.MoldName_lbl);
            this.Controls.Add(this.MoldName_txt);
            this.Controls.Add(this.MoldCode_lbl);
            this.Controls.Add(this.Clear_btn);
            this.Controls.Add(this.Exit_btn);
            this.Controls.Add(this.Delete_btn);
            this.Controls.Add(this.Update_btn);
            this.Controls.Add(this.Add_btn);
            this.Controls.Add(this.Search_btn);
            this.Controls.Add(this.Mold_dgv);
            this.Name = "MoldForm";
            this.TitleText = "FormCommon";
            this.Load += new System.EventHandler(this.MoldForm_Load);
            this.Controls.SetChildIndex(this.Mold_dgv, 0);
            this.Controls.SetChildIndex(this.Search_btn, 0);
            this.Controls.SetChildIndex(this.Add_btn, 0);
            this.Controls.SetChildIndex(this.Update_btn, 0);
            this.Controls.SetChildIndex(this.Delete_btn, 0);
            this.Controls.SetChildIndex(this.Exit_btn, 0);
            this.Controls.SetChildIndex(this.Clear_btn, 0);
            this.Controls.SetChildIndex(this.MoldCode_lbl, 0);
            this.Controls.SetChildIndex(this.MoldName_txt, 0);
            this.Controls.SetChildIndex(this.MoldName_lbl, 0);
            this.Controls.SetChildIndex(this.MoldCode_txt, 0);
            this.Controls.SetChildIndex(this.MoldType_cmb, 0);
            this.Controls.SetChildIndex(this.MoldType_lbl, 0);
            this.Controls.SetChildIndex(this.Upload_btn, 0);
            this.Controls.SetChildIndex(this.Download_btn, 0);
            this.Controls.SetChildIndex(this.Save_btn, 0);
            ((System.ComponentModel.ISupportInitialize)(this.Mold_dgv)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        protected Framework.LabelCommon MoldType_lbl;
        protected Framework.ComboBoxCommon MoldType_cmb;
        protected Framework.TextBoxCommon MoldCode_txt;
        protected Framework.LabelCommon MoldName_lbl;
        protected Framework.TextBoxCommon MoldName_txt;
        protected Framework.LabelCommon MoldCode_lbl;
        protected Framework.ButtonCommon Clear_btn;
        protected Framework.ButtonCommon Exit_btn;
        protected Framework.ButtonCommon Delete_btn;
        protected Framework.ButtonCommon Update_btn;
        protected Framework.ButtonCommon Add_btn;
        protected Framework.ButtonCommon Search_btn;
        public Framework.DataGridViewCommon Mold_dgv;
        private Framework.ButtonCommon Upload_btn;
        private Framework.ButtonCommon Download_btn;
        private System.Windows.Forms.SaveFileDialog ExcelExport_sfdlg;
        protected Framework.ButtonCommon Save_btn;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMoldId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMoldCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMoldName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMoldType;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMoldTypeId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colWidth;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDepth;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHeight;
        private System.Windows.Forms.DataGridViewTextBoxColumn colWeight;
        private System.Windows.Forms.DataGridViewTextBoxColumn colProductionDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLifeShotCount;
        private System.Windows.Forms.DataGridViewTextBoxColumn colComment;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRemarks;
    }
}