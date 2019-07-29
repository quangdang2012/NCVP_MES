namespace Com.Nidec.Mes.GlobalMasterMaintenance
{
    partial class StockLocationForm : FormCommonMaster
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StockLocationForm));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.Clear_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.Exit_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.Delete_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.Update_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.Add_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.Search_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.StockLocationData_dgv = new Com.Nidec.Mes.Framework.DataGridViewCommon();
            this.ItemName_lbl = new Com.Nidec.Mes.Framework.LabelCommon();
            this.StockLocationName_txt = new Com.Nidec.Mes.Framework.TextBoxCommon();
            this.ItemCode_lbl = new Com.Nidec.Mes.Framework.LabelCommon();
            this.StockLocationCode_txt = new Com.Nidec.Mes.Framework.TextBoxCommon();
            this.colStockLocationId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStockLocationCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStockLocationName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDisplayOrder = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLocationType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.StockLocationData_dgv)).BeginInit();
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
            // Delete_btn
            // 
            resources.ApplyResources(this.Delete_btn, "Delete_btn");
            this.Delete_btn.BackColor = System.Drawing.SystemColors.Control;
            this.Delete_btn.ControlId = null;
            this.Delete_btn.Name = "Delete_btn";
            this.Delete_btn.UseVisualStyleBackColor = true;
            this.Delete_btn.Click += new System.EventHandler(this.Delete_btn_Click);
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
            // Add_btn
            // 
            this.Add_btn.BackColor = System.Drawing.SystemColors.Control;
            this.Add_btn.ControlId = null;
            resources.ApplyResources(this.Add_btn, "Add_btn");
            this.Add_btn.Name = "Add_btn";
            this.Add_btn.UseVisualStyleBackColor = true;
            this.Add_btn.Click += new System.EventHandler(this.Add_btn_Click);
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
            // StockLocationData_dgv
            // 
            this.StockLocationData_dgv.AllowUserToAddRows = false;
            this.StockLocationData_dgv.AllowUserToDeleteRows = false;
            this.StockLocationData_dgv.AllowUserToOrderColumns = true;
            this.StockLocationData_dgv.AllowUserToResizeRows = false;
            resources.ApplyResources(this.StockLocationData_dgv, "StockLocationData_dgv");
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(232)))), ((int)(((byte)(180)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.StockLocationData_dgv.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.StockLocationData_dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.StockLocationData_dgv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colStockLocationId,
            this.colStockLocationCode,
            this.colStockLocationName,
            this.colDisplayOrder,
            this.colLocationType});
            this.StockLocationData_dgv.ControlId = null;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.StockLocationData_dgv.DefaultCellStyle = dataGridViewCellStyle2;
            this.StockLocationData_dgv.EnableHeadersVisualStyles = false;
            this.StockLocationData_dgv.MultiSelect = false;
            this.StockLocationData_dgv.Name = "StockLocationData_dgv";
            this.StockLocationData_dgv.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(232)))), ((int)(((byte)(180)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.StockLocationData_dgv.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.StockLocationData_dgv.RowHeadersVisible = false;
            this.StockLocationData_dgv.RowTemplate.Height = 21;
            this.StockLocationData_dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.StockLocationData_dgv.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.ItemData_dgv_CellClick);
            this.StockLocationData_dgv.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.ItemData_dgv_CellDoubleClick);
            // 
            // ItemName_lbl
            // 
            resources.ApplyResources(this.ItemName_lbl, "ItemName_lbl");
            this.ItemName_lbl.ControlId = null;
            this.ItemName_lbl.Name = "ItemName_lbl";
            // 
            // StockLocationName_txt
            // 
            this.StockLocationName_txt.ControlId = null;
            resources.ApplyResources(this.StockLocationName_txt, "StockLocationName_txt");
            this.StockLocationName_txt.InputType = Com.Nidec.Mes.Framework.TextBoxCommon.InputTypeList.All;
            this.StockLocationName_txt.Name = "StockLocationName_txt";
            // 
            // ItemCode_lbl
            // 
            resources.ApplyResources(this.ItemCode_lbl, "ItemCode_lbl");
            this.ItemCode_lbl.ControlId = null;
            this.ItemCode_lbl.Name = "ItemCode_lbl";
            // 
            // StockLocationCode_txt
            // 
            this.StockLocationCode_txt.ControlId = null;
            resources.ApplyResources(this.StockLocationCode_txt, "StockLocationCode_txt");
            this.StockLocationCode_txt.InputType = Com.Nidec.Mes.Framework.TextBoxCommon.InputTypeList.All;
            this.StockLocationCode_txt.Name = "StockLocationCode_txt";
            // 
            // colStockLocationId
            // 
            this.colStockLocationId.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colStockLocationId.DataPropertyName = "StockLocationId";
            resources.ApplyResources(this.colStockLocationId, "colStockLocationId");
            this.colStockLocationId.Name = "colStockLocationId";
            this.colStockLocationId.ReadOnly = true;
            // 
            // colStockLocationCode
            // 
            this.colStockLocationCode.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colStockLocationCode.DataPropertyName = "StockLocationCode";
            resources.ApplyResources(this.colStockLocationCode, "colStockLocationCode");
            this.colStockLocationCode.Name = "colStockLocationCode";
            this.colStockLocationCode.ReadOnly = true;
            // 
            // colStockLocationName
            // 
            this.colStockLocationName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colStockLocationName.DataPropertyName = "StockLocationName";
            resources.ApplyResources(this.colStockLocationName, "colStockLocationName");
            this.colStockLocationName.Name = "colStockLocationName";
            this.colStockLocationName.ReadOnly = true;
            // 
            // colDisplayOrder
            // 
            this.colDisplayOrder.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colDisplayOrder.DataPropertyName = "DisplayOrder";
            resources.ApplyResources(this.colDisplayOrder, "colDisplayOrder");
            this.colDisplayOrder.Name = "colDisplayOrder";
            this.colDisplayOrder.ReadOnly = true;
            // 
            // colLocationType
            // 
            this.colLocationType.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colLocationType.DataPropertyName = "LocationTypeDisplay";
            resources.ApplyResources(this.colLocationType, "colLocationType");
            this.colLocationType.Name = "colLocationType";
            this.colLocationType.ReadOnly = true;
            // 
            // StockLocationForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ControlId = "bpmf010";
            this.Controls.Add(this.StockLocationCode_txt);
            this.Controls.Add(this.ItemName_lbl);
            this.Controls.Add(this.StockLocationName_txt);
            this.Controls.Add(this.ItemCode_lbl);
            this.Controls.Add(this.Clear_btn);
            this.Controls.Add(this.Exit_btn);
            this.Controls.Add(this.Delete_btn);
            this.Controls.Add(this.Update_btn);
            this.Controls.Add(this.Add_btn);
            this.Controls.Add(this.Search_btn);
            this.Controls.Add(this.StockLocationData_dgv);
            this.Name = "StockLocationForm";
            this.TitleText = "FormCommon";
            this.Load += new System.EventHandler(this.StockLocationForm_Load);
            this.Controls.SetChildIndex(this.StockLocationData_dgv, 0);
            this.Controls.SetChildIndex(this.Search_btn, 0);
            this.Controls.SetChildIndex(this.Add_btn, 0);
            this.Controls.SetChildIndex(this.Update_btn, 0);
            this.Controls.SetChildIndex(this.Delete_btn, 0);
            this.Controls.SetChildIndex(this.Exit_btn, 0);
            this.Controls.SetChildIndex(this.Clear_btn, 0);
            this.Controls.SetChildIndex(this.ItemCode_lbl, 0);
            this.Controls.SetChildIndex(this.StockLocationName_txt, 0);
            this.Controls.SetChildIndex(this.ItemName_lbl, 0);
            this.Controls.SetChildIndex(this.StockLocationCode_txt, 0);
            ((System.ComponentModel.ISupportInitialize)(this.StockLocationData_dgv)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        protected Framework.ButtonCommon Clear_btn;
        protected Framework.ButtonCommon Exit_btn;
        protected Framework.ButtonCommon Delete_btn;
        protected Framework.ButtonCommon Update_btn;
        protected Framework.ButtonCommon Add_btn;
        protected Framework.ButtonCommon Search_btn;
        protected Framework.DataGridViewCommon StockLocationData_dgv;
        protected Framework.LabelCommon ItemName_lbl;
        protected Framework.TextBoxCommon StockLocationName_txt;
        protected Framework.LabelCommon ItemCode_lbl;
        protected Framework.TextBoxCommon StockLocationCode_txt;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStockLocationId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStockLocationCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStockLocationName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDisplayOrder;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLocationType;
    }
}