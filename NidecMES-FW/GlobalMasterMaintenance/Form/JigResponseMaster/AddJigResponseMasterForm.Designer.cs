namespace Com.Nidec.Mes.GlobalMasterMaintenance
{
    partial class AddJigResponseMasterForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddJigResponseMasterForm));
            this.JigResponseCode_txt = new Com.Nidec.Mes.Framework.TextBoxCommon();
            this.JigResponseName_lbl = new Com.Nidec.Mes.Framework.LabelCommon();
            this.JigResponseName_txt = new Com.Nidec.Mes.Framework.TextBoxCommon();
            this.JigResponseCode_lbl = new Com.Nidec.Mes.Framework.LabelCommon();
            this.Exit_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.Ok_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.SuspendLayout();
            // 
            // JigResponseCode_txt
            // 
            this.JigResponseCode_txt.ControlId = null;
            resources.ApplyResources(this.JigResponseCode_txt, "JigResponseCode_txt");
            this.JigResponseCode_txt.InputType = Com.Nidec.Mes.Framework.TextBoxCommon.InputTypeList.All;
            this.JigResponseCode_txt.Name = "JigResponseCode_txt";
            // 
            // JigResponseName_lbl
            // 
            resources.ApplyResources(this.JigResponseName_lbl, "JigResponseName_lbl");
            this.JigResponseName_lbl.ControlId = null;
            this.JigResponseName_lbl.Name = "JigResponseName_lbl";
            // 
            // JigResponseName_txt
            // 
            this.JigResponseName_txt.ControlId = null;
            resources.ApplyResources(this.JigResponseName_txt, "JigResponseName_txt");
            this.JigResponseName_txt.InputType = Com.Nidec.Mes.Framework.TextBoxCommon.InputTypeList.All;
            this.JigResponseName_txt.Name = "JigResponseName_txt";
            // 
            // JigResponseCode_lbl
            // 
            resources.ApplyResources(this.JigResponseCode_lbl, "JigResponseCode_lbl");
            this.JigResponseCode_lbl.ControlId = null;
            this.JigResponseCode_lbl.Name = "JigResponseCode_lbl";
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
            // AddJigResponseMasterForm
            // 
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.Exit_btn);
            this.Controls.Add(this.Ok_btn);
            this.Controls.Add(this.JigResponseCode_txt);
            this.Controls.Add(this.JigResponseName_lbl);
            this.Controls.Add(this.JigResponseName_txt);
            this.Controls.Add(this.JigResponseCode_lbl);
            this.Name = "AddJigResponseMasterForm";
            this.TitleText = "FormCommon";
            this.Load += new System.EventHandler(this.AddJigResponseMasterForm_Load);
            this.Controls.SetChildIndex(this.JigResponseCode_lbl, 0);
            this.Controls.SetChildIndex(this.JigResponseName_txt, 0);
            this.Controls.SetChildIndex(this.JigResponseName_lbl, 0);
            this.Controls.SetChildIndex(this.JigResponseCode_txt, 0);
            this.Controls.SetChildIndex(this.Ok_btn, 0);
            this.Controls.SetChildIndex(this.Exit_btn, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Framework.TextBoxCommon JigResponseCode_txt;
        private Framework.LabelCommon JigResponseName_lbl;
        private Framework.TextBoxCommon JigResponseName_txt;
        private Framework.LabelCommon JigResponseCode_lbl;
        private Framework.ButtonCommon Exit_btn;
        private Framework.ButtonCommon Ok_btn;
    }
}
