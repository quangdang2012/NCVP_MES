namespace Com.Nidec.Mes.Framework_Batch
{
    partial class ChangeBatchProcessStatusForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChangeBatchProcessStatusForm));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.Basic = new Com.Nidec.Mes.Framework.PanelCommon();
            this.Status_dgv = new Com.Nidec.Mes.Framework.DataGridViewCommon();
            this.CurrentStasus_lbl = new Com.Nidec.Mes.Framework.LabelCommon();
            this.Refresh_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.Exit_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.Revert_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.Delete_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.colStop = new System.Windows.Forms.DataGridViewButtonColumn();
            this.colStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colIsStopRequested = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBatchProcessID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBatchProcessCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colRegistrationUserCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colRegistrationDateTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Basic.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Status_dgv)).BeginInit();
            this.SuspendLayout();
            // 
            // Basic
            // 
            resources.ApplyResources(this.Basic, "Basic");
            this.Basic.ControlId = null;
            this.Basic.Controls.Add(this.Status_dgv);
            this.Basic.Controls.Add(this.CurrentStasus_lbl);
            this.Basic.Name = "Basic";
            // 
            // Status_dgv
            // 
            resources.ApplyResources(this.Status_dgv, "Status_dgv");
            this.Status_dgv.AllowUserToAddRows = false;
            this.Status_dgv.AllowUserToDeleteRows = false;
            this.Status_dgv.AllowUserToOrderColumns = true;
            this.Status_dgv.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(232)))), ((int)(((byte)(180)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial", 9F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.Status_dgv.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.Status_dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Status_dgv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colStop,
            this.colStatus,
            this.colIsStopRequested,
            this.colBatchProcessID,
            this.colBatchProcessCode,
            this.colRegistrationUserCode,
            this.colRegistrationDateTime});
            this.Status_dgv.ControlId = null;
            this.Status_dgv.EnableHeadersVisualStyles = false;
            this.Status_dgv.MultiSelect = false;
            this.Status_dgv.Name = "Status_dgv";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(232)))), ((int)(((byte)(180)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Arial", 9F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.Status_dgv.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.Status_dgv.RowHeadersVisible = false;
            this.Status_dgv.RowTemplate.Height = 21;
            this.Status_dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.Status_dgv.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Status_dgv_CellContentClick);
            // 
            // CurrentStasus_lbl
            // 
            resources.ApplyResources(this.CurrentStasus_lbl, "CurrentStasus_lbl");
            this.CurrentStasus_lbl.BackColor = System.Drawing.Color.LimeGreen;
            this.CurrentStasus_lbl.ControlId = null;
            this.CurrentStasus_lbl.Name = "CurrentStasus_lbl";
            // 
            // Refresh_btn
            // 
            resources.ApplyResources(this.Refresh_btn, "Refresh_btn");
            this.Refresh_btn.BackColor = System.Drawing.SystemColors.Control;
            this.Refresh_btn.ControlId = null;
            this.Refresh_btn.Name = "Refresh_btn";
            this.Refresh_btn.UseVisualStyleBackColor = false;
            this.Refresh_btn.Click += new System.EventHandler(this.Refresh_btn_Click);
            // 
            // Exit_btn
            // 
            resources.ApplyResources(this.Exit_btn, "Exit_btn");
            this.Exit_btn.BackColor = System.Drawing.SystemColors.Control;
            this.Exit_btn.ControlId = null;
            this.Exit_btn.Name = "Exit_btn";
            this.Exit_btn.UseVisualStyleBackColor = false;
            this.Exit_btn.Click += new System.EventHandler(this.Exit_btn_Click);
            // 
            // Revert_btn
            // 
            resources.ApplyResources(this.Revert_btn, "Revert_btn");
            this.Revert_btn.BackColor = System.Drawing.SystemColors.Control;
            this.Revert_btn.ControlId = null;
            this.Revert_btn.Name = "Revert_btn";
            this.Revert_btn.UseVisualStyleBackColor = false;
            this.Revert_btn.Click += new System.EventHandler(this.Revert_btn_Click);
            // 
            // Delete_btn
            // 
            resources.ApplyResources(this.Delete_btn, "Delete_btn");
            this.Delete_btn.BackColor = System.Drawing.SystemColors.Control;
            this.Delete_btn.ControlId = null;
            this.Delete_btn.Name = "Delete_btn";
            this.Delete_btn.UseVisualStyleBackColor = false;
            this.Delete_btn.Click += new System.EventHandler(this.Delete_btn_Click);
            // 
            // colStop
            // 
            this.colStop.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
            this.colStop.DataPropertyName = "Stop";
            resources.ApplyResources(this.colStop, "colStop");
            this.colStop.Name = "colStop";
            this.colStop.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colStop.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.colStop.Text = "Stop";
            this.colStop.UseColumnTextForButtonValue = true;
            // 
            // colStatus
            // 
            this.colStatus.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colStatus.DataPropertyName = "Status";
            resources.ApplyResources(this.colStatus, "colStatus");
            this.colStatus.Name = "colStatus";
            this.colStatus.ReadOnly = true;
            // 
            // colIsStopRequested
            // 
            this.colIsStopRequested.DataPropertyName = "IsStopRequested";
            resources.ApplyResources(this.colIsStopRequested, "colIsStopRequested");
            this.colIsStopRequested.Name = "colIsStopRequested";
            this.colIsStopRequested.ReadOnly = true;
            // 
            // colBatchProcessID
            // 
            this.colBatchProcessID.DataPropertyName = "BatchProcessID";
            resources.ApplyResources(this.colBatchProcessID, "colBatchProcessID");
            this.colBatchProcessID.Name = "colBatchProcessID";
            this.colBatchProcessID.ReadOnly = true;
            // 
            // colBatchProcessCode
            // 
            this.colBatchProcessCode.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colBatchProcessCode.DataPropertyName = "BatchProcessCode";
            resources.ApplyResources(this.colBatchProcessCode, "colBatchProcessCode");
            this.colBatchProcessCode.Name = "colBatchProcessCode";
            this.colBatchProcessCode.ReadOnly = true;
            // 
            // colRegistrationUserCode
            // 
            this.colRegistrationUserCode.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colRegistrationUserCode.DataPropertyName = "RegistrationUserCode";
            resources.ApplyResources(this.colRegistrationUserCode, "colRegistrationUserCode");
            this.colRegistrationUserCode.Name = "colRegistrationUserCode";
            this.colRegistrationUserCode.ReadOnly = true;
            // 
            // colRegistrationDateTime
            // 
            this.colRegistrationDateTime.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colRegistrationDateTime.DataPropertyName = "RegistrationDateTime";
            resources.ApplyResources(this.colRegistrationDateTime, "colRegistrationDateTime");
            this.colRegistrationDateTime.Name = "colRegistrationDateTime";
            this.colRegistrationDateTime.ReadOnly = true;
            // 
            // ChangeBatchProcessStatusForm
            // 
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.Refresh_btn);
            this.Controls.Add(this.Delete_btn);
            this.Controls.Add(this.Revert_btn);
            this.Controls.Add(this.Exit_btn);
            this.Controls.Add(this.Basic);
            this.Name = "ChangeBatchProcessStatusForm";
            this.TitleText = "批处理管理";
            this.Load += new System.EventHandler(this.ChangeBatchProcessStatusForm_Load);
            this.Controls.SetChildIndex(this.Basic, 0);
            this.Controls.SetChildIndex(this.Exit_btn, 0);
            this.Controls.SetChildIndex(this.Revert_btn, 0);
            this.Controls.SetChildIndex(this.Delete_btn, 0);
            this.Controls.SetChildIndex(this.Refresh_btn, 0);
            this.Basic.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Status_dgv)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Framework.PanelCommon Basic;
        private Framework.DataGridViewCommon Status_dgv;
        private Framework.LabelCommon CurrentStasus_lbl;
        private Framework.ButtonCommon Exit_btn;
        private Framework.ButtonCommon Revert_btn;
        private Framework.ButtonCommon Delete_btn;
        private Framework.ButtonCommon Refresh_btn;
        private System.Windows.Forms.DataGridViewButtonColumn colStop;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIsStopRequested;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBatchProcessID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBatchProcessCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRegistrationUserCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRegistrationDateTime;
    }
}
