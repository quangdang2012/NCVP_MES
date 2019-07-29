namespace Com.Nidec.Mes.GlobalMasterMaintenance
{
    partial class InspectionItemForProcessForm : FormCommonMaster
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InspectionItemForProcessForm));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.Exit_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.Delete_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.Update_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.Add_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.InspectionItem_dgv = new Com.Nidec.Mes.Framework.DataGridViewCommon();
            this.colInspectionItemCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColInspectionItemId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColParentInspectionItemId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colInspectionProcessId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colInspectionItemName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colParentItemName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colInspectionProcess = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colInsSpecification = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTestInstruction = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colItemDataType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colComments = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colResultInputDecimalDigits = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDisplayOrder = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.InspectionProcess_lbl = new Com.Nidec.Mes.Framework.LabelCommon();
            this.InspectionProcess_cmb = new Com.Nidec.Mes.Framework.ComboBoxCommon();
            this.InspectionTestInstruction_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.InspectionSpecification_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.ItemCopy_cntxMnu = new System.Windows.Forms.ContextMenuStrip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.InspectionItem_dgv)).BeginInit();
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
            // Add_btn
            // 
            resources.ApplyResources(this.Add_btn, "Add_btn");
            this.Add_btn.BackColor = System.Drawing.SystemColors.Control;
            this.Add_btn.ControlId = null;
            this.Add_btn.Name = "Add_btn";
            this.Add_btn.UseVisualStyleBackColor = true;
            this.Add_btn.Click += new System.EventHandler(this.Add_btn_Click);
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
            this.colParentItemName,
            this.colInspectionProcess,
            this.colInsSpecification,
            this.colTestInstruction,
            this.colItemDataType,
            this.colComments,
            this.colResultInputDecimalDigits,
            this.colDisplayOrder});
            this.InspectionItem_dgv.ControlId = null;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.InspectionItem_dgv.DefaultCellStyle = dataGridViewCellStyle3;
            this.InspectionItem_dgv.EnableHeadersVisualStyles = false;
            this.InspectionItem_dgv.MultiSelect = false;
            this.InspectionItem_dgv.Name = "InspectionItem_dgv";
            this.InspectionItem_dgv.ReadOnly = true;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(232)))), ((int)(((byte)(180)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.InspectionItem_dgv.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.InspectionItem_dgv.RowHeadersVisible = false;
            this.InspectionItem_dgv.RowTemplate.Height = 21;
            this.InspectionItem_dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.InspectionItem_dgv.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.InspectionItem_dgv_CellClick);
            this.InspectionItem_dgv.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.InspectionItem_dgv_CellDoubleClick);
            this.InspectionItem_dgv.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.InspectionItem_dgv_ColumnHeaderMouseClick);
            this.InspectionItem_dgv.MouseClick += new System.Windows.Forms.MouseEventHandler(this.InspectionItem_dgv_MouseClick);
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
            this.ColInspectionItemId.DataPropertyName = "InspectionItemId";
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
            // colParentItemName
            // 
            this.colParentItemName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.colParentItemName.DataPropertyName = "ParentItemName";
            resources.ApplyResources(this.colParentItemName, "colParentItemName");
            this.colParentItemName.Name = "colParentItemName";
            this.colParentItemName.ReadOnly = true;
            // 
            // colInspectionProcess
            // 
            this.colInspectionProcess.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colInspectionProcess.DataPropertyName = "InspectionProcessName";
            resources.ApplyResources(this.colInspectionProcess, "colInspectionProcess");
            this.colInspectionProcess.Name = "colInspectionProcess";
            this.colInspectionProcess.ReadOnly = true;
            // 
            // colInsSpecification
            // 
            this.colInsSpecification.DataPropertyName = "InspectionSpecificationText";
            resources.ApplyResources(this.colInsSpecification, "colInsSpecification");
            this.colInsSpecification.Name = "colInsSpecification";
            this.colInsSpecification.ReadOnly = true;
            // 
            // colTestInstruction
            // 
            this.colTestInstruction.DataPropertyName = "InspectionTestInstructionText";
            resources.ApplyResources(this.colTestInstruction, "colTestInstruction");
            this.colTestInstruction.Name = "colTestInstruction";
            this.colTestInstruction.ReadOnly = true;
            // 
            // colItemDataType
            // 
            this.colItemDataType.DataPropertyName = "InspectionItemDataType";
            resources.ApplyResources(this.colItemDataType, "colItemDataType");
            this.colItemDataType.Name = "colItemDataType";
            this.colItemDataType.ReadOnly = true;
            // 
            // colComments
            // 
            resources.ApplyResources(this.colComments, "colComments");
            this.colComments.Name = "colComments";
            this.colComments.ReadOnly = true;
            // 
            // colResultInputDecimalDigits
            // 
            this.colResultInputDecimalDigits.DataPropertyName = "InspectionResultItemDecimalDigits";
            resources.ApplyResources(this.colResultInputDecimalDigits, "colResultInputDecimalDigits");
            this.colResultInputDecimalDigits.Name = "colResultInputDecimalDigits";
            this.colResultInputDecimalDigits.ReadOnly = true;
            // 
            // colDisplayOrder
            // 
            this.colDisplayOrder.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colDisplayOrder.DataPropertyName = "FormattedDisplayOrder";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.colDisplayOrder.DefaultCellStyle = dataGridViewCellStyle2;
            resources.ApplyResources(this.colDisplayOrder, "colDisplayOrder");
            this.colDisplayOrder.Name = "colDisplayOrder";
            this.colDisplayOrder.ReadOnly = true;
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
            // ItemCopy_cntxMnu
            // 
            resources.ApplyResources(this.ItemCopy_cntxMnu, "ItemCopy_cntxMnu");
            this.ItemCopy_cntxMnu.Name = "contextMenuStrip1";
            this.ItemCopy_cntxMnu.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.ItemCopy_cntxMnu_ItemClicked);
            // 
            // InspectionItemForProcessForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ControlId = "bpmf017";
            this.Controls.Add(this.InspectionSpecification_btn);
            this.Controls.Add(this.InspectionTestInstruction_btn);
            this.Controls.Add(this.InspectionProcess_lbl);
            this.Controls.Add(this.InspectionProcess_cmb);
            this.Controls.Add(this.Exit_btn);
            this.Controls.Add(this.Delete_btn);
            this.Controls.Add(this.Update_btn);
            this.Controls.Add(this.Add_btn);
            this.Controls.Add(this.InspectionItem_dgv);
            this.Name = "InspectionItemForProcessForm";
            this.TitleText = "FormCommon";
            this.Load += new System.EventHandler(this.InspectionItemForm_Load);
            this.Controls.SetChildIndex(this.InspectionItem_dgv, 0);
            this.Controls.SetChildIndex(this.Add_btn, 0);
            this.Controls.SetChildIndex(this.Update_btn, 0);
            this.Controls.SetChildIndex(this.Delete_btn, 0);
            this.Controls.SetChildIndex(this.Exit_btn, 0);
            this.Controls.SetChildIndex(this.InspectionProcess_cmb, 0);
            this.Controls.SetChildIndex(this.InspectionProcess_lbl, 0);
            this.Controls.SetChildIndex(this.InspectionTestInstruction_btn, 0);
            this.Controls.SetChildIndex(this.InspectionSpecification_btn, 0);
            ((System.ComponentModel.ISupportInitialize)(this.InspectionItem_dgv)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Com.Nidec.Mes.Framework.ButtonCommon Exit_btn;
        private Com.Nidec.Mes.Framework.ButtonCommon Delete_btn;
        private Com.Nidec.Mes.Framework.ButtonCommon Update_btn;
        private Com.Nidec.Mes.Framework.ButtonCommon Add_btn;
        internal Com.Nidec.Mes.Framework.DataGridViewCommon InspectionItem_dgv;
        private Framework.LabelCommon InspectionProcess_lbl;
        private Framework.ComboBoxCommon InspectionProcess_cmb;
        private Framework.ButtonCommon InspectionTestInstruction_btn;
        private Framework.ButtonCommon InspectionSpecification_btn;
        private System.Windows.Forms.DataGridViewTextBoxColumn colInspectionItemCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColInspectionItemId;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColParentInspectionItemId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colInspectionProcessId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colInspectionItemName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colParentItemName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colInspectionProcess;
        private System.Windows.Forms.DataGridViewTextBoxColumn colInsSpecification;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTestInstruction;
        private System.Windows.Forms.DataGridViewTextBoxColumn colItemDataType;
        private System.Windows.Forms.DataGridViewTextBoxColumn colComments;
        private System.Windows.Forms.DataGridViewTextBoxColumn colResultInputDecimalDigits;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDisplayOrder;
        private System.Windows.Forms.ContextMenuStrip ItemCopy_cntxMnu;
    }
}