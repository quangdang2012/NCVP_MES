namespace Com.Nidec.Mes.GlobalMasterMaintenance
{
    partial class SapUserMasterForm : FormCommonMaster
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SapUserMasterForm));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.SapUser_lbl = new Com.Nidec.Mes.Framework.LabelCommon();
            this.UserName_lbl = new Com.Nidec.Mes.Framework.LabelCommon();
            this.SapUserName_txt = new Com.Nidec.Mes.Framework.TextBoxCommon();
            this.UserName_cmb = new Com.Nidec.Mes.Framework.ComboBoxCommon();
            this.SapUserdetails_dgv = new Com.Nidec.Mes.Framework.DataGridViewCommon();
            this.Clear_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.Exit_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.Delete_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.Update_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.Add_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.Search_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.colSapUserId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colUserCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colUserName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSapUser = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.SapUserdetails_dgv)).BeginInit();
            this.SuspendLayout();
            // 
            // SapUser_lbl
            // 
            resources.ApplyResources(this.SapUser_lbl, "SapUser_lbl");
            this.SapUser_lbl.ControlId = null;
            this.SapUser_lbl.Name = "SapUser_lbl";
            // 
            // UserName_lbl
            // 
            resources.ApplyResources(this.UserName_lbl, "UserName_lbl");
            this.UserName_lbl.ControlId = null;
            this.UserName_lbl.Name = "UserName_lbl";
            // 
            // SapUserName_txt
            // 
            resources.ApplyResources(this.SapUserName_txt, "SapUserName_txt");
            this.SapUserName_txt.ControlId = null;
            this.SapUserName_txt.InputType = Com.Nidec.Mes.Framework.TextBoxCommon.InputTypeList.All;
            this.SapUserName_txt.Name = "SapUserName_txt";
            // 
            // UserName_cmb
            // 
            resources.ApplyResources(this.UserName_cmb, "UserName_cmb");
            this.UserName_cmb.ControlId = null;
            this.UserName_cmb.FormattingEnabled = true;
            this.UserName_cmb.Name = "UserName_cmb";
            // 
            // SapUserdetails_dgv
            // 
            resources.ApplyResources(this.SapUserdetails_dgv, "SapUserdetails_dgv");
            this.SapUserdetails_dgv.AllowUserToAddRows = false;
            this.SapUserdetails_dgv.AllowUserToDeleteRows = false;
            this.SapUserdetails_dgv.AllowUserToResizeRows = false;
            this.SapUserdetails_dgv.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(232)))), ((int)(((byte)(180)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.SapUserdetails_dgv.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.SapUserdetails_dgv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colSapUserId,
            this.colUserCode,
            this.colUserName,
            this.colSapUser});
            this.SapUserdetails_dgv.ControlId = null;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.SapUserdetails_dgv.DefaultCellStyle = dataGridViewCellStyle2;
            this.SapUserdetails_dgv.EnableHeadersVisualStyles = false;
            this.SapUserdetails_dgv.MultiSelect = false;
            this.SapUserdetails_dgv.Name = "SapUserdetails_dgv";
            this.SapUserdetails_dgv.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(232)))), ((int)(((byte)(180)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.SapUserdetails_dgv.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.SapUserdetails_dgv.RowHeadersVisible = false;
            this.SapUserdetails_dgv.RowTemplate.Height = 21;
            this.SapUserdetails_dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.SapUserdetails_dgv.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.SapUserdetails_dgv_CellClick);
            this.SapUserdetails_dgv.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.SapUserdetails_dgv_CellDoubleClick);
            this.SapUserdetails_dgv.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.SapUserdetails_dgv_ColumnHeaderMouseClick);
            // 
            // Clear_btn
            // 
            resources.ApplyResources(this.Clear_btn, "Clear_btn");
            this.Clear_btn.BackColor = System.Drawing.SystemColors.Control;
            this.Clear_btn.ControlId = null;
            this.Clear_btn.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Clear_btn.Name = "Clear_btn";
            this.Clear_btn.UseVisualStyleBackColor = true;
            this.Clear_btn.Click += new System.EventHandler(this.Clear_btn_Click);
            // 
            // Exit_btn
            // 
            resources.ApplyResources(this.Exit_btn, "Exit_btn");
            this.Exit_btn.BackColor = System.Drawing.SystemColors.Control;
            this.Exit_btn.ControlId = null;
            this.Exit_btn.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Exit_btn.Name = "Exit_btn";
            this.Exit_btn.UseVisualStyleBackColor = true;
            this.Exit_btn.Click += new System.EventHandler(this.Exit_btn_Click);
            // 
            // Delete_btn
            // 
            resources.ApplyResources(this.Delete_btn, "Delete_btn");
            this.Delete_btn.BackColor = System.Drawing.SystemColors.Control;
            this.Delete_btn.ControlId = null;
            this.Delete_btn.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Delete_btn.Name = "Delete_btn";
            this.Delete_btn.UseVisualStyleBackColor = true;
            this.Delete_btn.Click += new System.EventHandler(this.Delete_btn_Click);
            // 
            // Update_btn
            // 
            resources.ApplyResources(this.Update_btn, "Update_btn");
            this.Update_btn.BackColor = System.Drawing.SystemColors.Control;
            this.Update_btn.ControlId = null;
            this.Update_btn.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Update_btn.Name = "Update_btn";
            this.Update_btn.UseVisualStyleBackColor = true;
            this.Update_btn.Click += new System.EventHandler(this.Update_btn_Click);
            // 
            // Add_btn
            // 
            resources.ApplyResources(this.Add_btn, "Add_btn");
            this.Add_btn.BackColor = System.Drawing.SystemColors.Control;
            this.Add_btn.ControlId = "BTN_01_01";
            this.Add_btn.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Add_btn.Name = "Add_btn";
            this.Add_btn.UseVisualStyleBackColor = true;
            this.Add_btn.Click += new System.EventHandler(this.Add_btn_Click);
            // 
            // Search_btn
            // 
            resources.ApplyResources(this.Search_btn, "Search_btn");
            this.Search_btn.BackColor = System.Drawing.SystemColors.Control;
            this.Search_btn.ControlId = "BTN_01_02";
            this.Search_btn.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Search_btn.Name = "Search_btn";
            this.Search_btn.UseVisualStyleBackColor = true;
            this.Search_btn.Click += new System.EventHandler(this.Search_btn_Click);
            // 
            // colSapUserId
            // 
            this.colSapUserId.DataPropertyName = "SapUserId";
            this.colSapUserId.Frozen = true;
            resources.ApplyResources(this.colSapUserId, "colSapUserId");
            this.colSapUserId.Name = "colSapUserId";
            this.colSapUserId.ReadOnly = true;
            // 
            // colUserCode
            // 
            this.colUserCode.DataPropertyName = "MesUserCode";
            this.colUserCode.Frozen = true;
            resources.ApplyResources(this.colUserCode, "colUserCode");
            this.colUserCode.Name = "colUserCode";
            this.colUserCode.ReadOnly = true;
            // 
            // colUserName
            // 
            this.colUserName.DataPropertyName = "UserName";
            this.colUserName.FillWeight = 140F;
            this.colUserName.Frozen = true;
            resources.ApplyResources(this.colUserName, "colUserName");
            this.colUserName.Name = "colUserName";
            this.colUserName.ReadOnly = true;
            // 
            // colSapUser
            // 
            this.colSapUser.DataPropertyName = "SapUser";
            this.colSapUser.FillWeight = 32.46753F;
            this.colSapUser.Frozen = true;
            resources.ApplyResources(this.colSapUser, "colSapUser");
            this.colSapUser.Name = "colSapUser";
            this.colSapUser.ReadOnly = true;
            // 
            // SapUserMasterForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ControlId = "bpmf003";
            this.Controls.Add(this.Clear_btn);
            this.Controls.Add(this.Exit_btn);
            this.Controls.Add(this.Delete_btn);
            this.Controls.Add(this.Update_btn);
            this.Controls.Add(this.Add_btn);
            this.Controls.Add(this.Search_btn);
            this.Controls.Add(this.SapUserdetails_dgv);
            this.Controls.Add(this.SapUser_lbl);
            this.Controls.Add(this.UserName_lbl);
            this.Controls.Add(this.SapUserName_txt);
            this.Controls.Add(this.UserName_cmb);
            this.Name = "SapUserMasterForm";
            this.TitleText = "FormCommon";
            this.Load += new System.EventHandler(this.SapUserMasterForm_Load);
            this.Controls.SetChildIndex(this.UserName_cmb, 0);
            this.Controls.SetChildIndex(this.SapUserName_txt, 0);
            this.Controls.SetChildIndex(this.UserName_lbl, 0);
            this.Controls.SetChildIndex(this.SapUser_lbl, 0);
            this.Controls.SetChildIndex(this.SapUserdetails_dgv, 0);
            this.Controls.SetChildIndex(this.Search_btn, 0);
            this.Controls.SetChildIndex(this.Add_btn, 0);
            this.Controls.SetChildIndex(this.Update_btn, 0);
            this.Controls.SetChildIndex(this.Delete_btn, 0);
            this.Controls.SetChildIndex(this.Exit_btn, 0);
            this.Controls.SetChildIndex(this.Clear_btn, 0);
            ((System.ComponentModel.ISupportInitialize)(this.SapUserdetails_dgv)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Com.Nidec.Mes.Framework.LabelCommon SapUser_lbl;
        private Com.Nidec.Mes.Framework.LabelCommon UserName_lbl;
        private Com.Nidec.Mes.Framework.TextBoxCommon SapUserName_txt;
        private Com.Nidec.Mes.Framework.ComboBoxCommon UserName_cmb;
        internal Com.Nidec.Mes.Framework.DataGridViewCommon SapUserdetails_dgv;
        private Com.Nidec.Mes.Framework.ButtonCommon Search_btn;
        private Com.Nidec.Mes.Framework.ButtonCommon Add_btn;
        private Com.Nidec.Mes.Framework.ButtonCommon Update_btn;
        private Com.Nidec.Mes.Framework.ButtonCommon Delete_btn;
        private Com.Nidec.Mes.Framework.ButtonCommon Exit_btn;
        private Com.Nidec.Mes.Framework.ButtonCommon Clear_btn;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSapUserId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colUserCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn colUserName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSapUser;
    }
}