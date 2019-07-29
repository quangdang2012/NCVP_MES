namespace Com.Nidec.Mes.GlobalMasterMaintenance
{
    partial class CustomerLineForm : FormCommonMaster
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CustomerLineForm));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.Clear_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.Exit_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.Search_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.Customer_dgv = new Com.Nidec.Mes.Framework.DataGridViewCommon();
            this.CustomerLine_cmb = new Com.Nidec.Mes.Framework.ComboBoxCommon();
            this.CustomerLine_lbl = new Com.Nidec.Mes.Framework.LabelCommon();
            this.Line = new Com.Nidec.Mes.Framework.LabelCommon();
            this.Line_cmb = new Com.Nidec.Mes.Framework.ComboBoxCommon();
            this.colCustomerLineId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCustomerCd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCustomerName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLineCd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLineName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.Customer_dgv)).BeginInit();
            this.SuspendLayout();
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
            // Exit_btn
            // 
            resources.ApplyResources(this.Exit_btn, "Exit_btn");
            this.Exit_btn.BackColor = System.Drawing.SystemColors.Control;
            this.Exit_btn.ControlId = null;
            this.Exit_btn.Name = "Exit_btn";
            this.Exit_btn.UseVisualStyleBackColor = true;
            this.Exit_btn.Click += new System.EventHandler(this.Exit_btn_Click);
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
            // Customer_dgv
            // 
            this.Customer_dgv.AllowUserToAddRows = false;
            this.Customer_dgv.AllowUserToDeleteRows = false;
            this.Customer_dgv.AllowUserToOrderColumns = true;
            this.Customer_dgv.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(232)))), ((int)(((byte)(180)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.Customer_dgv.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.Customer_dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Customer_dgv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colCustomerLineId,
            this.colCustomerCd,
            this.colCustomerName,
            this.colLineCd,
            this.colLineName});
            this.Customer_dgv.ControlId = null;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.Customer_dgv.DefaultCellStyle = dataGridViewCellStyle2;
            this.Customer_dgv.EnableHeadersVisualStyles = false;
            resources.ApplyResources(this.Customer_dgv, "Customer_dgv");
            this.Customer_dgv.MultiSelect = false;
            this.Customer_dgv.Name = "Customer_dgv";
            this.Customer_dgv.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(232)))), ((int)(((byte)(180)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.Customer_dgv.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.Customer_dgv.RowHeadersVisible = false;
            this.Customer_dgv.RowTemplate.Height = 21;
            this.Customer_dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            // 
            // CustomerLine_cmb
            // 
            this.CustomerLine_cmb.ControlId = null;
            resources.ApplyResources(this.CustomerLine_cmb, "CustomerLine_cmb");
            this.CustomerLine_cmb.FormattingEnabled = true;
            this.CustomerLine_cmb.Name = "CustomerLine_cmb";
            this.CustomerLine_cmb.SelectedIndexChanged += new System.EventHandler(this.CustomerLine_cmb_SelectedIndexChanged);
            // 
            // CustomerLine_lbl
            // 
            resources.ApplyResources(this.CustomerLine_lbl, "CustomerLine_lbl");
            this.CustomerLine_lbl.ControlId = null;
            this.CustomerLine_lbl.Name = "CustomerLine_lbl";
            // 
            // Line
            // 
            resources.ApplyResources(this.Line, "Line");
            this.Line.ControlId = null;
            this.Line.Name = "Line";
            // 
            // Line_cmb
            // 
            this.Line_cmb.ControlId = null;
            resources.ApplyResources(this.Line_cmb, "Line_cmb");
            this.Line_cmb.FormattingEnabled = true;
            this.Line_cmb.Name = "Line_cmb";
            // 
            // colCustomerLineId
            // 
            this.colCustomerLineId.DataPropertyName = "CustomerLineId";
            resources.ApplyResources(this.colCustomerLineId, "colCustomerLineId");
            this.colCustomerLineId.Name = "colCustomerLineId";
            this.colCustomerLineId.ReadOnly = true;
            // 
            // colCustomerCd
            // 
            this.colCustomerCd.DataPropertyName = "CustomerCd";
            this.colCustomerCd.FillWeight = 200F;
            resources.ApplyResources(this.colCustomerCd, "colCustomerCd");
            this.colCustomerCd.Name = "colCustomerCd";
            this.colCustomerCd.ReadOnly = true;
            // 
            // colCustomerName
            // 
            this.colCustomerName.DataPropertyName = "CustomerName";
            resources.ApplyResources(this.colCustomerName, "colCustomerName");
            this.colCustomerName.Name = "colCustomerName";
            this.colCustomerName.ReadOnly = true;
            // 
            // colLineCd
            // 
            this.colLineCd.DataPropertyName = "LineCd";
            resources.ApplyResources(this.colLineCd, "colLineCd");
            this.colLineCd.Name = "colLineCd";
            this.colLineCd.ReadOnly = true;
            // 
            // colLineName
            // 
            this.colLineName.DataPropertyName = "LineName";
            resources.ApplyResources(this.colLineName, "colLineName");
            this.colLineName.Name = "colLineName";
            this.colLineName.ReadOnly = true;
            // 
            // CustomerLineForm
            // 
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.Line_cmb);
            this.Controls.Add(this.Line);
            this.Controls.Add(this.CustomerLine_cmb);
            this.Controls.Add(this.CustomerLine_lbl);
            this.Controls.Add(this.Clear_btn);
            this.Controls.Add(this.Exit_btn);
            this.Controls.Add(this.Search_btn);
            this.Controls.Add(this.Customer_dgv);
            this.Name = "CustomerLineForm";
            this.TitleText = "FormCommon";
            this.Load += new System.EventHandler(this.CustomerLineForm_Load);
            this.Controls.SetChildIndex(this.Customer_dgv, 0);
            this.Controls.SetChildIndex(this.Search_btn, 0);
            this.Controls.SetChildIndex(this.Exit_btn, 0);
            this.Controls.SetChildIndex(this.Clear_btn, 0);
            this.Controls.SetChildIndex(this.CustomerLine_lbl, 0);
            this.Controls.SetChildIndex(this.CustomerLine_cmb, 0);
            this.Controls.SetChildIndex(this.Line, 0);
            this.Controls.SetChildIndex(this.Line_cmb, 0);
            ((System.ComponentModel.ISupportInitialize)(this.Customer_dgv)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Com.Nidec.Mes.Framework.ButtonCommon Clear_btn;
        private Com.Nidec.Mes.Framework.ButtonCommon Exit_btn;
        private Com.Nidec.Mes.Framework.ButtonCommon Search_btn;
        internal Com.Nidec.Mes.Framework.DataGridViewCommon Customer_dgv;
        private Framework.ComboBoxCommon CustomerLine_cmb;
        private Framework.LabelCommon CustomerLine_lbl;
        private Framework.LabelCommon Line;
        private Framework.ComboBoxCommon Line_cmb;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCustomerLineId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCustomerCd;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCustomerName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLineCd;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLineName;
    }
}
