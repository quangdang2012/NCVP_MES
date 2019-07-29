namespace Com.Nidec.Mes.GlobalMasterMaintenance
{
    partial class LineRestTimeMasterForm : FormCommonMaster
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LineRestTimeMasterForm));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.Exit_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.Ok_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.LineRestTime_dgv = new Com.Nidec.Mes.Framework.DataGridViewCommon();
            this.colLineId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLineRestTimeId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colShift = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colShiftText = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPlanRestMinutes = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LineId_lbl = new Com.Nidec.Mes.Framework.LabelCommon();
            this.Line_cmb = new Com.Nidec.Mes.Framework.ComboBoxCommon();
            this.Search_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.Clear_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            ((System.ComponentModel.ISupportInitialize)(this.LineRestTime_dgv)).BeginInit();
            this.SuspendLayout();
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
            // Ok_btn
            // 
            resources.ApplyResources(this.Ok_btn, "Ok_btn");
            this.Ok_btn.BackColor = System.Drawing.SystemColors.Control;
            this.Ok_btn.ControlId = null;
            this.Ok_btn.Name = "Ok_btn";
            this.Ok_btn.UseVisualStyleBackColor = true;
            this.Ok_btn.Click += new System.EventHandler(this.Ok_btn_Click);
            // 
            // LineRestTime_dgv
            // 
            resources.ApplyResources(this.LineRestTime_dgv, "LineRestTime_dgv");
            this.LineRestTime_dgv.AllowUserToAddRows = false;
            this.LineRestTime_dgv.AllowUserToDeleteRows = false;
            this.LineRestTime_dgv.AllowUserToOrderColumns = true;
            this.LineRestTime_dgv.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(232)))), ((int)(((byte)(180)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.LineRestTime_dgv.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.LineRestTime_dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.LineRestTime_dgv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colLineId,
            this.colLineRestTimeId,
            this.colShift,
            this.colShiftText,
            this.colPlanRestMinutes});
            this.LineRestTime_dgv.ControlId = null;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.LineRestTime_dgv.DefaultCellStyle = dataGridViewCellStyle4;
            this.LineRestTime_dgv.EnableHeadersVisualStyles = false;
            this.LineRestTime_dgv.MultiSelect = false;
            this.LineRestTime_dgv.Name = "LineRestTime_dgv";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(232)))), ((int)(((byte)(180)))));
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.LineRestTime_dgv.RowHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.LineRestTime_dgv.RowHeadersVisible = false;
            this.LineRestTime_dgv.RowTemplate.Height = 21;
            this.LineRestTime_dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.LineRestTime_dgv.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.LineItem_dgv_CellClick);
            this.LineRestTime_dgv.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.LineItem_dgv_CellValidating);
            this.LineRestTime_dgv.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.LineItem_dgv_EditingControlShowing);
            // 
            // colLineId
            // 
            this.colLineId.DataPropertyName = "LineId";
            resources.ApplyResources(this.colLineId, "colLineId");
            this.colLineId.Name = "colLineId";
            // 
            // colLineRestTimeId
            // 
            this.colLineRestTimeId.DataPropertyName = "LineRestTimeId";
            resources.ApplyResources(this.colLineRestTimeId, "colLineRestTimeId");
            this.colLineRestTimeId.Name = "colLineRestTimeId";
            // 
            // colShift
            // 
            this.colShift.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colShift.DataPropertyName = "Shift";
            resources.ApplyResources(this.colShift, "colShift");
            this.colShift.Name = "colShift";
            this.colShift.ReadOnly = true;
            // 
            // colShiftText
            // 
            this.colShiftText.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colShiftText.DataPropertyName = "ShiftText";
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.colShiftText.DefaultCellStyle = dataGridViewCellStyle2;
            resources.ApplyResources(this.colShiftText, "colShiftText");
            this.colShiftText.Name = "colShiftText";
            this.colShiftText.ReadOnly = true;
            // 
            // colPlanRestMinutes
            // 
            this.colPlanRestMinutes.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colPlanRestMinutes.DataPropertyName = "PlanRestMinutes";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.colPlanRestMinutes.DefaultCellStyle = dataGridViewCellStyle3;
            resources.ApplyResources(this.colPlanRestMinutes, "colPlanRestMinutes");
            this.colPlanRestMinutes.MaxInputLength = 3;
            this.colPlanRestMinutes.Name = "colPlanRestMinutes";
            // 
            // LineId_lbl
            // 
            resources.ApplyResources(this.LineId_lbl, "LineId_lbl");
            this.LineId_lbl.ControlId = null;
            this.LineId_lbl.Name = "LineId_lbl";
            // 
            // Line_cmb
            // 
            resources.ApplyResources(this.Line_cmb, "Line_cmb");
            this.Line_cmb.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.Line_cmb.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.Line_cmb.ControlId = null;
            this.Line_cmb.FormattingEnabled = true;
            this.Line_cmb.Name = "Line_cmb";
            this.Line_cmb.SelectionChangeCommitted += new System.EventHandler(this.Line_cmb_SelectionChangeCommitted);
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
            // Clear_btn
            // 
            resources.ApplyResources(this.Clear_btn, "Clear_btn");
            this.Clear_btn.BackColor = System.Drawing.SystemColors.Control;
            this.Clear_btn.ControlId = null;
            this.Clear_btn.Name = "Clear_btn";
            this.Clear_btn.UseVisualStyleBackColor = true;
            this.Clear_btn.Click += new System.EventHandler(this.Clear_btn_Click);
            // 
            // LineRestTimeMasterForm
            // 
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.Clear_btn);
            this.Controls.Add(this.Search_btn);
            this.Controls.Add(this.Line_cmb);
            this.Controls.Add(this.LineId_lbl);
            this.Controls.Add(this.LineRestTime_dgv);
            this.Controls.Add(this.Exit_btn);
            this.Controls.Add(this.Ok_btn);
            this.Name = "LineRestTimeMasterForm";
            this.TitleText = "Line Rest Time";
            this.Load += new System.EventHandler(this.LineRestTimeMasterForm_Load);
            this.Controls.SetChildIndex(this.Ok_btn, 0);
            this.Controls.SetChildIndex(this.Exit_btn, 0);
            this.Controls.SetChildIndex(this.LineRestTime_dgv, 0);
            this.Controls.SetChildIndex(this.LineId_lbl, 0);
            this.Controls.SetChildIndex(this.Line_cmb, 0);
            this.Controls.SetChildIndex(this.Search_btn, 0);
            this.Controls.SetChildIndex(this.Clear_btn, 0);
            ((System.ComponentModel.ISupportInitialize)(this.LineRestTime_dgv)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private Framework.ButtonCommon Exit_btn;
        private Framework.ButtonCommon Ok_btn;
        internal Framework.DataGridViewCommon LineRestTime_dgv;
        private Framework.LabelCommon LineId_lbl;
        private Framework.ComboBoxCommon Line_cmb;
        private Framework.ButtonCommon Search_btn;
        private Framework.ButtonCommon Clear_btn;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLineId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLineRestTimeId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colShift;
        private System.Windows.Forms.DataGridViewTextBoxColumn colShiftText;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPlanRestMinutes;
    }
}
