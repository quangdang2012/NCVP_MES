namespace Com.Nidec.Mes.GlobalMasterMaintenance
{
    partial class AddFactoryMasterForm: FormCommonMaster
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddFactoryMasterForm));
            this.FactoryCode_txt = new Com.Nidec.Mes.Framework.TextBoxCommon();
            this.FactoryCode_lbl = new Com.Nidec.Mes.Framework.LabelCommon();
            this.FactoryName_txt = new Com.Nidec.Mes.Framework.TextBoxCommon();
            this.FactoryName_lbl = new Com.Nidec.Mes.Framework.LabelCommon();
            this.Exit_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.Ok_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.labelCommon2 = new Com.Nidec.Mes.Framework.LabelCommon();
            this.labelCommon1 = new Com.Nidec.Mes.Framework.LabelCommon();
            this.UpdateText_lbl = new Com.Nidec.Mes.Framework.LabelCommon();
            this.SuspendLayout();
            // 
            // FactoryCode_txt
            // 
            this.FactoryCode_txt.ControlId = null;
            resources.ApplyResources(this.FactoryCode_txt, "FactoryCode_txt");
            this.FactoryCode_txt.InputType = Com.Nidec.Mes.Framework.TextBoxCommon.InputTypeList.All;
            this.FactoryCode_txt.Name = "FactoryCode_txt";
            // 
            // FactoryCode_lbl
            // 
            resources.ApplyResources(this.FactoryCode_lbl, "FactoryCode_lbl");
            this.FactoryCode_lbl.ControlId = null;
            this.FactoryCode_lbl.Name = "FactoryCode_lbl";
            // 
            // FactoryName_txt
            // 
            this.FactoryName_txt.ControlId = null;
            resources.ApplyResources(this.FactoryName_txt, "FactoryName_txt");
            this.FactoryName_txt.InputType = Com.Nidec.Mes.Framework.TextBoxCommon.InputTypeList.All;
            this.FactoryName_txt.Name = "FactoryName_txt";
            // 
            // FactoryName_lbl
            // 
            resources.ApplyResources(this.FactoryName_lbl, "FactoryName_lbl");
            this.FactoryName_lbl.ControlId = null;
            this.FactoryName_lbl.Name = "FactoryName_lbl";
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
            // AddFactoryMasterForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.UpdateText_lbl);
            this.Controls.Add(this.labelCommon1);
            this.Controls.Add(this.labelCommon2);
            this.Controls.Add(this.Exit_btn);
            this.Controls.Add(this.Ok_btn);
            this.Controls.Add(this.FactoryName_txt);
            this.Controls.Add(this.FactoryName_lbl);
            this.Controls.Add(this.FactoryCode_txt);
            this.Controls.Add(this.FactoryCode_lbl);
            this.Name = "AddFactoryMasterForm";
            this.TitleText = "FormCommon";
            this.Load += new System.EventHandler(this.AddFactoryMasterForm_Load);
            this.Controls.SetChildIndex(this.FactoryCode_lbl, 0);
            this.Controls.SetChildIndex(this.FactoryCode_txt, 0);
            this.Controls.SetChildIndex(this.FactoryName_lbl, 0);
            this.Controls.SetChildIndex(this.FactoryName_txt, 0);
            this.Controls.SetChildIndex(this.Ok_btn, 0);
            this.Controls.SetChildIndex(this.Exit_btn, 0);
            this.Controls.SetChildIndex(this.labelCommon2, 0);
            this.Controls.SetChildIndex(this.labelCommon1, 0);
            this.Controls.SetChildIndex(this.UpdateText_lbl, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        protected Com.Nidec.Mes.Framework.TextBoxCommon FactoryCode_txt;
        protected Com.Nidec.Mes.Framework.LabelCommon FactoryCode_lbl;
        protected Com.Nidec.Mes.Framework.TextBoxCommon FactoryName_txt;
        protected Com.Nidec.Mes.Framework.LabelCommon FactoryName_lbl;
        protected Com.Nidec.Mes.Framework.ButtonCommon Exit_btn;
        protected Com.Nidec.Mes.Framework.ButtonCommon Ok_btn;
        protected Framework.LabelCommon labelCommon2;
        protected Framework.LabelCommon labelCommon1;
        protected Framework.LabelCommon UpdateText_lbl;
    }
}
