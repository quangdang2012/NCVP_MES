namespace Com.Nidec.Mes.GlobalMasterMaintenance
{
    partial class InspectionFormatMasterForm : FormCommonMaster
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InspectionFormatMasterForm));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.InspectionFormatCode_txt = new Com.Nidec.Mes.Framework.TextBoxCommon();
            this.InspectionFormatCode_lbl = new Com.Nidec.Mes.Framework.LabelCommon();
            this.InspectionFormatName_txt = new Com.Nidec.Mes.Framework.TextBoxCommon();
            this.InspectionFormatName_lbl = new Com.Nidec.Mes.Framework.LabelCommon();
            this.Add_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.Search_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.InspectionFormatDetails_dgv = new Com.Nidec.Mes.Framework.DataGridViewCommon();
            this.colInspectionFormatId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colInspectionItemLine = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colInspectionFormatCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colInspectionFormatName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colInspectionProcess = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Exit_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.Delete_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.Update_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.Clear_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.Process_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.LineId_cmb = new Com.Nidec.Mes.Framework.ComboBoxCommon();
            this.ItemId_cmb = new Com.Nidec.Mes.Framework.ComboBoxCommon();
            this.LineId_lbl = new Com.Nidec.Mes.Framework.LabelCommon();
            this.ItemId_lbl = new Com.Nidec.Mes.Framework.LabelCommon();
            this.ItemCode_txt = new Com.Nidec.Mes.Framework.TextBoxCommon();
            this.ItemSearch_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.FormatCopy_cntxMnu = new System.Windows.Forms.ContextMenuStrip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.InspectionFormatDetails_dgv)).BeginInit();
            this.SuspendLayout();
            // 
            // InspectionFormatCode_txt
            // 
            resources.ApplyResources(this.InspectionFormatCode_txt, "InspectionFormatCode_txt");
            this.InspectionFormatCode_txt.ControlId = null;
            this.InspectionFormatCode_txt.InputType = Com.Nidec.Mes.Framework.TextBoxCommon.InputTypeList.All;
            this.InspectionFormatCode_txt.Name = "InspectionFormatCode_txt";
            // 
            // InspectionFormatCode_lbl
            // 
            resources.ApplyResources(this.InspectionFormatCode_lbl, "InspectionFormatCode_lbl");
            this.InspectionFormatCode_lbl.ControlId = null;
            this.InspectionFormatCode_lbl.Name = "InspectionFormatCode_lbl";
            // 
            // InspectionFormatName_txt
            // 
            resources.ApplyResources(this.InspectionFormatName_txt, "InspectionFormatName_txt");
            this.InspectionFormatName_txt.ControlId = null;
            this.InspectionFormatName_txt.InputType = Com.Nidec.Mes.Framework.TextBoxCommon.InputTypeList.All;
            this.InspectionFormatName_txt.Name = "InspectionFormatName_txt";
            // 
            // InspectionFormatName_lbl
            // 
            resources.ApplyResources(this.InspectionFormatName_lbl, "InspectionFormatName_lbl");
            this.InspectionFormatName_lbl.ControlId = null;
            this.InspectionFormatName_lbl.Name = "InspectionFormatName_lbl";
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
            // InspectionFormatDetails_dgv
            // 
            resources.ApplyResources(this.InspectionFormatDetails_dgv, "InspectionFormatDetails_dgv");
            this.InspectionFormatDetails_dgv.AllowUserToAddRows = false;
            this.InspectionFormatDetails_dgv.AllowUserToDeleteRows = false;
            this.InspectionFormatDetails_dgv.AllowUserToOrderColumns = true;
            this.InspectionFormatDetails_dgv.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(232)))), ((int)(((byte)(180)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.InspectionFormatDetails_dgv.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.InspectionFormatDetails_dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.InspectionFormatDetails_dgv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colInspectionFormatId,
            this.colInspectionItemLine,
            this.colInspectionFormatCode,
            this.colInspectionFormatName,
            this.colInspectionProcess});
            this.InspectionFormatDetails_dgv.ControlId = null;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.InspectionFormatDetails_dgv.DefaultCellStyle = dataGridViewCellStyle2;
            this.InspectionFormatDetails_dgv.EnableHeadersVisualStyles = false;
            this.InspectionFormatDetails_dgv.MultiSelect = false;
            this.InspectionFormatDetails_dgv.Name = "InspectionFormatDetails_dgv";
            this.InspectionFormatDetails_dgv.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(232)))), ((int)(((byte)(180)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.InspectionFormatDetails_dgv.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.InspectionFormatDetails_dgv.RowHeadersVisible = false;
            this.InspectionFormatDetails_dgv.RowTemplate.Height = 21;
            this.InspectionFormatDetails_dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.InspectionFormatDetails_dgv.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.InspectionFormatDetails_dgv_CellClick);
            this.InspectionFormatDetails_dgv.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.InspectionFormatDetails_dgv_CellDoubleClick);
            this.InspectionFormatDetails_dgv.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.InspectionFormatDetails_dgv_ColumnHeaderMouseClick);
            this.InspectionFormatDetails_dgv.MouseClick += new System.Windows.Forms.MouseEventHandler(this.InspectionFormatDetails_dgv_MouseClick);
            // 
            // colInspectionFormatId
            // 
            this.colInspectionFormatId.DataPropertyName = "InspectionFormatId";
            resources.ApplyResources(this.colInspectionFormatId, "colInspectionFormatId");
            this.colInspectionFormatId.Name = "colInspectionFormatId";
            this.colInspectionFormatId.ReadOnly = true;
            // 
            // colInspectionItemLine
            // 
            this.colInspectionItemLine.DataPropertyName = "InspectionItemLineName";
            resources.ApplyResources(this.colInspectionItemLine, "colInspectionItemLine");
            this.colInspectionItemLine.Name = "colInspectionItemLine";
            this.colInspectionItemLine.ReadOnly = true;
            // 
            // colInspectionFormatCode
            // 
            this.colInspectionFormatCode.DataPropertyName = "InspectionFormatCode";
            resources.ApplyResources(this.colInspectionFormatCode, "colInspectionFormatCode");
            this.colInspectionFormatCode.Name = "colInspectionFormatCode";
            this.colInspectionFormatCode.ReadOnly = true;
            // 
            // colInspectionFormatName
            // 
            this.colInspectionFormatName.DataPropertyName = "InspectionFormatName";
            resources.ApplyResources(this.colInspectionFormatName, "colInspectionFormatName");
            this.colInspectionFormatName.Name = "colInspectionFormatName";
            this.colInspectionFormatName.ReadOnly = true;
            // 
            // colInspectionProcess
            // 
            this.colInspectionProcess.DataPropertyName = "InspectionProcessName";
            resources.ApplyResources(this.colInspectionProcess, "colInspectionProcess");
            this.colInspectionProcess.Name = "colInspectionProcess";
            this.colInspectionProcess.ReadOnly = true;
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
            // Clear_btn
            // 
            resources.ApplyResources(this.Clear_btn, "Clear_btn");
            this.Clear_btn.BackColor = System.Drawing.SystemColors.Control;
            this.Clear_btn.ControlId = null;
            this.Clear_btn.Name = "Clear_btn";
            this.Clear_btn.UseVisualStyleBackColor = true;
            this.Clear_btn.Click += new System.EventHandler(this.Clear_btn_Click);
            // 
            // Process_btn
            // 
            resources.ApplyResources(this.Process_btn, "Process_btn");
            this.Process_btn.BackColor = System.Drawing.SystemColors.Control;
            this.Process_btn.ControlId = null;
            this.Process_btn.Name = "Process_btn";
            this.Process_btn.UseVisualStyleBackColor = true;
            this.Process_btn.Click += new System.EventHandler(this.Process_btn_Click);
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
            // ItemCode_txt
            // 
            resources.ApplyResources(this.ItemCode_txt, "ItemCode_txt");
            this.ItemCode_txt.ControlId = null;
            this.ItemCode_txt.InputType = Com.Nidec.Mes.Framework.TextBoxCommon.InputTypeList.All;
            this.ItemCode_txt.Name = "ItemCode_txt";
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
            // FormatCopy_cntxMnu
            // 
            resources.ApplyResources(this.FormatCopy_cntxMnu, "FormatCopy_cntxMnu");
            this.FormatCopy_cntxMnu.Name = "contextMenuStrip1";
            this.FormatCopy_cntxMnu.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.FormatCopy_cntxMnu_ItemClicked);
            // 
            // InspectionFormatMasterForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ControlId = "bpmf006";
            this.Controls.Add(this.ItemSearch_btn);
            this.Controls.Add(this.ItemCode_txt);
            this.Controls.Add(this.LineId_cmb);
            this.Controls.Add(this.ItemId_cmb);
            this.Controls.Add(this.LineId_lbl);
            this.Controls.Add(this.ItemId_lbl);
            this.Controls.Add(this.Process_btn);
            this.Controls.Add(this.Clear_btn);
            this.Controls.Add(this.Exit_btn);
            this.Controls.Add(this.Delete_btn);
            this.Controls.Add(this.Update_btn);
            this.Controls.Add(this.InspectionFormatDetails_dgv);
            this.Controls.Add(this.Add_btn);
            this.Controls.Add(this.Search_btn);
            this.Controls.Add(this.InspectionFormatName_txt);
            this.Controls.Add(this.InspectionFormatName_lbl);
            this.Controls.Add(this.InspectionFormatCode_txt);
            this.Controls.Add(this.InspectionFormatCode_lbl);
            this.Name = "InspectionFormatMasterForm";
            this.TitleText = "FormCommon";
            this.Load += new System.EventHandler(this.InspectionFormatMasterForm_Load);
            this.Controls.SetChildIndex(this.InspectionFormatCode_lbl, 0);
            this.Controls.SetChildIndex(this.InspectionFormatCode_txt, 0);
            this.Controls.SetChildIndex(this.InspectionFormatName_lbl, 0);
            this.Controls.SetChildIndex(this.InspectionFormatName_txt, 0);
            this.Controls.SetChildIndex(this.Search_btn, 0);
            this.Controls.SetChildIndex(this.Add_btn, 0);
            this.Controls.SetChildIndex(this.InspectionFormatDetails_dgv, 0);
            this.Controls.SetChildIndex(this.Update_btn, 0);
            this.Controls.SetChildIndex(this.Delete_btn, 0);
            this.Controls.SetChildIndex(this.Exit_btn, 0);
            this.Controls.SetChildIndex(this.Clear_btn, 0);
            this.Controls.SetChildIndex(this.Process_btn, 0);
            this.Controls.SetChildIndex(this.ItemId_lbl, 0);
            this.Controls.SetChildIndex(this.LineId_lbl, 0);
            this.Controls.SetChildIndex(this.ItemId_cmb, 0);
            this.Controls.SetChildIndex(this.LineId_cmb, 0);
            this.Controls.SetChildIndex(this.ItemCode_txt, 0);
            this.Controls.SetChildIndex(this.ItemSearch_btn, 0);
            ((System.ComponentModel.ISupportInitialize)(this.InspectionFormatDetails_dgv)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        protected Com.Nidec.Mes.Framework.TextBoxCommon InspectionFormatCode_txt;
        protected Com.Nidec.Mes.Framework.LabelCommon InspectionFormatCode_lbl;
        protected Com.Nidec.Mes.Framework.TextBoxCommon InspectionFormatName_txt;
        protected Com.Nidec.Mes.Framework.LabelCommon InspectionFormatName_lbl;
        protected Com.Nidec.Mes.Framework.ButtonCommon Add_btn;
        protected Com.Nidec.Mes.Framework.ButtonCommon Search_btn;
        protected Com.Nidec.Mes.Framework.DataGridViewCommon InspectionFormatDetails_dgv;
        protected Com.Nidec.Mes.Framework.ButtonCommon Exit_btn;
        protected Com.Nidec.Mes.Framework.ButtonCommon Delete_btn;
        protected Com.Nidec.Mes.Framework.ButtonCommon Update_btn;
        protected Com.Nidec.Mes.Framework.ButtonCommon Clear_btn;
        protected Framework.ButtonCommon Process_btn;
        private Framework.ComboBoxCommon LineId_cmb;
        private Framework.ComboBoxCommon ItemId_cmb;
        private Framework.LabelCommon LineId_lbl;
        private Framework.LabelCommon ItemId_lbl;
        private System.Windows.Forms.DataGridViewTextBoxColumn colInspectionFormatId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colInspectionItemLine;
        private System.Windows.Forms.DataGridViewTextBoxColumn colInspectionFormatCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn colInspectionFormatName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colInspectionProcess;
        protected Framework.TextBoxCommon ItemCode_txt;
        protected Framework.ButtonCommon ItemSearch_btn;
        private System.Windows.Forms.ContextMenuStrip FormatCopy_cntxMnu;
    }
}