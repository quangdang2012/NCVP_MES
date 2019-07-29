namespace Com.Nidec.Mes.Common.Basic.MachineMaintenance.Form.IPQCForm
{
    partial class InspectItemMaster
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InspectItemMaster));
            this.btnAdd = new System.Windows.Forms.Button();
            this.dgvTester = new System.Windows.Forms.DataGridView();
            this.no = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_model = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.process = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.inspect = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.description = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.upper = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lower = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.instrument = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmset = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rowset = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTester)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(12, 16);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(120, 24);
            this.btnAdd.TabIndex = 11;
            this.btnAdd.Text = "Add / Edit";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // dgvTester
            // 
            this.dgvTester.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.dgvTester.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTester.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.no,
            this.col_model,
            this.process,
            this.inspect,
            this.description,
            this.upper,
            this.lower,
            this.instrument,
            this.clmset,
            this.rowset});
            this.dgvTester.Location = new System.Drawing.Point(0, 3);
            this.dgvTester.Name = "dgvTester";
            this.dgvTester.ReadOnly = true;
            this.dgvTester.RowTemplate.Height = 21;
            this.dgvTester.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvTester.Size = new System.Drawing.Size(1216, 551);
            this.dgvTester.TabIndex = 12;
            // 
            // no
            // 
            this.no.DataPropertyName = "No";
            this.no.HeaderText = "No.";
            this.no.Name = "no";
            this.no.ReadOnly = true;
            // 
            // col_model
            // 
            this.col_model.DataPropertyName = "Model";
            this.col_model.HeaderText = "Model";
            this.col_model.Name = "col_model";
            this.col_model.ReadOnly = true;
            // 
            // process
            // 
            this.process.DataPropertyName = "Process";
            this.process.HeaderText = "Process";
            this.process.Name = "process";
            this.process.ReadOnly = true;
            // 
            // inspect
            // 
            this.inspect.DataPropertyName = "Inspect";
            this.inspect.HeaderText = "Inspect";
            this.inspect.Name = "inspect";
            this.inspect.ReadOnly = true;
            // 
            // description
            // 
            this.description.DataPropertyName = "Description";
            this.description.HeaderText = "Description";
            this.description.Name = "description";
            this.description.ReadOnly = true;
            // 
            // upper
            // 
            this.upper.DataPropertyName = "Upper";
            this.upper.HeaderText = "Upper";
            this.upper.Name = "upper";
            this.upper.ReadOnly = true;
            // 
            // lower
            // 
            this.lower.DataPropertyName = "Lower";
            this.lower.HeaderText = "Lower";
            this.lower.Name = "lower";
            this.lower.ReadOnly = true;
            // 
            // instrument
            // 
            this.instrument.DataPropertyName = "Instrument";
            this.instrument.HeaderText = "Instrument";
            this.instrument.Name = "instrument";
            this.instrument.ReadOnly = true;
            // 
            // clmset
            // 
            this.clmset.DataPropertyName = "ClmSet";
            this.clmset.HeaderText = "ClmSet";
            this.clmset.Name = "clmset";
            this.clmset.ReadOnly = true;
            // 
            // rowset
            // 
            this.rowset.DataPropertyName = "RowSet";
            this.rowset.HeaderText = "RowSet";
            this.rowset.Name = "rowset";
            this.rowset.ReadOnly = true;
            // 
            // btnSave
            // 
            this.btnSave.Enabled = false;
            this.btnSave.Location = new System.Drawing.Point(264, 16);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(120, 24);
            this.btnSave.TabIndex = 11;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(138, 16);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(120, 24);
            this.btnDelete.TabIndex = 11;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(390, 16);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(120, 24);
            this.btnClose.TabIndex = 11;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 107);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.btnAdd);
            this.splitContainer1.Panel1.Controls.Add(this.btnClose);
            this.splitContainer1.Panel1.Controls.Add(this.btnDelete);
            this.splitContainer1.Panel1.Controls.Add(this.btnSave);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.dgvTester);
            this.splitContainer1.Size = new System.Drawing.Size(1216, 611);
            this.splitContainer1.SplitterDistance = 55;
            this.splitContainer1.TabIndex = 13;
            // 
            // InspectItemMaster
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1216, 718);
            this.Controls.Add(this.splitContainer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "InspectItemMaster";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Measurement Item Edit";
            this.TitleText = "Measurement Item Edit";
            this.Load += new System.EventHandler(this.Form7_2_Load);
            this.Controls.SetChildIndex(this.splitContainer1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTester)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.DataGridView dgvTester;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.DataGridViewTextBoxColumn no;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_model;
        private System.Windows.Forms.DataGridViewTextBoxColumn process;
        private System.Windows.Forms.DataGridViewTextBoxColumn inspect;
        private System.Windows.Forms.DataGridViewTextBoxColumn description;
        private System.Windows.Forms.DataGridViewTextBoxColumn upper;
        private System.Windows.Forms.DataGridViewTextBoxColumn lower;
        private System.Windows.Forms.DataGridViewTextBoxColumn instrument;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmset;
        private System.Windows.Forms.DataGridViewTextBoxColumn rowset;
        private System.Windows.Forms.SplitContainer splitContainer1;
    }
}

