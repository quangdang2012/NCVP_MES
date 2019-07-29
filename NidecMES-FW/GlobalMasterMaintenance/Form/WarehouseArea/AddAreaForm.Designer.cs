namespace Com.Nidec.Mes.GlobalMasterMaintenance
{
    partial class AddAreaForm : FormCommonMaster
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddAreaForm));
            this.Location_lbl = new Com.Nidec.Mes.Framework.LabelCommon();
            this.Location_cmb = new Com.Nidec.Mes.Framework.ComboBoxCommon();
            this.Exit_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.Ok_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.AreaCode_txt = new Com.Nidec.Mes.Framework.TextBoxCommon();
            this.AreaName_lbl = new Com.Nidec.Mes.Framework.LabelCommon();
            this.AreaName_txt = new Com.Nidec.Mes.Framework.TextBoxCommon();
            this.AreaCode_lbl = new Com.Nidec.Mes.Framework.LabelCommon();
            this.labelCommon2 = new Com.Nidec.Mes.Framework.LabelCommon();
            this.labelCommon1 = new Com.Nidec.Mes.Framework.LabelCommon();
            this.labelCommon3 = new Com.Nidec.Mes.Framework.LabelCommon();
            this.UpdateText_lbl = new Com.Nidec.Mes.Framework.LabelCommon();
            this.SuspendLayout();
            // 
            // Location_lbl
            // 
            resources.ApplyResources(this.Location_lbl, "Location_lbl");
            this.Location_lbl.ControlId = null;
            this.Location_lbl.Name = "Location_lbl";
            // 
            // Location_cmb
            // 
            this.Location_cmb.ControlId = null;
            resources.ApplyResources(this.Location_cmb, "Location_cmb");
            this.Location_cmb.FormattingEnabled = true;
            this.Location_cmb.Name = "Location_cmb";
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
            // AreaCode_txt
            // 
            this.AreaCode_txt.ControlId = null;
            resources.ApplyResources(this.AreaCode_txt, "AreaCode_txt");
            this.AreaCode_txt.InputType = Com.Nidec.Mes.Framework.TextBoxCommon.InputTypeList.All;
            this.AreaCode_txt.Name = "AreaCode_txt";
            // 
            // AreaName_lbl
            // 
            resources.ApplyResources(this.AreaName_lbl, "AreaName_lbl");
            this.AreaName_lbl.ControlId = null;
            this.AreaName_lbl.Name = "AreaName_lbl";
            // 
            // AreaName_txt
            // 
            this.AreaName_txt.ControlId = null;
            resources.ApplyResources(this.AreaName_txt, "AreaName_txt");
            this.AreaName_txt.InputType = Com.Nidec.Mes.Framework.TextBoxCommon.InputTypeList.All;
            this.AreaName_txt.Name = "AreaName_txt";
            // 
            // AreaCode_lbl
            // 
            resources.ApplyResources(this.AreaCode_lbl, "AreaCode_lbl");
            this.AreaCode_lbl.ControlId = null;
            this.AreaCode_lbl.Name = "AreaCode_lbl";
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
            // AddAreaForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.UpdateText_lbl);
            this.Controls.Add(this.labelCommon3);
            this.Controls.Add(this.labelCommon1);
            this.Controls.Add(this.labelCommon2);
            this.Controls.Add(this.Location_lbl);
            this.Controls.Add(this.Location_cmb);
            this.Controls.Add(this.Exit_btn);
            this.Controls.Add(this.Ok_btn);
            this.Controls.Add(this.AreaCode_txt);
            this.Controls.Add(this.AreaName_lbl);
            this.Controls.Add(this.AreaName_txt);
            this.Controls.Add(this.AreaCode_lbl);
            this.Name = "AddAreaForm";
            this.TitleText = "FormCommon";
            this.Load += new System.EventHandler(this.AddAreaForm_Load);
            this.Controls.SetChildIndex(this.AreaCode_lbl, 0);
            this.Controls.SetChildIndex(this.AreaName_txt, 0);
            this.Controls.SetChildIndex(this.AreaName_lbl, 0);
            this.Controls.SetChildIndex(this.AreaCode_txt, 0);
            this.Controls.SetChildIndex(this.Ok_btn, 0);
            this.Controls.SetChildIndex(this.Exit_btn, 0);
            this.Controls.SetChildIndex(this.Location_cmb, 0);
            this.Controls.SetChildIndex(this.Location_lbl, 0);
            this.Controls.SetChildIndex(this.labelCommon2, 0);
            this.Controls.SetChildIndex(this.labelCommon1, 0);
            this.Controls.SetChildIndex(this.labelCommon3, 0);
            this.Controls.SetChildIndex(this.UpdateText_lbl, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Com.Nidec.Mes.Framework.LabelCommon Location_lbl;
        private Com.Nidec.Mes.Framework.ComboBoxCommon Location_cmb;
        private Com.Nidec.Mes.Framework.ButtonCommon Exit_btn;
        private Com.Nidec.Mes.Framework.ButtonCommon Ok_btn;
        private Com.Nidec.Mes.Framework.TextBoxCommon AreaCode_txt;
        private Com.Nidec.Mes.Framework.LabelCommon AreaName_lbl;
        private Com.Nidec.Mes.Framework.TextBoxCommon AreaName_txt;
        private Com.Nidec.Mes.Framework.LabelCommon AreaCode_lbl;
        private Framework.LabelCommon labelCommon2;
        private Framework.LabelCommon labelCommon1;
        private Framework.LabelCommon labelCommon3;
        private Framework.LabelCommon UpdateText_lbl;
    }
}