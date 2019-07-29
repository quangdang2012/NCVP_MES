namespace Com.Nidec.Mes.GlobalMasterMaintenance
{
    partial class AddJigCauseMasterForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddJigCauseMasterForm));
            this.JigCauseCode_txt = new Com.Nidec.Mes.Framework.TextBoxCommon();
            this.JigCauseName_lbl = new Com.Nidec.Mes.Framework.LabelCommon();
            this.JigCauseName_txt = new Com.Nidec.Mes.Framework.TextBoxCommon();
            this.JigCauseCode_lbl = new Com.Nidec.Mes.Framework.LabelCommon();
            this.Exit_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.Ok_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.SuspendLayout();
            // 
            // JigCauseCode_txt
            // 
            this.JigCauseCode_txt.ControlId = null;
            resources.ApplyResources(this.JigCauseCode_txt, "JigCauseCode_txt");
            this.JigCauseCode_txt.InputType = Com.Nidec.Mes.Framework.TextBoxCommon.InputTypeList.All;
            this.JigCauseCode_txt.Name = "JigCauseCode_txt";
            // 
            // JigCauseName_lbl
            // 
            resources.ApplyResources(this.JigCauseName_lbl, "JigCauseName_lbl");
            this.JigCauseName_lbl.ControlId = null;
            this.JigCauseName_lbl.Name = "JigCauseName_lbl";
            // 
            // JigCauseName_txt
            // 
            this.JigCauseName_txt.ControlId = null;
            resources.ApplyResources(this.JigCauseName_txt, "JigCauseName_txt");
            this.JigCauseName_txt.InputType = Com.Nidec.Mes.Framework.TextBoxCommon.InputTypeList.All;
            this.JigCauseName_txt.Name = "JigCauseName_txt";
            // 
            // JigCauseCode_lbl
            // 
            resources.ApplyResources(this.JigCauseCode_lbl, "JigCauseCode_lbl");
            this.JigCauseCode_lbl.ControlId = null;
            this.JigCauseCode_lbl.Name = "JigCauseCode_lbl";
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
            // AddJigCauseMasterForm
            // 
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.Exit_btn);
            this.Controls.Add(this.Ok_btn);
            this.Controls.Add(this.JigCauseCode_txt);
            this.Controls.Add(this.JigCauseName_lbl);
            this.Controls.Add(this.JigCauseName_txt);
            this.Controls.Add(this.JigCauseCode_lbl);
            this.Name = "AddJigCauseMasterForm";
            this.TitleText = "FormCommon";
            this.Load += new System.EventHandler(this.AddJigCauseMasterForm_Load);
            this.Controls.SetChildIndex(this.JigCauseCode_lbl, 0);
            this.Controls.SetChildIndex(this.JigCauseName_txt, 0);
            this.Controls.SetChildIndex(this.JigCauseName_lbl, 0);
            this.Controls.SetChildIndex(this.JigCauseCode_txt, 0);
            this.Controls.SetChildIndex(this.Ok_btn, 0);
            this.Controls.SetChildIndex(this.Exit_btn, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Framework.TextBoxCommon JigCauseCode_txt;
        private Framework.LabelCommon JigCauseName_lbl;
        private Framework.TextBoxCommon JigCauseName_txt;
        private Framework.LabelCommon JigCauseCode_lbl;
        private Framework.ButtonCommon Exit_btn;
        private Framework.ButtonCommon Ok_btn;
    }
}
