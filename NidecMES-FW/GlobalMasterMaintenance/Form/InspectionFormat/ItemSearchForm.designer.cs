namespace Com.Nidec.Mes.GlobalMasterMaintenance
{
    partial class ItemSearchForm : FormCommonMaster
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ItemSearchForm));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.ItemCode_txt = new Com.Nidec.Mes.Framework.TextBoxCommon();
            this.ItemName_lbl = new Com.Nidec.Mes.Framework.LabelCommon();
            this.ItemName_txt = new Com.Nidec.Mes.Framework.TextBoxCommon();
            this.ItemCode_lbl = new Com.Nidec.Mes.Framework.LabelCommon();
            this.Exit_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.Ok_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.Search_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.Item_dgv = new Com.Nidec.Mes.Framework.DataGridViewCommon();
            this.lblmessage = new Com.Nidec.Mes.Framework.LabelCommon();
            this.colItemCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colItemName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.Item_dgv)).BeginInit();
            this.SuspendLayout();
            // 
            // ItemCode_txt
            // 
            resources.ApplyResources(this.ItemCode_txt, "ItemCode_txt");
            this.ItemCode_txt.ControlId = null;
            this.ItemCode_txt.InputType = Com.Nidec.Mes.Framework.TextBoxCommon.InputTypeList.All;
            this.ItemCode_txt.Name = "ItemCode_txt";
            // 
            // ItemName_lbl
            // 
            resources.ApplyResources(this.ItemName_lbl, "ItemName_lbl");
            this.ItemName_lbl.ControlId = null;
            this.ItemName_lbl.Name = "ItemName_lbl";
            // 
            // ItemName_txt
            // 
            resources.ApplyResources(this.ItemName_txt, "ItemName_txt");
            this.ItemName_txt.ControlId = null;
            this.ItemName_txt.InputType = Com.Nidec.Mes.Framework.TextBoxCommon.InputTypeList.All;
            this.ItemName_txt.Name = "ItemName_txt";
            // 
            // ItemCode_lbl
            // 
            resources.ApplyResources(this.ItemCode_lbl, "ItemCode_lbl");
            this.ItemCode_lbl.ControlId = null;
            this.ItemCode_lbl.Name = "ItemCode_lbl";
            // 
            // Exit_btn
            // 
            resources.ApplyResources(this.Exit_btn, "Exit_btn");
            this.Exit_btn.BackColor = System.Drawing.SystemColors.Control;
            this.Exit_btn.ControlId = null;
            this.Exit_btn.Name = "Exit_btn";
            this.Exit_btn.UseVisualStyleBackColor = true;
            this.Exit_btn.Click += new System.EventHandler(this.Exit_btn_Click);
            // 
            // Ok_btn
            // 
            resources.ApplyResources(this.Ok_btn, "Ok_btn");
            this.Ok_btn.BackColor = System.Drawing.SystemColors.Control;
            this.Ok_btn.ControlId = null;
            this.Ok_btn.Name = "Ok_btn";
            this.Ok_btn.UseVisualStyleBackColor = true;
            this.Ok_btn.Click += new System.EventHandler(this.Ok_btn_Click);
            // 
            // Search_btn
            // 
            resources.ApplyResources(this.Search_btn, "Search_btn");
            this.Search_btn.BackColor = System.Drawing.SystemColors.Control;
            this.Search_btn.ControlId = null;
            this.Search_btn.Name = "Search_btn";
            this.Search_btn.UseVisualStyleBackColor = true;
            this.Search_btn.Click += new System.EventHandler(this.Search_btn_Click);
            // 
            // Item_dgv
            // 
            resources.ApplyResources(this.Item_dgv, "Item_dgv");
            this.Item_dgv.AllowUserToAddRows = false;
            this.Item_dgv.AllowUserToDeleteRows = false;
            this.Item_dgv.AllowUserToOrderColumns = true;
            this.Item_dgv.AllowUserToResizeRows = false;
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
            this.Item_dgv.MultiSelect = false;
            this.Item_dgv.Name = "Item_dgv";
            this.Item_dgv.ReadOnly = true;
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
            this.Item_dgv.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Item_dgv_CellClick);
            this.Item_dgv.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Item_dgv_CellDoubleClick);
            // 
            // lblmessage
            // 
            resources.ApplyResources(this.lblmessage, "lblmessage");
            this.lblmessage.ControlId = null;
            this.lblmessage.ForeColor = System.Drawing.Color.Red;
            this.lblmessage.Name = "lblmessage";
            // 
            // colItemCode
            // 
            this.colItemCode.DataPropertyName = "SapItemCode";
            resources.ApplyResources(this.colItemCode, "colItemCode");
            this.colItemCode.Name = "colItemCode";
            this.colItemCode.ReadOnly = true;
            // 
            // colItemName
            // 
            this.colItemName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colItemName.DataPropertyName = "SapItemName";
            resources.ApplyResources(this.colItemName, "colItemName");
            this.colItemName.Name = "colItemName";
            this.colItemName.ReadOnly = true;
            // 
            // ItemSearchForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ControlId = "bpmf019";
            this.Controls.Add(this.lblmessage);
            this.Controls.Add(this.ItemCode_txt);
            this.Controls.Add(this.ItemName_lbl);
            this.Controls.Add(this.ItemName_txt);
            this.Controls.Add(this.ItemCode_lbl);
            this.Controls.Add(this.Exit_btn);
            this.Controls.Add(this.Ok_btn);
            this.Controls.Add(this.Search_btn);
            this.Controls.Add(this.Item_dgv);
            this.Name = "ItemSearchForm";
            this.TitleText = "FormCommon";
            this.Load += new System.EventHandler(this.ItemSearchForm_Load);
            this.Controls.SetChildIndex(this.Item_dgv, 0);
            this.Controls.SetChildIndex(this.Search_btn, 0);
            this.Controls.SetChildIndex(this.Ok_btn, 0);
            this.Controls.SetChildIndex(this.Exit_btn, 0);
            this.Controls.SetChildIndex(this.ItemCode_lbl, 0);
            this.Controls.SetChildIndex(this.ItemName_txt, 0);
            this.Controls.SetChildIndex(this.ItemName_lbl, 0);
            this.Controls.SetChildIndex(this.ItemCode_txt, 0);
            this.Controls.SetChildIndex(this.lblmessage, 0);
            ((System.ComponentModel.ISupportInitialize)(this.Item_dgv)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Com.Nidec.Mes.Framework.TextBoxCommon ItemCode_txt;
        private Com.Nidec.Mes.Framework.LabelCommon ItemName_lbl;
        private Com.Nidec.Mes.Framework.TextBoxCommon ItemName_txt;
        private Com.Nidec.Mes.Framework.LabelCommon ItemCode_lbl;
        private Com.Nidec.Mes.Framework.ButtonCommon Exit_btn;
        private Com.Nidec.Mes.Framework.ButtonCommon Ok_btn;
        private Com.Nidec.Mes.Framework.ButtonCommon Search_btn;
        internal Com.Nidec.Mes.Framework.DataGridViewCommon Item_dgv;
        private Framework.LabelCommon lblmessage;
        private System.Windows.Forms.DataGridViewTextBoxColumn colItemCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn colItemName;
    }
}