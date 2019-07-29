namespace Com.Nidec.Mes.GlobalMasterMaintenance
{
    partial class AddShelfForm : FormCommonMaster
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddShelfForm));
            this.Area_lbl = new Com.Nidec.Mes.Framework.LabelCommon();
            this.Area_cmb = new Com.Nidec.Mes.Framework.ComboBoxCommon();
            this.Exit_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.Ok_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.ShelfCode_txt = new Com.Nidec.Mes.Framework.TextBoxCommon();
            this.ShelfName_lbl = new Com.Nidec.Mes.Framework.LabelCommon();
            this.ShelfName_txt = new Com.Nidec.Mes.Framework.TextBoxCommon();
            this.ShelfCode_lbl = new Com.Nidec.Mes.Framework.LabelCommon();
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
            // ShelfCode_txt
            // 
            this.ShelfCode_txt.ControlId = null;
            resources.ApplyResources(this.ShelfCode_txt, "ShelfCode_txt");
            this.ShelfCode_txt.InputType = Com.Nidec.Mes.Framework.TextBoxCommon.InputTypeList.All;
            this.ShelfCode_txt.Name = "ShelfCode_txt";
            // 
            // ShelfName_lbl
            // 
            resources.ApplyResources(this.ShelfName_lbl, "ShelfName_lbl");
            this.ShelfName_lbl.ControlId = null;
            this.ShelfName_lbl.Name = "ShelfName_lbl";
            // 
            // ShelfName_txt
            // 
            this.ShelfName_txt.ControlId = null;
            resources.ApplyResources(this.ShelfName_txt, "ShelfName_txt");
            this.ShelfName_txt.InputType = Com.Nidec.Mes.Framework.TextBoxCommon.InputTypeList.All;
            this.ShelfName_txt.Name = "ShelfName_txt";
            // 
            // ShelfCode_lbl
            // 
            resources.ApplyResources(this.ShelfCode_lbl, "ShelfCode_lbl");
            this.ShelfCode_lbl.ControlId = null;
            this.ShelfCode_lbl.Name = "ShelfCode_lbl";
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
            // AddShelfForm
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
            this.Controls.Add(this.ShelfCode_txt);
            this.Controls.Add(this.ShelfName_lbl);
            this.Controls.Add(this.ShelfName_txt);
            this.Controls.Add(this.ShelfCode_lbl);
            this.Name = "AddShelfForm";
            this.TitleText = "FormCommon";
            this.Load += new System.EventHandler(this.AddShelfForm_Load);
            this.Controls.SetChildIndex(this.ShelfCode_lbl, 0);
            this.Controls.SetChildIndex(this.ShelfName_txt, 0);
            this.Controls.SetChildIndex(this.ShelfName_lbl, 0);
            this.Controls.SetChildIndex(this.ShelfCode_txt, 0);
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
        private Com.Nidec.Mes.Framework.TextBoxCommon ShelfCode_txt;
        private Com.Nidec.Mes.Framework.LabelCommon ShelfName_lbl;
        private Com.Nidec.Mes.Framework.TextBoxCommon ShelfName_txt;
        private Com.Nidec.Mes.Framework.LabelCommon ShelfCode_lbl;
        private Framework.LabelCommon labelCommon2;
        private Framework.LabelCommon labelCommon1;
        private Framework.LabelCommon labelCommon3;
        private Framework.LabelCommon UpdateText_lbl;
    }
}