namespace Com.Nidec.Mes.GlobalMasterMaintenance
{
    partial class AddPaletteForm : FormCommonMaster
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddPaletteForm));
            this.Area_lbl = new Com.Nidec.Mes.Framework.LabelCommon();
            this.Area_cmb = new Com.Nidec.Mes.Framework.ComboBoxCommon();
            this.Exit_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.Ok_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.PaletteCode_txt = new Com.Nidec.Mes.Framework.TextBoxCommon();
            this.PaletteName_lbl = new Com.Nidec.Mes.Framework.LabelCommon();
            this.PaletteName_txt = new Com.Nidec.Mes.Framework.TextBoxCommon();
            this.PaletteCode_lbl = new Com.Nidec.Mes.Framework.LabelCommon();
            this.labelCommon2 = new Com.Nidec.Mes.Framework.LabelCommon();
            this.labelCommon1 = new Com.Nidec.Mes.Framework.LabelCommon();
            this.labelCommon3 = new Com.Nidec.Mes.Framework.LabelCommon();
            this.UpdateText_lbl = new Com.Nidec.Mes.Framework.LabelCommon();
            this.SuspendLayout();
            // 
            // Area_lbl
            // 
            resources.ApplyResources(this.Area_lbl, "Area_lbl");
            this.Area_lbl.ControlId = null;
            this.Area_lbl.Name = "Area_lbl";
            // 
            // Area_cmb
            // 
            this.Area_cmb.ControlId = null;
            resources.ApplyResources(this.Area_cmb, "Area_cmb");
            this.Area_cmb.FormattingEnabled = true;
            this.Area_cmb.Name = "Area_cmb";
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
            // PaletteCode_txt
            // 
            this.PaletteCode_txt.ControlId = null;
            resources.ApplyResources(this.PaletteCode_txt, "PaletteCode_txt");
            this.PaletteCode_txt.InputType = Com.Nidec.Mes.Framework.TextBoxCommon.InputTypeList.All;
            this.PaletteCode_txt.Name = "PaletteCode_txt";
            // 
            // PaletteName_lbl
            // 
            resources.ApplyResources(this.PaletteName_lbl, "PaletteName_lbl");
            this.PaletteName_lbl.ControlId = null;
            this.PaletteName_lbl.Name = "PaletteName_lbl";
            // 
            // PaletteName_txt
            // 
            this.PaletteName_txt.ControlId = null;
            resources.ApplyResources(this.PaletteName_txt, "PaletteName_txt");
            this.PaletteName_txt.InputType = Com.Nidec.Mes.Framework.TextBoxCommon.InputTypeList.All;
            this.PaletteName_txt.Name = "PaletteName_txt";
            // 
            // PaletteCode_lbl
            // 
            resources.ApplyResources(this.PaletteCode_lbl, "PaletteCode_lbl");
            this.PaletteCode_lbl.ControlId = null;
            this.PaletteCode_lbl.Name = "PaletteCode_lbl";
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
            // AddPaletteForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.UpdateText_lbl);
            this.Controls.Add(this.labelCommon3);
            this.Controls.Add(this.labelCommon1);
            this.Controls.Add(this.labelCommon2);
            this.Controls.Add(this.Area_lbl);
            this.Controls.Add(this.Area_cmb);
            this.Controls.Add(this.Exit_btn);
            this.Controls.Add(this.Ok_btn);
            this.Controls.Add(this.PaletteCode_txt);
            this.Controls.Add(this.PaletteName_lbl);
            this.Controls.Add(this.PaletteName_txt);
            this.Controls.Add(this.PaletteCode_lbl);
            this.Name = "AddPaletteForm";
            this.TitleText = "FormCommon";
            this.Load += new System.EventHandler(this.AddPaletteForm_Load);
            this.Controls.SetChildIndex(this.PaletteCode_lbl, 0);
            this.Controls.SetChildIndex(this.PaletteName_txt, 0);
            this.Controls.SetChildIndex(this.PaletteName_lbl, 0);
            this.Controls.SetChildIndex(this.PaletteCode_txt, 0);
            this.Controls.SetChildIndex(this.Ok_btn, 0);
            this.Controls.SetChildIndex(this.Exit_btn, 0);
            this.Controls.SetChildIndex(this.Area_cmb, 0);
            this.Controls.SetChildIndex(this.Area_lbl, 0);
            this.Controls.SetChildIndex(this.labelCommon2, 0);
            this.Controls.SetChildIndex(this.labelCommon1, 0);
            this.Controls.SetChildIndex(this.labelCommon3, 0);
            this.Controls.SetChildIndex(this.UpdateText_lbl, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Com.Nidec.Mes.Framework.LabelCommon Area_lbl;
        private Com.Nidec.Mes.Framework.ComboBoxCommon Area_cmb;
        private Com.Nidec.Mes.Framework.ButtonCommon Exit_btn;
        private Com.Nidec.Mes.Framework.ButtonCommon Ok_btn;
        private Com.Nidec.Mes.Framework.TextBoxCommon PaletteCode_txt;
        private Com.Nidec.Mes.Framework.LabelCommon PaletteName_lbl;
        private Com.Nidec.Mes.Framework.TextBoxCommon PaletteName_txt;
        private Com.Nidec.Mes.Framework.LabelCommon PaletteCode_lbl;
        private Framework.LabelCommon labelCommon2;
        private Framework.LabelCommon labelCommon1;
        private Framework.LabelCommon labelCommon3;
        private Framework.LabelCommon UpdateText_lbl;
    }
}