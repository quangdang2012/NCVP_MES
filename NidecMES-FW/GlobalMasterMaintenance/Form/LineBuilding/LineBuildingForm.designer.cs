namespace Com.Nidec.Mes.GlobalMasterMaintenance
{
    partial class LineBuildingForm : FormCommonMaster
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LineBuildingForm));
            this.Exit_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.Update_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.Clear_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.Search_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.Building_cmb = new Com.Nidec.Mes.Framework.ComboBoxCommon();
            this.Building_lbl = new Com.Nidec.Mes.Framework.LabelCommon();
            this.LineBuildingDetails_tv = new System.Windows.Forms.TreeView();
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
            // Building_cmb
            // 
            this.Building_cmb.ControlId = null;
            resources.ApplyResources(this.Building_cmb, "Building_cmb");
            this.Building_cmb.FormattingEnabled = true;
            this.Building_cmb.Name = "Building_cmb";
            // 
            // Building_lbl
            // 
            this.Building_lbl.ControlId = null;
            resources.ApplyResources(this.Building_lbl, "Building_lbl");
            this.Building_lbl.Name = "Building_lbl";
            // 
            // LineBuildingDetails_tv
            // 
            this.LineBuildingDetails_tv.CheckBoxes = true;
            this.LineBuildingDetails_tv.DrawMode = System.Windows.Forms.TreeViewDrawMode.OwnerDrawAll;
            resources.ApplyResources(this.LineBuildingDetails_tv, "LineBuildingDetails_tv");
            this.LineBuildingDetails_tv.Name = "LineBuildingDetails_tv";
            this.LineBuildingDetails_tv.DrawNode += new System.Windows.Forms.DrawTreeNodeEventHandler(this.LineBuildingDetails_tv_DrawNode);
            this.LineBuildingDetails_tv.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.LineBuildingDetails_tv_NodeMouseClick);
            // 
            // LineBuildingForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.LineBuildingDetails_tv);
            this.Controls.Add(this.Exit_btn);
            this.Controls.Add(this.Update_btn);
            this.Controls.Add(this.Building_cmb);
            this.Controls.Add(this.Building_lbl);
            this.Controls.Add(this.Clear_btn);
            this.Controls.Add(this.Search_btn);
            this.Name = "LineBuildingForm";
            this.TitleText = "FormCommon";
            this.Load += new System.EventHandler(this.LineBuildingForm_Load);
            this.Controls.SetChildIndex(this.Search_btn, 0);
            this.Controls.SetChildIndex(this.Clear_btn, 0);
            this.Controls.SetChildIndex(this.Building_lbl, 0);
            this.Controls.SetChildIndex(this.Building_cmb, 0);
            this.Controls.SetChildIndex(this.Update_btn, 0);
            this.Controls.SetChildIndex(this.Exit_btn, 0);
            this.Controls.SetChildIndex(this.LineBuildingDetails_tv, 0);
            this.ResumeLayout(false);

        }

        #endregion
        private Framework.ButtonCommon Exit_btn;
        private Framework.ButtonCommon Update_btn;
        private Framework.ButtonCommon Clear_btn;
        private Framework.ButtonCommon Search_btn;
        private Framework.ComboBoxCommon Building_cmb;
        private Framework.LabelCommon Building_lbl;
        private System.Windows.Forms.TreeView LineBuildingDetails_tv;
    }
}