namespace Com.Nidec.Mes.GlobalMasterMaintenance
{
    partial class LineRestTimeForm : FormCommonMaster
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LineRestTimeForm));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.LineCode_txt = new Com.Nidec.Mes.Framework.TextBoxCommon();
            this.LineCode_lbl = new Com.Nidec.Mes.Framework.LabelCommon();
            this.LineName_txt = new Com.Nidec.Mes.Framework.TextBoxCommon();
            this.LineName_lbl = new Com.Nidec.Mes.Framework.LabelCommon();
            this.Add_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.Search_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.LineDetails_dgv = new Com.Nidec.Mes.Framework.DataGridViewCommon();
            this.colLineId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLineCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLineName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colRemarks = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Exit_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.Delete_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.Update_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.Clear_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.Upload_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.DownloadExcel_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.Save_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            ((System.ComponentModel.ISupportInitialize)(this.LineDetails_dgv)).BeginInit();
            this.SuspendLayout();
            // 
            // LineCode_txt
            // 
            resources.ApplyResources(this.LineCode_txt, "LineCode_txt");
            this.LineCode_txt.ControlId = null;
            this.LineCode_txt.InputType = Com.Nidec.Mes.Framework.TextBoxCommon.InputTypeList.All;
            this.LineCode_txt.Name = "LineCode_txt";
            // 
            // LineCode_lbl
            // 
            resources.ApplyResources(this.LineCode_lbl, "LineCode_lbl");
            this.LineCode_lbl.ControlId = null;
            this.LineCode_lbl.Name = "LineCode_lbl";
            // 
            // LineName_txt
            // 
            resources.ApplyResources(this.LineName_txt, "LineName_txt");
            this.LineName_txt.ControlId = null;
            this.LineName_txt.InputType = Com.Nidec.Mes.Framework.TextBoxCommon.InputTypeList.All;
            this.LineName_txt.Name = "LineName_txt";
            // 
            // LineName_lbl
            // 
            resources.ApplyResources(this.LineName_lbl, "LineName_lbl");
            this.LineName_lbl.ControlId = null;
            this.LineName_lbl.Name = "LineName_lbl";
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
            // LineDetails_dgv
            // 
            resources.ApplyResources(this.LineDetails_dgv, "LineDetails_dgv");
            this.LineDetails_dgv.AllowUserToAddRows = false;
            this.LineDetails_dgv.AllowUserToDeleteRows = false;
            this.LineDetails_dgv.AllowUserToOrderColumns = true;
            this.LineDetails_dgv.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(232)))), ((int)(((byte)(180)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.LineDetails_dgv.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.LineDetails_dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.LineDetails_dgv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colLineId,
            this.colLineCode,
            this.colLineName,
            this.colRemarks});
            this.LineDetails_dgv.ControlId = null;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.LineDetails_dgv.DefaultCellStyle = dataGridViewCellStyle2;
            this.LineDetails_dgv.EnableHeadersVisualStyles = false;
            this.LineDetails_dgv.MultiSelect = false;
            this.LineDetails_dgv.Name = "LineDetails_dgv";
            this.LineDetails_dgv.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(232)))), ((int)(((byte)(180)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.LineDetails_dgv.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.LineDetails_dgv.RowHeadersVisible = false;
            this.LineDetails_dgv.RowTemplate.Height = 21;
            this.LineDetails_dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.LineDetails_dgv.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.LineDetails_dgv_CellClick);
            this.LineDetails_dgv.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.LineDetails_dgv_CellDoubleClick);
            this.LineDetails_dgv.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.LineDetails_dgv_ColumnHeaderMouseClick);
            // 
            // colLineId
            // 
            this.colLineId.DataPropertyName = "LineId";
            resources.ApplyResources(this.colLineId, "colLineId");
            this.colLineId.Name = "colLineId";
            this.colLineId.ReadOnly = true;
            // 
            // colLineCode
            // 
            this.colLineCode.DataPropertyName = "LineCode";
            resources.ApplyResources(this.colLineCode, "colLineCode");
            this.colLineCode.Name = "colLineCode";
            this.colLineCode.ReadOnly = true;
            // 
            // colLineName
            // 
            this.colLineName.DataPropertyName = "LineName";
            resources.ApplyResources(this.colLineName, "colLineName");
            this.colLineName.Name = "colLineName";
            this.colLineName.ReadOnly = true;
            // 
            // colRemarks
            // 
            this.colRemarks.DataPropertyName = "Remarks";
            resources.ApplyResources(this.colRemarks, "colRemarks");
            this.colRemarks.Name = "colRemarks";
            this.colRemarks.ReadOnly = true;
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
            // Clear_btn
            // 
            resources.ApplyResources(this.Clear_btn, "Clear_btn");
            this.Clear_btn.BackColor = System.Drawing.SystemColors.Control;
            this.Clear_btn.ControlId = null;
            this.Clear_btn.Name = "Clear_btn";
            this.Clear_btn.UseVisualStyleBackColor = true;
            this.Clear_btn.Click += new System.EventHandler(this.Clear_btn_Click);
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
            // DownloadExcel_btn
            // 
            resources.ApplyResources(this.DownloadExcel_btn, "DownloadExcel_btn");
            this.DownloadExcel_btn.BackColor = System.Drawing.SystemColors.Control;
            this.DownloadExcel_btn.ControlId = null;
            this.DownloadExcel_btn.Name = "DownloadExcel_btn";
            this.DownloadExcel_btn.UseVisualStyleBackColor = true;
            this.DownloadExcel_btn.Click += new System.EventHandler(this.DownloadExcel_btn_Click);
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
            // LineRestTimeForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ControlId = "bpmf006";
            this.Controls.Add(this.Save_btn);
            this.Controls.Add(this.DownloadExcel_btn);
            this.Controls.Add(this.Upload_btn);
            this.Controls.Add(this.Clear_btn);
            this.Controls.Add(this.Exit_btn);
            this.Controls.Add(this.Delete_btn);
            this.Controls.Add(this.Update_btn);
            this.Controls.Add(this.LineDetails_dgv);
            this.Controls.Add(this.Add_btn);
            this.Controls.Add(this.Search_btn);
            this.Controls.Add(this.LineName_txt);
            this.Controls.Add(this.LineName_lbl);
            this.Controls.Add(this.LineCode_txt);
            this.Controls.Add(this.LineCode_lbl);
            this.Name = "LineRestTimeForm";
            this.TitleText = "FormCommon";
            this.Load += new System.EventHandler(this.LineRestTimeForm_Load);
            this.Controls.SetChildIndex(this.LineCode_lbl, 0);
            this.Controls.SetChildIndex(this.LineCode_txt, 0);
            this.Controls.SetChildIndex(this.LineName_lbl, 0);
            this.Controls.SetChildIndex(this.LineName_txt, 0);
            this.Controls.SetChildIndex(this.Search_btn, 0);
            this.Controls.SetChildIndex(this.Add_btn, 0);
            this.Controls.SetChildIndex(this.LineDetails_dgv, 0);
            this.Controls.SetChildIndex(this.Update_btn, 0);
            this.Controls.SetChildIndex(this.Delete_btn, 0);
            this.Controls.SetChildIndex(this.Exit_btn, 0);
            this.Controls.SetChildIndex(this.Clear_btn, 0);
            this.Controls.SetChildIndex(this.Upload_btn, 0);
            this.Controls.SetChildIndex(this.DownloadExcel_btn, 0);
            this.Controls.SetChildIndex(this.Save_btn, 0);
            ((System.ComponentModel.ISupportInitialize)(this.LineDetails_dgv)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Com.Nidec.Mes.Framework.TextBoxCommon LineCode_txt;
        private Com.Nidec.Mes.Framework.LabelCommon LineCode_lbl;
        private Com.Nidec.Mes.Framework.TextBoxCommon LineName_txt;
        private Com.Nidec.Mes.Framework.LabelCommon LineName_lbl;
        private Com.Nidec.Mes.Framework.ButtonCommon Add_btn;
        private Com.Nidec.Mes.Framework.ButtonCommon Search_btn;
        internal Com.Nidec.Mes.Framework.DataGridViewCommon LineDetails_dgv;
        private Com.Nidec.Mes.Framework.ButtonCommon Exit_btn;
        private Com.Nidec.Mes.Framework.ButtonCommon Delete_btn;
        private Com.Nidec.Mes.Framework.ButtonCommon Update_btn;
        private Com.Nidec.Mes.Framework.ButtonCommon Clear_btn;
        private Framework.ButtonCommon Upload_btn;
        private Framework.ButtonCommon DownloadExcel_btn;
        private Framework.ButtonCommon Save_btn;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLineId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLineCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLineName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRemarks;
    }
}