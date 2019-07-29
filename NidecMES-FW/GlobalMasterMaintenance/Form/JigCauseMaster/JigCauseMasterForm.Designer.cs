namespace Com.Nidec.Mes.GlobalMasterMaintenance
{
    partial class JigCauseMasterForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(JigCauseMasterForm));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.JigCauseCode_txt = new Com.Nidec.Mes.Framework.TextBoxCommon();
            this.JigCauseName_lbl = new Com.Nidec.Mes.Framework.LabelCommon();
            this.JigCauseName_txt = new Com.Nidec.Mes.Framework.TextBoxCommon();
            this.JigCauseCode_lbl = new Com.Nidec.Mes.Framework.LabelCommon();
            this.Clear_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.Exit_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.Delete_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.Update_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.Add_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.Search_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.JigCause_dgv = new Com.Nidec.Mes.Framework.DataGridViewCommon();
            this.colJigCauseId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colJigCauseCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colJigCauseName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.JigCause_dgv)).BeginInit();
            this.SuspendLayout();
            // 
            // JigCauseCode_txt
            // 
            this.JigCauseCode_txt.ControlId = null;
            resources.ApplyResources(this.JigCauseCode_txt, "JigCauseCode_txt");
            this.JigCauseCode_txt.InputType = Com.Nidec.Mes.Framework.TextBoxCommon.InputTypeList.All;
            this.JigCauseCode_txt.Name = "JigCauseCode_txt";
            // 
            // JigCauseName_lbl
            // 
            resources.ApplyResources(this.JigCauseName_lbl, "JigCauseName_lbl");
            this.JigCauseName_lbl.ControlId = null;
            this.JigCauseName_lbl.Name = "JigCauseName_lbl";
            // 
            // JigCauseName_txt
            // 
            this.JigCauseName_txt.ControlId = null;
            resources.ApplyResources(this.JigCauseName_txt, "JigCauseName_txt");
            this.JigCauseName_txt.InputType = Com.Nidec.Mes.Framework.TextBoxCommon.InputTypeList.All;
            this.JigCauseName_txt.Name = "JigCauseName_txt";
            // 
            // JigCauseCode_lbl
            // 
            resources.ApplyResources(this.JigCauseCode_lbl, "JigCauseCode_lbl");
            this.JigCauseCode_lbl.ControlId = null;
            this.JigCauseCode_lbl.Name = "JigCauseCode_lbl";
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
            // JigCause_dgv
            // 
            this.JigCause_dgv.AllowUserToAddRows = false;
            this.JigCause_dgv.AllowUserToDeleteRows = false;
            this.JigCause_dgv.AllowUserToOrderColumns = true;
            this.JigCause_dgv.AllowUserToResizeRows = false;
            resources.ApplyResources(this.JigCause_dgv, "JigCause_dgv");
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(232)))), ((int)(((byte)(180)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.JigCause_dgv.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.JigCause_dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.JigCause_dgv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colJigCauseId,
            this.colJigCauseCode,
            this.colJigCauseName});
            this.JigCause_dgv.ControlId = null;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.JigCause_dgv.DefaultCellStyle = dataGridViewCellStyle2;
            this.JigCause_dgv.EnableHeadersVisualStyles = false;
            this.JigCause_dgv.MultiSelect = false;
            this.JigCause_dgv.Name = "JigCause_dgv";
            this.JigCause_dgv.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(232)))), ((int)(((byte)(180)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.JigCause_dgv.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.JigCause_dgv.RowHeadersVisible = false;
            this.JigCause_dgv.RowTemplate.Height = 21;
            this.JigCause_dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.JigCause_dgv.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.JigCause_dgv_CellClick);
            this.JigCause_dgv.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.JigCause_dgv_CellDoubleClick);
            // 
            // colJigCauseId
            // 
            this.colJigCauseId.DataPropertyName = "JigCauseId";
            resources.ApplyResources(this.colJigCauseId, "colJigCauseId");
            this.colJigCauseId.Name = "colJigCauseId";
            this.colJigCauseId.ReadOnly = true;
            // 
            // colJigCauseCode
            // 
            this.colJigCauseCode.DataPropertyName = "JigCauseCode";
            resources.ApplyResources(this.colJigCauseCode, "colJigCauseCode");
            this.colJigCauseCode.Name = "colJigCauseCode";
            this.colJigCauseCode.ReadOnly = true;
            // 
            // colJigCauseName
            // 
            this.colJigCauseName.DataPropertyName = "JigCauseName";
            resources.ApplyResources(this.colJigCauseName, "colJigCauseName");
            this.colJigCauseName.Name = "colJigCauseName";
            this.colJigCauseName.ReadOnly = true;
            // 
            // JigCauseMasterForm
            // 
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.JigCauseCode_txt);
            this.Controls.Add(this.JigCauseName_lbl);
            this.Controls.Add(this.JigCauseName_txt);
            this.Controls.Add(this.JigCauseCode_lbl);
            this.Controls.Add(this.Clear_btn);
            this.Controls.Add(this.Exit_btn);
            this.Controls.Add(this.Delete_btn);
            this.Controls.Add(this.Update_btn);
            this.Controls.Add(this.Add_btn);
            this.Controls.Add(this.Search_btn);
            this.Controls.Add(this.JigCause_dgv);
            this.Name = "JigCauseMasterForm";
            this.TitleText = "FormCommon";
            this.Controls.SetChildIndex(this.JigCause_dgv, 0);
            this.Controls.SetChildIndex(this.Search_btn, 0);
            this.Controls.SetChildIndex(this.Add_btn, 0);
            this.Controls.SetChildIndex(this.Update_btn, 0);
            this.Controls.SetChildIndex(this.Delete_btn, 0);
            this.Controls.SetChildIndex(this.Exit_btn, 0);
            this.Controls.SetChildIndex(this.Clear_btn, 0);
            this.Controls.SetChildIndex(this.JigCauseCode_lbl, 0);
            this.Controls.SetChildIndex(this.JigCauseName_txt, 0);
            this.Controls.SetChildIndex(this.JigCauseName_lbl, 0);
            this.Controls.SetChildIndex(this.JigCauseCode_txt, 0);
            ((System.ComponentModel.ISupportInitialize)(this.JigCause_dgv)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Com.Nidec.Mes.Framework.TextBoxCommon JigCauseCode_txt;
        private Com.Nidec.Mes.Framework.LabelCommon JigCauseName_lbl;
        private Com.Nidec.Mes.Framework.TextBoxCommon JigCauseName_txt;
        private Com.Nidec.Mes.Framework.LabelCommon JigCauseCode_lbl;
        private Com.Nidec.Mes.Framework.ButtonCommon Clear_btn;
        private Com.Nidec.Mes.Framework.ButtonCommon Exit_btn;
        private Com.Nidec.Mes.Framework.ButtonCommon Delete_btn;
        private Com.Nidec.Mes.Framework.ButtonCommon Update_btn;
        private Com.Nidec.Mes.Framework.ButtonCommon Add_btn;
        private Com.Nidec.Mes.Framework.ButtonCommon Search_btn;
        internal Com.Nidec.Mes.Framework.DataGridViewCommon JigCause_dgv;
        private System.Windows.Forms.DataGridViewTextBoxColumn colJigCauseId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colJigCauseCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn colJigCauseName;
    }
}
