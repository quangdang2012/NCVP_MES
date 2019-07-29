namespace Com.Nidec.Mes.Common.Basic.MachineMaintenance.Form
{
    partial class AddMachineStatusForm
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
            this.insert_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.section_cbm = new Com.Nidec.Mes.Framework.ComboBoxCommon();
            this.section_lbl = new Com.Nidec.Mes.Framework.LabelCommon();
            this.insert_ST_machine_status_dvg = new Com.Nidec.Mes.Framework.DataGridViewCommon();
            this.colSTMachinename = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSTStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSTDatetime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSTRemark = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.insert_ST_machine_status_dvg)).BeginInit();
            this.SuspendLayout();
            // 
            // insert_btn
            // 
            this.insert_btn.BackColor = System.Drawing.SystemColors.Control;
            this.insert_btn.ControlId = null;
            this.insert_btn.Font = new System.Drawing.Font("Arial", 9F);
            this.insert_btn.Location = new System.Drawing.Point(230, 118);
            this.insert_btn.Name = "insert_btn";
            this.insert_btn.Size = new System.Drawing.Size(80, 35);
            this.insert_btn.TabIndex = 2;
            this.insert_btn.Text = "Insert";
            this.insert_btn.UseVisualStyleBackColor = false;
            this.insert_btn.Click += new System.EventHandler(this.insert_btn_Click);
            // 
            // section_cbm
            // 
            this.section_cbm.ControlId = null;
            this.section_cbm.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.section_cbm.FormattingEnabled = true;
            this.section_cbm.Location = new System.Drawing.Point(79, 125);
            this.section_cbm.Name = "section_cbm";
            this.section_cbm.Size = new System.Drawing.Size(121, 23);
            this.section_cbm.TabIndex = 4;
            this.section_cbm.SelectedIndexChanged += new System.EventHandler(this.section_cbm_SelectedIndexChanged);
            // 
            // section_lbl
            // 
            this.section_lbl.AutoSize = true;
            this.section_lbl.ControlId = null;
            this.section_lbl.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.section_lbl.Location = new System.Drawing.Point(22, 128);
            this.section_lbl.Name = "section_lbl";
            this.section_lbl.Size = new System.Drawing.Size(51, 15);
            this.section_lbl.TabIndex = 5;
            this.section_lbl.Text = "Section:";
            // 
            // insert_ST_machine_status_dvg
            // 
            this.insert_ST_machine_status_dvg.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.insert_ST_machine_status_dvg.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.insert_ST_machine_status_dvg.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.insert_ST_machine_status_dvg.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.insert_ST_machine_status_dvg.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colSTMachinename,
            this.colSTStatus,
            this.colSTDatetime,
            this.colSTRemark});
            this.insert_ST_machine_status_dvg.ControlId = null;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.insert_ST_machine_status_dvg.DefaultCellStyle = dataGridViewCellStyle2;
            this.insert_ST_machine_status_dvg.Location = new System.Drawing.Point(0, 180);
            this.insert_ST_machine_status_dvg.Name = "insert_ST_machine_status_dvg";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(232)))), ((int)(((byte)(180)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.insert_ST_machine_status_dvg.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.insert_ST_machine_status_dvg.RowHeadersWidth = 30;
            this.insert_ST_machine_status_dvg.Size = new System.Drawing.Size(595, 439);
            this.insert_ST_machine_status_dvg.TabIndex = 51;
            // 
            // colSTMachinename
            // 
            this.colSTMachinename.DataPropertyName = "STMachine";
            this.colSTMachinename.HeaderText = "Machine Name";
            this.colSTMachinename.Name = "colSTMachinename";
            this.colSTMachinename.Width = 105;
            // 
            // colSTStatus
            // 
            this.colSTStatus.DataPropertyName = "STData";
            this.colSTStatus.HeaderText = "Status";
            this.colSTStatus.Name = "colSTStatus";
            this.colSTStatus.Width = 67;
            // 
            // colSTDatetime
            // 
            this.colSTDatetime.DataPropertyName = "STDateTimeLoad";
            this.colSTDatetime.HeaderText = "DateTime";
            this.colSTDatetime.Name = "colSTDatetime";
            this.colSTDatetime.Width = 86;
            // 
            // colSTRemark
            // 
            this.colSTRemark.DataPropertyName = "STRemark";
            this.colSTRemark.HeaderText = "Comment";
            this.colSTRemark.Name = "colSTRemark";
            this.colSTRemark.Width = 87;
            // 
            // AddMachineStatusForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(595, 619);
            this.Controls.Add(this.insert_ST_machine_status_dvg);
            this.Controls.Add(this.section_lbl);
            this.Controls.Add(this.section_cbm);
            this.Controls.Add(this.insert_btn);
            this.Name = "AddMachineStatusForm";
            this.Text = "Add Status Machine";
            this.TitleText = "Add Status Machine";
            this.Load += new System.EventHandler(this.AddMachineStatusForm_Load);
            this.Controls.SetChildIndex(this.insert_btn, 0);
            this.Controls.SetChildIndex(this.section_cbm, 0);
            this.Controls.SetChildIndex(this.section_lbl, 0);
            this.Controls.SetChildIndex(this.insert_ST_machine_status_dvg, 0);
            ((System.ComponentModel.ISupportInitialize)(this.insert_ST_machine_status_dvg)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Framework.ButtonCommon insert_btn;
        private Framework.ComboBoxCommon section_cbm;
        private Framework.LabelCommon section_lbl;
        private Framework.DataGridViewCommon insert_ST_machine_status_dvg;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSTMachinename;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSTStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSTDatetime;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSTRemark;
    }
}
