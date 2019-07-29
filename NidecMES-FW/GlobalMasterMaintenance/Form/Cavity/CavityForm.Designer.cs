namespace Com.Nidec.Mes.GlobalMasterMaintenance
{
    partial class CavityForm : FormCommonMaster
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CavityForm));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.Mold_lbl = new Com.Nidec.Mes.Framework.LabelCommon();
            this.Mold_cmb = new Com.Nidec.Mes.Framework.ComboBoxCommon();
            this.CavityCode_txt = new Com.Nidec.Mes.Framework.TextBoxCommon();
            this.CavityName_lbl = new Com.Nidec.Mes.Framework.LabelCommon();
            this.CavityName_txt = new Com.Nidec.Mes.Framework.TextBoxCommon();
            this.CavityCode_lbl = new Com.Nidec.Mes.Framework.LabelCommon();
            this.Clear_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.Exit_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.Delete_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.Update_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.Add_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.Search_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.Cavity_dgv = new Com.Nidec.Mes.Framework.DataGridViewCommon();
            this.colCavityId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMold = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCavityName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCavityCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMoldId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.Cavity_dgv)).BeginInit();
            this.SuspendLayout();
            // 
            // Mold_lbl
            // 
            resources.ApplyResources(this.Mold_lbl, "Mold_lbl");
            this.Mold_lbl.ControlId = null;
            this.Mold_lbl.Name = "Mold_lbl";
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
            // CavityCode_txt
            // 
            resources.ApplyResources(this.CavityCode_txt, "CavityCode_txt");
            this.CavityCode_txt.ControlId = null;
            this.CavityCode_txt.InputType = Com.Nidec.Mes.Framework.TextBoxCommon.InputTypeList.All;
            this.CavityCode_txt.Name = "CavityCode_txt";
            // 
            // CavityName_lbl
            // 
            resources.ApplyResources(this.CavityName_lbl, "CavityName_lbl");
            this.CavityName_lbl.ControlId = null;
            this.CavityName_lbl.Name = "CavityName_lbl";
            // 
            // CavityName_txt
            // 
            resources.ApplyResources(this.CavityName_txt, "CavityName_txt");
            this.CavityName_txt.ControlId = null;
            this.CavityName_txt.InputType = Com.Nidec.Mes.Framework.TextBoxCommon.InputTypeList.All;
            this.CavityName_txt.Name = "CavityName_txt";
            // 
            // CavityCode_lbl
            // 
            resources.ApplyResources(this.CavityCode_lbl, "CavityCode_lbl");
            this.CavityCode_lbl.ControlId = null;
            this.CavityCode_lbl.Name = "CavityCode_lbl";
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
            // Cavity_dgv
            // 
            resources.ApplyResources(this.Cavity_dgv, "Cavity_dgv");
            this.Cavity_dgv.AllowUserToAddRows = false;
            this.Cavity_dgv.AllowUserToDeleteRows = false;
            this.Cavity_dgv.AllowUserToOrderColumns = true;
            this.Cavity_dgv.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(232)))), ((int)(((byte)(180)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.Cavity_dgv.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.Cavity_dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Cavity_dgv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colCavityId,
            this.colMold,
            this.colCavityName,
            this.colCavityCode,
            this.colMoldId});
            this.Cavity_dgv.ControlId = null;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.Cavity_dgv.DefaultCellStyle = dataGridViewCellStyle2;
            this.Cavity_dgv.EnableHeadersVisualStyles = false;
            this.Cavity_dgv.MultiSelect = false;
            this.Cavity_dgv.Name = "Cavity_dgv";
            this.Cavity_dgv.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(232)))), ((int)(((byte)(180)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.Cavity_dgv.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.Cavity_dgv.RowHeadersVisible = false;
            this.Cavity_dgv.RowTemplate.Height = 21;
            this.Cavity_dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.Cavity_dgv.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Cavity_dgv_CellClick);
            this.Cavity_dgv.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Cavity_dgv_CellDoubleClick);
            // 
            // colCavityId
            // 
            this.colCavityId.DataPropertyName = "CavityId";
            resources.ApplyResources(this.colCavityId, "colCavityId");
            this.colCavityId.Name = "colCavityId";
            this.colCavityId.ReadOnly = true;
            // 
            // colMold
            // 
            this.colMold.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colMold.DataPropertyName = "MoldCode";
            resources.ApplyResources(this.colMold, "colMold");
            this.colMold.Name = "colMold";
            this.colMold.ReadOnly = true;
            // 
            // colCavityName
            // 
            this.colCavityName.DataPropertyName = "CavityName";
            resources.ApplyResources(this.colCavityName, "colCavityName");
            this.colCavityName.Name = "colCavityName";
            this.colCavityName.ReadOnly = true;
            // 
            // colCavityCode
            // 
            this.colCavityCode.DataPropertyName = "CavityCode";
            resources.ApplyResources(this.colCavityCode, "colCavityCode");
            this.colCavityCode.Name = "colCavityCode";
            this.colCavityCode.ReadOnly = true;
            // 
            // colMoldId
            // 
            this.colMoldId.DataPropertyName = "MoldId";
            resources.ApplyResources(this.colMoldId, "colMoldId");
            this.colMoldId.Name = "colMoldId";
            this.colMoldId.ReadOnly = true;
            // 
            // CavityForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ControlId = "bpmf019";
            this.Controls.Add(this.Mold_lbl);
            this.Controls.Add(this.Mold_cmb);
            this.Controls.Add(this.CavityCode_txt);
            this.Controls.Add(this.CavityName_lbl);
            this.Controls.Add(this.CavityName_txt);
            this.Controls.Add(this.CavityCode_lbl);
            this.Controls.Add(this.Clear_btn);
            this.Controls.Add(this.Exit_btn);
            this.Controls.Add(this.Delete_btn);
            this.Controls.Add(this.Update_btn);
            this.Controls.Add(this.Add_btn);
            this.Controls.Add(this.Search_btn);
            this.Controls.Add(this.Cavity_dgv);
            this.Name = "CavityForm";
            this.TitleText = "FormCommon";
            this.Load += new System.EventHandler(this.CavityForm_Load);
            this.Controls.SetChildIndex(this.Cavity_dgv, 0);
            this.Controls.SetChildIndex(this.Search_btn, 0);
            this.Controls.SetChildIndex(this.Add_btn, 0);
            this.Controls.SetChildIndex(this.Update_btn, 0);
            this.Controls.SetChildIndex(this.Delete_btn, 0);
            this.Controls.SetChildIndex(this.Exit_btn, 0);
            this.Controls.SetChildIndex(this.Clear_btn, 0);
            this.Controls.SetChildIndex(this.CavityCode_lbl, 0);
            this.Controls.SetChildIndex(this.CavityName_txt, 0);
            this.Controls.SetChildIndex(this.CavityName_lbl, 0);
            this.Controls.SetChildIndex(this.CavityCode_txt, 0);
            this.Controls.SetChildIndex(this.Mold_cmb, 0);
            this.Controls.SetChildIndex(this.Mold_lbl, 0);
            ((System.ComponentModel.ISupportInitialize)(this.Cavity_dgv)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        protected Framework.LabelCommon Mold_lbl;
        protected Framework.ComboBoxCommon Mold_cmb;
        protected Framework.TextBoxCommon CavityCode_txt;
        protected Framework.LabelCommon CavityName_lbl;
        protected Framework.TextBoxCommon CavityName_txt;
        protected Framework.LabelCommon CavityCode_lbl;
        protected Framework.ButtonCommon Clear_btn;
        protected Framework.ButtonCommon Exit_btn;
        protected Framework.ButtonCommon Delete_btn;
        protected Framework.ButtonCommon Update_btn;
        protected Framework.ButtonCommon Add_btn;
        protected Framework.ButtonCommon Search_btn;
        protected Framework.DataGridViewCommon Cavity_dgv;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCavityId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMold;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCavityName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCavityCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMoldId;
    }
}