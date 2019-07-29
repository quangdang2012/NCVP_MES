namespace Com.Nidec.Mes.GlobalMasterMaintenance
{
    partial class CustomerMasterForm:FormCommonMaster
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CustomerMasterForm));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            this.CustomerName_lbl = new Com.Nidec.Mes.Framework.LabelCommon();
            this.CustomerName_txt = new Com.Nidec.Mes.Framework.TextBoxCommon();
            this.CustomerCode_txt = new Com.Nidec.Mes.Framework.TextBoxCommon();
            this.CustomerCode_lbl = new Com.Nidec.Mes.Framework.LabelCommon();
            this.Customerdetails_dgv = new Com.Nidec.Mes.Framework.DataGridViewCommon();
            this.colCustomerCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCustomerName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAddress1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAddress2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEmail = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPhoneNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colRemarks = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCustomerId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Clear_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.Exit_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.Delete_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.Update_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.Add_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.Search_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.Address2_lbl = new Com.Nidec.Mes.Framework.LabelCommon();
            this.Address2_txt = new Com.Nidec.Mes.Framework.TextBoxCommon();
            this.Address1_txt = new Com.Nidec.Mes.Framework.TextBoxCommon();
            this.Address1_lbl = new Com.Nidec.Mes.Framework.LabelCommon();
            this.PhoneNo_lbl = new Com.Nidec.Mes.Framework.LabelCommon();
            this.PhoneNo_txt = new Com.Nidec.Mes.Framework.TextBoxCommon();
            this.EmailId_txt = new Com.Nidec.Mes.Framework.TextBoxCommon();
            this.EmailId_lbl = new Com.Nidec.Mes.Framework.LabelCommon();
            ((System.ComponentModel.ISupportInitialize)(this.Customerdetails_dgv)).BeginInit();
            this.SuspendLayout();
            // 
            // CustomerName_lbl
            // 
            resources.ApplyResources(this.CustomerName_lbl, "CustomerName_lbl");
            this.CustomerName_lbl.ControlId = null;
            this.CustomerName_lbl.Name = "CustomerName_lbl";
            // 
            // CustomerName_txt
            // 
            this.CustomerName_txt.ControlId = null;
            resources.ApplyResources(this.CustomerName_txt, "CustomerName_txt");
            this.CustomerName_txt.InputType = Com.Nidec.Mes.Framework.TextBoxCommon.InputTypeList.All;
            this.CustomerName_txt.Name = "CustomerName_txt";
            // 
            // CustomerCode_txt
            // 
            this.CustomerCode_txt.ControlId = null;
            resources.ApplyResources(this.CustomerCode_txt, "CustomerCode_txt");
            this.CustomerCode_txt.InputType = Com.Nidec.Mes.Framework.TextBoxCommon.InputTypeList.All;
            this.CustomerCode_txt.Name = "CustomerCode_txt";
            // 
            // CustomerCode_lbl
            // 
            resources.ApplyResources(this.CustomerCode_lbl, "CustomerCode_lbl");
            this.CustomerCode_lbl.BackColor = System.Drawing.Color.Transparent;
            this.CustomerCode_lbl.ControlId = null;
            this.CustomerCode_lbl.Name = "CustomerCode_lbl";
            // 
            // Customerdetails_dgv
            // 
            this.Customerdetails_dgv.AllowUserToAddRows = false;
            this.Customerdetails_dgv.AllowUserToDeleteRows = false;
            this.Customerdetails_dgv.AllowUserToResizeRows = false;
            resources.ApplyResources(this.Customerdetails_dgv, "Customerdetails_dgv");
            this.Customerdetails_dgv.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(232)))), ((int)(((byte)(180)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.Customerdetails_dgv.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.Customerdetails_dgv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colCustomerCode,
            this.colCustomerName,
            this.colAddress1,
            this.colAddress2,
            this.colEmail,
            this.colPhoneNo,
            this.colRemarks,
            this.colCustomerId});
            this.Customerdetails_dgv.ControlId = null;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.Customerdetails_dgv.DefaultCellStyle = dataGridViewCellStyle8;
            this.Customerdetails_dgv.EnableHeadersVisualStyles = false;
            this.Customerdetails_dgv.MultiSelect = false;
            this.Customerdetails_dgv.Name = "Customerdetails_dgv";
            this.Customerdetails_dgv.ReadOnly = true;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(232)))), ((int)(((byte)(180)))));
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.Customerdetails_dgv.RowHeadersDefaultCellStyle = dataGridViewCellStyle9;
            this.Customerdetails_dgv.RowHeadersVisible = false;
            this.Customerdetails_dgv.RowTemplate.Height = 21;
            this.Customerdetails_dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.Customerdetails_dgv.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.TableDetails_dgv_CellClick);
            this.Customerdetails_dgv.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.TableDetails_dgv_CellDoubleClick);
            this.Customerdetails_dgv.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.Customerdetails_dgv_ColumnHeaderMouseClick);
            // 
            // colCustomerCode
            // 
            this.colCustomerCode.DataPropertyName = "CustomerCode";
            this.colCustomerCode.Frozen = true;
            resources.ApplyResources(this.colCustomerCode, "colCustomerCode");
            this.colCustomerCode.Name = "colCustomerCode";
            this.colCustomerCode.ReadOnly = true;
            // 
            // colCustomerName
            // 
            this.colCustomerName.DataPropertyName = "CustomerName";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.colCustomerName.DefaultCellStyle = dataGridViewCellStyle2;
            this.colCustomerName.FillWeight = 140F;
            this.colCustomerName.Frozen = true;
            resources.ApplyResources(this.colCustomerName, "colCustomerName");
            this.colCustomerName.Name = "colCustomerName";
            this.colCustomerName.ReadOnly = true;
            // 
            // colAddress1
            // 
            this.colAddress1.DataPropertyName = "Address1";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.colAddress1.DefaultCellStyle = dataGridViewCellStyle3;
            this.colAddress1.FillWeight = 32.46753F;
            this.colAddress1.Frozen = true;
            resources.ApplyResources(this.colAddress1, "colAddress1");
            this.colAddress1.Name = "colAddress1";
            this.colAddress1.ReadOnly = true;
            // 
            // colAddress2
            // 
            this.colAddress2.DataPropertyName = "Address2";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.colAddress2.DefaultCellStyle = dataGridViewCellStyle4;
            this.colAddress2.FillWeight = 32.46753F;
            this.colAddress2.Frozen = true;
            resources.ApplyResources(this.colAddress2, "colAddress2");
            this.colAddress2.Name = "colAddress2";
            this.colAddress2.ReadOnly = true;
            // 
            // colEmail
            // 
            this.colEmail.DataPropertyName = "EmailId";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.colEmail.DefaultCellStyle = dataGridViewCellStyle5;
            resources.ApplyResources(this.colEmail, "colEmail");
            this.colEmail.Name = "colEmail";
            this.colEmail.ReadOnly = true;
            // 
            // colPhoneNo
            // 
            this.colPhoneNo.DataPropertyName = "PhoneNo";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.colPhoneNo.DefaultCellStyle = dataGridViewCellStyle6;
            this.colPhoneNo.FillWeight = 32.46753F;
            resources.ApplyResources(this.colPhoneNo, "colPhoneNo");
            this.colPhoneNo.Name = "colPhoneNo";
            this.colPhoneNo.ReadOnly = true;
            // 
            // colRemarks
            // 
            this.colRemarks.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colRemarks.DataPropertyName = "Remarks";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.colRemarks.DefaultCellStyle = dataGridViewCellStyle7;
            this.colRemarks.FillWeight = 32.46753F;
            resources.ApplyResources(this.colRemarks, "colRemarks");
            this.colRemarks.Name = "colRemarks";
            this.colRemarks.ReadOnly = true;
            // 
            // colCustomerId
            // 
            this.colCustomerId.DataPropertyName = "CustomerId";
            resources.ApplyResources(this.colCustomerId, "colCustomerId");
            this.colCustomerId.Name = "colCustomerId";
            this.colCustomerId.ReadOnly = true;
            // 
            // Clear_btn
            // 
            this.Clear_btn.BackColor = System.Drawing.SystemColors.Control;
            this.Clear_btn.ControlId = null;
            resources.ApplyResources(this.Clear_btn, "Clear_btn");
            this.Clear_btn.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Clear_btn.Name = "Clear_btn";
            this.Clear_btn.UseVisualStyleBackColor = true;
            this.Clear_btn.Click += new System.EventHandler(this.Clear_btn_Click);
            // 
            // Exit_btn
            // 
            resources.ApplyResources(this.Exit_btn, "Exit_btn");
            this.Exit_btn.BackColor = System.Drawing.SystemColors.Control;
            this.Exit_btn.ControlId = null;
            this.Exit_btn.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Exit_btn.Name = "Exit_btn";
            this.Exit_btn.UseVisualStyleBackColor = true;
            this.Exit_btn.Click += new System.EventHandler(this.Exit_btn_Click);
            // 
            // Delete_btn
            // 
            resources.ApplyResources(this.Delete_btn, "Delete_btn");
            this.Delete_btn.BackColor = System.Drawing.SystemColors.Control;
            this.Delete_btn.ControlId = null;
            this.Delete_btn.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Delete_btn.Name = "Delete_btn";
            this.Delete_btn.UseVisualStyleBackColor = true;
            this.Delete_btn.Click += new System.EventHandler(this.Delete_btn_Click);
            // 
            // Update_btn
            // 
            resources.ApplyResources(this.Update_btn, "Update_btn");
            this.Update_btn.BackColor = System.Drawing.SystemColors.Control;
            this.Update_btn.ControlId = null;
            this.Update_btn.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Update_btn.Name = "Update_btn";
            this.Update_btn.UseVisualStyleBackColor = true;
            this.Update_btn.Click += new System.EventHandler(this.Update_btn_Click);
            // 
            // Add_btn
            // 
            this.Add_btn.BackColor = System.Drawing.SystemColors.Control;
            this.Add_btn.ControlId = "BTN_01_01";
            resources.ApplyResources(this.Add_btn, "Add_btn");
            this.Add_btn.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Add_btn.Name = "Add_btn";
            this.Add_btn.UseVisualStyleBackColor = true;
            this.Add_btn.Click += new System.EventHandler(this.Add_btn_Click);
            // 
            // Search_btn
            // 
            this.Search_btn.BackColor = System.Drawing.SystemColors.Control;
            this.Search_btn.ControlId = "BTN_01_02";
            resources.ApplyResources(this.Search_btn, "Search_btn");
            this.Search_btn.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Search_btn.Name = "Search_btn";
            this.Search_btn.UseVisualStyleBackColor = true;
            this.Search_btn.Click += new System.EventHandler(this.Search_btn_Click);
            // 
            // Address2_lbl
            // 
            resources.ApplyResources(this.Address2_lbl, "Address2_lbl");
            this.Address2_lbl.ControlId = null;
            this.Address2_lbl.Name = "Address2_lbl";
            // 
            // Address2_txt
            // 
            this.Address2_txt.ControlId = null;
            resources.ApplyResources(this.Address2_txt, "Address2_txt");
            this.Address2_txt.InputType = Com.Nidec.Mes.Framework.TextBoxCommon.InputTypeList.All;
            this.Address2_txt.Name = "Address2_txt";
            // 
            // Address1_txt
            // 
            this.Address1_txt.ControlId = null;
            resources.ApplyResources(this.Address1_txt, "Address1_txt");
            this.Address1_txt.InputType = Com.Nidec.Mes.Framework.TextBoxCommon.InputTypeList.All;
            this.Address1_txt.Name = "Address1_txt";
            // 
            // Address1_lbl
            // 
            resources.ApplyResources(this.Address1_lbl, "Address1_lbl");
            this.Address1_lbl.BackColor = System.Drawing.Color.Transparent;
            this.Address1_lbl.ControlId = null;
            this.Address1_lbl.Name = "Address1_lbl";
            // 
            // PhoneNo_lbl
            // 
            resources.ApplyResources(this.PhoneNo_lbl, "PhoneNo_lbl");
            this.PhoneNo_lbl.ControlId = null;
            this.PhoneNo_lbl.Name = "PhoneNo_lbl";
            // 
            // PhoneNo_txt
            // 
            this.PhoneNo_txt.ControlId = null;
            resources.ApplyResources(this.PhoneNo_txt, "PhoneNo_txt");
            this.PhoneNo_txt.InputType = Com.Nidec.Mes.Framework.TextBoxCommon.InputTypeList.All;
            this.PhoneNo_txt.Name = "PhoneNo_txt";
            // 
            // EmailId_txt
            // 
            this.EmailId_txt.ControlId = null;
            resources.ApplyResources(this.EmailId_txt, "EmailId_txt");
            this.EmailId_txt.InputType = Com.Nidec.Mes.Framework.TextBoxCommon.InputTypeList.All;
            this.EmailId_txt.Name = "EmailId_txt";
            // 
            // EmailId_lbl
            // 
            resources.ApplyResources(this.EmailId_lbl, "EmailId_lbl");
            this.EmailId_lbl.BackColor = System.Drawing.Color.Transparent;
            this.EmailId_lbl.ControlId = null;
            this.EmailId_lbl.Name = "EmailId_lbl";
            // 
            // CustomerMasterForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ControlId = "bpmf003";
            this.Controls.Add(this.PhoneNo_lbl);
            this.Controls.Add(this.PhoneNo_txt);
            this.Controls.Add(this.EmailId_txt);
            this.Controls.Add(this.EmailId_lbl);
            this.Controls.Add(this.Address2_lbl);
            this.Controls.Add(this.Address2_txt);
            this.Controls.Add(this.Address1_txt);
            this.Controls.Add(this.Address1_lbl);
            this.Controls.Add(this.Clear_btn);
            this.Controls.Add(this.Exit_btn);
            this.Controls.Add(this.Delete_btn);
            this.Controls.Add(this.Update_btn);
            this.Controls.Add(this.Add_btn);
            this.Controls.Add(this.Search_btn);
            this.Controls.Add(this.Customerdetails_dgv);
            this.Controls.Add(this.CustomerName_lbl);
            this.Controls.Add(this.CustomerName_txt);
            this.Controls.Add(this.CustomerCode_txt);
            this.Controls.Add(this.CustomerCode_lbl);
            this.Name = "CustomerMasterForm";
            this.TitleText = "FormCommon";
            this.Load += new System.EventHandler(this.CustomerMasterForm_Load);
            this.Controls.SetChildIndex(this.CustomerCode_lbl, 0);
            this.Controls.SetChildIndex(this.CustomerCode_txt, 0);
            this.Controls.SetChildIndex(this.CustomerName_txt, 0);
            this.Controls.SetChildIndex(this.CustomerName_lbl, 0);
            this.Controls.SetChildIndex(this.Customerdetails_dgv, 0);
            this.Controls.SetChildIndex(this.Search_btn, 0);
            this.Controls.SetChildIndex(this.Add_btn, 0);
            this.Controls.SetChildIndex(this.Update_btn, 0);
            this.Controls.SetChildIndex(this.Delete_btn, 0);
            this.Controls.SetChildIndex(this.Exit_btn, 0);
            this.Controls.SetChildIndex(this.Clear_btn, 0);
            this.Controls.SetChildIndex(this.Address1_lbl, 0);
            this.Controls.SetChildIndex(this.Address1_txt, 0);
            this.Controls.SetChildIndex(this.Address2_txt, 0);
            this.Controls.SetChildIndex(this.Address2_lbl, 0);
            this.Controls.SetChildIndex(this.EmailId_lbl, 0);
            this.Controls.SetChildIndex(this.EmailId_txt, 0);
            this.Controls.SetChildIndex(this.PhoneNo_txt, 0);
            this.Controls.SetChildIndex(this.PhoneNo_lbl, 0);
            ((System.ComponentModel.ISupportInitialize)(this.Customerdetails_dgv)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Com.Nidec.Mes.Framework.LabelCommon CustomerName_lbl;
        private Com.Nidec.Mes.Framework.TextBoxCommon CustomerName_txt;
        private Com.Nidec.Mes.Framework.TextBoxCommon CustomerCode_txt;
        private Com.Nidec.Mes.Framework.LabelCommon CustomerCode_lbl;
        internal Com.Nidec.Mes.Framework.DataGridViewCommon Customerdetails_dgv;
        private Com.Nidec.Mes.Framework.ButtonCommon Search_btn;
        private Com.Nidec.Mes.Framework.ButtonCommon Add_btn;
        private Com.Nidec.Mes.Framework.ButtonCommon Update_btn;
        private Com.Nidec.Mes.Framework.ButtonCommon Delete_btn;
        private Com.Nidec.Mes.Framework.ButtonCommon Exit_btn;
        private Com.Nidec.Mes.Framework.ButtonCommon Clear_btn;
        private Framework.LabelCommon Address2_lbl;
        private Framework.TextBoxCommon Address2_txt;
        private Framework.TextBoxCommon Address1_txt;
        private Framework.LabelCommon Address1_lbl;
        private Framework.LabelCommon PhoneNo_lbl;
        private Framework.TextBoxCommon PhoneNo_txt;
        private Framework.TextBoxCommon EmailId_txt;
        private Framework.LabelCommon EmailId_lbl;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCustomerCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCustomerName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAddress1;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAddress2;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEmail;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPhoneNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRemarks;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCustomerId;
    }
}