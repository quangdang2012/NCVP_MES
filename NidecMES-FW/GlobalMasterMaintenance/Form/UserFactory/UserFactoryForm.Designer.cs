namespace Com.Nidec.Mes.GlobalMasterMaintenance
{
    partial class UserFactoryForm :FormCommonMaster
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserFactoryForm));
            this.Exit_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.Clear_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.Search_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.Update_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.UserFactoryDetails_tv = new System.Windows.Forms.TreeView();
            this.UserCode_lbl = new Com.Nidec.Mes.Framework.LabelCommon();
            this.User_cmb = new System.Windows.Forms.ComboBox();
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
            // Update_btn
            // 
            resources.ApplyResources(this.Update_btn, "Update_btn");
            this.Update_btn.BackColor = System.Drawing.SystemColors.Control;
            this.Update_btn.ControlId = null;
            this.Update_btn.Name = "Update_btn";
            this.Update_btn.UseVisualStyleBackColor = true;
            this.Update_btn.Click += new System.EventHandler(this.Update_btn_Click);
            // 
            // UserFactoryDetails_tv
            // 
            this.UserFactoryDetails_tv.AllowDrop = true;
            resources.ApplyResources(this.UserFactoryDetails_tv, "UserFactoryDetails_tv");
            this.UserFactoryDetails_tv.CheckBoxes = true;
            this.UserFactoryDetails_tv.DrawMode = System.Windows.Forms.TreeViewDrawMode.OwnerDrawAll;
            this.UserFactoryDetails_tv.Name = "UserFactoryDetails_tv";
            this.UserFactoryDetails_tv.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.UserFactoryDetails_tv_AfterCheck);
            this.UserFactoryDetails_tv.DrawNode += new System.Windows.Forms.DrawTreeNodeEventHandler(this.UserFactoryDetails_tv_DrawNode);
            this.UserFactoryDetails_tv.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.UserFactoryDetails_tv_ItemDrag);
            this.UserFactoryDetails_tv.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.UserFactoryDetails_tv_NodeMouseClick);
            this.UserFactoryDetails_tv.DragDrop += new System.Windows.Forms.DragEventHandler(this.UserFactoryDetails_tv_DragDrop);
            this.UserFactoryDetails_tv.DragEnter += new System.Windows.Forms.DragEventHandler(this.UserFactoryDetails_tv_DragEnter);
            this.UserFactoryDetails_tv.DragOver += new System.Windows.Forms.DragEventHandler(this.UserFactoryDetails_tv_DragOver);
            // 
            // UserCode_lbl
            // 
            resources.ApplyResources(this.UserCode_lbl, "UserCode_lbl");
            this.UserCode_lbl.ControlId = null;
            this.UserCode_lbl.Name = "UserCode_lbl";
            // 
            // User_cmb
            // 
            this.User_cmb.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.User_cmb.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.User_cmb.FormattingEnabled = true;
            resources.ApplyResources(this.User_cmb, "User_cmb");
            this.User_cmb.Name = "User_cmb";
            // 
            // UserFactoryForm
            // 
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.User_cmb);
            this.Controls.Add(this.UserFactoryDetails_tv);
            this.Controls.Add(this.UserCode_lbl);
            this.Controls.Add(this.Exit_btn);
            this.Controls.Add(this.Clear_btn);
            this.Controls.Add(this.Search_btn);
            this.Controls.Add(this.Update_btn);
            this.Name = "UserFactoryForm";
            this.TitleText = "FormCommon";
            this.Load += new System.EventHandler(this.UserFactoryForm_Load);
            this.Controls.SetChildIndex(this.Update_btn, 0);
            this.Controls.SetChildIndex(this.Search_btn, 0);
            this.Controls.SetChildIndex(this.Clear_btn, 0);
            this.Controls.SetChildIndex(this.Exit_btn, 0);
            this.Controls.SetChildIndex(this.UserCode_lbl, 0);
            this.Controls.SetChildIndex(this.UserFactoryDetails_tv, 0);
            this.Controls.SetChildIndex(this.User_cmb, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Framework.ButtonCommon Exit_btn;
        private Framework.ButtonCommon Clear_btn;
        private Framework.ButtonCommon Search_btn;
        private Framework.ButtonCommon Update_btn;
        private System.Windows.Forms.TreeView UserFactoryDetails_tv;
        private Framework.LabelCommon UserCode_lbl;
        private System.Windows.Forms.ComboBox User_cmb;
    }
}