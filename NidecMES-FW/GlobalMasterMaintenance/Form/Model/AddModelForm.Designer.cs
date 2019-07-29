namespace Com.Nidec.Mes.GlobalMasterMaintenance
{
    partial class AddModelForm : FormCommonMaster
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddModelForm));
            this.Exit_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.Ok_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.ModelCode_txt = new Com.Nidec.Mes.Framework.TextBoxCommon();
            this.ModelName_lbl = new Com.Nidec.Mes.Framework.LabelCommon();
            this.ModelName_txt = new Com.Nidec.Mes.Framework.TextBoxCommon();
            this.ModelCode_lbl = new Com.Nidec.Mes.Framework.LabelCommon();
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
            // ModelCode_txt
            // 
            this.ModelCode_txt.ControlId = null;
            resources.ApplyResources(this.ModelCode_txt, "ModelCode_txt");
            this.ModelCode_txt.InputType = Com.Nidec.Mes.Framework.TextBoxCommon.InputTypeList.All;
            this.ModelCode_txt.Name = "ModelCode_txt";
            // 
            // ModelName_lbl
            // 
            resources.ApplyResources(this.ModelName_lbl, "ModelName_lbl");
            this.ModelName_lbl.ControlId = null;
            this.ModelName_lbl.Name = "ModelName_lbl";
            // 
            // ModelName_txt
            // 
            this.ModelName_txt.ControlId = null;
            resources.ApplyResources(this.ModelName_txt, "ModelName_txt");
            this.ModelName_txt.InputType = Com.Nidec.Mes.Framework.TextBoxCommon.InputTypeList.All;
            this.ModelName_txt.Name = "ModelName_txt";
            // 
            // ModelCode_lbl
            // 
            resources.ApplyResources(this.ModelCode_lbl, "ModelCode_lbl");
            this.ModelCode_lbl.ControlId = null;
            this.ModelCode_lbl.Name = "ModelCode_lbl";
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
            // AddModelForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.UpdateText_lbl);
            this.Controls.Add(this.labelCommon1);
            this.Controls.Add(this.labelCommon2);
            this.Controls.Add(this.Exit_btn);
            this.Controls.Add(this.Ok_btn);
            this.Controls.Add(this.ModelCode_txt);
            this.Controls.Add(this.ModelName_lbl);
            this.Controls.Add(this.ModelName_txt);
            this.Controls.Add(this.ModelCode_lbl);
            this.Name = "AddModelForm";
            this.TitleText = "FormCommon";
            this.Load += new System.EventHandler(this.AddModelForm_Load);
            this.Controls.SetChildIndex(this.ModelCode_lbl, 0);
            this.Controls.SetChildIndex(this.ModelName_txt, 0);
            this.Controls.SetChildIndex(this.ModelName_lbl, 0);
            this.Controls.SetChildIndex(this.ModelCode_txt, 0);
            this.Controls.SetChildIndex(this.Ok_btn, 0);
            this.Controls.SetChildIndex(this.Exit_btn, 0);
            this.Controls.SetChildIndex(this.labelCommon2, 0);
            this.Controls.SetChildIndex(this.labelCommon1, 0);
            this.Controls.SetChildIndex(this.UpdateText_lbl, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Com.Nidec.Mes.Framework.ButtonCommon Exit_btn;
        private Com.Nidec.Mes.Framework.ButtonCommon Ok_btn;
        private Com.Nidec.Mes.Framework.TextBoxCommon ModelCode_txt;
        private Com.Nidec.Mes.Framework.LabelCommon ModelName_lbl;
        private Com.Nidec.Mes.Framework.TextBoxCommon ModelName_txt;
        private Com.Nidec.Mes.Framework.LabelCommon ModelCode_lbl;
        private Framework.LabelCommon labelCommon2;
        private Framework.LabelCommon labelCommon1;
        private Framework.LabelCommon UpdateText_lbl;
    }
}