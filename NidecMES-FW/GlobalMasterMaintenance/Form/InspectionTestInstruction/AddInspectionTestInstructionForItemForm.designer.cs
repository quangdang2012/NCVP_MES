namespace Com.Nidec.Mes.GlobalMasterMaintenance
{
    partial class AddInspectionTestInstructionForItemForm : FormCommonMaster
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddInspectionTestInstructionForItemForm));
            this.Exit_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.Ok_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.InspectionTestInstructionText_lbl = new Com.Nidec.Mes.Framework.LabelCommon();
            this.InspectionTestInstructionText_txt = new Com.Nidec.Mes.Framework.TextBoxCommon();
            this.InspectionItem_cmb = new Com.Nidec.Mes.Framework.ComboBoxCommon();
            this.InspectionItem_lbl = new Com.Nidec.Mes.Framework.LabelCommon();
            this.labelCommon2 = new Com.Nidec.Mes.Framework.LabelCommon();
            this.labelCommon3 = new Com.Nidec.Mes.Framework.LabelCommon();
            this.UpdateText_lbl = new Com.Nidec.Mes.Framework.LabelCommon();
            this.Detail_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.delete_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
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
            // InspectionTestInstructionText_lbl
            // 
            resources.ApplyResources(this.InspectionTestInstructionText_lbl, "InspectionTestInstructionText_lbl");
            this.InspectionTestInstructionText_lbl.ControlId = null;
            this.InspectionTestInstructionText_lbl.Name = "InspectionTestInstructionText_lbl";
            // 
            // InspectionTestInstructionText_txt
            // 
            resources.ApplyResources(this.InspectionTestInstructionText_txt, "InspectionTestInstructionText_txt");
            this.InspectionTestInstructionText_txt.ControlId = null;
            this.InspectionTestInstructionText_txt.InputType = Com.Nidec.Mes.Framework.TextBoxCommon.InputTypeList.All;
            this.InspectionTestInstructionText_txt.Name = "InspectionTestInstructionText_txt";
            // 
            // InspectionItem_cmb
            // 
            resources.ApplyResources(this.InspectionItem_cmb, "InspectionItem_cmb");
            this.InspectionItem_cmb.ControlId = null;
            this.InspectionItem_cmb.FormattingEnabled = true;
            this.InspectionItem_cmb.Name = "InspectionItem_cmb";
            // 
            // InspectionItem_lbl
            // 
            resources.ApplyResources(this.InspectionItem_lbl, "InspectionItem_lbl");
            this.InspectionItem_lbl.ControlId = null;
            this.InspectionItem_lbl.Name = "InspectionItem_lbl";
            // 
            // labelCommon2
            // 
            resources.ApplyResources(this.labelCommon2, "labelCommon2");
            this.labelCommon2.ControlId = null;
            this.labelCommon2.ForeColor = System.Drawing.Color.DarkRed;
            this.labelCommon2.Name = "labelCommon2";
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
            // Detail_btn
            // 
            resources.ApplyResources(this.Detail_btn, "Detail_btn");
            this.Detail_btn.BackColor = System.Drawing.SystemColors.Control;
            this.Detail_btn.ControlId = null;
            this.Detail_btn.Name = "Detail_btn";
            this.Detail_btn.UseVisualStyleBackColor = true;
            this.Detail_btn.Click += new System.EventHandler(this.Detail_btn_Click);
            // 
            // delete_btn
            // 
            resources.ApplyResources(this.delete_btn, "delete_btn");
            this.delete_btn.BackColor = System.Drawing.SystemColors.Control;
            this.delete_btn.ControlId = null;
            this.delete_btn.Name = "delete_btn";
            this.delete_btn.UseVisualStyleBackColor = true;
            this.delete_btn.Click += new System.EventHandler(this.delete_btn_Click);
            // 
            // AddInspectionTestInstructionForItemForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.delete_btn);
            this.Controls.Add(this.Detail_btn);
            this.Controls.Add(this.UpdateText_lbl);
            this.Controls.Add(this.labelCommon3);
            this.Controls.Add(this.labelCommon2);
            this.Controls.Add(this.InspectionItem_cmb);
            this.Controls.Add(this.InspectionItem_lbl);
            this.Controls.Add(this.Exit_btn);
            this.Controls.Add(this.Ok_btn);
            this.Controls.Add(this.InspectionTestInstructionText_txt);
            this.Controls.Add(this.InspectionTestInstructionText_lbl);
            this.Name = "AddInspectionTestInstructionForItemForm";
            this.TitleText = "FormCommon";
            this.Load += new System.EventHandler(this.AddInspectionTestInstructionbyItemForm_Load);
            this.Controls.SetChildIndex(this.InspectionTestInstructionText_lbl, 0);
            this.Controls.SetChildIndex(this.InspectionTestInstructionText_txt, 0);
            this.Controls.SetChildIndex(this.Ok_btn, 0);
            this.Controls.SetChildIndex(this.Exit_btn, 0);
            this.Controls.SetChildIndex(this.InspectionItem_lbl, 0);
            this.Controls.SetChildIndex(this.InspectionItem_cmb, 0);
            this.Controls.SetChildIndex(this.labelCommon2, 0);
            this.Controls.SetChildIndex(this.labelCommon3, 0);
            this.Controls.SetChildIndex(this.UpdateText_lbl, 0);
            this.Controls.SetChildIndex(this.Detail_btn, 0);
            this.Controls.SetChildIndex(this.delete_btn, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Com.Nidec.Mes.Framework.ButtonCommon Exit_btn;
        private Com.Nidec.Mes.Framework.ButtonCommon Ok_btn;
        private Com.Nidec.Mes.Framework.LabelCommon InspectionTestInstructionText_lbl;
        private Com.Nidec.Mes.Framework.TextBoxCommon InspectionTestInstructionText_txt;
        private Com.Nidec.Mes.Framework.ComboBoxCommon InspectionItem_cmb;
        private Com.Nidec.Mes.Framework.LabelCommon InspectionItem_lbl;
        private Framework.LabelCommon labelCommon2;
        private Framework.LabelCommon labelCommon3;
        private Framework.LabelCommon UpdateText_lbl;
        private Framework.ButtonCommon Detail_btn;
        private Framework.ButtonCommon delete_btn;
    }
}