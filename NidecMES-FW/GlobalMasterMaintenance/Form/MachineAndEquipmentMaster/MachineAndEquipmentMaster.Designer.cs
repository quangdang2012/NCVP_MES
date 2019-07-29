namespace Com.Nidec.Mes.GlobalMasterMaintenance
{
    partial class MachineAndEquipmentMaster
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MachineAndEquipmentMaster));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.Update_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.machinename_cmb = new Com.Nidec.Mes.Framework.ComboBoxCommon();
            this.machinename_lbl = new Com.Nidec.Mes.Framework.LabelCommon();
            this.Equipment_dgv = new Com.Nidec.Mes.Framework.DataGridViewCommon();
            this.colSelected = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colEquipmentCD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColEquipmentName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMachineName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.Equipment_dgv)).BeginInit();
            this.SuspendLayout();
            // 
            // Update_btn
            // 
            this.Update_btn.BackColor = System.Drawing.SystemColors.Control;
            this.Update_btn.ControlId = null;
            resources.ApplyResources(this.Update_btn, "Update_btn");
            this.Update_btn.Name = "Update_btn";
            this.Update_btn.UseVisualStyleBackColor = true;
            this.Update_btn.Click += new System.EventHandler(this.Update_btn_Click);
            // 
            // machinename_cmb
            // 
            this.machinename_cmb.ControlId = null;
            resources.ApplyResources(this.machinename_cmb, "machinename_cmb");
            this.machinename_cmb.FormattingEnabled = true;
            this.machinename_cmb.Name = "machinename_cmb";
            this.machinename_cmb.SelectedIndexChanged += new System.EventHandler(this.machinename_cmb_SelectedIndexChanged);
            // 
            // machinename_lbl
            // 
            resources.ApplyResources(this.machinename_lbl, "machinename_lbl");
            this.machinename_lbl.ControlId = null;
            this.machinename_lbl.Name = "machinename_lbl";
            // 
            // Equipment_dgv
            // 
            this.Equipment_dgv.AllowUserToAddRows = false;
            this.Equipment_dgv.AllowUserToDeleteRows = false;
            this.Equipment_dgv.AllowUserToOrderColumns = true;
            this.Equipment_dgv.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(232)))), ((int)(((byte)(180)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.Equipment_dgv.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.Equipment_dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Equipment_dgv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colSelected,
            this.colEquipmentCD,
            this.ColEquipmentName,
            this.colMachineName});
            this.Equipment_dgv.ControlId = null;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.Equipment_dgv.DefaultCellStyle = dataGridViewCellStyle2;
            this.Equipment_dgv.EnableHeadersVisualStyles = false;
            resources.ApplyResources(this.Equipment_dgv, "Equipment_dgv");
            this.Equipment_dgv.MultiSelect = false;
            this.Equipment_dgv.Name = "Equipment_dgv";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(232)))), ((int)(((byte)(180)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.Equipment_dgv.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.Equipment_dgv.RowHeadersVisible = false;
            this.Equipment_dgv.RowTemplate.Height = 21;
            this.Equipment_dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.Equipment_dgv.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.Equipment_dgv_CellBeginEdit);
            // 
            // colSelected
            // 
            this.colSelected.DataPropertyName = "Selected";
            resources.ApplyResources(this.colSelected, "colSelected");
            this.colSelected.Name = "colSelected";
            // 
            // colEquipmentCD
            // 
            this.colEquipmentCD.DataPropertyName = "EquipmentCode";
            resources.ApplyResources(this.colEquipmentCD, "colEquipmentCD");
            this.colEquipmentCD.Name = "colEquipmentCD";
            this.colEquipmentCD.ReadOnly = true;
            // 
            // ColEquipmentName
            // 
            this.ColEquipmentName.DataPropertyName = "EquipmentName";
            resources.ApplyResources(this.ColEquipmentName, "ColEquipmentName");
            this.ColEquipmentName.Name = "ColEquipmentName";
            this.ColEquipmentName.ReadOnly = true;
            // 
            // colMachineName
            // 
            this.colMachineName.DataPropertyName = "MachineName";
            resources.ApplyResources(this.colMachineName, "colMachineName");
            this.colMachineName.Name = "colMachineName";
            this.colMachineName.ReadOnly = true;
            // 
            // MachineAndEquipmentMaster
            // 
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.Equipment_dgv);
            this.Controls.Add(this.Update_btn);
            this.Controls.Add(this.machinename_cmb);
            this.Controls.Add(this.machinename_lbl);
            this.Name = "MachineAndEquipmentMaster";
            this.Load += new System.EventHandler(this.MachineAndEquipmentMaster_Load);
            this.Controls.SetChildIndex(this.machinename_lbl, 0);
            this.Controls.SetChildIndex(this.machinename_cmb, 0);
            this.Controls.SetChildIndex(this.Update_btn, 0);
            this.Controls.SetChildIndex(this.Equipment_dgv, 0);
            ((System.ComponentModel.ISupportInitialize)(this.Equipment_dgv)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Framework.ButtonCommon Update_btn;
        private Framework.ComboBoxCommon machinename_cmb;
        private Framework.LabelCommon machinename_lbl;
        internal Framework.DataGridViewCommon Equipment_dgv;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colSelected;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEquipmentCD;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColEquipmentName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMachineName;
    }
}
