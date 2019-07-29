namespace Com.Nidec.Mes.Common.Basic.MachineMaintenance.Form.AccountWhForm.InventoryForm
{
    partial class InvertoryCheckForm
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
            this.InvertoryCheck_dgv = new Com.Nidec.Mes.Framework.DataGridViewCommon();
            this.colInvertoryEquipmentId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAssetCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAssetId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNowLocation = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBeforeLocation = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colRankNameBefore = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colRankNameNow = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.colRankNameNowTextBox = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAssetName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colInvertoryValue = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colUserAdd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDateTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.asset_code_lbl = new Com.Nidec.Mes.Framework.LabelCommon();
            this.groupBoxCommon1 = new Com.Nidec.Mes.Framework.GroupBoxCommon();
            this.update_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.Search_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.location_cbm = new Com.Nidec.Mes.Framework.ComboBoxCommon();
            this.select_location_lbl = new Com.Nidec.Mes.Framework.LabelCommon();
            this.Invertory_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.asset_Code_cmb = new Com.Nidec.Mes.Framework.ComboBoxCommon();
            this.InvertoryTimeCode_lbl = new Com.Nidec.Mes.Framework.LabelCommon();
            this.InvertoryTimeCode_cbm = new Com.Nidec.Mes.Framework.ComboBoxCommon();
            this.Inventory_Offline_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.linksave_txt = new Com.Nidec.Mes.Framework.TextBoxCommon();
            this.browser_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.groupBoxCommon2 = new Com.Nidec.Mes.Framework.GroupBoxCommon();
            this.groupBoxCommon3 = new Com.Nidec.Mes.Framework.GroupBoxCommon();
            this.ExportExcel_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.linkexport_txt = new Com.Nidec.Mes.Framework.TextBoxCommon();
            this.exportlink_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            ((System.ComponentModel.ISupportInitialize)(this.InvertoryCheck_dgv)).BeginInit();
            this.groupBoxCommon1.SuspendLayout();
            this.groupBoxCommon2.SuspendLayout();
            this.groupBoxCommon3.SuspendLayout();
            this.SuspendLayout();
            // 
            // InvertoryCheck_dgv
            // 
            this.InvertoryCheck_dgv.AllowUserToAddRows = false;
            this.InvertoryCheck_dgv.AllowUserToDeleteRows = false;
            this.InvertoryCheck_dgv.AllowUserToResizeRows = false;
            this.InvertoryCheck_dgv.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.InvertoryCheck_dgv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(232)))), ((int)(((byte)(180)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.InvertoryCheck_dgv.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.InvertoryCheck_dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.InvertoryCheck_dgv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colInvertoryEquipmentId,
            this.colAssetCode,
            this.colAssetId,
            this.colNowLocation,
            this.colBeforeLocation,
            this.colRankNameBefore,
            this.colRankNameNow,
            this.colRankNameNowTextBox,
            this.colAssetName,
            this.colInvertoryValue,
            this.colUserAdd,
            this.colDateTime});
            this.InvertoryCheck_dgv.ControlId = null;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.InvertoryCheck_dgv.DefaultCellStyle = dataGridViewCellStyle2;
            this.InvertoryCheck_dgv.EnableHeadersVisualStyles = false;
            this.InvertoryCheck_dgv.Location = new System.Drawing.Point(0, 249);
            this.InvertoryCheck_dgv.MultiSelect = false;
            this.InvertoryCheck_dgv.Name = "InvertoryCheck_dgv";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(232)))), ((int)(((byte)(180)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.InvertoryCheck_dgv.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.InvertoryCheck_dgv.RowTemplate.Height = 21;
            this.InvertoryCheck_dgv.Size = new System.Drawing.Size(1261, 393);
            this.InvertoryCheck_dgv.TabIndex = 19;
            // 
            // colInvertoryEquipmentId
            // 
            this.colInvertoryEquipmentId.DataPropertyName = "InvertoryEquipmentId";
            this.colInvertoryEquipmentId.HeaderText = "InvertoryEquipmentId";
            this.colInvertoryEquipmentId.Name = "colInvertoryEquipmentId";
            this.colInvertoryEquipmentId.Visible = false;
            this.colInvertoryEquipmentId.Width = 128;
            // 
            // colAssetCode
            // 
            this.colAssetCode.DataPropertyName = "AssetCode";
            this.colAssetCode.HeaderText = "Asset Code";
            this.colAssetCode.Name = "colAssetCode";
            this.colAssetCode.Width = 88;
            // 
            // colAssetId
            // 
            this.colAssetId.DataPropertyName = "AssetId";
            this.colAssetId.HeaderText = "AssetId";
            this.colAssetId.Name = "colAssetId";
            this.colAssetId.Visible = false;
            this.colAssetId.Width = 73;
            // 
            // colNowLocation
            // 
            this.colNowLocation.DataPropertyName = "NowLocation";
            this.colNowLocation.HeaderText = "Now Location";
            this.colNowLocation.Name = "colNowLocation";
            this.colNowLocation.Width = 98;
            // 
            // colBeforeLocation
            // 
            this.colBeforeLocation.DataPropertyName = "BeforeLocation";
            this.colBeforeLocation.HeaderText = "BeforeLocation";
            this.colBeforeLocation.Name = "colBeforeLocation";
            this.colBeforeLocation.Width = 115;
            // 
            // colRankNameBefore
            // 
            this.colRankNameBefore.DataPropertyName = "RankNameBefore";
            this.colRankNameBefore.HeaderText = "RankNameBefore";
            this.colRankNameBefore.Name = "colRankNameBefore";
            this.colRankNameBefore.Width = 131;
            // 
            // colRankNameNow
            // 
            this.colRankNameNow.HeaderText = "RankNameNow";
            this.colRankNameNow.Name = "colRankNameNow";
            this.colRankNameNow.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colRankNameNow.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.colRankNameNow.Width = 120;
            // 
            // colRankNameNowTextBox
            // 
            this.colRankNameNowTextBox.HeaderText = "Rank Name Now";
            this.colRankNameNowTextBox.Name = "colRankNameNowTextBox";
            this.colRankNameNowTextBox.Width = 115;
            // 
            // colAssetName
            // 
            this.colAssetName.DataPropertyName = "AssetName";
            this.colAssetName.HeaderText = "Asset Name";
            this.colAssetName.Name = "colAssetName";
            this.colAssetName.Width = 92;
            // 
            // colInvertoryValue
            // 
            this.colInvertoryValue.DataPropertyName = "InvertoryValue";
            this.colInvertoryValue.HeaderText = "Inventory Value";
            this.colInvertoryValue.Name = "colInvertoryValue";
            this.colInvertoryValue.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colInvertoryValue.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.colInvertoryValue.Width = 104;
            // 
            // colUserAdd
            // 
            this.colUserAdd.DataPropertyName = "RegistrationUserCode";
            this.colUserAdd.HeaderText = "User Add";
            this.colUserAdd.Name = "colUserAdd";
            this.colUserAdd.Width = 76;
            // 
            // colDateTime
            // 
            this.colDateTime.DataPropertyName = "RegistrationDateTime";
            this.colDateTime.HeaderText = "Date Time";
            this.colDateTime.Name = "colDateTime";
            this.colDateTime.Width = 82;
            // 
            // asset_code_lbl
            // 
            this.asset_code_lbl.AutoSize = true;
            this.asset_code_lbl.ControlId = null;
            this.asset_code_lbl.Font = new System.Drawing.Font("Arial", 9F);
            this.asset_code_lbl.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.asset_code_lbl.Location = new System.Drawing.Point(69, 25);
            this.asset_code_lbl.Name = "asset_code_lbl";
            this.asset_code_lbl.Size = new System.Drawing.Size(74, 15);
            this.asset_code_lbl.TabIndex = 73;
            this.asset_code_lbl.Text = "Asset Code:";
            // 
            // groupBoxCommon1
            // 
            this.groupBoxCommon1.ControlId = null;
            this.groupBoxCommon1.Controls.Add(this.update_btn);
            this.groupBoxCommon1.Controls.Add(this.Search_btn);
            this.groupBoxCommon1.Controls.Add(this.location_cbm);
            this.groupBoxCommon1.Controls.Add(this.select_location_lbl);
            this.groupBoxCommon1.Controls.Add(this.Invertory_btn);
            this.groupBoxCommon1.Controls.Add(this.asset_Code_cmb);
            this.groupBoxCommon1.Controls.Add(this.InvertoryTimeCode_lbl);
            this.groupBoxCommon1.Controls.Add(this.InvertoryTimeCode_cbm);
            this.groupBoxCommon1.Controls.Add(this.asset_code_lbl);
            this.groupBoxCommon1.Font = new System.Drawing.Font("Arial", 9F);
            this.groupBoxCommon1.Location = new System.Drawing.Point(12, 113);
            this.groupBoxCommon1.Name = "groupBoxCommon1";
            this.groupBoxCommon1.Size = new System.Drawing.Size(485, 130);
            this.groupBoxCommon1.TabIndex = 77;
            this.groupBoxCommon1.TabStop = false;
            this.groupBoxCommon1.Text = "Check";
            // 
            // update_btn
            // 
            this.update_btn.BackColor = System.Drawing.SystemColors.Control;
            this.update_btn.ControlId = null;
            this.update_btn.Font = new System.Drawing.Font("Arial", 9F);
            this.update_btn.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.update_btn.Location = new System.Drawing.Point(367, 95);
            this.update_btn.Name = "update_btn";
            this.update_btn.Size = new System.Drawing.Size(95, 32);
            this.update_btn.TabIndex = 81;
            this.update_btn.Text = "Update Rank";
            this.update_btn.UseVisualStyleBackColor = true;
            this.update_btn.Click += new System.EventHandler(this.update_btn_Click);
            // 
            // Search_btn
            // 
            this.Search_btn.BackColor = System.Drawing.SystemColors.Control;
            this.Search_btn.ControlId = null;
            this.Search_btn.Font = new System.Drawing.Font("Arial", 9F);
            this.Search_btn.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.Search_btn.Location = new System.Drawing.Point(367, 54);
            this.Search_btn.Name = "Search_btn";
            this.Search_btn.Size = new System.Drawing.Size(95, 32);
            this.Search_btn.TabIndex = 81;
            this.Search_btn.Text = "Search";
            this.Search_btn.UseVisualStyleBackColor = true;
            this.Search_btn.Click += new System.EventHandler(this.Search_btn_Click);
            // 
            // location_cbm
            // 
            this.location_cbm.ControlId = null;
            this.location_cbm.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.location_cbm.FormattingEnabled = true;
            this.location_cbm.Location = new System.Drawing.Point(149, 52);
            this.location_cbm.Name = "location_cbm";
            this.location_cbm.Size = new System.Drawing.Size(162, 23);
            this.location_cbm.TabIndex = 84;
            // 
            // select_location_lbl
            // 
            this.select_location_lbl.AutoSize = true;
            this.select_location_lbl.ControlId = null;
            this.select_location_lbl.Font = new System.Drawing.Font("Arial", 9F);
            this.select_location_lbl.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.select_location_lbl.Location = new System.Drawing.Point(60, 55);
            this.select_location_lbl.Name = "select_location_lbl";
            this.select_location_lbl.Size = new System.Drawing.Size(85, 15);
            this.select_location_lbl.TabIndex = 83;
            this.select_location_lbl.Text = "Now Location:";
            // 
            // Invertory_btn
            // 
            this.Invertory_btn.BackColor = System.Drawing.SystemColors.Control;
            this.Invertory_btn.ControlId = null;
            this.Invertory_btn.Font = new System.Drawing.Font("Arial", 9F);
            this.Invertory_btn.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.Invertory_btn.Location = new System.Drawing.Point(367, 13);
            this.Invertory_btn.Name = "Invertory_btn";
            this.Invertory_btn.Size = new System.Drawing.Size(95, 33);
            this.Invertory_btn.TabIndex = 16;
            this.Invertory_btn.Text = "Inventory";
            this.Invertory_btn.UseVisualStyleBackColor = true;
            this.Invertory_btn.Click += new System.EventHandler(this.Invertory_btn_Click);
            // 
            // asset_Code_cmb
            // 
            this.asset_Code_cmb.ControlId = null;
            this.asset_Code_cmb.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.asset_Code_cmb.FormattingEnabled = true;
            this.asset_Code_cmb.Location = new System.Drawing.Point(149, 20);
            this.asset_Code_cmb.Name = "asset_Code_cmb";
            this.asset_Code_cmb.Size = new System.Drawing.Size(162, 23);
            this.asset_Code_cmb.TabIndex = 82;
            // 
            // InvertoryTimeCode_lbl
            // 
            this.InvertoryTimeCode_lbl.AutoSize = true;
            this.InvertoryTimeCode_lbl.ControlId = null;
            this.InvertoryTimeCode_lbl.Font = new System.Drawing.Font("Arial", 9F);
            this.InvertoryTimeCode_lbl.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.InvertoryTimeCode_lbl.Location = new System.Drawing.Point(54, 90);
            this.InvertoryTimeCode_lbl.Name = "InvertoryTimeCode_lbl";
            this.InvertoryTimeCode_lbl.Size = new System.Drawing.Size(91, 15);
            this.InvertoryTimeCode_lbl.TabIndex = 81;
            this.InvertoryTimeCode_lbl.Text = "Inventory Code:";
            // 
            // InvertoryTimeCode_cbm
            // 
            this.InvertoryTimeCode_cbm.ControlId = null;
            this.InvertoryTimeCode_cbm.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.InvertoryTimeCode_cbm.FormattingEnabled = true;
            this.InvertoryTimeCode_cbm.Location = new System.Drawing.Point(149, 85);
            this.InvertoryTimeCode_cbm.Name = "InvertoryTimeCode_cbm";
            this.InvertoryTimeCode_cbm.Size = new System.Drawing.Size(162, 23);
            this.InvertoryTimeCode_cbm.TabIndex = 80;
            // 
            // Inventory_Offline_btn
            // 
            this.Inventory_Offline_btn.BackColor = System.Drawing.SystemColors.Control;
            this.Inventory_Offline_btn.ControlId = null;
            this.Inventory_Offline_btn.Font = new System.Drawing.Font("Arial", 9F);
            this.Inventory_Offline_btn.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.Inventory_Offline_btn.Location = new System.Drawing.Point(328, 19);
            this.Inventory_Offline_btn.Name = "Inventory_Offline_btn";
            this.Inventory_Offline_btn.Size = new System.Drawing.Size(91, 33);
            this.Inventory_Offline_btn.TabIndex = 78;
            this.Inventory_Offline_btn.Text = "Run Offline";
            this.Inventory_Offline_btn.UseVisualStyleBackColor = true;
            this.Inventory_Offline_btn.Click += new System.EventHandler(this.Inventory_Offline_btn_Click);
            // 
            // linksave_txt
            // 
            this.linksave_txt.ControlId = null;
            this.linksave_txt.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linksave_txt.InputType = Com.Nidec.Mes.Framework.TextBoxCommon.InputTypeList.All;
            this.linksave_txt.Location = new System.Drawing.Point(136, 25);
            this.linksave_txt.Name = "linksave_txt";
            this.linksave_txt.ReadOnly = true;
            this.linksave_txt.Size = new System.Drawing.Size(182, 21);
            this.linksave_txt.TabIndex = 80;
            // 
            // browser_btn
            // 
            this.browser_btn.BackColor = System.Drawing.SystemColors.Control;
            this.browser_btn.ControlId = null;
            this.browser_btn.Font = new System.Drawing.Font("Arial", 9F);
            this.browser_btn.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.browser_btn.Location = new System.Drawing.Point(6, 19);
            this.browser_btn.Name = "browser_btn";
            this.browser_btn.Size = new System.Drawing.Size(111, 33);
            this.browser_btn.TabIndex = 79;
            this.browser_btn.Text = "Browser  Import ";
            this.browser_btn.UseVisualStyleBackColor = false;
            this.browser_btn.Click += new System.EventHandler(this.browser_btn_Click);
            // 
            // groupBoxCommon2
            // 
            this.groupBoxCommon2.ControlId = null;
            this.groupBoxCommon2.Controls.Add(this.Inventory_Offline_btn);
            this.groupBoxCommon2.Controls.Add(this.linksave_txt);
            this.groupBoxCommon2.Controls.Add(this.browser_btn);
            this.groupBoxCommon2.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxCommon2.Location = new System.Drawing.Point(525, 113);
            this.groupBoxCommon2.Name = "groupBoxCommon2";
            this.groupBoxCommon2.Size = new System.Drawing.Size(425, 59);
            this.groupBoxCommon2.TabIndex = 81;
            this.groupBoxCommon2.TabStop = false;
            // 
            // groupBoxCommon3
            // 
            this.groupBoxCommon3.ControlId = null;
            this.groupBoxCommon3.Controls.Add(this.ExportExcel_btn);
            this.groupBoxCommon3.Controls.Add(this.linkexport_txt);
            this.groupBoxCommon3.Controls.Add(this.exportlink_btn);
            this.groupBoxCommon3.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxCommon3.Location = new System.Drawing.Point(525, 177);
            this.groupBoxCommon3.Name = "groupBoxCommon3";
            this.groupBoxCommon3.Size = new System.Drawing.Size(425, 66);
            this.groupBoxCommon3.TabIndex = 82;
            this.groupBoxCommon3.TabStop = false;
            // 
            // ExportExcel_btn
            // 
            this.ExportExcel_btn.BackColor = System.Drawing.SystemColors.Control;
            this.ExportExcel_btn.ControlId = null;
            this.ExportExcel_btn.Font = new System.Drawing.Font("Arial", 9F);
            this.ExportExcel_btn.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.ExportExcel_btn.Location = new System.Drawing.Point(327, 18);
            this.ExportExcel_btn.Name = "ExportExcel_btn";
            this.ExportExcel_btn.Size = new System.Drawing.Size(91, 32);
            this.ExportExcel_btn.TabIndex = 78;
            this.ExportExcel_btn.Text = "Export Excel";
            this.ExportExcel_btn.UseVisualStyleBackColor = true;
            this.ExportExcel_btn.Click += new System.EventHandler(this.ExportExcel_btn_Click);
            // 
            // linkexport_txt
            // 
            this.linkexport_txt.ControlId = null;
            this.linkexport_txt.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkexport_txt.InputType = Com.Nidec.Mes.Framework.TextBoxCommon.InputTypeList.All;
            this.linkexport_txt.Location = new System.Drawing.Point(135, 23);
            this.linkexport_txt.Name = "linkexport_txt";
            this.linkexport_txt.Size = new System.Drawing.Size(182, 21);
            this.linkexport_txt.TabIndex = 80;
            // 
            // exportlink_btn
            // 
            this.exportlink_btn.BackColor = System.Drawing.SystemColors.Control;
            this.exportlink_btn.ControlId = null;
            this.exportlink_btn.Font = new System.Drawing.Font("Arial", 9F);
            this.exportlink_btn.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.exportlink_btn.Location = new System.Drawing.Point(6, 17);
            this.exportlink_btn.Name = "exportlink_btn";
            this.exportlink_btn.Size = new System.Drawing.Size(111, 33);
            this.exportlink_btn.TabIndex = 79;
            this.exportlink_btn.Text = "Browser Export";
            this.exportlink_btn.UseVisualStyleBackColor = false;
            this.exportlink_btn.Click += new System.EventHandler(this.exportlink_btn_Click);
            // 
            // InvertoryCheckForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(1261, 642);
            this.Controls.Add(this.groupBoxCommon3);
            this.Controls.Add(this.groupBoxCommon2);
            this.Controls.Add(this.groupBoxCommon1);
            this.Controls.Add(this.InvertoryCheck_dgv);
            this.Name = "InvertoryCheckForm";
            this.Text = "Equipment Inventory";
            this.TitleText = "Equipment Inventory";
            this.Load += new System.EventHandler(this.InvertoryCheckForm_Load);
            this.Controls.SetChildIndex(this.InvertoryCheck_dgv, 0);
            this.Controls.SetChildIndex(this.groupBoxCommon1, 0);
            this.Controls.SetChildIndex(this.groupBoxCommon2, 0);
            this.Controls.SetChildIndex(this.groupBoxCommon3, 0);
            ((System.ComponentModel.ISupportInitialize)(this.InvertoryCheck_dgv)).EndInit();
            this.groupBoxCommon1.ResumeLayout(false);
            this.groupBoxCommon1.PerformLayout();
            this.groupBoxCommon2.ResumeLayout(false);
            this.groupBoxCommon2.PerformLayout();
            this.groupBoxCommon3.ResumeLayout(false);
            this.groupBoxCommon3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        internal Framework.DataGridViewCommon InvertoryCheck_dgv;
        private Framework.LabelCommon asset_code_lbl;
        private Framework.GroupBoxCommon groupBoxCommon1;
        private Framework.ComboBoxCommon InvertoryTimeCode_cbm;
        private Framework.LabelCommon InvertoryTimeCode_lbl;
        private Framework.ComboBoxCommon asset_Code_cmb;
        private Framework.ButtonCommon Invertory_btn;
        private Framework.ButtonCommon Inventory_Offline_btn;
        private Framework.TextBoxCommon linksave_txt;
        private Framework.ButtonCommon browser_btn;
        private Framework.GroupBoxCommon groupBoxCommon2;
        private Framework.ComboBoxCommon location_cbm;
        private Framework.LabelCommon select_location_lbl;
        private Framework.ButtonCommon Search_btn;
        private Framework.GroupBoxCommon groupBoxCommon3;
        private Framework.ButtonCommon ExportExcel_btn;
        private Framework.TextBoxCommon linkexport_txt;
        private Framework.ButtonCommon exportlink_btn;
        private Framework.ButtonCommon update_btn;
        private System.Windows.Forms.DataGridViewTextBoxColumn colInvertoryEquipmentId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAssetCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAssetId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNowLocation;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBeforeLocation;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRankNameBefore;
        private System.Windows.Forms.DataGridViewComboBoxColumn colRankNameNow;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRankNameNowTextBox;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAssetName;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colInvertoryValue;
        private System.Windows.Forms.DataGridViewTextBoxColumn colUserAdd;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDateTime;
    }
}
