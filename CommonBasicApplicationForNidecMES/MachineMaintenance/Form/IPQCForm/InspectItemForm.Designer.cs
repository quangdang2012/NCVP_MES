namespace Com.Nidec.Mes.Common.Basic.MachineMaintenance.Form.IPQCForm
{
    partial class InspectItemForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InspectItemForm));
            this.dgvMeasureItem = new System.Windows.Forms.DataGridView();
            this.no = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.model = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.process = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.inspect = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.description = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.instrument = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmbModel = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnEditMaster = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.btnCancel = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMeasureItem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvMeasureItem
            // 
            this.dgvMeasureItem.AllowUserToAddRows = false;
            this.dgvMeasureItem.AllowUserToDeleteRows = false;
            this.dgvMeasureItem.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvMeasureItem.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvMeasureItem.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.dgvMeasureItem.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMeasureItem.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.no,
            this.model,
            this.process,
            this.inspect,
            this.description,
            this.instrument});
            this.dgvMeasureItem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvMeasureItem.Location = new System.Drawing.Point(0, 0);
            this.dgvMeasureItem.Name = "dgvMeasureItem";
            this.dgvMeasureItem.ReadOnly = true;
            this.dgvMeasureItem.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvMeasureItem.RowTemplate.Height = 21;
            this.dgvMeasureItem.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvMeasureItem.Size = new System.Drawing.Size(798, 532);
            this.dgvMeasureItem.TabIndex = 9;
            this.dgvMeasureItem.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvMeasureItem_CellDoubleClick);
            // 
            // no
            // 
            this.no.DataPropertyName = "No";
            this.no.HeaderText = "No.";
            this.no.Name = "no";
            this.no.ReadOnly = true;
            this.no.Width = 49;
            // 
            // model
            // 
            this.model.DataPropertyName = "Model";
            this.model.HeaderText = "Model";
            this.model.Name = "model";
            this.model.ReadOnly = true;
            this.model.Width = 61;
            // 
            // process
            // 
            this.process.DataPropertyName = "Process";
            this.process.HeaderText = "Process";
            this.process.Name = "process";
            this.process.ReadOnly = true;
            this.process.Width = 70;
            // 
            // inspect
            // 
            this.inspect.DataPropertyName = "Inspect";
            this.inspect.HeaderText = "Inspect";
            this.inspect.Name = "inspect";
            this.inspect.ReadOnly = true;
            this.inspect.Width = 67;
            // 
            // description
            // 
            this.description.DataPropertyName = "Description";
            this.description.HeaderText = "Description";
            this.description.Name = "description";
            this.description.ReadOnly = true;
            this.description.Width = 85;
            // 
            // instrument
            // 
            this.instrument.DataPropertyName = "Instrument";
            this.instrument.HeaderText = "Instrument";
            this.instrument.Name = "instrument";
            this.instrument.ReadOnly = true;
            this.instrument.Width = 81;
            // 
            // cmbModel
            // 
            this.cmbModel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbModel.FormattingEnabled = true;
            this.cmbModel.Location = new System.Drawing.Point(75, 124);
            this.cmbModel.Name = "cmbModel";
            this.cmbModel.Size = new System.Drawing.Size(183, 21);
            this.cmbModel.TabIndex = 10;
            this.cmbModel.SelectedIndexChanged += new System.EventHandler(this.cmbModel_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 127);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Model: ";
            // 
            // btnEditMaster
            // 
            this.btnEditMaster.BackColor = System.Drawing.SystemColors.Control;
            this.btnEditMaster.ControlId = "cbip001";
            this.btnEditMaster.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnEditMaster.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditMaster.Location = new System.Drawing.Point(585, 121);
            this.btnEditMaster.Name = "btnEditMaster";
            this.btnEditMaster.Size = new System.Drawing.Size(87, 25);
            this.btnEditMaster.TabIndex = 11;
            this.btnEditMaster.Text = "Edit Master";
            this.btnEditMaster.UseVisualStyleBackColor = false;
            this.btnEditMaster.Click += new System.EventHandler(this.btnEditMaster_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.SystemColors.Control;
            this.btnCancel.ControlId = "cbip002";
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.btnCancel.Location = new System.Drawing.Point(678, 121);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(87, 25);
            this.btnCancel.TabIndex = 12;
            this.btnCancel.Text = "Close";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.splitContainer1.IsSplitterFixed = true;
            this.splitContainer1.Location = new System.Drawing.Point(0, 152);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.dgvMeasureItem);
            this.splitContainer1.Size = new System.Drawing.Size(798, 561);
            this.splitContainer1.SplitterDistance = 25;
            this.splitContainer1.TabIndex = 13;
            // 
            // InspectItemForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(798, 713);
            this.ControlId = "ffom002";
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnEditMaster);
            this.Controls.Add(this.cmbModel);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "InspectItemForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Measurement Item";
            this.TitleText = "Measurement Item";
            this.Load += new System.EventHandler(this.ItemForm_Load);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.cmbModel, 0);
            this.Controls.SetChildIndex(this.btnEditMaster, 0);
            this.Controls.SetChildIndex(this.btnCancel, 0);
            this.Controls.SetChildIndex(this.splitContainer1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMeasureItem)).EndInit();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvMeasureItem;
        private System.Windows.Forms.ComboBox cmbModel;
        private System.Windows.Forms.Label label1;
        private Framework.ButtonCommon btnEditMaster;
        private Framework.ButtonCommon btnCancel;
        private System.Windows.Forms.DataGridViewTextBoxColumn no;
        private System.Windows.Forms.DataGridViewTextBoxColumn model;
        private System.Windows.Forms.DataGridViewTextBoxColumn process;
        private System.Windows.Forms.DataGridViewTextBoxColumn inspect;
        private System.Windows.Forms.DataGridViewTextBoxColumn description;
        private System.Windows.Forms.DataGridViewTextBoxColumn instrument;
        private System.Windows.Forms.SplitContainer splitContainer1;
    }
}

