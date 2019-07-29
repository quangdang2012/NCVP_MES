namespace Com.Nidec.Mes.Common.Basic.MachineMaintenance.Form
{
    partial class AddBoxID
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.txtBoxId = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpPrint = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dgvDateCode = new System.Windows.Forms.DataGridView();
            this.txtProduct = new System.Windows.Forms.TextBox();
            this.lblUser = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtUser = new System.Windows.Forms.TextBox();
            this.btnChangeLimit = new System.Windows.Forms.Button();
            this.txtOkCount = new System.Windows.Forms.TextBox();
            this.txtLimit = new System.Windows.Forms.TextBox();
            this.lblModel = new System.Windows.Forms.Label();
            this.cmbModel = new System.Windows.Forms.ComboBox();
            this.btnRegisterBoxId = new System.Windows.Forms.Button();
            this.btnDeleteAll = new System.Windows.Forms.Button();
            this.btnDeleteSelection = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.dgvProductSerial = new System.Windows.Forms.DataGridView();
            this.Serial = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Model = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Line = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Lot = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Thurst = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Thurst_MC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Noise = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Noise_MC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.lblLotCount = new System.Windows.Forms.Label();
            this.dgvDateCode2 = new System.Windows.Forms.DataGridView();
            this.txtBoxIdPrint = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDateCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductSerial)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDateCode2)).BeginInit();
            this.SuspendLayout();
            // 
            // txtBoxId
            // 
            this.txtBoxId.Enabled = false;
            this.txtBoxId.Location = new System.Drawing.Point(88, 6);
            this.txtBoxId.Name = "txtBoxId";
            this.txtBoxId.Size = new System.Drawing.Size(465, 20);
            this.txtBoxId.TabIndex = 14;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 9);
            this.label1.Margin = new System.Windows.Forms.Padding(3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Box ID: ";
            // 
            // dtpPrint
            // 
            this.dtpPrint.Enabled = false;
            this.dtpPrint.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpPrint.Location = new System.Drawing.Point(88, 32);
            this.dtpPrint.Name = "dtpPrint";
            this.dtpPrint.Size = new System.Drawing.Size(465, 20);
            this.dtpPrint.TabIndex = 15;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 38);
            this.label5.Margin = new System.Windows.Forms.Padding(3);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(60, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Print Date: ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 183);
            this.label3.Margin = new System.Windows.Forms.Padding(3);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Product Serial: ";
            // 
            // dgvDateCode
            // 
            this.dgvDateCode.AllowUserToAddRows = false;
            this.dgvDateCode.AllowUserToDeleteRows = false;
            this.dgvDateCode.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.dgvDateCode.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText;
            this.dgvDateCode.GridColor = System.Drawing.SystemColors.ControlLight;
            this.dgvDateCode.Location = new System.Drawing.Point(88, 58);
            this.dgvDateCode.Name = "dgvDateCode";
            this.dgvDateCode.ReadOnly = true;
            this.dgvDateCode.RowTemplate.Height = 21;
            this.dgvDateCode.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvDateCode.Size = new System.Drawing.Size(465, 116);
            this.dgvDateCode.TabIndex = 22;
            // 
            // txtProduct
            // 
            this.txtProduct.Location = new System.Drawing.Point(88, 180);
            this.txtProduct.Name = "txtProduct";
            this.txtProduct.Size = new System.Drawing.Size(465, 20);
            this.txtProduct.TabIndex = 13;
            this.txtProduct.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtProduct_KeyDown);
            // 
            // lblUser
            // 
            this.lblUser.AutoSize = true;
            this.lblUser.Location = new System.Drawing.Point(638, 6);
            this.lblUser.Margin = new System.Windows.Forms.Padding(3);
            this.lblUser.Name = "lblUser";
            this.lblUser.Size = new System.Drawing.Size(35, 13);
            this.lblUser.TabIndex = 21;
            this.lblUser.Text = "User: ";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(638, 35);
            this.label6.Margin = new System.Windows.Forms.Padding(3);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(59, 13);
            this.label6.TabIndex = 20;
            this.label6.Text = "OK Count: ";
            // 
            // txtUser
            // 
            this.txtUser.Location = new System.Drawing.Point(719, 6);
            this.txtUser.MaxLength = 10;
            this.txtUser.Name = "txtUser";
            this.txtUser.Size = new System.Drawing.Size(418, 20);
            this.txtUser.TabIndex = 19;
            // 
            // btnChangeLimit
            // 
            this.btnChangeLimit.Location = new System.Drawing.Point(1143, 32);
            this.btnChangeLimit.Name = "btnChangeLimit";
            this.btnChangeLimit.Size = new System.Drawing.Size(116, 36);
            this.btnChangeLimit.TabIndex = 25;
            this.btnChangeLimit.Text = "Change Limit";
            this.btnChangeLimit.UseVisualStyleBackColor = true;
            this.btnChangeLimit.Click += new System.EventHandler(this.btnChangeLimit_Click);
            // 
            // txtOkCount
            // 
            this.txtOkCount.Enabled = false;
            this.txtOkCount.Location = new System.Drawing.Point(719, 32);
            this.txtOkCount.Name = "txtOkCount";
            this.txtOkCount.Size = new System.Drawing.Size(418, 20);
            this.txtOkCount.TabIndex = 18;
            // 
            // txtLimit
            // 
            this.txtLimit.Enabled = false;
            this.txtLimit.Location = new System.Drawing.Point(1143, 6);
            this.txtLimit.Name = "txtLimit";
            this.txtLimit.Size = new System.Drawing.Size(52, 20);
            this.txtLimit.TabIndex = 17;
            this.txtLimit.Text = "350";
            // 
            // lblModel
            // 
            this.lblModel.AutoSize = true;
            this.lblModel.Location = new System.Drawing.Point(638, 61);
            this.lblModel.Margin = new System.Windows.Forms.Padding(3);
            this.lblModel.Name = "lblModel";
            this.lblModel.Size = new System.Drawing.Size(39, 13);
            this.lblModel.TabIndex = 26;
            this.lblModel.Text = "Model:";
            // 
            // cmbModel
            // 
            this.cmbModel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbModel.FormattingEnabled = true;
            this.cmbModel.Items.AddRange(new object[] {
            "LPD5SG-030",
            "LPD5SG-039"});
            this.cmbModel.Location = new System.Drawing.Point(719, 58);
            this.cmbModel.Name = "cmbModel";
            this.cmbModel.Size = new System.Drawing.Size(121, 21);
            this.cmbModel.TabIndex = 27;
            // 
            // btnRegisterBoxId
            // 
            this.btnRegisterBoxId.Enabled = false;
            this.btnRegisterBoxId.Location = new System.Drawing.Point(641, 119);
            this.btnRegisterBoxId.Name = "btnRegisterBoxId";
            this.btnRegisterBoxId.Size = new System.Drawing.Size(139, 55);
            this.btnRegisterBoxId.TabIndex = 22;
            this.btnRegisterBoxId.Text = "Register Box ID";
            this.btnRegisterBoxId.UseVisualStyleBackColor = true;
            this.btnRegisterBoxId.Click += new System.EventHandler(this.btnRegisterBoxId_Click);
            // 
            // btnDeleteAll
            // 
            this.btnDeleteAll.Location = new System.Drawing.Point(931, 119);
            this.btnDeleteAll.Name = "btnDeleteAll";
            this.btnDeleteAll.Size = new System.Drawing.Size(139, 55);
            this.btnDeleteAll.TabIndex = 24;
            this.btnDeleteAll.Text = "Delete All";
            this.btnDeleteAll.UseVisualStyleBackColor = true;
            this.btnDeleteAll.Click += new System.EventHandler(this.btnDeleteAll_Click);
            // 
            // btnDeleteSelection
            // 
            this.btnDeleteSelection.Location = new System.Drawing.Point(786, 119);
            this.btnDeleteSelection.Name = "btnDeleteSelection";
            this.btnDeleteSelection.Size = new System.Drawing.Size(139, 55);
            this.btnDeleteSelection.TabIndex = 23;
            this.btnDeleteSelection.Text = "Delete Selection";
            this.btnDeleteSelection.UseVisualStyleBackColor = true;
            this.btnDeleteSelection.Click += new System.EventHandler(this.btnDeleteSelection_Click);
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(247)))), ((int)(((byte)(236)))));
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(1076, 119);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(141, 55);
            this.btnClose.TabIndex = 24;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // dgvProductSerial
            // 
            this.dgvProductSerial.AllowUserToAddRows = false;
            this.dgvProductSerial.AllowUserToDeleteRows = false;
            this.dgvProductSerial.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.dgvProductSerial.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProductSerial.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Serial,
            this.Model,
            this.Line,
            this.Lot,
            this.Thurst,
            this.Thurst_MC,
            this.Noise,
            this.Noise_MC});
            this.dgvProductSerial.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvProductSerial.Location = new System.Drawing.Point(0, 0);
            this.dgvProductSerial.Name = "dgvProductSerial";
            this.dgvProductSerial.ReadOnly = true;
            this.dgvProductSerial.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.dgvProductSerial.RowTemplate.Height = 21;
            this.dgvProductSerial.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvProductSerial.Size = new System.Drawing.Size(1284, 426);
            this.dgvProductSerial.TabIndex = 10;
            // 
            // Serial
            // 
            this.Serial.DataPropertyName = "Serial";
            this.Serial.HeaderText = "Serial No";
            this.Serial.Name = "Serial";
            this.Serial.ReadOnly = true;
            // 
            // Model
            // 
            this.Model.DataPropertyName = "Model";
            this.Model.HeaderText = "Model";
            this.Model.Name = "Model";
            this.Model.ReadOnly = true;
            // 
            // Line
            // 
            this.Line.DataPropertyName = "Line";
            this.Line.HeaderText = "Line";
            this.Line.Name = "Line";
            this.Line.ReadOnly = true;
            // 
            // Lot
            // 
            this.Lot.DataPropertyName = "Lot";
            this.Lot.HeaderText = "Lot";
            this.Lot.Name = "Lot";
            this.Lot.ReadOnly = true;
            // 
            // Thurst
            // 
            this.Thurst.DataPropertyName = "Thurst";
            this.Thurst.HeaderText = "Thurst";
            this.Thurst.Name = "Thurst";
            this.Thurst.ReadOnly = true;
            // 
            // Thurst_MC
            // 
            this.Thurst_MC.DataPropertyName = "thurst_mc";
            this.Thurst_MC.HeaderText = "Thurst MC";
            this.Thurst_MC.Name = "Thurst_MC";
            this.Thurst_MC.ReadOnly = true;
            // 
            // Noise
            // 
            this.Noise.DataPropertyName = "Noise";
            this.Noise.HeaderText = "Noise";
            this.Noise.Name = "Noise";
            this.Noise.ReadOnly = true;
            // 
            // Noise_MC
            // 
            this.Noise_MC.DataPropertyName = "noise_mc";
            this.Noise_MC.HeaderText = "Noise MC";
            this.Noise_MC.Name = "Noise_MC";
            this.Noise_MC.ReadOnly = true;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.IsSplitterFixed = true;
            this.splitContainer1.Location = new System.Drawing.Point(0, 107);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.lblLotCount);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            this.splitContainer1.Panel1.Controls.Add(this.btnClose);
            this.splitContainer1.Panel1.Controls.Add(this.label5);
            this.splitContainer1.Panel1.Controls.Add(this.btnDeleteAll);
            this.splitContainer1.Panel1.Controls.Add(this.txtBoxId);
            this.splitContainer1.Panel1.Controls.Add(this.btnRegisterBoxId);
            this.splitContainer1.Panel1.Controls.Add(this.dgvDateCode);
            this.splitContainer1.Panel1.Controls.Add(this.btnDeleteSelection);
            this.splitContainer1.Panel1.Controls.Add(this.dtpPrint);
            this.splitContainer1.Panel1.Controls.Add(this.btnChangeLimit);
            this.splitContainer1.Panel1.Controls.Add(this.lblModel);
            this.splitContainer1.Panel1.Controls.Add(this.txtUser);
            this.splitContainer1.Panel1.Controls.Add(this.label3);
            this.splitContainer1.Panel1.Controls.Add(this.txtLimit);
            this.splitContainer1.Panel1.Controls.Add(this.txtProduct);
            this.splitContainer1.Panel1.Controls.Add(this.txtOkCount);
            this.splitContainer1.Panel1.Controls.Add(this.lblUser);
            this.splitContainer1.Panel1.Controls.Add(this.cmbModel);
            this.splitContainer1.Panel1.Controls.Add(this.label6);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.dgvDateCode2);
            this.splitContainer1.Panel2.Controls.Add(this.txtBoxIdPrint);
            this.splitContainer1.Panel2.Controls.Add(this.dgvProductSerial);
            this.splitContainer1.Size = new System.Drawing.Size(1284, 643);
            this.splitContainer1.SplitterDistance = 213;
            this.splitContainer1.TabIndex = 28;
            // 
            // lblLotCount
            // 
            this.lblLotCount.AutoSize = true;
            this.lblLotCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLotCount.Location = new System.Drawing.Point(573, 58);
            this.lblLotCount.Name = "lblLotCount";
            this.lblLotCount.Size = new System.Drawing.Size(0, 25);
            this.lblLotCount.TabIndex = 28;
            // 
            // dgvDateCode2
            // 
            this.dgvDateCode2.AllowUserToAddRows = false;
            this.dgvDateCode2.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.dgvDateCode2.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvDateCode2.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvDateCode2.ColumnHeadersHeight = 18;
            this.dgvDateCode2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvDateCode2.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvDateCode2.EnableHeadersVisualStyles = false;
            this.dgvDateCode2.GridColor = System.Drawing.Color.White;
            this.dgvDateCode2.Location = new System.Drawing.Point(811, 124);
            this.dgvDateCode2.Name = "dgvDateCode2";
            this.dgvDateCode2.ReadOnly = true;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("MS UI Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvDateCode2.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvDateCode2.RowHeadersVisible = false;
            this.dgvDateCode2.RowHeadersWidth = 40;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.Black;
            this.dgvDateCode2.RowsDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvDateCode2.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.dgvDateCode2.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.White;
            this.dgvDateCode2.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black;
            this.dgvDateCode2.RowTemplate.Height = 18;
            this.dgvDateCode2.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvDateCode2.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.dgvDateCode2.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvDateCode2.Size = new System.Drawing.Size(344, 43);
            this.dgvDateCode2.TabIndex = 27;
            this.dgvDateCode2.Visible = false;
            // 
            // txtBoxIdPrint
            // 
            this.txtBoxIdPrint.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.txtBoxIdPrint.Location = new System.Drawing.Point(931, 77);
            this.txtBoxIdPrint.Multiline = true;
            this.txtBoxIdPrint.Name = "txtBoxIdPrint";
            this.txtBoxIdPrint.Size = new System.Drawing.Size(190, 24);
            this.txtBoxIdPrint.TabIndex = 26;
            this.txtBoxIdPrint.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtBoxIdPrint.Visible = false;
            // 
            // AddBoxID
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(1284, 750);
            this.Controls.Add(this.splitContainer1);
            this.Name = "AddBoxID";
            this.Text = "Add BoxID";
            this.TitleText = "Add BoxID";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.ShippingForm_Load);
            this.Controls.SetChildIndex(this.splitContainer1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDateCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductSerial)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDateCode2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TextBox txtBoxId;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpPrint;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dgvDateCode;
        private System.Windows.Forms.TextBox txtProduct;
        private System.Windows.Forms.Label lblUser;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtUser;
        private System.Windows.Forms.Button btnChangeLimit;
        private System.Windows.Forms.TextBox txtOkCount;
        private System.Windows.Forms.TextBox txtLimit;
        private System.Windows.Forms.Label lblModel;
        private System.Windows.Forms.ComboBox cmbModel;
        private System.Windows.Forms.Button btnRegisterBoxId;
        private System.Windows.Forms.Button btnDeleteAll;
        private System.Windows.Forms.Button btnDeleteSelection;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.DataGridView dgvProductSerial;
        private System.Windows.Forms.DataGridViewTextBoxColumn Serial;
        private System.Windows.Forms.DataGridViewTextBoxColumn Model;
        private System.Windows.Forms.DataGridViewTextBoxColumn Line;
        private System.Windows.Forms.DataGridViewTextBoxColumn Lot;
        private System.Windows.Forms.DataGridViewTextBoxColumn Thurst;
        private System.Windows.Forms.DataGridViewTextBoxColumn Thurst_MC;
        private System.Windows.Forms.DataGridViewTextBoxColumn Noise;
        private System.Windows.Forms.DataGridViewTextBoxColumn Noise_MC;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.DataGridView dgvDateCode2;
        private System.Windows.Forms.TextBox txtBoxIdPrint;
        private System.Windows.Forms.Label lblLotCount;
    }
}
