namespace Com.Nidec.Mes.GlobalMasterMaintenance
{
    partial class InspectionSelectionDatetypeValueForItemForm : FormCommonMaster
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InspectionSelectionDatetypeValueForItemForm));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.Exit_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.Delete_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.Update_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.InspectionSelectionValue_dgv = new Com.Nidec.Mes.Framework.DataGridViewCommon();
            this.colInspectionItemSelectionValueCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colInspectionItemSelectionDatatypeValueId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colInspectionItemSelectionValueText = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDisplayOrder = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Add_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.InspectionItem_cmb = new Com.Nidec.Mes.Framework.ComboBoxCommon();
            this.InspectionItem_lbl = new Com.Nidec.Mes.Framework.LabelCommon();
            this.Ok_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            ((System.ComponentModel.ISupportInitialize)(this.InspectionSelectionValue_dgv)).BeginInit();
            this.SuspendLayout();
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
            // InspectionSelectionValue_dgv
            // 
            resources.ApplyResources(this.InspectionSelectionValue_dgv, "InspectionSelectionValue_dgv");
            this.InspectionSelectionValue_dgv.AllowUserToAddRows = false;
            this.InspectionSelectionValue_dgv.AllowUserToDeleteRows = false;
            this.InspectionSelectionValue_dgv.AllowUserToOrderColumns = true;
            this.InspectionSelectionValue_dgv.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(232)))), ((int)(((byte)(180)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.InspectionSelectionValue_dgv.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.InspectionSelectionValue_dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.InspectionSelectionValue_dgv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colInspectionItemSelectionValueCode,
            this.colInspectionItemSelectionDatatypeValueId,
            this.colInspectionItemSelectionValueText,
            this.colDisplayOrder});
            this.InspectionSelectionValue_dgv.ControlId = null;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.InspectionSelectionValue_dgv.DefaultCellStyle = dataGridViewCellStyle3;
            this.InspectionSelectionValue_dgv.EnableHeadersVisualStyles = false;
            this.InspectionSelectionValue_dgv.MultiSelect = false;
            this.InspectionSelectionValue_dgv.Name = "InspectionSelectionValue_dgv";
            this.InspectionSelectionValue_dgv.ReadOnly = true;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(232)))), ((int)(((byte)(180)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.InspectionSelectionValue_dgv.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.InspectionSelectionValue_dgv.RowHeadersVisible = false;
            this.InspectionSelectionValue_dgv.RowTemplate.Height = 21;
            this.InspectionSelectionValue_dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.InspectionSelectionValue_dgv.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.InspectionTestInstructionDetail_dgv_CellClick);
            this.InspectionSelectionValue_dgv.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.InspectionTestInstructionDetail_dgv_CellDoubleClick);
            this.InspectionSelectionValue_dgv.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.InspectionTestInstructionDetail_dgv_ColumnHeaderMouseClick);
            // 
            // colInspectionItemSelectionValueCode
            // 
            this.colInspectionItemSelectionValueCode.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            resources.ApplyResources(this.colInspectionItemSelectionValueCode, "colInspectionItemSelectionValueCode");
            this.colInspectionItemSelectionValueCode.Name = "colInspectionItemSelectionValueCode";
            this.colInspectionItemSelectionValueCode.ReadOnly = true;
            // 
            // colInspectionItemSelectionDatatypeValueId
            // 
            this.colInspectionItemSelectionDatatypeValueId.DataPropertyName = "InspectionItemSelectionDatatypeValueId";
            resources.ApplyResources(this.colInspectionItemSelectionDatatypeValueId, "colInspectionItemSelectionDatatypeValueId");
            this.colInspectionItemSelectionDatatypeValueId.Name = "colInspectionItemSelectionDatatypeValueId";
            this.colInspectionItemSelectionDatatypeValueId.ReadOnly = true;
            // 
            // colInspectionItemSelectionValueText
            // 
            this.colInspectionItemSelectionValueText.DataPropertyName = "InspectionItemSelectionDatatypeValueText";
            this.colInspectionItemSelectionValueText.FillWeight = 98.47716F;
            resources.ApplyResources(this.colInspectionItemSelectionValueText, "colInspectionItemSelectionValueText");
            this.colInspectionItemSelectionValueText.Name = "colInspectionItemSelectionValueText";
            this.colInspectionItemSelectionValueText.ReadOnly = true;
            // 
            // colDisplayOrder
            // 
            this.colDisplayOrder.DataPropertyName = "DisplayOrder";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.colDisplayOrder.DefaultCellStyle = dataGridViewCellStyle2;
            this.colDisplayOrder.FillWeight = 101.5228F;
            resources.ApplyResources(this.colDisplayOrder, "colDisplayOrder");
            this.colDisplayOrder.Name = "colDisplayOrder";
            this.colDisplayOrder.ReadOnly = true;
            // 
            // Add_btn
            // 
            resources.ApplyResources(this.Add_btn, "Add_btn");
            this.Add_btn.BackColor = System.Drawing.SystemColors.Control;
            this.Add_btn.ControlId = null;
            this.Add_btn.Name = "Add_btn";
            this.Add_btn.UseVisualStyleBackColor = true;
            this.Add_btn.Click += new System.EventHandler(this.Add_btn_Click);
            // 
            // InspectionItem_cmb
            // 
            resources.ApplyResources(this.InspectionItem_cmb, "InspectionItem_cmb");
            this.InspectionItem_cmb.ControlId = null;
            this.InspectionItem_cmb.FormattingEnabled = true;
            this.InspectionItem_cmb.Name = "InspectionItem_cmb";
            // 
            // InspectionItem_lbl
            // 
            resources.ApplyResources(this.InspectionItem_lbl, "InspectionItem_lbl");
            this.InspectionItem_lbl.ControlId = null;
            this.InspectionItem_lbl.Name = "InspectionItem_lbl";
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
            // InspectionSelectionDatetypeValueForItemForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ControlId = "bpmf008";
            this.Controls.Add(this.Ok_btn);
            this.Controls.Add(this.InspectionItem_cmb);
            this.Controls.Add(this.InspectionItem_lbl);
            this.Controls.Add(this.Exit_btn);
            this.Controls.Add(this.Delete_btn);
            this.Controls.Add(this.Update_btn);
            this.Controls.Add(this.InspectionSelectionValue_dgv);
            this.Controls.Add(this.Add_btn);
            this.Name = "InspectionSelectionDatetypeValueForItemForm";
            this.TitleText = "Selection Value";
            this.Load += new System.EventHandler(this.InspectionSelectionDatetypeValueForItemForm_Load);
            this.Controls.SetChildIndex(this.Add_btn, 0);
            this.Controls.SetChildIndex(this.InspectionSelectionValue_dgv, 0);
            this.Controls.SetChildIndex(this.Update_btn, 0);
            this.Controls.SetChildIndex(this.Delete_btn, 0);
            this.Controls.SetChildIndex(this.Exit_btn, 0);
            this.Controls.SetChildIndex(this.InspectionItem_lbl, 0);
            this.Controls.SetChildIndex(this.InspectionItem_cmb, 0);
            this.Controls.SetChildIndex(this.Ok_btn, 0);
            ((System.ComponentModel.ISupportInitialize)(this.InspectionSelectionValue_dgv)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Com.Nidec.Mes.Framework.ButtonCommon Exit_btn;
        private Com.Nidec.Mes.Framework.ButtonCommon Delete_btn;
        private Com.Nidec.Mes.Framework.ButtonCommon Update_btn;
        internal Com.Nidec.Mes.Framework.DataGridViewCommon InspectionSelectionValue_dgv;
        private Com.Nidec.Mes.Framework.ButtonCommon Add_btn;
        private Framework.ComboBoxCommon InspectionItem_cmb;
        private Framework.LabelCommon InspectionItem_lbl;
        private Framework.ButtonCommon Ok_btn;
        private System.Windows.Forms.DataGridViewTextBoxColumn colInspectionItemSelectionValueCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn colInspectionItemSelectionDatatypeValueId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colInspectionItemSelectionValueText;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDisplayOrder;
    }
}