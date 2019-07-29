namespace Com.Nidec.Mes.GlobalMasterMaintenance
{
    partial class AddDrawMasterForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddDrawMasterForm));
            this.DrawCode_txt = new Com.Nidec.Mes.Framework.TextBoxCommon();
            this.DrawName_lbl = new Com.Nidec.Mes.Framework.LabelCommon();
            this.DrawName_txt = new Com.Nidec.Mes.Framework.TextBoxCommon();
            this.DrawCode_lbl = new Com.Nidec.Mes.Framework.LabelCommon();
            this.Exit_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.Ok_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.SuspendLayout();
            // 
            // DrawCode_txt
            // 
            this.DrawCode_txt.ControlId = null;
            resources.ApplyResources(this.DrawCode_txt, "DrawCode_txt");
            this.DrawCode_txt.InputType = Com.Nidec.Mes.Framework.TextBoxCommon.InputTypeList.All;
            this.DrawCode_txt.Name = "DrawCode_txt";
            // 
            // DrawName_lbl
            // 
            resources.ApplyResources(this.DrawName_lbl, "DrawName_lbl");
            this.DrawName_lbl.ControlId = null;
            this.DrawName_lbl.Name = "DrawName_lbl";
            // 
            // DrawName_txt
            // 
            this.DrawName_txt.ControlId = null;
            resources.ApplyResources(this.DrawName_txt, "DrawName_txt");
            this.DrawName_txt.InputType = Com.Nidec.Mes.Framework.TextBoxCommon.InputTypeList.All;
            this.DrawName_txt.Name = "DrawName_txt";
            // 
            // DrawCode_lbl
            // 
            resources.ApplyResources(this.DrawCode_lbl, "DrawCode_lbl");
            this.DrawCode_lbl.ControlId = null;
            this.DrawCode_lbl.Name = "DrawCode_lbl";
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
            // AddDrawMasterForm
            // 
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.Exit_btn);
            this.Controls.Add(this.Ok_btn);
            this.Controls.Add(this.DrawCode_txt);
            this.Controls.Add(this.DrawName_lbl);
            this.Controls.Add(this.DrawName_txt);
            this.Controls.Add(this.DrawCode_lbl);
            this.Name = "AddDrawMasterForm";
            this.TitleText = "FormCommon";
            this.Load += new System.EventHandler(this.AddModelMasterForm_Load);
            this.Controls.SetChildIndex(this.DrawCode_lbl, 0);
            this.Controls.SetChildIndex(this.DrawName_txt, 0);
            this.Controls.SetChildIndex(this.DrawName_lbl, 0);
            this.Controls.SetChildIndex(this.DrawCode_txt, 0);
            this.Controls.SetChildIndex(this.Ok_btn, 0);
            this.Controls.SetChildIndex(this.Exit_btn, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Framework.TextBoxCommon DrawCode_txt;
        private Framework.LabelCommon DrawName_lbl;
        private Framework.TextBoxCommon DrawName_txt;
        private Framework.LabelCommon DrawCode_lbl;
        private Framework.ButtonCommon Exit_btn;
        private Framework.ButtonCommon Ok_btn;
    }
}
