namespace Com.Nidec.Mes.GlobalMasterMaintenance
{
    partial class JigResponseMasterForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(JigResponseMasterForm));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.JigResponseCode_txt = new Com.Nidec.Mes.Framework.TextBoxCommon();
            this.JigResponseName_lbl = new Com.Nidec.Mes.Framework.LabelCommon();
            this.JigResponseName_txt = new Com.Nidec.Mes.Framework.TextBoxCommon();
            this.JigResponseCode_lbl = new Com.Nidec.Mes.Framework.LabelCommon();
            this.Clear_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.Exit_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.Delete_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.Update_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.Add_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.Search_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.JigResponse_dgv = new Com.Nidec.Mes.Framework.DataGridViewCommon();
            this.colJigResponseId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colJigResponseCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colJigResponseName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.JigResponse_dgv)).BeginInit();
            this.SuspendLayout();
            // 
            // JigResponseCode_txt
            // 
            this.JigResponseCode_txt.ControlId = null;
            resources.ApplyResources(this.JigResponseCode_txt, "JigResponseCode_txt");
            this.JigResponseCode_txt.InputType = Com.Nidec.Mes.Framework.TextBoxCommon.InputTypeList.All;
            this.JigResponseCode_txt.Name = "JigResponseCode_txt";
            // 
            // JigResponseName_lbl
            // 
            resources.ApplyResources(this.JigResponseName_lbl, "JigResponseName_lbl");
            this.JigResponseName_lbl.ControlId = null;
            this.JigResponseName_lbl.Name = "JigResponseName_lbl";
            // 
            // JigResponseName_txt
            // 
            this.JigResponseName_txt.ControlId = null;
            resources.ApplyResources(this.JigResponseName_txt, "JigResponseName_txt");
            this.JigResponseName_txt.InputType = Com.Nidec.Mes.Framework.TextBoxCommon.InputTypeList.All;
            this.JigResponseName_txt.Name = "JigResponseName_txt";
            // 
            // JigResponseCode_lbl
            // 
            resources.ApplyResources(this.JigResponseCode_lbl, "JigResponseCode_lbl");
            this.JigResponseCode_lbl.ControlId = null;
            this.JigResponseCode_lbl.Name = "JigResponseCode_lbl";
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
            // JigResponse_dgv
            // 
            this.JigResponse_dgv.AllowUserToAddRows = false;
            this.JigResponse_dgv.AllowUserToDeleteRows = false;
            this.JigResponse_dgv.AllowUserToOrderColumns = true;
            this.JigResponse_dgv.AllowUserToResizeRows = false;
            resources.ApplyResources(this.JigResponse_dgv, "JigResponse_dgv");
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(232)))), ((int)(((byte)(180)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.JigResponse_dgv.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.JigResponse_dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.JigResponse_dgv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colJigResponseId,
            this.colJigResponseCode,
            this.colJigResponseName});
            this.JigResponse_dgv.ControlId = null;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.JigResponse_dgv.DefaultCellStyle = dataGridViewCellStyle2;
            this.JigResponse_dgv.EnableHeadersVisualStyles = false;
            this.JigResponse_dgv.MultiSelect = false;
            this.JigResponse_dgv.Name = "JigResponse_dgv";
            this.JigResponse_dgv.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(232)))), ((int)(((byte)(180)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.JigResponse_dgv.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.JigResponse_dgv.RowHeadersVisible = false;
            this.JigResponse_dgv.RowTemplate.Height = 21;
            this.JigResponse_dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.JigResponse_dgv.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.JigResponse_dgv_CellClick);
            this.JigResponse_dgv.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.JigResponse_dgv_CellDoubleClick);
            // 
            // colJigResponseId
            // 
            this.colJigResponseId.DataPropertyName = "JigResponseId";
            resources.ApplyResources(this.colJigResponseId, "colJigResponseId");
            this.colJigResponseId.Name = "colJigResponseId";
            this.colJigResponseId.ReadOnly = true;
            // 
            // colJigResponseCode
            // 
            this.colJigResponseCode.DataPropertyName = "JigResponseCode";
            resources.ApplyResources(this.colJigResponseCode, "colJigResponseCode");
            this.colJigResponseCode.Name = "colJigResponseCode";
            this.colJigResponseCode.ReadOnly = true;
            // 
            // colJigResponseName
            // 
            this.colJigResponseName.DataPropertyName = "JigResponseName";
            resources.ApplyResources(this.colJigResponseName, "colJigResponseName");
            this.colJigResponseName.Name = "colJigResponseName";
            this.colJigResponseName.ReadOnly = true;
            // 
            // JigResponseMasterForm
            // 
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.JigResponseCode_txt);
            this.Controls.Add(this.JigResponseName_lbl);
            this.Controls.Add(this.JigResponseName_txt);
            this.Controls.Add(this.JigResponseCode_lbl);
            this.Controls.Add(this.Clear_btn);
            this.Controls.Add(this.Exit_btn);
            this.Controls.Add(this.Delete_btn);
            this.Controls.Add(this.Update_btn);
            this.Controls.Add(this.Add_btn);
            this.Controls.Add(this.Search_btn);
            this.Controls.Add(this.JigResponse_dgv);
            this.Name = "JigResponseMasterForm";
            this.TitleText = "FormCommon";
            this.Controls.SetChildIndex(this.JigResponse_dgv, 0);
            this.Controls.SetChildIndex(this.Search_btn, 0);
            this.Controls.SetChildIndex(this.Add_btn, 0);
            this.Controls.SetChildIndex(this.Update_btn, 0);
            this.Controls.SetChildIndex(this.Delete_btn, 0);
            this.Controls.SetChildIndex(this.Exit_btn, 0);
            this.Controls.SetChildIndex(this.Clear_btn, 0);
            this.Controls.SetChildIndex(this.JigResponseCode_lbl, 0);
            this.Controls.SetChildIndex(this.JigResponseName_txt, 0);
            this.Controls.SetChildIndex(this.JigResponseName_lbl, 0);
            this.Controls.SetChildIndex(this.JigResponseCode_txt, 0);
            ((System.ComponentModel.ISupportInitialize)(this.JigResponse_dgv)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Com.Nidec.Mes.Framework.TextBoxCommon JigResponseCode_txt;
        private Com.Nidec.Mes.Framework.LabelCommon JigResponseName_lbl;
        private Com.Nidec.Mes.Framework.TextBoxCommon JigResponseName_txt;
        private Com.Nidec.Mes.Framework.LabelCommon JigResponseCode_lbl;
        private Com.Nidec.Mes.Framework.ButtonCommon Clear_btn;
        private Com.Nidec.Mes.Framework.ButtonCommon Exit_btn;
        private Com.Nidec.Mes.Framework.ButtonCommon Delete_btn;
        private Com.Nidec.Mes.Framework.ButtonCommon Update_btn;
        private Com.Nidec.Mes.Framework.ButtonCommon Add_btn;
        private Com.Nidec.Mes.Framework.ButtonCommon Search_btn;
        internal Com.Nidec.Mes.Framework.DataGridViewCommon JigResponse_dgv;
        private System.Windows.Forms.DataGridViewTextBoxColumn colJigResponseId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colJigResponseCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn colJigResponseName;
    }
}
