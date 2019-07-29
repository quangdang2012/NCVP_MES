namespace Com.Nidec.Mes.GlobalMasterMaintenance
{
    partial class AddBuildingForm : FormCommonMaster
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddBuildingForm));
            this.Exit_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.Ok_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.BuildingCode_txt = new Com.Nidec.Mes.Framework.TextBoxCommon();
            this.BuildingName_lbl = new Com.Nidec.Mes.Framework.LabelCommon();
            this.BuildingName_txt = new Com.Nidec.Mes.Framework.TextBoxCommon();
            this.BuildingCode_lbl = new Com.Nidec.Mes.Framework.LabelCommon();
            this.labelCommon2 = new Com.Nidec.Mes.Framework.LabelCommon();
            this.labelCommon1 = new Com.Nidec.Mes.Framework.LabelCommon();
            this.UpdateText_lbl = new Com.Nidec.Mes.Framework.LabelCommon();
            this.Factory_lbl = new Com.Nidec.Mes.Framework.LabelCommon();
            this.FactoryCode_cmb = new Com.Nidec.Mes.Framework.ComboBoxCommon();
            this.labelCommon4 = new Com.Nidec.Mes.Framework.LabelCommon();
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
            // BuildingCode_txt
            // 
            this.BuildingCode_txt.ControlId = null;
            resources.ApplyResources(this.BuildingCode_txt, "BuildingCode_txt");
            this.BuildingCode_txt.InputType = Com.Nidec.Mes.Framework.TextBoxCommon.InputTypeList.All;
            this.BuildingCode_txt.Name = "BuildingCode_txt";
            // 
            // BuildingName_lbl
            // 
            resources.ApplyResources(this.BuildingName_lbl, "BuildingName_lbl");
            this.BuildingName_lbl.ControlId = null;
            this.BuildingName_lbl.Name = "BuildingName_lbl";
            // 
            // BuildingName_txt
            // 
            this.BuildingName_txt.ControlId = null;
            resources.ApplyResources(this.BuildingName_txt, "BuildingName_txt");
            this.BuildingName_txt.InputType = Com.Nidec.Mes.Framework.TextBoxCommon.InputTypeList.All;
            this.BuildingName_txt.Name = "BuildingName_txt";
            // 
            // BuildingCode_lbl
            // 
            resources.ApplyResources(this.BuildingCode_lbl, "BuildingCode_lbl");
            this.BuildingCode_lbl.ControlId = null;
            this.BuildingCode_lbl.Name = "BuildingCode_lbl";
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
            // Factory_lbl
            // 
            resources.ApplyResources(this.Factory_lbl, "Factory_lbl");
            this.Factory_lbl.ControlId = null;
            this.Factory_lbl.Name = "Factory_lbl";
            // 
            // FactoryCode_cmb
            // 
            this.FactoryCode_cmb.ControlId = null;
            resources.ApplyResources(this.FactoryCode_cmb, "FactoryCode_cmb");
            this.FactoryCode_cmb.FormattingEnabled = true;
            this.FactoryCode_cmb.Name = "FactoryCode_cmb";
            // 
            // labelCommon4
            // 
            resources.ApplyResources(this.labelCommon4, "labelCommon4");
            this.labelCommon4.ControlId = null;
            this.labelCommon4.ForeColor = System.Drawing.Color.DarkRed;
            this.labelCommon4.Name = "labelCommon4";
            // 
            // AddBuildingForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.labelCommon4);
            this.Controls.Add(this.FactoryCode_cmb);
            this.Controls.Add(this.Factory_lbl);
            this.Controls.Add(this.UpdateText_lbl);
            this.Controls.Add(this.labelCommon1);
            this.Controls.Add(this.labelCommon2);
            this.Controls.Add(this.Exit_btn);
            this.Controls.Add(this.Ok_btn);
            this.Controls.Add(this.BuildingCode_txt);
            this.Controls.Add(this.BuildingName_lbl);
            this.Controls.Add(this.BuildingName_txt);
            this.Controls.Add(this.BuildingCode_lbl);
            this.Name = "AddBuildingForm";
            this.TitleText = "FormCommon";
            this.Load += new System.EventHandler(this.AddBuildingForm_Load);
            this.Controls.SetChildIndex(this.BuildingCode_lbl, 0);
            this.Controls.SetChildIndex(this.BuildingName_txt, 0);
            this.Controls.SetChildIndex(this.BuildingName_lbl, 0);
            this.Controls.SetChildIndex(this.BuildingCode_txt, 0);
            this.Controls.SetChildIndex(this.Ok_btn, 0);
            this.Controls.SetChildIndex(this.Exit_btn, 0);
            this.Controls.SetChildIndex(this.labelCommon2, 0);
            this.Controls.SetChildIndex(this.labelCommon1, 0);
            this.Controls.SetChildIndex(this.UpdateText_lbl, 0);
            this.Controls.SetChildIndex(this.Factory_lbl, 0);
            this.Controls.SetChildIndex(this.FactoryCode_cmb, 0);
            this.Controls.SetChildIndex(this.labelCommon4, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Com.Nidec.Mes.Framework.ButtonCommon Exit_btn;
        private Com.Nidec.Mes.Framework.ButtonCommon Ok_btn;
        private Com.Nidec.Mes.Framework.TextBoxCommon BuildingCode_txt;
        private Com.Nidec.Mes.Framework.LabelCommon BuildingName_lbl;
        private Com.Nidec.Mes.Framework.TextBoxCommon BuildingName_txt;
        private Com.Nidec.Mes.Framework.LabelCommon BuildingCode_lbl;
        private Framework.LabelCommon labelCommon2;
        private Framework.LabelCommon labelCommon1;
        private Framework.LabelCommon UpdateText_lbl;
        private Framework.LabelCommon Factory_lbl;
        private Framework.ComboBoxCommon FactoryCode_cmb;
        private Framework.LabelCommon labelCommon4;
    }
}