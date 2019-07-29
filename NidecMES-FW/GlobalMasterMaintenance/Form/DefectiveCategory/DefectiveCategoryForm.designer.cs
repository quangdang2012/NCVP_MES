namespace Com.Nidec.Mes.GlobalMasterMaintenance
{
    partial class DefectiveCategoryForm: FormCommonMaster
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DefectiveCategoryForm));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.DefectiveCategoryCode_txt = new Com.Nidec.Mes.Framework.TextBoxCommon();
            this.DefectiveCategoryCode_lbl = new Com.Nidec.Mes.Framework.LabelCommon();
            this.DefectiveCategoryName_txt = new Com.Nidec.Mes.Framework.TextBoxCommon();
            this.DefectiveCategoryName_lbl = new Com.Nidec.Mes.Framework.LabelCommon();
            this.Add_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.Search_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.DefectiveCategoryDetails_dgv = new Com.Nidec.Mes.Framework.DataGridViewCommon();
            this.colDefectiveCategoryId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDefectiveCategoryCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDefectiveCategoryName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Exit_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.Delete_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.Update_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.Clear_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            ((System.ComponentModel.ISupportInitialize)(this.DefectiveCategoryDetails_dgv)).BeginInit();
            this.SuspendLayout();
            // 
            // DefectiveCategoryCode_txt
            // 
            this.DefectiveCategoryCode_txt.ControlId = null;
            resources.ApplyResources(this.DefectiveCategoryCode_txt, "DefectiveCategoryCode_txt");
            this.DefectiveCategoryCode_txt.InputType = Com.Nidec.Mes.Framework.TextBoxCommon.InputTypeList.All;
            this.DefectiveCategoryCode_txt.Name = "DefectiveCategoryCode_txt";
            // 
            // DefectiveCategoryCode_lbl
            // 
            resources.ApplyResources(this.DefectiveCategoryCode_lbl, "DefectiveCategoryCode_lbl");
            this.DefectiveCategoryCode_lbl.ControlId = null;
            this.DefectiveCategoryCode_lbl.Name = "DefectiveCategoryCode_lbl";
            // 
            // DefectiveCategoryName_txt
            // 
            this.DefectiveCategoryName_txt.ControlId = null;
            resources.ApplyResources(this.DefectiveCategoryName_txt, "DefectiveCategoryName_txt");
            this.DefectiveCategoryName_txt.InputType = Com.Nidec.Mes.Framework.TextBoxCommon.InputTypeList.All;
            this.DefectiveCategoryName_txt.Name = "DefectiveCategoryName_txt";
            // 
            // DefectiveCategoryName_lbl
            // 
            resources.ApplyResources(this.DefectiveCategoryName_lbl, "DefectiveCategoryName_lbl");
            this.DefectiveCategoryName_lbl.ControlId = null;
            this.DefectiveCategoryName_lbl.Name = "DefectiveCategoryName_lbl";
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
            // DefectiveCategoryDetails_dgv
            // 
            this.DefectiveCategoryDetails_dgv.AllowUserToAddRows = false;
            this.DefectiveCategoryDetails_dgv.AllowUserToDeleteRows = false;
            this.DefectiveCategoryDetails_dgv.AllowUserToOrderColumns = true;
            this.DefectiveCategoryDetails_dgv.AllowUserToResizeRows = false;
            resources.ApplyResources(this.DefectiveCategoryDetails_dgv, "DefectiveCategoryDetails_dgv");
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(232)))), ((int)(((byte)(180)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DefectiveCategoryDetails_dgv.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.DefectiveCategoryDetails_dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DefectiveCategoryDetails_dgv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colDefectiveCategoryId,
            this.colDefectiveCategoryCode,
            this.colDefectiveCategoryName});
            this.DefectiveCategoryDetails_dgv.ControlId = null;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DefectiveCategoryDetails_dgv.DefaultCellStyle = dataGridViewCellStyle2;
            this.DefectiveCategoryDetails_dgv.EnableHeadersVisualStyles = false;
            this.DefectiveCategoryDetails_dgv.MultiSelect = false;
            this.DefectiveCategoryDetails_dgv.Name = "DefectiveCategoryDetails_dgv";
            this.DefectiveCategoryDetails_dgv.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(232)))), ((int)(((byte)(180)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DefectiveCategoryDetails_dgv.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.DefectiveCategoryDetails_dgv.RowHeadersVisible = false;
            this.DefectiveCategoryDetails_dgv.RowTemplate.Height = 21;
            this.DefectiveCategoryDetails_dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DefectiveCategoryDetails_dgv.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DefectiveCategoryDetails_dgv_CellClick);
            this.DefectiveCategoryDetails_dgv.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DefectiveCategoryDetails_dgv_CellDoubleClick);
            // 
            // colDefectiveCategoryId
            // 
            this.colDefectiveCategoryId.DataPropertyName = "DefectiveCategoryId";
            resources.ApplyResources(this.colDefectiveCategoryId, "colDefectiveCategoryId");
            this.colDefectiveCategoryId.Name = "colDefectiveCategoryId";
            this.colDefectiveCategoryId.ReadOnly = true;
            // 
            // colDefectiveCategoryCode
            // 
            this.colDefectiveCategoryCode.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colDefectiveCategoryCode.DataPropertyName = "DefectiveCategoryCode";
            resources.ApplyResources(this.colDefectiveCategoryCode, "colDefectiveCategoryCode");
            this.colDefectiveCategoryCode.Name = "colDefectiveCategoryCode";
            this.colDefectiveCategoryCode.ReadOnly = true;
            // 
            // colDefectiveCategoryName
            // 
            this.colDefectiveCategoryName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colDefectiveCategoryName.DataPropertyName = "DefectiveCategoryName";
            resources.ApplyResources(this.colDefectiveCategoryName, "colDefectiveCategoryName");
            this.colDefectiveCategoryName.Name = "colDefectiveCategoryName";
            this.colDefectiveCategoryName.ReadOnly = true;
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
            this.Clear_btn.BackColor = System.Drawing.SystemColors.Control;
            this.Clear_btn.ControlId = null;
            resources.ApplyResources(this.Clear_btn, "Clear_btn");
            this.Clear_btn.Name = "Clear_btn";
            this.Clear_btn.UseVisualStyleBackColor = true;
            this.Clear_btn.Click += new System.EventHandler(this.Clear_btn_Click);
            // 
            // DefectiveCategoryForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ControlId = "bpmf006";
            this.Controls.Add(this.Clear_btn);
            this.Controls.Add(this.Exit_btn);
            this.Controls.Add(this.Delete_btn);
            this.Controls.Add(this.Update_btn);
            this.Controls.Add(this.DefectiveCategoryDetails_dgv);
            this.Controls.Add(this.Add_btn);
            this.Controls.Add(this.Search_btn);
            this.Controls.Add(this.DefectiveCategoryName_txt);
            this.Controls.Add(this.DefectiveCategoryName_lbl);
            this.Controls.Add(this.DefectiveCategoryCode_txt);
            this.Controls.Add(this.DefectiveCategoryCode_lbl);
            this.Name = "DefectiveCategoryForm";
            this.TitleText = "FormCommon";
            this.Load += new System.EventHandler(this.DefectiveCategoryForm_Load);
            this.Controls.SetChildIndex(this.DefectiveCategoryCode_lbl, 0);
            this.Controls.SetChildIndex(this.DefectiveCategoryCode_txt, 0);
            this.Controls.SetChildIndex(this.DefectiveCategoryName_lbl, 0);
            this.Controls.SetChildIndex(this.DefectiveCategoryName_txt, 0);
            this.Controls.SetChildIndex(this.Search_btn, 0);
            this.Controls.SetChildIndex(this.Add_btn, 0);
            this.Controls.SetChildIndex(this.DefectiveCategoryDetails_dgv, 0);
            this.Controls.SetChildIndex(this.Update_btn, 0);
            this.Controls.SetChildIndex(this.Delete_btn, 0);
            this.Controls.SetChildIndex(this.Exit_btn, 0);
            this.Controls.SetChildIndex(this.Clear_btn, 0);
            ((System.ComponentModel.ISupportInitialize)(this.DefectiveCategoryDetails_dgv)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Com.Nidec.Mes.Framework.TextBoxCommon DefectiveCategoryCode_txt;
        private Com.Nidec.Mes.Framework.LabelCommon DefectiveCategoryCode_lbl;
        private Com.Nidec.Mes.Framework.TextBoxCommon DefectiveCategoryName_txt;
        private Com.Nidec.Mes.Framework.LabelCommon DefectiveCategoryName_lbl;
        private Com.Nidec.Mes.Framework.ButtonCommon Add_btn;
        private Com.Nidec.Mes.Framework.ButtonCommon Search_btn;
        internal Com.Nidec.Mes.Framework.DataGridViewCommon DefectiveCategoryDetails_dgv;
        private Com.Nidec.Mes.Framework.ButtonCommon Exit_btn;
        private Com.Nidec.Mes.Framework.ButtonCommon Delete_btn;
        private Com.Nidec.Mes.Framework.ButtonCommon Update_btn;
        private Com.Nidec.Mes.Framework.ButtonCommon Clear_btn;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDefectiveCategoryId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDefectiveCategoryCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDefectiveCategoryName;
    }
}