namespace Com.Nidec.Mes.GlobalMasterMaintenance
{
    partial class InspectionTestInstructionDetailForm : FormCommonMaster
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InspectionTestInstructionDetailForm));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.Exit_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.Delete_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.Update_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.InspectionTestInstructionDetail_dgv = new Com.Nidec.Mes.Framework.DataGridViewCommon();
            this.colInspectionTestInstructionDetailCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colInspectionTestInstructionDetailText = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colInspectionTestInstructionDetailResultCount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colInspectiontestinstructiondetailmachine = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colInspectionTestInstructionText = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colInspectionTestInstructionId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colInspectionTestInstructionDetailId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Add_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.InspectionTestInstructionDetail_txt = new Com.Nidec.Mes.Framework.TextBoxCommon();
            this.InspectionTestInstructionDetailText_lbl = new Com.Nidec.Mes.Framework.LabelCommon();
            this.InspectionTestInstructionCode_txt = new Com.Nidec.Mes.Framework.TextBoxCommon();
            this.InspectionTestInstructionDetailCode_lbl = new Com.Nidec.Mes.Framework.LabelCommon();
            ((System.ComponentModel.ISupportInitialize)(this.InspectionTestInstructionDetail_dgv)).BeginInit();
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
            // InspectionTestInstructionDetail_dgv
            // 
            resources.ApplyResources(this.InspectionTestInstructionDetail_dgv, "InspectionTestInstructionDetail_dgv");
            this.InspectionTestInstructionDetail_dgv.AllowUserToAddRows = false;
            this.InspectionTestInstructionDetail_dgv.AllowUserToDeleteRows = false;
            this.InspectionTestInstructionDetail_dgv.AllowUserToOrderColumns = true;
            this.InspectionTestInstructionDetail_dgv.AllowUserToResizeRows = false;
            this.InspectionTestInstructionDetail_dgv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(232)))), ((int)(((byte)(180)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.InspectionTestInstructionDetail_dgv.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.InspectionTestInstructionDetail_dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.InspectionTestInstructionDetail_dgv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colInspectionTestInstructionDetailCode,
            this.colInspectionTestInstructionDetailText,
            this.colInspectionTestInstructionDetailResultCount,
            this.colInspectiontestinstructiondetailmachine,
            this.colInspectionTestInstructionText,
            this.colInspectionTestInstructionId,
            this.colInspectionTestInstructionDetailId});
            this.InspectionTestInstructionDetail_dgv.ControlId = null;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.InspectionTestInstructionDetail_dgv.DefaultCellStyle = dataGridViewCellStyle2;
            this.InspectionTestInstructionDetail_dgv.EnableHeadersVisualStyles = false;
            this.InspectionTestInstructionDetail_dgv.MultiSelect = false;
            this.InspectionTestInstructionDetail_dgv.Name = "InspectionTestInstructionDetail_dgv";
            this.InspectionTestInstructionDetail_dgv.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(232)))), ((int)(((byte)(180)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.InspectionTestInstructionDetail_dgv.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.InspectionTestInstructionDetail_dgv.RowHeadersVisible = false;
            this.InspectionTestInstructionDetail_dgv.RowTemplate.Height = 21;
            this.InspectionTestInstructionDetail_dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.InspectionTestInstructionDetail_dgv.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.InspectionTestInstructionDetail_dgv_CellClick);
            this.InspectionTestInstructionDetail_dgv.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.InspectionTestInstructionDetail_dgv_CellDoubleClick);
            this.InspectionTestInstructionDetail_dgv.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.InspectionTestInstructionDetail_dgv_ColumnHeaderMouseClick);
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
            // colInspectiontestinstructiondetailmachine
            // 
            this.colInspectiontestinstructiondetailmachine.DataPropertyName = "InspectionTestInstructionDetailMachine";
            resources.ApplyResources(this.colInspectiontestinstructiondetailmachine, "colInspectiontestinstructiondetailmachine");
            this.colInspectiontestinstructiondetailmachine.Name = "colInspectiontestinstructiondetailmachine";
            this.colInspectiontestinstructiondetailmachine.ReadOnly = true;
            // 
            // colInspectionTestInstructionText
            // 
            this.colInspectionTestInstructionText.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colInspectionTestInstructionText.DataPropertyName = "InspectionTestInstructionText";
            resources.ApplyResources(this.colInspectionTestInstructionText, "colInspectionTestInstructionText");
            this.colInspectionTestInstructionText.Name = "colInspectionTestInstructionText";
            this.colInspectionTestInstructionText.ReadOnly = true;
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
            // InspectionTestInstructionDetail_txt
            // 
            resources.ApplyResources(this.InspectionTestInstructionDetail_txt, "InspectionTestInstructionDetail_txt");
            this.InspectionTestInstructionDetail_txt.ControlId = null;
            this.InspectionTestInstructionDetail_txt.InputType = Com.Nidec.Mes.Framework.TextBoxCommon.InputTypeList.All;
            this.InspectionTestInstructionDetail_txt.Name = "InspectionTestInstructionDetail_txt";
            this.InspectionTestInstructionDetail_txt.ReadOnly = true;
            // 
            // InspectionTestInstructionDetailText_lbl
            // 
            resources.ApplyResources(this.InspectionTestInstructionDetailText_lbl, "InspectionTestInstructionDetailText_lbl");
            this.InspectionTestInstructionDetailText_lbl.ControlId = null;
            this.InspectionTestInstructionDetailText_lbl.Name = "InspectionTestInstructionDetailText_lbl";
            // 
            // InspectionTestInstructionCode_txt
            // 
            resources.ApplyResources(this.InspectionTestInstructionCode_txt, "InspectionTestInstructionCode_txt");
            this.InspectionTestInstructionCode_txt.ControlId = null;
            this.InspectionTestInstructionCode_txt.InputType = Com.Nidec.Mes.Framework.TextBoxCommon.InputTypeList.All;
            this.InspectionTestInstructionCode_txt.Name = "InspectionTestInstructionCode_txt";
            this.InspectionTestInstructionCode_txt.ReadOnly = true;
            // 
            // InspectionTestInstructionDetailCode_lbl
            // 
            resources.ApplyResources(this.InspectionTestInstructionDetailCode_lbl, "InspectionTestInstructionDetailCode_lbl");
            this.InspectionTestInstructionDetailCode_lbl.ControlId = null;
            this.InspectionTestInstructionDetailCode_lbl.Name = "InspectionTestInstructionDetailCode_lbl";
            // 
            // InspectionTestInstructionDetailForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ControlId = "bpmf008";
            this.Controls.Add(this.Exit_btn);
            this.Controls.Add(this.Delete_btn);
            this.Controls.Add(this.Update_btn);
            this.Controls.Add(this.InspectionTestInstructionDetail_dgv);
            this.Controls.Add(this.Add_btn);
            this.Controls.Add(this.InspectionTestInstructionDetail_txt);
            this.Controls.Add(this.InspectionTestInstructionDetailText_lbl);
            this.Controls.Add(this.InspectionTestInstructionCode_txt);
            this.Controls.Add(this.InspectionTestInstructionDetailCode_lbl);
            this.Name = "InspectionTestInstructionDetailForm";
            this.TitleText = "FormCommon";
            this.Load += new System.EventHandler(this.InspectionTestInstructionDetailForm_Load);
            this.Controls.SetChildIndex(this.InspectionTestInstructionDetailCode_lbl, 0);
            this.Controls.SetChildIndex(this.InspectionTestInstructionCode_txt, 0);
            this.Controls.SetChildIndex(this.InspectionTestInstructionDetailText_lbl, 0);
            this.Controls.SetChildIndex(this.InspectionTestInstructionDetail_txt, 0);
            this.Controls.SetChildIndex(this.Add_btn, 0);
            this.Controls.SetChildIndex(this.InspectionTestInstructionDetail_dgv, 0);
            this.Controls.SetChildIndex(this.Update_btn, 0);
            this.Controls.SetChildIndex(this.Delete_btn, 0);
            this.Controls.SetChildIndex(this.Exit_btn, 0);
            ((System.ComponentModel.ISupportInitialize)(this.InspectionTestInstructionDetail_dgv)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Com.Nidec.Mes.Framework.ButtonCommon Exit_btn;
        private Com.Nidec.Mes.Framework.ButtonCommon Delete_btn;
        private Com.Nidec.Mes.Framework.ButtonCommon Update_btn;
        internal Com.Nidec.Mes.Framework.DataGridViewCommon InspectionTestInstructionDetail_dgv;
        private Com.Nidec.Mes.Framework.ButtonCommon Add_btn;
        private Com.Nidec.Mes.Framework.TextBoxCommon InspectionTestInstructionDetail_txt;
        private Com.Nidec.Mes.Framework.LabelCommon InspectionTestInstructionDetailText_lbl;
        private Com.Nidec.Mes.Framework.TextBoxCommon InspectionTestInstructionCode_txt;
        private Com.Nidec.Mes.Framework.LabelCommon InspectionTestInstructionDetailCode_lbl;
        private System.Windows.Forms.DataGridViewTextBoxColumn colInspectionTestInstructionDetailCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn colInspectionTestInstructionDetailText;
        private System.Windows.Forms.DataGridViewTextBoxColumn colInspectionTestInstructionDetailResultCount;
        private System.Windows.Forms.DataGridViewTextBoxColumn colInspectiontestinstructiondetailmachine;
        private System.Windows.Forms.DataGridViewTextBoxColumn colInspectionTestInstructionText;
        private System.Windows.Forms.DataGridViewTextBoxColumn colInspectionTestInstructionId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colInspectionTestInstructionDetailId;
    }
}