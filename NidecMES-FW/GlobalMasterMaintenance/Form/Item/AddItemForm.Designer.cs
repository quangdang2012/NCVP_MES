namespace Com.Nidec.Mes.GlobalMasterMaintenance
{
    partial class AddItemForm : FormCommonMaster
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddItemForm));
            this.Exit_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.Ok_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.ItemCode_txt = new Com.Nidec.Mes.Framework.TextBoxCommon();
            this.ItemName_lbl = new Com.Nidec.Mes.Framework.LabelCommon();
            this.ItemName_txt = new Com.Nidec.Mes.Framework.TextBoxCommon();
            this.ItemCode_lbl = new Com.Nidec.Mes.Framework.LabelCommon();
            this.labelCommon2 = new Com.Nidec.Mes.Framework.LabelCommon();
            this.labelCommon1 = new Com.Nidec.Mes.Framework.LabelCommon();
            this.labelCommon3 = new Com.Nidec.Mes.Framework.LabelCommon();
            this.UnitType_lbl = new Com.Nidec.Mes.Framework.LabelCommon();
            this.UnitType_cmb = new Com.Nidec.Mes.Framework.ComboBoxCommon();
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
            // ItemCode_txt
            // 
            this.ItemCode_txt.ControlId = null;
            resources.ApplyResources(this.ItemCode_txt, "ItemCode_txt");
            this.ItemCode_txt.InputType = Com.Nidec.Mes.Framework.TextBoxCommon.InputTypeList.All;
            this.ItemCode_txt.Name = "ItemCode_txt";
            // 
            // ItemName_lbl
            // 
            resources.ApplyResources(this.ItemName_lbl, "ItemName_lbl");
            this.ItemName_lbl.ControlId = null;
            this.ItemName_lbl.Name = "ItemName_lbl";
            // 
            // ItemName_txt
            // 
            this.ItemName_txt.ControlId = null;
            resources.ApplyResources(this.ItemName_txt, "ItemName_txt");
            this.ItemName_txt.InputType = Com.Nidec.Mes.Framework.TextBoxCommon.InputTypeList.All;
            this.ItemName_txt.Name = "ItemName_txt";
            // 
            // ItemCode_lbl
            // 
            resources.ApplyResources(this.ItemCode_lbl, "ItemCode_lbl");
            this.ItemCode_lbl.ControlId = null;
            this.ItemCode_lbl.Name = "ItemCode_lbl";
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
            // UnitType_lbl
            // 
            resources.ApplyResources(this.UnitType_lbl, "UnitType_lbl");
            this.UnitType_lbl.ControlId = null;
            this.UnitType_lbl.Name = "UnitType_lbl";
            // 
            // UnitType_cmb
            // 
            this.UnitType_cmb.ControlId = null;
            resources.ApplyResources(this.UnitType_cmb, "UnitType_cmb");
            this.UnitType_cmb.FormattingEnabled = true;
            this.UnitType_cmb.Name = "UnitType_cmb";
            // 
            // AddItemForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.UnitType_cmb);
            this.Controls.Add(this.labelCommon3);
            this.Controls.Add(this.UnitType_lbl);
            this.Controls.Add(this.labelCommon1);
            this.Controls.Add(this.labelCommon2);
            this.Controls.Add(this.Exit_btn);
            this.Controls.Add(this.Ok_btn);
            this.Controls.Add(this.ItemCode_txt);
            this.Controls.Add(this.ItemName_lbl);
            this.Controls.Add(this.ItemName_txt);
            this.Controls.Add(this.ItemCode_lbl);
            this.Name = "AddItemForm";
            this.TitleText = "FormCommon";
            this.Load += new System.EventHandler(this.AddItemForm_Load);
            this.Controls.SetChildIndex(this.ItemCode_lbl, 0);
            this.Controls.SetChildIndex(this.ItemName_txt, 0);
            this.Controls.SetChildIndex(this.ItemName_lbl, 0);
            this.Controls.SetChildIndex(this.ItemCode_txt, 0);
            this.Controls.SetChildIndex(this.Ok_btn, 0);
            this.Controls.SetChildIndex(this.Exit_btn, 0);
            this.Controls.SetChildIndex(this.labelCommon2, 0);
            this.Controls.SetChildIndex(this.labelCommon1, 0);
            this.Controls.SetChildIndex(this.UnitType_lbl, 0);
            this.Controls.SetChildIndex(this.labelCommon3, 0);
            this.Controls.SetChildIndex(this.UnitType_cmb, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Framework.LabelCommon labelCommon2;
        protected Framework.ButtonCommon Exit_btn;
        protected Framework.ButtonCommon Ok_btn;
        protected Framework.TextBoxCommon ItemCode_txt;
        protected Framework.LabelCommon ItemName_lbl;
        protected Framework.TextBoxCommon ItemName_txt;
        protected Framework.LabelCommon ItemCode_lbl;
        protected Framework.LabelCommon UnitType_lbl;
        protected Framework.ComboBoxCommon UnitType_cmb;
        protected Framework.LabelCommon labelCommon1;
        protected Framework.LabelCommon labelCommon3;
    }
}