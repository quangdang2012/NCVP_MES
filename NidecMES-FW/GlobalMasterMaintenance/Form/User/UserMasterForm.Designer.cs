namespace Com.Nidec.Mes.GlobalMasterMaintenance
{
    partial class UserMasterForm:FormCommonMaster
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserMasterForm));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.FactoryCode_cmb = new Com.Nidec.Mes.Framework.ComboBoxCommon();
            this.FactoryCode_lbl = new Com.Nidec.Mes.Framework.LabelCommon();
            this.Country_lbl = new Com.Nidec.Mes.Framework.LabelCommon();
            this.UserName_lbl = new Com.Nidec.Mes.Framework.LabelCommon();
            this.UserName_txt = new Com.Nidec.Mes.Framework.TextBoxCommon();
            this.Country_cmb = new Com.Nidec.Mes.Framework.ComboBoxCommon();
            this.UserCode_txt = new Com.Nidec.Mes.Framework.TextBoxCommon();
            this.UserCode_lbl = new Com.Nidec.Mes.Framework.LabelCommon();
            this.Userdetails_dgv = new Com.Nidec.Mes.Framework.DataGridViewCommon();
            this.colUserCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colUserName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCountry = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLocaleId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMultiLogin = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFactoryCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Clear_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.Exit_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.Delete_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.Update_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.Add_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.Search_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            ((System.ComponentModel.ISupportInitialize)(this.Userdetails_dgv)).BeginInit();
            this.SuspendLayout();
            // 
            // FactoryCode_cmb
            // 
            this.FactoryCode_cmb.ControlId = null;
            resources.ApplyResources(this.FactoryCode_cmb, "FactoryCode_cmb");
            this.FactoryCode_cmb.FormattingEnabled = true;
            this.FactoryCode_cmb.Name = "FactoryCode_cmb";
            // 
            // FactoryCode_lbl
            // 
            resources.ApplyResources(this.FactoryCode_lbl, "FactoryCode_lbl");
            this.FactoryCode_lbl.ControlId = null;
            this.FactoryCode_lbl.Name = "FactoryCode_lbl";
            // 
            // Country_lbl
            // 
            resources.ApplyResources(this.Country_lbl, "Country_lbl");
            this.Country_lbl.ControlId = null;
            this.Country_lbl.Name = "Country_lbl";
            // 
            // UserName_lbl
            // 
            resources.ApplyResources(this.UserName_lbl, "UserName_lbl");
            this.UserName_lbl.ControlId = null;
            this.UserName_lbl.Name = "UserName_lbl";
            // 
            // UserName_txt
            // 
            this.UserName_txt.ControlId = null;
            resources.ApplyResources(this.UserName_txt, "UserName_txt");
            this.UserName_txt.InputType = Com.Nidec.Mes.Framework.TextBoxCommon.InputTypeList.All;
            this.UserName_txt.Name = "UserName_txt";
            // 
            // Country_cmb
            // 
            this.Country_cmb.ControlId = null;
            resources.ApplyResources(this.Country_cmb, "Country_cmb");
            this.Country_cmb.FormattingEnabled = true;
            this.Country_cmb.Name = "Country_cmb";
            this.Country_cmb.SelectedIndexChanged += new System.EventHandler(this.Country_cmb_SelectedIndexChanged);
            this.Country_cmb.Leave += new System.EventHandler(this.Country_cmb_Leave);
            // 
            // UserCode_txt
            // 
            this.UserCode_txt.ControlId = null;
            resources.ApplyResources(this.UserCode_txt, "UserCode_txt");
            this.UserCode_txt.InputType = Com.Nidec.Mes.Framework.TextBoxCommon.InputTypeList.All;
            this.UserCode_txt.Name = "UserCode_txt";
            // 
            // UserCode_lbl
            // 
            resources.ApplyResources(this.UserCode_lbl, "UserCode_lbl");
            this.UserCode_lbl.BackColor = System.Drawing.Color.Transparent;
            this.UserCode_lbl.ControlId = null;
            this.UserCode_lbl.Name = "UserCode_lbl";
            // 
            // Userdetails_dgv
            // 
            this.Userdetails_dgv.AllowUserToAddRows = false;
            this.Userdetails_dgv.AllowUserToDeleteRows = false;
            this.Userdetails_dgv.AllowUserToResizeRows = false;
            resources.ApplyResources(this.Userdetails_dgv, "Userdetails_dgv");
            this.Userdetails_dgv.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(232)))), ((int)(((byte)(180)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.Userdetails_dgv.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.Userdetails_dgv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colUserCode,
            this.colUserName,
            this.colCountry,
            this.colLocaleId,
            this.colMultiLogin,
            this.colFactoryCode});
            this.Userdetails_dgv.ControlId = null;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.Userdetails_dgv.DefaultCellStyle = dataGridViewCellStyle3;
            this.Userdetails_dgv.EnableHeadersVisualStyles = false;
            this.Userdetails_dgv.MultiSelect = false;
            this.Userdetails_dgv.Name = "Userdetails_dgv";
            this.Userdetails_dgv.ReadOnly = true;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(232)))), ((int)(((byte)(180)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.Userdetails_dgv.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.Userdetails_dgv.RowHeadersVisible = false;
            this.Userdetails_dgv.RowTemplate.Height = 21;
            this.Userdetails_dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.Userdetails_dgv.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.TableDetails_dgv_CellClick);
            this.Userdetails_dgv.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.TableDetails_dgv_CellDoubleClick);
            this.Userdetails_dgv.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.Userdetails_dgv_ColumnHeaderMouseClick);
            // 
            // colUserCode
            // 
            this.colUserCode.DataPropertyName = "UserCode";
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
            // colCountry
            // 
            this.colCountry.DataPropertyName = "Country";
            this.colCountry.FillWeight = 32.46753F;
            this.colCountry.Frozen = true;
            resources.ApplyResources(this.colCountry, "colCountry");
            this.colCountry.Name = "colCountry";
            this.colCountry.ReadOnly = true;
            // 
            // colLocaleId
            // 
            this.colLocaleId.DataPropertyName = "LocaleId";
            this.colLocaleId.FillWeight = 32.46753F;
            this.colLocaleId.Frozen = true;
            resources.ApplyResources(this.colLocaleId, "colLocaleId");
            this.colLocaleId.Name = "colLocaleId";
            this.colLocaleId.ReadOnly = true;
            // 
            // colMultiLogin
            // 
            this.colMultiLogin.DataPropertyName = "MultiLoginFlag";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.colMultiLogin.DefaultCellStyle = dataGridViewCellStyle2;
            this.colMultiLogin.FillWeight = 32.46753F;
            this.colMultiLogin.Frozen = true;
            resources.ApplyResources(this.colMultiLogin, "colMultiLogin");
            this.colMultiLogin.Name = "colMultiLogin";
            this.colMultiLogin.ReadOnly = true;
            // 
            // colFactoryCode
            // 
            this.colFactoryCode.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colFactoryCode.DataPropertyName = "RegistrationFactoryCode";
            this.colFactoryCode.FillWeight = 32.46753F;
            resources.ApplyResources(this.colFactoryCode, "colFactoryCode");
            this.colFactoryCode.Name = "colFactoryCode";
            this.colFactoryCode.ReadOnly = true;
            // 
            // Clear_btn
            // 
            this.Clear_btn.BackColor = System.Drawing.SystemColors.Control;
            this.Clear_btn.ControlId = null;
            resources.ApplyResources(this.Clear_btn, "Clear_btn");
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
            this.Add_btn.BackColor = System.Drawing.SystemColors.Control;
            this.Add_btn.ControlId = "BTN_01_01";
            resources.ApplyResources(this.Add_btn, "Add_btn");
            this.Add_btn.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Add_btn.Name = "Add_btn";
            this.Add_btn.UseVisualStyleBackColor = true;
            this.Add_btn.Click += new System.EventHandler(this.Add_btn_Click);
            // 
            // Search_btn
            // 
            this.Search_btn.BackColor = System.Drawing.SystemColors.Control;
            this.Search_btn.ControlId = "BTN_01_02";
            resources.ApplyResources(this.Search_btn, "Search_btn");
            this.Search_btn.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Search_btn.Name = "Search_btn";
            this.Search_btn.UseVisualStyleBackColor = true;
            this.Search_btn.Click += new System.EventHandler(this.Search_btn_Click);
            // 
            // UserMasterForm
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
            this.Controls.Add(this.Userdetails_dgv);
            this.Controls.Add(this.FactoryCode_cmb);
            this.Controls.Add(this.FactoryCode_lbl);
            this.Controls.Add(this.Country_lbl);
            this.Controls.Add(this.UserName_lbl);
            this.Controls.Add(this.UserName_txt);
            this.Controls.Add(this.Country_cmb);
            this.Controls.Add(this.UserCode_txt);
            this.Controls.Add(this.UserCode_lbl);
            this.Name = "UserMasterForm";
            this.TitleText = "FormCommon";
            this.Load += new System.EventHandler(this.UserMasterForm_Load);
            this.Controls.SetChildIndex(this.UserCode_lbl, 0);
            this.Controls.SetChildIndex(this.UserCode_txt, 0);
            this.Controls.SetChildIndex(this.Country_cmb, 0);
            this.Controls.SetChildIndex(this.UserName_txt, 0);
            this.Controls.SetChildIndex(this.UserName_lbl, 0);
            this.Controls.SetChildIndex(this.Country_lbl, 0);
            this.Controls.SetChildIndex(this.FactoryCode_lbl, 0);
            this.Controls.SetChildIndex(this.FactoryCode_cmb, 0);
            this.Controls.SetChildIndex(this.Userdetails_dgv, 0);
            this.Controls.SetChildIndex(this.Search_btn, 0);
            this.Controls.SetChildIndex(this.Add_btn, 0);
            this.Controls.SetChildIndex(this.Update_btn, 0);
            this.Controls.SetChildIndex(this.Delete_btn, 0);
            this.Controls.SetChildIndex(this.Exit_btn, 0);
            this.Controls.SetChildIndex(this.Clear_btn, 0);
            ((System.ComponentModel.ISupportInitialize)(this.Userdetails_dgv)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Com.Nidec.Mes.Framework.ComboBoxCommon FactoryCode_cmb;
        private Com.Nidec.Mes.Framework.LabelCommon FactoryCode_lbl;
        private Com.Nidec.Mes.Framework.LabelCommon Country_lbl;
        private Com.Nidec.Mes.Framework.LabelCommon UserName_lbl;
        private Com.Nidec.Mes.Framework.TextBoxCommon UserName_txt;
        private Com.Nidec.Mes.Framework.ComboBoxCommon Country_cmb;
        private Com.Nidec.Mes.Framework.TextBoxCommon UserCode_txt;
        private Com.Nidec.Mes.Framework.LabelCommon UserCode_lbl;
        internal Com.Nidec.Mes.Framework.DataGridViewCommon Userdetails_dgv;
        private Com.Nidec.Mes.Framework.ButtonCommon Search_btn;
        private Com.Nidec.Mes.Framework.ButtonCommon Add_btn;
        private Com.Nidec.Mes.Framework.ButtonCommon Update_btn;
        private Com.Nidec.Mes.Framework.ButtonCommon Delete_btn;
        private Com.Nidec.Mes.Framework.ButtonCommon Exit_btn;
        private Com.Nidec.Mes.Framework.ButtonCommon Clear_btn;
        private System.Windows.Forms.DataGridViewTextBoxColumn colUserCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn colUserName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCountry;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLocaleId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMultiLogin;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFactoryCode;
    }
}