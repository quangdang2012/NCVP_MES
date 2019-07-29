namespace Com.Nidec.Mes.Common.Basic.MachineMaintenance.Form
{
    partial class AddDocumentForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddDocumentForm));
            this.Cancel_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.OK_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.linksave_txt = new System.Windows.Forms.TextBox();
            this.cmbDocType = new System.Windows.Forms.ComboBox();
            this.doc_type_lbl = new System.Windows.Forms.Label();
            this.btnBrowser = new System.Windows.Forms.Button();
            this.txtDocName = new System.Windows.Forms.TextBox();
            this.txtVersion = new System.Windows.Forms.TextBox();
            this.txtModel = new System.Windows.Forms.TextBox();
            this.txtDocNo = new System.Windows.Forms.TextBox();
            this.version_lbl = new System.Windows.Forms.Label();
            this.model_lbl = new System.Windows.Forms.Label();
            this.doc_no_lbl = new System.Windows.Forms.Label();
            this.doc_name_lbl = new System.Windows.Forms.Label();
            this.department_lbl = new System.Windows.Forms.Label();
            this.cmbDepartment = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // Cancel_btn
            // 
            this.Cancel_btn.BackColor = System.Drawing.SystemColors.Control;
            this.Cancel_btn.ControlId = null;
            resources.ApplyResources(this.Cancel_btn, "Cancel_btn");
            this.Cancel_btn.Name = "Cancel_btn";
            this.Cancel_btn.UseVisualStyleBackColor = false;
            this.Cancel_btn.Click += new System.EventHandler(this.Cancel_btn_Click);
            // 
            // OK_btn
            // 
            this.OK_btn.BackColor = System.Drawing.SystemColors.Control;
            this.OK_btn.ControlId = null;
            resources.ApplyResources(this.OK_btn, "OK_btn");
            this.OK_btn.Name = "OK_btn";
            this.OK_btn.UseVisualStyleBackColor = false;
            this.OK_btn.Click += new System.EventHandler(this.OK_btn_Click);
            // 
            // linksave_txt
            // 
            resources.ApplyResources(this.linksave_txt, "linksave_txt");
            this.linksave_txt.Name = "linksave_txt";
            // 
            // cmbDocType
            // 
            resources.ApplyResources(this.cmbDocType, "cmbDocType");
            this.cmbDocType.FormattingEnabled = true;
            this.cmbDocType.Name = "cmbDocType";
            // 
            // doc_type_lbl
            // 
            resources.ApplyResources(this.doc_type_lbl, "doc_type_lbl");
            this.doc_type_lbl.Name = "doc_type_lbl";
            // 
            // btnBrowser
            // 
            resources.ApplyResources(this.btnBrowser, "btnBrowser");
            this.btnBrowser.Name = "btnBrowser";
            this.btnBrowser.UseVisualStyleBackColor = true;
            this.btnBrowser.Click += new System.EventHandler(this.browser_btn_Click);
            // 
            // txtDocName
            // 
            resources.ApplyResources(this.txtDocName, "txtDocName");
            this.txtDocName.Name = "txtDocName";
            // 
            // txtVersion
            // 
            this.txtVersion.BackColor = System.Drawing.SystemColors.Window;
            resources.ApplyResources(this.txtVersion, "txtVersion");
            this.txtVersion.Name = "txtVersion";
            // 
            // txtModel
            // 
            this.txtModel.BackColor = System.Drawing.SystemColors.Window;
            resources.ApplyResources(this.txtModel, "txtModel");
            this.txtModel.Name = "txtModel";
            this.txtModel.ReadOnly = true;
            // 
            // txtDocNo
            // 
            this.txtDocNo.BackColor = System.Drawing.SystemColors.Window;
            resources.ApplyResources(this.txtDocNo, "txtDocNo");
            this.txtDocNo.Name = "txtDocNo";
            this.txtDocNo.ReadOnly = true;
            // 
            // version_lbl
            // 
            resources.ApplyResources(this.version_lbl, "version_lbl");
            this.version_lbl.Name = "version_lbl";
            // 
            // model_lbl
            // 
            resources.ApplyResources(this.model_lbl, "model_lbl");
            this.model_lbl.Name = "model_lbl";
            // 
            // doc_no_lbl
            // 
            resources.ApplyResources(this.doc_no_lbl, "doc_no_lbl");
            this.doc_no_lbl.Name = "doc_no_lbl";
            // 
            // doc_name_lbl
            // 
            resources.ApplyResources(this.doc_name_lbl, "doc_name_lbl");
            this.doc_name_lbl.Name = "doc_name_lbl";
            // 
            // department_lbl
            // 
            resources.ApplyResources(this.department_lbl, "department_lbl");
            this.department_lbl.Name = "department_lbl";
            // 
            // cmbDepartment
            // 
            resources.ApplyResources(this.cmbDepartment, "cmbDepartment");
            this.cmbDepartment.FormattingEnabled = true;
            this.cmbDepartment.Name = "cmbDepartment";
            // 
            // AddDocumentForm
            // 
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.btnBrowser);
            this.Controls.Add(this.linksave_txt);
            this.Controls.Add(this.cmbDepartment);
            this.Controls.Add(this.cmbDocType);
            this.Controls.Add(this.department_lbl);
            this.Controls.Add(this.doc_type_lbl);
            this.Controls.Add(this.txtDocName);
            this.Controls.Add(this.txtVersion);
            this.Controls.Add(this.txtModel);
            this.Controls.Add(this.txtDocNo);
            this.Controls.Add(this.version_lbl);
            this.Controls.Add(this.model_lbl);
            this.Controls.Add(this.doc_no_lbl);
            this.Controls.Add(this.doc_name_lbl);
            this.Controls.Add(this.Cancel_btn);
            this.Controls.Add(this.OK_btn);
            this.MaximizeBox = false;
            this.Name = "AddDocumentForm";
            this.TitleText = "Register Document";
            this.Load += new System.EventHandler(this.AddDocumentForm_Load);
            this.Controls.SetChildIndex(this.OK_btn, 0);
            this.Controls.SetChildIndex(this.Cancel_btn, 0);
            this.Controls.SetChildIndex(this.doc_name_lbl, 0);
            this.Controls.SetChildIndex(this.doc_no_lbl, 0);
            this.Controls.SetChildIndex(this.model_lbl, 0);
            this.Controls.SetChildIndex(this.version_lbl, 0);
            this.Controls.SetChildIndex(this.txtDocNo, 0);
            this.Controls.SetChildIndex(this.txtModel, 0);
            this.Controls.SetChildIndex(this.txtVersion, 0);
            this.Controls.SetChildIndex(this.txtDocName, 0);
            this.Controls.SetChildIndex(this.doc_type_lbl, 0);
            this.Controls.SetChildIndex(this.department_lbl, 0);
            this.Controls.SetChildIndex(this.cmbDocType, 0);
            this.Controls.SetChildIndex(this.cmbDepartment, 0);
            this.Controls.SetChildIndex(this.linksave_txt, 0);
            this.Controls.SetChildIndex(this.btnBrowser, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Framework.ButtonCommon Cancel_btn;
        private Framework.ButtonCommon OK_btn;
        private System.Windows.Forms.TextBox linksave_txt;
        private System.Windows.Forms.ComboBox cmbDocType;
        private System.Windows.Forms.Label doc_type_lbl;
        private System.Windows.Forms.Button btnBrowser;
        private System.Windows.Forms.TextBox txtDocName;
        private System.Windows.Forms.TextBox txtVersion;
        private System.Windows.Forms.TextBox txtModel;
        private System.Windows.Forms.TextBox txtDocNo;
        private System.Windows.Forms.Label version_lbl;
        private System.Windows.Forms.Label model_lbl;
        private System.Windows.Forms.Label doc_no_lbl;
        private System.Windows.Forms.Label doc_name_lbl;
        private System.Windows.Forms.Label department_lbl;
        private System.Windows.Forms.ComboBox cmbDepartment;
    }
}
