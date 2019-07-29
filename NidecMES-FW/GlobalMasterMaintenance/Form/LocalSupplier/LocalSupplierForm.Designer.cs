namespace Com.Nidec.Mes.GlobalMasterMaintenance
{
    partial class LocalSupplierForm : FormCommonMaster
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LocalSupplierForm));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.Clear_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.Exit_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.Delete_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.Update_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.Add_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.Search_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.LocalSupplier_dgv = new Com.Nidec.Mes.Framework.DataGridViewCommon();
            this.colLocalSupplierId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLocalSupplierCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLocalSupplierName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LocalSupplierCode_txt = new Com.Nidec.Mes.Framework.TextBoxCommon();
            this.LocalSupplierName_lbl = new Com.Nidec.Mes.Framework.LabelCommon();
            this.LocalSupplierName_txt = new Com.Nidec.Mes.Framework.TextBoxCommon();
            this.LocalSupplierCode_lbl = new Com.Nidec.Mes.Framework.LabelCommon();
            ((System.ComponentModel.ISupportInitialize)(this.LocalSupplier_dgv)).BeginInit();
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
            // LocalSupplier_dgv
            // 
            this.LocalSupplier_dgv.AllowUserToAddRows = false;
            this.LocalSupplier_dgv.AllowUserToDeleteRows = false;
            this.LocalSupplier_dgv.AllowUserToOrderColumns = true;
            this.LocalSupplier_dgv.AllowUserToResizeRows = false;
            resources.ApplyResources(this.LocalSupplier_dgv, "LocalSupplier_dgv");
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(232)))), ((int)(((byte)(180)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.LocalSupplier_dgv.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.LocalSupplier_dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.LocalSupplier_dgv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colLocalSupplierId,
            this.colLocalSupplierCode,
            this.colLocalSupplierName});
            this.LocalSupplier_dgv.ControlId = null;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.LocalSupplier_dgv.DefaultCellStyle = dataGridViewCellStyle2;
            this.LocalSupplier_dgv.EnableHeadersVisualStyles = false;
            this.LocalSupplier_dgv.MultiSelect = false;
            this.LocalSupplier_dgv.Name = "LocalSupplier_dgv";
            this.LocalSupplier_dgv.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(232)))), ((int)(((byte)(180)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.LocalSupplier_dgv.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.LocalSupplier_dgv.RowHeadersVisible = false;
            this.LocalSupplier_dgv.RowTemplate.Height = 21;
            this.LocalSupplier_dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.LocalSupplier_dgv.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.LocalSupplier_dgv_CellClick);
            this.LocalSupplier_dgv.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.LocalSupplier_dgv_CellDoubleClick);
            // 
            // colLocalSupplierId
            // 
            this.colLocalSupplierId.DataPropertyName = "LocalSupplierId";
            resources.ApplyResources(this.colLocalSupplierId, "colLocalSupplierId");
            this.colLocalSupplierId.Name = "colLocalSupplierId";
            this.colLocalSupplierId.ReadOnly = true;
            // 
            // colLocalSupplierCode
            // 
            this.colLocalSupplierCode.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colLocalSupplierCode.DataPropertyName = "LocalSupplierCode";
            resources.ApplyResources(this.colLocalSupplierCode, "colLocalSupplierCode");
            this.colLocalSupplierCode.Name = "colLocalSupplierCode";
            this.colLocalSupplierCode.ReadOnly = true;
            // 
            // colLocalSupplierName
            // 
            this.colLocalSupplierName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colLocalSupplierName.DataPropertyName = "LocalSupplierName";
            resources.ApplyResources(this.colLocalSupplierName, "colLocalSupplierName");
            this.colLocalSupplierName.Name = "colLocalSupplierName";
            this.colLocalSupplierName.ReadOnly = true;
            // 
            // LocalSupplierCode_txt
            // 
            this.LocalSupplierCode_txt.ControlId = null;
            resources.ApplyResources(this.LocalSupplierCode_txt, "LocalSupplierCode_txt");
            this.LocalSupplierCode_txt.InputType = Com.Nidec.Mes.Framework.TextBoxCommon.InputTypeList.All;
            this.LocalSupplierCode_txt.Name = "LocalSupplierCode_txt";
            // 
            // LocalSupplierName_lbl
            // 
            resources.ApplyResources(this.LocalSupplierName_lbl, "LocalSupplierName_lbl");
            this.LocalSupplierName_lbl.ControlId = null;
            this.LocalSupplierName_lbl.Name = "LocalSupplierName_lbl";
            // 
            // LocalSupplierName_txt
            // 
            this.LocalSupplierName_txt.ControlId = null;
            resources.ApplyResources(this.LocalSupplierName_txt, "LocalSupplierName_txt");
            this.LocalSupplierName_txt.InputType = Com.Nidec.Mes.Framework.TextBoxCommon.InputTypeList.All;
            this.LocalSupplierName_txt.Name = "LocalSupplierName_txt";
            // 
            // LocalSupplierCode_lbl
            // 
            resources.ApplyResources(this.LocalSupplierCode_lbl, "LocalSupplierCode_lbl");
            this.LocalSupplierCode_lbl.ControlId = null;
            this.LocalSupplierCode_lbl.Name = "LocalSupplierCode_lbl";
            // 
            // LocalSupplierForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ControlId = "bpmf014";
            this.Controls.Add(this.LocalSupplierCode_txt);
            this.Controls.Add(this.LocalSupplierName_lbl);
            this.Controls.Add(this.LocalSupplierName_txt);
            this.Controls.Add(this.LocalSupplierCode_lbl);
            this.Controls.Add(this.Clear_btn);
            this.Controls.Add(this.Exit_btn);
            this.Controls.Add(this.Delete_btn);
            this.Controls.Add(this.Update_btn);
            this.Controls.Add(this.Add_btn);
            this.Controls.Add(this.Search_btn);
            this.Controls.Add(this.LocalSupplier_dgv);
            this.Name = "LocalSupplierForm";
            this.TitleText = "FormCommon";
            this.Load += new System.EventHandler(this.LocalSupplierForm_Load);
            this.Controls.SetChildIndex(this.LocalSupplier_dgv, 0);
            this.Controls.SetChildIndex(this.Search_btn, 0);
            this.Controls.SetChildIndex(this.Add_btn, 0);
            this.Controls.SetChildIndex(this.Update_btn, 0);
            this.Controls.SetChildIndex(this.Delete_btn, 0);
            this.Controls.SetChildIndex(this.Exit_btn, 0);
            this.Controls.SetChildIndex(this.Clear_btn, 0);
            this.Controls.SetChildIndex(this.LocalSupplierCode_lbl, 0);
            this.Controls.SetChildIndex(this.LocalSupplierName_txt, 0);
            this.Controls.SetChildIndex(this.LocalSupplierName_lbl, 0);
            this.Controls.SetChildIndex(this.LocalSupplierCode_txt, 0);
            ((System.ComponentModel.ISupportInitialize)(this.LocalSupplier_dgv)).EndInit();
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
        internal Com.Nidec.Mes.Framework.DataGridViewCommon LocalSupplier_dgv;
        private Com.Nidec.Mes.Framework.TextBoxCommon LocalSupplierCode_txt;
        private Com.Nidec.Mes.Framework.LabelCommon LocalSupplierName_lbl;
        private Com.Nidec.Mes.Framework.TextBoxCommon LocalSupplierName_txt;
        private Com.Nidec.Mes.Framework.LabelCommon LocalSupplierCode_lbl;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLocalSupplierId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLocalSupplierCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLocalSupplierName;
    }
}