namespace Com.Nidec.Mes.Common.Basic.MachineMaintenance.Form.GA1ModelForm.ShippingForm
{
    partial class ReplaceSerialForm
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
            this.labelCommon1 = new Com.Nidec.Mes.Framework.LabelCommon();
            this.labelCommon2 = new Com.Nidec.Mes.Framework.LabelCommon();
            this.txtOldSerial = new Com.Nidec.Mes.Framework.TextBoxCommon();
            this.txtNewSerial = new Com.Nidec.Mes.Framework.TextBoxCommon();
            this.btnCancel = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.btnReplace = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.dgvNewSerial = new System.Windows.Forms.DataGridView();
            this.Serial = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Model = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Line = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Lot = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Thurst = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Thurst_MC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Noise = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Noise_MC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblBoxID = new Com.Nidec.Mes.Framework.LabelCommon();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNewSerial)).BeginInit();
            this.SuspendLayout();
            // 
            // labelCommon1
            // 
            this.labelCommon1.AutoSize = true;
            this.labelCommon1.ControlId = null;
            this.labelCommon1.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCommon1.Location = new System.Drawing.Point(75, 120);
            this.labelCommon1.Name = "labelCommon1";
            this.labelCommon1.Size = new System.Drawing.Size(61, 15);
            this.labelCommon1.TabIndex = 2;
            this.labelCommon1.Text = "Old Serial";
            // 
            // labelCommon2
            // 
            this.labelCommon2.AutoSize = true;
            this.labelCommon2.ControlId = null;
            this.labelCommon2.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCommon2.Location = new System.Drawing.Point(75, 147);
            this.labelCommon2.Name = "labelCommon2";
            this.labelCommon2.Size = new System.Drawing.Size(67, 15);
            this.labelCommon2.TabIndex = 3;
            this.labelCommon2.Text = "New Serial";
            // 
            // txtOldSerial
            // 
            this.txtOldSerial.ControlId = null;
            this.txtOldSerial.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtOldSerial.InputType = Com.Nidec.Mes.Framework.TextBoxCommon.InputTypeList.All;
            this.txtOldSerial.Location = new System.Drawing.Point(192, 117);
            this.txtOldSerial.Name = "txtOldSerial";
            this.txtOldSerial.Size = new System.Drawing.Size(166, 21);
            this.txtOldSerial.TabIndex = 4;
            this.txtOldSerial.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtOldSerial_KeyDown);
            // 
            // txtNewSerial
            // 
            this.txtNewSerial.ControlId = null;
            this.txtNewSerial.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNewSerial.InputType = Com.Nidec.Mes.Framework.TextBoxCommon.InputTypeList.All;
            this.txtNewSerial.Location = new System.Drawing.Point(192, 144);
            this.txtNewSerial.Name = "txtNewSerial";
            this.txtNewSerial.Size = new System.Drawing.Size(166, 21);
            this.txtNewSerial.TabIndex = 5;
            this.txtNewSerial.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtNewSerial_KeyDown);
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.SystemColors.Control;
            this.btnCancel.ControlId = null;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnCancel.Font = new System.Drawing.Font("Arial", 9F);
            this.btnCancel.Location = new System.Drawing.Point(289, 176);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(80, 33);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnReplace
            // 
            this.btnReplace.BackColor = System.Drawing.SystemColors.Control;
            this.btnReplace.ControlId = null;
            this.btnReplace.Enabled = false;
            this.btnReplace.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnReplace.Font = new System.Drawing.Font("Arial", 9F);
            this.btnReplace.Location = new System.Drawing.Point(172, 176);
            this.btnReplace.Name = "btnReplace";
            this.btnReplace.Size = new System.Drawing.Size(80, 33);
            this.btnReplace.TabIndex = 6;
            this.btnReplace.Text = "Replace";
            this.btnReplace.UseVisualStyleBackColor = false;
            this.btnReplace.Click += new System.EventHandler(this.btnReplace_Click);
            // 
            // dgvNewSerial
            // 
            this.dgvNewSerial.AllowUserToAddRows = false;
            this.dgvNewSerial.AllowUserToDeleteRows = false;
            this.dgvNewSerial.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.dgvNewSerial.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvNewSerial.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Serial,
            this.Model,
            this.Line,
            this.Lot,
            this.Thurst,
            this.Thurst_MC,
            this.Noise,
            this.Noise_MC});
            this.dgvNewSerial.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgvNewSerial.Location = new System.Drawing.Point(0, 220);
            this.dgvNewSerial.Name = "dgvNewSerial";
            this.dgvNewSerial.ReadOnly = true;
            this.dgvNewSerial.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.dgvNewSerial.RowTemplate.Height = 21;
            this.dgvNewSerial.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvNewSerial.Size = new System.Drawing.Size(823, 107);
            this.dgvNewSerial.TabIndex = 11;
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
            // lblBoxID
            // 
            this.lblBoxID.AutoSize = true;
            this.lblBoxID.ControlId = null;
            this.lblBoxID.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBoxID.Location = new System.Drawing.Point(403, 132);
            this.lblBoxID.Name = "lblBoxID";
            this.lblBoxID.Size = new System.Drawing.Size(55, 18);
            this.lblBoxID.TabIndex = 2;
            this.lblBoxID.Text = "BoxID:";
            // 
            // ReplaceSerialForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(823, 327);
            this.Controls.Add(this.dgvNewSerial);
            this.Controls.Add(this.btnReplace);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.txtNewSerial);
            this.Controls.Add(this.txtOldSerial);
            this.Controls.Add(this.labelCommon2);
            this.Controls.Add(this.lblBoxID);
            this.Controls.Add(this.labelCommon1);
            this.MaximizeBox = false;
            this.Name = "ReplaceSerialForm";
            this.ShowInTaskbar = false;
            this.Text = "Replace Serial";
            this.TitleText = "Replace Serial";
            this.Controls.SetChildIndex(this.labelCommon1, 0);
            this.Controls.SetChildIndex(this.lblBoxID, 0);
            this.Controls.SetChildIndex(this.labelCommon2, 0);
            this.Controls.SetChildIndex(this.txtOldSerial, 0);
            this.Controls.SetChildIndex(this.txtNewSerial, 0);
            this.Controls.SetChildIndex(this.btnCancel, 0);
            this.Controls.SetChildIndex(this.btnReplace, 0);
            this.Controls.SetChildIndex(this.dgvNewSerial, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dgvNewSerial)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Framework.LabelCommon labelCommon1;
        private Framework.LabelCommon labelCommon2;
        private Framework.TextBoxCommon txtOldSerial;
        private Framework.TextBoxCommon txtNewSerial;
        private Framework.ButtonCommon btnCancel;
        private Framework.ButtonCommon btnReplace;
        private System.Windows.Forms.DataGridView dgvNewSerial;
        private System.Windows.Forms.DataGridViewTextBoxColumn Serial;
        private System.Windows.Forms.DataGridViewTextBoxColumn Model;
        private System.Windows.Forms.DataGridViewTextBoxColumn Line;
        private System.Windows.Forms.DataGridViewTextBoxColumn Lot;
        private System.Windows.Forms.DataGridViewTextBoxColumn Thurst;
        private System.Windows.Forms.DataGridViewTextBoxColumn Thurst_MC;
        private System.Windows.Forms.DataGridViewTextBoxColumn Noise;
        private System.Windows.Forms.DataGridViewTextBoxColumn Noise_MC;
        private Framework.LabelCommon lblBoxID;
    }
}
