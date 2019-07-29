namespace Com.Nidec.Mes.GlobalMasterMaintenance
{
    partial class InspectionTestInstructionForm : FormCommonMaster
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InspectionTestInstructionForm));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.InspectionItemId_cmb = new Com.Nidec.Mes.Framework.ComboBoxCommon();
            this.InspectionItemId_lbl = new Com.Nidec.Mes.Framework.LabelCommon();
            this.Clear_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.Exit_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.Delete_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.Update_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.InspectionTestInstruction_dgv = new Com.Nidec.Mes.Framework.DataGridViewCommon();
            this.colInspectionTestInstructionCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colInspectionTestInstructionText = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colInspectionItemName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colInspectionTestInstructionDetailCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colInspectionTestInstructionDetailText = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colInspectionTestInstructionDetailResultCount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colInspectionItemId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colInspectionTestInstructionId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colInspectionTestInstructionDetailId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Add_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.InspectionTestInstructionText_txt = new Com.Nidec.Mes.Framework.TextBoxCommon();
            this.InspectionTestInstructionText_lbl = new Com.Nidec.Mes.Framework.LabelCommon();
            this.InspectionTestInstructionCode_txt = new Com.Nidec.Mes.Framework.TextBoxCommon();
            this.InspectionTestInstructionCode_lbl = new Com.Nidec.Mes.Framework.LabelCommon();
            this.Detail_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.Search_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            ((System.ComponentModel.ISupportInitialize)(this.InspectionTestInstruction_dgv)).BeginInit();
            this.SuspendLayout();
            // 
            // InspectionItemId_cmb
            // 
            resources.ApplyResources(this.InspectionItemId_cmb, "InspectionItemId_cmb");
            this.InspectionItemId_cmb.ControlId = null;
            this.InspectionItemId_cmb.FormattingEnabled = true;
            this.InspectionItemId_cmb.Name = "InspectionItemId_cmb";
            // 
            // InspectionItemId_lbl
            // 
            resources.ApplyResources(this.InspectionItemId_lbl, "InspectionItemId_lbl");
            this.InspectionItemId_lbl.ControlId = null;
            this.InspectionItemId_lbl.Name = "InspectionItemId_lbl";
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
            // InspectionTestInstruction_dgv
            // 
            resources.ApplyResources(this.InspectionTestInstruction_dgv, "InspectionTestInstruction_dgv");
            this.InspectionTestInstruction_dgv.AllowUserToAddRows = false;
            this.InspectionTestInstruction_dgv.AllowUserToDeleteRows = false;
            this.InspectionTestInstruction_dgv.AllowUserToOrderColumns = true;
            this.InspectionTestInstruction_dgv.AllowUserToResizeRows = false;
            this.InspectionTestInstruction_dgv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(232)))), ((int)(((byte)(180)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.InspectionTestInstruction_dgv.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.InspectionTestInstruction_dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.InspectionTestInstruction_dgv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colInspectionTestInstructionCode,
            this.colInspectionTestInstructionText,
            this.colInspectionItemName,
            this.colInspectionTestInstructionDetailCode,
            this.colInspectionTestInstructionDetailText,
            this.colInspectionTestInstructionDetailResultCount,
            this.colInspectionItemId,
            this.colInspectionTestInstructionId,
            this.colInspectionTestInstructionDetailId});
            this.InspectionTestInstruction_dgv.ControlId = null;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.InspectionTestInstruction_dgv.DefaultCellStyle = dataGridViewCellStyle2;
            this.InspectionTestInstruction_dgv.EnableHeadersVisualStyles = false;
            this.InspectionTestInstruction_dgv.MultiSelect = false;
            this.InspectionTestInstruction_dgv.Name = "InspectionTestInstruction_dgv";
            this.InspectionTestInstruction_dgv.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(232)))), ((int)(((byte)(180)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.InspectionTestInstruction_dgv.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.InspectionTestInstruction_dgv.RowHeadersVisible = false;
            this.InspectionTestInstruction_dgv.RowTemplate.Height = 21;
            this.InspectionTestInstruction_dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.InspectionTestInstruction_dgv.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.InspectionTestInstruction_dgv_CellClick);
            this.InspectionTestInstruction_dgv.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.InspectionTestInstruction_dgv_CellDoubleClick);
            this.InspectionTestInstruction_dgv.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.InspectionTestInstruction_dgv_ColumnHeaderMouseClick);
            // 
            // colInspectionTestInstructionCode
            // 
            this.colInspectionTestInstructionCode.DataPropertyName = "InspectionTestInstructionCode";
            resources.ApplyResources(this.colInspectionTestInstructionCode, "colInspectionTestInstructionCode");
            this.colInspectionTestInstructionCode.Name = "colInspectionTestInstructionCode";
            this.colInspectionTestInstructionCode.ReadOnly = true;
            // 
            // colInspectionTestInstructionText
            // 
            this.colInspectionTestInstructionText.DataPropertyName = "InspectionTestInstructionText";
            resources.ApplyResources(this.colInspectionTestInstructionText, "colInspectionTestInstructionText");
            this.colInspectionTestInstructionText.Name = "colInspectionTestInstructionText";
            this.colInspectionTestInstructionText.ReadOnly = true;
            // 
            // colInspectionItemName
            // 
            this.colInspectionItemName.DataPropertyName = "InspectionItemName";
            resources.ApplyResources(this.colInspectionItemName, "colInspectionItemName");
            this.colInspectionItemName.Name = "colInspectionItemName";
            this.colInspectionItemName.ReadOnly = true;
            // 
            // colInspectionTestInstructionDetailCode
            // 
            this.colInspectionTestInstructionDetailCode.DataPropertyName = "InspectionTestInstructionDetailCode";
            resources.ApplyResources(this.colInspectionTestInstructionDetailCode, "colInspectionTestInstructionDetailCode");
            this.colInspectionTestInstructionDetailCode.Name = "colInspectionTestInstructionDetailCode";
            this.colInspectionTestInstructionDetailCode.ReadOnly = true;
            // 
            // colInspectionTestInstructionDetailText
            // 
            this.colInspectionTestInstructionDetailText.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colInspectionTestInstructionDetailText.DataPropertyName = "InspectionTestInstructionDetailText";
            resources.ApplyResources(this.colInspectionTestInstructionDetailText, "colInspectionTestInstructionDetailText");
            this.colInspectionTestInstructionDetailText.Name = "colInspectionTestInstructionDetailText";
            this.colInspectionTestInstructionDetailText.ReadOnly = true;
            // 
            // colInspectionTestInstructionDetailResultCount
            // 
            this.colInspectionTestInstructionDetailResultCount.DataPropertyName = "InspectionTestInstructionDetailResultCount";
            resources.ApplyResources(this.colInspectionTestInstructionDetailResultCount, "colInspectionTestInstructionDetailResultCount");
            this.colInspectionTestInstructionDetailResultCount.Name = "colInspectionTestInstructionDetailResultCount";
            this.colInspectionTestInstructionDetailResultCount.ReadOnly = true;
            // 
            // colInspectionItemId
            // 
            this.colInspectionItemId.DataPropertyName = "InspectionItemId";
            resources.ApplyResources(this.colInspectionItemId, "colInspectionItemId");
            this.colInspectionItemId.Name = "colInspectionItemId";
            this.colInspectionItemId.ReadOnly = true;
            // 
            // colInspectionTestInstructionId
            // 
            this.colInspectionTestInstructionId.DataPropertyName = "InspectionTestInstructionId";
            resources.ApplyResources(this.colInspectionTestInstructionId, "colInspectionTestInstructionId");
            this.colInspectionTestInstructionId.Name = "colInspectionTestInstructionId";
            this.colInspectionTestInstructionId.ReadOnly = true;
            // 
            // colInspectionTestInstructionDetailId
            // 
            this.colInspectionTestInstructionDetailId.DataPropertyName = "InspectionTestInstructionDetailId";
            resources.ApplyResources(this.colInspectionTestInstructionDetailId, "colInspectionTestInstructionDetailId");
            this.colInspectionTestInstructionDetailId.Name = "colInspectionTestInstructionDetailId";
            this.colInspectionTestInstructionDetailId.ReadOnly = true;
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
            // InspectionTestInstructionText_txt
            // 
            resources.ApplyResources(this.InspectionTestInstructionText_txt, "InspectionTestInstructionText_txt");
            this.InspectionTestInstructionText_txt.ControlId = null;
            this.InspectionTestInstructionText_txt.InputType = Com.Nidec.Mes.Framework.TextBoxCommon.InputTypeList.All;
            this.InspectionTestInstructionText_txt.Name = "InspectionTestInstructionText_txt";
            // 
            // InspectionTestInstructionText_lbl
            // 
            resources.ApplyResources(this.InspectionTestInstructionText_lbl, "InspectionTestInstructionText_lbl");
            this.InspectionTestInstructionText_lbl.ControlId = null;
            this.InspectionTestInstructionText_lbl.Name = "InspectionTestInstructionText_lbl";
            // 
            // InspectionTestInstructionCode_txt
            // 
            resources.ApplyResources(this.InspectionTestInstructionCode_txt, "InspectionTestInstructionCode_txt");
            this.InspectionTestInstructionCode_txt.ControlId = null;
            this.InspectionTestInstructionCode_txt.InputType = Com.Nidec.Mes.Framework.TextBoxCommon.InputTypeList.All;
            this.InspectionTestInstructionCode_txt.Name = "InspectionTestInstructionCode_txt";
            // 
            // InspectionTestInstructionCode_lbl
            // 
            resources.ApplyResources(this.InspectionTestInstructionCode_lbl, "InspectionTestInstructionCode_lbl");
            this.InspectionTestInstructionCode_lbl.ControlId = null;
            this.InspectionTestInstructionCode_lbl.Name = "InspectionTestInstructionCode_lbl";
            // 
            // Detail_btn
            // 
            resources.ApplyResources(this.Detail_btn, "Detail_btn");
            this.Detail_btn.BackColor = System.Drawing.SystemColors.Control;
            this.Detail_btn.ControlId = null;
            this.Detail_btn.Name = "Detail_btn";
            this.Detail_btn.UseVisualStyleBackColor = true;
            this.Detail_btn.Click += new System.EventHandler(this.Detail_btn_Click);
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
            // InspectionTestInstructionForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ControlId = "bpmf008";
            this.Controls.Add(this.Detail_btn);
            this.Controls.Add(this.InspectionItemId_cmb);
            this.Controls.Add(this.InspectionItemId_lbl);
            this.Controls.Add(this.Clear_btn);
            this.Controls.Add(this.Exit_btn);
            this.Controls.Add(this.Delete_btn);
            this.Controls.Add(this.Update_btn);
            this.Controls.Add(this.InspectionTestInstruction_dgv);
            this.Controls.Add(this.Add_btn);
            this.Controls.Add(this.Search_btn);
            this.Controls.Add(this.InspectionTestInstructionText_txt);
            this.Controls.Add(this.InspectionTestInstructionText_lbl);
            this.Controls.Add(this.InspectionTestInstructionCode_txt);
            this.Controls.Add(this.InspectionTestInstructionCode_lbl);
            this.Name = "InspectionTestInstructionForm";
            this.TitleText = "FormCommon";
            this.Load += new System.EventHandler(this.InspectionTestInstructionForm_Load);
            this.Controls.SetChildIndex(this.InspectionTestInstructionCode_lbl, 0);
            this.Controls.SetChildIndex(this.InspectionTestInstructionCode_txt, 0);
            this.Controls.SetChildIndex(this.InspectionTestInstructionText_lbl, 0);
            this.Controls.SetChildIndex(this.InspectionTestInstructionText_txt, 0);
            this.Controls.SetChildIndex(this.Search_btn, 0);
            this.Controls.SetChildIndex(this.Add_btn, 0);
            this.Controls.SetChildIndex(this.InspectionTestInstruction_dgv, 0);
            this.Controls.SetChildIndex(this.Update_btn, 0);
            this.Controls.SetChildIndex(this.Delete_btn, 0);
            this.Controls.SetChildIndex(this.Exit_btn, 0);
            this.Controls.SetChildIndex(this.Clear_btn, 0);
            this.Controls.SetChildIndex(this.InspectionItemId_lbl, 0);
            this.Controls.SetChildIndex(this.InspectionItemId_cmb, 0);
            this.Controls.SetChildIndex(this.Detail_btn, 0);
            ((System.ComponentModel.ISupportInitialize)(this.InspectionTestInstruction_dgv)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Com.Nidec.Mes.Framework.ButtonCommon Clear_btn;
        private Com.Nidec.Mes.Framework.ButtonCommon Exit_btn;
        private Com.Nidec.Mes.Framework.ButtonCommon Delete_btn;
        private Com.Nidec.Mes.Framework.ButtonCommon Update_btn;
        internal Com.Nidec.Mes.Framework.DataGridViewCommon InspectionTestInstruction_dgv;
        private Com.Nidec.Mes.Framework.ButtonCommon Add_btn;
        private Com.Nidec.Mes.Framework.TextBoxCommon InspectionTestInstructionText_txt;
        private Com.Nidec.Mes.Framework.LabelCommon InspectionTestInstructionText_lbl;
        private Com.Nidec.Mes.Framework.TextBoxCommon InspectionTestInstructionCode_txt;
        private Com.Nidec.Mes.Framework.LabelCommon InspectionTestInstructionCode_lbl;
        private Com.Nidec.Mes.Framework.ComboBoxCommon InspectionItemId_cmb;
        private Com.Nidec.Mes.Framework.LabelCommon InspectionItemId_lbl;
        private Framework.ButtonCommon Detail_btn;
        private System.Windows.Forms.DataGridViewTextBoxColumn colInspectionTestInstructionCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn colInspectionTestInstructionText;
        private System.Windows.Forms.DataGridViewTextBoxColumn colInspectionItemName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colInspectionTestInstructionDetailCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn colInspectionTestInstructionDetailText;
        private System.Windows.Forms.DataGridViewTextBoxColumn colInspectionTestInstructionDetailResultCount;
        private System.Windows.Forms.DataGridViewTextBoxColumn colInspectionItemId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colInspectionTestInstructionId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colInspectionTestInstructionDetailId;
        private Framework.ButtonCommon Search_btn;
    }
}