namespace Com.Nidec.Mes.GlobalMasterMaintenance
{
    partial class ShelfForm : FormCommonMaster
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ShelfForm));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.Area_lbl = new Com.Nidec.Mes.Framework.LabelCommon();
            this.Area_cmb = new Com.Nidec.Mes.Framework.ComboBoxCommon();
            this.ShelfCode_txt = new Com.Nidec.Mes.Framework.TextBoxCommon();
            this.ShelfName_lbl = new Com.Nidec.Mes.Framework.LabelCommon();
            this.ShelfName_txt = new Com.Nidec.Mes.Framework.TextBoxCommon();
            this.ShelfCode_lbl = new Com.Nidec.Mes.Framework.LabelCommon();
            this.Clear_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.Exit_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.Delete_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.Update_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.Add_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.Search_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.Shelf_dgv = new Com.Nidec.Mes.Framework.DataGridViewCommon();
            this.colShelfId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colShelfCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colShelfName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colArea = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAreaId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.Shelf_dgv)).BeginInit();
            this.SuspendLayout();
            // 
            // Area_lbl
            // 
            resources.ApplyResources(this.Area_lbl, "Area_lbl");
            this.Area_lbl.ControlId = null;
            this.Area_lbl.Name = "Area_lbl";
            // 
            // Area_cmb
            // 
            this.Area_cmb.ControlId = null;
            resources.ApplyResources(this.Area_cmb, "Area_cmb");
            this.Area_cmb.FormattingEnabled = true;
            this.Area_cmb.Name = "Area_cmb";
            // 
            // ShelfCode_txt
            // 
            this.ShelfCode_txt.ControlId = null;
            resources.ApplyResources(this.ShelfCode_txt, "ShelfCode_txt");
            this.ShelfCode_txt.InputType = Com.Nidec.Mes.Framework.TextBoxCommon.InputTypeList.All;
            this.ShelfCode_txt.Name = "ShelfCode_txt";
            // 
            // ShelfName_lbl
            // 
            resources.ApplyResources(this.ShelfName_lbl, "ShelfName_lbl");
            this.ShelfName_lbl.ControlId = null;
            this.ShelfName_lbl.Name = "ShelfName_lbl";
            // 
            // ShelfName_txt
            // 
            this.ShelfName_txt.ControlId = null;
            resources.ApplyResources(this.ShelfName_txt, "ShelfName_txt");
            this.ShelfName_txt.InputType = Com.Nidec.Mes.Framework.TextBoxCommon.InputTypeList.All;
            this.ShelfName_txt.Name = "ShelfName_txt";
            // 
            // ShelfCode_lbl
            // 
            resources.ApplyResources(this.ShelfCode_lbl, "ShelfCode_lbl");
            this.ShelfCode_lbl.ControlId = null;
            this.ShelfCode_lbl.Name = "ShelfCode_lbl";
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
            // Shelf_dgv
            // 
            this.Shelf_dgv.AllowUserToAddRows = false;
            this.Shelf_dgv.AllowUserToDeleteRows = false;
            this.Shelf_dgv.AllowUserToOrderColumns = true;
            this.Shelf_dgv.AllowUserToResizeRows = false;
            resources.ApplyResources(this.Shelf_dgv, "Shelf_dgv");
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(232)))), ((int)(((byte)(180)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.Shelf_dgv.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.Shelf_dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Shelf_dgv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colShelfId,
            this.colShelfCode,
            this.colShelfName,
            this.colArea,
            this.colAreaId});
            this.Shelf_dgv.ControlId = null;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.Shelf_dgv.DefaultCellStyle = dataGridViewCellStyle2;
            this.Shelf_dgv.EnableHeadersVisualStyles = false;
            this.Shelf_dgv.MultiSelect = false;
            this.Shelf_dgv.Name = "Shelf_dgv";
            this.Shelf_dgv.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(232)))), ((int)(((byte)(180)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.Shelf_dgv.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.Shelf_dgv.RowHeadersVisible = false;
            this.Shelf_dgv.RowTemplate.Height = 21;
            this.Shelf_dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.Shelf_dgv.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Shelf_dgv_CellClick);
            this.Shelf_dgv.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Shelf_dgv_CellDoubleClick);
            // 
            // colShelfId
            // 
            this.colShelfId.DataPropertyName = "ShelfId";
            resources.ApplyResources(this.colShelfId, "colShelfId");
            this.colShelfId.Name = "colShelfId";
            this.colShelfId.ReadOnly = true;
            // 
            // colShelfCode
            // 
            this.colShelfCode.DataPropertyName = "ShelfCode";
            resources.ApplyResources(this.colShelfCode, "colShelfCode");
            this.colShelfCode.Name = "colShelfCode";
            this.colShelfCode.ReadOnly = true;
            // 
            // colShelfName
            // 
            this.colShelfName.DataPropertyName = "ShelfName";
            resources.ApplyResources(this.colShelfName, "colShelfName");
            this.colShelfName.Name = "colShelfName";
            this.colShelfName.ReadOnly = true;
            // 
            // colArea
            // 
            this.colArea.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colArea.DataPropertyName = "AreaName";
            resources.ApplyResources(this.colArea, "colArea");
            this.colArea.Name = "colArea";
            this.colArea.ReadOnly = true;
            // 
            // colAreaId
            // 
            this.colAreaId.DataPropertyName = "AreaId";
            resources.ApplyResources(this.colAreaId, "colAreaId");
            this.colAreaId.Name = "colAreaId";
            this.colAreaId.ReadOnly = true;
            // 
            // ShelfForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ControlId = "bpmf019";
            this.Controls.Add(this.Area_lbl);
            this.Controls.Add(this.Area_cmb);
            this.Controls.Add(this.ShelfCode_txt);
            this.Controls.Add(this.ShelfName_lbl);
            this.Controls.Add(this.ShelfName_txt);
            this.Controls.Add(this.ShelfCode_lbl);
            this.Controls.Add(this.Clear_btn);
            this.Controls.Add(this.Exit_btn);
            this.Controls.Add(this.Delete_btn);
            this.Controls.Add(this.Update_btn);
            this.Controls.Add(this.Add_btn);
            this.Controls.Add(this.Search_btn);
            this.Controls.Add(this.Shelf_dgv);
            this.Name = "ShelfForm";
            this.TitleText = "FormCommon";
            this.Load += new System.EventHandler(this.ShelfForm_Load);
            this.Controls.SetChildIndex(this.Shelf_dgv, 0);
            this.Controls.SetChildIndex(this.Search_btn, 0);
            this.Controls.SetChildIndex(this.Add_btn, 0);
            this.Controls.SetChildIndex(this.Update_btn, 0);
            this.Controls.SetChildIndex(this.Delete_btn, 0);
            this.Controls.SetChildIndex(this.Exit_btn, 0);
            this.Controls.SetChildIndex(this.Clear_btn, 0);
            this.Controls.SetChildIndex(this.ShelfCode_lbl, 0);
            this.Controls.SetChildIndex(this.ShelfName_txt, 0);
            this.Controls.SetChildIndex(this.ShelfName_lbl, 0);
            this.Controls.SetChildIndex(this.ShelfCode_txt, 0);
            this.Controls.SetChildIndex(this.Area_cmb, 0);
            this.Controls.SetChildIndex(this.Area_lbl, 0);
            ((System.ComponentModel.ISupportInitialize)(this.Shelf_dgv)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Com.Nidec.Mes.Framework.LabelCommon Area_lbl;
        private Com.Nidec.Mes.Framework.ComboBoxCommon Area_cmb;
        private Com.Nidec.Mes.Framework.TextBoxCommon ShelfCode_txt;
        private Com.Nidec.Mes.Framework.LabelCommon ShelfName_lbl;
        private Com.Nidec.Mes.Framework.TextBoxCommon ShelfName_txt;
        private Com.Nidec.Mes.Framework.LabelCommon ShelfCode_lbl;
        private Com.Nidec.Mes.Framework.ButtonCommon Clear_btn;
        private Com.Nidec.Mes.Framework.ButtonCommon Exit_btn;
        private Com.Nidec.Mes.Framework.ButtonCommon Delete_btn;
        private Com.Nidec.Mes.Framework.ButtonCommon Update_btn;
        private Com.Nidec.Mes.Framework.ButtonCommon Add_btn;
        private Com.Nidec.Mes.Framework.ButtonCommon Search_btn;
        internal Com.Nidec.Mes.Framework.DataGridViewCommon Shelf_dgv;
        private System.Windows.Forms.DataGridViewTextBoxColumn colShelfId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colShelfCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn colShelfName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colArea;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAreaId;
    }
}