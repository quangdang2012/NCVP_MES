namespace Com.Nidec.Mes.GlobalMasterMaintenance
{
    partial class RoleForm : FormCommonMaster
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RoleForm));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.RoleCode_txt = new Com.Nidec.Mes.Framework.TextBoxCommon();
            this.RoleName_lbl = new Com.Nidec.Mes.Framework.LabelCommon();
            this.RoleName_txt = new Com.Nidec.Mes.Framework.TextBoxCommon();
            this.RoleCode_lbl = new Com.Nidec.Mes.Framework.LabelCommon();
            this.Clear_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.Exit_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.Delete_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.Update_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.Add_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.Search_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.RoleData_dgv = new Com.Nidec.Mes.Framework.DataGridViewCommon();
            this.colRoleCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colRoleName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.RoleData_dgv)).BeginInit();
            this.SuspendLayout();
            // 
            // RoleCode_txt
            // 
            this.RoleCode_txt.ControlId = null;
            resources.ApplyResources(this.RoleCode_txt, "RoleCode_txt");
            this.RoleCode_txt.InputType = Com.Nidec.Mes.Framework.TextBoxCommon.InputTypeList.All;
            this.RoleCode_txt.Name = "RoleCode_txt";
            // 
            // RoleName_lbl
            // 
            resources.ApplyResources(this.RoleName_lbl, "RoleName_lbl");
            this.RoleName_lbl.ControlId = null;
            this.RoleName_lbl.Name = "RoleName_lbl";
            // 
            // RoleName_txt
            // 
            this.RoleName_txt.ControlId = null;
            resources.ApplyResources(this.RoleName_txt, "RoleName_txt");
            this.RoleName_txt.InputType = Com.Nidec.Mes.Framework.TextBoxCommon.InputTypeList.All;
            this.RoleName_txt.Name = "RoleName_txt";
            // 
            // RoleCode_lbl
            // 
            resources.ApplyResources(this.RoleCode_lbl, "RoleCode_lbl");
            this.RoleCode_lbl.ControlId = null;
            this.RoleCode_lbl.Name = "RoleCode_lbl";
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
            // RoleData_dgv
            // 
            this.RoleData_dgv.AllowUserToAddRows = false;
            this.RoleData_dgv.AllowUserToDeleteRows = false;
            this.RoleData_dgv.AllowUserToOrderColumns = true;
            this.RoleData_dgv.AllowUserToResizeRows = false;
            resources.ApplyResources(this.RoleData_dgv, "RoleData_dgv");
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(232)))), ((int)(((byte)(180)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.RoleData_dgv.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.RoleData_dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.RoleData_dgv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colRoleCode,
            this.colRoleName});
            this.RoleData_dgv.ControlId = null;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.RoleData_dgv.DefaultCellStyle = dataGridViewCellStyle2;
            this.RoleData_dgv.EnableHeadersVisualStyles = false;
            this.RoleData_dgv.MultiSelect = false;
            this.RoleData_dgv.Name = "RoleData_dgv";
            this.RoleData_dgv.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(232)))), ((int)(((byte)(180)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.RoleData_dgv.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.RoleData_dgv.RowHeadersVisible = false;
            this.RoleData_dgv.RowTemplate.Height = 21;
            this.RoleData_dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.RoleData_dgv.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.RoleData_dgv_CellClick);
            this.RoleData_dgv.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.RoleData_dgv_CellDoubleClick);
            this.RoleData_dgv.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.RoleData_dgv_ColumnHeaderMouseClick);
            // 
            // colRoleCode
            // 
            this.colRoleCode.DataPropertyName = "RoleCode";
            this.colRoleCode.Frozen = true;
            resources.ApplyResources(this.colRoleCode, "colRoleCode");
            this.colRoleCode.Name = "colRoleCode";
            this.colRoleCode.ReadOnly = true;
            // 
            // colRoleName
            // 
            this.colRoleName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colRoleName.DataPropertyName = "RoleName";
            resources.ApplyResources(this.colRoleName, "colRoleName");
            this.colRoleName.Name = "colRoleName";
            this.colRoleName.ReadOnly = true;
            // 
            // RoleForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ControlId = "bpmf004";
            this.Controls.Add(this.RoleCode_txt);
            this.Controls.Add(this.RoleName_lbl);
            this.Controls.Add(this.RoleName_txt);
            this.Controls.Add(this.RoleCode_lbl);
            this.Controls.Add(this.Clear_btn);
            this.Controls.Add(this.Exit_btn);
            this.Controls.Add(this.Delete_btn);
            this.Controls.Add(this.Update_btn);
            this.Controls.Add(this.Add_btn);
            this.Controls.Add(this.Search_btn);
            this.Controls.Add(this.RoleData_dgv);
            this.Name = "RoleForm";
            this.TitleText = "FormCommon";
            this.Load += new System.EventHandler(this.RoleForm_Load);
            this.Controls.SetChildIndex(this.RoleData_dgv, 0);
            this.Controls.SetChildIndex(this.Search_btn, 0);
            this.Controls.SetChildIndex(this.Add_btn, 0);
            this.Controls.SetChildIndex(this.Update_btn, 0);
            this.Controls.SetChildIndex(this.Delete_btn, 0);
            this.Controls.SetChildIndex(this.Exit_btn, 0);
            this.Controls.SetChildIndex(this.Clear_btn, 0);
            this.Controls.SetChildIndex(this.RoleCode_lbl, 0);
            this.Controls.SetChildIndex(this.RoleName_txt, 0);
            this.Controls.SetChildIndex(this.RoleName_lbl, 0);
            this.Controls.SetChildIndex(this.RoleCode_txt, 0);
            ((System.ComponentModel.ISupportInitialize)(this.RoleData_dgv)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Com.Nidec.Mes.Framework.TextBoxCommon RoleCode_txt;
        private Com.Nidec.Mes.Framework.LabelCommon RoleName_lbl;
        private Com.Nidec.Mes.Framework.TextBoxCommon RoleName_txt;
        private Com.Nidec.Mes.Framework.LabelCommon RoleCode_lbl;
        private Com.Nidec.Mes.Framework.ButtonCommon Clear_btn;
        private Com.Nidec.Mes.Framework.ButtonCommon Exit_btn;
        private Com.Nidec.Mes.Framework.ButtonCommon Delete_btn;
        private Com.Nidec.Mes.Framework.ButtonCommon Update_btn;
        private Com.Nidec.Mes.Framework.ButtonCommon Add_btn;
        private Com.Nidec.Mes.Framework.ButtonCommon Search_btn;
        internal Com.Nidec.Mes.Framework.DataGridViewCommon RoleData_dgv;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRoleCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRoleName;
    }
}