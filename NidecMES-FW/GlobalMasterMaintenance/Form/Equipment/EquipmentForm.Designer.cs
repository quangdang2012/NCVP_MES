namespace Com.Nidec.Mes.GlobalMasterMaintenance
{
    partial class EquipmentForm: FormCommonMaster
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EquipmentForm));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.EquipmentData_dgv = new Com.Nidec.Mes.Framework.DataGridViewCommon();
            this.colEquipmentId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEquipmentCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEquipmentName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colInstrationDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAssetNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colManufacturer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colModelCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colModelName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Clear_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.Add_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.Search_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.Exit_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.Delete_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.Update_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.ModelName_txt = new Com.Nidec.Mes.Framework.TextBoxCommon();
            this.ModelName_lbl = new Com.Nidec.Mes.Framework.LabelCommon();
            this.Manufacturer_txt = new Com.Nidec.Mes.Framework.TextBoxCommon();
            this.ModelCode_lbl = new Com.Nidec.Mes.Framework.LabelCommon();
            this.ModelCode_txt = new Com.Nidec.Mes.Framework.TextBoxCommon();
            this.Manufacturer_lbl = new Com.Nidec.Mes.Framework.LabelCommon();
            this.AssertNo_lbl = new Com.Nidec.Mes.Framework.LabelCommon();
            this.AssertNo_txt = new Com.Nidec.Mes.Framework.TextBoxCommon();
            this.InstrationDate_lbl = new Com.Nidec.Mes.Framework.LabelCommon();
            this.EquipmentCode_txt = new Com.Nidec.Mes.Framework.TextBoxCommon();
            this.EquipmentName_lbl = new Com.Nidec.Mes.Framework.LabelCommon();
            this.EquipmentName_txt = new Com.Nidec.Mes.Framework.TextBoxCommon();
            this.EquipmentCode_lbl = new Com.Nidec.Mes.Framework.LabelCommon();
            this.InstrationDate_dtp = new Com.Nidec.Mes.Framework.DateTimePickerCommon();
            ((System.ComponentModel.ISupportInitialize)(this.EquipmentData_dgv)).BeginInit();
            this.SuspendLayout();
            // 
            // EquipmentData_dgv
            // 
            this.EquipmentData_dgv.AllowUserToAddRows = false;
            this.EquipmentData_dgv.AllowUserToDeleteRows = false;
            this.EquipmentData_dgv.AllowUserToOrderColumns = true;
            this.EquipmentData_dgv.AllowUserToResizeRows = false;
            resources.ApplyResources(this.EquipmentData_dgv, "EquipmentData_dgv");
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(232)))), ((int)(((byte)(180)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.EquipmentData_dgv.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.EquipmentData_dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.EquipmentData_dgv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colEquipmentId,
            this.colEquipmentCode,
            this.colEquipmentName,
            this.colInstrationDate,
            this.colAssetNo,
            this.colManufacturer,
            this.colModelCode,
            this.colModelName});
            this.EquipmentData_dgv.ControlId = null;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.EquipmentData_dgv.DefaultCellStyle = dataGridViewCellStyle3;
            this.EquipmentData_dgv.EnableHeadersVisualStyles = false;
            this.EquipmentData_dgv.MultiSelect = false;
            this.EquipmentData_dgv.Name = "EquipmentData_dgv";
            this.EquipmentData_dgv.ReadOnly = true;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(232)))), ((int)(((byte)(180)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.EquipmentData_dgv.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.EquipmentData_dgv.RowHeadersVisible = false;
            this.EquipmentData_dgv.RowTemplate.Height = 21;
            this.EquipmentData_dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.EquipmentData_dgv.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.EquipmentData_dgv_CellClick);
            this.EquipmentData_dgv.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.EquipmentData_dgv_CellDoubleClick);
            // 
            // colEquipmentId
            // 
            this.colEquipmentId.DataPropertyName = "EquipmentId";
            resources.ApplyResources(this.colEquipmentId, "colEquipmentId");
            this.colEquipmentId.Name = "colEquipmentId";
            this.colEquipmentId.ReadOnly = true;
            // 
            // colEquipmentCode
            // 
            this.colEquipmentCode.DataPropertyName = "EquipmentCode";
            resources.ApplyResources(this.colEquipmentCode, "colEquipmentCode");
            this.colEquipmentCode.Name = "colEquipmentCode";
            this.colEquipmentCode.ReadOnly = true;
            // 
            // colEquipmentName
            // 
            this.colEquipmentName.DataPropertyName = "EquipmentName";
            resources.ApplyResources(this.colEquipmentName, "colEquipmentName");
            this.colEquipmentName.Name = "colEquipmentName";
            this.colEquipmentName.ReadOnly = true;
            // 
            // colInstrationDate
            // 
            this.colInstrationDate.DataPropertyName = "InstrationDate";
            dataGridViewCellStyle2.Format = "yyyy-MM-dd";
            dataGridViewCellStyle2.NullValue = null;
            this.colInstrationDate.DefaultCellStyle = dataGridViewCellStyle2;
            resources.ApplyResources(this.colInstrationDate, "colInstrationDate");
            this.colInstrationDate.Name = "colInstrationDate";
            this.colInstrationDate.ReadOnly = true;
            // 
            // colAssetNo
            // 
            this.colAssetNo.DataPropertyName = "AssetNo";
            resources.ApplyResources(this.colAssetNo, "colAssetNo");
            this.colAssetNo.Name = "colAssetNo";
            this.colAssetNo.ReadOnly = true;
            // 
            // colManufacturer
            // 
            this.colManufacturer.DataPropertyName = "Manufacturer";
            resources.ApplyResources(this.colManufacturer, "colManufacturer");
            this.colManufacturer.Name = "colManufacturer";
            this.colManufacturer.ReadOnly = true;
            // 
            // colModelCode
            // 
            this.colModelCode.DataPropertyName = "ModelCode";
            resources.ApplyResources(this.colModelCode, "colModelCode");
            this.colModelCode.Name = "colModelCode";
            this.colModelCode.ReadOnly = true;
            // 
            // colModelName
            // 
            this.colModelName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colModelName.DataPropertyName = "ModelName";
            resources.ApplyResources(this.colModelName, "colModelName");
            this.colModelName.Name = "colModelName";
            this.colModelName.ReadOnly = true;
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
            // ModelName_txt
            // 
            this.ModelName_txt.ControlId = null;
            resources.ApplyResources(this.ModelName_txt, "ModelName_txt");
            this.ModelName_txt.InputType = Com.Nidec.Mes.Framework.TextBoxCommon.InputTypeList.All;
            this.ModelName_txt.Name = "ModelName_txt";
            // 
            // ModelName_lbl
            // 
            resources.ApplyResources(this.ModelName_lbl, "ModelName_lbl");
            this.ModelName_lbl.ControlId = null;
            this.ModelName_lbl.Name = "ModelName_lbl";
            // 
            // Manufacturer_txt
            // 
            this.Manufacturer_txt.ControlId = null;
            resources.ApplyResources(this.Manufacturer_txt, "Manufacturer_txt");
            this.Manufacturer_txt.InputType = Com.Nidec.Mes.Framework.TextBoxCommon.InputTypeList.All;
            this.Manufacturer_txt.Name = "Manufacturer_txt";
            // 
            // ModelCode_lbl
            // 
            resources.ApplyResources(this.ModelCode_lbl, "ModelCode_lbl");
            this.ModelCode_lbl.ControlId = null;
            this.ModelCode_lbl.Name = "ModelCode_lbl";
            // 
            // ModelCode_txt
            // 
            this.ModelCode_txt.ControlId = null;
            resources.ApplyResources(this.ModelCode_txt, "ModelCode_txt");
            this.ModelCode_txt.InputType = Com.Nidec.Mes.Framework.TextBoxCommon.InputTypeList.All;
            this.ModelCode_txt.Name = "ModelCode_txt";
            // 
            // Manufacturer_lbl
            // 
            resources.ApplyResources(this.Manufacturer_lbl, "Manufacturer_lbl");
            this.Manufacturer_lbl.ControlId = null;
            this.Manufacturer_lbl.Name = "Manufacturer_lbl";
            // 
            // AssertNo_lbl
            // 
            resources.ApplyResources(this.AssertNo_lbl, "AssertNo_lbl");
            this.AssertNo_lbl.ControlId = null;
            this.AssertNo_lbl.Name = "AssertNo_lbl";
            // 
            // AssertNo_txt
            // 
            this.AssertNo_txt.ControlId = null;
            resources.ApplyResources(this.AssertNo_txt, "AssertNo_txt");
            this.AssertNo_txt.InputType = Com.Nidec.Mes.Framework.TextBoxCommon.InputTypeList.All;
            this.AssertNo_txt.Name = "AssertNo_txt";
            // 
            // InstrationDate_lbl
            // 
            resources.ApplyResources(this.InstrationDate_lbl, "InstrationDate_lbl");
            this.InstrationDate_lbl.ControlId = null;
            this.InstrationDate_lbl.Name = "InstrationDate_lbl";
            // 
            // EquipmentCode_txt
            // 
            this.EquipmentCode_txt.ControlId = null;
            resources.ApplyResources(this.EquipmentCode_txt, "EquipmentCode_txt");
            this.EquipmentCode_txt.InputType = Com.Nidec.Mes.Framework.TextBoxCommon.InputTypeList.All;
            this.EquipmentCode_txt.Name = "EquipmentCode_txt";
            // 
            // EquipmentName_lbl
            // 
            resources.ApplyResources(this.EquipmentName_lbl, "EquipmentName_lbl");
            this.EquipmentName_lbl.ControlId = null;
            this.EquipmentName_lbl.Name = "EquipmentName_lbl";
            // 
            // EquipmentName_txt
            // 
            this.EquipmentName_txt.ControlId = null;
            resources.ApplyResources(this.EquipmentName_txt, "EquipmentName_txt");
            this.EquipmentName_txt.InputType = Com.Nidec.Mes.Framework.TextBoxCommon.InputTypeList.All;
            this.EquipmentName_txt.Name = "EquipmentName_txt";
            // 
            // EquipmentCode_lbl
            // 
            resources.ApplyResources(this.EquipmentCode_lbl, "EquipmentCode_lbl");
            this.EquipmentCode_lbl.ControlId = null;
            this.EquipmentCode_lbl.Name = "EquipmentCode_lbl";
            // 
            // InstrationDate_dtp
            // 
            this.InstrationDate_dtp.BackColor = System.Drawing.SystemColors.Control;
            this.InstrationDate_dtp.ControlId = null;
            this.InstrationDate_dtp.DisplayFormat = Com.Nidec.Mes.Framework.DateTimePickerCommon.DisplayFormatList.ShortDatePattern;
            resources.ApplyResources(this.InstrationDate_dtp, "InstrationDate_dtp");
            this.InstrationDate_dtp.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.InstrationDate_dtp.Name = "InstrationDate_dtp";
            this.InstrationDate_dtp.ValueChanged += new System.EventHandler(this.InstrationDate_dtp_ValueChanged);
            // 
            // EquipmentForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ControlId = "bpmf007";
            this.Controls.Add(this.InstrationDate_dtp);
            this.Controls.Add(this.ModelName_txt);
            this.Controls.Add(this.ModelName_lbl);
            this.Controls.Add(this.Manufacturer_txt);
            this.Controls.Add(this.ModelCode_lbl);
            this.Controls.Add(this.ModelCode_txt);
            this.Controls.Add(this.Manufacturer_lbl);
            this.Controls.Add(this.AssertNo_lbl);
            this.Controls.Add(this.AssertNo_txt);
            this.Controls.Add(this.InstrationDate_lbl);
            this.Controls.Add(this.EquipmentCode_txt);
            this.Controls.Add(this.EquipmentName_lbl);
            this.Controls.Add(this.EquipmentName_txt);
            this.Controls.Add(this.EquipmentCode_lbl);
            this.Controls.Add(this.Exit_btn);
            this.Controls.Add(this.Delete_btn);
            this.Controls.Add(this.Update_btn);
            this.Controls.Add(this.Clear_btn);
            this.Controls.Add(this.Add_btn);
            this.Controls.Add(this.Search_btn);
            this.Controls.Add(this.EquipmentData_dgv);
            this.Name = "EquipmentForm";
            this.TitleText = "FormCommon";
            this.Load += new System.EventHandler(this.EquipmentForm_Load);
            this.Controls.SetChildIndex(this.EquipmentData_dgv, 0);
            this.Controls.SetChildIndex(this.Search_btn, 0);
            this.Controls.SetChildIndex(this.Add_btn, 0);
            this.Controls.SetChildIndex(this.Clear_btn, 0);
            this.Controls.SetChildIndex(this.Update_btn, 0);
            this.Controls.SetChildIndex(this.Delete_btn, 0);
            this.Controls.SetChildIndex(this.Exit_btn, 0);
            this.Controls.SetChildIndex(this.EquipmentCode_lbl, 0);
            this.Controls.SetChildIndex(this.EquipmentName_txt, 0);
            this.Controls.SetChildIndex(this.EquipmentName_lbl, 0);
            this.Controls.SetChildIndex(this.EquipmentCode_txt, 0);
            this.Controls.SetChildIndex(this.InstrationDate_lbl, 0);
            this.Controls.SetChildIndex(this.AssertNo_txt, 0);
            this.Controls.SetChildIndex(this.AssertNo_lbl, 0);
            this.Controls.SetChildIndex(this.Manufacturer_lbl, 0);
            this.Controls.SetChildIndex(this.ModelCode_txt, 0);
            this.Controls.SetChildIndex(this.ModelCode_lbl, 0);
            this.Controls.SetChildIndex(this.Manufacturer_txt, 0);
            this.Controls.SetChildIndex(this.ModelName_lbl, 0);
            this.Controls.SetChildIndex(this.ModelName_txt, 0);
            this.Controls.SetChildIndex(this.InstrationDate_dtp, 0);
            ((System.ComponentModel.ISupportInitialize)(this.EquipmentData_dgv)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal Com.Nidec.Mes.Framework.DataGridViewCommon EquipmentData_dgv;
        private Com.Nidec.Mes.Framework.ButtonCommon Clear_btn;
        private Com.Nidec.Mes.Framework.ButtonCommon Add_btn;
        private Com.Nidec.Mes.Framework.ButtonCommon Search_btn;
        private Com.Nidec.Mes.Framework.ButtonCommon Exit_btn;
        private Com.Nidec.Mes.Framework.ButtonCommon Delete_btn;
        private Com.Nidec.Mes.Framework.ButtonCommon Update_btn;
        private Com.Nidec.Mes.Framework.TextBoxCommon ModelName_txt;
        private Com.Nidec.Mes.Framework.LabelCommon ModelName_lbl;
        private Com.Nidec.Mes.Framework.TextBoxCommon Manufacturer_txt;
        private Com.Nidec.Mes.Framework.LabelCommon ModelCode_lbl;
        private Com.Nidec.Mes.Framework.TextBoxCommon ModelCode_txt;
        private Com.Nidec.Mes.Framework.LabelCommon Manufacturer_lbl;
        private Com.Nidec.Mes.Framework.LabelCommon AssertNo_lbl;
        private Com.Nidec.Mes.Framework.TextBoxCommon AssertNo_txt;
        private Com.Nidec.Mes.Framework.LabelCommon InstrationDate_lbl;
        private Com.Nidec.Mes.Framework.TextBoxCommon EquipmentCode_txt;
        private Com.Nidec.Mes.Framework.LabelCommon EquipmentName_lbl;
        private Com.Nidec.Mes.Framework.TextBoxCommon EquipmentName_txt;
        private Com.Nidec.Mes.Framework.LabelCommon EquipmentCode_lbl;
        private Framework.DateTimePickerCommon InstrationDate_dtp;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEquipmentId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEquipmentCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEquipmentName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colInstrationDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAssetNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colManufacturer;
        private System.Windows.Forms.DataGridViewTextBoxColumn colModelCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn colModelName;
    }
}