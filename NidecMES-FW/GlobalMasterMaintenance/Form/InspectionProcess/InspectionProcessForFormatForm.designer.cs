namespace Com.Nidec.Mes.GlobalMasterMaintenance
{
    partial class InspectionProcessForFormatForm : FormCommonMaster
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InspectionProcessForFormatForm));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.Exit_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.Delete_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.Update_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.InspectionProcessDetails_dgv = new Com.Nidec.Mes.Framework.DataGridViewCommon();
            this.colInspectionProcessCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colInspectionProcessName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colInspectionFormatName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colInspectionFormatId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colInspectionProcessId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colInspectionItem = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Comments = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDisplayOrder = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Add_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.InspectionItem_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.InspectionFormatId_cmb = new Com.Nidec.Mes.Framework.ComboBoxCommon();
            this.InspectionFormatId_lbl = new Com.Nidec.Mes.Framework.LabelCommon();
            this.ProcessCopy_cntxMnu = new System.Windows.Forms.ContextMenuStrip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.InspectionProcessDetails_dgv)).BeginInit();
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
            // InspectionProcessDetails_dgv
            // 
            this.InspectionProcessDetails_dgv.AllowUserToAddRows = false;
            this.InspectionProcessDetails_dgv.AllowUserToDeleteRows = false;
            this.InspectionProcessDetails_dgv.AllowUserToOrderColumns = true;
            this.InspectionProcessDetails_dgv.AllowUserToResizeRows = false;
            resources.ApplyResources(this.InspectionProcessDetails_dgv, "InspectionProcessDetails_dgv");
            this.InspectionProcessDetails_dgv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(232)))), ((int)(((byte)(180)))));
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.InspectionProcessDetails_dgv.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.InspectionProcessDetails_dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.InspectionProcessDetails_dgv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colInspectionProcessCode,
            this.colInspectionProcessName,
            this.colInspectionFormatName,
            this.colInspectionFormatId,
            this.colInspectionProcessId,
            this.colInspectionItem,
            this.Comments,
            this.colDisplayOrder});
            this.InspectionProcessDetails_dgv.ControlId = null;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.InspectionProcessDetails_dgv.DefaultCellStyle = dataGridViewCellStyle7;
            this.InspectionProcessDetails_dgv.EnableHeadersVisualStyles = false;
            this.InspectionProcessDetails_dgv.MultiSelect = false;
            this.InspectionProcessDetails_dgv.Name = "InspectionProcessDetails_dgv";
            this.InspectionProcessDetails_dgv.ReadOnly = true;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(232)))), ((int)(((byte)(180)))));
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.InspectionProcessDetails_dgv.RowHeadersDefaultCellStyle = dataGridViewCellStyle8;
            this.InspectionProcessDetails_dgv.RowHeadersVisible = false;
            this.InspectionProcessDetails_dgv.RowTemplate.Height = 21;
            this.InspectionProcessDetails_dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.InspectionProcessDetails_dgv.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.InspectionProcessDetails_dgv_CellClick);
            this.InspectionProcessDetails_dgv.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.InspectionProcessDetails_dgv_CellDoubleClick);
            this.InspectionProcessDetails_dgv.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.InspectionProcessDetails_dgv_ColumnHeaderMouseClick);
            this.InspectionProcessDetails_dgv.MouseClick += new System.Windows.Forms.MouseEventHandler(this.InspectionProcessDetails_dgv_MouseClick);
            // 
            // colInspectionProcessCode
            // 
            this.colInspectionProcessCode.DataPropertyName = "InspectionProcessCode";
            resources.ApplyResources(this.colInspectionProcessCode, "colInspectionProcessCode");
            this.colInspectionProcessCode.Name = "colInspectionProcessCode";
            this.colInspectionProcessCode.ReadOnly = true;
            // 
            // colInspectionProcessName
            // 
            this.colInspectionProcessName.DataPropertyName = "InspectionProcessName";
            resources.ApplyResources(this.colInspectionProcessName, "colInspectionProcessName");
            this.colInspectionProcessName.Name = "colInspectionProcessName";
            this.colInspectionProcessName.ReadOnly = true;
            // 
            // colInspectionFormatName
            // 
            this.colInspectionFormatName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colInspectionFormatName.DataPropertyName = "InspectionFormatName";
            resources.ApplyResources(this.colInspectionFormatName, "colInspectionFormatName");
            this.colInspectionFormatName.Name = "colInspectionFormatName";
            this.colInspectionFormatName.ReadOnly = true;
            // 
            // colInspectionFormatId
            // 
            this.colInspectionFormatId.DataPropertyName = "InspectionFormatId";
            resources.ApplyResources(this.colInspectionFormatId, "colInspectionFormatId");
            this.colInspectionFormatId.Name = "colInspectionFormatId";
            this.colInspectionFormatId.ReadOnly = true;
            // 
            // colInspectionProcessId
            // 
            this.colInspectionProcessId.DataPropertyName = "InspectionProcessId";
            resources.ApplyResources(this.colInspectionProcessId, "colInspectionProcessId");
            this.colInspectionProcessId.Name = "colInspectionProcessId";
            this.colInspectionProcessId.ReadOnly = true;
            // 
            // colInspectionItem
            // 
            this.colInspectionItem.DataPropertyName = "InspectionItemName";
            resources.ApplyResources(this.colInspectionItem, "colInspectionItem");
            this.colInspectionItem.Name = "colInspectionItem";
            this.colInspectionItem.ReadOnly = true;
            // 
            // Comments
            // 
            resources.ApplyResources(this.Comments, "Comments");
            this.Comments.Name = "Comments";
            this.Comments.ReadOnly = true;
            // 
            // colDisplayOrder
            // 
            this.colDisplayOrder.DataPropertyName = "DisplayOrder";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.colDisplayOrder.DefaultCellStyle = dataGridViewCellStyle6;
            resources.ApplyResources(this.colDisplayOrder, "colDisplayOrder");
            this.colDisplayOrder.Name = "colDisplayOrder";
            this.colDisplayOrder.ReadOnly = true;
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
            // InspectionItem_btn
            // 
            resources.ApplyResources(this.InspectionItem_btn, "InspectionItem_btn");
            this.InspectionItem_btn.BackColor = System.Drawing.SystemColors.Control;
            this.InspectionItem_btn.ControlId = null;
            this.InspectionItem_btn.Name = "InspectionItem_btn";
            this.InspectionItem_btn.UseVisualStyleBackColor = true;
            this.InspectionItem_btn.Click += new System.EventHandler(this.InspectionItem_btn_Click);
            // 
            // InspectionFormatId_cmb
            // 
            this.InspectionFormatId_cmb.ControlId = null;
            resources.ApplyResources(this.InspectionFormatId_cmb, "InspectionFormatId_cmb");
            this.InspectionFormatId_cmb.FormattingEnabled = true;
            this.InspectionFormatId_cmb.Name = "InspectionFormatId_cmb";
            // 
            // InspectionFormatId_lbl
            // 
            resources.ApplyResources(this.InspectionFormatId_lbl, "InspectionFormatId_lbl");
            this.InspectionFormatId_lbl.ControlId = null;
            this.InspectionFormatId_lbl.Name = "InspectionFormatId_lbl";
            // 
            // ProcessCopy_cntxMnu
            // 
            this.ProcessCopy_cntxMnu.Name = "contextMenuStrip1";
            resources.ApplyResources(this.ProcessCopy_cntxMnu, "ProcessCopy_cntxMnu");
            this.ProcessCopy_cntxMnu.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.ProcessCopy_cntxMnu_ItemClicked);
            // 
            // InspectionProcessForFormatForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ControlId = "bpmf008";
            this.Controls.Add(this.InspectionFormatId_cmb);
            this.Controls.Add(this.InspectionFormatId_lbl);
            this.Controls.Add(this.InspectionItem_btn);
            this.Controls.Add(this.Exit_btn);
            this.Controls.Add(this.Delete_btn);
            this.Controls.Add(this.Update_btn);
            this.Controls.Add(this.InspectionProcessDetails_dgv);
            this.Controls.Add(this.Add_btn);
            this.Name = "InspectionProcessForFormatForm";
            this.TitleText = "FormCommon";
            this.Load += new System.EventHandler(this.InspectionProcessForm_Load);
            this.Controls.SetChildIndex(this.Add_btn, 0);
            this.Controls.SetChildIndex(this.InspectionProcessDetails_dgv, 0);
            this.Controls.SetChildIndex(this.Update_btn, 0);
            this.Controls.SetChildIndex(this.Delete_btn, 0);
            this.Controls.SetChildIndex(this.Exit_btn, 0);
            this.Controls.SetChildIndex(this.InspectionItem_btn, 0);
            this.Controls.SetChildIndex(this.InspectionFormatId_lbl, 0);
            this.Controls.SetChildIndex(this.InspectionFormatId_cmb, 0);
            ((System.ComponentModel.ISupportInitialize)(this.InspectionProcessDetails_dgv)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Com.Nidec.Mes.Framework.ButtonCommon Exit_btn;
        private Com.Nidec.Mes.Framework.ButtonCommon Delete_btn;
        private Com.Nidec.Mes.Framework.ButtonCommon Update_btn;
        internal Com.Nidec.Mes.Framework.DataGridViewCommon InspectionProcessDetails_dgv;
        private Com.Nidec.Mes.Framework.ButtonCommon Add_btn;
        private Framework.ButtonCommon InspectionItem_btn;
        private Framework.ComboBoxCommon InspectionFormatId_cmb;
        private Framework.LabelCommon InspectionFormatId_lbl;
        private System.Windows.Forms.DataGridViewTextBoxColumn colInspectionProcessCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn colInspectionProcessName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colInspectionFormatName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colInspectionFormatId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colInspectionProcessId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colInspectionItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn Comments;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDisplayOrder;
        private System.Windows.Forms.ContextMenuStrip ProcessCopy_cntxMnu;
    }
}