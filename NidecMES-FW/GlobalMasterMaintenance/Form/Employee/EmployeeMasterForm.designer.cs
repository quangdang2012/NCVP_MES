namespace Com.Nidec.Mes.GlobalMasterMaintenance
{
    partial class EmployeeMasterForm: FormCommonMaster
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EmployeeMasterForm));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.EmployeeCode_txt = new Com.Nidec.Mes.Framework.TextBoxCommon();
            this.EmployeeCode_lbl = new Com.Nidec.Mes.Framework.LabelCommon();
            this.EmployeeName_txt = new Com.Nidec.Mes.Framework.TextBoxCommon();
            this.EmployeeName_lbl = new Com.Nidec.Mes.Framework.LabelCommon();
            this.Add_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.Search_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.EmployeeDetails_dgv = new Com.Nidec.Mes.Framework.DataGridViewCommon();
            this.Exit_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.Delete_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.Update_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.Clear_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.colEmployeeCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEmployeeName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.EmployeeDetails_dgv)).BeginInit();
            this.SuspendLayout();
            // 
            // EmployeeCode_txt
            // 
            this.EmployeeCode_txt.ControlId = null;
            resources.ApplyResources(this.EmployeeCode_txt, "EmployeeCode_txt");
            this.EmployeeCode_txt.InputType = Com.Nidec.Mes.Framework.TextBoxCommon.InputTypeList.All;
            this.EmployeeCode_txt.Name = "EmployeeCode_txt";
            // 
            // EmployeeCode_lbl
            // 
            resources.ApplyResources(this.EmployeeCode_lbl, "EmployeeCode_lbl");
            this.EmployeeCode_lbl.ControlId = null;
            this.EmployeeCode_lbl.Name = "EmployeeCode_lbl";
            // 
            // EmployeeName_txt
            // 
            this.EmployeeName_txt.ControlId = null;
            resources.ApplyResources(this.EmployeeName_txt, "EmployeeName_txt");
            this.EmployeeName_txt.InputType = Com.Nidec.Mes.Framework.TextBoxCommon.InputTypeList.All;
            this.EmployeeName_txt.Name = "EmployeeName_txt";
            // 
            // EmployeeName_lbl
            // 
            resources.ApplyResources(this.EmployeeName_lbl, "EmployeeName_lbl");
            this.EmployeeName_lbl.ControlId = null;
            this.EmployeeName_lbl.Name = "EmployeeName_lbl";
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
            // EmployeeDetails_dgv
            // 
            this.EmployeeDetails_dgv.AllowUserToAddRows = false;
            this.EmployeeDetails_dgv.AllowUserToDeleteRows = false;
            this.EmployeeDetails_dgv.AllowUserToOrderColumns = true;
            this.EmployeeDetails_dgv.AllowUserToResizeRows = false;
            resources.ApplyResources(this.EmployeeDetails_dgv, "EmployeeDetails_dgv");
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(232)))), ((int)(((byte)(180)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.EmployeeDetails_dgv.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.EmployeeDetails_dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.EmployeeDetails_dgv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colEmployeeCode,
            this.colEmployeeName});
            this.EmployeeDetails_dgv.ControlId = null;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.EmployeeDetails_dgv.DefaultCellStyle = dataGridViewCellStyle2;
            this.EmployeeDetails_dgv.EnableHeadersVisualStyles = false;
            this.EmployeeDetails_dgv.MultiSelect = false;
            this.EmployeeDetails_dgv.Name = "EmployeeDetails_dgv";
            this.EmployeeDetails_dgv.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(232)))), ((int)(((byte)(180)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.EmployeeDetails_dgv.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.EmployeeDetails_dgv.RowHeadersVisible = false;
            this.EmployeeDetails_dgv.RowTemplate.Height = 21;
            this.EmployeeDetails_dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.EmployeeDetails_dgv.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.LineDetails_dgv_CellClick);
            this.EmployeeDetails_dgv.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.LineDetails_dgv_CellDoubleClick);
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
            // colEmployeeCode
            // 
            this.colEmployeeCode.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colEmployeeCode.DataPropertyName = "EmployeeCode";
            resources.ApplyResources(this.colEmployeeCode, "colEmployeeCode");
            this.colEmployeeCode.Name = "colEmployeeCode";
            this.colEmployeeCode.ReadOnly = true;
            // 
            // colEmployeeName
            // 
            this.colEmployeeName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colEmployeeName.DataPropertyName = "EmployeeName";
            resources.ApplyResources(this.colEmployeeName, "colEmployeeName");
            this.colEmployeeName.Name = "colEmployeeName";
            this.colEmployeeName.ReadOnly = true;
            // 
            // EmployeeMasterForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ControlId = "bpmf006";
            this.Controls.Add(this.Clear_btn);
            this.Controls.Add(this.Exit_btn);
            this.Controls.Add(this.Delete_btn);
            this.Controls.Add(this.Update_btn);
            this.Controls.Add(this.EmployeeDetails_dgv);
            this.Controls.Add(this.Add_btn);
            this.Controls.Add(this.Search_btn);
            this.Controls.Add(this.EmployeeName_txt);
            this.Controls.Add(this.EmployeeName_lbl);
            this.Controls.Add(this.EmployeeCode_txt);
            this.Controls.Add(this.EmployeeCode_lbl);
            this.Name = "EmployeeMasterForm";
            this.TitleText = "FormCommon";
            this.Load += new System.EventHandler(this.EmployeeMasterForm_Load);
            this.Controls.SetChildIndex(this.EmployeeCode_lbl, 0);
            this.Controls.SetChildIndex(this.EmployeeCode_txt, 0);
            this.Controls.SetChildIndex(this.EmployeeName_lbl, 0);
            this.Controls.SetChildIndex(this.EmployeeName_txt, 0);
            this.Controls.SetChildIndex(this.Search_btn, 0);
            this.Controls.SetChildIndex(this.Add_btn, 0);
            this.Controls.SetChildIndex(this.EmployeeDetails_dgv, 0);
            this.Controls.SetChildIndex(this.Update_btn, 0);
            this.Controls.SetChildIndex(this.Delete_btn, 0);
            this.Controls.SetChildIndex(this.Exit_btn, 0);
            this.Controls.SetChildIndex(this.Clear_btn, 0);
            ((System.ComponentModel.ISupportInitialize)(this.EmployeeDetails_dgv)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Com.Nidec.Mes.Framework.TextBoxCommon EmployeeCode_txt;
        private Com.Nidec.Mes.Framework.LabelCommon EmployeeCode_lbl;
        private Com.Nidec.Mes.Framework.TextBoxCommon EmployeeName_txt;
        private Com.Nidec.Mes.Framework.LabelCommon EmployeeName_lbl;
        private Com.Nidec.Mes.Framework.ButtonCommon Add_btn;
        private Com.Nidec.Mes.Framework.ButtonCommon Search_btn;
        internal Com.Nidec.Mes.Framework.DataGridViewCommon EmployeeDetails_dgv;
        private Com.Nidec.Mes.Framework.ButtonCommon Exit_btn;
        private Com.Nidec.Mes.Framework.ButtonCommon Delete_btn;
        private Com.Nidec.Mes.Framework.ButtonCommon Update_btn;
        private Com.Nidec.Mes.Framework.ButtonCommon Clear_btn;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEmployeeCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEmployeeName;
    }
}