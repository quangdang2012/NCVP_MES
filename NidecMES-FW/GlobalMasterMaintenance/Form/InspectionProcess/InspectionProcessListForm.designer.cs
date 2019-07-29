namespace Com.Nidec.Mes.GlobalMasterMaintenance
{
    partial class InspectionProcessListForm : FormCommonMaster
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InspectionProcessListForm));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.Exit_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.Ok_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.InspectionProcessDetails_dgv = new Com.Nidec.Mes.Framework.DataGridViewCommon();
            this.colInspectionProcessCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colInspectionProcessName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colInspectionFormatName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colInspectionFormatId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colInspectionProcessId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colInspectionItem = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Comments = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDisplayOrder = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LineId_cmb = new Com.Nidec.Mes.Framework.ComboBoxCommon();
            this.ItemId_cmb = new Com.Nidec.Mes.Framework.ComboBoxCommon();
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
            // Ok_btn
            // 
            resources.ApplyResources(this.Ok_btn, "Ok_btn");
            this.Ok_btn.BackColor = System.Drawing.SystemColors.Control;
            this.Ok_btn.ControlId = null;
            this.Ok_btn.Name = "Ok_btn";
            this.Ok_btn.UseVisualStyleBackColor = true;
            this.Ok_btn.Click += new System.EventHandler(this.Ok_btn_Click);
            // 
            // InspectionProcessDetails_dgv
            // 
            resources.ApplyResources(this.InspectionProcessDetails_dgv, "InspectionProcessDetails_dgv");
            this.InspectionProcessDetails_dgv.AllowUserToAddRows = false;
            this.InspectionProcessDetails_dgv.AllowUserToDeleteRows = false;
            this.InspectionProcessDetails_dgv.AllowUserToOrderColumns = true;
            this.InspectionProcessDetails_dgv.AllowUserToResizeRows = false;
            this.InspectionProcessDetails_dgv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(232)))), ((int)(((byte)(180)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.InspectionProcessDetails_dgv.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
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
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.InspectionProcessDetails_dgv.DefaultCellStyle = dataGridViewCellStyle3;
            this.InspectionProcessDetails_dgv.EnableHeadersVisualStyles = false;
            this.InspectionProcessDetails_dgv.MultiSelect = false;
            this.InspectionProcessDetails_dgv.Name = "InspectionProcessDetails_dgv";
            this.InspectionProcessDetails_dgv.ReadOnly = true;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(232)))), ((int)(((byte)(180)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.InspectionProcessDetails_dgv.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.InspectionProcessDetails_dgv.RowHeadersVisible = false;
            this.InspectionProcessDetails_dgv.RowTemplate.Height = 21;
            this.InspectionProcessDetails_dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.InspectionProcessDetails_dgv.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.InspectionProcessDetails_dgv_CellClick);
            this.InspectionProcessDetails_dgv.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.InspectionProcessDetails_dgv_ColumnHeaderMouseClick);
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
            // ItemId_cmb
            // 
            resources.ApplyResources(this.ItemId_cmb, "ItemId_cmb");
            this.ItemId_cmb.ControlId = null;
            this.ItemId_cmb.FormattingEnabled = true;
            this.ItemId_cmb.Name = "ItemId_cmb";
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
            // InspectionProcessListForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ControlId = "bpmf006";
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
            this.Controls.Add(this.InspectionProcessDetails_dgv);
            this.Controls.Add(this.Exit_btn);
            this.Controls.Add(this.Ok_btn);
            this.Controls.Add(this.ItemId_cmb);
            this.Name = "InspectionProcessListForm";
            this.TitleText = "FormCommon";
            this.Load += new System.EventHandler(this.InspectionProcessListForm_Load);
            this.Controls.SetChildIndex(this.ItemId_cmb, 0);
            this.Controls.SetChildIndex(this.Ok_btn, 0);
            this.Controls.SetChildIndex(this.Exit_btn, 0);
            this.Controls.SetChildIndex(this.InspectionProcessDetails_dgv, 0);
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
            ((System.ComponentModel.ISupportInitialize)(this.InspectionProcessDetails_dgv)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        protected Com.Nidec.Mes.Framework.ButtonCommon Exit_btn;
        protected Com.Nidec.Mes.Framework.ButtonCommon Ok_btn;
        internal Framework.DataGridViewCommon InspectionProcessDetails_dgv;
        public Framework.ComboBoxCommon LineId_cmb;
        public Framework.ComboBoxCommon ItemId_cmb;
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
        private System.Windows.Forms.DataGridViewTextBoxColumn colInspectionProcessCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn colInspectionProcessName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colInspectionFormatName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colInspectionFormatId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colInspectionProcessId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colInspectionItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn Comments;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDisplayOrder;
    }
}