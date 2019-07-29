namespace Com.Nidec.Mes.GlobalMasterMaintenance
{
    partial class AddAuthorityControlForm : FormCommonMaster
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddAuthorityControlForm));
            this.Exit_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.Ok_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.ParentControl_lbl = new Com.Nidec.Mes.Framework.LabelCommon();
            this.AuthorityControlName_lbl = new Com.Nidec.Mes.Framework.LabelCommon();
            this.AuthorityControlName_txt = new Com.Nidec.Mes.Framework.TextBoxCommon();
            this.ParentControl_cmb = new Com.Nidec.Mes.Framework.ComboBoxCommon();
            this.AuthorityControlCode_txt = new Com.Nidec.Mes.Framework.TextBoxCommon();
            this.AuthorityControlCode_lbl = new Com.Nidec.Mes.Framework.LabelCommon();
            this.labelCommon2 = new Com.Nidec.Mes.Framework.LabelCommon();
            this.labelCommon1 = new Com.Nidec.Mes.Framework.LabelCommon();
            this.UpdateText_lbl = new Com.Nidec.Mes.Framework.LabelCommon();
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
            // AddAuthorityControlForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.UpdateText_lbl);
            this.Controls.Add(this.labelCommon1);
            this.Controls.Add(this.labelCommon2);
            this.Controls.Add(this.ParentControl_lbl);
            this.Controls.Add(this.AuthorityControlName_lbl);
            this.Controls.Add(this.AuthorityControlName_txt);
            this.Controls.Add(this.ParentControl_cmb);
            this.Controls.Add(this.AuthorityControlCode_txt);
            this.Controls.Add(this.AuthorityControlCode_lbl);
            this.Controls.Add(this.Exit_btn);
            this.Controls.Add(this.Ok_btn);
            this.Name = "AddAuthorityControlForm";
            this.TitleText = "FormCommon";
            this.Load += new System.EventHandler(this.AddAuthorityControlForm_Load);
            this.Controls.SetChildIndex(this.Ok_btn, 0);
            this.Controls.SetChildIndex(this.Exit_btn, 0);
            this.Controls.SetChildIndex(this.AuthorityControlCode_lbl, 0);
            this.Controls.SetChildIndex(this.AuthorityControlCode_txt, 0);
            this.Controls.SetChildIndex(this.ParentControl_cmb, 0);
            this.Controls.SetChildIndex(this.AuthorityControlName_txt, 0);
            this.Controls.SetChildIndex(this.AuthorityControlName_lbl, 0);
            this.Controls.SetChildIndex(this.ParentControl_lbl, 0);
            this.Controls.SetChildIndex(this.labelCommon2, 0);
            this.Controls.SetChildIndex(this.labelCommon1, 0);
            this.Controls.SetChildIndex(this.UpdateText_lbl, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Com.Nidec.Mes.Framework.ButtonCommon Exit_btn;
        private Com.Nidec.Mes.Framework.ButtonCommon Ok_btn;
        private Com.Nidec.Mes.Framework.LabelCommon ParentControl_lbl;
        private Com.Nidec.Mes.Framework.LabelCommon AuthorityControlName_lbl;
        private Com.Nidec.Mes.Framework.TextBoxCommon AuthorityControlName_txt;
        private Com.Nidec.Mes.Framework.ComboBoxCommon ParentControl_cmb;
        private Com.Nidec.Mes.Framework.TextBoxCommon AuthorityControlCode_txt;
        private Com.Nidec.Mes.Framework.LabelCommon AuthorityControlCode_lbl;
        private Framework.LabelCommon labelCommon2;
        private Framework.LabelCommon labelCommon1;
        private Framework.LabelCommon UpdateText_lbl;
    }
}