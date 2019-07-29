namespace Com.Nidec.Mes.Common.Basic.MachineMaintenance.Form.AccountWhForm.TranferForm
{
    partial class TranferInfoForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.Exit_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.TranferInfo_dgv = new Com.Nidec.Mes.Framework.DataGridViewCommon();
            this.colTransferId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTransferCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTransferContent = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colRequestUser = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTransferDept = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTranferStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTransferApprover = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDestinationDept = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDestinationStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDestiApprover = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colApproveStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAccounterApproved = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Search_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.Destination_cmb = new Com.Nidec.Mes.Framework.ComboBoxCommon();
            this.Destination_lbl = new Com.Nidec.Mes.Framework.LabelCommon();
            this.View_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            ((System.ComponentModel.ISupportInitialize)(this.TranferInfo_dgv)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Exit_btn
            // 
            this.Exit_btn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Exit_btn.BackColor = System.Drawing.SystemColors.Control;
            this.Exit_btn.ControlId = null;
            this.Exit_btn.Font = new System.Drawing.Font("Arial", 9F);
            this.Exit_btn.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.Exit_btn.Location = new System.Drawing.Point(829, 62);
            this.Exit_btn.Name = "Exit_btn";
            this.Exit_btn.Size = new System.Drawing.Size(80, 33);
            this.Exit_btn.TabIndex = 22;
            this.Exit_btn.Text = "Exit";
            this.Exit_btn.UseVisualStyleBackColor = true;
            this.Exit_btn.Click += new System.EventHandler(this.Exit_btn_Click);
            // 
            // TranferInfo_dgv
            // 
            this.TranferInfo_dgv.AllowUserToAddRows = false;
            this.TranferInfo_dgv.AllowUserToDeleteRows = false;
            this.TranferInfo_dgv.AllowUserToOrderColumns = true;
            this.TranferInfo_dgv.AllowUserToResizeRows = false;
            this.TranferInfo_dgv.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TranferInfo_dgv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(232)))), ((int)(((byte)(180)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.TranferInfo_dgv.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.TranferInfo_dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.TranferInfo_dgv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colTransferId,
            this.colTransferCode,
            this.colTransferContent,
            this.colRequestUser,
            this.colTransferDept,
            this.colTranferStatus,
            this.colTransferApprover,
            this.colDestinationDept,
            this.colDestinationStatus,
            this.colDestiApprover,
            this.colApproveStatus,
            this.colAccounterApproved});
            this.TranferInfo_dgv.ControlId = null;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.TranferInfo_dgv.DefaultCellStyle = dataGridViewCellStyle2;
            this.TranferInfo_dgv.EnableHeadersVisualStyles = false;
            this.TranferInfo_dgv.Location = new System.Drawing.Point(0, 215);
            this.TranferInfo_dgv.MultiSelect = false;
            this.TranferInfo_dgv.Name = "TranferInfo_dgv";
            this.TranferInfo_dgv.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(232)))), ((int)(((byte)(180)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.TranferInfo_dgv.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.TranferInfo_dgv.RowHeadersVisible = false;
            this.TranferInfo_dgv.RowTemplate.Height = 21;
            this.TranferInfo_dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.TranferInfo_dgv.Size = new System.Drawing.Size(968, 426);
            this.TranferInfo_dgv.TabIndex = 19;
            // 
            // colTransferId
            // 
            this.colTransferId.DataPropertyName = "TransferDeviceId";
            this.colTransferId.HeaderText = "Transfer ID";
            this.colTransferId.Name = "colTransferId";
            this.colTransferId.ReadOnly = true;
            this.colTransferId.Visible = false;
            // 
            // colTransferCode
            // 
            this.colTransferCode.DataPropertyName = "TransferDeviceCode";
            this.colTransferCode.HeaderText = "Transfer Code";
            this.colTransferCode.Name = "colTransferCode";
            this.colTransferCode.ReadOnly = true;
            this.colTransferCode.Width = 102;
            // 
            // colTransferContent
            // 
            this.colTransferContent.DataPropertyName = "TransferContent";
            this.colTransferContent.HeaderText = "Transfer Content";
            this.colTransferContent.Name = "colTransferContent";
            this.colTransferContent.ReadOnly = true;
            this.colTransferContent.Width = 114;
            // 
            // colRequestUser
            // 
            this.colRequestUser.DataPropertyName = "UserName";
            this.colRequestUser.HeaderText = "Request User";
            this.colRequestUser.Name = "colRequestUser";
            this.colRequestUser.ReadOnly = true;
            // 
            // colTransferDept
            // 
            this.colTransferDept.DataPropertyName = "TransferDept";
            this.colTransferDept.HeaderText = "Transfer Dept";
            this.colTransferDept.Name = "colTransferDept";
            this.colTransferDept.ReadOnly = true;
            this.colTransferDept.Width = 98;
            // 
            // colTranferStatus
            // 
            this.colTranferStatus.DataPropertyName = "TransferStatus";
            this.colTranferStatus.HeaderText = "Tranfer Status";
            this.colTranferStatus.Name = "colTranferStatus";
            this.colTranferStatus.ReadOnly = true;
            this.colTranferStatus.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // colTransferApprover
            // 
            this.colTransferApprover.DataPropertyName = "TransferApprover";
            this.colTransferApprover.HeaderText = "Check By";
            this.colTransferApprover.Name = "colTransferApprover";
            this.colTransferApprover.ReadOnly = true;
            this.colTransferApprover.Width = 77;
            // 
            // colDestinationDept
            // 
            this.colDestinationDept.DataPropertyName = "DestinationDept";
            this.colDestinationDept.HeaderText = "Destination Dept";
            this.colDestinationDept.Name = "colDestinationDept";
            this.colDestinationDept.ReadOnly = true;
            this.colDestinationDept.Width = 114;
            // 
            // colDestinationStatus
            // 
            this.colDestinationStatus.DataPropertyName = "DestinationStatus";
            this.colDestinationStatus.HeaderText = "Destination Status";
            this.colDestinationStatus.Name = "colDestinationStatus";
            this.colDestinationStatus.ReadOnly = true;
            this.colDestinationStatus.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colDestinationStatus.Width = 122;
            // 
            // colDestiApprover
            // 
            this.colDestiApprover.DataPropertyName = "DestinationApprover";
            this.colDestiApprover.HeaderText = "Check By";
            this.colDestiApprover.Name = "colDestiApprover";
            this.colDestiApprover.ReadOnly = true;
            this.colDestiApprover.Width = 77;
            // 
            // colApproveStatus
            // 
            this.colApproveStatus.DataPropertyName = "ApproveStatus";
            this.colApproveStatus.HeaderText = "Approve Status";
            this.colApproveStatus.Name = "colApproveStatus";
            this.colApproveStatus.ReadOnly = true;
            this.colApproveStatus.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colApproveStatus.Width = 105;
            // 
            // colAccounterApproved
            // 
            this.colAccounterApproved.DataPropertyName = "Accounter";
            this.colAccounterApproved.HeaderText = "Accounter Approve";
            this.colAccounterApproved.Name = "colAccounterApproved";
            this.colAccounterApproved.ReadOnly = true;
            this.colAccounterApproved.Width = 121;
            // 
            // Search_btn
            // 
            this.Search_btn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Search_btn.BackColor = System.Drawing.SystemColors.Control;
            this.Search_btn.ControlId = null;
            this.Search_btn.Font = new System.Drawing.Font("Arial", 9F);
            this.Search_btn.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.Search_btn.Location = new System.Drawing.Point(334, 35);
            this.Search_btn.Name = "Search_btn";
            this.Search_btn.Size = new System.Drawing.Size(80, 33);
            this.Search_btn.TabIndex = 16;
            this.Search_btn.Text = "Search";
            this.Search_btn.UseVisualStyleBackColor = true;
            this.Search_btn.Click += new System.EventHandler(this.Search_btn_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.Destination_cmb);
            this.groupBox1.Controls.Add(this.Exit_btn);
            this.groupBox1.Controls.Add(this.Destination_lbl);
            this.groupBox1.Controls.Add(this.View_btn);
            this.groupBox1.Controls.Add(this.Search_btn);
            this.groupBox1.Location = new System.Drawing.Point(5, 108);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(959, 101);
            this.groupBox1.TabIndex = 126;
            this.groupBox1.TabStop = false;
            // 
            // Destination_cmb
            // 
            this.Destination_cmb.ControlId = null;
            this.Destination_cmb.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Destination_cmb.FormattingEnabled = true;
            this.Destination_cmb.Location = new System.Drawing.Point(176, 40);
            this.Destination_cmb.Name = "Destination_cmb";
            this.Destination_cmb.Size = new System.Drawing.Size(152, 23);
            this.Destination_cmb.TabIndex = 124;
            // 
            // Destination_lbl
            // 
            this.Destination_lbl.AutoSize = true;
            this.Destination_lbl.ControlId = null;
            this.Destination_lbl.Font = new System.Drawing.Font("Arial", 9F);
            this.Destination_lbl.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.Destination_lbl.Location = new System.Drawing.Point(68, 43);
            this.Destination_lbl.Name = "Destination_lbl";
            this.Destination_lbl.Size = new System.Drawing.Size(102, 15);
            this.Destination_lbl.TabIndex = 123;
            this.Destination_lbl.Text = "Destination Dept:";
            // 
            // View_btn
            // 
            this.View_btn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.View_btn.BackColor = System.Drawing.SystemColors.Control;
            this.View_btn.ControlId = null;
            this.View_btn.Font = new System.Drawing.Font("Arial", 9F);
            this.View_btn.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.View_btn.Location = new System.Drawing.Point(743, 62);
            this.View_btn.Name = "View_btn";
            this.View_btn.Size = new System.Drawing.Size(80, 33);
            this.View_btn.TabIndex = 16;
            this.View_btn.Text = "View";
            this.View_btn.UseVisualStyleBackColor = true;
            this.View_btn.Click += new System.EventHandler(this.View_btn_Click);
            // 
            // TranferInfoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(968, 641);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.TranferInfo_dgv);
            this.Name = "TranferInfoForm";
            this.TitleText = "FormCommon";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.TranferInfoForm_Load);
            this.Controls.SetChildIndex(this.TranferInfo_dgv, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.TranferInfo_dgv)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private Framework.ButtonCommon Exit_btn;
        internal Framework.DataGridViewCommon TranferInfo_dgv;
        private Framework.ButtonCommon Search_btn;
        private System.Windows.Forms.GroupBox groupBox1;
        private Framework.ComboBoxCommon Destination_cmb;
        private Framework.LabelCommon Destination_lbl;
        private Framework.ButtonCommon View_btn;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTransferId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTransferCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTransferContent;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRequestUser;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTransferDept;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTranferStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTransferApprover;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDestinationDept;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDestinationStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDestiApprover;
        private System.Windows.Forms.DataGridViewTextBoxColumn colApproveStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAccounterApproved;
    }
}
