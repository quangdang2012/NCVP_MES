namespace Com.Nidec.Mes.Common.Basic.MachineMaintenance.Form.AccountWhForm.Asset
{
    partial class AssetForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.Clear_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.Exit_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.Delete_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.Update_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.Add_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.Search_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.AssetName_txt = new Com.Nidec.Mes.Framework.TextBoxCommon();
            this.AssetName_lbl = new Com.Nidec.Mes.Framework.LabelCommon();
            this.AssetCode_txt = new Com.Nidec.Mes.Framework.TextBoxCommon();
            this.AssetCode_lbl = new Com.Nidec.Mes.Framework.LabelCommon();
            this.AssetDetails_dgv = new Com.Nidec.Mes.Framework.DataGridViewCommon();
            this.groupBoxCommon1 = new Com.Nidec.Mes.Framework.GroupBoxCommon();
            this.colAssetId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAssetCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAssetNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAssetName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAssetModel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colassetserial = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLife = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAsquiscost = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAcquistionDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colassetinvoice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_asset_po = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAssetSupplier = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAssetType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLabelStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.AssetDetails_dgv)).BeginInit();
            this.groupBoxCommon1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Clear_btn
            // 
            this.Clear_btn.BackColor = System.Drawing.SystemColors.Control;
            this.Clear_btn.ControlId = null;
            this.Clear_btn.Font = new System.Drawing.Font("Arial", 9F);
            this.Clear_btn.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.Clear_btn.Location = new System.Drawing.Point(534, 20);
            this.Clear_btn.Name = "Clear_btn";
            this.Clear_btn.Size = new System.Drawing.Size(80, 33);
            this.Clear_btn.TabIndex = 18;
            this.Clear_btn.Text = "Clear";
            this.Clear_btn.UseVisualStyleBackColor = true;
            this.Clear_btn.Click += new System.EventHandler(this.Clear_btn_Click);
            // 
            // Exit_btn
            // 
            this.Exit_btn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Exit_btn.BackColor = System.Drawing.SystemColors.Control;
            this.Exit_btn.ControlId = null;
            this.Exit_btn.Font = new System.Drawing.Font("Arial", 9F);
            this.Exit_btn.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.Exit_btn.Location = new System.Drawing.Point(818, 20);
            this.Exit_btn.Name = "Exit_btn";
            this.Exit_btn.Size = new System.Drawing.Size(80, 33);
            this.Exit_btn.TabIndex = 21;
            this.Exit_btn.Text = "Exit";
            this.Exit_btn.UseVisualStyleBackColor = true;
            this.Exit_btn.Click += new System.EventHandler(this.Exit_btn_Click);
            // 
            // Delete_btn
            // 
            this.Delete_btn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Delete_btn.BackColor = System.Drawing.SystemColors.Control;
            this.Delete_btn.ControlId = null;
            this.Delete_btn.Font = new System.Drawing.Font("Arial", 9F);
            this.Delete_btn.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.Delete_btn.Location = new System.Drawing.Point(724, 20);
            this.Delete_btn.Name = "Delete_btn";
            this.Delete_btn.Size = new System.Drawing.Size(80, 33);
            this.Delete_btn.TabIndex = 20;
            this.Delete_btn.Text = "Delete";
            this.Delete_btn.UseVisualStyleBackColor = true;
            this.Delete_btn.Click += new System.EventHandler(this.Delete_btn_Click);
            // 
            // Update_btn
            // 
            this.Update_btn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Update_btn.BackColor = System.Drawing.SystemColors.Control;
            this.Update_btn.ControlId = null;
            this.Update_btn.Font = new System.Drawing.Font("Arial", 9F);
            this.Update_btn.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.Update_btn.Location = new System.Drawing.Point(630, 20);
            this.Update_btn.Name = "Update_btn";
            this.Update_btn.Size = new System.Drawing.Size(80, 33);
            this.Update_btn.TabIndex = 19;
            this.Update_btn.Text = "Update";
            this.Update_btn.UseVisualStyleBackColor = true;
            this.Update_btn.Click += new System.EventHandler(this.Update_btn_Click);
            // 
            // Add_btn
            // 
            this.Add_btn.BackColor = System.Drawing.SystemColors.Control;
            this.Add_btn.ControlId = null;
            this.Add_btn.Font = new System.Drawing.Font("Arial", 9F);
            this.Add_btn.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.Add_btn.Location = new System.Drawing.Point(440, 20);
            this.Add_btn.Name = "Add_btn";
            this.Add_btn.Size = new System.Drawing.Size(80, 33);
            this.Add_btn.TabIndex = 17;
            this.Add_btn.Text = "Add";
            this.Add_btn.UseVisualStyleBackColor = true;
            this.Add_btn.Click += new System.EventHandler(this.Add_btn_Click);
            // 
            // Search_btn
            // 
            this.Search_btn.BackColor = System.Drawing.SystemColors.Control;
            this.Search_btn.ControlId = null;
            this.Search_btn.Font = new System.Drawing.Font("Arial", 9F);
            this.Search_btn.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.Search_btn.Location = new System.Drawing.Point(346, 20);
            this.Search_btn.Name = "Search_btn";
            this.Search_btn.Size = new System.Drawing.Size(80, 33);
            this.Search_btn.TabIndex = 16;
            this.Search_btn.Text = "Search";
            this.Search_btn.UseVisualStyleBackColor = true;
            this.Search_btn.Click += new System.EventHandler(this.Search_btn_Click);
            // 
            // AssetName_txt
            // 
            this.AssetName_txt.ControlId = null;
            this.AssetName_txt.Font = new System.Drawing.Font("Arial", 9F);
            this.AssetName_txt.InputType = Com.Nidec.Mes.Framework.TextBoxCommon.InputTypeList.All;
            this.AssetName_txt.Location = new System.Drawing.Point(98, 42);
            this.AssetName_txt.MaxLength = 32;
            this.AssetName_txt.Name = "AssetName_txt";
            this.AssetName_txt.Size = new System.Drawing.Size(187, 21);
            this.AssetName_txt.TabIndex = 15;
            // 
            // AssetName_lbl
            // 
            this.AssetName_lbl.AutoSize = true;
            this.AssetName_lbl.ControlId = null;
            this.AssetName_lbl.Font = new System.Drawing.Font("Arial", 9F);
            this.AssetName_lbl.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.AssetName_lbl.Location = new System.Drawing.Point(12, 45);
            this.AssetName_lbl.Name = "AssetName_lbl";
            this.AssetName_lbl.Size = new System.Drawing.Size(75, 15);
            this.AssetName_lbl.TabIndex = 14;
            this.AssetName_lbl.Text = "Asset Name";
            // 
            // AssetCode_txt
            // 
            this.AssetCode_txt.ControlId = null;
            this.AssetCode_txt.Font = new System.Drawing.Font("Arial", 9F);
            this.AssetCode_txt.InputType = Com.Nidec.Mes.Framework.TextBoxCommon.InputTypeList.All;
            this.AssetCode_txt.Location = new System.Drawing.Point(98, 12);
            this.AssetCode_txt.MaxLength = 32;
            this.AssetCode_txt.Name = "AssetCode_txt";
            this.AssetCode_txt.Size = new System.Drawing.Size(187, 21);
            this.AssetCode_txt.TabIndex = 13;
            // 
            // AssetCode_lbl
            // 
            this.AssetCode_lbl.AutoSize = true;
            this.AssetCode_lbl.ControlId = null;
            this.AssetCode_lbl.Font = new System.Drawing.Font("Arial", 9F);
            this.AssetCode_lbl.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.AssetCode_lbl.Location = new System.Drawing.Point(12, 15);
            this.AssetCode_lbl.Name = "AssetCode_lbl";
            this.AssetCode_lbl.Size = new System.Drawing.Size(71, 15);
            this.AssetCode_lbl.TabIndex = 12;
            this.AssetCode_lbl.Text = "Asset Code";
            // 
            // AssetDetails_dgv
            // 
            this.AssetDetails_dgv.AllowUserToAddRows = false;
            this.AssetDetails_dgv.AllowUserToDeleteRows = false;
            this.AssetDetails_dgv.AllowUserToOrderColumns = true;
            this.AssetDetails_dgv.AllowUserToResizeRows = false;
            this.AssetDetails_dgv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(232)))), ((int)(((byte)(180)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.AssetDetails_dgv.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.AssetDetails_dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.AssetDetails_dgv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colAssetId,
            this.colAssetCode,
            this.colAssetNo,
            this.colAssetName,
            this.colAssetModel,
            this.colassetserial,
            this.colLife,
            this.colAsquiscost,
            this.colAcquistionDate,
            this.colassetinvoice,
            this.col_asset_po,
            this.colAssetSupplier,
            this.colAssetType,
            this.colLabelStatus});
            this.AssetDetails_dgv.ControlId = null;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.AssetDetails_dgv.DefaultCellStyle = dataGridViewCellStyle2;
            this.AssetDetails_dgv.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.AssetDetails_dgv.EnableHeadersVisualStyles = false;
            this.AssetDetails_dgv.Location = new System.Drawing.Point(0, 191);
            this.AssetDetails_dgv.MultiSelect = false;
            this.AssetDetails_dgv.Name = "AssetDetails_dgv";
            this.AssetDetails_dgv.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(232)))), ((int)(((byte)(180)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.AssetDetails_dgv.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.AssetDetails_dgv.RowHeadersVisible = false;
            this.AssetDetails_dgv.RowTemplate.Height = 21;
            this.AssetDetails_dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.AssetDetails_dgv.Size = new System.Drawing.Size(1063, 389);
            this.AssetDetails_dgv.TabIndex = 22;
            this.AssetDetails_dgv.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.AssetDetails_dgv_CellClick);
            this.AssetDetails_dgv.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.AssetDetails_dgv_CellDoubleClick);
            // 
            // groupBoxCommon1
            // 
            this.groupBoxCommon1.ControlId = null;
            this.groupBoxCommon1.Controls.Add(this.Exit_btn);
            this.groupBoxCommon1.Controls.Add(this.Search_btn);
            this.groupBoxCommon1.Controls.Add(this.AssetName_txt);
            this.groupBoxCommon1.Controls.Add(this.Clear_btn);
            this.groupBoxCommon1.Controls.Add(this.AssetName_lbl);
            this.groupBoxCommon1.Controls.Add(this.Add_btn);
            this.groupBoxCommon1.Controls.Add(this.AssetCode_txt);
            this.groupBoxCommon1.Controls.Add(this.AssetCode_lbl);
            this.groupBoxCommon1.Controls.Add(this.Update_btn);
            this.groupBoxCommon1.Controls.Add(this.Delete_btn);
            this.groupBoxCommon1.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxCommon1.Location = new System.Drawing.Point(12, 113);
            this.groupBoxCommon1.Name = "groupBoxCommon1";
            this.groupBoxCommon1.Size = new System.Drawing.Size(963, 72);
            this.groupBoxCommon1.TabIndex = 23;
            this.groupBoxCommon1.TabStop = false;
            // 
            // colAssetId
            // 
            this.colAssetId.DataPropertyName = "AssetId";
            this.colAssetId.HeaderText = "Asset Id";
            this.colAssetId.Name = "colAssetId";
            this.colAssetId.ReadOnly = true;
            this.colAssetId.Visible = false;
            this.colAssetId.Width = 57;
            // 
            // colAssetCode
            // 
            this.colAssetCode.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colAssetCode.DataPropertyName = "AssetCode";
            this.colAssetCode.HeaderText = "Asset Code";
            this.colAssetCode.Name = "colAssetCode";
            this.colAssetCode.ReadOnly = true;
            // 
            // colAssetNo
            // 
            this.colAssetNo.DataPropertyName = "AssetNo";
            this.colAssetNo.HeaderText = "Asset No";
            this.colAssetNo.Name = "colAssetNo";
            this.colAssetNo.ReadOnly = true;
            this.colAssetNo.Width = 82;
            // 
            // colAssetName
            // 
            this.colAssetName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.colAssetName.DataPropertyName = "AssetName";
            this.colAssetName.HeaderText = "Asset Name";
            this.colAssetName.Name = "colAssetName";
            this.colAssetName.ReadOnly = true;
            // 
            // colAssetModel
            // 
            this.colAssetModel.DataPropertyName = "AssetModel";
            this.colAssetModel.HeaderText = "Asset Model";
            this.colAssetModel.Name = "colAssetModel";
            this.colAssetModel.ReadOnly = true;
            this.colAssetModel.Width = 99;
            // 
            // colassetserial
            // 
            this.colassetserial.DataPropertyName = "AssetSerial";
            this.colassetserial.HeaderText = "Asset Serial";
            this.colassetserial.Name = "colassetserial";
            this.colassetserial.ReadOnly = true;
            this.colassetserial.Width = 98;
            // 
            // colLife
            // 
            this.colLife.DataPropertyName = "AssetLife";
            this.colLife.HeaderText = "Life";
            this.colLife.Name = "colLife";
            this.colLife.ReadOnly = true;
            this.colLife.Width = 52;
            // 
            // colAsquiscost
            // 
            this.colAsquiscost.DataPropertyName = "AcquistionCost";
            this.colAsquiscost.HeaderText = "Acquisition Cost";
            this.colAsquiscost.Name = "colAsquiscost";
            this.colAsquiscost.ReadOnly = true;
            this.colAsquiscost.Width = 111;
            // 
            // colAcquistionDate
            // 
            this.colAcquistionDate.DataPropertyName = "AcquistionDate";
            this.colAcquistionDate.HeaderText = "Acquisition Date";
            this.colAcquistionDate.Name = "colAcquistionDate";
            this.colAcquistionDate.ReadOnly = true;
            this.colAcquistionDate.Width = 111;
            // 
            // colassetinvoice
            // 
            this.colassetinvoice.DataPropertyName = "AssetInvoice";
            this.colassetinvoice.HeaderText = "Invoice";
            this.colassetinvoice.Name = "colassetinvoice";
            this.colassetinvoice.ReadOnly = true;
            this.colassetinvoice.Width = 70;
            // 
            // col_asset_po
            // 
            this.col_asset_po.DataPropertyName = "AssetPO";
            this.col_asset_po.HeaderText = "P/O";
            this.col_asset_po.Name = "col_asset_po";
            this.col_asset_po.ReadOnly = true;
            this.col_asset_po.Width = 52;
            // 
            // colAssetSupplier
            // 
            this.colAssetSupplier.DataPropertyName = "AssetSuppiler";
            this.colAssetSupplier.HeaderText = "Asset Supplier";
            this.colAssetSupplier.Name = "colAssetSupplier";
            this.colAssetSupplier.ReadOnly = true;
            this.colAssetSupplier.Width = 103;
            // 
            // colAssetType
            // 
            this.colAssetType.DataPropertyName = "AssetType";
            this.colAssetType.HeaderText = "Asset Type";
            this.colAssetType.Name = "colAssetType";
            this.colAssetType.ReadOnly = true;
            this.colAssetType.Width = 85;
            // 
            // colLabelStatus
            // 
            this.colLabelStatus.DataPropertyName = "LabelStatus";
            this.colLabelStatus.HeaderText = "Label Status";
            this.colLabelStatus.Name = "colLabelStatus";
            this.colLabelStatus.ReadOnly = true;
            this.colLabelStatus.Width = 93;
            // 
            // AssetForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(1063, 580);
            this.Controls.Add(this.groupBoxCommon1);
            this.Controls.Add(this.AssetDetails_dgv);
            this.Name = "AssetForm";
            this.Text = "Asset Master";
            this.TitleText = "FormCommon";
            this.Load += new System.EventHandler(this.AssetForm_Load);
            this.Controls.SetChildIndex(this.AssetDetails_dgv, 0);
            this.Controls.SetChildIndex(this.groupBoxCommon1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.AssetDetails_dgv)).EndInit();
            this.groupBoxCommon1.ResumeLayout(false);
            this.groupBoxCommon1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Framework.ButtonCommon Clear_btn;
        private Framework.ButtonCommon Exit_btn;
        private Framework.ButtonCommon Delete_btn;
        private Framework.ButtonCommon Update_btn;
        private Framework.ButtonCommon Add_btn;
        private Framework.ButtonCommon Search_btn;
        private Framework.TextBoxCommon AssetName_txt;
        private Framework.LabelCommon AssetName_lbl;
        private Framework.TextBoxCommon AssetCode_txt;
        private Framework.LabelCommon AssetCode_lbl;
        internal Framework.DataGridViewCommon AssetDetails_dgv;
        private Framework.GroupBoxCommon groupBoxCommon1;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAssetId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAssetCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAssetNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAssetName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAssetModel;
        private System.Windows.Forms.DataGridViewTextBoxColumn colassetserial;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLife;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAsquiscost;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAcquistionDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colassetinvoice;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_asset_po;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAssetSupplier;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAssetType;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLabelStatus;
    }
}
