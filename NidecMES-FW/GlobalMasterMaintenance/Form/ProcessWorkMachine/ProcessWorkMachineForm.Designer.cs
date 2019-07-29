namespace Com.Nidec.Mes.GlobalMasterMaintenance
{
    partial class ProcessWorkMachineForm : FormCommonMaster
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProcessWorkMachineForm));
            this.Exit_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.Update_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.Machine_lbl = new Com.Nidec.Mes.Framework.LabelCommon();
            this.ProcessWork_lbl = new Com.Nidec.Mes.Framework.LabelCommon();
            this.UpdateText_lbl = new Com.Nidec.Mes.Framework.LabelCommon();
            this.Machine_chlst = new System.Windows.Forms.CheckedListBox();
            this.ProcessWork_lst = new System.Windows.Forms.ListBox();
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
            // Update_btn
            // 
            resources.ApplyResources(this.Update_btn, "Update_btn");
            this.Update_btn.BackColor = System.Drawing.SystemColors.Control;
            this.Update_btn.ControlId = null;
            this.Update_btn.Name = "Update_btn";
            this.Update_btn.UseVisualStyleBackColor = true;
            this.Update_btn.Click += new System.EventHandler(this.Ok_btn_Click);
            // 
            // Machine_lbl
            // 
            resources.ApplyResources(this.Machine_lbl, "Machine_lbl");
            this.Machine_lbl.ControlId = null;
            this.Machine_lbl.Name = "Machine_lbl";
            // 
            // ProcessWork_lbl
            // 
            resources.ApplyResources(this.ProcessWork_lbl, "ProcessWork_lbl");
            this.ProcessWork_lbl.ControlId = null;
            this.ProcessWork_lbl.Name = "ProcessWork_lbl";
            // 
            // UpdateText_lbl
            // 
            resources.ApplyResources(this.UpdateText_lbl, "UpdateText_lbl");
            this.UpdateText_lbl.ControlId = null;
            this.UpdateText_lbl.Name = "UpdateText_lbl";
            // 
            // Machine_chlst
            // 
            resources.ApplyResources(this.Machine_chlst, "Machine_chlst");
            this.Machine_chlst.CheckOnClick = true;
            this.Machine_chlst.FormattingEnabled = true;
            this.Machine_chlst.Name = "Machine_chlst";
            // 
            // ProcessWork_lst
            // 
            resources.ApplyResources(this.ProcessWork_lst, "ProcessWork_lst");
            this.ProcessWork_lst.FormattingEnabled = true;
            this.ProcessWork_lst.Name = "ProcessWork_lst";
            this.ProcessWork_lst.SelectedIndexChanged += new System.EventHandler(this.ProcessWork_lst_SelectedIndexChanged);
            // 
            // ProcessWorkMachineForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ProcessWork_lst);
            this.Controls.Add(this.Machine_chlst);
            this.Controls.Add(this.UpdateText_lbl);
            this.Controls.Add(this.Exit_btn);
            this.Controls.Add(this.Update_btn);
            this.Controls.Add(this.Machine_lbl);
            this.Controls.Add(this.ProcessWork_lbl);
            this.Name = "ProcessWorkMachineForm";
            this.TitleText = "FormCommon";
            this.Load += new System.EventHandler(this.ProcessWorkMachineForm_Load);
            this.Controls.SetChildIndex(this.ProcessWork_lbl, 0);
            this.Controls.SetChildIndex(this.Machine_lbl, 0);
            this.Controls.SetChildIndex(this.Update_btn, 0);
            this.Controls.SetChildIndex(this.Exit_btn, 0);
            this.Controls.SetChildIndex(this.UpdateText_lbl, 0);
            this.Controls.SetChildIndex(this.Machine_chlst, 0);
            this.Controls.SetChildIndex(this.ProcessWork_lst, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Com.Nidec.Mes.Framework.ButtonCommon Exit_btn;
        private Com.Nidec.Mes.Framework.ButtonCommon Update_btn;
        private Com.Nidec.Mes.Framework.LabelCommon Machine_lbl;
        private Com.Nidec.Mes.Framework.LabelCommon ProcessWork_lbl;
        private Framework.LabelCommon UpdateText_lbl;
        private System.Windows.Forms.CheckedListBox Machine_chlst;
        private System.Windows.Forms.ListBox ProcessWork_lst;
    }
}