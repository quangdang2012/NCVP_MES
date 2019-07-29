namespace Com.Nidec.Mes.GlobalMasterMaintenance
{
    partial class DrawMasterForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DrawMasterForm));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.DrawCode_txt = new Com.Nidec.Mes.Framework.TextBoxCommon();
            this.DrawName_lbl = new Com.Nidec.Mes.Framework.LabelCommon();
            this.DrawName_txt = new Com.Nidec.Mes.Framework.TextBoxCommon();
            this.DrawCode_lbl = new Com.Nidec.Mes.Framework.LabelCommon();
            this.Clear_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.Exit_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.Delete_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.Update_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.Add_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.Search_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.Draw_dgv = new Com.Nidec.Mes.Framework.DataGridViewCommon();
            this.colDrawId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDrawCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDrawName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.Draw_dgv)).BeginInit();
            this.SuspendLayout();
            // 
            // DrawCode_txt
            // 
            this.DrawCode_txt.ControlId = null;
            resources.ApplyResources(this.DrawCode_txt, "DrawCode_txt");
            this.DrawCode_txt.InputType = Com.Nidec.Mes.Framework.TextBoxCommon.InputTypeList.All;
            this.DrawCode_txt.Name = "DrawCode_txt";
            // 
            // DrawName_lbl
            // 
            resources.ApplyResources(this.DrawName_lbl, "DrawName_lbl");
            this.DrawName_lbl.ControlId = null;
            this.DrawName_lbl.Name = "DrawName_lbl";
            // 
            // DrawName_txt
            // 
            this.DrawName_txt.ControlId = null;
            resources.ApplyResources(this.DrawName_txt, "DrawName_txt");
            this.DrawName_txt.InputType = Com.Nidec.Mes.Framework.TextBoxCommon.InputTypeList.All;
            this.DrawName_txt.Name = "DrawName_txt";
            // 
            // DrawCode_lbl
            // 
            resources.ApplyResources(this.DrawCode_lbl, "DrawCode_lbl");
            this.DrawCode_lbl.ControlId = null;
            this.DrawCode_lbl.Name = "DrawCode_lbl";
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
            // Draw_dgv
            // 
            this.Draw_dgv.AllowUserToAddRows = false;
            this.Draw_dgv.AllowUserToDeleteRows = false;
            this.Draw_dgv.AllowUserToOrderColumns = true;
            this.Draw_dgv.AllowUserToResizeRows = false;
            resources.ApplyResources(this.Draw_dgv, "Draw_dgv");
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(232)))), ((int)(((byte)(180)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.Draw_dgv.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.Draw_dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Draw_dgv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colDrawId,
            this.colDrawCode,
            this.colDrawName});
            this.Draw_dgv.ControlId = null;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.Draw_dgv.DefaultCellStyle = dataGridViewCellStyle2;
            this.Draw_dgv.EnableHeadersVisualStyles = false;
            this.Draw_dgv.MultiSelect = false;
            this.Draw_dgv.Name = "Draw_dgv";
            this.Draw_dgv.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(232)))), ((int)(((byte)(180)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.Draw_dgv.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.Draw_dgv.RowHeadersVisible = false;
            this.Draw_dgv.RowTemplate.Height = 21;
            this.Draw_dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.Draw_dgv.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Machine_dgv_CellClick);
            this.Draw_dgv.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Machine_dgv_CellDoubleClick);
            // 
            // colDrawId
            // 
            this.colDrawId.DataPropertyName = "DrawId";
            resources.ApplyResources(this.colDrawId, "colDrawId");
            this.colDrawId.Name = "colDrawId";
            this.colDrawId.ReadOnly = true;
            // 
            // colDrawCode
            // 
            this.colDrawCode.DataPropertyName = "DrawCode";
            resources.ApplyResources(this.colDrawCode, "colDrawCode");
            this.colDrawCode.Name = "colDrawCode";
            this.colDrawCode.ReadOnly = true;
            // 
            // colDrawName
            // 
            this.colDrawName.DataPropertyName = "DrawName";
            resources.ApplyResources(this.colDrawName, "colDrawName");
            this.colDrawName.Name = "colDrawName";
            this.colDrawName.ReadOnly = true;
            // 
            // DrawMasterForm
            // 
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.DrawCode_txt);
            this.Controls.Add(this.DrawName_lbl);
            this.Controls.Add(this.DrawName_txt);
            this.Controls.Add(this.DrawCode_lbl);
            this.Controls.Add(this.Clear_btn);
            this.Controls.Add(this.Exit_btn);
            this.Controls.Add(this.Delete_btn);
            this.Controls.Add(this.Update_btn);
            this.Controls.Add(this.Add_btn);
            this.Controls.Add(this.Search_btn);
            this.Controls.Add(this.Draw_dgv);
            this.Name = "DrawMasterForm";
            this.TitleText = "FormCommon";
            this.Controls.SetChildIndex(this.Draw_dgv, 0);
            this.Controls.SetChildIndex(this.Search_btn, 0);
            this.Controls.SetChildIndex(this.Add_btn, 0);
            this.Controls.SetChildIndex(this.Update_btn, 0);
            this.Controls.SetChildIndex(this.Delete_btn, 0);
            this.Controls.SetChildIndex(this.Exit_btn, 0);
            this.Controls.SetChildIndex(this.Clear_btn, 0);
            this.Controls.SetChildIndex(this.DrawCode_lbl, 0);
            this.Controls.SetChildIndex(this.DrawName_txt, 0);
            this.Controls.SetChildIndex(this.DrawName_lbl, 0);
            this.Controls.SetChildIndex(this.DrawCode_txt, 0);
            ((System.ComponentModel.ISupportInitialize)(this.Draw_dgv)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Com.Nidec.Mes.Framework.TextBoxCommon DrawCode_txt;
        private Com.Nidec.Mes.Framework.LabelCommon DrawName_lbl;
        private Com.Nidec.Mes.Framework.TextBoxCommon DrawName_txt;
        private Com.Nidec.Mes.Framework.LabelCommon DrawCode_lbl;
        private Com.Nidec.Mes.Framework.ButtonCommon Clear_btn;
        private Com.Nidec.Mes.Framework.ButtonCommon Exit_btn;
        private Com.Nidec.Mes.Framework.ButtonCommon Delete_btn;
        private Com.Nidec.Mes.Framework.ButtonCommon Update_btn;
        private Com.Nidec.Mes.Framework.ButtonCommon Add_btn;
        private Com.Nidec.Mes.Framework.ButtonCommon Search_btn;
        internal Com.Nidec.Mes.Framework.DataGridViewCommon Draw_dgv;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDrawId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDrawCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDrawName;
    }
}
