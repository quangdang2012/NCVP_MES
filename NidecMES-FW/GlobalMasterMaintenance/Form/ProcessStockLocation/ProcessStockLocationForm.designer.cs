namespace Com.Nidec.Mes.GlobalMasterMaintenance
{
    partial class ProcessStockLocationForm : FormCommonMaster
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProcessStockLocationForm));
            this.Exit_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.Update_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.StockLocation_lbl = new Com.Nidec.Mes.Framework.LabelCommon();
            this.Process_lbl = new Com.Nidec.Mes.Framework.LabelCommon();
            this.UpdateText_lbl = new Com.Nidec.Mes.Framework.LabelCommon();
            this.StockLocation_chlst = new System.Windows.Forms.CheckedListBox();
            this.Process_lst = new System.Windows.Forms.ListBox();
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
            // StockLocation_lbl
            // 
            resources.ApplyResources(this.StockLocation_lbl, "StockLocation_lbl");
            this.StockLocation_lbl.ControlId = null;
            this.StockLocation_lbl.Name = "StockLocation_lbl";
            // 
            // Process_lbl
            // 
            resources.ApplyResources(this.Process_lbl, "Process_lbl");
            this.Process_lbl.ControlId = null;
            this.Process_lbl.Name = "Process_lbl";
            // 
            // UpdateText_lbl
            // 
            resources.ApplyResources(this.UpdateText_lbl, "UpdateText_lbl");
            this.UpdateText_lbl.ControlId = null;
            this.UpdateText_lbl.Name = "UpdateText_lbl";
            // 
            // StockLocation_chlst
            // 
            resources.ApplyResources(this.StockLocation_chlst, "StockLocation_chlst");
            this.StockLocation_chlst.CheckOnClick = true;
            this.StockLocation_chlst.FormattingEnabled = true;
            this.StockLocation_chlst.Name = "StockLocation_chlst";
            // 
            // Process_lst
            // 
            resources.ApplyResources(this.Process_lst, "Process_lst");
            this.Process_lst.FormattingEnabled = true;
            this.Process_lst.Name = "Process_lst";
            this.Process_lst.SelectedIndexChanged += new System.EventHandler(this.Process_lst_SelectedIndexChanged);
            // 
            // ProcessStockLocation
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.Process_lst);
            this.Controls.Add(this.StockLocation_chlst);
            this.Controls.Add(this.UpdateText_lbl);
            this.Controls.Add(this.Exit_btn);
            this.Controls.Add(this.Update_btn);
            this.Controls.Add(this.StockLocation_lbl);
            this.Controls.Add(this.Process_lbl);
            this.Name = "ProcessStockLocation";
            this.TitleText = "FormCommon";
            this.Load += new System.EventHandler(this.ProcessWorkLineForm_Load);
            this.Controls.SetChildIndex(this.Process_lbl, 0);
            this.Controls.SetChildIndex(this.StockLocation_lbl, 0);
            this.Controls.SetChildIndex(this.Update_btn, 0);
            this.Controls.SetChildIndex(this.Exit_btn, 0);
            this.Controls.SetChildIndex(this.UpdateText_lbl, 0);
            this.Controls.SetChildIndex(this.StockLocation_chlst, 0);
            this.Controls.SetChildIndex(this.Process_lst, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Com.Nidec.Mes.Framework.ButtonCommon Exit_btn;
        private Com.Nidec.Mes.Framework.ButtonCommon Update_btn;
        private Com.Nidec.Mes.Framework.LabelCommon StockLocation_lbl;
        private Com.Nidec.Mes.Framework.LabelCommon Process_lbl;
        private Framework.LabelCommon UpdateText_lbl;
        private System.Windows.Forms.CheckedListBox StockLocation_chlst;
        private System.Windows.Forms.ListBox Process_lst;
    }
}