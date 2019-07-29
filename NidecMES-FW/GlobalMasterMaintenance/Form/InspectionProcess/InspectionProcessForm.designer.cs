namespace Com.Nidec.Mes.GlobalMasterMaintenance
{
    partial class InspectionProcessForm : FormCommonMaster
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InspectionProcessForm));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.InspectionFormatId_cmb = new Com.Nidec.Mes.Framework.ComboBoxCommon();
            this.InspectionFormatId_lbl = new Com.Nidec.Mes.Framework.LabelCommon();
            this.Clear_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.Exit_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.Delete_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.Update_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.InspectionProcessDetails_dgv = new Com.Nidec.Mes.Framework.DataGridViewCommon();
            this.colInspectionProcessCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colInspectionProcessName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colInspectionFormatName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colInspectionFormatId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colInspectionProcessId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Add_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.Search_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.InspectionProcessName_txt = new Com.Nidec.Mes.Framework.TextBoxCommon();
            this.InspectionProcessName_lbl = new Com.Nidec.Mes.Framework.LabelCommon();
            this.InspectionProcessCode_txt = new Com.Nidec.Mes.Framework.TextBoxCommon();
            this.InspectionProcessCode_lbl = new Com.Nidec.Mes.Framework.LabelCommon();
            ((System.ComponentModel.ISupportInitialize)(this.InspectionProcessDetails_dgv)).BeginInit();
            this.SuspendLayout();
            // 
            // InspectionFormatId_cmb
            // 
            resources.ApplyResources(this.InspectionFormatId_cmb, "InspectionFormatId_cmb");
            this.InspectionFormatId_cmb.ControlId = null;
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
            // InspectionProcessDetails_dgv
            // 
            resources.ApplyResources(this.InspectionProcessDetails_dgv, "InspectionProcessDetails_dgv");
            this.InspectionProcessDetails_dgv.AllowUserToAddRows = false;
            this.InspectionProcessDetails_dgv.AllowUserToDeleteRows = false;
            this.InspectionProcessDetails_dgv.AllowUserToOrderColumns = true;
            this.InspectionProcessDetails_dgv.AllowUserToResizeRows = false;
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
            this.colInspectionProcessId});
            this.InspectionProcessDetails_dgv.ControlId = null;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.InspectionProcessDetails_dgv.DefaultCellStyle = dataGridViewCellStyle2;
            this.InspectionProcessDetails_dgv.EnableHeadersVisualStyles = false;
            this.InspectionProcessDetails_dgv.MultiSelect = false;
            this.InspectionProcessDetails_dgv.Name = "InspectionProcessDetails_dgv";
            this.InspectionProcessDetails_dgv.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(232)))), ((int)(((byte)(180)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.InspectionProcessDetails_dgv.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.InspectionProcessDetails_dgv.RowHeadersVisible = false;
            this.InspectionProcessDetails_dgv.RowTemplate.Height = 21;
            this.InspectionProcessDetails_dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.InspectionProcessDetails_dgv.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.InspectionProcessDetails_dgv_CellClick);
            this.InspectionProcessDetails_dgv.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.InspectionProcessDetails_dgv_CellDoubleClick);
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
            // InspectionProcessName_txt
            // 
            resources.ApplyResources(this.InspectionProcessName_txt, "InspectionProcessName_txt");
            this.InspectionProcessName_txt.ControlId = null;
            this.InspectionProcessName_txt.InputType = Com.Nidec.Mes.Framework.TextBoxCommon.InputTypeList.All;
            this.InspectionProcessName_txt.Name = "InspectionProcessName_txt";
            // 
            // InspectionProcessName_lbl
            // 
            resources.ApplyResources(this.InspectionProcessName_lbl, "InspectionProcessName_lbl");
            this.InspectionProcessName_lbl.ControlId = null;
            this.InspectionProcessName_lbl.Name = "InspectionProcessName_lbl";
            // 
            // InspectionProcessCode_txt
            // 
            resources.ApplyResources(this.InspectionProcessCode_txt, "InspectionProcessCode_txt");
            this.InspectionProcessCode_txt.ControlId = null;
            this.InspectionProcessCode_txt.InputType = Com.Nidec.Mes.Framework.TextBoxCommon.InputTypeList.All;
            this.InspectionProcessCode_txt.Name = "InspectionProcessCode_txt";
            // 
            // InspectionProcessCode_lbl
            // 
            resources.ApplyResources(this.InspectionProcessCode_lbl, "InspectionProcessCode_lbl");
            this.InspectionProcessCode_lbl.ControlId = null;
            this.InspectionProcessCode_lbl.Name = "InspectionProcessCode_lbl";
            // 
            // InspectionProcessForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ControlId = "bpmf008";
            this.Controls.Add(this.InspectionFormatId_cmb);
            this.Controls.Add(this.InspectionFormatId_lbl);
            this.Controls.Add(this.Clear_btn);
            this.Controls.Add(this.Exit_btn);
            this.Controls.Add(this.Delete_btn);
            this.Controls.Add(this.Update_btn);
            this.Controls.Add(this.InspectionProcessDetails_dgv);
            this.Controls.Add(this.Add_btn);
            this.Controls.Add(this.Search_btn);
            this.Controls.Add(this.InspectionProcessName_txt);
            this.Controls.Add(this.InspectionProcessName_lbl);
            this.Controls.Add(this.InspectionProcessCode_txt);
            this.Controls.Add(this.InspectionProcessCode_lbl);
            this.Name = "InspectionProcessForm";
            this.TitleText = "FormCommon";
            this.Load += new System.EventHandler(this.InspectionProcessForm_Load);
            this.Controls.SetChildIndex(this.InspectionProcessCode_lbl, 0);
            this.Controls.SetChildIndex(this.InspectionProcessCode_txt, 0);
            this.Controls.SetChildIndex(this.InspectionProcessName_lbl, 0);
            this.Controls.SetChildIndex(this.InspectionProcessName_txt, 0);
            this.Controls.SetChildIndex(this.Search_btn, 0);
            this.Controls.SetChildIndex(this.Add_btn, 0);
            this.Controls.SetChildIndex(this.InspectionProcessDetails_dgv, 0);
            this.Controls.SetChildIndex(this.Update_btn, 0);
            this.Controls.SetChildIndex(this.Delete_btn, 0);
            this.Controls.SetChildIndex(this.Exit_btn, 0);
            this.Controls.SetChildIndex(this.Clear_btn, 0);
            this.Controls.SetChildIndex(this.InspectionFormatId_lbl, 0);
            this.Controls.SetChildIndex(this.InspectionFormatId_cmb, 0);
            ((System.ComponentModel.ISupportInitialize)(this.InspectionProcessDetails_dgv)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Com.Nidec.Mes.Framework.ButtonCommon Clear_btn;
        private Com.Nidec.Mes.Framework.ButtonCommon Exit_btn;
        private Com.Nidec.Mes.Framework.ButtonCommon Delete_btn;
        private Com.Nidec.Mes.Framework.ButtonCommon Update_btn;
        internal Com.Nidec.Mes.Framework.DataGridViewCommon InspectionProcessDetails_dgv;
        private Com.Nidec.Mes.Framework.ButtonCommon Add_btn;
        private Com.Nidec.Mes.Framework.ButtonCommon Search_btn;
        private Com.Nidec.Mes.Framework.TextBoxCommon InspectionProcessName_txt;
        private Com.Nidec.Mes.Framework.LabelCommon InspectionProcessName_lbl;
        private Com.Nidec.Mes.Framework.TextBoxCommon InspectionProcessCode_txt;
        private Com.Nidec.Mes.Framework.LabelCommon InspectionProcessCode_lbl;
        private Com.Nidec.Mes.Framework.ComboBoxCommon InspectionFormatId_cmb;
        private Com.Nidec.Mes.Framework.LabelCommon InspectionFormatId_lbl;
        private System.Windows.Forms.DataGridViewTextBoxColumn colInspectionProcessCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn colInspectionProcessName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colInspectionFormatName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colInspectionFormatId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colInspectionProcessId;
    }
}