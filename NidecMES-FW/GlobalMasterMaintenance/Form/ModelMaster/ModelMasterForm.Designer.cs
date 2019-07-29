﻿namespace Com.Nidec.Mes.GlobalMasterMaintenance
{
    partial class ModelMasterForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ModelMasterForm));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.ModelCode_txt = new Com.Nidec.Mes.Framework.TextBoxCommon();
            this.ModelName_lbl = new Com.Nidec.Mes.Framework.LabelCommon();
            this.ModelName_txt = new Com.Nidec.Mes.Framework.TextBoxCommon();
            this.ModelCode_lbl = new Com.Nidec.Mes.Framework.LabelCommon();
            this.Clear_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.Exit_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.Delete_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.Update_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.Add_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.Search_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.Machine_dgv = new Com.Nidec.Mes.Framework.DataGridViewCommon();
            this.colModelId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colModelCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colModelName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.Machine_dgv)).BeginInit();
            this.SuspendLayout();
            // 
            // ModelCode_txt
            // 
            this.ModelCode_txt.ControlId = null;
            resources.ApplyResources(this.ModelCode_txt, "ModelCode_txt");
            this.ModelCode_txt.InputType = Com.Nidec.Mes.Framework.TextBoxCommon.InputTypeList.All;
            this.ModelCode_txt.Name = "ModelCode_txt";
            // 
            // ModelName_lbl
            // 
            resources.ApplyResources(this.ModelName_lbl, "ModelName_lbl");
            this.ModelName_lbl.ControlId = null;
            this.ModelName_lbl.Name = "ModelName_lbl";
            // 
            // ModelName_txt
            // 
            this.ModelName_txt.ControlId = null;
            resources.ApplyResources(this.ModelName_txt, "ModelName_txt");
            this.ModelName_txt.InputType = Com.Nidec.Mes.Framework.TextBoxCommon.InputTypeList.All;
            this.ModelName_txt.Name = "ModelName_txt";
            // 
            // ModelCode_lbl
            // 
            resources.ApplyResources(this.ModelCode_lbl, "ModelCode_lbl");
            this.ModelCode_lbl.ControlId = null;
            this.ModelCode_lbl.Name = "ModelCode_lbl";
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
            // Machine_dgv
            // 
            this.Machine_dgv.AllowUserToAddRows = false;
            this.Machine_dgv.AllowUserToDeleteRows = false;
            this.Machine_dgv.AllowUserToOrderColumns = true;
            this.Machine_dgv.AllowUserToResizeRows = false;
            resources.ApplyResources(this.Machine_dgv, "Machine_dgv");
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(232)))), ((int)(((byte)(180)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.Machine_dgv.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.Machine_dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Machine_dgv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colModelId,
            this.colModelCode,
            this.colModelName});
            this.Machine_dgv.ControlId = null;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.Machine_dgv.DefaultCellStyle = dataGridViewCellStyle2;
            this.Machine_dgv.EnableHeadersVisualStyles = false;
            this.Machine_dgv.MultiSelect = false;
            this.Machine_dgv.Name = "Machine_dgv";
            this.Machine_dgv.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(232)))), ((int)(((byte)(180)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.Machine_dgv.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.Machine_dgv.RowHeadersVisible = false;
            this.Machine_dgv.RowTemplate.Height = 21;
            this.Machine_dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.Machine_dgv.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Machine_dgv_CellClick);
            this.Machine_dgv.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Machine_dgv_CellDoubleClick);
            // 
            // colModelId
            // 
            this.colModelId.DataPropertyName = "ModelId";
            resources.ApplyResources(this.colModelId, "colModelId");
            this.colModelId.Name = "colModelId";
            this.colModelId.ReadOnly = true;
            // 
            // colModelCode
            // 
            this.colModelCode.DataPropertyName = "ModelCode";
            resources.ApplyResources(this.colModelCode, "colModelCode");
            this.colModelCode.Name = "colModelCode";
            this.colModelCode.ReadOnly = true;
            // 
            // colModelName
            // 
            this.colModelName.DataPropertyName = "ModelName";
            resources.ApplyResources(this.colModelName, "colModelName");
            this.colModelName.Name = "colModelName";
            this.colModelName.ReadOnly = true;
            // 
            // ModelMasterForm
            // 
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.ModelCode_txt);
            this.Controls.Add(this.ModelName_lbl);
            this.Controls.Add(this.ModelName_txt);
            this.Controls.Add(this.ModelCode_lbl);
            this.Controls.Add(this.Clear_btn);
            this.Controls.Add(this.Exit_btn);
            this.Controls.Add(this.Delete_btn);
            this.Controls.Add(this.Update_btn);
            this.Controls.Add(this.Add_btn);
            this.Controls.Add(this.Search_btn);
            this.Controls.Add(this.Machine_dgv);
            this.Name = "ModelMasterForm";
            this.TitleText = "FormCommon";
            this.Controls.SetChildIndex(this.Machine_dgv, 0);
            this.Controls.SetChildIndex(this.Search_btn, 0);
            this.Controls.SetChildIndex(this.Add_btn, 0);
            this.Controls.SetChildIndex(this.Update_btn, 0);
            this.Controls.SetChildIndex(this.Delete_btn, 0);
            this.Controls.SetChildIndex(this.Exit_btn, 0);
            this.Controls.SetChildIndex(this.Clear_btn, 0);
            this.Controls.SetChildIndex(this.ModelCode_lbl, 0);
            this.Controls.SetChildIndex(this.ModelName_txt, 0);
            this.Controls.SetChildIndex(this.ModelName_lbl, 0);
            this.Controls.SetChildIndex(this.ModelCode_txt, 0);
            ((System.ComponentModel.ISupportInitialize)(this.Machine_dgv)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Com.Nidec.Mes.Framework.TextBoxCommon ModelCode_txt;
        private Com.Nidec.Mes.Framework.LabelCommon ModelName_lbl;
        private Com.Nidec.Mes.Framework.TextBoxCommon ModelName_txt;
        private Com.Nidec.Mes.Framework.LabelCommon ModelCode_lbl;
        private Com.Nidec.Mes.Framework.ButtonCommon Clear_btn;
        private Com.Nidec.Mes.Framework.ButtonCommon Exit_btn;
        private Com.Nidec.Mes.Framework.ButtonCommon Delete_btn;
        private Com.Nidec.Mes.Framework.ButtonCommon Update_btn;
        private Com.Nidec.Mes.Framework.ButtonCommon Add_btn;
        private Com.Nidec.Mes.Framework.ButtonCommon Search_btn;
        internal Com.Nidec.Mes.Framework.DataGridViewCommon Machine_dgv;
        private System.Windows.Forms.DataGridViewTextBoxColumn colModelId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colModelCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn colModelName;
    }
}
