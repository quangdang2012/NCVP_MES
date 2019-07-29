namespace Com.Nidec.Mes.GlobalMasterMaintenance
{
    partial class CountryLanguageForm:FormCommonMaster
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CountryLanguageForm));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.Clear_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.Exit_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.Delete_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.Add_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.Search_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.CntryLang_dgv = new Com.Nidec.Mes.Framework.DataGridViewCommon();
            this.colCountry = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLanguage = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Language_lbl = new Com.Nidec.Mes.Framework.LabelCommon();
            this.Language_cmb = new Com.Nidec.Mes.Framework.ComboBoxCommon();
            this.Country_lbl = new Com.Nidec.Mes.Framework.LabelCommon();
            this.Country_cmb = new Com.Nidec.Mes.Framework.ComboBoxCommon();
            this.Update_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            ((System.ComponentModel.ISupportInitialize)(this.CntryLang_dgv)).BeginInit();
            this.SuspendLayout();
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
            // CntryLang_dgv
            // 
            this.CntryLang_dgv.AllowUserToAddRows = false;
            this.CntryLang_dgv.AllowUserToDeleteRows = false;
            this.CntryLang_dgv.AllowUserToOrderColumns = true;
            this.CntryLang_dgv.AllowUserToResizeRows = false;
            resources.ApplyResources(this.CntryLang_dgv, "CntryLang_dgv");
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(232)))), ((int)(((byte)(180)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.CntryLang_dgv.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.CntryLang_dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.CntryLang_dgv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colCountry,
            this.colLanguage});
            this.CntryLang_dgv.ControlId = null;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.CntryLang_dgv.DefaultCellStyle = dataGridViewCellStyle2;
            this.CntryLang_dgv.EnableHeadersVisualStyles = false;
            this.CntryLang_dgv.MultiSelect = false;
            this.CntryLang_dgv.Name = "CntryLang_dgv";
            this.CntryLang_dgv.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(232)))), ((int)(((byte)(180)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.CntryLang_dgv.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.CntryLang_dgv.RowHeadersVisible = false;
            this.CntryLang_dgv.RowTemplate.Height = 21;
            this.CntryLang_dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.CntryLang_dgv.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.CntryLang_dgv_CellClick);
            this.CntryLang_dgv.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.CntryLang_dgv_ColumnHeaderMouseClick);
            this.CntryLang_dgv.Sorted += new System.EventHandler(this.CntryLang_dgv_Sorted);
            // 
            // colCountry
            // 
            this.colCountry.DataPropertyName = "Country";
            this.colCountry.FillWeight = 5.076141F;
            this.colCountry.Frozen = true;
            resources.ApplyResources(this.colCountry, "colCountry");
            this.colCountry.Name = "colCountry";
            this.colCountry.ReadOnly = true;
            // 
            // colLanguage
            // 
            this.colLanguage.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colLanguage.DataPropertyName = "Language";
            this.colLanguage.FillWeight = 194.9239F;
            resources.ApplyResources(this.colLanguage, "colLanguage");
            this.colLanguage.Name = "colLanguage";
            this.colLanguage.ReadOnly = true;
            // 
            // Language_lbl
            // 
            resources.ApplyResources(this.Language_lbl, "Language_lbl");
            this.Language_lbl.ControlId = null;
            this.Language_lbl.Name = "Language_lbl";
            // 
            // Language_cmb
            // 
            this.Language_cmb.ControlId = null;
            resources.ApplyResources(this.Language_cmb, "Language_cmb");
            this.Language_cmb.FormattingEnabled = true;
            this.Language_cmb.Name = "Language_cmb";
            // 
            // Country_lbl
            // 
            resources.ApplyResources(this.Country_lbl, "Country_lbl");
            this.Country_lbl.ControlId = null;
            this.Country_lbl.Name = "Country_lbl";
            // 
            // Country_cmb
            // 
            this.Country_cmb.ControlId = null;
            resources.ApplyResources(this.Country_cmb, "Country_cmb");
            this.Country_cmb.FormattingEnabled = true;
            this.Country_cmb.Name = "Country_cmb";
            this.Country_cmb.SelectedIndexChanged += new System.EventHandler(this.Country_cmb_SelectedIndexChanged);
            this.Country_cmb.Leave += new System.EventHandler(this.Country_cmb_Leave);
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
            // CountryLanguageForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ControlId = "bpmf005";
            this.Controls.Add(this.Clear_btn);
            this.Controls.Add(this.Exit_btn);
            this.Controls.Add(this.Delete_btn);
            this.Controls.Add(this.Update_btn);
            this.Controls.Add(this.Add_btn);
            this.Controls.Add(this.Search_btn);
            this.Controls.Add(this.CntryLang_dgv);
            this.Controls.Add(this.Language_lbl);
            this.Controls.Add(this.Language_cmb);
            this.Controls.Add(this.Country_lbl);
            this.Controls.Add(this.Country_cmb);
            this.Name = "CountryLanguageForm";
            this.TitleText = "FormCommon";
            this.Load += new System.EventHandler(this.CountryLanguageForm_Load);
            this.Controls.SetChildIndex(this.Country_cmb, 0);
            this.Controls.SetChildIndex(this.Country_lbl, 0);
            this.Controls.SetChildIndex(this.Language_cmb, 0);
            this.Controls.SetChildIndex(this.Language_lbl, 0);
            this.Controls.SetChildIndex(this.CntryLang_dgv, 0);
            this.Controls.SetChildIndex(this.Search_btn, 0);
            this.Controls.SetChildIndex(this.Add_btn, 0);
            this.Controls.SetChildIndex(this.Update_btn, 0);
            this.Controls.SetChildIndex(this.Delete_btn, 0);
            this.Controls.SetChildIndex(this.Exit_btn, 0);
            this.Controls.SetChildIndex(this.Clear_btn, 0);
            ((System.ComponentModel.ISupportInitialize)(this.CntryLang_dgv)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Com.Nidec.Mes.Framework.ButtonCommon Clear_btn;
        private Com.Nidec.Mes.Framework.ButtonCommon Exit_btn;
        private Com.Nidec.Mes.Framework.ButtonCommon Delete_btn;
        private Com.Nidec.Mes.Framework.ButtonCommon Add_btn;
        private Com.Nidec.Mes.Framework.ButtonCommon Search_btn;
        internal Com.Nidec.Mes.Framework.DataGridViewCommon CntryLang_dgv;
        private Com.Nidec.Mes.Framework.LabelCommon Language_lbl;
        private Com.Nidec.Mes.Framework.ComboBoxCommon Language_cmb;
        private Com.Nidec.Mes.Framework.LabelCommon Country_lbl;
        private Com.Nidec.Mes.Framework.ComboBoxCommon Country_cmb;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCountry;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLanguage;
        private Framework.ButtonCommon Update_btn;
    }
}