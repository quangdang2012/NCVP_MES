namespace Com.Nidec.Mes.GlobalMasterMaintenance
{
    partial class LineItemCycleTimeForm : FormCommonMaster
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LineItemCycleTimeForm));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.Clear_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.Search_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.Exit_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.Update_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.LineItem_dgv = new Com.Nidec.Mes.Framework.DataGridViewCommon();
            this.colSapItemCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmstdcycletime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SapItem_lbl = new Com.Nidec.Mes.Framework.LabelCommon();
            this.LineId_lbl = new Com.Nidec.Mes.Framework.LabelCommon();
            this.SapItem_cmb = new Com.Nidec.Mes.Framework.ComboBoxCommon();
            this.Line_cmb = new Com.Nidec.Mes.Framework.ComboBoxCommon();
            this.ItemSearch_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            ((System.ComponentModel.ISupportInitialize)(this.LineItem_dgv)).BeginInit();
            this.SuspendLayout();
            // 
            // Clear_btn
            // 
            resources.ApplyResources(this.Clear_btn, "Clear_btn");
            this.Clear_btn.BackColor = System.Drawing.SystemColors.Control;
            this.Clear_btn.ControlId = null;
            this.Clear_btn.Name = "Clear_btn";
            this.Clear_btn.UseVisualStyleBackColor = true;
            this.Clear_btn.Click += new System.EventHandler(this.Clear_btn_Click);
            // 
            // Search_btn
            // 
            resources.ApplyResources(this.Search_btn, "Search_btn");
            this.Search_btn.BackColor = System.Drawing.SystemColors.Control;
            this.Search_btn.ControlId = null;
            this.Search_btn.Name = "Search_btn";
            this.Search_btn.UseVisualStyleBackColor = true;
            this.Search_btn.Click += new System.EventHandler(this.Search_btn_Click);
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
            // LineItem_dgv
            // 
            resources.ApplyResources(this.LineItem_dgv, "LineItem_dgv");
            this.LineItem_dgv.AllowUserToAddRows = false;
            this.LineItem_dgv.AllowUserToDeleteRows = false;
            this.LineItem_dgv.AllowUserToOrderColumns = true;
            this.LineItem_dgv.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(232)))), ((int)(((byte)(180)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.LineItem_dgv.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.LineItem_dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.LineItem_dgv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colSapItemCode,
            this.clmstdcycletime});
            this.LineItem_dgv.ControlId = null;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.LineItem_dgv.DefaultCellStyle = dataGridViewCellStyle4;
            this.LineItem_dgv.EnableHeadersVisualStyles = false;
            this.LineItem_dgv.MultiSelect = false;
            this.LineItem_dgv.Name = "LineItem_dgv";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(232)))), ((int)(((byte)(180)))));
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.LineItem_dgv.RowHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.LineItem_dgv.RowHeadersVisible = false;
            this.LineItem_dgv.RowTemplate.Height = 21;
            this.LineItem_dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.LineItem_dgv.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.LineItem_dgv_CellClick);
            this.LineItem_dgv.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.LineItem_dgv_CellContentClick);
            this.LineItem_dgv.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.LineItem_dgv_CellValidating);
            this.LineItem_dgv.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.LineItem_dgv_ColumnHeaderMouseClick);
            this.LineItem_dgv.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.LineItem_dgv_EditingControlShowing);
            // 
            // colSapItemCode
            // 
            this.colSapItemCode.DataPropertyName = "SapItemCode";
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.colSapItemCode.DefaultCellStyle = dataGridViewCellStyle2;
            resources.ApplyResources(this.colSapItemCode, "colSapItemCode");
            this.colSapItemCode.Name = "colSapItemCode";
            this.colSapItemCode.ReadOnly = true;
            // 
            // clmstdcycletime
            // 
            this.clmstdcycletime.DataPropertyName = "StdCycleTimeNull";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.clmstdcycletime.DefaultCellStyle = dataGridViewCellStyle3;
            resources.ApplyResources(this.clmstdcycletime, "clmstdcycletime");
            this.clmstdcycletime.MaxInputLength = 10;
            this.clmstdcycletime.Name = "clmstdcycletime";
            // 
            // SapItem_lbl
            // 
            resources.ApplyResources(this.SapItem_lbl, "SapItem_lbl");
            this.SapItem_lbl.ControlId = null;
            this.SapItem_lbl.Name = "SapItem_lbl";
            // 
            // LineId_lbl
            // 
            resources.ApplyResources(this.LineId_lbl, "LineId_lbl");
            this.LineId_lbl.ControlId = null;
            this.LineId_lbl.Name = "LineId_lbl";
            // 
            // SapItem_cmb
            // 
            resources.ApplyResources(this.SapItem_cmb, "SapItem_cmb");
            this.SapItem_cmb.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.SapItem_cmb.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.SapItem_cmb.ControlId = null;
            this.SapItem_cmb.FormattingEnabled = true;
            this.SapItem_cmb.Name = "SapItem_cmb";
            // 
            // Line_cmb
            // 
            resources.ApplyResources(this.Line_cmb, "Line_cmb");
            this.Line_cmb.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.Line_cmb.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.Line_cmb.ControlId = null;
            this.Line_cmb.FormattingEnabled = true;
            this.Line_cmb.Name = "Line_cmb";
            this.Line_cmb.SelectionChangeCommitted += new System.EventHandler(this.Line_cmb_SelectionChangeCommitted);
            // 
            // ItemSearch_btn
            // 
            resources.ApplyResources(this.ItemSearch_btn, "ItemSearch_btn");
            this.ItemSearch_btn.BackColor = System.Drawing.SystemColors.Control;
            this.ItemSearch_btn.ControlId = "BTN_01_02";
            this.ItemSearch_btn.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ItemSearch_btn.Name = "ItemSearch_btn";
            this.ItemSearch_btn.UseVisualStyleBackColor = true;
            this.ItemSearch_btn.Click += new System.EventHandler(this.ItemSearch_btn_Click);
            // 
            // LineItemCycleTimeForm
            // 
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.ItemSearch_btn);
            this.Controls.Add(this.Line_cmb);
            this.Controls.Add(this.LineId_lbl);
            this.Controls.Add(this.SapItem_cmb);
            this.Controls.Add(this.SapItem_lbl);
            this.Controls.Add(this.LineItem_dgv);
            this.Controls.Add(this.Exit_btn);
            this.Controls.Add(this.Update_btn);
            this.Controls.Add(this.Clear_btn);
            this.Controls.Add(this.Search_btn);
            this.Name = "LineItemCycleTimeForm";
            this.TitleText = "Line Item Cycle Time";
            this.Load += new System.EventHandler(this.LineItemCycleTimeForm_Load);
            this.Controls.SetChildIndex(this.Search_btn, 0);
            this.Controls.SetChildIndex(this.Clear_btn, 0);
            this.Controls.SetChildIndex(this.Update_btn, 0);
            this.Controls.SetChildIndex(this.Exit_btn, 0);
            this.Controls.SetChildIndex(this.LineItem_dgv, 0);
            this.Controls.SetChildIndex(this.SapItem_lbl, 0);
            this.Controls.SetChildIndex(this.SapItem_cmb, 0);
            this.Controls.SetChildIndex(this.LineId_lbl, 0);
            this.Controls.SetChildIndex(this.Line_cmb, 0);
            this.Controls.SetChildIndex(this.ItemSearch_btn, 0);
            ((System.ComponentModel.ISupportInitialize)(this.LineItem_dgv)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Framework.ButtonCommon Clear_btn;
        private Framework.ButtonCommon Search_btn;
        private Framework.ButtonCommon Exit_btn;
        private Framework.ButtonCommon Update_btn;
        internal Framework.DataGridViewCommon LineItem_dgv;
        private Framework.LabelCommon SapItem_lbl;
        private Framework.LabelCommon LineId_lbl;
        private Framework.ComboBoxCommon SapItem_cmb;
        private Framework.ComboBoxCommon Line_cmb;
        private Framework.ButtonCommon ItemSearch_btn;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSapItemCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmstdcycletime;
    }
}
