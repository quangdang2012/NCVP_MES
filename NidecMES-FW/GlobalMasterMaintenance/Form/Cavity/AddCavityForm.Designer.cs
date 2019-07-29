namespace Com.Nidec.Mes.GlobalMasterMaintenance
{
    partial class AddCavityForm : FormCommonMaster
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddCavityForm));
            this.Mold_lbl = new Com.Nidec.Mes.Framework.LabelCommon();
            this.Mold_cmb = new Com.Nidec.Mes.Framework.ComboBoxCommon();
            this.Exit_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.Ok_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.CavityCode_txt = new Com.Nidec.Mes.Framework.TextBoxCommon();
            this.CavityName_lbl = new Com.Nidec.Mes.Framework.LabelCommon();
            this.CavityName_txt = new Com.Nidec.Mes.Framework.TextBoxCommon();
            this.CavityCode_lbl = new Com.Nidec.Mes.Framework.LabelCommon();
            this.labelCommon2 = new Com.Nidec.Mes.Framework.LabelCommon();
            this.labelCommon1 = new Com.Nidec.Mes.Framework.LabelCommon();
            this.labelCommon3 = new Com.Nidec.Mes.Framework.LabelCommon();
            this.UpdateText_lbl = new Com.Nidec.Mes.Framework.LabelCommon();
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
            this.Mold_cmb.ControlId = null;
            this.Mold_cmb.FormattingEnabled = true;
            this.Mold_cmb.Name = "Mold_cmb";
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
            // labelCommon3
            // 
            resources.ApplyResources(this.labelCommon3, "labelCommon3");
            this.labelCommon3.ControlId = null;
            this.labelCommon3.ForeColor = System.Drawing.Color.DarkRed;
            this.labelCommon3.Name = "labelCommon3";
            // 
            // UpdateText_lbl
            // 
            resources.ApplyResources(this.UpdateText_lbl, "UpdateText_lbl");
            this.UpdateText_lbl.ControlId = null;
            this.UpdateText_lbl.Name = "UpdateText_lbl";
            // 
            // AddCavityForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.UpdateText_lbl);
            this.Controls.Add(this.labelCommon3);
            this.Controls.Add(this.labelCommon1);
            this.Controls.Add(this.labelCommon2);
            this.Controls.Add(this.Mold_lbl);
            this.Controls.Add(this.Mold_cmb);
            this.Controls.Add(this.Exit_btn);
            this.Controls.Add(this.Ok_btn);
            this.Controls.Add(this.CavityCode_txt);
            this.Controls.Add(this.CavityName_lbl);
            this.Controls.Add(this.CavityName_txt);
            this.Controls.Add(this.CavityCode_lbl);
            this.Name = "AddCavityForm";
            this.TitleText = "FormCommon";
            this.Load += new System.EventHandler(this.AddCavityForm_Load);
            this.Controls.SetChildIndex(this.CavityCode_lbl, 0);
            this.Controls.SetChildIndex(this.CavityName_txt, 0);
            this.Controls.SetChildIndex(this.CavityName_lbl, 0);
            this.Controls.SetChildIndex(this.CavityCode_txt, 0);
            this.Controls.SetChildIndex(this.Ok_btn, 0);
            this.Controls.SetChildIndex(this.Exit_btn, 0);
            this.Controls.SetChildIndex(this.Mold_cmb, 0);
            this.Controls.SetChildIndex(this.Mold_lbl, 0);
            this.Controls.SetChildIndex(this.labelCommon2, 0);
            this.Controls.SetChildIndex(this.labelCommon1, 0);
            this.Controls.SetChildIndex(this.labelCommon3, 0);
            this.Controls.SetChildIndex(this.UpdateText_lbl, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        protected Com.Nidec.Mes.Framework.LabelCommon Mold_lbl;
        protected Com.Nidec.Mes.Framework.ComboBoxCommon Mold_cmb;
        protected Com.Nidec.Mes.Framework.ButtonCommon Exit_btn;
        protected Com.Nidec.Mes.Framework.ButtonCommon Ok_btn;
        protected Com.Nidec.Mes.Framework.TextBoxCommon CavityCode_txt;
        protected Com.Nidec.Mes.Framework.LabelCommon CavityName_lbl;
        protected Com.Nidec.Mes.Framework.TextBoxCommon CavityName_txt;
        protected Com.Nidec.Mes.Framework.LabelCommon CavityCode_lbl;
        protected Framework.LabelCommon labelCommon2;
        protected Framework.LabelCommon labelCommon1;
        protected Framework.LabelCommon labelCommon3;
        protected Framework.LabelCommon UpdateText_lbl;
    }
}