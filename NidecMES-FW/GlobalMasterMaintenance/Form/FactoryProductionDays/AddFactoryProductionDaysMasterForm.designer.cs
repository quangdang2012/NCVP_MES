namespace Com.Nidec.Mes.GlobalMasterMaintenance
{
    partial class AddFactoryProductionDaysMasterForm : FormCommonMaster
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddFactoryProductionDaysMasterForm));
            this.Building_lbl = new Com.Nidec.Mes.Framework.LabelCommon();
            this.Year_lbl = new Com.Nidec.Mes.Framework.LabelCommon();
            this.Exit_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.Ok_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.MandatorySymbol_lbl2 = new Com.Nidec.Mes.Framework.LabelCommon();
            this.UpdateText_lbl = new Com.Nidec.Mes.Framework.LabelCommon();
            this.MandatorySymbol_lbl1 = new Com.Nidec.Mes.Framework.LabelCommon();
            this.Building_cmb = new Com.Nidec.Mes.Framework.ComboBoxCommon();
            this.Month_cmb = new Com.Nidec.Mes.Framework.ComboBoxCommon();
            this.Year_txt = new Com.Nidec.Mes.Framework.TextBoxCommon();
            this.MandatorySymbol_lbl3 = new Com.Nidec.Mes.Framework.LabelCommon();
            this.Date_txt = new Com.Nidec.Mes.Framework.TextBoxCommon();
            this.MonthDate_lbl = new Com.Nidec.Mes.Framework.LabelCommon();
            this.SuspendLayout();
            // 
            // Building_lbl
            // 
            resources.ApplyResources(this.Building_lbl, "Building_lbl");
            this.Building_lbl.ControlId = null;
            this.Building_lbl.Name = "Building_lbl";
            // 
            // Year_lbl
            // 
            resources.ApplyResources(this.Year_lbl, "Year_lbl");
            this.Year_lbl.ControlId = null;
            this.Year_lbl.Name = "Year_lbl";
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
            // MandatorySymbol_lbl2
            // 
            resources.ApplyResources(this.MandatorySymbol_lbl2, "MandatorySymbol_lbl2");
            this.MandatorySymbol_lbl2.ControlId = null;
            this.MandatorySymbol_lbl2.ForeColor = System.Drawing.Color.DarkRed;
            this.MandatorySymbol_lbl2.Name = "MandatorySymbol_lbl2";
            // 
            // UpdateText_lbl
            // 
            resources.ApplyResources(this.UpdateText_lbl, "UpdateText_lbl");
            this.UpdateText_lbl.ControlId = null;
            this.UpdateText_lbl.Name = "UpdateText_lbl";
            // 
            // MandatorySymbol_lbl1
            // 
            resources.ApplyResources(this.MandatorySymbol_lbl1, "MandatorySymbol_lbl1");
            this.MandatorySymbol_lbl1.ControlId = null;
            this.MandatorySymbol_lbl1.ForeColor = System.Drawing.Color.DarkRed;
            this.MandatorySymbol_lbl1.Name = "MandatorySymbol_lbl1";
            // 
            // Building_cmb
            // 
            resources.ApplyResources(this.Building_cmb, "Building_cmb");
            this.Building_cmb.ControlId = null;
            this.Building_cmb.FormattingEnabled = true;
            this.Building_cmb.Name = "Building_cmb";
            this.Building_cmb.SelectionChangeCommitted += new System.EventHandler(this.Building_cmb_SelectionChangeCommitted);
            // 
            // Month_cmb
            // 
            resources.ApplyResources(this.Month_cmb, "Month_cmb");
            this.Month_cmb.ControlId = null;
            this.Month_cmb.FormattingEnabled = true;
            this.Month_cmb.Items.AddRange(new object[] {
            resources.GetString("Month_cmb.Items"),
            resources.GetString("Month_cmb.Items1"),
            resources.GetString("Month_cmb.Items2"),
            resources.GetString("Month_cmb.Items3"),
            resources.GetString("Month_cmb.Items4"),
            resources.GetString("Month_cmb.Items5"),
            resources.GetString("Month_cmb.Items6"),
            resources.GetString("Month_cmb.Items7"),
            resources.GetString("Month_cmb.Items8"),
            resources.GetString("Month_cmb.Items9"),
            resources.GetString("Month_cmb.Items10"),
            resources.GetString("Month_cmb.Items11")});
            this.Month_cmb.Name = "Month_cmb";
            this.Month_cmb.SelectionChangeCommitted += new System.EventHandler(this.Month_cmb_SelectionChangeCommitted);
            // 
            // Year_txt
            // 
            resources.ApplyResources(this.Year_txt, "Year_txt");
            this.Year_txt.ControlId = null;
            this.Year_txt.InputType = Com.Nidec.Mes.Framework.TextBoxCommon.InputTypeList.Numeric;
            this.Year_txt.Name = "Year_txt";
            // 
            // MandatorySymbol_lbl3
            // 
            resources.ApplyResources(this.MandatorySymbol_lbl3, "MandatorySymbol_lbl3");
            this.MandatorySymbol_lbl3.ControlId = null;
            this.MandatorySymbol_lbl3.ForeColor = System.Drawing.Color.DarkRed;
            this.MandatorySymbol_lbl3.Name = "MandatorySymbol_lbl3";
            // 
            // Date_txt
            // 
            resources.ApplyResources(this.Date_txt, "Date_txt");
            this.Date_txt.ControlId = null;
            this.Date_txt.InputType = Com.Nidec.Mes.Framework.TextBoxCommon.InputTypeList.Numeric;
            this.Date_txt.Name = "Date_txt";
            // 
            // MonthDate_lbl
            // 
            resources.ApplyResources(this.MonthDate_lbl, "MonthDate_lbl");
            this.MonthDate_lbl.ControlId = null;
            this.MonthDate_lbl.Name = "MonthDate_lbl";
            // 
            // AddFactoryProductionDaysMasterForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.MonthDate_lbl);
            this.Controls.Add(this.Date_txt);
            this.Controls.Add(this.MandatorySymbol_lbl3);
            this.Controls.Add(this.Year_txt);
            this.Controls.Add(this.Month_cmb);
            this.Controls.Add(this.Building_cmb);
            this.Controls.Add(this.MandatorySymbol_lbl1);
            this.Controls.Add(this.UpdateText_lbl);
            this.Controls.Add(this.MandatorySymbol_lbl2);
            this.Controls.Add(this.Exit_btn);
            this.Controls.Add(this.Ok_btn);
            this.Controls.Add(this.Year_lbl);
            this.Controls.Add(this.Building_lbl);
            this.Name = "AddFactoryProductionDaysMasterForm";
            this.TitleText = "FormCommon";
            this.Load += new System.EventHandler(this.AddFactoryProductionDaysMasterForm_Load);
            this.Controls.SetChildIndex(this.Building_lbl, 0);
            this.Controls.SetChildIndex(this.Year_lbl, 0);
            this.Controls.SetChildIndex(this.Ok_btn, 0);
            this.Controls.SetChildIndex(this.Exit_btn, 0);
            this.Controls.SetChildIndex(this.MandatorySymbol_lbl2, 0);
            this.Controls.SetChildIndex(this.UpdateText_lbl, 0);
            this.Controls.SetChildIndex(this.MandatorySymbol_lbl1, 0);
            this.Controls.SetChildIndex(this.Building_cmb, 0);
            this.Controls.SetChildIndex(this.Month_cmb, 0);
            this.Controls.SetChildIndex(this.Year_txt, 0);
            this.Controls.SetChildIndex(this.MandatorySymbol_lbl3, 0);
            this.Controls.SetChildIndex(this.Date_txt, 0);
            this.Controls.SetChildIndex(this.MonthDate_lbl, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        protected Com.Nidec.Mes.Framework.LabelCommon Building_lbl;
        protected Com.Nidec.Mes.Framework.LabelCommon Year_lbl;
        protected Com.Nidec.Mes.Framework.ButtonCommon Exit_btn;
        protected Com.Nidec.Mes.Framework.ButtonCommon Ok_btn;
        protected Framework.LabelCommon MandatorySymbol_lbl2;
        protected Framework.LabelCommon UpdateText_lbl;
        protected Framework.LabelCommon MandatorySymbol_lbl1;
        private Framework.ComboBoxCommon Building_cmb;
        private Framework.ComboBoxCommon Month_cmb;
        private Framework.TextBoxCommon Year_txt;
        protected Framework.LabelCommon MandatorySymbol_lbl3;
        private Framework.TextBoxCommon Date_txt;
        protected Framework.LabelCommon MonthDate_lbl;
    }
}
