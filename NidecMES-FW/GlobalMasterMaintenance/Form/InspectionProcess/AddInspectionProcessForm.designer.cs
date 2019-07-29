namespace Com.Nidec.Mes.GlobalMasterMaintenance
{
    partial class AddInspectionProcessForm : FormCommonMaster
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddInspectionProcessForm));
            this.InspectionProcessCode_txt = new Com.Nidec.Mes.Framework.TextBoxCommon();
            this.InspectionProcessCode_lbl = new Com.Nidec.Mes.Framework.LabelCommon();
            this.Exit_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.Ok_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.InspectionProcessName_lbl = new Com.Nidec.Mes.Framework.LabelCommon();
            this.InspectionProcessName_txt = new Com.Nidec.Mes.Framework.TextBoxCommon();
            this.InspectionFormat_cmb = new Com.Nidec.Mes.Framework.ComboBoxCommon();
            this.InspectionFormat_lbl = new Com.Nidec.Mes.Framework.LabelCommon();
            this.labelCommon2 = new Com.Nidec.Mes.Framework.LabelCommon();
            this.labelCommon1 = new Com.Nidec.Mes.Framework.LabelCommon();
            this.labelCommon3 = new Com.Nidec.Mes.Framework.LabelCommon();
            this.UpdateText_lbl = new Com.Nidec.Mes.Framework.LabelCommon();
            this.SuspendLayout();
            // 
            // InspectionProcessCode_txt
            // 
            resources.ApplyResources(this.InspectionProcessCode_txt, "InspectionProcessCode_txt");
            this.InspectionProcessCode_txt.ControlId = null;
            this.InspectionProcessCode_txt.InputType = Com.Nidec.Mes.Framework.TextBoxCommon.InputTypeList.All;
            this.InspectionProcessCode_txt.Name = "InspectionProcessCode_txt";
            // 
            // InspectionProcessCode_lbl
            // 
            resources.ApplyResources(this.InspectionProcessCode_lbl, "InspectionProcessCode_lbl");
            this.InspectionProcessCode_lbl.ControlId = null;
            this.InspectionProcessCode_lbl.Name = "InspectionProcessCode_lbl";
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
            // InspectionProcessName_lbl
            // 
            resources.ApplyResources(this.InspectionProcessName_lbl, "InspectionProcessName_lbl");
            this.InspectionProcessName_lbl.ControlId = null;
            this.InspectionProcessName_lbl.Name = "InspectionProcessName_lbl";
            // 
            // InspectionProcessName_txt
            // 
            resources.ApplyResources(this.InspectionProcessName_txt, "InspectionProcessName_txt");
            this.InspectionProcessName_txt.ControlId = null;
            this.InspectionProcessName_txt.InputType = Com.Nidec.Mes.Framework.TextBoxCommon.InputTypeList.All;
            this.InspectionProcessName_txt.Name = "InspectionProcessName_txt";
            // 
            // InspectionFormat_cmb
            // 
            resources.ApplyResources(this.InspectionFormat_cmb, "InspectionFormat_cmb");
            this.InspectionFormat_cmb.ControlId = null;
            this.InspectionFormat_cmb.FormattingEnabled = true;
            this.InspectionFormat_cmb.Name = "InspectionFormat_cmb";
            // 
            // InspectionFormat_lbl
            // 
            resources.ApplyResources(this.InspectionFormat_lbl, "InspectionFormat_lbl");
            this.InspectionFormat_lbl.ControlId = null;
            this.InspectionFormat_lbl.Name = "InspectionFormat_lbl";
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
            // AddInspectionProcessForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.UpdateText_lbl);
            this.Controls.Add(this.labelCommon3);
            this.Controls.Add(this.labelCommon1);
            this.Controls.Add(this.labelCommon2);
            this.Controls.Add(this.InspectionFormat_cmb);
            this.Controls.Add(this.InspectionFormat_lbl);
            this.Controls.Add(this.Exit_btn);
            this.Controls.Add(this.Ok_btn);
            this.Controls.Add(this.InspectionProcessName_txt);
            this.Controls.Add(this.InspectionProcessCode_txt);
            this.Controls.Add(this.InspectionProcessName_lbl);
            this.Controls.Add(this.InspectionProcessCode_lbl);
            this.Name = "AddInspectionProcessForm";
            this.TitleText = "FormCommon";
            this.Load += new System.EventHandler(this.AddInspectionProcessForm_Load);
            this.Controls.SetChildIndex(this.InspectionProcessCode_lbl, 0);
            this.Controls.SetChildIndex(this.InspectionProcessName_lbl, 0);
            this.Controls.SetChildIndex(this.InspectionProcessCode_txt, 0);
            this.Controls.SetChildIndex(this.InspectionProcessName_txt, 0);
            this.Controls.SetChildIndex(this.Ok_btn, 0);
            this.Controls.SetChildIndex(this.Exit_btn, 0);
            this.Controls.SetChildIndex(this.InspectionFormat_lbl, 0);
            this.Controls.SetChildIndex(this.InspectionFormat_cmb, 0);
            this.Controls.SetChildIndex(this.labelCommon2, 0);
            this.Controls.SetChildIndex(this.labelCommon1, 0);
            this.Controls.SetChildIndex(this.labelCommon3, 0);
            this.Controls.SetChildIndex(this.UpdateText_lbl, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Com.Nidec.Mes.Framework.TextBoxCommon InspectionProcessCode_txt;
        private Com.Nidec.Mes.Framework.LabelCommon InspectionProcessCode_lbl;
        private Com.Nidec.Mes.Framework.ButtonCommon Exit_btn;
        private Com.Nidec.Mes.Framework.ButtonCommon Ok_btn;
        private Com.Nidec.Mes.Framework.LabelCommon InspectionProcessName_lbl;
        private Com.Nidec.Mes.Framework.TextBoxCommon InspectionProcessName_txt;
        private Com.Nidec.Mes.Framework.ComboBoxCommon InspectionFormat_cmb;
        private Com.Nidec.Mes.Framework.LabelCommon InspectionFormat_lbl;
        private Framework.LabelCommon labelCommon2;
        private Framework.LabelCommon labelCommon1;
        private Framework.LabelCommon labelCommon3;
        private Framework.LabelCommon UpdateText_lbl;
    }
}