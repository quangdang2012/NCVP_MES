namespace Com.Nidec.Mes.GlobalMasterMaintenance
{
    partial class RoleAuthorityControlForm  :FormCommonMaster
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RoleAuthorityControlForm));
            this.Exit_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.Clear_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.Search_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.RoleName_lbl = new Com.Nidec.Mes.Framework.LabelCommon();
            this.RoleName_txt = new Com.Nidec.Mes.Framework.TextBoxCommon();
            this.Update_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.RoleAuthorityDetails_tv = new System.Windows.Forms.TreeView();
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
            // Clear_btn
            // 
            this.Clear_btn.BackColor = System.Drawing.SystemColors.Control;
            this.Clear_btn.ControlId = null;
            resources.ApplyResources(this.Clear_btn, "Clear_btn");
            this.Clear_btn.Name = "Clear_btn";
            this.Clear_btn.UseVisualStyleBackColor = true;
            this.Clear_btn.Click += new System.EventHandler(this.Clear_btn_Click);
            // 
            // Search_btn
            // 
            this.Search_btn.BackColor = System.Drawing.SystemColors.Control;
            this.Search_btn.ControlId = null;
            resources.ApplyResources(this.Search_btn, "Search_btn");
            this.Search_btn.Name = "Search_btn";
            this.Search_btn.UseVisualStyleBackColor = true;
            this.Search_btn.Click += new System.EventHandler(this.Search_btn_Click);
            // 
            // RoleName_lbl
            // 
            resources.ApplyResources(this.RoleName_lbl, "RoleName_lbl");
            this.RoleName_lbl.ControlId = null;
            this.RoleName_lbl.Name = "RoleName_lbl";
            // 
            // RoleName_txt
            // 
            this.RoleName_txt.ControlId = null;
            resources.ApplyResources(this.RoleName_txt, "RoleName_txt");
            this.RoleName_txt.InputType = Com.Nidec.Mes.Framework.TextBoxCommon.InputTypeList.All;
            this.RoleName_txt.Name = "RoleName_txt";
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
            // RoleAuthorityDetails_tv
            // 
            resources.ApplyResources(this.RoleAuthorityDetails_tv, "RoleAuthorityDetails_tv");
            this.RoleAuthorityDetails_tv.CheckBoxes = true;
            this.RoleAuthorityDetails_tv.DrawMode = System.Windows.Forms.TreeViewDrawMode.OwnerDrawAll;
            this.RoleAuthorityDetails_tv.Name = "RoleAuthorityDetails_tv";
            this.RoleAuthorityDetails_tv.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.RoleAuthorityDetails_tv_AfterCheck);
            this.RoleAuthorityDetails_tv.DrawNode += new System.Windows.Forms.DrawTreeNodeEventHandler(this.RoleAuthorityDetails_tv_DrawNode);
            this.RoleAuthorityDetails_tv.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.RoleAuthorityDetails_tv_NodeMouseClick);
            // 
            // RoleAuthorityControlForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ControlId = "bpmf018";
            this.Controls.Add(this.Exit_btn);
            this.Controls.Add(this.Clear_btn);
            this.Controls.Add(this.Search_btn);
            this.Controls.Add(this.RoleName_lbl);
            this.Controls.Add(this.RoleName_txt);
            this.Controls.Add(this.Update_btn);
            this.Controls.Add(this.RoleAuthorityDetails_tv);
            this.Name = "RoleAuthorityControlForm";
            this.TitleText = "FormCommon";
            this.Load += new System.EventHandler(this.RoleAuthorityControlForm_Load);
            this.Controls.SetChildIndex(this.RoleAuthorityDetails_tv, 0);
            this.Controls.SetChildIndex(this.Update_btn, 0);
            this.Controls.SetChildIndex(this.RoleName_txt, 0);
            this.Controls.SetChildIndex(this.RoleName_lbl, 0);
            this.Controls.SetChildIndex(this.Search_btn, 0);
            this.Controls.SetChildIndex(this.Clear_btn, 0);
            this.Controls.SetChildIndex(this.Exit_btn, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Com.Nidec.Mes.Framework.ButtonCommon Exit_btn;
        private Com.Nidec.Mes.Framework.ButtonCommon Clear_btn;
        private Com.Nidec.Mes.Framework.ButtonCommon Search_btn;
        private Com.Nidec.Mes.Framework.LabelCommon RoleName_lbl;
        private Com.Nidec.Mes.Framework.TextBoxCommon RoleName_txt;
        private Com.Nidec.Mes.Framework.ButtonCommon Update_btn;
        private System.Windows.Forms.TreeView RoleAuthorityDetails_tv;
    }
}