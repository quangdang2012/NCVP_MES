namespace Com.Nidec.Mes.GlobalMasterMaintenance
{
    partial class InspectionItemListForm : FormCommonMaster
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InspectionItemListForm));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.Exit_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.Ok_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.InspectionItem_dgv = new Com.Nidec.Mes.Framework.DataGridViewCommon();
            this.colInspectionItemId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colInspectionItem = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colInspectionProcessName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colInspectionProcessId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDisplayOrder = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LineId_cmb = new Com.Nidec.Mes.Framework.ComboBoxCommon();
            this.ProcessId_cmb = new Com.Nidec.Mes.Framework.ComboBoxCommon();
            this.labelCommon1 = new Com.Nidec.Mes.Framework.LabelCommon();
            this.labelCommon2 = new Com.Nidec.Mes.Framework.LabelCommon();
            this.LineId_lbl = new Com.Nidec.Mes.Framework.LabelCommon();
            this.ItemId_lbl = new Com.Nidec.Mes.Framework.LabelCommon();
            this.Search_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.InspectionFormatName_txt = new Com.Nidec.Mes.Framework.TextBoxCommon();
            this.InspectionFormatName_lbl = new Com.Nidec.Mes.Framework.LabelCommon();
            this.Clear_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.ItemSearch_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.ItemCode_txt = new Com.Nidec.Mes.Framework.TextBoxCommon();
            this.GetProcess_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.InspectionProcessName_lbl = new Com.Nidec.Mes.Framework.LabelCommon();
            this.labelCommon3 = new Com.Nidec.Mes.Framework.LabelCommon();
            this.ItemName_lbl = new Com.Nidec.Mes.Framework.LabelCommon();
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
            // Ok_btn
            // 
            resources.ApplyResources(this.Ok_btn, "Ok_btn");
            this.Ok_btn.BackColor = System.Drawing.SystemColors.Control;
            this.Ok_btn.ControlId = null;
            this.Ok_btn.Name = "Ok_btn";
            this.Ok_btn.UseVisualStyleBackColor = true;
            this.Ok_btn.Click += new System.EventHandler(this.Ok_btn_Click);
            // 
            // InspectionItem_dgv
            // 
            resources.ApplyResources(this.InspectionItem_dgv, "InspectionItem_dgv");
            this.InspectionItem_dgv.AllowUserToAddRows = false;
            this.InspectionItem_dgv.AllowUserToDeleteRows = false;
            this.InspectionItem_dgv.AllowUserToOrderColumns = true;
            this.InspectionItem_dgv.AllowUserToResizeRows = false;
            this.InspectionItem_dgv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
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
            this.colInspectionItemId,
            this.colInspectionItem,
            this.colInspectionProcessName,
            this.colInspectionProcessId,
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
            this.InspectionItem_dgv.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.InspectionProcessDetails_dgv_CellClick);
            this.InspectionItem_dgv.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.InspectionProcessDetails_dgv_ColumnHeaderMouseClick);
            // 
            // colInspectionItemId
            // 
            this.colInspectionItemId.DataPropertyName = "InspectionItemId";
            resources.ApplyResources(this.colInspectionItemId, "colInspectionItemId");
            this.colInspectionItemId.Name = "colInspectionItemId";
            this.colInspectionItemId.ReadOnly = true;
            // 
            // colInspectionItem
            // 
            this.colInspectionItem.DataPropertyName = "InspectionItemName";
            resources.ApplyResources(this.colInspectionItem, "colInspectionItem");
            this.colInspectionItem.Name = "colInspectionItem";
            this.colInspectionItem.ReadOnly = true;
            // 
            // colInspectionProcessName
            // 
            this.colInspectionProcessName.DataPropertyName = "InspectionProcessName";
            resources.ApplyResources(this.colInspectionProcessName, "colInspectionProcessName");
            this.colInspectionProcessName.Name = "colInspectionProcessName";
            this.colInspectionProcessName.ReadOnly = true;
            // 
            // colInspectionProcessId
            // 
            this.colInspectionProcessId.DataPropertyName = "InspectionProcessId";
            resources.ApplyResources(this.colInspectionProcessId, "colInspectionProcessId");
            this.colInspectionProcessId.Name = "colInspectionProcessId";
            this.colInspectionProcessId.ReadOnly = true;
            // 
            // colDisplayOrder
            // 
            this.colDisplayOrder.DataPropertyName = "DisplayOrder";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.colDisplayOrder.DefaultCellStyle = dataGridViewCellStyle2;
            resources.ApplyResources(this.colDisplayOrder, "colDisplayOrder");
            this.colDisplayOrder.Name = "colDisplayOrder";
            this.colDisplayOrder.ReadOnly = true;
            // 
            // LineId_cmb
            // 
            resources.ApplyResources(this.LineId_cmb, "LineId_cmb");
            this.LineId_cmb.ControlId = null;
            this.LineId_cmb.FormattingEnabled = true;
            this.LineId_cmb.Name = "LineId_cmb";
            // 
            // ProcessId_cmb
            // 
            resources.ApplyResources(this.ProcessId_cmb, "ProcessId_cmb");
            this.ProcessId_cmb.ControlId = null;
            this.ProcessId_cmb.FormattingEnabled = true;
            this.ProcessId_cmb.Name = "ProcessId_cmb";
            // 
            // labelCommon1
            // 
            resources.ApplyResources(this.labelCommon1, "labelCommon1");
            this.labelCommon1.ControlId = null;
            this.labelCommon1.ForeColor = System.Drawing.Color.DarkRed;
            this.labelCommon1.Name = "labelCommon1";
            // 
            // labelCommon2
            // 
            resources.ApplyResources(this.labelCommon2, "labelCommon2");
            this.labelCommon2.ControlId = null;
            this.labelCommon2.ForeColor = System.Drawing.Color.DarkRed;
            this.labelCommon2.Name = "labelCommon2";
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
            // Search_btn
            // 
            resources.ApplyResources(this.Search_btn, "Search_btn");
            this.Search_btn.BackColor = System.Drawing.SystemColors.Control;
            this.Search_btn.ControlId = null;
            this.Search_btn.Name = "Search_btn";
            this.Search_btn.UseVisualStyleBackColor = true;
            this.Search_btn.Click += new System.EventHandler(this.Search_btn_Click);
            // 
            // InspectionFormatName_txt
            // 
            resources.ApplyResources(this.InspectionFormatName_txt, "InspectionFormatName_txt");
            this.InspectionFormatName_txt.ControlId = null;
            this.InspectionFormatName_txt.InputType = Com.Nidec.Mes.Framework.TextBoxCommon.InputTypeList.All;
            this.InspectionFormatName_txt.Name = "InspectionFormatName_txt";
            this.InspectionFormatName_txt.ReadOnly = true;
            this.InspectionFormatName_txt.TabStop = false;
            // 
            // InspectionFormatName_lbl
            // 
            resources.ApplyResources(this.InspectionFormatName_lbl, "InspectionFormatName_lbl");
            this.InspectionFormatName_lbl.ControlId = null;
            this.InspectionFormatName_lbl.Name = "InspectionFormatName_lbl";
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
            // ItemSearch_btn
            // 
            resources.ApplyResources(this.ItemSearch_btn, "ItemSearch_btn");
            this.ItemSearch_btn.BackColor = System.Drawing.SystemColors.Control;
            this.ItemSearch_btn.ControlId = null;
            this.ItemSearch_btn.Name = "ItemSearch_btn";
            this.ItemSearch_btn.UseVisualStyleBackColor = true;
            this.ItemSearch_btn.Click += new System.EventHandler(this.ItemSearch_btn_Click);
            // 
            // ItemCode_txt
            // 
            resources.ApplyResources(this.ItemCode_txt, "ItemCode_txt");
            this.ItemCode_txt.ControlId = null;
            this.ItemCode_txt.InputType = Com.Nidec.Mes.Framework.TextBoxCommon.InputTypeList.All;
            this.ItemCode_txt.Name = "ItemCode_txt";
            // 
            // GetProcess_btn
            // 
            resources.ApplyResources(this.GetProcess_btn, "GetProcess_btn");
            this.GetProcess_btn.BackColor = System.Drawing.SystemColors.Control;
            this.GetProcess_btn.ControlId = null;
            this.GetProcess_btn.Name = "GetProcess_btn";
            this.GetProcess_btn.UseVisualStyleBackColor = true;
            this.GetProcess_btn.Click += new System.EventHandler(this.GetProcess_btn_Click);
            // 
            // InspectionProcessName_lbl
            // 
            resources.ApplyResources(this.InspectionProcessName_lbl, "InspectionProcessName_lbl");
            this.InspectionProcessName_lbl.ControlId = null;
            this.InspectionProcessName_lbl.Name = "InspectionProcessName_lbl";
            // 
            // labelCommon3
            // 
            resources.ApplyResources(this.labelCommon3, "labelCommon3");
            this.labelCommon3.ControlId = null;
            this.labelCommon3.ForeColor = System.Drawing.Color.DarkRed;
            this.labelCommon3.Name = "labelCommon3";
            // 
            // ItemName_lbl
            // 
            resources.ApplyResources(this.ItemName_lbl, "ItemName_lbl");
            this.ItemName_lbl.ControlId = null;
            this.ItemName_lbl.Name = "ItemName_lbl";
            // 
            // InspectionItemListForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ControlId = "bpmf006";
            this.Controls.Add(this.ItemName_lbl);
            this.Controls.Add(this.labelCommon3);
            this.Controls.Add(this.InspectionProcessName_lbl);
            this.Controls.Add(this.GetProcess_btn);
            this.Controls.Add(this.ItemSearch_btn);
            this.Controls.Add(this.ItemCode_txt);
            this.Controls.Add(this.Clear_btn);
            this.Controls.Add(this.InspectionFormatName_txt);
            this.Controls.Add(this.InspectionFormatName_lbl);
            this.Controls.Add(this.Search_btn);
            this.Controls.Add(this.LineId_cmb);
            this.Controls.Add(this.labelCommon1);
            this.Controls.Add(this.labelCommon2);
            this.Controls.Add(this.LineId_lbl);
            this.Controls.Add(this.ItemId_lbl);
            this.Controls.Add(this.InspectionItem_dgv);
            this.Controls.Add(this.Exit_btn);
            this.Controls.Add(this.Ok_btn);
            this.Controls.Add(this.ProcessId_cmb);
            this.Name = "InspectionItemListForm";
            this.TitleText = "FormCommon";
            this.Load += new System.EventHandler(this.InspectionProcessListForm_Load);
            this.Controls.SetChildIndex(this.ProcessId_cmb, 0);
            this.Controls.SetChildIndex(this.Ok_btn, 0);
            this.Controls.SetChildIndex(this.Exit_btn, 0);
            this.Controls.SetChildIndex(this.InspectionItem_dgv, 0);
            this.Controls.SetChildIndex(this.ItemId_lbl, 0);
            this.Controls.SetChildIndex(this.LineId_lbl, 0);
            this.Controls.SetChildIndex(this.labelCommon2, 0);
            this.Controls.SetChildIndex(this.labelCommon1, 0);
            this.Controls.SetChildIndex(this.LineId_cmb, 0);
            this.Controls.SetChildIndex(this.Search_btn, 0);
            this.Controls.SetChildIndex(this.InspectionFormatName_lbl, 0);
            this.Controls.SetChildIndex(this.InspectionFormatName_txt, 0);
            this.Controls.SetChildIndex(this.Clear_btn, 0);
            this.Controls.SetChildIndex(this.ItemCode_txt, 0);
            this.Controls.SetChildIndex(this.ItemSearch_btn, 0);
            this.Controls.SetChildIndex(this.GetProcess_btn, 0);
            this.Controls.SetChildIndex(this.InspectionProcessName_lbl, 0);
            this.Controls.SetChildIndex(this.labelCommon3, 0);
            this.Controls.SetChildIndex(this.ItemName_lbl, 0);
            ((System.ComponentModel.ISupportInitialize)(this.InspectionItem_dgv)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        protected Com.Nidec.Mes.Framework.ButtonCommon Exit_btn;
        protected Com.Nidec.Mes.Framework.ButtonCommon Ok_btn;
        internal Framework.DataGridViewCommon InspectionItem_dgv;
        public Framework.ComboBoxCommon LineId_cmb;
        public Framework.ComboBoxCommon ProcessId_cmb;
        public Framework.LabelCommon labelCommon1;
        public Framework.LabelCommon labelCommon2;
        public Framework.LabelCommon LineId_lbl;
        public Framework.LabelCommon ItemId_lbl;
        protected Framework.ButtonCommon Search_btn;
        public Framework.TextBoxCommon InspectionFormatName_txt;
        public Framework.LabelCommon InspectionFormatName_lbl;
        protected Framework.ButtonCommon Clear_btn;
        protected Framework.ButtonCommon ItemSearch_btn;
        protected Framework.TextBoxCommon ItemCode_txt;
        protected Framework.ButtonCommon GetProcess_btn;
        private Framework.LabelCommon InspectionProcessName_lbl;
        private System.Windows.Forms.DataGridViewTextBoxColumn colInspectionItemId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colInspectionItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn colInspectionProcessName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colInspectionProcessId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDisplayOrder;
        public Framework.LabelCommon labelCommon3;
        public Framework.LabelCommon ItemName_lbl;
    }
}