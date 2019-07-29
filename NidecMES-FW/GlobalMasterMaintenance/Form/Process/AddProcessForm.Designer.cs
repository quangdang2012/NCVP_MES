namespace Com.Nidec.Mes.GlobalMasterMaintenance
{
    partial class AddProcessForm:FormCommonMaster
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddProcessForm));
            this.Exit_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.Ok_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.ProcessCode_txt = new Com.Nidec.Mes.Framework.TextBoxCommon();
            this.ProcessName_lbl = new Com.Nidec.Mes.Framework.LabelCommon();
            this.ProcessName_txt = new Com.Nidec.Mes.Framework.TextBoxCommon();
            this.ProcessCode_lbl = new Com.Nidec.Mes.Framework.LabelCommon();
            this.labelCommon2 = new Com.Nidec.Mes.Framework.LabelCommon();
            this.labelCommon1 = new Com.Nidec.Mes.Framework.LabelCommon();
            this.UpdateText_lbl = new Com.Nidec.Mes.Framework.LabelCommon();
            this.SuspendLayout();
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
            // ProcessCode_txt
            // 
            resources.ApplyResources(this.ProcessCode_txt, "ProcessCode_txt");
            this.ProcessCode_txt.ControlId = null;
            this.ProcessCode_txt.InputType = Com.Nidec.Mes.Framework.TextBoxCommon.InputTypeList.All;
            this.ProcessCode_txt.Name = "ProcessCode_txt";
            // 
            // ProcessName_lbl
            // 
            resources.ApplyResources(this.ProcessName_lbl, "ProcessName_lbl");
            this.ProcessName_lbl.ControlId = null;
            this.ProcessName_lbl.Name = "ProcessName_lbl";
            // 
            // ProcessName_txt
            // 
            resources.ApplyResources(this.ProcessName_txt, "ProcessName_txt");
            this.ProcessName_txt.ControlId = null;
            this.ProcessName_txt.InputType = Com.Nidec.Mes.Framework.TextBoxCommon.InputTypeList.All;
            this.ProcessName_txt.Name = "ProcessName_txt";
            // 
            // ProcessCode_lbl
            // 
            resources.ApplyResources(this.ProcessCode_lbl, "ProcessCode_lbl");
            this.ProcessCode_lbl.ControlId = null;
            this.ProcessCode_lbl.Name = "ProcessCode_lbl";
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
            // AddProcessForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.UpdateText_lbl);
            this.Controls.Add(this.labelCommon1);
            this.Controls.Add(this.labelCommon2);
            this.Controls.Add(this.Exit_btn);
            this.Controls.Add(this.Ok_btn);
            this.Controls.Add(this.ProcessCode_txt);
            this.Controls.Add(this.ProcessName_lbl);
            this.Controls.Add(this.ProcessName_txt);
            this.Controls.Add(this.ProcessCode_lbl);
            this.Name = "AddProcessForm";
            this.TitleText = "FormCommon";
            this.Load += new System.EventHandler(this.AddProcessForm_Load);
            this.Controls.SetChildIndex(this.ProcessCode_lbl, 0);
            this.Controls.SetChildIndex(this.ProcessName_txt, 0);
            this.Controls.SetChildIndex(this.ProcessName_lbl, 0);
            this.Controls.SetChildIndex(this.ProcessCode_txt, 0);
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
        private Com.Nidec.Mes.Framework.TextBoxCommon ProcessCode_txt;
        private Com.Nidec.Mes.Framework.LabelCommon ProcessName_lbl;
        private Com.Nidec.Mes.Framework.TextBoxCommon ProcessName_txt;
        private Com.Nidec.Mes.Framework.LabelCommon ProcessCode_lbl;
        private Framework.LabelCommon labelCommon2;
        private Framework.LabelCommon labelCommon1;
        private Framework.LabelCommon UpdateText_lbl;
    }
}