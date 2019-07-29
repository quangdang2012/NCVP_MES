namespace Com.Nidec.Mes.GlobalMasterMaintenance
{
    partial class ProcessForm:FormCommonMaster
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProcessForm));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.Clear_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.Exit_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.Delete_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.Update_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.Add_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.Search_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.Process_dgv = new Com.Nidec.Mes.Framework.DataGridViewCommon();
            this.ProcessCode_txt = new Com.Nidec.Mes.Framework.TextBoxCommon();
            this.ProcessName_lbl = new Com.Nidec.Mes.Framework.LabelCommon();
            this.ProcessName_txt = new Com.Nidec.Mes.Framework.TextBoxCommon();
            this.ProcessCode_lbl = new Com.Nidec.Mes.Framework.LabelCommon();
            this.colProcessId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colProcessCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colProcessName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.Process_dgv)).BeginInit();
            this.SuspendLayout();
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
            // Process_dgv
            // 
            resources.ApplyResources(this.Process_dgv, "Process_dgv");
            this.Process_dgv.AllowUserToAddRows = false;
            this.Process_dgv.AllowUserToDeleteRows = false;
            this.Process_dgv.AllowUserToOrderColumns = true;
            this.Process_dgv.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(232)))), ((int)(((byte)(180)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.Process_dgv.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.Process_dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Process_dgv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colProcessId,
            this.colProcessCode,
            this.colProcessName});
            this.Process_dgv.ControlId = null;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.Process_dgv.DefaultCellStyle = dataGridViewCellStyle2;
            this.Process_dgv.EnableHeadersVisualStyles = false;
            this.Process_dgv.MultiSelect = false;
            this.Process_dgv.Name = "Process_dgv";
            this.Process_dgv.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(232)))), ((int)(((byte)(180)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.Process_dgv.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.Process_dgv.RowHeadersVisible = false;
            this.Process_dgv.RowTemplate.Height = 21;
            this.Process_dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.Process_dgv.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Process_dgv_CellClick);
            this.Process_dgv.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Process_dgv_CellDoubleClick);
            this.Process_dgv.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.Process_dgv_ColumnHeaderMouseClick);
            // 
            // ProcessCode_txt
            // 
            resources.ApplyResources(this.ProcessCode_txt, "ProcessCode_txt");
            this.ProcessCode_txt.ControlId = null;
            this.ProcessCode_txt.InputType = Com.Nidec.Mes.Framework.TextBoxCommon.InputTypeList.All;
            this.ProcessCode_txt.Name = "ProcessCode_txt";
            // 
            // ProcessName_lbl
            // 
            resources.ApplyResources(this.ProcessName_lbl, "ProcessName_lbl");
            this.ProcessName_lbl.ControlId = null;
            this.ProcessName_lbl.Name = "ProcessName_lbl";
            // 
            // ProcessName_txt
            // 
            resources.ApplyResources(this.ProcessName_txt, "ProcessName_txt");
            this.ProcessName_txt.ControlId = null;
            this.ProcessName_txt.InputType = Com.Nidec.Mes.Framework.TextBoxCommon.InputTypeList.All;
            this.ProcessName_txt.Name = "ProcessName_txt";
            // 
            // ProcessCode_lbl
            // 
            resources.ApplyResources(this.ProcessCode_lbl, "ProcessCode_lbl");
            this.ProcessCode_lbl.ControlId = null;
            this.ProcessCode_lbl.Name = "ProcessCode_lbl";
            // 
            // colProcessId
            // 
            this.colProcessId.DataPropertyName = "ProcessId";
            resources.ApplyResources(this.colProcessId, "colProcessId");
            this.colProcessId.Name = "colProcessId";
            this.colProcessId.ReadOnly = true;
            // 
            // colProcessCode
            // 
            this.colProcessCode.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colProcessCode.DataPropertyName = "ProcessCode";
            resources.ApplyResources(this.colProcessCode, "colProcessCode");
            this.colProcessCode.Name = "colProcessCode";
            this.colProcessCode.ReadOnly = true;
            // 
            // colProcessName
            // 
            this.colProcessName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colProcessName.DataPropertyName = "ProcessName";
            resources.ApplyResources(this.colProcessName, "colProcessName");
            this.colProcessName.Name = "colProcessName";
            this.colProcessName.ReadOnly = true;
            // 
            // ProcessForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ControlId = "bpmf014";
            this.Controls.Add(this.ProcessCode_txt);
            this.Controls.Add(this.ProcessName_lbl);
            this.Controls.Add(this.ProcessName_txt);
            this.Controls.Add(this.ProcessCode_lbl);
            this.Controls.Add(this.Clear_btn);
            this.Controls.Add(this.Exit_btn);
            this.Controls.Add(this.Delete_btn);
            this.Controls.Add(this.Update_btn);
            this.Controls.Add(this.Add_btn);
            this.Controls.Add(this.Search_btn);
            this.Controls.Add(this.Process_dgv);
            this.Name = "ProcessForm";
            this.TitleText = "FormCommon";
            this.Load += new System.EventHandler(this.ProcessForm_Load);
            this.Controls.SetChildIndex(this.Process_dgv, 0);
            this.Controls.SetChildIndex(this.Search_btn, 0);
            this.Controls.SetChildIndex(this.Add_btn, 0);
            this.Controls.SetChildIndex(this.Update_btn, 0);
            this.Controls.SetChildIndex(this.Delete_btn, 0);
            this.Controls.SetChildIndex(this.Exit_btn, 0);
            this.Controls.SetChildIndex(this.Clear_btn, 0);
            this.Controls.SetChildIndex(this.ProcessCode_lbl, 0);
            this.Controls.SetChildIndex(this.ProcessName_txt, 0);
            this.Controls.SetChildIndex(this.ProcessName_lbl, 0);
            this.Controls.SetChildIndex(this.ProcessCode_txt, 0);
            ((System.ComponentModel.ISupportInitialize)(this.Process_dgv)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Com.Nidec.Mes.Framework.ButtonCommon Clear_btn;
        private Com.Nidec.Mes.Framework.ButtonCommon Exit_btn;
        private Com.Nidec.Mes.Framework.ButtonCommon Delete_btn;
        private Com.Nidec.Mes.Framework.ButtonCommon Update_btn;
        private Com.Nidec.Mes.Framework.ButtonCommon Add_btn;
        private Com.Nidec.Mes.Framework.ButtonCommon Search_btn;
        internal Com.Nidec.Mes.Framework.DataGridViewCommon Process_dgv;
        private Com.Nidec.Mes.Framework.TextBoxCommon ProcessCode_txt;
        private Com.Nidec.Mes.Framework.LabelCommon ProcessName_lbl;
        private Com.Nidec.Mes.Framework.TextBoxCommon ProcessName_txt;
        private Com.Nidec.Mes.Framework.LabelCommon ProcessCode_lbl;
        private System.Windows.Forms.DataGridViewTextBoxColumn colProcessId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colProcessCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn colProcessName;
    }
}