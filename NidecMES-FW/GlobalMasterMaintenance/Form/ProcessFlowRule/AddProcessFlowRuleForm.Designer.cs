namespace Com.Nidec.Mes.GlobalMasterMaintenance
{
    partial class AddProcessFlowRuleForm : FormCommonMaster
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddProcessFlowRuleForm));
            this.Exit_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.Ok_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.ProcessFlowRuleCode_txt = new Com.Nidec.Mes.Framework.TextBoxCommon();
            this.Comment_lbl = new Com.Nidec.Mes.Framework.LabelCommon();
            this.Comment_txt = new Com.Nidec.Mes.Framework.TextBoxCommon();
            this.ProcessFlowRuleCode_lbl = new Com.Nidec.Mes.Framework.LabelCommon();
            this.labelCommon2 = new Com.Nidec.Mes.Framework.LabelCommon();
            this.labelCommon1 = new Com.Nidec.Mes.Framework.LabelCommon();
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
            // ProcessFlowRuleCode_txt
            // 
            this.ProcessFlowRuleCode_txt.ControlId = null;
            resources.ApplyResources(this.ProcessFlowRuleCode_txt, "ProcessFlowRuleCode_txt");
            this.ProcessFlowRuleCode_txt.InputType = Com.Nidec.Mes.Framework.TextBoxCommon.InputTypeList.All;
            this.ProcessFlowRuleCode_txt.Name = "ProcessFlowRuleCode_txt";
            // 
            // Comment_lbl
            // 
            resources.ApplyResources(this.Comment_lbl, "Comment_lbl");
            this.Comment_lbl.ControlId = null;
            this.Comment_lbl.Name = "Comment_lbl";
            // 
            // Comment_txt
            // 
            this.Comment_txt.ControlId = null;
            resources.ApplyResources(this.Comment_txt, "Comment_txt");
            this.Comment_txt.InputType = Com.Nidec.Mes.Framework.TextBoxCommon.InputTypeList.All;
            this.Comment_txt.Name = "Comment_txt";
            // 
            // ProcessFlowRuleCode_lbl
            // 
            resources.ApplyResources(this.ProcessFlowRuleCode_lbl, "ProcessFlowRuleCode_lbl");
            this.ProcessFlowRuleCode_lbl.ControlId = null;
            this.ProcessFlowRuleCode_lbl.Name = "ProcessFlowRuleCode_lbl";
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
            // AddProcessFlowRuleForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.UpdateText_lbl);
            this.Controls.Add(this.labelCommon1);
            this.Controls.Add(this.labelCommon2);
            this.Controls.Add(this.Exit_btn);
            this.Controls.Add(this.Ok_btn);
            this.Controls.Add(this.ProcessFlowRuleCode_txt);
            this.Controls.Add(this.Comment_lbl);
            this.Controls.Add(this.Comment_txt);
            this.Controls.Add(this.ProcessFlowRuleCode_lbl);
            this.Name = "AddProcessFlowRuleForm";
            this.TitleText = "FormCommon";
            this.Load += new System.EventHandler(this.AddProcessFlowRuleForm_Load);
            this.Controls.SetChildIndex(this.ProcessFlowRuleCode_lbl, 0);
            this.Controls.SetChildIndex(this.Comment_txt, 0);
            this.Controls.SetChildIndex(this.Comment_lbl, 0);
            this.Controls.SetChildIndex(this.ProcessFlowRuleCode_txt, 0);
            this.Controls.SetChildIndex(this.Ok_btn, 0);
            this.Controls.SetChildIndex(this.Exit_btn, 0);
            this.Controls.SetChildIndex(this.labelCommon2, 0);
            this.Controls.SetChildIndex(this.labelCommon1, 0);
            this.Controls.SetChildIndex(this.UpdateText_lbl, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Com.Nidec.Mes.Framework.ButtonCommon Exit_btn;
        private Com.Nidec.Mes.Framework.ButtonCommon Ok_btn;
        private Com.Nidec.Mes.Framework.TextBoxCommon ProcessFlowRuleCode_txt;
        private Com.Nidec.Mes.Framework.LabelCommon Comment_lbl;
        private Com.Nidec.Mes.Framework.TextBoxCommon Comment_txt;
        private Com.Nidec.Mes.Framework.LabelCommon ProcessFlowRuleCode_lbl;
        private Framework.LabelCommon labelCommon2;
        private Framework.LabelCommon labelCommon1;
        private Framework.LabelCommon UpdateText_lbl;
    }
}