namespace Com.Nidec.Mes.GlobalMasterMaintenance
{
    partial class AddMoldCategoryForm : FormCommonMaster
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddMoldCategoryForm));
            this.Exit_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.Ok_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.MoldCategoryCode_txt = new Com.Nidec.Mes.Framework.TextBoxCommon();
            this.MoldCategoryName_lbl = new Com.Nidec.Mes.Framework.LabelCommon();
            this.MoldCategoryName_txt = new Com.Nidec.Mes.Framework.TextBoxCommon();
            this.MoldCategoryCode_lbl = new Com.Nidec.Mes.Framework.LabelCommon();
            this.labelCommon2 = new Com.Nidec.Mes.Framework.LabelCommon();
            this.labelCommon1 = new Com.Nidec.Mes.Framework.LabelCommon();
            this.UpdateText_lbl = new Com.Nidec.Mes.Framework.LabelCommon();
            this.DisplayOrder_txt = new Com.Nidec.Mes.Framework.TextBoxCommon();
            this.DisplayOrder_lbl = new Com.Nidec.Mes.Framework.LabelCommon();
            this.labelCommon3 = new Com.Nidec.Mes.Framework.LabelCommon();
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
            // MoldCategoryCode_txt
            // 
            resources.ApplyResources(this.MoldCategoryCode_txt, "MoldCategoryCode_txt");
            this.MoldCategoryCode_txt.ControlId = null;
            this.MoldCategoryCode_txt.InputType = Com.Nidec.Mes.Framework.TextBoxCommon.InputTypeList.All;
            this.MoldCategoryCode_txt.Name = "MoldCategoryCode_txt";
            // 
            // MoldCategoryName_lbl
            // 
            resources.ApplyResources(this.MoldCategoryName_lbl, "MoldCategoryName_lbl");
            this.MoldCategoryName_lbl.ControlId = null;
            this.MoldCategoryName_lbl.Name = "MoldCategoryName_lbl";
            // 
            // MoldCategoryName_txt
            // 
            resources.ApplyResources(this.MoldCategoryName_txt, "MoldCategoryName_txt");
            this.MoldCategoryName_txt.ControlId = null;
            this.MoldCategoryName_txt.InputType = Com.Nidec.Mes.Framework.TextBoxCommon.InputTypeList.All;
            this.MoldCategoryName_txt.Name = "MoldCategoryName_txt";
            // 
            // MoldCategoryCode_lbl
            // 
            resources.ApplyResources(this.MoldCategoryCode_lbl, "MoldCategoryCode_lbl");
            this.MoldCategoryCode_lbl.ControlId = null;
            this.MoldCategoryCode_lbl.Name = "MoldCategoryCode_lbl";
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
            // UpdateText_lbl
            // 
            resources.ApplyResources(this.UpdateText_lbl, "UpdateText_lbl");
            this.UpdateText_lbl.ControlId = null;
            this.UpdateText_lbl.Name = "UpdateText_lbl";
            // 
            // DisplayOrder_txt
            // 
            resources.ApplyResources(this.DisplayOrder_txt, "DisplayOrder_txt");
            this.DisplayOrder_txt.ControlId = null;
            this.DisplayOrder_txt.InputType = Com.Nidec.Mes.Framework.TextBoxCommon.InputTypeList.Numeric;
            this.DisplayOrder_txt.Name = "DisplayOrder_txt";
            // 
            // DisplayOrder_lbl
            // 
            resources.ApplyResources(this.DisplayOrder_lbl, "DisplayOrder_lbl");
            this.DisplayOrder_lbl.ControlId = null;
            this.DisplayOrder_lbl.Name = "DisplayOrder_lbl";
            // 
            // labelCommon3
            // 
            resources.ApplyResources(this.labelCommon3, "labelCommon3");
            this.labelCommon3.ControlId = null;
            this.labelCommon3.ForeColor = System.Drawing.Color.DarkRed;
            this.labelCommon3.Name = "labelCommon3";
            // 
            // AddMoldCategoryForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.labelCommon3);
            this.Controls.Add(this.DisplayOrder_txt);
            this.Controls.Add(this.DisplayOrder_lbl);
            this.Controls.Add(this.UpdateText_lbl);
            this.Controls.Add(this.labelCommon1);
            this.Controls.Add(this.labelCommon2);
            this.Controls.Add(this.Exit_btn);
            this.Controls.Add(this.Ok_btn);
            this.Controls.Add(this.MoldCategoryCode_txt);
            this.Controls.Add(this.MoldCategoryName_lbl);
            this.Controls.Add(this.MoldCategoryName_txt);
            this.Controls.Add(this.MoldCategoryCode_lbl);
            this.Name = "AddMoldCategoryForm";
            this.TitleText = "FormCommon";
            this.Load += new System.EventHandler(this.AddMoldCategoryForm_Load);
            this.Controls.SetChildIndex(this.MoldCategoryCode_lbl, 0);
            this.Controls.SetChildIndex(this.MoldCategoryName_txt, 0);
            this.Controls.SetChildIndex(this.MoldCategoryName_lbl, 0);
            this.Controls.SetChildIndex(this.MoldCategoryCode_txt, 0);
            this.Controls.SetChildIndex(this.Ok_btn, 0);
            this.Controls.SetChildIndex(this.Exit_btn, 0);
            this.Controls.SetChildIndex(this.labelCommon2, 0);
            this.Controls.SetChildIndex(this.labelCommon1, 0);
            this.Controls.SetChildIndex(this.UpdateText_lbl, 0);
            this.Controls.SetChildIndex(this.DisplayOrder_lbl, 0);
            this.Controls.SetChildIndex(this.DisplayOrder_txt, 0);
            this.Controls.SetChildIndex(this.labelCommon3, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Com.Nidec.Mes.Framework.ButtonCommon Exit_btn;
        private Com.Nidec.Mes.Framework.ButtonCommon Ok_btn;
        private Com.Nidec.Mes.Framework.TextBoxCommon MoldCategoryCode_txt;
        private Com.Nidec.Mes.Framework.LabelCommon MoldCategoryName_lbl;
        private Com.Nidec.Mes.Framework.TextBoxCommon MoldCategoryName_txt;
        private Com.Nidec.Mes.Framework.LabelCommon MoldCategoryCode_lbl;
        private Framework.LabelCommon labelCommon2;
        private Framework.LabelCommon labelCommon1;
        private Framework.LabelCommon UpdateText_lbl;
        private Framework.TextBoxCommon DisplayOrder_txt;
        private Framework.LabelCommon DisplayOrder_lbl;
        private Framework.LabelCommon labelCommon3;
    }
}