namespace Com.Nidec.Mes.GlobalMasterMaintenance
{
    partial class LineDefectiveReasonForm : FormCommonMaster
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LineDefectiveReasonForm));
            this.Exit_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.Update_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.Clear_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.Search_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.Line_cmb = new Com.Nidec.Mes.Framework.ComboBoxCommon();
            this.Line_lbl = new Com.Nidec.Mes.Framework.LabelCommon();
            this.LineDefectiveReasonDetails_tv = new System.Windows.Forms.TreeView();
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
            // Line_cmb
            // 
            this.Line_cmb.ControlId = null;
            resources.ApplyResources(this.Line_cmb, "Line_cmb");
            this.Line_cmb.FormattingEnabled = true;
            this.Line_cmb.Name = "Line_cmb";
            // 
            // Line_lbl
            // 
            this.Line_lbl.ControlId = null;
            resources.ApplyResources(this.Line_lbl, "Line_lbl");
            this.Line_lbl.Name = "Line_lbl";
            // 
            // LineDefectiveReasonDetails_tv
            // 
            this.LineDefectiveReasonDetails_tv.CheckBoxes = true;
            this.LineDefectiveReasonDetails_tv.DrawMode = System.Windows.Forms.TreeViewDrawMode.OwnerDrawAll;
            resources.ApplyResources(this.LineDefectiveReasonDetails_tv, "LineDefectiveReasonDetails_tv");
            this.LineDefectiveReasonDetails_tv.Name = "LineDefectiveReasonDetails_tv";
            this.LineDefectiveReasonDetails_tv.DrawNode += new System.Windows.Forms.DrawTreeNodeEventHandler(this.LineDefectiveReasonDetails_tv_DrawNode);
            this.LineDefectiveReasonDetails_tv.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.LineDefectiveReasonDetails_tv_NodeMouseClick);
            // 
            // LineDefectiveReasonForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.LineDefectiveReasonDetails_tv);
            this.Controls.Add(this.Exit_btn);
            this.Controls.Add(this.Update_btn);
            this.Controls.Add(this.Line_cmb);
            this.Controls.Add(this.Line_lbl);
            this.Controls.Add(this.Clear_btn);
            this.Controls.Add(this.Search_btn);
            this.Name = "LineDefectiveReasonForm";
            this.TitleText = "FormCommon";
            this.Load += new System.EventHandler(this.LineDefectiveReasonForm_Load);
            this.Controls.SetChildIndex(this.Search_btn, 0);
            this.Controls.SetChildIndex(this.Clear_btn, 0);
            this.Controls.SetChildIndex(this.Line_lbl, 0);
            this.Controls.SetChildIndex(this.Line_cmb, 0);
            this.Controls.SetChildIndex(this.Update_btn, 0);
            this.Controls.SetChildIndex(this.Exit_btn, 0);
            this.Controls.SetChildIndex(this.LineDefectiveReasonDetails_tv, 0);
            this.ResumeLayout(false);

        }

        #endregion
        private Framework.ButtonCommon Exit_btn;
        private Framework.ButtonCommon Update_btn;
        private Framework.ButtonCommon Clear_btn;
        private Framework.ButtonCommon Search_btn;
        private Framework.ComboBoxCommon Line_cmb;
        private Framework.LabelCommon Line_lbl;
        private System.Windows.Forms.TreeView LineDefectiveReasonDetails_tv;
    }
}