namespace Com.Nidec.Mes.GlobalMasterMaintenance
{
    partial class FactoryMasterForm: FormCommonMaster
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FactoryMasterForm));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.FactoryCode_txt = new Com.Nidec.Mes.Framework.TextBoxCommon();
            this.FactoryCode_lbl = new Com.Nidec.Mes.Framework.LabelCommon();
            this.FactoryName_txt = new Com.Nidec.Mes.Framework.TextBoxCommon();
            this.FactoryName_lbl = new Com.Nidec.Mes.Framework.LabelCommon();
            this.Add_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.Search_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.FactoryDetails_dgv = new Com.Nidec.Mes.Framework.DataGridViewCommon();
            this.colFactoryCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFactoryName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Exit_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.Delete_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.Update_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.Clear_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            ((System.ComponentModel.ISupportInitialize)(this.FactoryDetails_dgv)).BeginInit();
            this.SuspendLayout();
            // 
            // FactoryCode_txt
            // 
            this.FactoryCode_txt.ControlId = null;
            resources.ApplyResources(this.FactoryCode_txt, "FactoryCode_txt");
            this.FactoryCode_txt.InputType = Com.Nidec.Mes.Framework.TextBoxCommon.InputTypeList.All;
            this.FactoryCode_txt.Name = "FactoryCode_txt";
            // 
            // FactoryCode_lbl
            // 
            resources.ApplyResources(this.FactoryCode_lbl, "FactoryCode_lbl");
            this.FactoryCode_lbl.ControlId = null;
            this.FactoryCode_lbl.Name = "FactoryCode_lbl";
            // 
            // FactoryName_txt
            // 
            this.FactoryName_txt.ControlId = null;
            resources.ApplyResources(this.FactoryName_txt, "FactoryName_txt");
            this.FactoryName_txt.InputType = Com.Nidec.Mes.Framework.TextBoxCommon.InputTypeList.All;
            this.FactoryName_txt.Name = "FactoryName_txt";
            // 
            // FactoryName_lbl
            // 
            resources.ApplyResources(this.FactoryName_lbl, "FactoryName_lbl");
            this.FactoryName_lbl.ControlId = null;
            this.FactoryName_lbl.Name = "FactoryName_lbl";
            // 
            // Add_btn
            // 
            this.Add_btn.BackColor = System.Drawing.SystemColors.Control;
            this.Add_btn.ControlId = null;
            resources.ApplyResources(this.Add_btn, "Add_btn");
            this.Add_btn.Name = "Add_btn";
            this.Add_btn.UseVisualStyleBackColor = true;
            this.Add_btn.Click += new System.EventHandler(this.Add_btn_Click);
            // 
            // Search_btn
            // 
            this.Search_btn.BackColor = System.Drawing.SystemColors.Control;
            this.Search_btn.ControlId = null;
            resources.ApplyResources(this.Search_btn, "Search_btn");
            this.Search_btn.Name = "Search_btn";
            this.Search_btn.UseVisualStyleBackColor = true;
            this.Search_btn.Click += new System.EventHandler(this.Search_btn_Click);
            // 
            // FactoryDetails_dgv
            // 
            this.FactoryDetails_dgv.AllowUserToAddRows = false;
            this.FactoryDetails_dgv.AllowUserToDeleteRows = false;
            this.FactoryDetails_dgv.AllowUserToOrderColumns = true;
            this.FactoryDetails_dgv.AllowUserToResizeRows = false;
            resources.ApplyResources(this.FactoryDetails_dgv, "FactoryDetails_dgv");
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(232)))), ((int)(((byte)(180)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.FactoryDetails_dgv.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.FactoryDetails_dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.FactoryDetails_dgv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colFactoryCode,
            this.colFactoryName});
            this.FactoryDetails_dgv.ControlId = null;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.FactoryDetails_dgv.DefaultCellStyle = dataGridViewCellStyle2;
            this.FactoryDetails_dgv.EnableHeadersVisualStyles = false;
            this.FactoryDetails_dgv.MultiSelect = false;
            this.FactoryDetails_dgv.Name = "FactoryDetails_dgv";
            this.FactoryDetails_dgv.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(232)))), ((int)(((byte)(180)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.FactoryDetails_dgv.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.FactoryDetails_dgv.RowHeadersVisible = false;
            this.FactoryDetails_dgv.RowTemplate.Height = 21;
            this.FactoryDetails_dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.FactoryDetails_dgv.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.FactoryDetails_dgv_CellClick);
            this.FactoryDetails_dgv.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.FactoryDetails_dgv_CellDoubleClick);
            this.FactoryDetails_dgv.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.FactoryDetails_dgv_ColumnHeaderMouseClick);
            // 
            // colFactoryCode
            // 
            this.colFactoryCode.DataPropertyName = "FactoryCode";
            this.colFactoryCode.Frozen = true;
            resources.ApplyResources(this.colFactoryCode, "colFactoryCode");
            this.colFactoryCode.Name = "colFactoryCode";
            this.colFactoryCode.ReadOnly = true;
            // 
            // colFactoryName
            // 
            this.colFactoryName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colFactoryName.DataPropertyName = "FactoryName";
            resources.ApplyResources(this.colFactoryName, "colFactoryName");
            this.colFactoryName.Name = "colFactoryName";
            this.colFactoryName.ReadOnly = true;
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
            // Delete_btn
            // 
            resources.ApplyResources(this.Delete_btn, "Delete_btn");
            this.Delete_btn.BackColor = System.Drawing.SystemColors.Control;
            this.Delete_btn.ControlId = null;
            this.Delete_btn.Name = "Delete_btn";
            this.Delete_btn.UseVisualStyleBackColor = true;
            this.Delete_btn.Click += new System.EventHandler(this.Delete_btn_Click);
            // 
            // Update_btn
            // 
            resources.ApplyResources(this.Update_btn, "Update_btn");
            this.Update_btn.BackColor = System.Drawing.SystemColors.Control;
            this.Update_btn.ControlId = null;
            this.Update_btn.Name = "Update_btn";
            this.Update_btn.UseVisualStyleBackColor = true;
            this.Update_btn.Click += new System.EventHandler(this.Update_btn_Click);
            // 
            // Clear_btn
            // 
            this.Clear_btn.BackColor = System.Drawing.SystemColors.Control;
            this.Clear_btn.ControlId = null;
            resources.ApplyResources(this.Clear_btn, "Clear_btn");
            this.Clear_btn.Name = "Clear_btn";
            this.Clear_btn.UseVisualStyleBackColor = true;
            this.Clear_btn.Click += new System.EventHandler(this.Clear_btn_Click);
            // 
            // FactoryMasterForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ControlId = "bpmf006";
            this.Controls.Add(this.Clear_btn);
            this.Controls.Add(this.Exit_btn);
            this.Controls.Add(this.Delete_btn);
            this.Controls.Add(this.Update_btn);
            this.Controls.Add(this.FactoryDetails_dgv);
            this.Controls.Add(this.Add_btn);
            this.Controls.Add(this.Search_btn);
            this.Controls.Add(this.FactoryName_txt);
            this.Controls.Add(this.FactoryName_lbl);
            this.Controls.Add(this.FactoryCode_txt);
            this.Controls.Add(this.FactoryCode_lbl);
            this.Name = "FactoryMasterForm";
            this.TitleText = "FormCommon";
            this.Load += new System.EventHandler(this.FactoryMasterForm_Load);
            this.Controls.SetChildIndex(this.FactoryCode_lbl, 0);
            this.Controls.SetChildIndex(this.FactoryCode_txt, 0);
            this.Controls.SetChildIndex(this.FactoryName_lbl, 0);
            this.Controls.SetChildIndex(this.FactoryName_txt, 0);
            this.Controls.SetChildIndex(this.Search_btn, 0);
            this.Controls.SetChildIndex(this.Add_btn, 0);
            this.Controls.SetChildIndex(this.FactoryDetails_dgv, 0);
            this.Controls.SetChildIndex(this.Update_btn, 0);
            this.Controls.SetChildIndex(this.Delete_btn, 0);
            this.Controls.SetChildIndex(this.Exit_btn, 0);
            this.Controls.SetChildIndex(this.Clear_btn, 0);
            ((System.ComponentModel.ISupportInitialize)(this.FactoryDetails_dgv)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        protected Com.Nidec.Mes.Framework.TextBoxCommon FactoryCode_txt;
        protected Com.Nidec.Mes.Framework.LabelCommon FactoryCode_lbl;
        protected Com.Nidec.Mes.Framework.TextBoxCommon FactoryName_txt;
        protected Com.Nidec.Mes.Framework.LabelCommon FactoryName_lbl;
        protected Com.Nidec.Mes.Framework.ButtonCommon Add_btn;
        protected Com.Nidec.Mes.Framework.ButtonCommon Search_btn;
        protected Com.Nidec.Mes.Framework.DataGridViewCommon FactoryDetails_dgv;
        protected Com.Nidec.Mes.Framework.ButtonCommon Exit_btn;
        protected Com.Nidec.Mes.Framework.ButtonCommon Delete_btn;
        protected Com.Nidec.Mes.Framework.ButtonCommon Update_btn;
        protected Com.Nidec.Mes.Framework.ButtonCommon Clear_btn;
        protected System.Windows.Forms.DataGridViewTextBoxColumn colFactoryCode;
        protected System.Windows.Forms.DataGridViewTextBoxColumn colFactoryName;
    }
}