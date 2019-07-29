namespace Com.Nidec.Mes.GlobalMasterMaintenance
{
    partial class ProcessFlowRuleForm : FormCommonMaster
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProcessFlowRuleForm));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.Clear_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.Exit_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.Delete_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.Update_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.Add_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.Search_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.ProcessFlowRule_dgv = new Com.Nidec.Mes.Framework.DataGridViewCommon();
            this.colProcessFlowRuleId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colProcessFlowRuleCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colComment = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProcessFlowRuleCode_txt = new Com.Nidec.Mes.Framework.TextBoxCommon();
            this.Comment_lbl = new Com.Nidec.Mes.Framework.LabelCommon();
            this.Comment_txt = new Com.Nidec.Mes.Framework.TextBoxCommon();
            this.ProcessFlowRuleCode_lbl = new Com.Nidec.Mes.Framework.LabelCommon();
            ((System.ComponentModel.ISupportInitialize)(this.ProcessFlowRule_dgv)).BeginInit();
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
            // ProcessFlowRule_dgv
            // 
            this.ProcessFlowRule_dgv.AllowUserToAddRows = false;
            this.ProcessFlowRule_dgv.AllowUserToDeleteRows = false;
            this.ProcessFlowRule_dgv.AllowUserToOrderColumns = true;
            this.ProcessFlowRule_dgv.AllowUserToResizeRows = false;
            resources.ApplyResources(this.ProcessFlowRule_dgv, "ProcessFlowRule_dgv");
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(232)))), ((int)(((byte)(180)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.ProcessFlowRule_dgv.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.ProcessFlowRule_dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ProcessFlowRule_dgv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colProcessFlowRuleId,
            this.colProcessFlowRuleCode,
            this.colComment});
            this.ProcessFlowRule_dgv.ControlId = null;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.ProcessFlowRule_dgv.DefaultCellStyle = dataGridViewCellStyle2;
            this.ProcessFlowRule_dgv.EnableHeadersVisualStyles = false;
            this.ProcessFlowRule_dgv.MultiSelect = false;
            this.ProcessFlowRule_dgv.Name = "ProcessFlowRule_dgv";
            this.ProcessFlowRule_dgv.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(232)))), ((int)(((byte)(180)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.ProcessFlowRule_dgv.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.ProcessFlowRule_dgv.RowHeadersVisible = false;
            this.ProcessFlowRule_dgv.RowTemplate.Height = 21;
            this.ProcessFlowRule_dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.ProcessFlowRule_dgv.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.ProcessFlowRule_dgv_CellClick);
            this.ProcessFlowRule_dgv.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.ProcessFlowRule_dgv_CellDoubleClick);
            // 
            // colProcessFlowRuleId
            // 
            this.colProcessFlowRuleId.DataPropertyName = "ProcessFlowRuleId";
            resources.ApplyResources(this.colProcessFlowRuleId, "colProcessFlowRuleId");
            this.colProcessFlowRuleId.Name = "colProcessFlowRuleId";
            this.colProcessFlowRuleId.ReadOnly = true;
            // 
            // colProcessFlowRuleCode
            // 
            this.colProcessFlowRuleCode.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colProcessFlowRuleCode.DataPropertyName = "ProcessFlowRuleCode";
            resources.ApplyResources(this.colProcessFlowRuleCode, "colProcessFlowRuleCode");
            this.colProcessFlowRuleCode.Name = "colProcessFlowRuleCode";
            this.colProcessFlowRuleCode.ReadOnly = true;
            // 
            // colComment
            // 
            this.colComment.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colComment.DataPropertyName = "Comment";
            resources.ApplyResources(this.colComment, "colComment");
            this.colComment.Name = "colComment";
            this.colComment.ReadOnly = true;
            // 
            // ProcessFlowRuleCode_txt
            // 
            this.ProcessFlowRuleCode_txt.ControlId = null;
            resources.ApplyResources(this.ProcessFlowRuleCode_txt, "ProcessFlowRuleCode_txt");
            this.ProcessFlowRuleCode_txt.InputType = Com.Nidec.Mes.Framework.TextBoxCommon.InputTypeList.All;
            this.ProcessFlowRuleCode_txt.Name = "ProcessFlowRuleCode_txt";
            // 
            // Comment_lbl
            // 
            resources.ApplyResources(this.Comment_lbl, "Comment_lbl");
            this.Comment_lbl.ControlId = null;
            this.Comment_lbl.Name = "Comment_lbl";
            // 
            // Comment_txt
            // 
            this.Comment_txt.ControlId = null;
            resources.ApplyResources(this.Comment_txt, "Comment_txt");
            this.Comment_txt.InputType = Com.Nidec.Mes.Framework.TextBoxCommon.InputTypeList.All;
            this.Comment_txt.Name = "Comment_txt";
            // 
            // ProcessFlowRuleCode_lbl
            // 
            resources.ApplyResources(this.ProcessFlowRuleCode_lbl, "ProcessFlowRuleCode_lbl");
            this.ProcessFlowRuleCode_lbl.ControlId = null;
            this.ProcessFlowRuleCode_lbl.Name = "ProcessFlowRuleCode_lbl";
            // 
            // ProcessFlowRuleForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ControlId = "bpmf014";
            this.Controls.Add(this.ProcessFlowRuleCode_txt);
            this.Controls.Add(this.Comment_lbl);
            this.Controls.Add(this.Comment_txt);
            this.Controls.Add(this.ProcessFlowRuleCode_lbl);
            this.Controls.Add(this.Clear_btn);
            this.Controls.Add(this.Exit_btn);
            this.Controls.Add(this.Delete_btn);
            this.Controls.Add(this.Update_btn);
            this.Controls.Add(this.Add_btn);
            this.Controls.Add(this.Search_btn);
            this.Controls.Add(this.ProcessFlowRule_dgv);
            this.Name = "ProcessFlowRuleForm";
            this.TitleText = "FormCommon";
            this.Load += new System.EventHandler(this.ProcessFlowRuleForm_Load);
            this.Controls.SetChildIndex(this.ProcessFlowRule_dgv, 0);
            this.Controls.SetChildIndex(this.Search_btn, 0);
            this.Controls.SetChildIndex(this.Add_btn, 0);
            this.Controls.SetChildIndex(this.Update_btn, 0);
            this.Controls.SetChildIndex(this.Delete_btn, 0);
            this.Controls.SetChildIndex(this.Exit_btn, 0);
            this.Controls.SetChildIndex(this.Clear_btn, 0);
            this.Controls.SetChildIndex(this.ProcessFlowRuleCode_lbl, 0);
            this.Controls.SetChildIndex(this.Comment_txt, 0);
            this.Controls.SetChildIndex(this.Comment_lbl, 0);
            this.Controls.SetChildIndex(this.ProcessFlowRuleCode_txt, 0);
            ((System.ComponentModel.ISupportInitialize)(this.ProcessFlowRule_dgv)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Com.Nidec.Mes.Framework.ButtonCommon Clear_btn;
        private Com.Nidec.Mes.Framework.ButtonCommon Exit_btn;
        private Com.Nidec.Mes.Framework.ButtonCommon Delete_btn;
        private Com.Nidec.Mes.Framework.ButtonCommon Update_btn;
        private Com.Nidec.Mes.Framework.ButtonCommon Add_btn;
        private Com.Nidec.Mes.Framework.ButtonCommon Search_btn;
        internal Com.Nidec.Mes.Framework.DataGridViewCommon ProcessFlowRule_dgv;
        private Com.Nidec.Mes.Framework.TextBoxCommon ProcessFlowRuleCode_txt;
        private Com.Nidec.Mes.Framework.LabelCommon Comment_lbl;
        private Com.Nidec.Mes.Framework.TextBoxCommon Comment_txt;
        private Com.Nidec.Mes.Framework.LabelCommon ProcessFlowRuleCode_lbl;
        private System.Windows.Forms.DataGridViewTextBoxColumn colProcessFlowRuleId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colProcessFlowRuleCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn colComment;
    }
}