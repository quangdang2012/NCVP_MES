namespace Com.Nidec.Mes.GlobalMasterMaintenance
{
    partial class AddProdutionWorkContentTypeForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddProdutionWorkContentTypeForm));
            this.labelCommon1 = new Com.Nidec.Mes.Framework.LabelCommon();
            this.labelCommon2 = new Com.Nidec.Mes.Framework.LabelCommon();
            this.Exit_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.Ok_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.ProdutionWorkContentTypeCode_txt = new Com.Nidec.Mes.Framework.TextBoxCommon();
            this.ProdutionWorkContentTypeName_lbl = new Com.Nidec.Mes.Framework.LabelCommon();
            this.ProdutionWorkContentTypeName_txt = new Com.Nidec.Mes.Framework.TextBoxCommon();
            this.ProdutionWorkContentTypeCode_lbl = new Com.Nidec.Mes.Framework.LabelCommon();
            this.SuspendLayout();
            // 
            // labelCommon1
            // 
            this.labelCommon1.ControlId = null;
            resources.ApplyResources(this.labelCommon1, "labelCommon1");
            this.labelCommon1.ForeColor = System.Drawing.Color.DarkRed;
            this.labelCommon1.Name = "labelCommon1";
            // 
            // labelCommon2
            // 
            this.labelCommon2.ControlId = null;
            resources.ApplyResources(this.labelCommon2, "labelCommon2");
            this.labelCommon2.ForeColor = System.Drawing.Color.DarkRed;
            this.labelCommon2.Name = "labelCommon2";
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
            // ProdutionWorkContentTypeCode_txt
            // 
            this.ProdutionWorkContentTypeCode_txt.ControlId = null;
            resources.ApplyResources(this.ProdutionWorkContentTypeCode_txt, "ProdutionWorkContentTypeCode_txt");
            this.ProdutionWorkContentTypeCode_txt.InputType = Com.Nidec.Mes.Framework.TextBoxCommon.InputTypeList.All;
            this.ProdutionWorkContentTypeCode_txt.Name = "ProdutionWorkContentTypeCode_txt";
            // 
            // ProdutionWorkContentTypeName_lbl
            // 
            resources.ApplyResources(this.ProdutionWorkContentTypeName_lbl, "ProdutionWorkContentTypeName_lbl");
            this.ProdutionWorkContentTypeName_lbl.ControlId = null;
            this.ProdutionWorkContentTypeName_lbl.Name = "ProdutionWorkContentTypeName_lbl";
            // 
            // ProdutionWorkContentTypeName_txt
            // 
            this.ProdutionWorkContentTypeName_txt.ControlId = null;
            resources.ApplyResources(this.ProdutionWorkContentTypeName_txt, "ProdutionWorkContentTypeName_txt");
            this.ProdutionWorkContentTypeName_txt.InputType = Com.Nidec.Mes.Framework.TextBoxCommon.InputTypeList.All;
            this.ProdutionWorkContentTypeName_txt.Name = "ProdutionWorkContentTypeName_txt";
            // 
            // ProdutionWorkContentTypeCode_lbl
            // 
            resources.ApplyResources(this.ProdutionWorkContentTypeCode_lbl, "ProdutionWorkContentTypeCode_lbl");
            this.ProdutionWorkContentTypeCode_lbl.ControlId = null;
            this.ProdutionWorkContentTypeCode_lbl.Name = "ProdutionWorkContentTypeCode_lbl";
            // 
            // AddProdutionWorkContentTypeForm
            // 
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.ProdutionWorkContentTypeCode_txt);
            this.Controls.Add(this.ProdutionWorkContentTypeName_lbl);
            this.Controls.Add(this.ProdutionWorkContentTypeName_txt);
            this.Controls.Add(this.ProdutionWorkContentTypeCode_lbl);
            this.Controls.Add(this.labelCommon1);
            this.Controls.Add(this.labelCommon2);
            this.Controls.Add(this.Exit_btn);
            this.Controls.Add(this.Ok_btn);
            this.Name = "AddProdutionWorkContentTypeForm";
            this.TitleText = "FormCommon";
            this.Load += new System.EventHandler(this.AddProdutionWorkContentTypeMasterForm_Load);
            this.Controls.SetChildIndex(this.Ok_btn, 0);
            this.Controls.SetChildIndex(this.Exit_btn, 0);
            this.Controls.SetChildIndex(this.labelCommon2, 0);
            this.Controls.SetChildIndex(this.labelCommon1, 0);
            this.Controls.SetChildIndex(this.ProdutionWorkContentTypeCode_lbl, 0);
            this.Controls.SetChildIndex(this.ProdutionWorkContentTypeName_txt, 0);
            this.Controls.SetChildIndex(this.ProdutionWorkContentTypeName_lbl, 0);
            this.Controls.SetChildIndex(this.ProdutionWorkContentTypeCode_txt, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Framework.LabelCommon labelCommon1;
        private Framework.LabelCommon labelCommon2;
        private Framework.ButtonCommon Exit_btn;
        private Framework.ButtonCommon Ok_btn;
        private Framework.TextBoxCommon ProdutionWorkContentTypeCode_txt;
        private Framework.LabelCommon ProdutionWorkContentTypeName_lbl;
        private Framework.TextBoxCommon ProdutionWorkContentTypeName_txt;
        private Framework.LabelCommon ProdutionWorkContentTypeCode_lbl;
    }
}
