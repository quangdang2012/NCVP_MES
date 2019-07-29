namespace Com.Nidec.Mes.GlobalMasterMaintenance
{
    partial class AddSapUserMasterForm:FormCommonMaster
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddSapUserMasterForm));
            this.SapUser_lbl = new Com.Nidec.Mes.Framework.LabelCommon();
            this.UserName_lbl = new Com.Nidec.Mes.Framework.LabelCommon();
            this.SapUserName_txt = new Com.Nidec.Mes.Framework.TextBoxCommon();
            this.UserName_cmb = new Com.Nidec.Mes.Framework.ComboBoxCommon();
            this.Password_lbl = new Com.Nidec.Mes.Framework.LabelCommon();
            this.UserPassword_txt = new Com.Nidec.Mes.Framework.TextBoxCommon();
            this.Ok_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.Exit_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.labelCommon2 = new Com.Nidec.Mes.Framework.LabelCommon();
            this.labelCommon1 = new Com.Nidec.Mes.Framework.LabelCommon();
            this.labelCommon4 = new Com.Nidec.Mes.Framework.LabelCommon();
            this.UpdateText_lbl = new Com.Nidec.Mes.Framework.LabelCommon();
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
            // Password_lbl
            // 
            resources.ApplyResources(this.Password_lbl, "Password_lbl");
            this.Password_lbl.ControlId = null;
            this.Password_lbl.Name = "Password_lbl";
            // 
            // UserPassword_txt
            // 
            resources.ApplyResources(this.UserPassword_txt, "UserPassword_txt");
            this.UserPassword_txt.ControlId = null;
            this.UserPassword_txt.InputType = Com.Nidec.Mes.Framework.TextBoxCommon.InputTypeList.All;
            this.UserPassword_txt.Name = "UserPassword_txt";
            this.UserPassword_txt.UseSystemPasswordChar = true;
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
            // Exit_btn
            // 
            resources.ApplyResources(this.Exit_btn, "Exit_btn");
            this.Exit_btn.BackColor = System.Drawing.SystemColors.Control;
            this.Exit_btn.ControlId = null;
            this.Exit_btn.Name = "Exit_btn";
            this.Exit_btn.UseVisualStyleBackColor = true;
            this.Exit_btn.Click += new System.EventHandler(this.Exit_btn_Click);
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
            // labelCommon4
            // 
            resources.ApplyResources(this.labelCommon4, "labelCommon4");
            this.labelCommon4.ControlId = null;
            this.labelCommon4.ForeColor = System.Drawing.Color.DarkRed;
            this.labelCommon4.Name = "labelCommon4";
            // 
            // UpdateText_lbl
            // 
            resources.ApplyResources(this.UpdateText_lbl, "UpdateText_lbl");
            this.UpdateText_lbl.ControlId = null;
            this.UpdateText_lbl.Name = "UpdateText_lbl";
            // 
            // AddSapUserMasterForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.UpdateText_lbl);
            this.Controls.Add(this.labelCommon4);
            this.Controls.Add(this.labelCommon1);
            this.Controls.Add(this.labelCommon2);
            this.Controls.Add(this.Exit_btn);
            this.Controls.Add(this.Ok_btn);
            this.Controls.Add(this.UserPassword_txt);
            this.Controls.Add(this.SapUser_lbl);
            this.Controls.Add(this.UserName_lbl);
            this.Controls.Add(this.SapUserName_txt);
            this.Controls.Add(this.UserName_cmb);
            this.Controls.Add(this.Password_lbl);
            this.Name = "AddSapUserMasterForm";
            this.TitleText = "FormCommon";
            this.Load += new System.EventHandler(this.AddSapUserMasterForm_Load);
            this.Controls.SetChildIndex(this.Password_lbl, 0);
            this.Controls.SetChildIndex(this.UserName_cmb, 0);
            this.Controls.SetChildIndex(this.SapUserName_txt, 0);
            this.Controls.SetChildIndex(this.UserName_lbl, 0);
            this.Controls.SetChildIndex(this.SapUser_lbl, 0);
            this.Controls.SetChildIndex(this.UserPassword_txt, 0);
            this.Controls.SetChildIndex(this.Ok_btn, 0);
            this.Controls.SetChildIndex(this.Exit_btn, 0);
            this.Controls.SetChildIndex(this.labelCommon2, 0);
            this.Controls.SetChildIndex(this.labelCommon1, 0);
            this.Controls.SetChildIndex(this.labelCommon4, 0);
            this.Controls.SetChildIndex(this.UpdateText_lbl, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Com.Nidec.Mes.Framework.LabelCommon SapUser_lbl;
        private Com.Nidec.Mes.Framework.LabelCommon UserName_lbl;
        private Com.Nidec.Mes.Framework.TextBoxCommon SapUserName_txt;
        private Com.Nidec.Mes.Framework.ComboBoxCommon UserName_cmb;
        private Com.Nidec.Mes.Framework.LabelCommon Password_lbl;
        private Com.Nidec.Mes.Framework.TextBoxCommon UserPassword_txt;
        private Com.Nidec.Mes.Framework.ButtonCommon Ok_btn;
        private Com.Nidec.Mes.Framework.ButtonCommon Exit_btn;
        private Framework.LabelCommon labelCommon2;
        private Framework.LabelCommon labelCommon1;
        private Framework.LabelCommon labelCommon4;
        private Framework.LabelCommon UpdateText_lbl;
    }
}