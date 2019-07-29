namespace Com.Nidec.Mes.GlobalMasterMaintenance
{
    partial class MoldItemMasterForm : FormCommonMaster
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MoldItemMasterForm));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.Clear_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.Search_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.Exit_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.Update_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.MoldItem_dgv = new Com.Nidec.Mes.Framework.DataGridViewCommon();
            this.SapItem_lbl = new Com.Nidec.Mes.Framework.LabelCommon();
            this.MoldCode_lbl = new Com.Nidec.Mes.Framework.LabelCommon();
            this.SapItem_cmb = new Com.Nidec.Mes.Framework.ComboBoxCommon();
            this.Mold_cmb = new Com.Nidec.Mes.Framework.ComboBoxCommon();
            this.colItemId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colItemName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSapItemCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSapItem = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmstdcycletime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSelect = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.MoldItem_dgv)).BeginInit();
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
            // Search_btn
            // 
            resources.ApplyResources(this.Search_btn, "Search_btn");
            this.Search_btn.BackColor = System.Drawing.SystemColors.Control;
            this.Search_btn.ControlId = null;
            this.Search_btn.Name = "Search_btn";
            this.Search_btn.UseVisualStyleBackColor = true;
            this.Search_btn.Click += new System.EventHandler(this.Search_btn_Click);
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
            // MoldItem_dgv
            // 
            resources.ApplyResources(this.MoldItem_dgv, "MoldItem_dgv");
            this.MoldItem_dgv.AllowUserToAddRows = false;
            this.MoldItem_dgv.AllowUserToDeleteRows = false;
            this.MoldItem_dgv.AllowUserToOrderColumns = true;
            this.MoldItem_dgv.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(232)))), ((int)(((byte)(180)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.MoldItem_dgv.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.MoldItem_dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.MoldItem_dgv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colItemId,
            this.colItemName,
            this.colSapItemCode,
            this.colSapItem,
            this.clmstdcycletime,
            this.colSelect});
            this.MoldItem_dgv.ControlId = null;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.MoldItem_dgv.DefaultCellStyle = dataGridViewCellStyle2;
            this.MoldItem_dgv.EnableHeadersVisualStyles = false;
            this.MoldItem_dgv.MultiSelect = false;
            this.MoldItem_dgv.Name = "MoldItem_dgv";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(232)))), ((int)(((byte)(180)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.MoldItem_dgv.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.MoldItem_dgv.RowHeadersVisible = false;
            this.MoldItem_dgv.RowTemplate.Height = 21;
            this.MoldItem_dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.MoldItem_dgv.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.MoldItem_dgv_CellContentClick);
            this.MoldItem_dgv.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.MoldItem_dgv_CellValidating);
            this.MoldItem_dgv.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.LineMachine_dgv_ColumnHeaderMouseClick);
            this.MoldItem_dgv.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.MoldItem_dgv_EditingControlShowing);
            // 
            // SapItem_lbl
            // 
            resources.ApplyResources(this.SapItem_lbl, "SapItem_lbl");
            this.SapItem_lbl.ControlId = null;
            this.SapItem_lbl.Name = "SapItem_lbl";
            // 
            // MoldCode_lbl
            // 
            resources.ApplyResources(this.MoldCode_lbl, "MoldCode_lbl");
            this.MoldCode_lbl.ControlId = null;
            this.MoldCode_lbl.Name = "MoldCode_lbl";
            // 
            // SapItem_cmb
            // 
            resources.ApplyResources(this.SapItem_cmb, "SapItem_cmb");
            this.SapItem_cmb.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.SapItem_cmb.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.SapItem_cmb.ControlId = null;
            this.SapItem_cmb.FormattingEnabled = true;
            this.SapItem_cmb.Name = "SapItem_cmb";
            // 
            // Mold_cmb
            // 
            resources.ApplyResources(this.Mold_cmb, "Mold_cmb");
            this.Mold_cmb.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.Mold_cmb.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.Mold_cmb.ControlId = null;
            this.Mold_cmb.FormattingEnabled = true;
            this.Mold_cmb.Name = "Mold_cmb";
            // 
            // colItemId
            // 
            this.colItemId.DataPropertyName = "MoldId";
            resources.ApplyResources(this.colItemId, "colItemId");
            this.colItemId.Name = "colItemId";
            this.colItemId.ReadOnly = true;
            // 
            // colItemName
            // 
            this.colItemName.DataPropertyName = "MoldName";
            resources.ApplyResources(this.colItemName, "colItemName");
            this.colItemName.Name = "colItemName";
            this.colItemName.ReadOnly = true;
            // 
            // colSapItemCode
            // 
            this.colSapItemCode.DataPropertyName = "GlobalItemCode";
            resources.ApplyResources(this.colSapItemCode, "colSapItemCode");
            this.colSapItemCode.Name = "colSapItemCode";
            this.colSapItemCode.ReadOnly = true;
            // 
            // colSapItem
            // 
            this.colSapItem.DataPropertyName = "GlobalItemName";
            resources.ApplyResources(this.colSapItem, "colSapItem");
            this.colSapItem.Name = "colSapItem";
            this.colSapItem.ReadOnly = true;
            // 
            // clmstdcycletime
            // 
            this.clmstdcycletime.DataPropertyName = "StdCycleTime";
            resources.ApplyResources(this.clmstdcycletime, "clmstdcycletime");
            this.clmstdcycletime.Name = "clmstdcycletime";
            this.clmstdcycletime.ReadOnly = true;
            // 
            // colSelect
            // 
            this.colSelect.DataPropertyName = "IsExists";
            this.colSelect.FalseValue = "False";
            resources.ApplyResources(this.colSelect, "colSelect");
            this.colSelect.Name = "colSelect";
            this.colSelect.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colSelect.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.colSelect.TrueValue = "True";
            // 
            // MoldItemMasterForm
            // 
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.Mold_cmb);
            this.Controls.Add(this.MoldCode_lbl);
            this.Controls.Add(this.SapItem_cmb);
            this.Controls.Add(this.SapItem_lbl);
            this.Controls.Add(this.MoldItem_dgv);
            this.Controls.Add(this.Exit_btn);
            this.Controls.Add(this.Update_btn);
            this.Controls.Add(this.Clear_btn);
            this.Controls.Add(this.Search_btn);
            this.Name = "MoldItemMasterForm";
            this.TitleText = "FormCommon";
            this.Load += new System.EventHandler(this.MoldItemMasterForm_Load);
            this.Controls.SetChildIndex(this.Search_btn, 0);
            this.Controls.SetChildIndex(this.Clear_btn, 0);
            this.Controls.SetChildIndex(this.Update_btn, 0);
            this.Controls.SetChildIndex(this.Exit_btn, 0);
            this.Controls.SetChildIndex(this.MoldItem_dgv, 0);
            this.Controls.SetChildIndex(this.SapItem_lbl, 0);
            this.Controls.SetChildIndex(this.SapItem_cmb, 0);
            this.Controls.SetChildIndex(this.MoldCode_lbl, 0);
            this.Controls.SetChildIndex(this.Mold_cmb, 0);
            ((System.ComponentModel.ISupportInitialize)(this.MoldItem_dgv)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Framework.ButtonCommon Clear_btn;
        private Framework.ButtonCommon Search_btn;
        private Framework.ButtonCommon Exit_btn;
        private Framework.ButtonCommon Update_btn;
        internal Framework.DataGridViewCommon MoldItem_dgv;
        private Framework.LabelCommon SapItem_lbl;
        private Framework.LabelCommon MoldCode_lbl;
        private Framework.ComboBoxCommon SapItem_cmb;
        private Framework.ComboBoxCommon Mold_cmb;
        private System.Windows.Forms.DataGridViewTextBoxColumn colItemId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colItemName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSapItemCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSapItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmstdcycletime;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colSelect;
    }
}
