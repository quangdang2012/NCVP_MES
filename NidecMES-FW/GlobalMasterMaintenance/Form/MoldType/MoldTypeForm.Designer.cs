namespace Com.Nidec.Mes.GlobalMasterMaintenance
{
    partial class MoldTypeForm : FormCommonMaster
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MoldTypeForm));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.Clear_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.Exit_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.Delete_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.Update_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.Add_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.Search_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.MoldType_dgv = new Com.Nidec.Mes.Framework.DataGridViewCommon();
            this.colMoldTypeId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMoldTypeCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMoldTypeName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colItem = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colItemId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Item_lbl = new Com.Nidec.Mes.Framework.LabelCommon();
            this.Item_cmb = new Com.Nidec.Mes.Framework.ComboBoxCommon();
            this.MoldTypeCode_txt = new Com.Nidec.Mes.Framework.TextBoxCommon();
            this.MoldTypeName_lbl = new Com.Nidec.Mes.Framework.LabelCommon();
            this.MoldTypeName_txt = new Com.Nidec.Mes.Framework.TextBoxCommon();
            this.MoldTypeCode_lbl = new Com.Nidec.Mes.Framework.LabelCommon();
            ((System.ComponentModel.ISupportInitialize)(this.MoldType_dgv)).BeginInit();
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
            // MoldType_dgv
            // 
            this.MoldType_dgv.AllowUserToAddRows = false;
            this.MoldType_dgv.AllowUserToDeleteRows = false;
            resources.ApplyResources(this.MoldType_dgv, "MoldType_dgv");
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(232)))), ((int)(((byte)(180)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.MoldType_dgv.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.MoldType_dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.MoldType_dgv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colMoldTypeId,
            this.colMoldTypeCode,
            this.colMoldTypeName,
            this.colItem,
            this.colItemId});
            this.MoldType_dgv.ControlId = null;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.MoldType_dgv.DefaultCellStyle = dataGridViewCellStyle2;
            this.MoldType_dgv.EnableHeadersVisualStyles = false;
            this.MoldType_dgv.MultiSelect = false;
            this.MoldType_dgv.Name = "MoldType_dgv";
            this.MoldType_dgv.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(232)))), ((int)(((byte)(180)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.MoldType_dgv.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.MoldType_dgv.RowHeadersVisible = false;
            this.MoldType_dgv.RowTemplate.Height = 21;
            this.MoldType_dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.MoldType_dgv.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.MoldType_dgv_CellClick);
            this.MoldType_dgv.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.MoldType_dgv_CellDoubleClick);
            // 
            // colMoldTypeId
            // 
            this.colMoldTypeId.DataPropertyName = "MoldTypeId";
            resources.ApplyResources(this.colMoldTypeId, "colMoldTypeId");
            this.colMoldTypeId.Name = "colMoldTypeId";
            this.colMoldTypeId.ReadOnly = true;
            // 
            // colMoldTypeCode
            // 
            this.colMoldTypeCode.DataPropertyName = "MoldTypeCode";
            resources.ApplyResources(this.colMoldTypeCode, "colMoldTypeCode");
            this.colMoldTypeCode.Name = "colMoldTypeCode";
            this.colMoldTypeCode.ReadOnly = true;
            // 
            // colMoldTypeName
            // 
            this.colMoldTypeName.DataPropertyName = "MoldTypeName";
            resources.ApplyResources(this.colMoldTypeName, "colMoldTypeName");
            this.colMoldTypeName.Name = "colMoldTypeName";
            this.colMoldTypeName.ReadOnly = true;
            // 
            // colItem
            // 
            this.colItem.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colItem.DataPropertyName = "ItemCode";
            resources.ApplyResources(this.colItem, "colItem");
            this.colItem.Name = "colItem";
            this.colItem.ReadOnly = true;
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
            // MoldTypeCode_txt
            // 
            this.MoldTypeCode_txt.ControlId = null;
            resources.ApplyResources(this.MoldTypeCode_txt, "MoldTypeCode_txt");
            this.MoldTypeCode_txt.InputType = Com.Nidec.Mes.Framework.TextBoxCommon.InputTypeList.All;
            this.MoldTypeCode_txt.Name = "MoldTypeCode_txt";
            // 
            // MoldTypeName_lbl
            // 
            resources.ApplyResources(this.MoldTypeName_lbl, "MoldTypeName_lbl");
            this.MoldTypeName_lbl.ControlId = null;
            this.MoldTypeName_lbl.Name = "MoldTypeName_lbl";
            // 
            // MoldTypeName_txt
            // 
            this.MoldTypeName_txt.ControlId = null;
            resources.ApplyResources(this.MoldTypeName_txt, "MoldTypeName_txt");
            this.MoldTypeName_txt.InputType = Com.Nidec.Mes.Framework.TextBoxCommon.InputTypeList.All;
            this.MoldTypeName_txt.Name = "MoldTypeName_txt";
            // 
            // MoldTypeCode_lbl
            // 
            resources.ApplyResources(this.MoldTypeCode_lbl, "MoldTypeCode_lbl");
            this.MoldTypeCode_lbl.ControlId = null;
            this.MoldTypeCode_lbl.Name = "MoldTypeCode_lbl";
            // 
            // MoldTypeForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ControlId = "bpmf011";
            this.Controls.Add(this.Item_lbl);
            this.Controls.Add(this.Item_cmb);
            this.Controls.Add(this.MoldTypeCode_txt);
            this.Controls.Add(this.MoldTypeName_lbl);
            this.Controls.Add(this.MoldTypeName_txt);
            this.Controls.Add(this.MoldTypeCode_lbl);
            this.Controls.Add(this.Clear_btn);
            this.Controls.Add(this.Exit_btn);
            this.Controls.Add(this.Delete_btn);
            this.Controls.Add(this.Update_btn);
            this.Controls.Add(this.Add_btn);
            this.Controls.Add(this.Search_btn);
            this.Controls.Add(this.MoldType_dgv);
            this.Name = "MoldTypeForm";
            this.TitleText = "FormCommon";
            this.Load += new System.EventHandler(this.MoldTypeForm_Load);
            this.Controls.SetChildIndex(this.MoldType_dgv, 0);
            this.Controls.SetChildIndex(this.Search_btn, 0);
            this.Controls.SetChildIndex(this.Add_btn, 0);
            this.Controls.SetChildIndex(this.Update_btn, 0);
            this.Controls.SetChildIndex(this.Delete_btn, 0);
            this.Controls.SetChildIndex(this.Exit_btn, 0);
            this.Controls.SetChildIndex(this.Clear_btn, 0);
            this.Controls.SetChildIndex(this.MoldTypeCode_lbl, 0);
            this.Controls.SetChildIndex(this.MoldTypeName_txt, 0);
            this.Controls.SetChildIndex(this.MoldTypeName_lbl, 0);
            this.Controls.SetChildIndex(this.MoldTypeCode_txt, 0);
            this.Controls.SetChildIndex(this.Item_cmb, 0);
            this.Controls.SetChildIndex(this.Item_lbl, 0);
            ((System.ComponentModel.ISupportInitialize)(this.MoldType_dgv)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Com.Nidec.Mes.Framework.ButtonCommon Clear_btn;
        private Com.Nidec.Mes.Framework.ButtonCommon Exit_btn;
        private Com.Nidec.Mes.Framework.ButtonCommon Delete_btn;
        private Com.Nidec.Mes.Framework.ButtonCommon Update_btn;
        private Com.Nidec.Mes.Framework.ButtonCommon Add_btn;
        private Com.Nidec.Mes.Framework.ButtonCommon Search_btn;
        internal Com.Nidec.Mes.Framework.DataGridViewCommon MoldType_dgv;
        private Com.Nidec.Mes.Framework.LabelCommon Item_lbl;
        private Com.Nidec.Mes.Framework.ComboBoxCommon Item_cmb;
        private Com.Nidec.Mes.Framework.TextBoxCommon MoldTypeCode_txt;
        private Com.Nidec.Mes.Framework.LabelCommon MoldTypeName_lbl;
        private Com.Nidec.Mes.Framework.TextBoxCommon MoldTypeName_txt;
        private Com.Nidec.Mes.Framework.LabelCommon MoldTypeCode_lbl;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMoldTypeId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMoldTypeCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMoldTypeName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn colItemId;
    }
}