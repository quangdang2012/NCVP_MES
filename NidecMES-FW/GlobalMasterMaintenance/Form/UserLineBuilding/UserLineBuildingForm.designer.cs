namespace Com.Nidec.Mes.GlobalMasterMaintenance
{
    partial class UserLineBuildingForm : FormCommonMaster
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserLineBuildingForm));
            this.Exit_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.Update_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.Line_lbl = new Com.Nidec.Mes.Framework.LabelCommon();
            this.Building_lbl = new Com.Nidec.Mes.Framework.LabelCommon();
            this.Line_chlst = new System.Windows.Forms.CheckedListBox();
            this.Building_lst = new System.Windows.Forms.ListBox();
            this.User_lbl = new Com.Nidec.Mes.Framework.LabelCommon();
            this.User_cmb = new Com.Nidec.Mes.Framework.ComboBoxCommon();
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
            this.Update_btn.Click += new System.EventHandler(this.Update_btn_Click);
            // 
            // Line_lbl
            // 
            resources.ApplyResources(this.Line_lbl, "Line_lbl");
            this.Line_lbl.ControlId = null;
            this.Line_lbl.Name = "Line_lbl";
            // 
            // Building_lbl
            // 
            resources.ApplyResources(this.Building_lbl, "Building_lbl");
            this.Building_lbl.ControlId = null;
            this.Building_lbl.Name = "Building_lbl";
            // 
            // Line_chlst
            // 
            resources.ApplyResources(this.Line_chlst, "Line_chlst");
            this.Line_chlst.CheckOnClick = true;
            this.Line_chlst.FormattingEnabled = true;
            this.Line_chlst.Name = "Line_chlst";
            // 
            // Building_lst
            // 
            resources.ApplyResources(this.Building_lst, "Building_lst");
            this.Building_lst.FormattingEnabled = true;
            this.Building_lst.Name = "Building_lst";
            this.Building_lst.SelectedIndexChanged += new System.EventHandler(this.Building_lst_SelectedIndexChanged);
            // 
            // User_lbl
            // 
            resources.ApplyResources(this.User_lbl, "User_lbl");
            this.User_lbl.ControlId = null;
            this.User_lbl.Name = "User_lbl";
            // 
            // User_cmb
            // 
            resources.ApplyResources(this.User_cmb, "User_cmb");
            this.User_cmb.ControlId = null;
            this.User_cmb.FormattingEnabled = true;
            this.User_cmb.Name = "User_cmb";
            this.User_cmb.SelectedIndexChanged += new System.EventHandler(this.User_cmb_SelectedIndexChanged);
            // 
            // UserLineBuildingForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.User_cmb);
            this.Controls.Add(this.User_lbl);
            this.Controls.Add(this.Building_lst);
            this.Controls.Add(this.Line_chlst);
            this.Controls.Add(this.Exit_btn);
            this.Controls.Add(this.Update_btn);
            this.Controls.Add(this.Line_lbl);
            this.Controls.Add(this.Building_lbl);
            this.Name = "UserLineBuildingForm";
            this.TitleText = "FormCommon";
            this.Load += new System.EventHandler(this.UserLineBuildingForm_Load);
            this.Controls.SetChildIndex(this.Building_lbl, 0);
            this.Controls.SetChildIndex(this.Line_lbl, 0);
            this.Controls.SetChildIndex(this.Update_btn, 0);
            this.Controls.SetChildIndex(this.Exit_btn, 0);
            this.Controls.SetChildIndex(this.Line_chlst, 0);
            this.Controls.SetChildIndex(this.Building_lst, 0);
            this.Controls.SetChildIndex(this.User_lbl, 0);
            this.Controls.SetChildIndex(this.User_cmb, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Com.Nidec.Mes.Framework.ButtonCommon Exit_btn;
        private Com.Nidec.Mes.Framework.ButtonCommon Update_btn;
        private Com.Nidec.Mes.Framework.LabelCommon Line_lbl;
        private Com.Nidec.Mes.Framework.LabelCommon Building_lbl;
        private System.Windows.Forms.CheckedListBox Line_chlst;
        private System.Windows.Forms.ListBox Building_lst;
        private Framework.LabelCommon User_lbl;
        private Framework.ComboBoxCommon User_cmb;
    }
}