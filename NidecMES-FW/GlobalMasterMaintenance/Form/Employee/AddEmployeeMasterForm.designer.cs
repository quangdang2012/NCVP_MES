namespace Com.Nidec.Mes.GlobalMasterMaintenance
{
    partial class AddEmployeeMasterForm : FormCommonMaster
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddEmployeeMasterForm));
            this.EmployeeCode_txt = new Com.Nidec.Mes.Framework.TextBoxCommon();
            this.EmployeeCode_lbl = new Com.Nidec.Mes.Framework.LabelCommon();
            this.EmployeeName_txt = new Com.Nidec.Mes.Framework.TextBoxCommon();
            this.EmployeeName_lbl = new Com.Nidec.Mes.Framework.LabelCommon();
            this.Exit_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.Ok_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.labelCommon2 = new Com.Nidec.Mes.Framework.LabelCommon();
            this.labelCommon1 = new Com.Nidec.Mes.Framework.LabelCommon();
            this.UpdateText_lbl = new Com.Nidec.Mes.Framework.LabelCommon();
            this.labelCommon3 = new Com.Nidec.Mes.Framework.LabelCommon();
            this.Department_txt = new Com.Nidec.Mes.Framework.TextBoxCommon();
            this.Department_lbl = new Com.Nidec.Mes.Framework.LabelCommon();
            this.IsActive_chk = new System.Windows.Forms.CheckBox();
            this.IsActive_lbl = new Com.Nidec.Mes.Framework.LabelCommon();
            this.SuspendLayout();
            // 
            // EmployeeCode_txt
            // 
            this.EmployeeCode_txt.ControlId = null;
            resources.ApplyResources(this.EmployeeCode_txt, "EmployeeCode_txt");
            this.EmployeeCode_txt.InputType = Com.Nidec.Mes.Framework.TextBoxCommon.InputTypeList.All;
            this.EmployeeCode_txt.Name = "EmployeeCode_txt";
            // 
            // EmployeeCode_lbl
            // 
            resources.ApplyResources(this.EmployeeCode_lbl, "EmployeeCode_lbl");
            this.EmployeeCode_lbl.ControlId = null;
            this.EmployeeCode_lbl.Name = "EmployeeCode_lbl";
            // 
            // EmployeeName_txt
            // 
            this.EmployeeName_txt.ControlId = null;
            resources.ApplyResources(this.EmployeeName_txt, "EmployeeName_txt");
            this.EmployeeName_txt.InputType = Com.Nidec.Mes.Framework.TextBoxCommon.InputTypeList.All;
            this.EmployeeName_txt.Name = "EmployeeName_txt";
            // 
            // EmployeeName_lbl
            // 
            resources.ApplyResources(this.EmployeeName_lbl, "EmployeeName_lbl");
            this.EmployeeName_lbl.ControlId = null;
            this.EmployeeName_lbl.Name = "EmployeeName_lbl";
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
            // labelCommon3
            // 
            resources.ApplyResources(this.labelCommon3, "labelCommon3");
            this.labelCommon3.ControlId = null;
            this.labelCommon3.ForeColor = System.Drawing.Color.DarkRed;
            this.labelCommon3.Name = "labelCommon3";
            // 
            // Department_txt
            // 
            this.Department_txt.ControlId = null;
            resources.ApplyResources(this.Department_txt, "Department_txt");
            this.Department_txt.InputType = Com.Nidec.Mes.Framework.TextBoxCommon.InputTypeList.All;
            this.Department_txt.Name = "Department_txt";
            // 
            // Department_lbl
            // 
            resources.ApplyResources(this.Department_lbl, "Department_lbl");
            this.Department_lbl.ControlId = null;
            this.Department_lbl.Name = "Department_lbl";
            // 
            // IsActive_chk
            // 
            resources.ApplyResources(this.IsActive_chk, "IsActive_chk");
            this.IsActive_chk.Name = "IsActive_chk";
            this.IsActive_chk.UseVisualStyleBackColor = true;
            // 
            // IsActive_lbl
            // 
            resources.ApplyResources(this.IsActive_lbl, "IsActive_lbl");
            this.IsActive_lbl.ControlId = null;
            this.IsActive_lbl.Name = "IsActive_lbl";
            // 
            // AddEmployeeMasterForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.IsActive_chk);
            this.Controls.Add(this.IsActive_lbl);
            this.Controls.Add(this.labelCommon3);
            this.Controls.Add(this.Department_txt);
            this.Controls.Add(this.Department_lbl);
            this.Controls.Add(this.UpdateText_lbl);
            this.Controls.Add(this.labelCommon1);
            this.Controls.Add(this.labelCommon2);
            this.Controls.Add(this.Exit_btn);
            this.Controls.Add(this.Ok_btn);
            this.Controls.Add(this.EmployeeName_txt);
            this.Controls.Add(this.EmployeeName_lbl);
            this.Controls.Add(this.EmployeeCode_txt);
            this.Controls.Add(this.EmployeeCode_lbl);
            this.Name = "AddEmployeeMasterForm";
            this.TitleText = "FormCommon";
            this.Load += new System.EventHandler(this.AddEmployeeMasterForm_Load);
            this.Controls.SetChildIndex(this.EmployeeCode_lbl, 0);
            this.Controls.SetChildIndex(this.EmployeeCode_txt, 0);
            this.Controls.SetChildIndex(this.EmployeeName_lbl, 0);
            this.Controls.SetChildIndex(this.EmployeeName_txt, 0);
            this.Controls.SetChildIndex(this.Ok_btn, 0);
            this.Controls.SetChildIndex(this.Exit_btn, 0);
            this.Controls.SetChildIndex(this.labelCommon2, 0);
            this.Controls.SetChildIndex(this.labelCommon1, 0);
            this.Controls.SetChildIndex(this.UpdateText_lbl, 0);
            this.Controls.SetChildIndex(this.Department_lbl, 0);
            this.Controls.SetChildIndex(this.Department_txt, 0);
            this.Controls.SetChildIndex(this.labelCommon3, 0);
            this.Controls.SetChildIndex(this.IsActive_lbl, 0);
            this.Controls.SetChildIndex(this.IsActive_chk, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Com.Nidec.Mes.Framework.TextBoxCommon EmployeeCode_txt;
        private Com.Nidec.Mes.Framework.LabelCommon EmployeeCode_lbl;
        private Com.Nidec.Mes.Framework.TextBoxCommon EmployeeName_txt;
        private Com.Nidec.Mes.Framework.LabelCommon EmployeeName_lbl;
        private Com.Nidec.Mes.Framework.ButtonCommon Exit_btn;
        private Com.Nidec.Mes.Framework.ButtonCommon Ok_btn;
        private Framework.LabelCommon labelCommon2;
        private Framework.LabelCommon labelCommon1;
        private Framework.LabelCommon UpdateText_lbl;
        private Framework.LabelCommon labelCommon3;
        private Framework.TextBoxCommon Department_txt;
        private Framework.LabelCommon Department_lbl;
        private System.Windows.Forms.CheckBox IsActive_chk;
        private Framework.LabelCommon IsActive_lbl;
    }
}
