namespace Com.Nidec.Mes.GlobalMasterMaintenance
{
    partial class GlobalItemForm : FormCommonMaster
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GlobalItemForm));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.Clear_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.Exit_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.Delete_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.Update_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.Add_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.Search_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.GlobalItemData_dgv = new Com.Nidec.Mes.Framework.DataGridViewCommon();
            this.GlobalItemCode_txt = new Com.Nidec.Mes.Framework.TextBoxCommon();
            this.GlobalItemName_lbl = new Com.Nidec.Mes.Framework.LabelCommon();
            this.GlobalItemName_txt = new Com.Nidec.Mes.Framework.TextBoxCommon();
            this.GlobalItemCode_lbl = new Com.Nidec.Mes.Framework.LabelCommon();
            this.colItemId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colItemCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colItemName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.GlobalItemData_dgv)).BeginInit();
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
            // GlobalItemData_dgv
            // 
            this.GlobalItemData_dgv.AllowUserToAddRows = false;
            this.GlobalItemData_dgv.AllowUserToDeleteRows = false;
            this.GlobalItemData_dgv.AllowUserToOrderColumns = true;
            this.GlobalItemData_dgv.AllowUserToResizeRows = false;
            resources.ApplyResources(this.GlobalItemData_dgv, "GlobalItemData_dgv");
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(232)))), ((int)(((byte)(180)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.GlobalItemData_dgv.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.GlobalItemData_dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GlobalItemData_dgv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colItemId,
            this.colItemCode,
            this.colItemName});
            this.GlobalItemData_dgv.ControlId = null;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.GlobalItemData_dgv.DefaultCellStyle = dataGridViewCellStyle2;
            this.GlobalItemData_dgv.EnableHeadersVisualStyles = false;
            this.GlobalItemData_dgv.MultiSelect = false;
            this.GlobalItemData_dgv.Name = "GlobalItemData_dgv";
            this.GlobalItemData_dgv.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(232)))), ((int)(((byte)(180)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.GlobalItemData_dgv.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.GlobalItemData_dgv.RowHeadersVisible = false;
            this.GlobalItemData_dgv.RowTemplate.Height = 21;
            this.GlobalItemData_dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.GlobalItemData_dgv.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.ItemData_dgv_CellClick);
            this.GlobalItemData_dgv.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.ItemData_dgv_CellDoubleClick);
            // 
            // GlobalItemCode_txt
            // 
            this.GlobalItemCode_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Lower;
            this.GlobalItemCode_txt.ControlId = null;
            resources.ApplyResources(this.GlobalItemCode_txt, "GlobalItemCode_txt");
            this.GlobalItemCode_txt.InputType = Com.Nidec.Mes.Framework.TextBoxCommon.InputTypeList.All;
            this.GlobalItemCode_txt.Name = "GlobalItemCode_txt";
            // 
            // GlobalItemName_lbl
            // 
            resources.ApplyResources(this.GlobalItemName_lbl, "GlobalItemName_lbl");
            this.GlobalItemName_lbl.ControlId = null;
            this.GlobalItemName_lbl.Name = "GlobalItemName_lbl";
            // 
            // GlobalItemName_txt
            // 
            this.GlobalItemName_txt.ControlId = null;
            resources.ApplyResources(this.GlobalItemName_txt, "GlobalItemName_txt");
            this.GlobalItemName_txt.InputType = Com.Nidec.Mes.Framework.TextBoxCommon.InputTypeList.All;
            this.GlobalItemName_txt.Name = "GlobalItemName_txt";
            // 
            // GlobalItemCode_lbl
            // 
            resources.ApplyResources(this.GlobalItemCode_lbl, "GlobalItemCode_lbl");
            this.GlobalItemCode_lbl.ControlId = null;
            this.GlobalItemCode_lbl.Name = "GlobalItemCode_lbl";
            // 
            // colItemId
            // 
            this.colItemId.DataPropertyName = "GlobalItemId";
            resources.ApplyResources(this.colItemId, "colItemId");
            this.colItemId.Name = "colItemId";
            this.colItemId.ReadOnly = true;
            // 
            // colItemCode
            // 
            this.colItemCode.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colItemCode.DataPropertyName = "GlobalItemCode";
            resources.ApplyResources(this.colItemCode, "colItemCode");
            this.colItemCode.Name = "colItemCode";
            this.colItemCode.ReadOnly = true;
            // 
            // colItemName
            // 
            this.colItemName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colItemName.DataPropertyName = "GlobalItemName";
            resources.ApplyResources(this.colItemName, "colItemName");
            this.colItemName.Name = "colItemName";
            this.colItemName.ReadOnly = true;
            // 
            // GlobalItemForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ControlId = "bpmf010";
            this.Controls.Add(this.GlobalItemCode_txt);
            this.Controls.Add(this.GlobalItemName_lbl);
            this.Controls.Add(this.GlobalItemName_txt);
            this.Controls.Add(this.GlobalItemCode_lbl);
            this.Controls.Add(this.Clear_btn);
            this.Controls.Add(this.Exit_btn);
            this.Controls.Add(this.Delete_btn);
            this.Controls.Add(this.Update_btn);
            this.Controls.Add(this.Add_btn);
            this.Controls.Add(this.Search_btn);
            this.Controls.Add(this.GlobalItemData_dgv);
            this.Name = "GlobalItemForm";
            this.TitleText = "FormCommon";
            this.Load += new System.EventHandler(this.ItemForm_Load);
            this.Controls.SetChildIndex(this.GlobalItemData_dgv, 0);
            this.Controls.SetChildIndex(this.Search_btn, 0);
            this.Controls.SetChildIndex(this.Add_btn, 0);
            this.Controls.SetChildIndex(this.Update_btn, 0);
            this.Controls.SetChildIndex(this.Delete_btn, 0);
            this.Controls.SetChildIndex(this.Exit_btn, 0);
            this.Controls.SetChildIndex(this.Clear_btn, 0);
            this.Controls.SetChildIndex(this.GlobalItemCode_lbl, 0);
            this.Controls.SetChildIndex(this.GlobalItemName_txt, 0);
            this.Controls.SetChildIndex(this.GlobalItemName_lbl, 0);
            this.Controls.SetChildIndex(this.GlobalItemCode_txt, 0);
            ((System.ComponentModel.ISupportInitialize)(this.GlobalItemData_dgv)).EndInit();
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
        protected Framework.DataGridViewCommon GlobalItemData_dgv;
        protected Framework.TextBoxCommon GlobalItemCode_txt;
        protected Framework.LabelCommon GlobalItemName_lbl;
        protected Framework.TextBoxCommon GlobalItemName_txt;
        protected Framework.LabelCommon GlobalItemCode_lbl;
        private System.Windows.Forms.DataGridViewTextBoxColumn colItemId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colItemCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn colItemName;
    }
}