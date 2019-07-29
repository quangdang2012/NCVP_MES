namespace Com.Nidec.Mes.GlobalMasterMaintenance
{
    partial class AddLocationForm : FormCommonMaster
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddLocationForm));
            this.Mold_lbl = new Com.Nidec.Mes.Framework.LabelCommon();
            this.Building_cmb = new Com.Nidec.Mes.Framework.ComboBoxCommon();
            this.Exit_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.Ok_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.LocationCode_txt = new Com.Nidec.Mes.Framework.TextBoxCommon();
            this.LocationName_lbl = new Com.Nidec.Mes.Framework.LabelCommon();
            this.LocationName_txt = new Com.Nidec.Mes.Framework.TextBoxCommon();
            this.LocationCode_lbl = new Com.Nidec.Mes.Framework.LabelCommon();
            this.labelCommon2 = new Com.Nidec.Mes.Framework.LabelCommon();
            this.labelCommon1 = new Com.Nidec.Mes.Framework.LabelCommon();
            this.labelCommon3 = new Com.Nidec.Mes.Framework.LabelCommon();
            this.UpdateText_lbl = new Com.Nidec.Mes.Framework.LabelCommon();
            this.SuspendLayout();
            // 
            // Mold_lbl
            // 
            resources.ApplyResources(this.Mold_lbl, "Mold_lbl");
            this.Mold_lbl.ControlId = null;
            this.Mold_lbl.Name = "Mold_lbl";
            // 
            // Building_cmb
            // 
            this.Building_cmb.ControlId = null;
            resources.ApplyResources(this.Building_cmb, "Building_cmb");
            this.Building_cmb.FormattingEnabled = true;
            this.Building_cmb.Name = "Building_cmb";
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
            // LocationCode_txt
            // 
            this.LocationCode_txt.ControlId = null;
            resources.ApplyResources(this.LocationCode_txt, "LocationCode_txt");
            this.LocationCode_txt.InputType = Com.Nidec.Mes.Framework.TextBoxCommon.InputTypeList.All;
            this.LocationCode_txt.Name = "LocationCode_txt";
            // 
            // LocationName_lbl
            // 
            resources.ApplyResources(this.LocationName_lbl, "LocationName_lbl");
            this.LocationName_lbl.ControlId = null;
            this.LocationName_lbl.Name = "LocationName_lbl";
            // 
            // LocationName_txt
            // 
            this.LocationName_txt.ControlId = null;
            resources.ApplyResources(this.LocationName_txt, "LocationName_txt");
            this.LocationName_txt.InputType = Com.Nidec.Mes.Framework.TextBoxCommon.InputTypeList.All;
            this.LocationName_txt.Name = "LocationName_txt";
            // 
            // LocationCode_lbl
            // 
            resources.ApplyResources(this.LocationCode_lbl, "LocationCode_lbl");
            this.LocationCode_lbl.ControlId = null;
            this.LocationCode_lbl.Name = "LocationCode_lbl";
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
            // AddLocationForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.UpdateText_lbl);
            this.Controls.Add(this.labelCommon3);
            this.Controls.Add(this.labelCommon1);
            this.Controls.Add(this.labelCommon2);
            this.Controls.Add(this.Mold_lbl);
            this.Controls.Add(this.Building_cmb);
            this.Controls.Add(this.Exit_btn);
            this.Controls.Add(this.Ok_btn);
            this.Controls.Add(this.LocationCode_txt);
            this.Controls.Add(this.LocationName_lbl);
            this.Controls.Add(this.LocationName_txt);
            this.Controls.Add(this.LocationCode_lbl);
            this.Name = "AddLocationForm";
            this.TitleText = "FormCommon";
            this.Load += new System.EventHandler(this.AddLocationForm_Load);
            this.Controls.SetChildIndex(this.LocationCode_lbl, 0);
            this.Controls.SetChildIndex(this.LocationName_txt, 0);
            this.Controls.SetChildIndex(this.LocationName_lbl, 0);
            this.Controls.SetChildIndex(this.LocationCode_txt, 0);
            this.Controls.SetChildIndex(this.Ok_btn, 0);
            this.Controls.SetChildIndex(this.Exit_btn, 0);
            this.Controls.SetChildIndex(this.Building_cmb, 0);
            this.Controls.SetChildIndex(this.Mold_lbl, 0);
            this.Controls.SetChildIndex(this.labelCommon2, 0);
            this.Controls.SetChildIndex(this.labelCommon1, 0);
            this.Controls.SetChildIndex(this.labelCommon3, 0);
            this.Controls.SetChildIndex(this.UpdateText_lbl, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Com.Nidec.Mes.Framework.LabelCommon Mold_lbl;
        private Com.Nidec.Mes.Framework.ComboBoxCommon Building_cmb;
        private Com.Nidec.Mes.Framework.ButtonCommon Exit_btn;
        private Com.Nidec.Mes.Framework.ButtonCommon Ok_btn;
        private Com.Nidec.Mes.Framework.TextBoxCommon LocationCode_txt;
        private Com.Nidec.Mes.Framework.LabelCommon LocationName_lbl;
        private Com.Nidec.Mes.Framework.TextBoxCommon LocationName_txt;
        private Com.Nidec.Mes.Framework.LabelCommon LocationCode_lbl;
        private Framework.LabelCommon labelCommon2;
        private Framework.LabelCommon labelCommon1;
        private Framework.LabelCommon labelCommon3;
        private Framework.LabelCommon UpdateText_lbl;
    }
}