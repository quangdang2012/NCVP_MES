namespace Com.Nidec.Mes.GlobalMasterMaintenance
{
    partial class ItemForm : FormCommonMaster
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ItemForm));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.Clear_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.Exit_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.Delete_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.Update_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.Add_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.Search_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.ItemData_dgv = new Com.Nidec.Mes.Framework.DataGridViewCommon();
            this.colItemId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colItemCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colItemName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colUnitType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ItemCode_txt = new Com.Nidec.Mes.Framework.TextBoxCommon();
            this.ItemName_lbl = new Com.Nidec.Mes.Framework.LabelCommon();
            this.ItemName_txt = new Com.Nidec.Mes.Framework.TextBoxCommon();
            this.ItemCode_lbl = new Com.Nidec.Mes.Framework.LabelCommon();
            ((System.ComponentModel.ISupportInitialize)(this.ItemData_dgv)).BeginInit();
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
            // ItemData_dgv
            // 
            this.ItemData_dgv.AllowUserToAddRows = false;
            this.ItemData_dgv.AllowUserToDeleteRows = false;
            this.ItemData_dgv.AllowUserToOrderColumns = true;
            this.ItemData_dgv.AllowUserToResizeRows = false;
            resources.ApplyResources(this.ItemData_dgv, "ItemData_dgv");
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(232)))), ((int)(((byte)(180)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.ItemData_dgv.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.ItemData_dgv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colItemId,
            this.colItemCode,
            this.colItemName,
            this.colUnitType});
            this.ItemData_dgv.ControlId = null;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.ItemData_dgv.DefaultCellStyle = dataGridViewCellStyle2;
            this.ItemData_dgv.EnableHeadersVisualStyles = false;
            this.ItemData_dgv.MultiSelect = false;
            this.ItemData_dgv.Name = "ItemData_dgv";
            this.ItemData_dgv.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(232)))), ((int)(((byte)(180)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.ItemData_dgv.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.ItemData_dgv.RowHeadersVisible = false;
            this.ItemData_dgv.RowTemplate.Height = 21;
            this.ItemData_dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.ItemData_dgv.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.ItemData_dgv_CellClick);
            this.ItemData_dgv.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.ItemData_dgv_CellDoubleClick);
            // 
            // colItemId
            // 
            this.colItemId.DataPropertyName = "ItemId";
            resources.ApplyResources(this.colItemId, "colItemId");
            this.colItemId.Name = "colItemId";
            this.colItemId.ReadOnly = true;
            // 
            // colItemCode
            // 
            this.colItemCode.DataPropertyName = "ItemCode";
            resources.ApplyResources(this.colItemCode, "colItemCode");
            this.colItemCode.Name = "colItemCode";
            this.colItemCode.ReadOnly = true;
            // 
            // colItemName
            // 
            this.colItemName.DataPropertyName = "ItemName";
            resources.ApplyResources(this.colItemName, "colItemName");
            this.colItemName.Name = "colItemName";
            this.colItemName.ReadOnly = true;
            // 
            // colUnitType
            // 
            this.colUnitType.DataPropertyName = "UnitType_Display";
            resources.ApplyResources(this.colUnitType, "colUnitType");
            this.colUnitType.Name = "colUnitType";
            this.colUnitType.ReadOnly = true;
            // 
            // ItemCode_txt
            // 
            this.ItemCode_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Lower;
            this.ItemCode_txt.ControlId = null;
            resources.ApplyResources(this.ItemCode_txt, "ItemCode_txt");
            this.ItemCode_txt.InputType = Com.Nidec.Mes.Framework.TextBoxCommon.InputTypeList.All;
            this.ItemCode_txt.Name = "ItemCode_txt";
            // 
            // ItemName_lbl
            // 
            resources.ApplyResources(this.ItemName_lbl, "ItemName_lbl");
            this.ItemName_lbl.ControlId = null;
            this.ItemName_lbl.Name = "ItemName_lbl";
            // 
            // ItemName_txt
            // 
            this.ItemName_txt.ControlId = null;
            resources.ApplyResources(this.ItemName_txt, "ItemName_txt");
            this.ItemName_txt.InputType = Com.Nidec.Mes.Framework.TextBoxCommon.InputTypeList.All;
            this.ItemName_txt.Name = "ItemName_txt";
            // 
            // ItemCode_lbl
            // 
            resources.ApplyResources(this.ItemCode_lbl, "ItemCode_lbl");
            this.ItemCode_lbl.ControlId = null;
            this.ItemCode_lbl.Name = "ItemCode_lbl";
            // 
            // ItemForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ControlId = "bpmf010";
            this.Controls.Add(this.ItemCode_txt);
            this.Controls.Add(this.ItemName_lbl);
            this.Controls.Add(this.ItemName_txt);
            this.Controls.Add(this.ItemCode_lbl);
            this.Controls.Add(this.Clear_btn);
            this.Controls.Add(this.Exit_btn);
            this.Controls.Add(this.Delete_btn);
            this.Controls.Add(this.Update_btn);
            this.Controls.Add(this.Add_btn);
            this.Controls.Add(this.Search_btn);
            this.Controls.Add(this.ItemData_dgv);
            this.Name = "ItemForm";
            this.TitleText = "FormCommon";
            this.Load += new System.EventHandler(this.ItemForm_Load);
            this.Controls.SetChildIndex(this.ItemData_dgv, 0);
            this.Controls.SetChildIndex(this.Search_btn, 0);
            this.Controls.SetChildIndex(this.Add_btn, 0);
            this.Controls.SetChildIndex(this.Update_btn, 0);
            this.Controls.SetChildIndex(this.Delete_btn, 0);
            this.Controls.SetChildIndex(this.Exit_btn, 0);
            this.Controls.SetChildIndex(this.Clear_btn, 0);
            this.Controls.SetChildIndex(this.ItemCode_lbl, 0);
            this.Controls.SetChildIndex(this.ItemName_txt, 0);
            this.Controls.SetChildIndex(this.ItemName_lbl, 0);
            this.Controls.SetChildIndex(this.ItemCode_txt, 0);
            ((System.ComponentModel.ISupportInitialize)(this.ItemData_dgv)).EndInit();
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
        protected Framework.DataGridViewCommon ItemData_dgv;
        protected Framework.TextBoxCommon ItemCode_txt;
        protected Framework.LabelCommon ItemName_lbl;
        protected Framework.TextBoxCommon ItemName_txt;
        protected Framework.LabelCommon ItemCode_lbl;
        private System.Windows.Forms.DataGridViewTextBoxColumn colItemId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colItemCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn colItemName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colUnitType;
    }
}