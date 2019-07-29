namespace Com.Nidec.Mes.GlobalMasterMaintenance
{
    partial class BuildingForm : FormCommonMaster
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BuildingForm));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.BuildingCode_txt = new Com.Nidec.Mes.Framework.TextBoxCommon();
            this.BuildingName_lbl = new Com.Nidec.Mes.Framework.LabelCommon();
            this.BuildingName_txt = new Com.Nidec.Mes.Framework.TextBoxCommon();
            this.BuildingCode_lbl = new Com.Nidec.Mes.Framework.LabelCommon();
            this.Clear_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.Exit_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.Delete_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.Update_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.Add_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.Search_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.Building_dgv = new Com.Nidec.Mes.Framework.DataGridViewCommon();
            this.colBuildingId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBuildingCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBuildingName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFactoryCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FactoryCode_cmb = new Com.Nidec.Mes.Framework.ComboBoxCommon();
            this.Factory_lbl = new Com.Nidec.Mes.Framework.LabelCommon();
            ((System.ComponentModel.ISupportInitialize)(this.Building_dgv)).BeginInit();
            this.SuspendLayout();
            // 
            // BuildingCode_txt
            // 
            this.BuildingCode_txt.ControlId = null;
            resources.ApplyResources(this.BuildingCode_txt, "BuildingCode_txt");
            this.BuildingCode_txt.InputType = Com.Nidec.Mes.Framework.TextBoxCommon.InputTypeList.All;
            this.BuildingCode_txt.Name = "BuildingCode_txt";
            // 
            // BuildingName_lbl
            // 
            resources.ApplyResources(this.BuildingName_lbl, "BuildingName_lbl");
            this.BuildingName_lbl.ControlId = null;
            this.BuildingName_lbl.Name = "BuildingName_lbl";
            // 
            // BuildingName_txt
            // 
            this.BuildingName_txt.ControlId = null;
            resources.ApplyResources(this.BuildingName_txt, "BuildingName_txt");
            this.BuildingName_txt.InputType = Com.Nidec.Mes.Framework.TextBoxCommon.InputTypeList.All;
            this.BuildingName_txt.Name = "BuildingName_txt";
            // 
            // BuildingCode_lbl
            // 
            resources.ApplyResources(this.BuildingCode_lbl, "BuildingCode_lbl");
            this.BuildingCode_lbl.ControlId = null;
            this.BuildingCode_lbl.Name = "BuildingCode_lbl";
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
            // Building_dgv
            // 
            this.Building_dgv.AllowUserToAddRows = false;
            this.Building_dgv.AllowUserToDeleteRows = false;
            this.Building_dgv.AllowUserToOrderColumns = true;
            this.Building_dgv.AllowUserToResizeRows = false;
            resources.ApplyResources(this.Building_dgv, "Building_dgv");
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(232)))), ((int)(((byte)(180)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.Building_dgv.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.Building_dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Building_dgv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colBuildingId,
            this.colBuildingCode,
            this.colBuildingName,
            this.colFactoryCode});
            this.Building_dgv.ControlId = null;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.Building_dgv.DefaultCellStyle = dataGridViewCellStyle2;
            this.Building_dgv.EnableHeadersVisualStyles = false;
            this.Building_dgv.MultiSelect = false;
            this.Building_dgv.Name = "Building_dgv";
            this.Building_dgv.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(232)))), ((int)(((byte)(180)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.Building_dgv.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.Building_dgv.RowHeadersVisible = false;
            this.Building_dgv.RowTemplate.Height = 21;
            this.Building_dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.Building_dgv.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Building_dgv_CellClick);
            this.Building_dgv.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Building_dgv_CellDoubleClick);
            // 
            // colBuildingId
            // 
            this.colBuildingId.DataPropertyName = "BuildingId";
            resources.ApplyResources(this.colBuildingId, "colBuildingId");
            this.colBuildingId.Name = "colBuildingId";
            this.colBuildingId.ReadOnly = true;
            // 
            // colBuildingCode
            // 
            this.colBuildingCode.DataPropertyName = "BuildingCode";
            resources.ApplyResources(this.colBuildingCode, "colBuildingCode");
            this.colBuildingCode.Name = "colBuildingCode";
            this.colBuildingCode.ReadOnly = true;
            // 
            // colBuildingName
            // 
            this.colBuildingName.DataPropertyName = "BuildingName";
            resources.ApplyResources(this.colBuildingName, "colBuildingName");
            this.colBuildingName.Name = "colBuildingName";
            this.colBuildingName.ReadOnly = true;
            // 
            // colFactoryCode
            // 
            this.colFactoryCode.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colFactoryCode.DataPropertyName = "FactoryCode";
            resources.ApplyResources(this.colFactoryCode, "colFactoryCode");
            this.colFactoryCode.Name = "colFactoryCode";
            this.colFactoryCode.ReadOnly = true;
            // 
            // FactoryCode_cmb
            // 
            this.FactoryCode_cmb.ControlId = null;
            resources.ApplyResources(this.FactoryCode_cmb, "FactoryCode_cmb");
            this.FactoryCode_cmb.FormattingEnabled = true;
            this.FactoryCode_cmb.Name = "FactoryCode_cmb";
            // 
            // Factory_lbl
            // 
            resources.ApplyResources(this.Factory_lbl, "Factory_lbl");
            this.Factory_lbl.ControlId = null;
            this.Factory_lbl.Name = "Factory_lbl";
            // 
            // BuildingForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ControlId = "bpmf019";
            this.Controls.Add(this.FactoryCode_cmb);
            this.Controls.Add(this.Factory_lbl);
            this.Controls.Add(this.BuildingCode_txt);
            this.Controls.Add(this.BuildingName_lbl);
            this.Controls.Add(this.BuildingName_txt);
            this.Controls.Add(this.BuildingCode_lbl);
            this.Controls.Add(this.Clear_btn);
            this.Controls.Add(this.Exit_btn);
            this.Controls.Add(this.Delete_btn);
            this.Controls.Add(this.Update_btn);
            this.Controls.Add(this.Add_btn);
            this.Controls.Add(this.Search_btn);
            this.Controls.Add(this.Building_dgv);
            this.Name = "BuildingForm";
            this.TitleText = "FormCommon";
            this.Load += new System.EventHandler(this.BuildingForm_Load);
            this.Controls.SetChildIndex(this.Building_dgv, 0);
            this.Controls.SetChildIndex(this.Search_btn, 0);
            this.Controls.SetChildIndex(this.Add_btn, 0);
            this.Controls.SetChildIndex(this.Update_btn, 0);
            this.Controls.SetChildIndex(this.Delete_btn, 0);
            this.Controls.SetChildIndex(this.Exit_btn, 0);
            this.Controls.SetChildIndex(this.Clear_btn, 0);
            this.Controls.SetChildIndex(this.BuildingCode_lbl, 0);
            this.Controls.SetChildIndex(this.BuildingName_txt, 0);
            this.Controls.SetChildIndex(this.BuildingName_lbl, 0);
            this.Controls.SetChildIndex(this.BuildingCode_txt, 0);
            this.Controls.SetChildIndex(this.Factory_lbl, 0);
            this.Controls.SetChildIndex(this.FactoryCode_cmb, 0);
            ((System.ComponentModel.ISupportInitialize)(this.Building_dgv)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Com.Nidec.Mes.Framework.TextBoxCommon BuildingCode_txt;
        private Com.Nidec.Mes.Framework.LabelCommon BuildingName_lbl;
        private Com.Nidec.Mes.Framework.TextBoxCommon BuildingName_txt;
        private Com.Nidec.Mes.Framework.LabelCommon BuildingCode_lbl;
        private Com.Nidec.Mes.Framework.ButtonCommon Clear_btn;
        private Com.Nidec.Mes.Framework.ButtonCommon Exit_btn;
        private Com.Nidec.Mes.Framework.ButtonCommon Delete_btn;
        private Com.Nidec.Mes.Framework.ButtonCommon Update_btn;
        private Com.Nidec.Mes.Framework.ButtonCommon Add_btn;
        private Com.Nidec.Mes.Framework.ButtonCommon Search_btn;
        internal Com.Nidec.Mes.Framework.DataGridViewCommon Building_dgv;
        private Framework.ComboBoxCommon FactoryCode_cmb;
        private Framework.LabelCommon Factory_lbl;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBuildingId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBuildingCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBuildingName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFactoryCode;
    }
}