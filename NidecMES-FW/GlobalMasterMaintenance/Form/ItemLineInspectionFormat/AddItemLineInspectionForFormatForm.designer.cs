namespace Com.Nidec.Mes.GlobalMasterMaintenance
{
    partial class AddItemLineInspectionForFormatForm : FormCommonMaster
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddItemLineInspectionForFormatForm));
            this.ItemId_lbl = new Com.Nidec.Mes.Framework.LabelCommon();
            this.Exit_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.Ok_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.LineId_lbl = new Com.Nidec.Mes.Framework.LabelCommon();
            this.InspectionFormat_cmb = new Com.Nidec.Mes.Framework.ComboBoxCommon();
            this.InspectionFormat_lbl = new Com.Nidec.Mes.Framework.LabelCommon();
            this.labelCommon2 = new Com.Nidec.Mes.Framework.LabelCommon();
            this.labelCommon1 = new Com.Nidec.Mes.Framework.LabelCommon();
            this.labelCommon3 = new Com.Nidec.Mes.Framework.LabelCommon();
            this.UpdateText_lbl = new Com.Nidec.Mes.Framework.LabelCommon();
            this.ItemId_cmb = new Com.Nidec.Mes.Framework.ComboBoxCommon();
            this.LineId_cmb = new Com.Nidec.Mes.Framework.ComboBoxCommon();
            this.Delete_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.SuspendLayout();
            // 
            // ItemId_lbl
            // 
            resources.ApplyResources(this.ItemId_lbl, "ItemId_lbl");
            this.ItemId_lbl.ControlId = null;
            this.ItemId_lbl.Name = "ItemId_lbl";
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
            // LineId_lbl
            // 
            resources.ApplyResources(this.LineId_lbl, "LineId_lbl");
            this.LineId_lbl.ControlId = null;
            this.LineId_lbl.Name = "LineId_lbl";
            // 
            // InspectionFormat_cmb
            // 
            this.InspectionFormat_cmb.ControlId = null;
            resources.ApplyResources(this.InspectionFormat_cmb, "InspectionFormat_cmb");
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
            // ItemId_cmb
            // 
            this.ItemId_cmb.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.ItemId_cmb.ControlId = null;
            resources.ApplyResources(this.ItemId_cmb, "ItemId_cmb");
            this.ItemId_cmb.FormattingEnabled = true;
            this.ItemId_cmb.Name = "ItemId_cmb";
            // 
            // LineId_cmb
            // 
            this.LineId_cmb.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.LineId_cmb.ControlId = null;
            resources.ApplyResources(this.LineId_cmb, "LineId_cmb");
            this.LineId_cmb.FormattingEnabled = true;
            this.LineId_cmb.Name = "LineId_cmb";
            // 
            // Delete_btn
            // 
            this.Delete_btn.BackColor = System.Drawing.SystemColors.Control;
            this.Delete_btn.ControlId = null;
            resources.ApplyResources(this.Delete_btn, "Delete_btn");
            this.Delete_btn.Name = "Delete_btn";
            this.Delete_btn.UseVisualStyleBackColor = true;
            this.Delete_btn.Click += new System.EventHandler(this.Delete_btn_Click);
            // 
            // AddItemLineInspectionForFormatForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.Delete_btn);
            this.Controls.Add(this.LineId_cmb);
            this.Controls.Add(this.ItemId_cmb);
            this.Controls.Add(this.UpdateText_lbl);
            this.Controls.Add(this.labelCommon3);
            this.Controls.Add(this.labelCommon1);
            this.Controls.Add(this.labelCommon2);
            this.Controls.Add(this.InspectionFormat_cmb);
            this.Controls.Add(this.InspectionFormat_lbl);
            this.Controls.Add(this.Exit_btn);
            this.Controls.Add(this.Ok_btn);
            this.Controls.Add(this.LineId_lbl);
            this.Controls.Add(this.ItemId_lbl);
            this.Name = "AddItemLineInspectionForFormatForm";
            this.TitleText = "FormCommon";
            this.Load += new System.EventHandler(this.AddItemLineInspectionForFormatForm_Load);
            this.Controls.SetChildIndex(this.ItemId_lbl, 0);
            this.Controls.SetChildIndex(this.LineId_lbl, 0);
            this.Controls.SetChildIndex(this.Ok_btn, 0);
            this.Controls.SetChildIndex(this.Exit_btn, 0);
            this.Controls.SetChildIndex(this.InspectionFormat_lbl, 0);
            this.Controls.SetChildIndex(this.InspectionFormat_cmb, 0);
            this.Controls.SetChildIndex(this.labelCommon2, 0);
            this.Controls.SetChildIndex(this.labelCommon1, 0);
            this.Controls.SetChildIndex(this.labelCommon3, 0);
            this.Controls.SetChildIndex(this.UpdateText_lbl, 0);
            this.Controls.SetChildIndex(this.ItemId_cmb, 0);
            this.Controls.SetChildIndex(this.LineId_cmb, 0);
            this.Controls.SetChildIndex(this.Delete_btn, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        protected Com.Nidec.Mes.Framework.LabelCommon ItemId_lbl;
        protected Com.Nidec.Mes.Framework.ButtonCommon Exit_btn;
        protected Com.Nidec.Mes.Framework.ButtonCommon Ok_btn;
        protected Com.Nidec.Mes.Framework.LabelCommon LineId_lbl;
        protected Com.Nidec.Mes.Framework.ComboBoxCommon InspectionFormat_cmb;
        protected Com.Nidec.Mes.Framework.LabelCommon InspectionFormat_lbl;
        protected Framework.LabelCommon labelCommon2;
        protected Framework.LabelCommon labelCommon1;
        protected Framework.LabelCommon labelCommon3;
        protected Framework.LabelCommon UpdateText_lbl;
        protected Framework.ComboBoxCommon ItemId_cmb;
        protected Framework.ComboBoxCommon LineId_cmb;
        protected Framework.ButtonCommon Delete_btn;
    }
}