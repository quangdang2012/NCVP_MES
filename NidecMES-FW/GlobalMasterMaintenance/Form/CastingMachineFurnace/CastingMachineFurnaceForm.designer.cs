namespace Com.Nidec.Mes.GlobalMasterMaintenance
{
    partial class CastingMachineFurnaceForm : FormCommonMaster
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CastingMachineFurnaceForm));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.EquipmentId_cmb = new Com.Nidec.Mes.Framework.ComboBoxCommon();
            this.EquipmentCode_lbl = new Com.Nidec.Mes.Framework.LabelCommon();
            this.Clear_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.Exit_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.Delete_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.Update_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.CastingMachineFurnaceDetails_dgv = new Com.Nidec.Mes.Framework.DataGridViewCommon();
            this.colCastingMachineFurnaceCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCastingMachineFurnaceName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEquipmentName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEquipmentId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCastingMachineFurnaceId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Add_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.Search_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.CastingMachineFurnaceName_txt = new Com.Nidec.Mes.Framework.TextBoxCommon();
            this.CastingMachineFurnaceName_lbl = new Com.Nidec.Mes.Framework.LabelCommon();
            this.CastingMachineFurnaceCode_txt = new Com.Nidec.Mes.Framework.TextBoxCommon();
            this.CastingMachineFurnaceCode_lbl = new Com.Nidec.Mes.Framework.LabelCommon();
            ((System.ComponentModel.ISupportInitialize)(this.CastingMachineFurnaceDetails_dgv)).BeginInit();
            this.SuspendLayout();
            // 
            // EquipmentId_cmb
            // 
            this.EquipmentId_cmb.ControlId = null;
            resources.ApplyResources(this.EquipmentId_cmb, "EquipmentId_cmb");
            this.EquipmentId_cmb.FormattingEnabled = true;
            this.EquipmentId_cmb.Name = "EquipmentId_cmb";
            // 
            // EquipmentCode_lbl
            // 
            resources.ApplyResources(this.EquipmentCode_lbl, "EquipmentCode_lbl");
            this.EquipmentCode_lbl.ControlId = null;
            this.EquipmentCode_lbl.Name = "EquipmentCode_lbl";
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
            // CastingMachineFurnaceDetails_dgv
            // 
            this.CastingMachineFurnaceDetails_dgv.AllowUserToAddRows = false;
            this.CastingMachineFurnaceDetails_dgv.AllowUserToDeleteRows = false;
            this.CastingMachineFurnaceDetails_dgv.AllowUserToOrderColumns = true;
            this.CastingMachineFurnaceDetails_dgv.AllowUserToResizeRows = false;
            resources.ApplyResources(this.CastingMachineFurnaceDetails_dgv, "CastingMachineFurnaceDetails_dgv");
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(232)))), ((int)(((byte)(180)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.CastingMachineFurnaceDetails_dgv.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.CastingMachineFurnaceDetails_dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.CastingMachineFurnaceDetails_dgv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colCastingMachineFurnaceCode,
            this.colCastingMachineFurnaceName,
            this.colEquipmentName,
            this.colEquipmentId,
            this.colCastingMachineFurnaceId});
            this.CastingMachineFurnaceDetails_dgv.ControlId = null;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.CastingMachineFurnaceDetails_dgv.DefaultCellStyle = dataGridViewCellStyle2;
            this.CastingMachineFurnaceDetails_dgv.EnableHeadersVisualStyles = false;
            this.CastingMachineFurnaceDetails_dgv.MultiSelect = false;
            this.CastingMachineFurnaceDetails_dgv.Name = "CastingMachineFurnaceDetails_dgv";
            this.CastingMachineFurnaceDetails_dgv.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(232)))), ((int)(((byte)(180)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.CastingMachineFurnaceDetails_dgv.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.CastingMachineFurnaceDetails_dgv.RowHeadersVisible = false;
            this.CastingMachineFurnaceDetails_dgv.RowTemplate.Height = 21;
            this.CastingMachineFurnaceDetails_dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.CastingMachineFurnaceDetails_dgv.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.CastingMachineFurnaceDetails_dgv_CellClick);
            this.CastingMachineFurnaceDetails_dgv.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.CastingMachineFurnaceDetails_dgv_CellDoubleClick);
            // 
            // colCastingMachineFurnaceCode
            // 
            this.colCastingMachineFurnaceCode.DataPropertyName = "CastingMachineFurnaceCode";
            resources.ApplyResources(this.colCastingMachineFurnaceCode, "colCastingMachineFurnaceCode");
            this.colCastingMachineFurnaceCode.Name = "colCastingMachineFurnaceCode";
            this.colCastingMachineFurnaceCode.ReadOnly = true;
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
            // CastingMachineFurnaceName_txt
            // 
            this.CastingMachineFurnaceName_txt.ControlId = null;
            resources.ApplyResources(this.CastingMachineFurnaceName_txt, "CastingMachineFurnaceName_txt");
            this.CastingMachineFurnaceName_txt.InputType = Com.Nidec.Mes.Framework.TextBoxCommon.InputTypeList.All;
            this.CastingMachineFurnaceName_txt.Name = "CastingMachineFurnaceName_txt";
            // 
            // CastingMachineFurnaceName_lbl
            // 
            resources.ApplyResources(this.CastingMachineFurnaceName_lbl, "CastingMachineFurnaceName_lbl");
            this.CastingMachineFurnaceName_lbl.ControlId = null;
            this.CastingMachineFurnaceName_lbl.Name = "CastingMachineFurnaceName_lbl";
            // 
            // CastingMachineFurnaceCode_txt
            // 
            this.CastingMachineFurnaceCode_txt.ControlId = null;
            resources.ApplyResources(this.CastingMachineFurnaceCode_txt, "CastingMachineFurnaceCode_txt");
            this.CastingMachineFurnaceCode_txt.InputType = Com.Nidec.Mes.Framework.TextBoxCommon.InputTypeList.All;
            this.CastingMachineFurnaceCode_txt.Name = "CastingMachineFurnaceCode_txt";
            // 
            // CastingMachineFurnaceCode_lbl
            // 
            resources.ApplyResources(this.CastingMachineFurnaceCode_lbl, "CastingMachineFurnaceCode_lbl");
            this.CastingMachineFurnaceCode_lbl.ControlId = null;
            this.CastingMachineFurnaceCode_lbl.Name = "CastingMachineFurnaceCode_lbl";
            // 
            // CastingMachineFurnaceForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ControlId = "bpmf008";
            this.Controls.Add(this.EquipmentId_cmb);
            this.Controls.Add(this.EquipmentCode_lbl);
            this.Controls.Add(this.Clear_btn);
            this.Controls.Add(this.Exit_btn);
            this.Controls.Add(this.Delete_btn);
            this.Controls.Add(this.Update_btn);
            this.Controls.Add(this.CastingMachineFurnaceDetails_dgv);
            this.Controls.Add(this.Add_btn);
            this.Controls.Add(this.Search_btn);
            this.Controls.Add(this.CastingMachineFurnaceName_txt);
            this.Controls.Add(this.CastingMachineFurnaceName_lbl);
            this.Controls.Add(this.CastingMachineFurnaceCode_txt);
            this.Controls.Add(this.CastingMachineFurnaceCode_lbl);
            this.Name = "CastingMachineFurnaceForm";
            this.TitleText = "FormCommon";
            this.Load += new System.EventHandler(this.CastingMachineFurnaceMasterForm_Load);
            this.Controls.SetChildIndex(this.CastingMachineFurnaceCode_lbl, 0);
            this.Controls.SetChildIndex(this.CastingMachineFurnaceCode_txt, 0);
            this.Controls.SetChildIndex(this.CastingMachineFurnaceName_lbl, 0);
            this.Controls.SetChildIndex(this.CastingMachineFurnaceName_txt, 0);
            this.Controls.SetChildIndex(this.Search_btn, 0);
            this.Controls.SetChildIndex(this.Add_btn, 0);
            this.Controls.SetChildIndex(this.CastingMachineFurnaceDetails_dgv, 0);
            this.Controls.SetChildIndex(this.Update_btn, 0);
            this.Controls.SetChildIndex(this.Delete_btn, 0);
            this.Controls.SetChildIndex(this.Exit_btn, 0);
            this.Controls.SetChildIndex(this.Clear_btn, 0);
            this.Controls.SetChildIndex(this.EquipmentCode_lbl, 0);
            this.Controls.SetChildIndex(this.EquipmentId_cmb, 0);
            ((System.ComponentModel.ISupportInitialize)(this.CastingMachineFurnaceDetails_dgv)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Com.Nidec.Mes.Framework.ButtonCommon Clear_btn;
        private Com.Nidec.Mes.Framework.ButtonCommon Exit_btn;
        private Com.Nidec.Mes.Framework.ButtonCommon Delete_btn;
        private Com.Nidec.Mes.Framework.ButtonCommon Update_btn;
        internal Com.Nidec.Mes.Framework.DataGridViewCommon CastingMachineFurnaceDetails_dgv;
        private Com.Nidec.Mes.Framework.ButtonCommon Add_btn;
        private Com.Nidec.Mes.Framework.ButtonCommon Search_btn;
        private Com.Nidec.Mes.Framework.TextBoxCommon CastingMachineFurnaceName_txt;
        private Com.Nidec.Mes.Framework.LabelCommon CastingMachineFurnaceName_lbl;
        private Com.Nidec.Mes.Framework.TextBoxCommon CastingMachineFurnaceCode_txt;
        private Com.Nidec.Mes.Framework.LabelCommon CastingMachineFurnaceCode_lbl;
        private Com.Nidec.Mes.Framework.ComboBoxCommon EquipmentId_cmb;
        private Com.Nidec.Mes.Framework.LabelCommon EquipmentCode_lbl;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCastingMachineFurnaceCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCastingMachineFurnaceName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEquipmentName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEquipmentId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCastingMachineFurnaceId;
    }
}