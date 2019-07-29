namespace Com.Nidec.Mes.Common.Basic.MachineMaintenance.Form
{
    partial class DocumentForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DocumentForm));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.cmbModel = new Com.Nidec.Mes.Framework.ComboBoxCommon();
            this.model_lbl = new Com.Nidec.Mes.Framework.LabelCommon();
            this.update_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.add_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.exit_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.search_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.doc_name_lbl = new Com.Nidec.Mes.Framework.LabelCommon();
            this.doc_type_lbl = new Com.Nidec.Mes.Framework.LabelCommon();
            this.doc_type_cmb = new Com.Nidec.Mes.Framework.ComboBoxCommon();
            this.doc_no_lbl = new Com.Nidec.Mes.Framework.LabelCommon();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.dgvDocument = new System.Windows.Forms.DataGridView();
            this.doc_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.doc_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.doc_no = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.doc_type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.version = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.department = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.update_date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.model_cd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnDelete = new System.Windows.Forms.Button();
            this.txtDocName = new System.Windows.Forms.TextBox();
            this.txtDocNo = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbDept = new System.Windows.Forms.ComboBox();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDocument)).BeginInit();
            this.SuspendLayout();
            // 
            // cmbModel
            // 
            this.cmbModel.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbModel.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbModel.ControlId = null;
            resources.ApplyResources(this.cmbModel, "cmbModel");
            this.cmbModel.FormattingEnabled = true;
            this.cmbModel.Name = "cmbModel";
            // 
            // model_lbl
            // 
            resources.ApplyResources(this.model_lbl, "model_lbl");
            this.model_lbl.ControlId = null;
            this.model_lbl.Name = "model_lbl";
            // 
            // update_btn
            // 
            this.update_btn.BackColor = System.Drawing.SystemColors.Control;
            this.update_btn.ControlId = "mcfb002";
            resources.ApplyResources(this.update_btn, "update_btn");
            this.update_btn.Name = "update_btn";
            this.update_btn.UseVisualStyleBackColor = false;
            this.update_btn.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // add_btn
            // 
            this.add_btn.BackColor = System.Drawing.SystemColors.Control;
            this.add_btn.ControlId = "mcfb001";
            resources.ApplyResources(this.add_btn, "add_btn");
            this.add_btn.Name = "add_btn";
            this.add_btn.UseVisualStyleBackColor = false;
            this.add_btn.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // exit_btn
            // 
            this.exit_btn.BackColor = System.Drawing.SystemColors.Control;
            this.exit_btn.ControlId = null;
            resources.ApplyResources(this.exit_btn, "exit_btn");
            this.exit_btn.Name = "exit_btn";
            this.exit_btn.UseVisualStyleBackColor = false;
            this.exit_btn.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // search_btn
            // 
            this.search_btn.BackColor = System.Drawing.SystemColors.Control;
            this.search_btn.ControlId = null;
            resources.ApplyResources(this.search_btn, "search_btn");
            this.search_btn.Name = "search_btn";
            this.search_btn.UseVisualStyleBackColor = false;
            this.search_btn.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // doc_name_lbl
            // 
            resources.ApplyResources(this.doc_name_lbl, "doc_name_lbl");
            this.doc_name_lbl.ControlId = null;
            this.doc_name_lbl.Name = "doc_name_lbl";
            // 
            // doc_type_lbl
            // 
            resources.ApplyResources(this.doc_type_lbl, "doc_type_lbl");
            this.doc_type_lbl.ControlId = null;
            this.doc_type_lbl.Name = "doc_type_lbl";
            // 
            // doc_type_cmb
            // 
            this.doc_type_cmb.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.doc_type_cmb.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.doc_type_cmb.ControlId = null;
            resources.ApplyResources(this.doc_type_cmb, "doc_type_cmb");
            this.doc_type_cmb.FormattingEnabled = true;
            this.doc_type_cmb.Name = "doc_type_cmb";
            // 
            // doc_no_lbl
            // 
            resources.ApplyResources(this.doc_no_lbl, "doc_no_lbl");
            this.doc_no_lbl.ControlId = null;
            this.doc_no_lbl.Name = "doc_no_lbl";
            // 
            // tableLayoutPanel1
            // 
            resources.ApplyResources(this.tableLayoutPanel1, "tableLayoutPanel1");
            this.tableLayoutPanel1.Controls.Add(this.exit_btn, 6, 3);
            this.tableLayoutPanel1.Controls.Add(this.doc_no_lbl, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.add_btn, 4, 3);
            this.tableLayoutPanel1.Controls.Add(this.cmbModel, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.model_lbl, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.dgvDocument, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.doc_name_lbl, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.doc_type_lbl, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.doc_type_cmb, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.search_btn, 2, 3);
            this.tableLayoutPanel1.Controls.Add(this.update_btn, 3, 3);
            this.tableLayoutPanel1.Controls.Add(this.btnDelete, 5, 3);
            this.tableLayoutPanel1.Controls.Add(this.txtDocName, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.txtDocNo, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.label1, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.cmbDept, 3, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            // 
            // dgvDocument
            // 
            this.dgvDocument.AllowUserToAddRows = false;
            this.dgvDocument.AllowUserToDeleteRows = false;
            this.dgvDocument.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvDocument.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDocument.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvDocument.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDocument.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.doc_id,
            this.doc_name,
            this.doc_no,
            this.doc_type,
            this.version,
            this.department,
            this.update_date,
            this.model_cd});
            this.tableLayoutPanel1.SetColumnSpan(this.dgvDocument, 7);
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvDocument.DefaultCellStyle = dataGridViewCellStyle2;
            resources.ApplyResources(this.dgvDocument, "dgvDocument");
            this.dgvDocument.Name = "dgvDocument";
            this.dgvDocument.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDocument.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvDocument.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDocument_CellContentClick);
            // 
            // doc_id
            // 
            this.doc_id.DataPropertyName = "DocumentID";
            resources.ApplyResources(this.doc_id, "doc_id");
            this.doc_id.Name = "doc_id";
            this.doc_id.ReadOnly = true;
            // 
            // doc_name
            // 
            this.doc_name.DataPropertyName = "DocumentName";
            resources.ApplyResources(this.doc_name, "doc_name");
            this.doc_name.Name = "doc_name";
            this.doc_name.ReadOnly = true;
            // 
            // doc_no
            // 
            this.doc_no.DataPropertyName = "DocumentNo";
            resources.ApplyResources(this.doc_no, "doc_no");
            this.doc_no.Name = "doc_no";
            this.doc_no.ReadOnly = true;
            // 
            // doc_type
            // 
            this.doc_type.DataPropertyName = "DocumentType";
            resources.ApplyResources(this.doc_type, "doc_type");
            this.doc_type.Name = "doc_type";
            this.doc_type.ReadOnly = true;
            // 
            // version
            // 
            this.version.DataPropertyName = "Version";
            resources.ApplyResources(this.version, "version");
            this.version.Name = "version";
            this.version.ReadOnly = true;
            // 
            // department
            // 
            this.department.DataPropertyName = "Department";
            resources.ApplyResources(this.department, "department");
            this.department.Name = "department";
            this.department.ReadOnly = true;
            // 
            // update_date
            // 
            this.update_date.DataPropertyName = "Update_Date";
            resources.ApplyResources(this.update_date, "update_date");
            this.update_date.Name = "update_date";
            this.update_date.ReadOnly = true;
            // 
            // model_cd
            // 
            this.model_cd.DataPropertyName = "ModelCode";
            resources.ApplyResources(this.model_cd, "model_cd");
            this.model_cd.Name = "model_cd";
            this.model_cd.ReadOnly = true;
            // 
            // btnDelete
            // 
            resources.ApplyResources(this.btnDelete, "btnDelete");
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // txtDocName
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.txtDocName, 2);
            resources.ApplyResources(this.txtDocName, "txtDocName");
            this.txtDocName.Name = "txtDocName";
            // 
            // txtDocNo
            // 
            resources.ApplyResources(this.txtDocNo, "txtDocNo");
            this.txtDocNo.Name = "txtDocNo";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // cmbDept
            // 
            this.cmbDept.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbDept.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.tableLayoutPanel1.SetColumnSpan(this.cmbDept, 2);
            resources.ApplyResources(this.cmbDept, "cmbDept");
            this.cmbDept.FormattingEnabled = true;
            this.cmbDept.Name = "cmbDept";
            // 
            // DocumentForm
            // 
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "DocumentForm";
            this.TitleText = "Document Management";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.DocumentForm_Load);
            this.Controls.SetChildIndex(this.tableLayoutPanel1, 0);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDocument)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Framework.ComboBoxCommon cmbModel;
        private Framework.LabelCommon model_lbl;
        private Framework.ButtonCommon update_btn;
        private Framework.ButtonCommon add_btn;
        private Framework.ButtonCommon exit_btn;
        private Framework.ButtonCommon search_btn;
        private Framework.LabelCommon doc_name_lbl;
        private Framework.LabelCommon doc_type_lbl;
        private Framework.ComboBoxCommon doc_type_cmb;
        private Framework.LabelCommon doc_no_lbl;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.DataGridView dgvDocument;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.TextBox txtDocName;
        private System.Windows.Forms.TextBox txtDocNo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbDept;
        private System.Windows.Forms.DataGridViewTextBoxColumn doc_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn doc_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn doc_no;
        private System.Windows.Forms.DataGridViewTextBoxColumn doc_type;
        private System.Windows.Forms.DataGridViewTextBoxColumn version;
        private System.Windows.Forms.DataGridViewTextBoxColumn department;
        private System.Windows.Forms.DataGridViewTextBoxColumn update_date;
        private System.Windows.Forms.DataGridViewTextBoxColumn model_cd;
    }
}
