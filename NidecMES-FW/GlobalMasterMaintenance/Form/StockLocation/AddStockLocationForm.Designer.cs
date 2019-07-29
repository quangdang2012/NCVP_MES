namespace Com.Nidec.Mes.GlobalMasterMaintenance
{
    partial class AddStockLocationForm : FormCommonMaster
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddStockLocationForm));
            this.Exit_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.Ok_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.StockLocationCode_txt = new Com.Nidec.Mes.Framework.TextBoxCommon();
            this.StockLocationName_lbl = new Com.Nidec.Mes.Framework.LabelCommon();
            this.StockLocationName_txt = new Com.Nidec.Mes.Framework.TextBoxCommon();
            this.StockLocationCode_lbl = new Com.Nidec.Mes.Framework.LabelCommon();
            this.labelCommon2 = new Com.Nidec.Mes.Framework.LabelCommon();
            this.labelCommon1 = new Com.Nidec.Mes.Framework.LabelCommon();
            this.labelCommon4 = new Com.Nidec.Mes.Framework.LabelCommon();
            this.LocationType_cmb = new Com.Nidec.Mes.Framework.ComboBoxCommon();
            this.LocationType_lbl = new Com.Nidec.Mes.Framework.LabelCommon();
            this.labelCommon6 = new Com.Nidec.Mes.Framework.LabelCommon();
            this.DisplayOrder_txt = new Com.Nidec.Mes.Framework.TextBoxCommon();
            this.DisplayOrder_lbl = new Com.Nidec.Mes.Framework.LabelCommon();
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
            // StockLocationCode_txt
            // 
            this.StockLocationCode_txt.ControlId = null;
            resources.ApplyResources(this.StockLocationCode_txt, "StockLocationCode_txt");
            this.StockLocationCode_txt.InputType = Com.Nidec.Mes.Framework.TextBoxCommon.InputTypeList.All;
            this.StockLocationCode_txt.Name = "StockLocationCode_txt";
            // 
            // StockLocationName_lbl
            // 
            resources.ApplyResources(this.StockLocationName_lbl, "StockLocationName_lbl");
            this.StockLocationName_lbl.ControlId = null;
            this.StockLocationName_lbl.Name = "StockLocationName_lbl";
            // 
            // StockLocationName_txt
            // 
            this.StockLocationName_txt.ControlId = null;
            resources.ApplyResources(this.StockLocationName_txt, "StockLocationName_txt");
            this.StockLocationName_txt.InputType = Com.Nidec.Mes.Framework.TextBoxCommon.InputTypeList.All;
            this.StockLocationName_txt.Name = "StockLocationName_txt";
            // 
            // StockLocationCode_lbl
            // 
            resources.ApplyResources(this.StockLocationCode_lbl, "StockLocationCode_lbl");
            this.StockLocationCode_lbl.ControlId = null;
            this.StockLocationCode_lbl.Name = "StockLocationCode_lbl";
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
            // labelCommon4
            // 
            resources.ApplyResources(this.labelCommon4, "labelCommon4");
            this.labelCommon4.ControlId = null;
            this.labelCommon4.ForeColor = System.Drawing.Color.DarkRed;
            this.labelCommon4.Name = "labelCommon4";
            // 
            // LocationType_cmb
            // 
            this.LocationType_cmb.ControlId = null;
            resources.ApplyResources(this.LocationType_cmb, "LocationType_cmb");
            this.LocationType_cmb.FormattingEnabled = true;
            this.LocationType_cmb.Name = "LocationType_cmb";
            // 
            // LocationType_lbl
            // 
            resources.ApplyResources(this.LocationType_lbl, "LocationType_lbl");
            this.LocationType_lbl.ControlId = null;
            this.LocationType_lbl.Name = "LocationType_lbl";
            // 
            // labelCommon6
            // 
            resources.ApplyResources(this.labelCommon6, "labelCommon6");
            this.labelCommon6.ControlId = null;
            this.labelCommon6.ForeColor = System.Drawing.Color.DarkRed;
            this.labelCommon6.Name = "labelCommon6";
            // 
            // DisplayOrder_txt
            // 
            this.DisplayOrder_txt.ControlId = null;
            resources.ApplyResources(this.DisplayOrder_txt, "DisplayOrder_txt");
            this.DisplayOrder_txt.InputType = Com.Nidec.Mes.Framework.TextBoxCommon.InputTypeList.Numeric;
            this.DisplayOrder_txt.Name = "DisplayOrder_txt";
            // 
            // DisplayOrder_lbl
            // 
            resources.ApplyResources(this.DisplayOrder_lbl, "DisplayOrder_lbl");
            this.DisplayOrder_lbl.ControlId = null;
            this.DisplayOrder_lbl.Name = "DisplayOrder_lbl";
            // 
            // AddStockLocationForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.labelCommon6);
            this.Controls.Add(this.DisplayOrder_txt);
            this.Controls.Add(this.DisplayOrder_lbl);
            this.Controls.Add(this.labelCommon4);
            this.Controls.Add(this.LocationType_cmb);
            this.Controls.Add(this.LocationType_lbl);
            this.Controls.Add(this.labelCommon1);
            this.Controls.Add(this.labelCommon2);
            this.Controls.Add(this.Exit_btn);
            this.Controls.Add(this.Ok_btn);
            this.Controls.Add(this.StockLocationCode_txt);
            this.Controls.Add(this.StockLocationName_lbl);
            this.Controls.Add(this.StockLocationName_txt);
            this.Controls.Add(this.StockLocationCode_lbl);
            this.Name = "AddStockLocationForm";
            this.TitleText = "FormCommon";
            this.Load += new System.EventHandler(this.AddStockLocationForm_Load);
            this.Controls.SetChildIndex(this.StockLocationCode_lbl, 0);
            this.Controls.SetChildIndex(this.StockLocationName_txt, 0);
            this.Controls.SetChildIndex(this.StockLocationName_lbl, 0);
            this.Controls.SetChildIndex(this.StockLocationCode_txt, 0);
            this.Controls.SetChildIndex(this.Ok_btn, 0);
            this.Controls.SetChildIndex(this.Exit_btn, 0);
            this.Controls.SetChildIndex(this.labelCommon2, 0);
            this.Controls.SetChildIndex(this.labelCommon1, 0);
            this.Controls.SetChildIndex(this.LocationType_lbl, 0);
            this.Controls.SetChildIndex(this.LocationType_cmb, 0);
            this.Controls.SetChildIndex(this.labelCommon4, 0);
            this.Controls.SetChildIndex(this.DisplayOrder_lbl, 0);
            this.Controls.SetChildIndex(this.DisplayOrder_txt, 0);
            this.Controls.SetChildIndex(this.labelCommon6, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Framework.LabelCommon labelCommon2;
        private Framework.LabelCommon labelCommon1;
        protected Framework.ButtonCommon Exit_btn;
        protected Framework.ButtonCommon Ok_btn;
        protected Framework.TextBoxCommon StockLocationCode_txt;
        protected Framework.LabelCommon StockLocationName_lbl;
        protected Framework.TextBoxCommon StockLocationName_txt;
        protected Framework.LabelCommon StockLocationCode_lbl;
        private Framework.LabelCommon labelCommon4;
        protected Framework.ComboBoxCommon LocationType_cmb;
        protected Framework.LabelCommon LocationType_lbl;
        private Framework.LabelCommon labelCommon6;
        protected Framework.TextBoxCommon DisplayOrder_txt;
        protected Framework.LabelCommon DisplayOrder_lbl;
    }
}