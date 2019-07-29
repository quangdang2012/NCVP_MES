namespace Com.Nidec.Mes.GlobalMasterMaintenance
{
    partial class InspectionSpecificationForm : FormCommonMaster
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InspectionSpecificationForm));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.InspectionItemId_cmb = new Com.Nidec.Mes.Framework.ComboBoxCommon();
            this.InspectionItemId_lbl = new Com.Nidec.Mes.Framework.LabelCommon();
            this.Clear_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.Exit_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.Delete_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.Update_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.InspectionSpecificationDetails_dgv = new Com.Nidec.Mes.Framework.DataGridViewCommon();
            this.colInspectionSpecificationCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colInspectionSpecificationText = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colValueFrom = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colValueTo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colUnit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colOperatorFrom = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colOperatorTo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colInspectionItemId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colInspectionItemName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSpecificationResultJudgeType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colInspectionSpecificationId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Add_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.Search_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.InspectionSpecificationText_txt = new Com.Nidec.Mes.Framework.TextBoxCommon();
            this.InspectionSpecificationText_lbl = new Com.Nidec.Mes.Framework.LabelCommon();
            this.InspectionSpecificationCode_txt = new Com.Nidec.Mes.Framework.TextBoxCommon();
            this.InspectionSpecificationCode_lbl = new Com.Nidec.Mes.Framework.LabelCommon();
            this.Copy_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            ((System.ComponentModel.ISupportInitialize)(this.InspectionSpecificationDetails_dgv)).BeginInit();
            this.SuspendLayout();
            // 
            // InspectionItemId_cmb
            // 
            this.InspectionItemId_cmb.ControlId = null;
            resources.ApplyResources(this.InspectionItemId_cmb, "InspectionItemId_cmb");
            this.InspectionItemId_cmb.FormattingEnabled = true;
            this.InspectionItemId_cmb.Name = "InspectionItemId_cmb";
            // 
            // InspectionItemId_lbl
            // 
            resources.ApplyResources(this.InspectionItemId_lbl, "InspectionItemId_lbl");
            this.InspectionItemId_lbl.ControlId = null;
            this.InspectionItemId_lbl.Name = "InspectionItemId_lbl";
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
            // Update_btn
            // 
            resources.ApplyResources(this.Update_btn, "Update_btn");
            this.Update_btn.BackColor = System.Drawing.SystemColors.Control;
            this.Update_btn.ControlId = null;
            this.Update_btn.Name = "Update_btn";
            this.Update_btn.UseVisualStyleBackColor = true;
            this.Update_btn.Click += new System.EventHandler(this.Update_btn_Click);
            // 
            // InspectionSpecificationDetails_dgv
            // 
            this.InspectionSpecificationDetails_dgv.AllowUserToAddRows = false;
            this.InspectionSpecificationDetails_dgv.AllowUserToDeleteRows = false;
            this.InspectionSpecificationDetails_dgv.AllowUserToOrderColumns = true;
            this.InspectionSpecificationDetails_dgv.AllowUserToResizeRows = false;
            resources.ApplyResources(this.InspectionSpecificationDetails_dgv, "InspectionSpecificationDetails_dgv");
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(232)))), ((int)(((byte)(180)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.InspectionSpecificationDetails_dgv.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.InspectionSpecificationDetails_dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.InspectionSpecificationDetails_dgv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colInspectionSpecificationCode,
            this.colInspectionSpecificationText,
            this.colValueFrom,
            this.colValueTo,
            this.colUnit,
            this.colOperatorFrom,
            this.colOperatorTo,
            this.colInspectionItemId,
            this.colInspectionItemName,
            this.colSpecificationResultJudgeType,
            this.colInspectionSpecificationId});
            this.InspectionSpecificationDetails_dgv.ControlId = null;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.InspectionSpecificationDetails_dgv.DefaultCellStyle = dataGridViewCellStyle2;
            this.InspectionSpecificationDetails_dgv.EnableHeadersVisualStyles = false;
            this.InspectionSpecificationDetails_dgv.MultiSelect = false;
            this.InspectionSpecificationDetails_dgv.Name = "InspectionSpecificationDetails_dgv";
            this.InspectionSpecificationDetails_dgv.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(232)))), ((int)(((byte)(180)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.InspectionSpecificationDetails_dgv.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.InspectionSpecificationDetails_dgv.RowHeadersVisible = false;
            this.InspectionSpecificationDetails_dgv.RowTemplate.Height = 21;
            this.InspectionSpecificationDetails_dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.InspectionSpecificationDetails_dgv.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.InspectionSpecificationDetails_dgv_CellClick);
            this.InspectionSpecificationDetails_dgv.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.InspectionSpecificationDetails_dgv_CellDoubleClick);
            this.InspectionSpecificationDetails_dgv.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.InspectionSpecificationDetails_dgv_ColumnHeaderMouseClick);
            // 
            // colInspectionSpecificationCode
            // 
            this.colInspectionSpecificationCode.DataPropertyName = "InspectionSpecificationCode";
            resources.ApplyResources(this.colInspectionSpecificationCode, "colInspectionSpecificationCode");
            this.colInspectionSpecificationCode.Name = "colInspectionSpecificationCode";
            this.colInspectionSpecificationCode.ReadOnly = true;
            // 
            // colInspectionSpecificationText
            // 
            this.colInspectionSpecificationText.DataPropertyName = "InspectionSpecificationText";
            resources.ApplyResources(this.colInspectionSpecificationText, "colInspectionSpecificationText");
            this.colInspectionSpecificationText.Name = "colInspectionSpecificationText";
            this.colInspectionSpecificationText.ReadOnly = true;
            // 
            // colValueFrom
            // 
            this.colValueFrom.DataPropertyName = "ValueFrom";
            resources.ApplyResources(this.colValueFrom, "colValueFrom");
            this.colValueFrom.Name = "colValueFrom";
            this.colValueFrom.ReadOnly = true;
            // 
            // colValueTo
            // 
            this.colValueTo.DataPropertyName = "ValueTo";
            resources.ApplyResources(this.colValueTo, "colValueTo");
            this.colValueTo.Name = "colValueTo";
            this.colValueTo.ReadOnly = true;
            // 
            // colUnit
            // 
            this.colUnit.DataPropertyName = "Unit";
            resources.ApplyResources(this.colUnit, "colUnit");
            this.colUnit.Name = "colUnit";
            this.colUnit.ReadOnly = true;
            // 
            // colOperatorFrom
            // 
            this.colOperatorFrom.DataPropertyName = "OperatorFrom";
            resources.ApplyResources(this.colOperatorFrom, "colOperatorFrom");
            this.colOperatorFrom.Name = "colOperatorFrom";
            this.colOperatorFrom.ReadOnly = true;
            // 
            // colOperatorTo
            // 
            this.colOperatorTo.DataPropertyName = "OperatorTo";
            resources.ApplyResources(this.colOperatorTo, "colOperatorTo");
            this.colOperatorTo.Name = "colOperatorTo";
            this.colOperatorTo.ReadOnly = true;
            // 
            // colInspectionItemId
            // 
            this.colInspectionItemId.DataPropertyName = "InspectionItemId";
            resources.ApplyResources(this.colInspectionItemId, "colInspectionItemId");
            this.colInspectionItemId.Name = "colInspectionItemId";
            this.colInspectionItemId.ReadOnly = true;
            // 
            // colInspectionItemName
            // 
            this.colInspectionItemName.DataPropertyName = "InspectionItemName";
            resources.ApplyResources(this.colInspectionItemName, "colInspectionItemName");
            this.colInspectionItemName.Name = "colInspectionItemName";
            this.colInspectionItemName.ReadOnly = true;
            // 
            // colSpecificationResultJudgeType
            // 
            this.colSpecificationResultJudgeType.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colSpecificationResultJudgeType.DataPropertyName = "SpecificationResultJudgeTypeMode";
            resources.ApplyResources(this.colSpecificationResultJudgeType, "colSpecificationResultJudgeType");
            this.colSpecificationResultJudgeType.Name = "colSpecificationResultJudgeType";
            this.colSpecificationResultJudgeType.ReadOnly = true;
            // 
            // colInspectionSpecificationId
            // 
            this.colInspectionSpecificationId.DataPropertyName = "InspectionSpecificationId";
            resources.ApplyResources(this.colInspectionSpecificationId, "colInspectionSpecificationId");
            this.colInspectionSpecificationId.Name = "colInspectionSpecificationId";
            this.colInspectionSpecificationId.ReadOnly = true;
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
            // InspectionSpecificationText_txt
            // 
            this.InspectionSpecificationText_txt.ControlId = null;
            resources.ApplyResources(this.InspectionSpecificationText_txt, "InspectionSpecificationText_txt");
            this.InspectionSpecificationText_txt.InputType = Com.Nidec.Mes.Framework.TextBoxCommon.InputTypeList.All;
            this.InspectionSpecificationText_txt.Name = "InspectionSpecificationText_txt";
            // 
            // InspectionSpecificationText_lbl
            // 
            resources.ApplyResources(this.InspectionSpecificationText_lbl, "InspectionSpecificationText_lbl");
            this.InspectionSpecificationText_lbl.ControlId = null;
            this.InspectionSpecificationText_lbl.Name = "InspectionSpecificationText_lbl";
            // 
            // InspectionSpecificationCode_txt
            // 
            this.InspectionSpecificationCode_txt.ControlId = null;
            resources.ApplyResources(this.InspectionSpecificationCode_txt, "InspectionSpecificationCode_txt");
            this.InspectionSpecificationCode_txt.InputType = Com.Nidec.Mes.Framework.TextBoxCommon.InputTypeList.All;
            this.InspectionSpecificationCode_txt.Name = "InspectionSpecificationCode_txt";
            // 
            // InspectionSpecificationCode_lbl
            // 
            resources.ApplyResources(this.InspectionSpecificationCode_lbl, "InspectionSpecificationCode_lbl");
            this.InspectionSpecificationCode_lbl.ControlId = null;
            this.InspectionSpecificationCode_lbl.Name = "InspectionSpecificationCode_lbl";
            // 
            // Copy_btn
            // 
            resources.ApplyResources(this.Copy_btn, "Copy_btn");
            this.Copy_btn.BackColor = System.Drawing.SystemColors.Control;
            this.Copy_btn.ControlId = null;
            this.Copy_btn.Name = "Copy_btn";
            this.Copy_btn.UseVisualStyleBackColor = true;
            this.Copy_btn.Click += new System.EventHandler(this.Copy_btn_Click);
            // 
            // InspectionSpecificationForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ControlId = "bpmf008";
            this.Controls.Add(this.Copy_btn);
            this.Controls.Add(this.InspectionItemId_cmb);
            this.Controls.Add(this.InspectionItemId_lbl);
            this.Controls.Add(this.Clear_btn);
            this.Controls.Add(this.Exit_btn);
            this.Controls.Add(this.Delete_btn);
            this.Controls.Add(this.Update_btn);
            this.Controls.Add(this.InspectionSpecificationDetails_dgv);
            this.Controls.Add(this.Add_btn);
            this.Controls.Add(this.Search_btn);
            this.Controls.Add(this.InspectionSpecificationText_txt);
            this.Controls.Add(this.InspectionSpecificationText_lbl);
            this.Controls.Add(this.InspectionSpecificationCode_txt);
            this.Controls.Add(this.InspectionSpecificationCode_lbl);
            this.Name = "InspectionSpecificationForm";
            this.TitleText = "FormCommon";
            this.Load += new System.EventHandler(this.InspectionSpecificationForm_Load);
            this.Controls.SetChildIndex(this.InspectionSpecificationCode_lbl, 0);
            this.Controls.SetChildIndex(this.InspectionSpecificationCode_txt, 0);
            this.Controls.SetChildIndex(this.InspectionSpecificationText_lbl, 0);
            this.Controls.SetChildIndex(this.InspectionSpecificationText_txt, 0);
            this.Controls.SetChildIndex(this.Search_btn, 0);
            this.Controls.SetChildIndex(this.Add_btn, 0);
            this.Controls.SetChildIndex(this.InspectionSpecificationDetails_dgv, 0);
            this.Controls.SetChildIndex(this.Update_btn, 0);
            this.Controls.SetChildIndex(this.Delete_btn, 0);
            this.Controls.SetChildIndex(this.Exit_btn, 0);
            this.Controls.SetChildIndex(this.Clear_btn, 0);
            this.Controls.SetChildIndex(this.InspectionItemId_lbl, 0);
            this.Controls.SetChildIndex(this.InspectionItemId_cmb, 0);
            this.Controls.SetChildIndex(this.Copy_btn, 0);
            ((System.ComponentModel.ISupportInitialize)(this.InspectionSpecificationDetails_dgv)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Com.Nidec.Mes.Framework.ButtonCommon Clear_btn;
        private Com.Nidec.Mes.Framework.ButtonCommon Exit_btn;
        private Com.Nidec.Mes.Framework.ButtonCommon Delete_btn;
        private Com.Nidec.Mes.Framework.ButtonCommon Update_btn;
        internal Com.Nidec.Mes.Framework.DataGridViewCommon InspectionSpecificationDetails_dgv;
        private Com.Nidec.Mes.Framework.ButtonCommon Add_btn;
        private Com.Nidec.Mes.Framework.ButtonCommon Search_btn;
        private Com.Nidec.Mes.Framework.TextBoxCommon InspectionSpecificationText_txt;
        private Com.Nidec.Mes.Framework.LabelCommon InspectionSpecificationText_lbl;
        private Com.Nidec.Mes.Framework.TextBoxCommon InspectionSpecificationCode_txt;
        private Com.Nidec.Mes.Framework.LabelCommon InspectionSpecificationCode_lbl;
        private Com.Nidec.Mes.Framework.ComboBoxCommon InspectionItemId_cmb;
        private Com.Nidec.Mes.Framework.LabelCommon InspectionItemId_lbl;
        private Framework.ButtonCommon Copy_btn;
        private System.Windows.Forms.DataGridViewTextBoxColumn colInspectionSpecificationCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn colInspectionSpecificationText;
        private System.Windows.Forms.DataGridViewTextBoxColumn colValueFrom;
        private System.Windows.Forms.DataGridViewTextBoxColumn colValueTo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colUnit;
        private System.Windows.Forms.DataGridViewTextBoxColumn colOperatorFrom;
        private System.Windows.Forms.DataGridViewTextBoxColumn colOperatorTo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colInspectionItemId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colInspectionItemName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSpecificationResultJudgeType;
        private System.Windows.Forms.DataGridViewTextBoxColumn colInspectionSpecificationId;
    }
}