namespace Com.Nidec.Mes.GlobalMasterMaintenance
{
    partial class AreaForm : FormCommonMaster
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AreaForm));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.Location_lbl = new Com.Nidec.Mes.Framework.LabelCommon();
            this.Location_cmb = new Com.Nidec.Mes.Framework.ComboBoxCommon();
            this.AreaCode_txt = new Com.Nidec.Mes.Framework.TextBoxCommon();
            this.AreaName_lbl = new Com.Nidec.Mes.Framework.LabelCommon();
            this.AreaName_txt = new Com.Nidec.Mes.Framework.TextBoxCommon();
            this.AreaCode_lbl = new Com.Nidec.Mes.Framework.LabelCommon();
            this.Clear_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.Exit_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.Delete_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.Update_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.Add_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.Search_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.Area_dgv = new Com.Nidec.Mes.Framework.DataGridViewCommon();
            this.colAreaId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAreaCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAreaName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLocation = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLocationId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.Area_dgv)).BeginInit();
            this.SuspendLayout();
            // 
            // Location_lbl
            // 
            resources.ApplyResources(this.Location_lbl, "Location_lbl");
            this.Location_lbl.ControlId = null;
            this.Location_lbl.Name = "Location_lbl";
            // 
            // Location_cmb
            // 
            this.Location_cmb.ControlId = null;
            resources.ApplyResources(this.Location_cmb, "Location_cmb");
            this.Location_cmb.FormattingEnabled = true;
            this.Location_cmb.Name = "Location_cmb";
            // 
            // AreaCode_txt
            // 
            this.AreaCode_txt.ControlId = null;
            resources.ApplyResources(this.AreaCode_txt, "AreaCode_txt");
            this.AreaCode_txt.InputType = Com.Nidec.Mes.Framework.TextBoxCommon.InputTypeList.All;
            this.AreaCode_txt.Name = "AreaCode_txt";
            // 
            // AreaName_lbl
            // 
            resources.ApplyResources(this.AreaName_lbl, "AreaName_lbl");
            this.AreaName_lbl.ControlId = null;
            this.AreaName_lbl.Name = "AreaName_lbl";
            // 
            // AreaName_txt
            // 
            this.AreaName_txt.ControlId = null;
            resources.ApplyResources(this.AreaName_txt, "AreaName_txt");
            this.AreaName_txt.InputType = Com.Nidec.Mes.Framework.TextBoxCommon.InputTypeList.All;
            this.AreaName_txt.Name = "AreaName_txt";
            // 
            // AreaCode_lbl
            // 
            resources.ApplyResources(this.AreaCode_lbl, "AreaCode_lbl");
            this.AreaCode_lbl.ControlId = null;
            this.AreaCode_lbl.Name = "AreaCode_lbl";
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
            // Area_dgv
            // 
            this.Area_dgv.AllowUserToAddRows = false;
            this.Area_dgv.AllowUserToDeleteRows = false;
            this.Area_dgv.AllowUserToOrderColumns = true;
            this.Area_dgv.AllowUserToResizeRows = false;
            resources.ApplyResources(this.Area_dgv, "Area_dgv");
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(232)))), ((int)(((byte)(180)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.Area_dgv.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.Area_dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Area_dgv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colAreaId,
            this.colAreaCode,
            this.colAreaName,
            this.colLocation,
            this.colLocationId});
            this.Area_dgv.ControlId = null;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.Area_dgv.DefaultCellStyle = dataGridViewCellStyle2;
            this.Area_dgv.EnableHeadersVisualStyles = false;
            this.Area_dgv.MultiSelect = false;
            this.Area_dgv.Name = "Area_dgv";
            this.Area_dgv.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(232)))), ((int)(((byte)(180)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.Area_dgv.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.Area_dgv.RowHeadersVisible = false;
            this.Area_dgv.RowTemplate.Height = 21;
            this.Area_dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.Area_dgv.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Area_dgv_CellClick);
            this.Area_dgv.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Area_dgv_CellDoubleClick);
            // 
            // colAreaId
            // 
            this.colAreaId.DataPropertyName = "AreaId";
            resources.ApplyResources(this.colAreaId, "colAreaId");
            this.colAreaId.Name = "colAreaId";
            this.colAreaId.ReadOnly = true;
            // 
            // colAreaCode
            // 
            this.colAreaCode.DataPropertyName = "AreaCode";
            resources.ApplyResources(this.colAreaCode, "colAreaCode");
            this.colAreaCode.Name = "colAreaCode";
            this.colAreaCode.ReadOnly = true;
            // 
            // colAreaName
            // 
            this.colAreaName.DataPropertyName = "AreaName";
            resources.ApplyResources(this.colAreaName, "colAreaName");
            this.colAreaName.Name = "colAreaName";
            this.colAreaName.ReadOnly = true;
            // 
            // colLocation
            // 
            this.colLocation.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colLocation.DataPropertyName = "LocationName";
            resources.ApplyResources(this.colLocation, "colLocation");
            this.colLocation.Name = "colLocation";
            this.colLocation.ReadOnly = true;
            // 
            // colLocationId
            // 
            this.colLocationId.DataPropertyName = "LocationId";
            resources.ApplyResources(this.colLocationId, "colLocationId");
            this.colLocationId.Name = "colLocationId";
            this.colLocationId.ReadOnly = true;
            // 
            // AreaForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ControlId = "bpmf019";
            this.Controls.Add(this.Location_lbl);
            this.Controls.Add(this.Location_cmb);
            this.Controls.Add(this.AreaCode_txt);
            this.Controls.Add(this.AreaName_lbl);
            this.Controls.Add(this.AreaName_txt);
            this.Controls.Add(this.AreaCode_lbl);
            this.Controls.Add(this.Clear_btn);
            this.Controls.Add(this.Exit_btn);
            this.Controls.Add(this.Delete_btn);
            this.Controls.Add(this.Update_btn);
            this.Controls.Add(this.Add_btn);
            this.Controls.Add(this.Search_btn);
            this.Controls.Add(this.Area_dgv);
            this.Name = "AreaForm";
            this.TitleText = "FormCommon";
            this.Load += new System.EventHandler(this.AreaForm_Load);
            this.Controls.SetChildIndex(this.Area_dgv, 0);
            this.Controls.SetChildIndex(this.Search_btn, 0);
            this.Controls.SetChildIndex(this.Add_btn, 0);
            this.Controls.SetChildIndex(this.Update_btn, 0);
            this.Controls.SetChildIndex(this.Delete_btn, 0);
            this.Controls.SetChildIndex(this.Exit_btn, 0);
            this.Controls.SetChildIndex(this.Clear_btn, 0);
            this.Controls.SetChildIndex(this.AreaCode_lbl, 0);
            this.Controls.SetChildIndex(this.AreaName_txt, 0);
            this.Controls.SetChildIndex(this.AreaName_lbl, 0);
            this.Controls.SetChildIndex(this.AreaCode_txt, 0);
            this.Controls.SetChildIndex(this.Location_cmb, 0);
            this.Controls.SetChildIndex(this.Location_lbl, 0);
            ((System.ComponentModel.ISupportInitialize)(this.Area_dgv)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Com.Nidec.Mes.Framework.LabelCommon Location_lbl;
        private Com.Nidec.Mes.Framework.ComboBoxCommon Location_cmb;
        private Com.Nidec.Mes.Framework.TextBoxCommon AreaCode_txt;
        private Com.Nidec.Mes.Framework.LabelCommon AreaName_lbl;
        private Com.Nidec.Mes.Framework.TextBoxCommon AreaName_txt;
        private Com.Nidec.Mes.Framework.LabelCommon AreaCode_lbl;
        private Com.Nidec.Mes.Framework.ButtonCommon Clear_btn;
        private Com.Nidec.Mes.Framework.ButtonCommon Exit_btn;
        private Com.Nidec.Mes.Framework.ButtonCommon Delete_btn;
        private Com.Nidec.Mes.Framework.ButtonCommon Update_btn;
        private Com.Nidec.Mes.Framework.ButtonCommon Add_btn;
        private Com.Nidec.Mes.Framework.ButtonCommon Search_btn;
        internal Com.Nidec.Mes.Framework.DataGridViewCommon Area_dgv;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAreaId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAreaCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAreaName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLocation;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLocationId;
    }
}