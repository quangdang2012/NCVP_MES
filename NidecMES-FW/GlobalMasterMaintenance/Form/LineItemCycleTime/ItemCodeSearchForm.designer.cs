namespace Com.Nidec.Mes.GlobalMasterMaintenance
{
    partial class ItemCodeSearchForm
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
            this.lblmessage = new Com.Nidec.Mes.Framework.LabelCommon();
            this.ItemCode_txt = new Com.Nidec.Mes.Framework.TextBoxCommon();
            this.ItemName_lbl = new Com.Nidec.Mes.Framework.LabelCommon();
            this.ItemName_txt = new Com.Nidec.Mes.Framework.TextBoxCommon();
            this.ItemCode_lbl = new Com.Nidec.Mes.Framework.LabelCommon();
            this.Exit_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.Ok_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.Search_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.Item_dgv = new Com.Nidec.Mes.Framework.DataGridViewCommon();
            this.colSelect = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colItemCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colItemName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AllCheck_chk = new Com.Nidec.Mes.Framework.CheckBoxCommon();
            ((System.ComponentModel.ISupportInitialize)(this.Item_dgv)).BeginInit();
            this.SuspendLayout();
            // 
            // lblmessage
            // 
            this.lblmessage.AutoSize = true;
            this.lblmessage.ControlId = null;
            this.lblmessage.Font = new System.Drawing.Font("Arial", 6.75F);
            this.lblmessage.ForeColor = System.Drawing.Color.Red;
            this.lblmessage.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblmessage.Location = new System.Drawing.Point(15, 158);
            this.lblmessage.Name = "lblmessage";
            this.lblmessage.Size = new System.Drawing.Size(205, 12);
            this.lblmessage.TabIndex = 110;
            this.lblmessage.Text = "* Please input itemcode or itemname for search";
            // 
            // ItemCode_txt
            // 
            this.ItemCode_txt.ControlId = null;
            this.ItemCode_txt.Font = new System.Drawing.Font("Arial", 9F);
            this.ItemCode_txt.InputType = Com.Nidec.Mes.Framework.TextBoxCommon.InputTypeList.All;
            this.ItemCode_txt.Location = new System.Drawing.Point(85, 120);
            this.ItemCode_txt.MaxLength = 18;
            this.ItemCode_txt.Name = "ItemCode_txt";
            this.ItemCode_txt.Size = new System.Drawing.Size(196, 21);
            this.ItemCode_txt.TabIndex = 103;
            // 
            // ItemName_lbl
            // 
            this.ItemName_lbl.AutoSize = true;
            this.ItemName_lbl.ControlId = null;
            this.ItemName_lbl.Font = new System.Drawing.Font("Arial", 9F);
            this.ItemName_lbl.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.ItemName_lbl.Location = new System.Drawing.Point(298, 122);
            this.ItemName_lbl.Name = "ItemName_lbl";
            this.ItemName_lbl.Size = new System.Drawing.Size(68, 15);
            this.ItemName_lbl.TabIndex = 104;
            this.ItemName_lbl.Text = "Item Name";
            // 
            // ItemName_txt
            // 
            this.ItemName_txt.ControlId = null;
            this.ItemName_txt.Font = new System.Drawing.Font("Arial", 9F);
            this.ItemName_txt.InputType = Com.Nidec.Mes.Framework.TextBoxCommon.InputTypeList.All;
            this.ItemName_txt.Location = new System.Drawing.Point(374, 120);
            this.ItemName_txt.MaxLength = 40;
            this.ItemName_txt.Name = "ItemName_txt";
            this.ItemName_txt.Size = new System.Drawing.Size(196, 21);
            this.ItemName_txt.TabIndex = 105;
            // 
            // ItemCode_lbl
            // 
            this.ItemCode_lbl.AutoSize = true;
            this.ItemCode_lbl.ControlId = null;
            this.ItemCode_lbl.Font = new System.Drawing.Font("Arial", 9F);
            this.ItemCode_lbl.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.ItemCode_lbl.Location = new System.Drawing.Point(14, 122);
            this.ItemCode_lbl.Name = "ItemCode_lbl";
            this.ItemCode_lbl.Size = new System.Drawing.Size(64, 15);
            this.ItemCode_lbl.TabIndex = 102;
            this.ItemCode_lbl.Text = "Item Code";
            // 
            // Exit_btn
            // 
            this.Exit_btn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Exit_btn.BackColor = System.Drawing.SystemColors.Control;
            this.Exit_btn.ControlId = null;
            this.Exit_btn.Font = new System.Drawing.Font("Arial", 9F);
            this.Exit_btn.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.Exit_btn.Location = new System.Drawing.Point(587, 442);
            this.Exit_btn.Name = "Exit_btn";
            this.Exit_btn.Size = new System.Drawing.Size(80, 33);
            this.Exit_btn.TabIndex = 109;
            this.Exit_btn.Text = "Exit";
            this.Exit_btn.UseVisualStyleBackColor = true;
            this.Exit_btn.Click += new System.EventHandler(this.Exit_btn_Click);
            // 
            // Ok_btn
            // 
            this.Ok_btn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Ok_btn.BackColor = System.Drawing.SystemColors.Control;
            this.Ok_btn.ControlId = null;
            this.Ok_btn.Font = new System.Drawing.Font("Arial", 9F);
            this.Ok_btn.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.Ok_btn.Location = new System.Drawing.Point(498, 442);
            this.Ok_btn.Name = "Ok_btn";
            this.Ok_btn.Size = new System.Drawing.Size(80, 33);
            this.Ok_btn.TabIndex = 108;
            this.Ok_btn.Text = "Ok";
            this.Ok_btn.UseVisualStyleBackColor = true;
            this.Ok_btn.Click += new System.EventHandler(this.Ok_btn_Click);
            // 
            // Search_btn
            // 
            this.Search_btn.BackColor = System.Drawing.SystemColors.Control;
            this.Search_btn.ControlId = null;
            this.Search_btn.Font = new System.Drawing.Font("Arial", 9F);
            this.Search_btn.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.Search_btn.Location = new System.Drawing.Point(587, 113);
            this.Search_btn.Name = "Search_btn";
            this.Search_btn.Size = new System.Drawing.Size(80, 33);
            this.Search_btn.TabIndex = 106;
            this.Search_btn.Text = "Search";
            this.Search_btn.UseVisualStyleBackColor = true;
            this.Search_btn.Click += new System.EventHandler(this.Search_btn_Click);
            // 
            // Item_dgv
            // 
            this.Item_dgv.AllowUserToAddRows = false;
            this.Item_dgv.AllowUserToDeleteRows = false;
            this.Item_dgv.AllowUserToOrderColumns = true;
            this.Item_dgv.AllowUserToResizeRows = false;
            this.Item_dgv.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(232)))), ((int)(((byte)(180)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.Item_dgv.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.Item_dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Item_dgv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colSelect,
            this.colItemCode,
            this.colItemName});
            this.Item_dgv.ControlId = null;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.Item_dgv.DefaultCellStyle = dataGridViewCellStyle2;
            this.Item_dgv.EnableHeadersVisualStyles = false;
            this.Item_dgv.Location = new System.Drawing.Point(12, 173);
            this.Item_dgv.MultiSelect = false;
            this.Item_dgv.Name = "Item_dgv";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(232)))), ((int)(((byte)(180)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.Item_dgv.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.Item_dgv.RowHeadersVisible = false;
            this.Item_dgv.RowTemplate.Height = 21;
            this.Item_dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.Item_dgv.Size = new System.Drawing.Size(655, 263);
            this.Item_dgv.TabIndex = 107;
            // 
            // colSelect
            // 
            this.colSelect.HeaderText = "";
            this.colSelect.Name = "colSelect";
            this.colSelect.Width = 50;
            // 
            // colItemCode
            // 
            this.colItemCode.DataPropertyName = "SapItemCode";
            this.colItemCode.HeaderText = "Item Code";
            this.colItemCode.Name = "colItemCode";
            this.colItemCode.Width = 200;
            // 
            // colItemName
            // 
            this.colItemName.DataPropertyName = "SapItemName";
            this.colItemName.HeaderText = "Item Name";
            this.colItemName.Name = "colItemName";
            this.colItemName.Width = 300;
            // 
            // AllCheck_chk
            // 
            this.AllCheck_chk.ControlId = null;
            this.AllCheck_chk.Font = new System.Drawing.Font("Arial", 9F);
            this.AllCheck_chk.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.AllCheck_chk.Location = new System.Drawing.Point(31, 177);
            this.AllCheck_chk.Name = "AllCheck_chk";
            this.AllCheck_chk.Size = new System.Drawing.Size(13, 13);
            this.AllCheck_chk.TabIndex = 111;
            this.AllCheck_chk.UseVisualStyleBackColor = true;
            this.AllCheck_chk.CheckedChanged += new System.EventHandler(this.AllCheck_chk_CheckedChanged);
            // 
            // ItemCodeSearchForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(679, 487);
            this.Controls.Add(this.AllCheck_chk);
            this.Controls.Add(this.lblmessage);
            this.Controls.Add(this.ItemCode_txt);
            this.Controls.Add(this.ItemName_lbl);
            this.Controls.Add(this.ItemName_txt);
            this.Controls.Add(this.ItemCode_lbl);
            this.Controls.Add(this.Exit_btn);
            this.Controls.Add(this.Ok_btn);
            this.Controls.Add(this.Search_btn);
            this.Controls.Add(this.Item_dgv);
            this.Margin = new System.Windows.Forms.Padding(7, 5, 7, 5);
            this.Name = "ItemCodeSearchForm";
            this.Text = "Item Search";
            this.TitleText = "Item Search";
            this.Load += new System.EventHandler(this.ItemCodeSearchForm_Load);
            this.Controls.SetChildIndex(this.Item_dgv, 0);
            this.Controls.SetChildIndex(this.Search_btn, 0);
            this.Controls.SetChildIndex(this.Ok_btn, 0);
            this.Controls.SetChildIndex(this.Exit_btn, 0);
            this.Controls.SetChildIndex(this.ItemCode_lbl, 0);
            this.Controls.SetChildIndex(this.ItemName_txt, 0);
            this.Controls.SetChildIndex(this.ItemName_lbl, 0);
            this.Controls.SetChildIndex(this.ItemCode_txt, 0);
            this.Controls.SetChildIndex(this.lblmessage, 0);
            this.Controls.SetChildIndex(this.AllCheck_chk, 0);
            ((System.ComponentModel.ISupportInitialize)(this.Item_dgv)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Framework.LabelCommon lblmessage;
        private Framework.TextBoxCommon ItemCode_txt;
        private Framework.LabelCommon ItemName_lbl;
        private Framework.TextBoxCommon ItemName_txt;
        private Framework.LabelCommon ItemCode_lbl;
        private Framework.ButtonCommon Exit_btn;
        private Framework.ButtonCommon Ok_btn;
        private Framework.ButtonCommon Search_btn;
        internal Framework.DataGridViewCommon Item_dgv;
        private Framework.CheckBoxCommon AllCheck_chk;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colSelect;
        private System.Windows.Forms.DataGridViewTextBoxColumn colItemCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn colItemName;
    }
}
