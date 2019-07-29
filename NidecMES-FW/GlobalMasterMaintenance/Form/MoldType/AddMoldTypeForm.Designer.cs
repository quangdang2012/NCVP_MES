namespace Com.Nidec.Mes.GlobalMasterMaintenance
{
    partial class AddMoldTypeForm : FormCommonMaster
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddMoldTypeForm));
            this.Exit_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.Ok_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.MoldTypeCode_txt = new Com.Nidec.Mes.Framework.TextBoxCommon();
            this.MoldTypeName_lbl = new Com.Nidec.Mes.Framework.LabelCommon();
            this.MoldTypeName_txt = new Com.Nidec.Mes.Framework.TextBoxCommon();
            this.MoldTypeCode_lbl = new Com.Nidec.Mes.Framework.LabelCommon();
            this.Item_lbl = new Com.Nidec.Mes.Framework.LabelCommon();
            this.Item_cmb = new Com.Nidec.Mes.Framework.ComboBoxCommon();
            this.labelCommon3 = new Com.Nidec.Mes.Framework.LabelCommon();
            this.labelCommon1 = new Com.Nidec.Mes.Framework.LabelCommon();
            this.labelCommon2 = new Com.Nidec.Mes.Framework.LabelCommon();
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
            // MoldTypeCode_txt
            // 
            this.MoldTypeCode_txt.ControlId = null;
            resources.ApplyResources(this.MoldTypeCode_txt, "MoldTypeCode_txt");
            this.MoldTypeCode_txt.InputType = Com.Nidec.Mes.Framework.TextBoxCommon.InputTypeList.All;
            this.MoldTypeCode_txt.Name = "MoldTypeCode_txt";
            // 
            // MoldTypeName_lbl
            // 
            resources.ApplyResources(this.MoldTypeName_lbl, "MoldTypeName_lbl");
            this.MoldTypeName_lbl.ControlId = null;
            this.MoldTypeName_lbl.Name = "MoldTypeName_lbl";
            // 
            // MoldTypeName_txt
            // 
            this.MoldTypeName_txt.ControlId = null;
            resources.ApplyResources(this.MoldTypeName_txt, "MoldTypeName_txt");
            this.MoldTypeName_txt.InputType = Com.Nidec.Mes.Framework.TextBoxCommon.InputTypeList.All;
            this.MoldTypeName_txt.Name = "MoldTypeName_txt";
            // 
            // MoldTypeCode_lbl
            // 
            resources.ApplyResources(this.MoldTypeCode_lbl, "MoldTypeCode_lbl");
            this.MoldTypeCode_lbl.ControlId = null;
            this.MoldTypeCode_lbl.Name = "MoldTypeCode_lbl";
            // 
            // Item_lbl
            // 
            resources.ApplyResources(this.Item_lbl, "Item_lbl");
            this.Item_lbl.ControlId = null;
            this.Item_lbl.Name = "Item_lbl";
            // 
            // Item_cmb
            // 
            this.Item_cmb.ControlId = null;
            resources.ApplyResources(this.Item_cmb, "Item_cmb");
            this.Item_cmb.FormattingEnabled = true;
            this.Item_cmb.Name = "Item_cmb";
            // 
            // labelCommon3
            // 
            resources.ApplyResources(this.labelCommon3, "labelCommon3");
            this.labelCommon3.ControlId = null;
            this.labelCommon3.ForeColor = System.Drawing.Color.DarkRed;
            this.labelCommon3.Name = "labelCommon3";
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
            // UpdateText_lbl
            // 
            resources.ApplyResources(this.UpdateText_lbl, "UpdateText_lbl");
            this.UpdateText_lbl.ControlId = null;
            this.UpdateText_lbl.Name = "UpdateText_lbl";
            // 
            // AddMoldTypeForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.UpdateText_lbl);
            this.Controls.Add(this.labelCommon1);
            this.Controls.Add(this.labelCommon2);
            this.Controls.Add(this.labelCommon3);
            this.Controls.Add(this.Item_lbl);
            this.Controls.Add(this.Item_cmb);
            this.Controls.Add(this.Exit_btn);
            this.Controls.Add(this.Ok_btn);
            this.Controls.Add(this.MoldTypeCode_txt);
            this.Controls.Add(this.MoldTypeName_lbl);
            this.Controls.Add(this.MoldTypeName_txt);
            this.Controls.Add(this.MoldTypeCode_lbl);
            this.Name = "AddMoldTypeForm";
            this.TitleText = "FormCommon";
            this.Load += new System.EventHandler(this.AddMoldTypeForm_Load);
            this.Controls.SetChildIndex(this.MoldTypeCode_lbl, 0);
            this.Controls.SetChildIndex(this.MoldTypeName_txt, 0);
            this.Controls.SetChildIndex(this.MoldTypeName_lbl, 0);
            this.Controls.SetChildIndex(this.MoldTypeCode_txt, 0);
            this.Controls.SetChildIndex(this.Ok_btn, 0);
            this.Controls.SetChildIndex(this.Exit_btn, 0);
            this.Controls.SetChildIndex(this.Item_cmb, 0);
            this.Controls.SetChildIndex(this.Item_lbl, 0);
            this.Controls.SetChildIndex(this.labelCommon3, 0);
            this.Controls.SetChildIndex(this.labelCommon2, 0);
            this.Controls.SetChildIndex(this.labelCommon1, 0);
            this.Controls.SetChildIndex(this.UpdateText_lbl, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Com.Nidec.Mes.Framework.ButtonCommon Exit_btn;
        private Com.Nidec.Mes.Framework.ButtonCommon Ok_btn;
        private Com.Nidec.Mes.Framework.TextBoxCommon MoldTypeCode_txt;
        private Com.Nidec.Mes.Framework.LabelCommon MoldTypeName_lbl;
        private Com.Nidec.Mes.Framework.TextBoxCommon MoldTypeName_txt;
        private Com.Nidec.Mes.Framework.LabelCommon MoldTypeCode_lbl;
        private Com.Nidec.Mes.Framework.LabelCommon Item_lbl;
        private Com.Nidec.Mes.Framework.ComboBoxCommon Item_cmb;
        private Framework.LabelCommon labelCommon3;
        private Framework.LabelCommon labelCommon1;
        private Framework.LabelCommon labelCommon2;
        private Framework.LabelCommon UpdateText_lbl;
    }
}