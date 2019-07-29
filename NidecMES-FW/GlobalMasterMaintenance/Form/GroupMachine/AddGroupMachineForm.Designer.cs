namespace Com.Nidec.Mes.GlobalMasterMaintenance
{
    partial class AddGroupMachineForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddGroupMachineForm));
            this.GroupMachineCode_txt = new Com.Nidec.Mes.Framework.TextBoxCommon();
            this.GroupMachineName_lbl = new Com.Nidec.Mes.Framework.LabelCommon();
            this.GroupMachineName_txt = new Com.Nidec.Mes.Framework.TextBoxCommon();
            this.GroupMachineCode_lbl = new Com.Nidec.Mes.Framework.LabelCommon();
            this.Exit_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.Ok_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.Machine_cmb = new Com.Nidec.Mes.Framework.ComboBoxCommon();
            this.Machine_lbl = new Com.Nidec.Mes.Framework.LabelCommon();
            this.SuspendLayout();
            // 
            // GroupMachineCode_txt
            // 
            this.GroupMachineCode_txt.ControlId = null;
            resources.ApplyResources(this.GroupMachineCode_txt, "GroupMachineCode_txt");
            this.GroupMachineCode_txt.InputType = Com.Nidec.Mes.Framework.TextBoxCommon.InputTypeList.All;
            this.GroupMachineCode_txt.Name = "GroupMachineCode_txt";
            // 
            // GroupMachineName_lbl
            // 
            resources.ApplyResources(this.GroupMachineName_lbl, "GroupMachineName_lbl");
            this.GroupMachineName_lbl.ControlId = null;
            this.GroupMachineName_lbl.Name = "GroupMachineName_lbl";
            // 
            // GroupMachineName_txt
            // 
            this.GroupMachineName_txt.ControlId = null;
            resources.ApplyResources(this.GroupMachineName_txt, "GroupMachineName_txt");
            this.GroupMachineName_txt.InputType = Com.Nidec.Mes.Framework.TextBoxCommon.InputTypeList.All;
            this.GroupMachineName_txt.Name = "GroupMachineName_txt";
            // 
            // GroupMachineCode_lbl
            // 
            resources.ApplyResources(this.GroupMachineCode_lbl, "GroupMachineCode_lbl");
            this.GroupMachineCode_lbl.ControlId = null;
            this.GroupMachineCode_lbl.Name = "GroupMachineCode_lbl";
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
            // Machine_cmb
            // 
            this.Machine_cmb.ControlId = null;
            resources.ApplyResources(this.Machine_cmb, "Machine_cmb");
            this.Machine_cmb.FormattingEnabled = true;
            this.Machine_cmb.Name = "Machine_cmb";
            // 
            // Machine_lbl
            // 
            resources.ApplyResources(this.Machine_lbl, "Machine_lbl");
            this.Machine_lbl.ControlId = null;
            this.Machine_lbl.Name = "Machine_lbl";
            // 
            // AddGroupMachineForm
            // 
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.Machine_cmb);
            this.Controls.Add(this.Machine_lbl);
            this.Controls.Add(this.Exit_btn);
            this.Controls.Add(this.Ok_btn);
            this.Controls.Add(this.GroupMachineCode_txt);
            this.Controls.Add(this.GroupMachineName_lbl);
            this.Controls.Add(this.GroupMachineName_txt);
            this.Controls.Add(this.GroupMachineCode_lbl);
            this.Name = "AddGroupMachineForm";
            this.TitleText = "FormCommon";
            this.Load += new System.EventHandler(this.AddGroupMachineForm_Load);
            this.Controls.SetChildIndex(this.GroupMachineCode_lbl, 0);
            this.Controls.SetChildIndex(this.GroupMachineName_txt, 0);
            this.Controls.SetChildIndex(this.GroupMachineName_lbl, 0);
            this.Controls.SetChildIndex(this.GroupMachineCode_txt, 0);
            this.Controls.SetChildIndex(this.Ok_btn, 0);
            this.Controls.SetChildIndex(this.Exit_btn, 0);
            this.Controls.SetChildIndex(this.Machine_lbl, 0);
            this.Controls.SetChildIndex(this.Machine_cmb, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Framework.TextBoxCommon GroupMachineCode_txt;
        private Framework.LabelCommon GroupMachineName_lbl;
        private Framework.TextBoxCommon GroupMachineName_txt;
        private Framework.LabelCommon GroupMachineCode_lbl;
        private Framework.ButtonCommon Exit_btn;
        private Framework.ButtonCommon Ok_btn;
        private Framework.ComboBoxCommon Machine_cmb;
        private Framework.LabelCommon Machine_lbl;
    }
}
