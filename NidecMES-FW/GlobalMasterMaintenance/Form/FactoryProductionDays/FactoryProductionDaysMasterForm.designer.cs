namespace Com.Nidec.Mes.GlobalMasterMaintenance
{
    partial class FactoryProductionDaysMasterForm : FormCommonMaster
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FactoryProductionDaysMasterForm));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.Building_lbl = new Com.Nidec.Mes.Framework.LabelCommon();
            this.Add_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.Search_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.FactoryProductionDays_dgv = new Com.Nidec.Mes.Framework.DataGridViewCommon();
            this.Exit_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.Delete_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.Update_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.Clear_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.Building_cmb = new Com.Nidec.Mes.Framework.ComboBoxCommon();
            this.Year_lbl = new Com.Nidec.Mes.Framework.LabelCommon();
            this.Year_txt = new Com.Nidec.Mes.Framework.TextBoxCommon();
            this.colFactoryProductionId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBuildingName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.coliYear = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.coliMonth = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.coliDays = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.FactoryProductionDays_dgv)).BeginInit();
            this.SuspendLayout();
            // 
            // Building_lbl
            // 
            resources.ApplyResources(this.Building_lbl, "Building_lbl");
            this.Building_lbl.ControlId = null;
            this.Building_lbl.Name = "Building_lbl";
            // 
            // Add_btn
            // 
            resources.ApplyResources(this.Add_btn, "Add_btn");
            this.Add_btn.BackColor = System.Drawing.SystemColors.Control;
            this.Add_btn.ControlId = null;
            this.Add_btn.Name = "Add_btn";
            this.Add_btn.UseVisualStyleBackColor = true;
            this.Add_btn.Click += new System.EventHandler(this.Add_btn_Click);
            // 
            // Search_btn
            // 
            resources.ApplyResources(this.Search_btn, "Search_btn");
            this.Search_btn.BackColor = System.Drawing.SystemColors.Control;
            this.Search_btn.ControlId = null;
            this.Search_btn.Name = "Search_btn";
            this.Search_btn.UseVisualStyleBackColor = true;
            this.Search_btn.Click += new System.EventHandler(this.Search_btn_Click);
            // 
            // FactoryProductionDays_dgv
            // 
            resources.ApplyResources(this.FactoryProductionDays_dgv, "FactoryProductionDays_dgv");
            this.FactoryProductionDays_dgv.AllowUserToAddRows = false;
            this.FactoryProductionDays_dgv.AllowUserToDeleteRows = false;
            this.FactoryProductionDays_dgv.AllowUserToOrderColumns = true;
            this.FactoryProductionDays_dgv.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(232)))), ((int)(((byte)(180)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.FactoryProductionDays_dgv.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.FactoryProductionDays_dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.FactoryProductionDays_dgv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colFactoryProductionId,
            this.colBuildingName,
            this.coliYear,
            this.coliMonth,
            this.coliDays});
            this.FactoryProductionDays_dgv.ControlId = null;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.FactoryProductionDays_dgv.DefaultCellStyle = dataGridViewCellStyle6;
            this.FactoryProductionDays_dgv.EnableHeadersVisualStyles = false;
            this.FactoryProductionDays_dgv.MultiSelect = false;
            this.FactoryProductionDays_dgv.Name = "FactoryProductionDays_dgv";
            this.FactoryProductionDays_dgv.ReadOnly = true;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(232)))), ((int)(((byte)(180)))));
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.FactoryProductionDays_dgv.RowHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.FactoryProductionDays_dgv.RowHeadersVisible = false;
            this.FactoryProductionDays_dgv.RowTemplate.Height = 21;
            this.FactoryProductionDays_dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.FactoryProductionDays_dgv.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.FactoryDetails_dgv_CellClick);
            this.FactoryProductionDays_dgv.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.FactoryDetails_dgv_CellDoubleClick);
            this.FactoryProductionDays_dgv.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.FactoryDetails_dgv_ColumnHeaderMouseClick);
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
            // Clear_btn
            // 
            resources.ApplyResources(this.Clear_btn, "Clear_btn");
            this.Clear_btn.BackColor = System.Drawing.SystemColors.Control;
            this.Clear_btn.ControlId = null;
            this.Clear_btn.Name = "Clear_btn";
            this.Clear_btn.UseVisualStyleBackColor = true;
            this.Clear_btn.Click += new System.EventHandler(this.Clear_btn_Click);
            // 
            // Building_cmb
            // 
            resources.ApplyResources(this.Building_cmb, "Building_cmb");
            this.Building_cmb.ControlId = null;
            this.Building_cmb.FormattingEnabled = true;
            this.Building_cmb.Name = "Building_cmb";
            // 
            // Year_lbl
            // 
            resources.ApplyResources(this.Year_lbl, "Year_lbl");
            this.Year_lbl.ControlId = null;
            this.Year_lbl.Name = "Year_lbl";
            // 
            // Year_txt
            // 
            resources.ApplyResources(this.Year_txt, "Year_txt");
            this.Year_txt.ControlId = null;
            this.Year_txt.InputType = Com.Nidec.Mes.Framework.TextBoxCommon.InputTypeList.Numeric;
            this.Year_txt.Name = "Year_txt";
            // 
            // colFactoryProductionId
            // 
            this.colFactoryProductionId.DataPropertyName = "FactoryProductionDaysId";
            resources.ApplyResources(this.colFactoryProductionId, "colFactoryProductionId");
            this.colFactoryProductionId.Name = "colFactoryProductionId";
            this.colFactoryProductionId.ReadOnly = true;
            // 
            // colBuildingName
            // 
            this.colBuildingName.DataPropertyName = "BuildingName";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.colBuildingName.DefaultCellStyle = dataGridViewCellStyle2;
            resources.ApplyResources(this.colBuildingName, "colBuildingName");
            this.colBuildingName.Name = "colBuildingName";
            this.colBuildingName.ReadOnly = true;
            // 
            // coliYear
            // 
            this.coliYear.DataPropertyName = "iYear";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.coliYear.DefaultCellStyle = dataGridViewCellStyle3;
            resources.ApplyResources(this.coliYear, "coliYear");
            this.coliYear.Name = "coliYear";
            this.coliYear.ReadOnly = true;
            // 
            // coliMonth
            // 
            this.coliMonth.DataPropertyName = "iMonth";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.NullValue = null;
            this.coliMonth.DefaultCellStyle = dataGridViewCellStyle4;
            resources.ApplyResources(this.coliMonth, "coliMonth");
            this.coliMonth.Name = "coliMonth";
            this.coliMonth.ReadOnly = true;
            // 
            // coliDays
            // 
            this.coliDays.DataPropertyName = "iDays";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.NullValue = null;
            this.coliDays.DefaultCellStyle = dataGridViewCellStyle5;
            resources.ApplyResources(this.coliDays, "coliDays");
            this.coliDays.Name = "coliDays";
            this.coliDays.ReadOnly = true;
            // 
            // FactoryProductionDaysMasterForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ControlId = "bpmf006";
            this.Controls.Add(this.Year_txt);
            this.Controls.Add(this.Year_lbl);
            this.Controls.Add(this.Building_cmb);
            this.Controls.Add(this.Clear_btn);
            this.Controls.Add(this.Exit_btn);
            this.Controls.Add(this.Delete_btn);
            this.Controls.Add(this.Update_btn);
            this.Controls.Add(this.FactoryProductionDays_dgv);
            this.Controls.Add(this.Add_btn);
            this.Controls.Add(this.Search_btn);
            this.Controls.Add(this.Building_lbl);
            this.Name = "FactoryProductionDaysMasterForm";
            this.TitleText = "FormCommon";
            this.Load += new System.EventHandler(this.FactoryProductionDaysMasterForm_Load);
            this.Controls.SetChildIndex(this.Building_lbl, 0);
            this.Controls.SetChildIndex(this.Search_btn, 0);
            this.Controls.SetChildIndex(this.Add_btn, 0);
            this.Controls.SetChildIndex(this.FactoryProductionDays_dgv, 0);
            this.Controls.SetChildIndex(this.Update_btn, 0);
            this.Controls.SetChildIndex(this.Delete_btn, 0);
            this.Controls.SetChildIndex(this.Exit_btn, 0);
            this.Controls.SetChildIndex(this.Clear_btn, 0);
            this.Controls.SetChildIndex(this.Building_cmb, 0);
            this.Controls.SetChildIndex(this.Year_lbl, 0);
            this.Controls.SetChildIndex(this.Year_txt, 0);
            ((System.ComponentModel.ISupportInitialize)(this.FactoryProductionDays_dgv)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        protected Com.Nidec.Mes.Framework.LabelCommon Building_lbl;
        protected Com.Nidec.Mes.Framework.ButtonCommon Add_btn;
        protected Com.Nidec.Mes.Framework.ButtonCommon Search_btn;
        protected Com.Nidec.Mes.Framework.DataGridViewCommon FactoryProductionDays_dgv;
        protected Com.Nidec.Mes.Framework.ButtonCommon Exit_btn;
        protected Com.Nidec.Mes.Framework.ButtonCommon Delete_btn;
        protected Com.Nidec.Mes.Framework.ButtonCommon Update_btn;
        protected Com.Nidec.Mes.Framework.ButtonCommon Clear_btn;
        private Framework.ComboBoxCommon Building_cmb;
        protected Framework.LabelCommon Year_lbl;
        private Framework.TextBoxCommon Year_txt;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFactoryProductionId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBuildingName;
        private System.Windows.Forms.DataGridViewTextBoxColumn coliYear;
        private System.Windows.Forms.DataGridViewTextBoxColumn coliMonth;
        private System.Windows.Forms.DataGridViewTextBoxColumn coliDays;
    }
}