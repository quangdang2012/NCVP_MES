namespace Com.Nidec.Mes.GlobalMasterMaintenance
{
    partial class ItemLineInspectionFormatForm : FormCommonMaster
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ItemLineInspectionFormatForm));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.InspectionFormatId_cmb = new Com.Nidec.Mes.Framework.ComboBoxCommon();
            this.InspectionFormatId_lbl = new Com.Nidec.Mes.Framework.LabelCommon();
            this.Clear_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.Exit_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.Delete_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.Update_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.ItemLineInspectionFormatDetails_dgv = new Com.Nidec.Mes.Framework.DataGridViewCommon();
            this.colItemId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colItemName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLineId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLineName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colInspectionFormatName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colInspectionFormatId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colItemLineInspectionFormatId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Add_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.Search_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.LineId_lbl = new Com.Nidec.Mes.Framework.LabelCommon();
            this.ItemId_lbl = new Com.Nidec.Mes.Framework.LabelCommon();
            this.ItemId_cmb = new Com.Nidec.Mes.Framework.ComboBoxCommon();
            this.LineId_cmb = new Com.Nidec.Mes.Framework.ComboBoxCommon();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLineInspectionFormatDetails_dgv)).BeginInit();
            this.SuspendLayout();
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
            // ItemLineInspectionFormatDetails_dgv
            // 
            this.ItemLineInspectionFormatDetails_dgv.AllowUserToAddRows = false;
            this.ItemLineInspectionFormatDetails_dgv.AllowUserToDeleteRows = false;
            this.ItemLineInspectionFormatDetails_dgv.AllowUserToOrderColumns = true;
            this.ItemLineInspectionFormatDetails_dgv.AllowUserToResizeRows = false;
            resources.ApplyResources(this.ItemLineInspectionFormatDetails_dgv, "ItemLineInspectionFormatDetails_dgv");
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(232)))), ((int)(((byte)(180)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.ItemLineInspectionFormatDetails_dgv.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.ItemLineInspectionFormatDetails_dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ItemLineInspectionFormatDetails_dgv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colItemId,
            this.colItemName,
            this.colLineId,
            this.colLineName,
            this.colInspectionFormatName,
            this.colInspectionFormatId,
            this.colItemLineInspectionFormatId});
            this.ItemLineInspectionFormatDetails_dgv.ControlId = null;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.ItemLineInspectionFormatDetails_dgv.DefaultCellStyle = dataGridViewCellStyle2;
            this.ItemLineInspectionFormatDetails_dgv.EnableHeadersVisualStyles = false;
            this.ItemLineInspectionFormatDetails_dgv.MultiSelect = false;
            this.ItemLineInspectionFormatDetails_dgv.Name = "ItemLineInspectionFormatDetails_dgv";
            this.ItemLineInspectionFormatDetails_dgv.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(232)))), ((int)(((byte)(180)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.ItemLineInspectionFormatDetails_dgv.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.ItemLineInspectionFormatDetails_dgv.RowHeadersVisible = false;
            this.ItemLineInspectionFormatDetails_dgv.RowTemplate.Height = 21;
            this.ItemLineInspectionFormatDetails_dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.ItemLineInspectionFormatDetails_dgv.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.InspectionProcessDetails_dgv_CellClick);
            this.ItemLineInspectionFormatDetails_dgv.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.InspectionProcessDetails_dgv_CellDoubleClick);
            this.ItemLineInspectionFormatDetails_dgv.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.ItemLineInspectionFormatDetails_dgv_ColumnHeaderMouseClick);
            // 
            // colItemId
            // 
            this.colItemId.DataPropertyName = "ItemId";
            resources.ApplyResources(this.colItemId, "colItemId");
            this.colItemId.Name = "colItemId";
            this.colItemId.ReadOnly = true;
            // 
            // colItemName
            // 
            this.colItemName.DataPropertyName = "ItemName";
            resources.ApplyResources(this.colItemName, "colItemName");
            this.colItemName.Name = "colItemName";
            this.colItemName.ReadOnly = true;
            // 
            // colLineId
            // 
            this.colLineId.DataPropertyName = "LineId";
            resources.ApplyResources(this.colLineId, "colLineId");
            this.colLineId.Name = "colLineId";
            this.colLineId.ReadOnly = true;
            // 
            // colLineName
            // 
            this.colLineName.DataPropertyName = "LineName";
            resources.ApplyResources(this.colLineName, "colLineName");
            this.colLineName.Name = "colLineName";
            this.colLineName.ReadOnly = true;
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
            // colItemLineInspectionFormatId
            // 
            this.colItemLineInspectionFormatId.DataPropertyName = "ItemLineInspectionFormatId";
            resources.ApplyResources(this.colItemLineInspectionFormatId, "colItemLineInspectionFormatId");
            this.colItemLineInspectionFormatId.Name = "colItemLineInspectionFormatId";
            this.colItemLineInspectionFormatId.ReadOnly = true;
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
            // LineId_lbl
            // 
            resources.ApplyResources(this.LineId_lbl, "LineId_lbl");
            this.LineId_lbl.ControlId = null;
            this.LineId_lbl.Name = "LineId_lbl";
            // 
            // ItemId_lbl
            // 
            resources.ApplyResources(this.ItemId_lbl, "ItemId_lbl");
            this.ItemId_lbl.ControlId = null;
            this.ItemId_lbl.Name = "ItemId_lbl";
            // 
            // ItemId_cmb
            // 
            this.ItemId_cmb.ControlId = null;
            resources.ApplyResources(this.ItemId_cmb, "ItemId_cmb");
            this.ItemId_cmb.FormattingEnabled = true;
            this.ItemId_cmb.Name = "ItemId_cmb";
            // 
            // LineId_cmb
            // 
            this.LineId_cmb.ControlId = null;
            resources.ApplyResources(this.LineId_cmb, "LineId_cmb");
            this.LineId_cmb.FormattingEnabled = true;
            this.LineId_cmb.Name = "LineId_cmb";
            // 
            // ItemLineInspectionFormatForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ControlId = "bpmf008";
            this.Controls.Add(this.LineId_cmb);
            this.Controls.Add(this.ItemId_cmb);
            this.Controls.Add(this.InspectionFormatId_cmb);
            this.Controls.Add(this.InspectionFormatId_lbl);
            this.Controls.Add(this.Clear_btn);
            this.Controls.Add(this.Exit_btn);
            this.Controls.Add(this.Delete_btn);
            this.Controls.Add(this.Update_btn);
            this.Controls.Add(this.ItemLineInspectionFormatDetails_dgv);
            this.Controls.Add(this.Add_btn);
            this.Controls.Add(this.Search_btn);
            this.Controls.Add(this.LineId_lbl);
            this.Controls.Add(this.ItemId_lbl);
            this.Name = "ItemLineInspectionFormatForm";
            this.TitleText = "FormCommon";
            this.Load += new System.EventHandler(this.InspectionProcessForm_Load);
            this.Controls.SetChildIndex(this.ItemId_lbl, 0);
            this.Controls.SetChildIndex(this.LineId_lbl, 0);
            this.Controls.SetChildIndex(this.Search_btn, 0);
            this.Controls.SetChildIndex(this.Add_btn, 0);
            this.Controls.SetChildIndex(this.ItemLineInspectionFormatDetails_dgv, 0);
            this.Controls.SetChildIndex(this.Update_btn, 0);
            this.Controls.SetChildIndex(this.Delete_btn, 0);
            this.Controls.SetChildIndex(this.Exit_btn, 0);
            this.Controls.SetChildIndex(this.Clear_btn, 0);
            this.Controls.SetChildIndex(this.InspectionFormatId_lbl, 0);
            this.Controls.SetChildIndex(this.InspectionFormatId_cmb, 0);
            this.Controls.SetChildIndex(this.ItemId_cmb, 0);
            this.Controls.SetChildIndex(this.LineId_cmb, 0);
            ((System.ComponentModel.ISupportInitialize)(this.ItemLineInspectionFormatDetails_dgv)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Com.Nidec.Mes.Framework.ButtonCommon Clear_btn;
        private Com.Nidec.Mes.Framework.ButtonCommon Exit_btn;
        private Com.Nidec.Mes.Framework.ButtonCommon Delete_btn;
        private Com.Nidec.Mes.Framework.ButtonCommon Update_btn;
        internal Com.Nidec.Mes.Framework.DataGridViewCommon ItemLineInspectionFormatDetails_dgv;
        private Com.Nidec.Mes.Framework.ButtonCommon Add_btn;
        private Com.Nidec.Mes.Framework.ButtonCommon Search_btn;
        private Com.Nidec.Mes.Framework.LabelCommon LineId_lbl;
        private Com.Nidec.Mes.Framework.LabelCommon ItemId_lbl;
        private Com.Nidec.Mes.Framework.ComboBoxCommon InspectionFormatId_cmb;
        private Com.Nidec.Mes.Framework.LabelCommon InspectionFormatId_lbl;
        private Framework.ComboBoxCommon ItemId_cmb;
        private Framework.ComboBoxCommon LineId_cmb;
        private System.Windows.Forms.DataGridViewTextBoxColumn colItemId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colItemName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLineId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLineName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colInspectionFormatName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colInspectionFormatId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colItemLineInspectionFormatId;
    }
}