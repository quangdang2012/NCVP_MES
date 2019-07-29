namespace Com.Nidec.Mes.GlobalMasterMaintenance
{
    partial class InspectionItemForm : FormCommonMaster
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InspectionItemForm));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.Clear_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.Exit_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.Delete_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.Update_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.Add_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.Search_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.InspectionItem_dgv = new Com.Nidec.Mes.Framework.DataGridViewCommon();
            this.colInspectionItemCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColInspectionItemId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColParentInspectionItemId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colInspectionProcessId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colInspectionItemName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colParentItemCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colInspectionProcess = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ParentItemCode_lbl = new Com.Nidec.Mes.Framework.LabelCommon();
            this.InspectionItemName_lbl = new Com.Nidec.Mes.Framework.LabelCommon();
            this.InspectionItemName_txt = new Com.Nidec.Mes.Framework.TextBoxCommon();
            this.ParentItemCode_cmb = new Com.Nidec.Mes.Framework.ComboBoxCommon();
            this.InspectionItemCode_txt = new Com.Nidec.Mes.Framework.TextBoxCommon();
            this.InspectionItemCode_lbl = new Com.Nidec.Mes.Framework.LabelCommon();
            this.InspectionProcess_lbl = new Com.Nidec.Mes.Framework.LabelCommon();
            this.InspectionProcess_cmb = new Com.Nidec.Mes.Framework.ComboBoxCommon();
            this.InspectionTestInstruction_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.InspectionSpecification_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            ((System.ComponentModel.ISupportInitialize)(this.InspectionItem_dgv)).BeginInit();
            this.SuspendLayout();
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
            // InspectionItem_dgv
            // 
            resources.ApplyResources(this.InspectionItem_dgv, "InspectionItem_dgv");
            this.InspectionItem_dgv.AllowUserToAddRows = false;
            this.InspectionItem_dgv.AllowUserToDeleteRows = false;
            this.InspectionItem_dgv.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(232)))), ((int)(((byte)(180)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.InspectionItem_dgv.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.InspectionItem_dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.InspectionItem_dgv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colInspectionItemCode,
            this.ColInspectionItemId,
            this.ColParentInspectionItemId,
            this.colInspectionProcessId,
            this.colInspectionItemName,
            this.colParentItemCode,
            this.colInspectionProcess});
            this.InspectionItem_dgv.ControlId = null;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.InspectionItem_dgv.DefaultCellStyle = dataGridViewCellStyle2;
            this.InspectionItem_dgv.EnableHeadersVisualStyles = false;
            this.InspectionItem_dgv.MultiSelect = false;
            this.InspectionItem_dgv.Name = "InspectionItem_dgv";
            this.InspectionItem_dgv.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(232)))), ((int)(((byte)(180)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.InspectionItem_dgv.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.InspectionItem_dgv.RowHeadersVisible = false;
            this.InspectionItem_dgv.RowTemplate.Height = 21;
            this.InspectionItem_dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.InspectionItem_dgv.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.InspectionItem_dgv_CellClick);
            this.InspectionItem_dgv.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.InspectionItem_dgv_CellDoubleClick);
            this.InspectionItem_dgv.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.InspectionItem_dgv_ColumnHeaderMouseClick);
            // 
            // colInspectionItemCode
            // 
            this.colInspectionItemCode.DataPropertyName = "InspectionItemCode";
            this.colInspectionItemCode.Frozen = true;
            resources.ApplyResources(this.colInspectionItemCode, "colInspectionItemCode");
            this.colInspectionItemCode.Name = "colInspectionItemCode";
            this.colInspectionItemCode.ReadOnly = true;
            // 
            // ColInspectionItemId
            // 
            resources.ApplyResources(this.ColInspectionItemId, "ColInspectionItemId");
            this.ColInspectionItemId.Name = "ColInspectionItemId";
            this.ColInspectionItemId.ReadOnly = true;
            // 
            // ColParentInspectionItemId
            // 
            this.ColParentInspectionItemId.DataPropertyName = "ParentInspectionItemId";
            resources.ApplyResources(this.ColParentInspectionItemId, "ColParentInspectionItemId");
            this.ColParentInspectionItemId.Name = "ColParentInspectionItemId";
            this.ColParentInspectionItemId.ReadOnly = true;
            // 
            // colInspectionProcessId
            // 
            this.colInspectionProcessId.DataPropertyName = "InspectionProcessId";
            resources.ApplyResources(this.colInspectionProcessId, "colInspectionProcessId");
            this.colInspectionProcessId.Name = "colInspectionProcessId";
            this.colInspectionProcessId.ReadOnly = true;
            // 
            // colInspectionItemName
            // 
            this.colInspectionItemName.DataPropertyName = "InspectionItemName";
            resources.ApplyResources(this.colInspectionItemName, "colInspectionItemName");
            this.colInspectionItemName.Name = "colInspectionItemName";
            this.colInspectionItemName.ReadOnly = true;
            // 
            // colParentItemCode
            // 
            this.colParentItemCode.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.colParentItemCode.DataPropertyName = "ParentItemCode";
            resources.ApplyResources(this.colParentItemCode, "colParentItemCode");
            this.colParentItemCode.Name = "colParentItemCode";
            this.colParentItemCode.ReadOnly = true;
            // 
            // colInspectionProcess
            // 
            this.colInspectionProcess.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colInspectionProcess.DataPropertyName = "InspectionProcessName";
            resources.ApplyResources(this.colInspectionProcess, "colInspectionProcess");
            this.colInspectionProcess.Name = "colInspectionProcess";
            this.colInspectionProcess.ReadOnly = true;
            // 
            // ParentItemCode_lbl
            // 
            resources.ApplyResources(this.ParentItemCode_lbl, "ParentItemCode_lbl");
            this.ParentItemCode_lbl.ControlId = null;
            this.ParentItemCode_lbl.Name = "ParentItemCode_lbl";
            // 
            // InspectionItemName_lbl
            // 
            resources.ApplyResources(this.InspectionItemName_lbl, "InspectionItemName_lbl");
            this.InspectionItemName_lbl.ControlId = null;
            this.InspectionItemName_lbl.Name = "InspectionItemName_lbl";
            // 
            // InspectionItemName_txt
            // 
            resources.ApplyResources(this.InspectionItemName_txt, "InspectionItemName_txt");
            this.InspectionItemName_txt.ControlId = null;
            this.InspectionItemName_txt.InputType = Com.Nidec.Mes.Framework.TextBoxCommon.InputTypeList.All;
            this.InspectionItemName_txt.Name = "InspectionItemName_txt";
            // 
            // ParentItemCode_cmb
            // 
            resources.ApplyResources(this.ParentItemCode_cmb, "ParentItemCode_cmb");
            this.ParentItemCode_cmb.ControlId = null;
            this.ParentItemCode_cmb.FormattingEnabled = true;
            this.ParentItemCode_cmb.Name = "ParentItemCode_cmb";
            // 
            // InspectionItemCode_txt
            // 
            resources.ApplyResources(this.InspectionItemCode_txt, "InspectionItemCode_txt");
            this.InspectionItemCode_txt.ControlId = null;
            this.InspectionItemCode_txt.InputType = Com.Nidec.Mes.Framework.TextBoxCommon.InputTypeList.All;
            this.InspectionItemCode_txt.Name = "InspectionItemCode_txt";
            // 
            // InspectionItemCode_lbl
            // 
            resources.ApplyResources(this.InspectionItemCode_lbl, "InspectionItemCode_lbl");
            this.InspectionItemCode_lbl.ControlId = null;
            this.InspectionItemCode_lbl.Name = "InspectionItemCode_lbl";
            // 
            // InspectionProcess_lbl
            // 
            resources.ApplyResources(this.InspectionProcess_lbl, "InspectionProcess_lbl");
            this.InspectionProcess_lbl.ControlId = null;
            this.InspectionProcess_lbl.Name = "InspectionProcess_lbl";
            // 
            // InspectionProcess_cmb
            // 
            resources.ApplyResources(this.InspectionProcess_cmb, "InspectionProcess_cmb");
            this.InspectionProcess_cmb.ControlId = null;
            this.InspectionProcess_cmb.FormattingEnabled = true;
            this.InspectionProcess_cmb.Name = "InspectionProcess_cmb";
            // 
            // InspectionTestInstruction_btn
            // 
            resources.ApplyResources(this.InspectionTestInstruction_btn, "InspectionTestInstruction_btn");
            this.InspectionTestInstruction_btn.BackColor = System.Drawing.SystemColors.Control;
            this.InspectionTestInstruction_btn.ControlId = null;
            this.InspectionTestInstruction_btn.Name = "InspectionTestInstruction_btn";
            this.InspectionTestInstruction_btn.UseVisualStyleBackColor = true;
            this.InspectionTestInstruction_btn.Click += new System.EventHandler(this.InspectionTestInstruction_btn_Click);
            // 
            // InspectionSpecification_btn
            // 
            resources.ApplyResources(this.InspectionSpecification_btn, "InspectionSpecification_btn");
            this.InspectionSpecification_btn.BackColor = System.Drawing.SystemColors.Control;
            this.InspectionSpecification_btn.ControlId = null;
            this.InspectionSpecification_btn.Name = "InspectionSpecification_btn";
            this.InspectionSpecification_btn.UseVisualStyleBackColor = true;
            this.InspectionSpecification_btn.Click += new System.EventHandler(this.InspectionSpecification_btn_Click);
            // 
            // InspectionItemForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ControlId = "bpmf017";
            this.Controls.Add(this.InspectionSpecification_btn);
            this.Controls.Add(this.InspectionTestInstruction_btn);
            this.Controls.Add(this.InspectionProcess_lbl);
            this.Controls.Add(this.InspectionProcess_cmb);
            this.Controls.Add(this.Clear_btn);
            this.Controls.Add(this.Exit_btn);
            this.Controls.Add(this.Delete_btn);
            this.Controls.Add(this.Update_btn);
            this.Controls.Add(this.Add_btn);
            this.Controls.Add(this.Search_btn);
            this.Controls.Add(this.InspectionItem_dgv);
            this.Controls.Add(this.ParentItemCode_lbl);
            this.Controls.Add(this.InspectionItemName_lbl);
            this.Controls.Add(this.InspectionItemName_txt);
            this.Controls.Add(this.ParentItemCode_cmb);
            this.Controls.Add(this.InspectionItemCode_txt);
            this.Controls.Add(this.InspectionItemCode_lbl);
            this.Name = "InspectionItemForm";
            this.TitleText = "FormCommon";
            this.Load += new System.EventHandler(this.InspectionItemForm_Load);
            this.Controls.SetChildIndex(this.InspectionItemCode_lbl, 0);
            this.Controls.SetChildIndex(this.InspectionItemCode_txt, 0);
            this.Controls.SetChildIndex(this.ParentItemCode_cmb, 0);
            this.Controls.SetChildIndex(this.InspectionItemName_txt, 0);
            this.Controls.SetChildIndex(this.InspectionItemName_lbl, 0);
            this.Controls.SetChildIndex(this.ParentItemCode_lbl, 0);
            this.Controls.SetChildIndex(this.InspectionItem_dgv, 0);
            this.Controls.SetChildIndex(this.Search_btn, 0);
            this.Controls.SetChildIndex(this.Add_btn, 0);
            this.Controls.SetChildIndex(this.Update_btn, 0);
            this.Controls.SetChildIndex(this.Delete_btn, 0);
            this.Controls.SetChildIndex(this.Exit_btn, 0);
            this.Controls.SetChildIndex(this.Clear_btn, 0);
            this.Controls.SetChildIndex(this.InspectionProcess_cmb, 0);
            this.Controls.SetChildIndex(this.InspectionProcess_lbl, 0);
            this.Controls.SetChildIndex(this.InspectionTestInstruction_btn, 0);
            this.Controls.SetChildIndex(this.InspectionSpecification_btn, 0);
            ((System.ComponentModel.ISupportInitialize)(this.InspectionItem_dgv)).EndInit();
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
        internal Com.Nidec.Mes.Framework.DataGridViewCommon InspectionItem_dgv;
        private Com.Nidec.Mes.Framework.LabelCommon ParentItemCode_lbl;
        private Com.Nidec.Mes.Framework.LabelCommon InspectionItemName_lbl;
        private Com.Nidec.Mes.Framework.TextBoxCommon InspectionItemName_txt;
        private Com.Nidec.Mes.Framework.ComboBoxCommon ParentItemCode_cmb;
        private Com.Nidec.Mes.Framework.TextBoxCommon InspectionItemCode_txt;
        private Com.Nidec.Mes.Framework.LabelCommon InspectionItemCode_lbl;
        private Framework.LabelCommon InspectionProcess_lbl;
        private Framework.ComboBoxCommon InspectionProcess_cmb;
        private Framework.ButtonCommon InspectionTestInstruction_btn;
        private Framework.ButtonCommon InspectionSpecification_btn;
        private System.Windows.Forms.DataGridViewTextBoxColumn colInspectionItemCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColInspectionItemId;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColParentInspectionItemId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colInspectionProcessId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colInspectionItemName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colParentItemCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn colInspectionProcess;
    }
}