namespace Com.Nidec.Mes.GlobalMasterMaintenance
{
    partial class CastingMachineForm :FormCommonMaster
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CastingMachineForm));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.EquipmentId_cmb = new Com.Nidec.Mes.Framework.ComboBoxCommon();
            this.EquipmentId_lbl = new Com.Nidec.Mes.Framework.LabelCommon();
            this.Clear_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.Exit_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.Delete_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.Update_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.CastingMachineDetails_dgv = new Com.Nidec.Mes.Framework.DataGridViewCommon();
            this.colCastingMachineCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCastingMachineName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCastingMachineFurnaceName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEquipmentName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEquipmentId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCastingMachineFurnaceId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCastingMachineId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Add_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.Search_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.CastingMachineName_txt = new Com.Nidec.Mes.Framework.TextBoxCommon();
            this.CastingMachineName_lbl = new Com.Nidec.Mes.Framework.LabelCommon();
            this.CastingMachineCode_txt = new Com.Nidec.Mes.Framework.TextBoxCommon();
            this.CastingMachineCode_lbl = new Com.Nidec.Mes.Framework.LabelCommon();
            this.CastingMachineFurnaceId_cmb = new Com.Nidec.Mes.Framework.ComboBoxCommon();
            this.CastingMachineFurnaceId_lbl = new Com.Nidec.Mes.Framework.LabelCommon();
            ((System.ComponentModel.ISupportInitialize)(this.CastingMachineDetails_dgv)).BeginInit();
            this.SuspendLayout();
            // 
            // EquipmentId_cmb
            // 
            this.EquipmentId_cmb.ControlId = null;
            resources.ApplyResources(this.EquipmentId_cmb, "EquipmentId_cmb");
            this.EquipmentId_cmb.FormattingEnabled = true;
            this.EquipmentId_cmb.Name = "EquipmentId_cmb";
            // 
            // EquipmentId_lbl
            // 
            resources.ApplyResources(this.EquipmentId_lbl, "EquipmentId_lbl");
            this.EquipmentId_lbl.ControlId = null;
            this.EquipmentId_lbl.Name = "EquipmentId_lbl";
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
            // CastingMachineDetails_dgv
            // 
            this.CastingMachineDetails_dgv.AllowUserToAddRows = false;
            this.CastingMachineDetails_dgv.AllowUserToDeleteRows = false;
            this.CastingMachineDetails_dgv.AllowUserToOrderColumns = true;
            this.CastingMachineDetails_dgv.AllowUserToResizeRows = false;
            resources.ApplyResources(this.CastingMachineDetails_dgv, "CastingMachineDetails_dgv");
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(232)))), ((int)(((byte)(180)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.CastingMachineDetails_dgv.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.CastingMachineDetails_dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.CastingMachineDetails_dgv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colCastingMachineCode,
            this.colCastingMachineName,
            this.colCastingMachineFurnaceName,
            this.colEquipmentName,
            this.colEquipmentId,
            this.colCastingMachineFurnaceId,
            this.colCastingMachineId});
            this.CastingMachineDetails_dgv.ControlId = null;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.CastingMachineDetails_dgv.DefaultCellStyle = dataGridViewCellStyle2;
            this.CastingMachineDetails_dgv.EnableHeadersVisualStyles = false;
            this.CastingMachineDetails_dgv.MultiSelect = false;
            this.CastingMachineDetails_dgv.Name = "CastingMachineDetails_dgv";
            this.CastingMachineDetails_dgv.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(232)))), ((int)(((byte)(180)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.CastingMachineDetails_dgv.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.CastingMachineDetails_dgv.RowHeadersVisible = false;
            this.CastingMachineDetails_dgv.RowTemplate.Height = 21;
            this.CastingMachineDetails_dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.CastingMachineDetails_dgv.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.CastingMachineDetails_dgv_CellClick);
            this.CastingMachineDetails_dgv.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.CastingMachineDetails_dgv_CellDoubleClick);
            // 
            // colCastingMachineCode
            // 
            this.colCastingMachineCode.DataPropertyName = "CastingMachineCode";
            resources.ApplyResources(this.colCastingMachineCode, "colCastingMachineCode");
            this.colCastingMachineCode.Name = "colCastingMachineCode";
            this.colCastingMachineCode.ReadOnly = true;
            // 
            // colCastingMachineName
            // 
            this.colCastingMachineName.DataPropertyName = "CastingMachineName";
            resources.ApplyResources(this.colCastingMachineName, "colCastingMachineName");
            this.colCastingMachineName.Name = "colCastingMachineName";
            this.colCastingMachineName.ReadOnly = true;
            // 
            // colCastingMachineFurnaceName
            // 
            this.colCastingMachineFurnaceName.DataPropertyName = "CastingMachineFurnaceName";
            resources.ApplyResources(this.colCastingMachineFurnaceName, "colCastingMachineFurnaceName");
            this.colCastingMachineFurnaceName.Name = "colCastingMachineFurnaceName";
            this.colCastingMachineFurnaceName.ReadOnly = true;
            // 
            // colEquipmentName
            // 
            this.colEquipmentName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colEquipmentName.DataPropertyName = "EquipmentName";
            resources.ApplyResources(this.colEquipmentName, "colEquipmentName");
            this.colEquipmentName.Name = "colEquipmentName";
            this.colEquipmentName.ReadOnly = true;
            // 
            // colEquipmentId
            // 
            this.colEquipmentId.DataPropertyName = "EquipmentId";
            resources.ApplyResources(this.colEquipmentId, "colEquipmentId");
            this.colEquipmentId.Name = "colEquipmentId";
            this.colEquipmentId.ReadOnly = true;
            // 
            // colCastingMachineFurnaceId
            // 
            this.colCastingMachineFurnaceId.DataPropertyName = "CastingMachineFurnaceId";
            resources.ApplyResources(this.colCastingMachineFurnaceId, "colCastingMachineFurnaceId");
            this.colCastingMachineFurnaceId.Name = "colCastingMachineFurnaceId";
            this.colCastingMachineFurnaceId.ReadOnly = true;
            // 
            // colCastingMachineId
            // 
            this.colCastingMachineId.DataPropertyName = "CastingMachineId";
            resources.ApplyResources(this.colCastingMachineId, "colCastingMachineId");
            this.colCastingMachineId.Name = "colCastingMachineId";
            this.colCastingMachineId.ReadOnly = true;
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
            // CastingMachineName_txt
            // 
            this.CastingMachineName_txt.ControlId = null;
            resources.ApplyResources(this.CastingMachineName_txt, "CastingMachineName_txt");
            this.CastingMachineName_txt.InputType = Com.Nidec.Mes.Framework.TextBoxCommon.InputTypeList.All;
            this.CastingMachineName_txt.Name = "CastingMachineName_txt";
            // 
            // CastingMachineName_lbl
            // 
            resources.ApplyResources(this.CastingMachineName_lbl, "CastingMachineName_lbl");
            this.CastingMachineName_lbl.ControlId = null;
            this.CastingMachineName_lbl.Name = "CastingMachineName_lbl";
            // 
            // CastingMachineCode_txt
            // 
            this.CastingMachineCode_txt.ControlId = null;
            resources.ApplyResources(this.CastingMachineCode_txt, "CastingMachineCode_txt");
            this.CastingMachineCode_txt.InputType = Com.Nidec.Mes.Framework.TextBoxCommon.InputTypeList.All;
            this.CastingMachineCode_txt.Name = "CastingMachineCode_txt";
            // 
            // CastingMachineCode_lbl
            // 
            resources.ApplyResources(this.CastingMachineCode_lbl, "CastingMachineCode_lbl");
            this.CastingMachineCode_lbl.ControlId = null;
            this.CastingMachineCode_lbl.Name = "CastingMachineCode_lbl";
            // 
            // CastingMachineFurnaceId_cmb
            // 
            this.CastingMachineFurnaceId_cmb.ControlId = null;
            resources.ApplyResources(this.CastingMachineFurnaceId_cmb, "CastingMachineFurnaceId_cmb");
            this.CastingMachineFurnaceId_cmb.FormattingEnabled = true;
            this.CastingMachineFurnaceId_cmb.Name = "CastingMachineFurnaceId_cmb";
            // 
            // CastingMachineFurnaceId_lbl
            // 
            resources.ApplyResources(this.CastingMachineFurnaceId_lbl, "CastingMachineFurnaceId_lbl");
            this.CastingMachineFurnaceId_lbl.ControlId = null;
            this.CastingMachineFurnaceId_lbl.Name = "CastingMachineFurnaceId_lbl";
            // 
            // CastingMachineForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ControlId = "bpmf009";
            this.Controls.Add(this.CastingMachineFurnaceId_cmb);
            this.Controls.Add(this.CastingMachineFurnaceId_lbl);
            this.Controls.Add(this.EquipmentId_cmb);
            this.Controls.Add(this.EquipmentId_lbl);
            this.Controls.Add(this.Clear_btn);
            this.Controls.Add(this.Exit_btn);
            this.Controls.Add(this.Delete_btn);
            this.Controls.Add(this.Update_btn);
            this.Controls.Add(this.CastingMachineDetails_dgv);
            this.Controls.Add(this.Add_btn);
            this.Controls.Add(this.Search_btn);
            this.Controls.Add(this.CastingMachineName_txt);
            this.Controls.Add(this.CastingMachineName_lbl);
            this.Controls.Add(this.CastingMachineCode_txt);
            this.Controls.Add(this.CastingMachineCode_lbl);
            this.Name = "CastingMachineForm";
            this.TitleText = "FormCommon";
            this.Load += new System.EventHandler(this.CastingMachineForm_Load);
            this.Controls.SetChildIndex(this.CastingMachineCode_lbl, 0);
            this.Controls.SetChildIndex(this.CastingMachineCode_txt, 0);
            this.Controls.SetChildIndex(this.CastingMachineName_lbl, 0);
            this.Controls.SetChildIndex(this.CastingMachineName_txt, 0);
            this.Controls.SetChildIndex(this.Search_btn, 0);
            this.Controls.SetChildIndex(this.Add_btn, 0);
            this.Controls.SetChildIndex(this.CastingMachineDetails_dgv, 0);
            this.Controls.SetChildIndex(this.Update_btn, 0);
            this.Controls.SetChildIndex(this.Delete_btn, 0);
            this.Controls.SetChildIndex(this.Exit_btn, 0);
            this.Controls.SetChildIndex(this.Clear_btn, 0);
            this.Controls.SetChildIndex(this.EquipmentId_lbl, 0);
            this.Controls.SetChildIndex(this.EquipmentId_cmb, 0);
            this.Controls.SetChildIndex(this.CastingMachineFurnaceId_lbl, 0);
            this.Controls.SetChildIndex(this.CastingMachineFurnaceId_cmb, 0);
            ((System.ComponentModel.ISupportInitialize)(this.CastingMachineDetails_dgv)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Com.Nidec.Mes.Framework.ComboBoxCommon EquipmentId_cmb;
        private Com.Nidec.Mes.Framework.LabelCommon EquipmentId_lbl;
        private Com.Nidec.Mes.Framework.ButtonCommon Clear_btn;
        private Com.Nidec.Mes.Framework.ButtonCommon Exit_btn;
        private Com.Nidec.Mes.Framework.ButtonCommon Delete_btn;
        private Com.Nidec.Mes.Framework.ButtonCommon Update_btn;
        internal Com.Nidec.Mes.Framework.DataGridViewCommon CastingMachineDetails_dgv;
        private Com.Nidec.Mes.Framework.ButtonCommon Add_btn;
        private Com.Nidec.Mes.Framework.ButtonCommon Search_btn;
        private Com.Nidec.Mes.Framework.TextBoxCommon CastingMachineName_txt;
        private Com.Nidec.Mes.Framework.LabelCommon CastingMachineName_lbl;
        private Com.Nidec.Mes.Framework.TextBoxCommon CastingMachineCode_txt;
        private Com.Nidec.Mes.Framework.LabelCommon CastingMachineCode_lbl;
        private Com.Nidec.Mes.Framework.ComboBoxCommon CastingMachineFurnaceId_cmb;
        private Com.Nidec.Mes.Framework.LabelCommon CastingMachineFurnaceId_lbl;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCastingMachineCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCastingMachineName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCastingMachineFurnaceName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEquipmentName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEquipmentId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCastingMachineFurnaceId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCastingMachineId;
    }
}