namespace Com.Nidec.Mes.GlobalMasterMaintenance
{
    partial class AddGlobalItemForm : FormCommonMaster
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddGlobalItemForm));
            this.Exit_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.Ok_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.GlobalItemCode_txt = new Com.Nidec.Mes.Framework.TextBoxCommon();
            this.GlobalItemName_lbl = new Com.Nidec.Mes.Framework.LabelCommon();
            this.GlobalItemName_txt = new Com.Nidec.Mes.Framework.TextBoxCommon();
            this.GlobalItemCode_lbl = new Com.Nidec.Mes.Framework.LabelCommon();
            this.labelCommon2 = new Com.Nidec.Mes.Framework.LabelCommon();
            this.labelCommon1 = new Com.Nidec.Mes.Framework.LabelCommon();
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
            // GlobalItemCode_txt
            // 
            this.GlobalItemCode_txt.ControlId = null;
            resources.ApplyResources(this.GlobalItemCode_txt, "GlobalItemCode_txt");
            this.GlobalItemCode_txt.InputType = Com.Nidec.Mes.Framework.TextBoxCommon.InputTypeList.All;
            this.GlobalItemCode_txt.Name = "GlobalItemCode_txt";
            // 
            // GlobalItemName_lbl
            // 
            resources.ApplyResources(this.GlobalItemName_lbl, "GlobalItemName_lbl");
            this.GlobalItemName_lbl.ControlId = null;
            this.GlobalItemName_lbl.Name = "GlobalItemName_lbl";
            // 
            // GlobalItemName_txt
            // 
            this.GlobalItemName_txt.ControlId = null;
            resources.ApplyResources(this.GlobalItemName_txt, "GlobalItemName_txt");
            this.GlobalItemName_txt.InputType = Com.Nidec.Mes.Framework.TextBoxCommon.InputTypeList.All;
            this.GlobalItemName_txt.Name = "GlobalItemName_txt";
            // 
            // GlobalItemCode_lbl
            // 
            resources.ApplyResources(this.GlobalItemCode_lbl, "GlobalItemCode_lbl");
            this.GlobalItemCode_lbl.ControlId = null;
            this.GlobalItemCode_lbl.Name = "GlobalItemCode_lbl";
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
            // AddGlobalItemForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.labelCommon1);
            this.Controls.Add(this.labelCommon2);
            this.Controls.Add(this.Exit_btn);
            this.Controls.Add(this.Ok_btn);
            this.Controls.Add(this.GlobalItemCode_txt);
            this.Controls.Add(this.GlobalItemName_lbl);
            this.Controls.Add(this.GlobalItemName_txt);
            this.Controls.Add(this.GlobalItemCode_lbl);
            this.Name = "AddGlobalItemForm";
            this.TitleText = "FormCommon";
            this.Load += new System.EventHandler(this.AddItemForm_Load);
            this.Controls.SetChildIndex(this.GlobalItemCode_lbl, 0);
            this.Controls.SetChildIndex(this.GlobalItemName_txt, 0);
            this.Controls.SetChildIndex(this.GlobalItemName_lbl, 0);
            this.Controls.SetChildIndex(this.GlobalItemCode_txt, 0);
            this.Controls.SetChildIndex(this.Ok_btn, 0);
            this.Controls.SetChildIndex(this.Exit_btn, 0);
            this.Controls.SetChildIndex(this.labelCommon2, 0);
            this.Controls.SetChildIndex(this.labelCommon1, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Framework.LabelCommon labelCommon2;
        private Framework.LabelCommon labelCommon1;
        protected Framework.ButtonCommon Exit_btn;
        protected Framework.ButtonCommon Ok_btn;
        protected Framework.TextBoxCommon GlobalItemCode_txt;
        protected Framework.LabelCommon GlobalItemName_lbl;
        protected Framework.TextBoxCommon GlobalItemName_txt;
        protected Framework.LabelCommon GlobalItemCode_lbl;
    }
}