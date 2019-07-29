namespace Com.Nidec.Mes.GlobalMasterMaintenance
{
    partial class AddInspectionFormatMasterForm : FormCommonMaster
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddInspectionFormatMasterForm));
            this.InspectionFormatName_lbl = new Com.Nidec.Mes.Framework.LabelCommon();
            this.InspectionFormatName_txt = new Com.Nidec.Mes.Framework.TextBoxCommon();
            this.labelCommon4 = new Com.Nidec.Mes.Framework.LabelCommon();
            this.Ok_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.Exit_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.UpdateText_lbl = new Com.Nidec.Mes.Framework.LabelCommon();
            this.LineId_cmb = new Com.Nidec.Mes.Framework.ComboBoxCommon();
            this.ItemId_cmb = new Com.Nidec.Mes.Framework.ComboBoxCommon();
            this.labelCommon1 = new Com.Nidec.Mes.Framework.LabelCommon();
            this.labelCommon2 = new Com.Nidec.Mes.Framework.LabelCommon();
            this.LineId_lbl = new Com.Nidec.Mes.Framework.LabelCommon();
            this.ItemId_lbl = new Com.Nidec.Mes.Framework.LabelCommon();
            this.SampleName_lbl = new Com.Nidec.Mes.Framework.LabelCommon();
            this.CopyFormat_txt = new Com.Nidec.Mes.Framework.TextBoxCommon();
            this.CopyFormat_lbl = new Com.Nidec.Mes.Framework.LabelCommon();
            this.CopyFormat_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.ItemSearch_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.ItemCode_txt = new Com.Nidec.Mes.Framework.TextBoxCommon();
            this.SuspendLayout();
            // 
            // InspectionFormatName_lbl
            // 
            resources.ApplyResources(this.InspectionFormatName_lbl, "InspectionFormatName_lbl");
            this.InspectionFormatName_lbl.ControlId = null;
            this.InspectionFormatName_lbl.Name = "InspectionFormatName_lbl";
            // 
            // InspectionFormatName_txt
            // 
            this.InspectionFormatName_txt.ControlId = null;
            resources.ApplyResources(this.InspectionFormatName_txt, "InspectionFormatName_txt");
            this.InspectionFormatName_txt.InputType = Com.Nidec.Mes.Framework.TextBoxCommon.InputTypeList.All;
            this.InspectionFormatName_txt.Name = "InspectionFormatName_txt";
            // 
            // labelCommon4
            // 
            resources.ApplyResources(this.labelCommon4, "labelCommon4");
            this.labelCommon4.ControlId = null;
            this.labelCommon4.ForeColor = System.Drawing.Color.DarkRed;
            this.labelCommon4.Name = "labelCommon4";
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
            // Exit_btn
            // 
            this.Exit_btn.BackColor = System.Drawing.SystemColors.Control;
            this.Exit_btn.ControlId = null;
            resources.ApplyResources(this.Exit_btn, "Exit_btn");
            this.Exit_btn.Name = "Exit_btn";
            this.Exit_btn.UseVisualStyleBackColor = true;
            this.Exit_btn.Click += new System.EventHandler(this.Exit_btn_Click);
            // 
            // UpdateText_lbl
            // 
            resources.ApplyResources(this.UpdateText_lbl, "UpdateText_lbl");
            this.UpdateText_lbl.ControlId = null;
            this.UpdateText_lbl.Name = "UpdateText_lbl";
            // 
            // LineId_cmb
            // 
            this.LineId_cmb.ControlId = null;
            resources.ApplyResources(this.LineId_cmb, "LineId_cmb");
            this.LineId_cmb.FormattingEnabled = true;
            this.LineId_cmb.Name = "LineId_cmb";
            // 
            // ItemId_cmb
            // 
            this.ItemId_cmb.ControlId = null;
            resources.ApplyResources(this.ItemId_cmb, "ItemId_cmb");
            this.ItemId_cmb.FormattingEnabled = true;
            this.ItemId_cmb.Name = "ItemId_cmb";
            // 
            // labelCommon1
            // 
            resources.ApplyResources(this.labelCommon1, "labelCommon1");
            this.labelCommon1.ControlId = null;
            this.labelCommon1.ForeColor = System.Drawing.Color.DarkRed;
            this.labelCommon1.Name = "labelCommon1";
            // 
            // labelCommon2
            // 
            resources.ApplyResources(this.labelCommon2, "labelCommon2");
            this.labelCommon2.ControlId = null;
            this.labelCommon2.ForeColor = System.Drawing.Color.DarkRed;
            this.labelCommon2.Name = "labelCommon2";
            // 
            // LineId_lbl
            // 
            resources.ApplyResources(this.LineId_lbl, "LineId_lbl");
            this.LineId_lbl.ControlId = null;
            this.LineId_lbl.Name = "LineId_lbl";
            // 
            // ItemId_lbl
            // 
            resources.ApplyResources(this.ItemId_lbl, "ItemId_lbl");
            this.ItemId_lbl.ControlId = null;
            this.ItemId_lbl.Name = "ItemId_lbl";
            // 
            // SampleName_lbl
            // 
            resources.ApplyResources(this.SampleName_lbl, "SampleName_lbl");
            this.SampleName_lbl.ControlId = null;
            this.SampleName_lbl.ForeColor = System.Drawing.Color.Gray;
            this.SampleName_lbl.Name = "SampleName_lbl";
            // 
            // CopyFormat_txt
            // 
            this.CopyFormat_txt.ControlId = null;
            resources.ApplyResources(this.CopyFormat_txt, "CopyFormat_txt");
            this.CopyFormat_txt.InputType = Com.Nidec.Mes.Framework.TextBoxCommon.InputTypeList.All;
            this.CopyFormat_txt.Name = "CopyFormat_txt";
            this.CopyFormat_txt.ReadOnly = true;
            // 
            // CopyFormat_lbl
            // 
            this.CopyFormat_lbl.ControlId = null;
            resources.ApplyResources(this.CopyFormat_lbl, "CopyFormat_lbl");
            this.CopyFormat_lbl.Name = "CopyFormat_lbl";
            // 
            // CopyFormat_btn
            // 
            this.CopyFormat_btn.BackColor = System.Drawing.SystemColors.Control;
            this.CopyFormat_btn.ControlId = null;
            resources.ApplyResources(this.CopyFormat_btn, "CopyFormat_btn");
            this.CopyFormat_btn.Name = "CopyFormat_btn";
            this.CopyFormat_btn.UseVisualStyleBackColor = true;
            this.CopyFormat_btn.Click += new System.EventHandler(this.BrowseFormat_btn_Click);
            // 
            // ItemSearch_btn
            // 
            this.ItemSearch_btn.BackColor = System.Drawing.SystemColors.Control;
            this.ItemSearch_btn.ControlId = null;
            resources.ApplyResources(this.ItemSearch_btn, "ItemSearch_btn");
            this.ItemSearch_btn.Name = "ItemSearch_btn";
            this.ItemSearch_btn.UseVisualStyleBackColor = true;
            this.ItemSearch_btn.Click += new System.EventHandler(this.ItemSearch_btn_Click);
            // 
            // ItemCode_txt
            // 
            this.ItemCode_txt.ControlId = null;
            resources.ApplyResources(this.ItemCode_txt, "ItemCode_txt");
            this.ItemCode_txt.InputType = Com.Nidec.Mes.Framework.TextBoxCommon.InputTypeList.All;
            this.ItemCode_txt.Name = "ItemCode_txt";
            // 
            // AddInspectionFormatMasterForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ItemSearch_btn);
            this.Controls.Add(this.ItemCode_txt);
            this.Controls.Add(this.CopyFormat_btn);
            this.Controls.Add(this.CopyFormat_txt);
            this.Controls.Add(this.CopyFormat_lbl);
            this.Controls.Add(this.SampleName_lbl);
            this.Controls.Add(this.LineId_cmb);
            this.Controls.Add(this.ItemId_cmb);
            this.Controls.Add(this.labelCommon1);
            this.Controls.Add(this.labelCommon2);
            this.Controls.Add(this.LineId_lbl);
            this.Controls.Add(this.ItemId_lbl);
            this.Controls.Add(this.UpdateText_lbl);
            this.Controls.Add(this.Exit_btn);
            this.Controls.Add(this.Ok_btn);
            this.Controls.Add(this.labelCommon4);
            this.Controls.Add(this.InspectionFormatName_txt);
            this.Controls.Add(this.InspectionFormatName_lbl);
            this.Name = "AddInspectionFormatMasterForm";
            this.TitleText = "FormCommon";
            this.Load += new System.EventHandler(this.InspectionFormatMasterForm_Load);
            this.Controls.SetChildIndex(this.InspectionFormatName_lbl, 0);
            this.Controls.SetChildIndex(this.InspectionFormatName_txt, 0);
            this.Controls.SetChildIndex(this.labelCommon4, 0);
            this.Controls.SetChildIndex(this.Ok_btn, 0);
            this.Controls.SetChildIndex(this.Exit_btn, 0);
            this.Controls.SetChildIndex(this.UpdateText_lbl, 0);
            this.Controls.SetChildIndex(this.ItemId_lbl, 0);
            this.Controls.SetChildIndex(this.LineId_lbl, 0);
            this.Controls.SetChildIndex(this.labelCommon2, 0);
            this.Controls.SetChildIndex(this.labelCommon1, 0);
            this.Controls.SetChildIndex(this.ItemId_cmb, 0);
            this.Controls.SetChildIndex(this.LineId_cmb, 0);
            this.Controls.SetChildIndex(this.SampleName_lbl, 0);
            this.Controls.SetChildIndex(this.CopyFormat_lbl, 0);
            this.Controls.SetChildIndex(this.CopyFormat_txt, 0);
            this.Controls.SetChildIndex(this.CopyFormat_btn, 0);
            this.Controls.SetChildIndex(this.ItemCode_txt, 0);
            this.Controls.SetChildIndex(this.ItemSearch_btn, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        public Framework.LabelCommon InspectionFormatName_lbl;
        public Framework.TextBoxCommon InspectionFormatName_txt;
        public Framework.LabelCommon labelCommon4;
        public Framework.ButtonCommon Ok_btn;
        public Framework.ButtonCommon Exit_btn;
        public Framework.LabelCommon UpdateText_lbl;
        public Framework.ComboBoxCommon LineId_cmb;
        public Framework.ComboBoxCommon ItemId_cmb;
        public Framework.LabelCommon labelCommon1;
        public Framework.LabelCommon labelCommon2;
        public Framework.LabelCommon LineId_lbl;
        public Framework.LabelCommon ItemId_lbl;
        public Framework.LabelCommon SampleName_lbl;
        public Framework.TextBoxCommon CopyFormat_txt;
        public Framework.LabelCommon CopyFormat_lbl;
        public Framework.ButtonCommon CopyFormat_btn;
        protected Framework.ButtonCommon ItemSearch_btn;
        protected Framework.TextBoxCommon ItemCode_txt;
    }
}