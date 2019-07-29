namespace Com.Nidec.Mes.GlobalMasterMaintenance
{
    partial class AddMachineForm:FormCommonMaster
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddMachineForm));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.Exit_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.Ok_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.MachineCode_txt = new Com.Nidec.Mes.Framework.TextBoxCommon();
            this.MachineName_lbl = new Com.Nidec.Mes.Framework.LabelCommon();
            this.MachineName_txt = new Com.Nidec.Mes.Framework.TextBoxCommon();
            this.MachineCode_lbl = new Com.Nidec.Mes.Framework.LabelCommon();
            this.labelCommon2 = new Com.Nidec.Mes.Framework.LabelCommon();
            this.labelCommon1 = new Com.Nidec.Mes.Framework.LabelCommon();
            this.UpdateText_lbl = new Com.Nidec.Mes.Framework.LabelCommon();
            this.ProcessWork_dgv = new Com.Nidec.Mes.Framework.DataGridViewCommon();
            this.colSelect = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colProcessWorkId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colProcessWorkName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CheckAll_chk = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.ProcessWork_dgv)).BeginInit();
            this.SuspendLayout();
            // 
            // Exit_btn
            // 
            this.Exit_btn.BackColor = System.Drawing.SystemColors.Control;
            this.Exit_btn.ControlId = null;
            resources.ApplyResources(this.Exit_btn, "Exit_btn");
            this.Exit_btn.Name = "Exit_btn";
            this.Exit_btn.UseVisualStyleBackColor = true;
            this.Exit_btn.Click += new System.EventHandler(this.Exit_btn_Click);
            // 
            // Ok_btn
            // 
            this.Ok_btn.BackColor = System.Drawing.SystemColors.Control;
            this.Ok_btn.ControlId = null;
            resources.ApplyResources(this.Ok_btn, "Ok_btn");
            this.Ok_btn.Name = "Ok_btn";
            this.Ok_btn.UseVisualStyleBackColor = true;
            this.Ok_btn.Click += new System.EventHandler(this.Ok_btn_Click);
            // 
            // MachineCode_txt
            // 
            this.MachineCode_txt.ControlId = null;
            resources.ApplyResources(this.MachineCode_txt, "MachineCode_txt");
            this.MachineCode_txt.InputType = Com.Nidec.Mes.Framework.TextBoxCommon.InputTypeList.All;
            this.MachineCode_txt.Name = "MachineCode_txt";
            // 
            // MachineName_lbl
            // 
            resources.ApplyResources(this.MachineName_lbl, "MachineName_lbl");
            this.MachineName_lbl.ControlId = null;
            this.MachineName_lbl.Name = "MachineName_lbl";
            // 
            // MachineName_txt
            // 
            this.MachineName_txt.ControlId = null;
            resources.ApplyResources(this.MachineName_txt, "MachineName_txt");
            this.MachineName_txt.InputType = Com.Nidec.Mes.Framework.TextBoxCommon.InputTypeList.All;
            this.MachineName_txt.Name = "MachineName_txt";
            // 
            // MachineCode_lbl
            // 
            resources.ApplyResources(this.MachineCode_lbl, "MachineCode_lbl");
            this.MachineCode_lbl.ControlId = null;
            this.MachineCode_lbl.Name = "MachineCode_lbl";
            // 
            // labelCommon2
            // 
            resources.ApplyResources(this.labelCommon2, "labelCommon2");
            this.labelCommon2.ControlId = null;
            this.labelCommon2.ForeColor = System.Drawing.Color.DarkRed;
            this.labelCommon2.Name = "labelCommon2";
            // 
            // labelCommon1
            // 
            resources.ApplyResources(this.labelCommon1, "labelCommon1");
            this.labelCommon1.ControlId = null;
            this.labelCommon1.ForeColor = System.Drawing.Color.DarkRed;
            this.labelCommon1.Name = "labelCommon1";
            // 
            // UpdateText_lbl
            // 
            resources.ApplyResources(this.UpdateText_lbl, "UpdateText_lbl");
            this.UpdateText_lbl.ControlId = null;
            this.UpdateText_lbl.Name = "UpdateText_lbl";
            // 
            // ProcessWork_dgv
            // 
            this.ProcessWork_dgv.AllowUserToAddRows = false;
            this.ProcessWork_dgv.AllowUserToDeleteRows = false;
            this.ProcessWork_dgv.AllowUserToOrderColumns = true;
            this.ProcessWork_dgv.AllowUserToResizeRows = false;
            this.ProcessWork_dgv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(232)))), ((int)(((byte)(180)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.ProcessWork_dgv.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.ProcessWork_dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ProcessWork_dgv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colSelect,
            this.colProcessWorkId,
            this.colProcessWorkName});
            this.ProcessWork_dgv.ControlId = null;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.ProcessWork_dgv.DefaultCellStyle = dataGridViewCellStyle2;
            this.ProcessWork_dgv.EnableHeadersVisualStyles = false;
            resources.ApplyResources(this.ProcessWork_dgv, "ProcessWork_dgv");
            this.ProcessWork_dgv.MultiSelect = false;
            this.ProcessWork_dgv.Name = "ProcessWork_dgv";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(232)))), ((int)(((byte)(180)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.ProcessWork_dgv.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.ProcessWork_dgv.RowHeadersVisible = false;
            this.ProcessWork_dgv.RowTemplate.Height = 21;
            this.ProcessWork_dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            // 
            // colSelect
            // 
            this.colSelect.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.colSelect.DataPropertyName = "IsExists";
            this.colSelect.FalseValue = "False";
            this.colSelect.FillWeight = 45F;
            resources.ApplyResources(this.colSelect, "colSelect");
            this.colSelect.Name = "colSelect";
            this.colSelect.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colSelect.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.colSelect.TrueValue = "True";
            // 
            // colProcessWorkId
            // 
            this.colProcessWorkId.DataPropertyName = "ProcessWorkId";
            resources.ApplyResources(this.colProcessWorkId, "colProcessWorkId");
            this.colProcessWorkId.Name = "colProcessWorkId";
            this.colProcessWorkId.ReadOnly = true;
            // 
            // colProcessWorkName
            // 
            this.colProcessWorkName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.colProcessWorkName.DataPropertyName = "ProcessWorkName";
            resources.ApplyResources(this.colProcessWorkName, "colProcessWorkName");
            this.colProcessWorkName.Name = "colProcessWorkName";
            this.colProcessWorkName.ReadOnly = true;
            // 
            // CheckAll_chk
            // 
            resources.ApplyResources(this.CheckAll_chk, "CheckAll_chk");
            this.CheckAll_chk.Name = "CheckAll_chk";
            this.CheckAll_chk.UseVisualStyleBackColor = true;
            this.CheckAll_chk.CheckedChanged += new System.EventHandler(this.CheckAll_chk_CheckedChanged);
            // 
            // AddMachineForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.CheckAll_chk);
            this.Controls.Add(this.ProcessWork_dgv);
            this.Controls.Add(this.UpdateText_lbl);
            this.Controls.Add(this.labelCommon1);
            this.Controls.Add(this.labelCommon2);
            this.Controls.Add(this.Exit_btn);
            this.Controls.Add(this.Ok_btn);
            this.Controls.Add(this.MachineCode_txt);
            this.Controls.Add(this.MachineName_lbl);
            this.Controls.Add(this.MachineName_txt);
            this.Controls.Add(this.MachineCode_lbl);
            this.Name = "AddMachineForm";
            this.TitleText = "FormCommon";
            this.Load += new System.EventHandler(this.AddMachineForm_Load);
            this.Controls.SetChildIndex(this.MachineCode_lbl, 0);
            this.Controls.SetChildIndex(this.MachineName_txt, 0);
            this.Controls.SetChildIndex(this.MachineName_lbl, 0);
            this.Controls.SetChildIndex(this.MachineCode_txt, 0);
            this.Controls.SetChildIndex(this.Ok_btn, 0);
            this.Controls.SetChildIndex(this.Exit_btn, 0);
            this.Controls.SetChildIndex(this.labelCommon2, 0);
            this.Controls.SetChildIndex(this.labelCommon1, 0);
            this.Controls.SetChildIndex(this.UpdateText_lbl, 0);
            this.Controls.SetChildIndex(this.ProcessWork_dgv, 0);
            this.Controls.SetChildIndex(this.CheckAll_chk, 0);
            ((System.ComponentModel.ISupportInitialize)(this.ProcessWork_dgv)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Com.Nidec.Mes.Framework.ButtonCommon Exit_btn;
        private Com.Nidec.Mes.Framework.ButtonCommon Ok_btn;
        private Com.Nidec.Mes.Framework.TextBoxCommon MachineCode_txt;
        private Com.Nidec.Mes.Framework.LabelCommon MachineName_lbl;
        private Com.Nidec.Mes.Framework.TextBoxCommon MachineName_txt;
        private Com.Nidec.Mes.Framework.LabelCommon MachineCode_lbl;
        private Framework.LabelCommon labelCommon2;
        private Framework.LabelCommon labelCommon1;
        private Framework.LabelCommon UpdateText_lbl;
        internal Framework.DataGridViewCommon ProcessWork_dgv;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colSelect;
        private System.Windows.Forms.DataGridViewTextBoxColumn colProcessWorkId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colProcessWorkName;
        private System.Windows.Forms.CheckBox CheckAll_chk;
    }
}