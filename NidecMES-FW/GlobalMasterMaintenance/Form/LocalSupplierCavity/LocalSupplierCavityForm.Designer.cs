namespace Com.Nidec.Mes.GlobalMasterMaintenance
{
    partial class LocalSupplierCavityForm : FormCommonMaster
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LocalSupplierCavityForm));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.LocalSupplier_lbl = new Com.Nidec.Mes.Framework.LabelCommon();
            this.LocalSupplier_cmb = new Com.Nidec.Mes.Framework.ComboBoxCommon();
            this.LocalSupplierCavityCode_txt = new Com.Nidec.Mes.Framework.TextBoxCommon();
            this.LocalSupplierCavityName_lbl = new Com.Nidec.Mes.Framework.LabelCommon();
            this.LocalSupplierCavityName_txt = new Com.Nidec.Mes.Framework.TextBoxCommon();
            this.LocalSupplierCavityCode_lbl = new Com.Nidec.Mes.Framework.LabelCommon();
            this.Clear_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.Exit_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.Delete_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.Update_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.Add_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.Search_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.LocalSupplierCavity_dgv = new Com.Nidec.Mes.Framework.DataGridViewCommon();
            this.colLocalSupplierCavityCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLocalSupplierCavityName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLocalSupplierType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLocalSupplierTypeId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLocalSupplierCavityId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colItemCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colItemId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Item_lbl = new Com.Nidec.Mes.Framework.LabelCommon();
            this.Item_cmb = new Com.Nidec.Mes.Framework.ComboBoxCommon();
            ((System.ComponentModel.ISupportInitialize)(this.LocalSupplierCavity_dgv)).BeginInit();
            this.SuspendLayout();
            // 
            // LocalSupplier_lbl
            // 
            resources.ApplyResources(this.LocalSupplier_lbl, "LocalSupplier_lbl");
            this.LocalSupplier_lbl.ControlId = null;
            this.LocalSupplier_lbl.Name = "LocalSupplier_lbl";
            // 
            // LocalSupplier_cmb
            // 
            this.LocalSupplier_cmb.ControlId = null;
            resources.ApplyResources(this.LocalSupplier_cmb, "LocalSupplier_cmb");
            this.LocalSupplier_cmb.FormattingEnabled = true;
            this.LocalSupplier_cmb.Name = "LocalSupplier_cmb";
            // 
            // LocalSupplierCavityCode_txt
            // 
            this.LocalSupplierCavityCode_txt.ControlId = null;
            resources.ApplyResources(this.LocalSupplierCavityCode_txt, "LocalSupplierCavityCode_txt");
            this.LocalSupplierCavityCode_txt.InputType = Com.Nidec.Mes.Framework.TextBoxCommon.InputTypeList.All;
            this.LocalSupplierCavityCode_txt.Name = "LocalSupplierCavityCode_txt";
            // 
            // LocalSupplierCavityName_lbl
            // 
            resources.ApplyResources(this.LocalSupplierCavityName_lbl, "LocalSupplierCavityName_lbl");
            this.LocalSupplierCavityName_lbl.ControlId = null;
            this.LocalSupplierCavityName_lbl.Name = "LocalSupplierCavityName_lbl";
            // 
            // LocalSupplierCavityName_txt
            // 
            this.LocalSupplierCavityName_txt.ControlId = null;
            resources.ApplyResources(this.LocalSupplierCavityName_txt, "LocalSupplierCavityName_txt");
            this.LocalSupplierCavityName_txt.InputType = Com.Nidec.Mes.Framework.TextBoxCommon.InputTypeList.All;
            this.LocalSupplierCavityName_txt.Name = "LocalSupplierCavityName_txt";
            // 
            // LocalSupplierCavityCode_lbl
            // 
            resources.ApplyResources(this.LocalSupplierCavityCode_lbl, "LocalSupplierCavityCode_lbl");
            this.LocalSupplierCavityCode_lbl.ControlId = null;
            this.LocalSupplierCavityCode_lbl.Name = "LocalSupplierCavityCode_lbl";
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
            // LocalSupplierCavity_dgv
            // 
            this.LocalSupplierCavity_dgv.AllowUserToAddRows = false;
            this.LocalSupplierCavity_dgv.AllowUserToDeleteRows = false;
            this.LocalSupplierCavity_dgv.AllowUserToOrderColumns = true;
            this.LocalSupplierCavity_dgv.AllowUserToResizeRows = false;
            resources.ApplyResources(this.LocalSupplierCavity_dgv, "LocalSupplierCavity_dgv");
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(232)))), ((int)(((byte)(180)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.LocalSupplierCavity_dgv.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.LocalSupplierCavity_dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.LocalSupplierCavity_dgv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colLocalSupplierCavityCode,
            this.colLocalSupplierCavityName,
            this.colLocalSupplierType,
            this.colLocalSupplierTypeId,
            this.colLocalSupplierCavityId,
            this.colItemCode,
            this.colItemId});
            this.LocalSupplierCavity_dgv.ControlId = null;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.LocalSupplierCavity_dgv.DefaultCellStyle = dataGridViewCellStyle2;
            this.LocalSupplierCavity_dgv.EnableHeadersVisualStyles = false;
            this.LocalSupplierCavity_dgv.MultiSelect = false;
            this.LocalSupplierCavity_dgv.Name = "LocalSupplierCavity_dgv";
            this.LocalSupplierCavity_dgv.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(232)))), ((int)(((byte)(180)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.LocalSupplierCavity_dgv.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.LocalSupplierCavity_dgv.RowHeadersVisible = false;
            this.LocalSupplierCavity_dgv.RowTemplate.Height = 21;
            this.LocalSupplierCavity_dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.LocalSupplierCavity_dgv.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.LocalSupplierCavity_dgv_CellClick);
            this.LocalSupplierCavity_dgv.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.LocalSupplierCavity_dgv_CellDoubleClick);
            this.LocalSupplierCavity_dgv.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.LocalSupplierCavity_dgv_ColumnHeaderMouseClick);
            // 
            // colLocalSupplierCavityCode
            // 
            this.colLocalSupplierCavityCode.DataPropertyName = "LocalSupplierCavityCode";
            resources.ApplyResources(this.colLocalSupplierCavityCode, "colLocalSupplierCavityCode");
            this.colLocalSupplierCavityCode.Name = "colLocalSupplierCavityCode";
            this.colLocalSupplierCavityCode.ReadOnly = true;
            // 
            // colLocalSupplierCavityName
            // 
            this.colLocalSupplierCavityName.DataPropertyName = "LocalSupplierCavityName";
            resources.ApplyResources(this.colLocalSupplierCavityName, "colLocalSupplierCavityName");
            this.colLocalSupplierCavityName.Name = "colLocalSupplierCavityName";
            this.colLocalSupplierCavityName.ReadOnly = true;
            // 
            // colLocalSupplierType
            // 
            this.colLocalSupplierType.DataPropertyName = "LocalSupplierName";
            resources.ApplyResources(this.colLocalSupplierType, "colLocalSupplierType");
            this.colLocalSupplierType.Name = "colLocalSupplierType";
            this.colLocalSupplierType.ReadOnly = true;
            // 
            // colLocalSupplierTypeId
            // 
            this.colLocalSupplierTypeId.DataPropertyName = "LocalSupplierId";
            resources.ApplyResources(this.colLocalSupplierTypeId, "colLocalSupplierTypeId");
            this.colLocalSupplierTypeId.Name = "colLocalSupplierTypeId";
            this.colLocalSupplierTypeId.ReadOnly = true;
            // 
            // colLocalSupplierCavityId
            // 
            this.colLocalSupplierCavityId.DataPropertyName = "LocalSupplierCavityId";
            resources.ApplyResources(this.colLocalSupplierCavityId, "colLocalSupplierCavityId");
            this.colLocalSupplierCavityId.Name = "colLocalSupplierCavityId";
            this.colLocalSupplierCavityId.ReadOnly = true;
            // 
            // colItemCode
            // 
            this.colItemCode.DataPropertyName = "ItemCode";
            resources.ApplyResources(this.colItemCode, "colItemCode");
            this.colItemCode.Name = "colItemCode";
            this.colItemCode.ReadOnly = true;
            // 
            // colItemId
            // 
            this.colItemId.DataPropertyName = "ItemId";
            resources.ApplyResources(this.colItemId, "colItemId");
            this.colItemId.Name = "colItemId";
            this.colItemId.ReadOnly = true;
            // 
            // Item_lbl
            // 
            resources.ApplyResources(this.Item_lbl, "Item_lbl");
            this.Item_lbl.ControlId = null;
            this.Item_lbl.Name = "Item_lbl";
            // 
            // Item_cmb
            // 
            this.Item_cmb.ControlId = null;
            resources.ApplyResources(this.Item_cmb, "Item_cmb");
            this.Item_cmb.FormattingEnabled = true;
            this.Item_cmb.Name = "Item_cmb";
            // 
            // LocalSupplierCavityForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ControlId = "bpmf012";
            this.Controls.Add(this.Item_lbl);
            this.Controls.Add(this.Item_cmb);
            this.Controls.Add(this.LocalSupplier_lbl);
            this.Controls.Add(this.LocalSupplier_cmb);
            this.Controls.Add(this.LocalSupplierCavityCode_txt);
            this.Controls.Add(this.LocalSupplierCavityName_lbl);
            this.Controls.Add(this.LocalSupplierCavityName_txt);
            this.Controls.Add(this.LocalSupplierCavityCode_lbl);
            this.Controls.Add(this.Clear_btn);
            this.Controls.Add(this.Exit_btn);
            this.Controls.Add(this.Delete_btn);
            this.Controls.Add(this.Update_btn);
            this.Controls.Add(this.Add_btn);
            this.Controls.Add(this.Search_btn);
            this.Controls.Add(this.LocalSupplierCavity_dgv);
            this.Name = "LocalSupplierCavityForm";
            this.TitleText = "FormCommon";
            this.Load += new System.EventHandler(this.LocalSupplierCavityForm_Load);
            this.Controls.SetChildIndex(this.LocalSupplierCavity_dgv, 0);
            this.Controls.SetChildIndex(this.Search_btn, 0);
            this.Controls.SetChildIndex(this.Add_btn, 0);
            this.Controls.SetChildIndex(this.Update_btn, 0);
            this.Controls.SetChildIndex(this.Delete_btn, 0);
            this.Controls.SetChildIndex(this.Exit_btn, 0);
            this.Controls.SetChildIndex(this.Clear_btn, 0);
            this.Controls.SetChildIndex(this.LocalSupplierCavityCode_lbl, 0);
            this.Controls.SetChildIndex(this.LocalSupplierCavityName_txt, 0);
            this.Controls.SetChildIndex(this.LocalSupplierCavityName_lbl, 0);
            this.Controls.SetChildIndex(this.LocalSupplierCavityCode_txt, 0);
            this.Controls.SetChildIndex(this.LocalSupplier_cmb, 0);
            this.Controls.SetChildIndex(this.LocalSupplier_lbl, 0);
            this.Controls.SetChildIndex(this.Item_cmb, 0);
            this.Controls.SetChildIndex(this.Item_lbl, 0);
            ((System.ComponentModel.ISupportInitialize)(this.LocalSupplierCavity_dgv)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Com.Nidec.Mes.Framework.LabelCommon LocalSupplier_lbl;
        private Com.Nidec.Mes.Framework.ComboBoxCommon LocalSupplier_cmb;
        private Com.Nidec.Mes.Framework.TextBoxCommon LocalSupplierCavityCode_txt;
        private Com.Nidec.Mes.Framework.LabelCommon LocalSupplierCavityName_lbl;
        private Com.Nidec.Mes.Framework.TextBoxCommon LocalSupplierCavityName_txt;
        private Com.Nidec.Mes.Framework.LabelCommon LocalSupplierCavityCode_lbl;
        private Com.Nidec.Mes.Framework.ButtonCommon Clear_btn;
        private Com.Nidec.Mes.Framework.ButtonCommon Exit_btn;
        private Com.Nidec.Mes.Framework.ButtonCommon Delete_btn;
        private Com.Nidec.Mes.Framework.ButtonCommon Update_btn;
        private Com.Nidec.Mes.Framework.ButtonCommon Add_btn;
        private Com.Nidec.Mes.Framework.ButtonCommon Search_btn;
        internal Com.Nidec.Mes.Framework.DataGridViewCommon LocalSupplierCavity_dgv;
        private Framework.LabelCommon Item_lbl;
        private Framework.ComboBoxCommon Item_cmb;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLocalSupplierCavityCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLocalSupplierCavityName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLocalSupplierType;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLocalSupplierTypeId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLocalSupplierCavityId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colItemCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn colItemId;
    }
}