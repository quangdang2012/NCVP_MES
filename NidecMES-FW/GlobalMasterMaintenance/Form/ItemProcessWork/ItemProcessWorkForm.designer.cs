namespace Com.Nidec.Mes.GlobalMasterMaintenance
{
    partial class ItemProcessWorkForm:FormCommonMaster
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ItemProcessWorkForm));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            this.Clear_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.Exit_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.Update_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.Search_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.ItemProcessWork_dgv = new Com.Nidec.Mes.Framework.DataGridViewCommon();
            this.colItemProcessWorkId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colProcessWorkId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colProcessWorkName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colProcessworksequence = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colIsOptionalProcess = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colIsSkip = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colComment = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.colProcessFlowRuleId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colItemId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ItemCd_lbl = new Com.Nidec.Mes.Framework.LabelCommon();
            this.ItemCd_cmb = new Com.Nidec.Mes.Framework.ComboBoxCommon();
            this.Down_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.Up_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.RemoveProcessWork_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.AddProcessWork_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.ProcessWork_dgv = new Com.Nidec.Mes.Framework.DataGridViewCommon();
            this.colProcWorkId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colProcessWork = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.ItemProcessWork_dgv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ProcessWork_dgv)).BeginInit();
            this.SuspendLayout();
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
            // Update_btn
            // 
            resources.ApplyResources(this.Update_btn, "Update_btn");
            this.Update_btn.BackColor = System.Drawing.SystemColors.Control;
            this.Update_btn.ControlId = null;
            this.Update_btn.Name = "Update_btn";
            this.Update_btn.UseVisualStyleBackColor = true;
            this.Update_btn.Click += new System.EventHandler(this.Update_btn_Click);
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
            // ItemProcessWork_dgv
            // 
            this.ItemProcessWork_dgv.AllowUserToAddRows = false;
            this.ItemProcessWork_dgv.AllowUserToDeleteRows = false;
            this.ItemProcessWork_dgv.AllowUserToOrderColumns = true;
            this.ItemProcessWork_dgv.AllowUserToResizeRows = false;
            resources.ApplyResources(this.ItemProcessWork_dgv, "ItemProcessWork_dgv");
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(232)))), ((int)(((byte)(180)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.ItemProcessWork_dgv.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.ItemProcessWork_dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ItemProcessWork_dgv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colItemProcessWorkId,
            this.colProcessWorkId,
            this.colProcessWorkName,
            this.colProcessworksequence,
            this.colIsOptionalProcess,
            this.colIsSkip,
            this.colComment,
            this.colProcessFlowRuleId,
            this.colItemId});
            this.ItemProcessWork_dgv.ControlId = null;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.ItemProcessWork_dgv.DefaultCellStyle = dataGridViewCellStyle3;
            this.ItemProcessWork_dgv.EnableHeadersVisualStyles = false;
            this.ItemProcessWork_dgv.MultiSelect = false;
            this.ItemProcessWork_dgv.Name = "ItemProcessWork_dgv";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(232)))), ((int)(((byte)(180)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.ItemProcessWork_dgv.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.ItemProcessWork_dgv.RowHeadersVisible = false;
            this.ItemProcessWork_dgv.RowTemplate.Height = 21;
            this.ItemProcessWork_dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.ItemProcessWork_dgv.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.ItemProcessWork_dgv_CellClick);
            // 
            // colItemProcessWorkId
            // 
            this.colItemProcessWorkId.DataPropertyName = "ItemProcessWorkId";
            resources.ApplyResources(this.colItemProcessWorkId, "colItemProcessWorkId");
            this.colItemProcessWorkId.Name = "colItemProcessWorkId";
            // 
            // colProcessWorkId
            // 
            this.colProcessWorkId.DataPropertyName = "ProcessWorkId";
            resources.ApplyResources(this.colProcessWorkId, "colProcessWorkId");
            this.colProcessWorkId.Name = "colProcessWorkId";
            this.colProcessWorkId.ReadOnly = true;
            // 
            // colProcessWorkName
            // 
            this.colProcessWorkName.DataPropertyName = "ProcessWorkName";
            resources.ApplyResources(this.colProcessWorkName, "colProcessWorkName");
            this.colProcessWorkName.Name = "colProcessWorkName";
            this.colProcessWorkName.ReadOnly = true;
            // 
            // colProcessworksequence
            // 
            this.colProcessworksequence.DataPropertyName = "ProcessWorkSeq";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.colProcessworksequence.DefaultCellStyle = dataGridViewCellStyle2;
            resources.ApplyResources(this.colProcessworksequence, "colProcessworksequence");
            this.colProcessworksequence.Name = "colProcessworksequence";
            this.colProcessworksequence.ReadOnly = true;
            // 
            // colIsOptionalProcess
            // 
            this.colIsOptionalProcess.DataPropertyName = "OptionalProcessFlag";
            resources.ApplyResources(this.colIsOptionalProcess, "colIsOptionalProcess");
            this.colIsOptionalProcess.Name = "colIsOptionalProcess";
            this.colIsOptionalProcess.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colIsOptionalProcess.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // colIsSkip
            // 
            this.colIsSkip.DataPropertyName = "SkipPreventionFlag";
            resources.ApplyResources(this.colIsSkip, "colIsSkip");
            this.colIsSkip.Name = "colIsSkip";
            // 
            // colComment
            // 
            this.colComment.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colComment.DataPropertyName = "Comment";
            resources.ApplyResources(this.colComment, "colComment");
            this.colComment.Name = "colComment";
            this.colComment.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colComment.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // colProcessFlowRuleId
            // 
            this.colProcessFlowRuleId.DataPropertyName = "ProcessFlowRuleId";
            resources.ApplyResources(this.colProcessFlowRuleId, "colProcessFlowRuleId");
            this.colProcessFlowRuleId.Name = "colProcessFlowRuleId";
            // 
            // colItemId
            // 
            this.colItemId.DataPropertyName = "ItemId";
            resources.ApplyResources(this.colItemId, "colItemId");
            this.colItemId.Name = "colItemId";
            // 
            // ItemCd_lbl
            // 
            resources.ApplyResources(this.ItemCd_lbl, "ItemCd_lbl");
            this.ItemCd_lbl.ControlId = null;
            this.ItemCd_lbl.Name = "ItemCd_lbl";
            // 
            // ItemCd_cmb
            // 
            this.ItemCd_cmb.ControlId = null;
            resources.ApplyResources(this.ItemCd_cmb, "ItemCd_cmb");
            this.ItemCd_cmb.FormattingEnabled = true;
            this.ItemCd_cmb.Name = "ItemCd_cmb";
            // 
            // Down_btn
            // 
            resources.ApplyResources(this.Down_btn, "Down_btn");
            this.Down_btn.BackColor = System.Drawing.SystemColors.Control;
            this.Down_btn.ControlId = null;
            this.Down_btn.Name = "Down_btn";
            this.Down_btn.UseVisualStyleBackColor = true;
            this.Down_btn.Click += new System.EventHandler(this.Down_btn_Click);
            // 
            // Up_btn
            // 
            resources.ApplyResources(this.Up_btn, "Up_btn");
            this.Up_btn.BackColor = System.Drawing.SystemColors.Control;
            this.Up_btn.ControlId = null;
            this.Up_btn.Name = "Up_btn";
            this.Up_btn.UseVisualStyleBackColor = true;
            this.Up_btn.Click += new System.EventHandler(this.Up_btn_Click);
            // 
            // RemoveProcessWork_btn
            // 
            this.RemoveProcessWork_btn.BackColor = System.Drawing.SystemColors.Control;
            this.RemoveProcessWork_btn.ControlId = null;
            resources.ApplyResources(this.RemoveProcessWork_btn, "RemoveProcessWork_btn");
            this.RemoveProcessWork_btn.Name = "RemoveProcessWork_btn";
            this.RemoveProcessWork_btn.UseVisualStyleBackColor = true;
            this.RemoveProcessWork_btn.Click += new System.EventHandler(this.RemoveProcessWork_btn_Click);
            // 
            // AddProcessWork_btn
            // 
            this.AddProcessWork_btn.BackColor = System.Drawing.SystemColors.Control;
            this.AddProcessWork_btn.ControlId = null;
            resources.ApplyResources(this.AddProcessWork_btn, "AddProcessWork_btn");
            this.AddProcessWork_btn.Name = "AddProcessWork_btn";
            this.AddProcessWork_btn.UseVisualStyleBackColor = true;
            this.AddProcessWork_btn.Click += new System.EventHandler(this.AddProcessWork_btn_Click);
            // 
            // ProcessWork_dgv
            // 
            this.ProcessWork_dgv.AllowUserToAddRows = false;
            this.ProcessWork_dgv.AllowUserToDeleteRows = false;
            this.ProcessWork_dgv.AllowUserToOrderColumns = true;
            this.ProcessWork_dgv.AllowUserToResizeRows = false;
            resources.ApplyResources(this.ProcessWork_dgv, "ProcessWork_dgv");
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(232)))), ((int)(((byte)(180)))));
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.ProcessWork_dgv.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.ProcessWork_dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ProcessWork_dgv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colProcWorkId,
            this.colProcessWork});
            this.ProcessWork_dgv.ControlId = null;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.ProcessWork_dgv.DefaultCellStyle = dataGridViewCellStyle6;
            this.ProcessWork_dgv.EnableHeadersVisualStyles = false;
            this.ProcessWork_dgv.MultiSelect = false;
            this.ProcessWork_dgv.Name = "ProcessWork_dgv";
            this.ProcessWork_dgv.ReadOnly = true;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(232)))), ((int)(((byte)(180)))));
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.ProcessWork_dgv.RowHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.ProcessWork_dgv.RowHeadersVisible = false;
            this.ProcessWork_dgv.RowTemplate.Height = 21;
            this.ProcessWork_dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            // 
            // colProcWorkId
            // 
            this.colProcWorkId.DataPropertyName = "ProcessWorkId";
            resources.ApplyResources(this.colProcWorkId, "colProcWorkId");
            this.colProcWorkId.Name = "colProcWorkId";
            this.colProcWorkId.ReadOnly = true;
            // 
            // colProcessWork
            // 
            this.colProcessWork.DataPropertyName = "ProcessWorkName";
            resources.ApplyResources(this.colProcessWork, "colProcessWork");
            this.colProcessWork.Name = "colProcessWork";
            this.colProcessWork.ReadOnly = true;
            // 
            // ItemProcessWorkForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ControlId = "bpmf015";
            this.Controls.Add(this.ProcessWork_dgv);
            this.Controls.Add(this.RemoveProcessWork_btn);
            this.Controls.Add(this.AddProcessWork_btn);
            this.Controls.Add(this.Down_btn);
            this.Controls.Add(this.Up_btn);
            this.Controls.Add(this.ItemCd_lbl);
            this.Controls.Add(this.ItemCd_cmb);
            this.Controls.Add(this.Clear_btn);
            this.Controls.Add(this.Exit_btn);
            this.Controls.Add(this.Update_btn);
            this.Controls.Add(this.Search_btn);
            this.Controls.Add(this.ItemProcessWork_dgv);
            this.Name = "ItemProcessWorkForm";
            this.TitleText = "FormCommon";
            this.Load += new System.EventHandler(this.ItemProcessWorkForm_Load);
            this.Controls.SetChildIndex(this.ItemProcessWork_dgv, 0);
            this.Controls.SetChildIndex(this.Search_btn, 0);
            this.Controls.SetChildIndex(this.Update_btn, 0);
            this.Controls.SetChildIndex(this.Exit_btn, 0);
            this.Controls.SetChildIndex(this.Clear_btn, 0);
            this.Controls.SetChildIndex(this.ItemCd_cmb, 0);
            this.Controls.SetChildIndex(this.ItemCd_lbl, 0);
            this.Controls.SetChildIndex(this.Up_btn, 0);
            this.Controls.SetChildIndex(this.Down_btn, 0);
            this.Controls.SetChildIndex(this.AddProcessWork_btn, 0);
            this.Controls.SetChildIndex(this.RemoveProcessWork_btn, 0);
            this.Controls.SetChildIndex(this.ProcessWork_dgv, 0);
            ((System.ComponentModel.ISupportInitialize)(this.ItemProcessWork_dgv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ProcessWork_dgv)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Com.Nidec.Mes.Framework.ButtonCommon Clear_btn;
        private Com.Nidec.Mes.Framework.ButtonCommon Exit_btn;
        private Com.Nidec.Mes.Framework.ButtonCommon Update_btn;
        private Com.Nidec.Mes.Framework.ButtonCommon Search_btn;
        internal Com.Nidec.Mes.Framework.DataGridViewCommon ItemProcessWork_dgv;
        private Com.Nidec.Mes.Framework.LabelCommon ItemCd_lbl;
        private Com.Nidec.Mes.Framework.ComboBoxCommon ItemCd_cmb;
        private Framework.ButtonCommon Down_btn;
        private Framework.ButtonCommon Up_btn;
        private Framework.ButtonCommon RemoveProcessWork_btn;
        private Framework.ButtonCommon AddProcessWork_btn;
        internal Framework.DataGridViewCommon ProcessWork_dgv;
        private System.Windows.Forms.DataGridViewTextBoxColumn colProcWorkId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colProcessWork;
        private System.Windows.Forms.DataGridViewTextBoxColumn colItemProcessWorkId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colProcessWorkId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colProcessWorkName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colProcessworksequence;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colIsOptionalProcess;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colIsSkip;
        private System.Windows.Forms.DataGridViewComboBoxColumn colComment;
        private System.Windows.Forms.DataGridViewTextBoxColumn colProcessFlowRuleId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colItemId;
    }
}