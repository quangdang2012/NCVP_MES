namespace Com.Nidec.Mes.GlobalMasterMaintenance
{
    partial class AddMoldNewForm : FormCommonMaster
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddMoldNewForm));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.Exit_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.Ok_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.ProcessWork_dgv = new Com.Nidec.Mes.Framework.DataGridViewCommon();
            this.colSelect = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colProcessWorkId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colProcessWorkName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Comment_lbl = new Com.Nidec.Mes.Framework.LabelCommon();
            this.Comment_txt = new Com.Nidec.Mes.Framework.TextBoxCommon();
            this.LifeShotCount_lbl = new Com.Nidec.Mes.Framework.LabelCommon();
            this.LifeShotCount_txt = new Com.Nidec.Mes.Framework.TextBoxCommon();
            this.ProductionDate_dtp = new Com.Nidec.Mes.Framework.DateTimePickerCommon();
            this.ProductionDate_lbl = new Com.Nidec.Mes.Framework.LabelCommon();
            this.Weight_lbl = new Com.Nidec.Mes.Framework.LabelCommon();
            this.Weight_txt = new Com.Nidec.Mes.Framework.TextBoxCommon();
            this.Height_lbl = new Com.Nidec.Mes.Framework.LabelCommon();
            this.Height_txt = new Com.Nidec.Mes.Framework.TextBoxCommon();
            this.Depth_lbl = new Com.Nidec.Mes.Framework.LabelCommon();
            this.Depth_txt = new Com.Nidec.Mes.Framework.TextBoxCommon();
            this.Width_lbl = new Com.Nidec.Mes.Framework.LabelCommon();
            this.Width_txt = new Com.Nidec.Mes.Framework.TextBoxCommon();
            this.UpdateText_lbl = new Com.Nidec.Mes.Framework.LabelCommon();
            this.labelCommon3 = new Com.Nidec.Mes.Framework.LabelCommon();
            this.labelCommon1 = new Com.Nidec.Mes.Framework.LabelCommon();
            this.labelCommon2 = new Com.Nidec.Mes.Framework.LabelCommon();
            this.MoldType_lbl = new Com.Nidec.Mes.Framework.LabelCommon();
            this.MoldType_cmb = new Com.Nidec.Mes.Framework.ComboBoxCommon();
            this.MoldCode_txt = new Com.Nidec.Mes.Framework.TextBoxCommon();
            this.MoldName_lbl = new Com.Nidec.Mes.Framework.LabelCommon();
            this.MoldName_txt = new Com.Nidec.Mes.Framework.TextBoxCommon();
            this.MoldCode_lbl = new Com.Nidec.Mes.Framework.LabelCommon();
            this.CheckAll_chk = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.ProcessWork_dgv)).BeginInit();
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
            // ProcessWork_dgv
            // 
            resources.ApplyResources(this.ProcessWork_dgv, "ProcessWork_dgv");
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
            // Comment_lbl
            // 
            resources.ApplyResources(this.Comment_lbl, "Comment_lbl");
            this.Comment_lbl.ControlId = null;
            this.Comment_lbl.Name = "Comment_lbl";
            // 
            // Comment_txt
            // 
            resources.ApplyResources(this.Comment_txt, "Comment_txt");
            this.Comment_txt.ControlId = null;
            this.Comment_txt.InputType = Com.Nidec.Mes.Framework.TextBoxCommon.InputTypeList.All;
            this.Comment_txt.Name = "Comment_txt";
            // 
            // LifeShotCount_lbl
            // 
            resources.ApplyResources(this.LifeShotCount_lbl, "LifeShotCount_lbl");
            this.LifeShotCount_lbl.ControlId = null;
            this.LifeShotCount_lbl.Name = "LifeShotCount_lbl";
            // 
            // LifeShotCount_txt
            // 
            resources.ApplyResources(this.LifeShotCount_txt, "LifeShotCount_txt");
            this.LifeShotCount_txt.ControlId = null;
            this.LifeShotCount_txt.InputType = Com.Nidec.Mes.Framework.TextBoxCommon.InputTypeList.Numeric;
            this.LifeShotCount_txt.Name = "LifeShotCount_txt";
            // 
            // ProductionDate_dtp
            // 
            resources.ApplyResources(this.ProductionDate_dtp, "ProductionDate_dtp");
            this.ProductionDate_dtp.BackColor = System.Drawing.SystemColors.Control;
            this.ProductionDate_dtp.ControlId = null;
            this.ProductionDate_dtp.DisplayFormat = Com.Nidec.Mes.Framework.DateTimePickerCommon.DisplayFormatList.ShortDatePattern;
            this.ProductionDate_dtp.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.ProductionDate_dtp.Name = "ProductionDate_dtp";
            // 
            // ProductionDate_lbl
            // 
            resources.ApplyResources(this.ProductionDate_lbl, "ProductionDate_lbl");
            this.ProductionDate_lbl.ControlId = null;
            this.ProductionDate_lbl.Name = "ProductionDate_lbl";
            // 
            // Weight_lbl
            // 
            resources.ApplyResources(this.Weight_lbl, "Weight_lbl");
            this.Weight_lbl.ControlId = null;
            this.Weight_lbl.Name = "Weight_lbl";
            // 
            // Weight_txt
            // 
            resources.ApplyResources(this.Weight_txt, "Weight_txt");
            this.Weight_txt.ControlId = null;
            this.Weight_txt.InputType = Com.Nidec.Mes.Framework.TextBoxCommon.InputTypeList.Numeric;
            this.Weight_txt.Name = "Weight_txt";
            // 
            // Height_lbl
            // 
            resources.ApplyResources(this.Height_lbl, "Height_lbl");
            this.Height_lbl.ControlId = null;
            this.Height_lbl.Name = "Height_lbl";
            // 
            // Height_txt
            // 
            resources.ApplyResources(this.Height_txt, "Height_txt");
            this.Height_txt.ControlId = null;
            this.Height_txt.InputType = Com.Nidec.Mes.Framework.TextBoxCommon.InputTypeList.Numeric;
            this.Height_txt.Name = "Height_txt";
            // 
            // Depth_lbl
            // 
            resources.ApplyResources(this.Depth_lbl, "Depth_lbl");
            this.Depth_lbl.ControlId = null;
            this.Depth_lbl.Name = "Depth_lbl";
            // 
            // Depth_txt
            // 
            resources.ApplyResources(this.Depth_txt, "Depth_txt");
            this.Depth_txt.ControlId = null;
            this.Depth_txt.InputType = Com.Nidec.Mes.Framework.TextBoxCommon.InputTypeList.Numeric;
            this.Depth_txt.Name = "Depth_txt";
            // 
            // Width_lbl
            // 
            resources.ApplyResources(this.Width_lbl, "Width_lbl");
            this.Width_lbl.ControlId = null;
            this.Width_lbl.Name = "Width_lbl";
            // 
            // Width_txt
            // 
            resources.ApplyResources(this.Width_txt, "Width_txt");
            this.Width_txt.ControlId = null;
            this.Width_txt.InputType = Com.Nidec.Mes.Framework.TextBoxCommon.InputTypeList.Numeric;
            this.Width_txt.Name = "Width_txt";
            // 
            // UpdateText_lbl
            // 
            resources.ApplyResources(this.UpdateText_lbl, "UpdateText_lbl");
            this.UpdateText_lbl.ControlId = null;
            this.UpdateText_lbl.Name = "UpdateText_lbl";
            // 
            // labelCommon3
            // 
            resources.ApplyResources(this.labelCommon3, "labelCommon3");
            this.labelCommon3.ControlId = null;
            this.labelCommon3.ForeColor = System.Drawing.Color.DarkRed;
            this.labelCommon3.Name = "labelCommon3";
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
            // MoldType_lbl
            // 
            resources.ApplyResources(this.MoldType_lbl, "MoldType_lbl");
            this.MoldType_lbl.ControlId = null;
            this.MoldType_lbl.Name = "MoldType_lbl";
            // 
            // MoldType_cmb
            // 
            resources.ApplyResources(this.MoldType_cmb, "MoldType_cmb");
            this.MoldType_cmb.ControlId = null;
            this.MoldType_cmb.FormattingEnabled = true;
            this.MoldType_cmb.Name = "MoldType_cmb";
            // 
            // MoldCode_txt
            // 
            resources.ApplyResources(this.MoldCode_txt, "MoldCode_txt");
            this.MoldCode_txt.ControlId = null;
            this.MoldCode_txt.InputType = Com.Nidec.Mes.Framework.TextBoxCommon.InputTypeList.All;
            this.MoldCode_txt.Name = "MoldCode_txt";
            // 
            // MoldName_lbl
            // 
            resources.ApplyResources(this.MoldName_lbl, "MoldName_lbl");
            this.MoldName_lbl.ControlId = null;
            this.MoldName_lbl.Name = "MoldName_lbl";
            // 
            // MoldName_txt
            // 
            resources.ApplyResources(this.MoldName_txt, "MoldName_txt");
            this.MoldName_txt.ControlId = null;
            this.MoldName_txt.InputType = Com.Nidec.Mes.Framework.TextBoxCommon.InputTypeList.All;
            this.MoldName_txt.Name = "MoldName_txt";
            // 
            // MoldCode_lbl
            // 
            resources.ApplyResources(this.MoldCode_lbl, "MoldCode_lbl");
            this.MoldCode_lbl.ControlId = null;
            this.MoldCode_lbl.Name = "MoldCode_lbl";
            // 
            // CheckAll_chk
            // 
            resources.ApplyResources(this.CheckAll_chk, "CheckAll_chk");
            this.CheckAll_chk.Name = "CheckAll_chk";
            this.CheckAll_chk.UseVisualStyleBackColor = true;
            this.CheckAll_chk.CheckedChanged += new System.EventHandler(this.CheckAll_chk_CheckedChanged);
            // 
            // AddMoldNewForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.CheckAll_chk);
            this.Controls.Add(this.Comment_lbl);
            this.Controls.Add(this.Comment_txt);
            this.Controls.Add(this.LifeShotCount_lbl);
            this.Controls.Add(this.LifeShotCount_txt);
            this.Controls.Add(this.ProductionDate_dtp);
            this.Controls.Add(this.ProductionDate_lbl);
            this.Controls.Add(this.Weight_lbl);
            this.Controls.Add(this.Weight_txt);
            this.Controls.Add(this.Height_lbl);
            this.Controls.Add(this.Height_txt);
            this.Controls.Add(this.Depth_lbl);
            this.Controls.Add(this.Depth_txt);
            this.Controls.Add(this.Width_lbl);
            this.Controls.Add(this.Width_txt);
            this.Controls.Add(this.UpdateText_lbl);
            this.Controls.Add(this.labelCommon3);
            this.Controls.Add(this.labelCommon1);
            this.Controls.Add(this.labelCommon2);
            this.Controls.Add(this.MoldType_lbl);
            this.Controls.Add(this.MoldType_cmb);
            this.Controls.Add(this.MoldCode_txt);
            this.Controls.Add(this.MoldName_lbl);
            this.Controls.Add(this.MoldName_txt);
            this.Controls.Add(this.MoldCode_lbl);
            this.Controls.Add(this.ProcessWork_dgv);
            this.Controls.Add(this.Exit_btn);
            this.Controls.Add(this.Ok_btn);
            this.Name = "AddMoldNewForm";
            this.TitleText = "FormCommon";
            this.Load += new System.EventHandler(this.AddMoldNewForm_Load);
            this.Controls.SetChildIndex(this.Ok_btn, 0);
            this.Controls.SetChildIndex(this.Exit_btn, 0);
            this.Controls.SetChildIndex(this.ProcessWork_dgv, 0);
            this.Controls.SetChildIndex(this.MoldCode_lbl, 0);
            this.Controls.SetChildIndex(this.MoldName_txt, 0);
            this.Controls.SetChildIndex(this.MoldName_lbl, 0);
            this.Controls.SetChildIndex(this.MoldCode_txt, 0);
            this.Controls.SetChildIndex(this.MoldType_cmb, 0);
            this.Controls.SetChildIndex(this.MoldType_lbl, 0);
            this.Controls.SetChildIndex(this.labelCommon2, 0);
            this.Controls.SetChildIndex(this.labelCommon1, 0);
            this.Controls.SetChildIndex(this.labelCommon3, 0);
            this.Controls.SetChildIndex(this.UpdateText_lbl, 0);
            this.Controls.SetChildIndex(this.Width_txt, 0);
            this.Controls.SetChildIndex(this.Width_lbl, 0);
            this.Controls.SetChildIndex(this.Depth_txt, 0);
            this.Controls.SetChildIndex(this.Depth_lbl, 0);
            this.Controls.SetChildIndex(this.Height_txt, 0);
            this.Controls.SetChildIndex(this.Height_lbl, 0);
            this.Controls.SetChildIndex(this.Weight_txt, 0);
            this.Controls.SetChildIndex(this.Weight_lbl, 0);
            this.Controls.SetChildIndex(this.ProductionDate_lbl, 0);
            this.Controls.SetChildIndex(this.ProductionDate_dtp, 0);
            this.Controls.SetChildIndex(this.LifeShotCount_txt, 0);
            this.Controls.SetChildIndex(this.LifeShotCount_lbl, 0);
            this.Controls.SetChildIndex(this.Comment_txt, 0);
            this.Controls.SetChildIndex(this.Comment_lbl, 0);
            this.Controls.SetChildIndex(this.CheckAll_chk, 0);
            ((System.ComponentModel.ISupportInitialize)(this.ProcessWork_dgv)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Com.Nidec.Mes.Framework.ButtonCommon Exit_btn;
        private Com.Nidec.Mes.Framework.ButtonCommon Ok_btn;
        internal Framework.DataGridViewCommon ProcessWork_dgv;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colSelect;
        private System.Windows.Forms.DataGridViewTextBoxColumn colProcessWorkId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colProcessWorkName;
        protected Framework.LabelCommon Comment_lbl;
        protected Framework.TextBoxCommon Comment_txt;
        protected Framework.LabelCommon LifeShotCount_lbl;
        protected Framework.TextBoxCommon LifeShotCount_txt;
        protected Framework.DateTimePickerCommon ProductionDate_dtp;
        protected Framework.LabelCommon ProductionDate_lbl;
        protected Framework.LabelCommon Weight_lbl;
        protected Framework.TextBoxCommon Weight_txt;
        protected Framework.LabelCommon Height_lbl;
        protected Framework.TextBoxCommon Height_txt;
        protected Framework.LabelCommon Depth_lbl;
        protected Framework.TextBoxCommon Depth_txt;
        protected Framework.LabelCommon Width_lbl;
        protected Framework.TextBoxCommon Width_txt;
        protected Framework.LabelCommon UpdateText_lbl;
        protected Framework.LabelCommon labelCommon3;
        protected Framework.LabelCommon labelCommon1;
        protected Framework.LabelCommon labelCommon2;
        protected Framework.LabelCommon MoldType_lbl;
        protected Framework.ComboBoxCommon MoldType_cmb;
        protected Framework.TextBoxCommon MoldCode_txt;
        protected Framework.LabelCommon MoldName_lbl;
        protected Framework.TextBoxCommon MoldName_txt;
        protected Framework.LabelCommon MoldCode_lbl;
        private System.Windows.Forms.CheckBox CheckAll_chk;
    }
}