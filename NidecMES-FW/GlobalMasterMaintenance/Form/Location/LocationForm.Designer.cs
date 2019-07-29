namespace Com.Nidec.Mes.GlobalMasterMaintenance
{
    partial class LocationForm : FormCommonMaster
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LocationForm));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.Building_lbl = new Com.Nidec.Mes.Framework.LabelCommon();
            this.Building_cmb = new Com.Nidec.Mes.Framework.ComboBoxCommon();
            this.LocationCode_txt = new Com.Nidec.Mes.Framework.TextBoxCommon();
            this.LocationName_lbl = new Com.Nidec.Mes.Framework.LabelCommon();
            this.LocationName_txt = new Com.Nidec.Mes.Framework.TextBoxCommon();
            this.LocationCode_lbl = new Com.Nidec.Mes.Framework.LabelCommon();
            this.Clear_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.Exit_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.Delete_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.Update_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.Add_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.Search_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.Location_dgv = new Com.Nidec.Mes.Framework.DataGridViewCommon();
            this.colLocationId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLocationCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLocationName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBuilding = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBuildingId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.Location_dgv)).BeginInit();
            this.SuspendLayout();
            // 
            // Building_lbl
            // 
            resources.ApplyResources(this.Building_lbl, "Building_lbl");
            this.Building_lbl.ControlId = null;
            this.Building_lbl.Name = "Building_lbl";
            // 
            // Building_cmb
            // 
            this.Building_cmb.ControlId = null;
            resources.ApplyResources(this.Building_cmb, "Building_cmb");
            this.Building_cmb.FormattingEnabled = true;
            this.Building_cmb.Name = "Building_cmb";
            // 
            // LocationCode_txt
            // 
            this.LocationCode_txt.ControlId = null;
            resources.ApplyResources(this.LocationCode_txt, "LocationCode_txt");
            this.LocationCode_txt.InputType = Com.Nidec.Mes.Framework.TextBoxCommon.InputTypeList.All;
            this.LocationCode_txt.Name = "LocationCode_txt";
            // 
            // LocationName_lbl
            // 
            resources.ApplyResources(this.LocationName_lbl, "LocationName_lbl");
            this.LocationName_lbl.ControlId = null;
            this.LocationName_lbl.Name = "LocationName_lbl";
            // 
            // LocationName_txt
            // 
            this.LocationName_txt.ControlId = null;
            resources.ApplyResources(this.LocationName_txt, "LocationName_txt");
            this.LocationName_txt.InputType = Com.Nidec.Mes.Framework.TextBoxCommon.InputTypeList.All;
            this.LocationName_txt.Name = "LocationName_txt";
            // 
            // LocationCode_lbl
            // 
            resources.ApplyResources(this.LocationCode_lbl, "LocationCode_lbl");
            this.LocationCode_lbl.ControlId = null;
            this.LocationCode_lbl.Name = "LocationCode_lbl";
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
            // Location_dgv
            // 
            this.Location_dgv.AllowUserToAddRows = false;
            this.Location_dgv.AllowUserToDeleteRows = false;
            this.Location_dgv.AllowUserToOrderColumns = true;
            this.Location_dgv.AllowUserToResizeRows = false;
            resources.ApplyResources(this.Location_dgv, "Location_dgv");
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(232)))), ((int)(((byte)(180)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.Location_dgv.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.Location_dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Location_dgv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colLocationId,
            this.colLocationCode,
            this.colLocationName,
            this.colBuilding,
            this.colBuildingId});
            this.Location_dgv.ControlId = null;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.Location_dgv.DefaultCellStyle = dataGridViewCellStyle2;
            this.Location_dgv.EnableHeadersVisualStyles = false;
            this.Location_dgv.MultiSelect = false;
            this.Location_dgv.Name = "Location_dgv";
            this.Location_dgv.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(232)))), ((int)(((byte)(180)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.Location_dgv.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.Location_dgv.RowHeadersVisible = false;
            this.Location_dgv.RowTemplate.Height = 21;
            this.Location_dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.Location_dgv.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Location_dgv_CellClick);
            this.Location_dgv.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Location_dgv_CellDoubleClick);
            // 
            // colLocationId
            // 
            this.colLocationId.DataPropertyName = "LocationId";
            resources.ApplyResources(this.colLocationId, "colLocationId");
            this.colLocationId.Name = "colLocationId";
            this.colLocationId.ReadOnly = true;
            // 
            // colLocationCode
            // 
            this.colLocationCode.DataPropertyName = "LocationCode";
            resources.ApplyResources(this.colLocationCode, "colLocationCode");
            this.colLocationCode.Name = "colLocationCode";
            this.colLocationCode.ReadOnly = true;
            // 
            // colLocationName
            // 
            this.colLocationName.DataPropertyName = "LocationName";
            resources.ApplyResources(this.colLocationName, "colLocationName");
            this.colLocationName.Name = "colLocationName";
            this.colLocationName.ReadOnly = true;
            // 
            // colBuilding
            // 
            this.colBuilding.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colBuilding.DataPropertyName = "BuildingName";
            resources.ApplyResources(this.colBuilding, "colBuilding");
            this.colBuilding.Name = "colBuilding";
            this.colBuilding.ReadOnly = true;
            // 
            // colBuildingId
            // 
            this.colBuildingId.DataPropertyName = "BuildingId";
            resources.ApplyResources(this.colBuildingId, "colBuildingId");
            this.colBuildingId.Name = "colBuildingId";
            this.colBuildingId.ReadOnly = true;
            // 
            // LocationForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ControlId = "bpmf019";
            this.Controls.Add(this.Building_lbl);
            this.Controls.Add(this.Building_cmb);
            this.Controls.Add(this.LocationCode_txt);
            this.Controls.Add(this.LocationName_lbl);
            this.Controls.Add(this.LocationName_txt);
            this.Controls.Add(this.LocationCode_lbl);
            this.Controls.Add(this.Clear_btn);
            this.Controls.Add(this.Exit_btn);
            this.Controls.Add(this.Delete_btn);
            this.Controls.Add(this.Update_btn);
            this.Controls.Add(this.Add_btn);
            this.Controls.Add(this.Search_btn);
            this.Controls.Add(this.Location_dgv);
            this.Name = "LocationForm";
            this.TitleText = "FormCommon";
            this.Load += new System.EventHandler(this.LocationForm_Load);
            this.Controls.SetChildIndex(this.Location_dgv, 0);
            this.Controls.SetChildIndex(this.Search_btn, 0);
            this.Controls.SetChildIndex(this.Add_btn, 0);
            this.Controls.SetChildIndex(this.Update_btn, 0);
            this.Controls.SetChildIndex(this.Delete_btn, 0);
            this.Controls.SetChildIndex(this.Exit_btn, 0);
            this.Controls.SetChildIndex(this.Clear_btn, 0);
            this.Controls.SetChildIndex(this.LocationCode_lbl, 0);
            this.Controls.SetChildIndex(this.LocationName_txt, 0);
            this.Controls.SetChildIndex(this.LocationName_lbl, 0);
            this.Controls.SetChildIndex(this.LocationCode_txt, 0);
            this.Controls.SetChildIndex(this.Building_cmb, 0);
            this.Controls.SetChildIndex(this.Building_lbl, 0);
            ((System.ComponentModel.ISupportInitialize)(this.Location_dgv)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Com.Nidec.Mes.Framework.LabelCommon Building_lbl;
        private Com.Nidec.Mes.Framework.ComboBoxCommon Building_cmb;
        private Com.Nidec.Mes.Framework.TextBoxCommon LocationCode_txt;
        private Com.Nidec.Mes.Framework.LabelCommon LocationName_lbl;
        private Com.Nidec.Mes.Framework.TextBoxCommon LocationName_txt;
        private Com.Nidec.Mes.Framework.LabelCommon LocationCode_lbl;
        private Com.Nidec.Mes.Framework.ButtonCommon Clear_btn;
        private Com.Nidec.Mes.Framework.ButtonCommon Exit_btn;
        private Com.Nidec.Mes.Framework.ButtonCommon Delete_btn;
        private Com.Nidec.Mes.Framework.ButtonCommon Update_btn;
        private Com.Nidec.Mes.Framework.ButtonCommon Add_btn;
        private Com.Nidec.Mes.Framework.ButtonCommon Search_btn;
        internal Com.Nidec.Mes.Framework.DataGridViewCommon Location_dgv;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLocationId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLocationCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLocationName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBuilding;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBuildingId;
    }
}