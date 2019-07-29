namespace Com.Nidec.Mes.GlobalMasterMaintenance
{
    partial class AuthorityControlForm :FormCommonMaster
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AuthorityControlForm));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.Clear_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.Exit_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.Delete_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.Update_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.Add_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.Search_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.AuthorityControldetails_dgv = new Com.Nidec.Mes.Framework.DataGridViewCommon();
            this.colAuthorityControlCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAuthorityControlName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colParentControlCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ParentControl_lbl = new Com.Nidec.Mes.Framework.LabelCommon();
            this.AuthorityControlName_lbl = new Com.Nidec.Mes.Framework.LabelCommon();
            this.AuthorityControlName_txt = new Com.Nidec.Mes.Framework.TextBoxCommon();
            this.ParentControl_cmb = new Com.Nidec.Mes.Framework.ComboBoxCommon();
            this.AuthorityControlCode_txt = new Com.Nidec.Mes.Framework.TextBoxCommon();
            this.AuthorityControlCode_lbl = new Com.Nidec.Mes.Framework.LabelCommon();
            ((System.ComponentModel.ISupportInitialize)(this.AuthorityControldetails_dgv)).BeginInit();
            this.SuspendLayout();
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
            // AuthorityControldetails_dgv
            // 
            this.AuthorityControldetails_dgv.AllowUserToAddRows = false;
            this.AuthorityControldetails_dgv.AllowUserToDeleteRows = false;
            this.AuthorityControldetails_dgv.AllowUserToResizeRows = false;
            resources.ApplyResources(this.AuthorityControldetails_dgv, "AuthorityControldetails_dgv");
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(232)))), ((int)(((byte)(180)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.AuthorityControldetails_dgv.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.AuthorityControldetails_dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.AuthorityControldetails_dgv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colAuthorityControlCode,
            this.colAuthorityControlName,
            this.colParentControlCode});
            this.AuthorityControldetails_dgv.ControlId = null;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.AuthorityControldetails_dgv.DefaultCellStyle = dataGridViewCellStyle2;
            this.AuthorityControldetails_dgv.EnableHeadersVisualStyles = false;
            this.AuthorityControldetails_dgv.MultiSelect = false;
            this.AuthorityControldetails_dgv.Name = "AuthorityControldetails_dgv";
            this.AuthorityControldetails_dgv.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(232)))), ((int)(((byte)(180)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.AuthorityControldetails_dgv.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.AuthorityControldetails_dgv.RowHeadersVisible = false;
            this.AuthorityControldetails_dgv.RowTemplate.Height = 21;
            this.AuthorityControldetails_dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.AuthorityControldetails_dgv.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.AuthorityControldetails_dgv_CellClick);
            this.AuthorityControldetails_dgv.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.AuthorityControldetails_dgv_CellDoubleClick);
            this.AuthorityControldetails_dgv.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.AuthorityControldetails_dgv_ColumnHeaderMouseClick);
            // 
            // colAuthorityControlCode
            // 
            this.colAuthorityControlCode.DataPropertyName = "AuthorityControlCode";
            this.colAuthorityControlCode.Frozen = true;
            resources.ApplyResources(this.colAuthorityControlCode, "colAuthorityControlCode");
            this.colAuthorityControlCode.Name = "colAuthorityControlCode";
            this.colAuthorityControlCode.ReadOnly = true;
            // 
            // colAuthorityControlName
            // 
            this.colAuthorityControlName.DataPropertyName = "AuthorityControlName";
            this.colAuthorityControlName.Frozen = true;
            resources.ApplyResources(this.colAuthorityControlName, "colAuthorityControlName");
            this.colAuthorityControlName.Name = "colAuthorityControlName";
            this.colAuthorityControlName.ReadOnly = true;
            // 
            // colParentControlCode
            // 
            this.colParentControlCode.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colParentControlCode.DataPropertyName = "ParentControlCode";
            resources.ApplyResources(this.colParentControlCode, "colParentControlCode");
            this.colParentControlCode.Name = "colParentControlCode";
            this.colParentControlCode.ReadOnly = true;
            // 
            // ParentControl_lbl
            // 
            resources.ApplyResources(this.ParentControl_lbl, "ParentControl_lbl");
            this.ParentControl_lbl.ControlId = null;
            this.ParentControl_lbl.Name = "ParentControl_lbl";
            // 
            // AuthorityControlName_lbl
            // 
            resources.ApplyResources(this.AuthorityControlName_lbl, "AuthorityControlName_lbl");
            this.AuthorityControlName_lbl.ControlId = null;
            this.AuthorityControlName_lbl.Name = "AuthorityControlName_lbl";
            // 
            // AuthorityControlName_txt
            // 
            this.AuthorityControlName_txt.ControlId = null;
            resources.ApplyResources(this.AuthorityControlName_txt, "AuthorityControlName_txt");
            this.AuthorityControlName_txt.InputType = Com.Nidec.Mes.Framework.TextBoxCommon.InputTypeList.All;
            this.AuthorityControlName_txt.Name = "AuthorityControlName_txt";
            // 
            // ParentControl_cmb
            // 
            this.ParentControl_cmb.ControlId = null;
            resources.ApplyResources(this.ParentControl_cmb, "ParentControl_cmb");
            this.ParentControl_cmb.FormattingEnabled = true;
            this.ParentControl_cmb.Name = "ParentControl_cmb";
            // 
            // AuthorityControlCode_txt
            // 
            this.AuthorityControlCode_txt.ControlId = null;
            resources.ApplyResources(this.AuthorityControlCode_txt, "AuthorityControlCode_txt");
            this.AuthorityControlCode_txt.InputType = Com.Nidec.Mes.Framework.TextBoxCommon.InputTypeList.All;
            this.AuthorityControlCode_txt.Name = "AuthorityControlCode_txt";
            // 
            // AuthorityControlCode_lbl
            // 
            resources.ApplyResources(this.AuthorityControlCode_lbl, "AuthorityControlCode_lbl");
            this.AuthorityControlCode_lbl.ControlId = null;
            this.AuthorityControlCode_lbl.Name = "AuthorityControlCode_lbl";
            // 
            // AuthorityControlForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ControlId = "bpmf017";
            this.Controls.Add(this.Clear_btn);
            this.Controls.Add(this.Exit_btn);
            this.Controls.Add(this.Delete_btn);
            this.Controls.Add(this.Update_btn);
            this.Controls.Add(this.Add_btn);
            this.Controls.Add(this.Search_btn);
            this.Controls.Add(this.AuthorityControldetails_dgv);
            this.Controls.Add(this.ParentControl_lbl);
            this.Controls.Add(this.AuthorityControlName_lbl);
            this.Controls.Add(this.AuthorityControlName_txt);
            this.Controls.Add(this.ParentControl_cmb);
            this.Controls.Add(this.AuthorityControlCode_txt);
            this.Controls.Add(this.AuthorityControlCode_lbl);
            this.Name = "AuthorityControlForm";
            this.TitleText = "FormCommon";
            this.Load += new System.EventHandler(this.AuthorityControlForm_Load);
            this.Controls.SetChildIndex(this.AuthorityControlCode_lbl, 0);
            this.Controls.SetChildIndex(this.AuthorityControlCode_txt, 0);
            this.Controls.SetChildIndex(this.ParentControl_cmb, 0);
            this.Controls.SetChildIndex(this.AuthorityControlName_txt, 0);
            this.Controls.SetChildIndex(this.AuthorityControlName_lbl, 0);
            this.Controls.SetChildIndex(this.ParentControl_lbl, 0);
            this.Controls.SetChildIndex(this.AuthorityControldetails_dgv, 0);
            this.Controls.SetChildIndex(this.Search_btn, 0);
            this.Controls.SetChildIndex(this.Add_btn, 0);
            this.Controls.SetChildIndex(this.Update_btn, 0);
            this.Controls.SetChildIndex(this.Delete_btn, 0);
            this.Controls.SetChildIndex(this.Exit_btn, 0);
            this.Controls.SetChildIndex(this.Clear_btn, 0);
            ((System.ComponentModel.ISupportInitialize)(this.AuthorityControldetails_dgv)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Com.Nidec.Mes.Framework.ButtonCommon Clear_btn;
        private Com.Nidec.Mes.Framework.ButtonCommon Exit_btn;
        private Com.Nidec.Mes.Framework.ButtonCommon Delete_btn;
        private Com.Nidec.Mes.Framework.ButtonCommon Update_btn;
        private Com.Nidec.Mes.Framework.ButtonCommon Add_btn;
        private Com.Nidec.Mes.Framework.ButtonCommon Search_btn;
        internal Com.Nidec.Mes.Framework.DataGridViewCommon AuthorityControldetails_dgv;
        private Com.Nidec.Mes.Framework.LabelCommon ParentControl_lbl;
        private Com.Nidec.Mes.Framework.LabelCommon AuthorityControlName_lbl;
        private Com.Nidec.Mes.Framework.TextBoxCommon AuthorityControlName_txt;
        private Com.Nidec.Mes.Framework.ComboBoxCommon ParentControl_cmb;
        private Com.Nidec.Mes.Framework.TextBoxCommon AuthorityControlCode_txt;
        private Com.Nidec.Mes.Framework.LabelCommon AuthorityControlCode_lbl;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAuthorityControlCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAuthorityControlName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colParentControlCode;
    }
}