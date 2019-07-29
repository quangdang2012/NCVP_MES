namespace Com.Nidec.Mes.GlobalMasterMaintenance
{
    partial class ProcessWorkForm:FormCommonMaster
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProcessWorkForm));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.Clear_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.Exit_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.Delete_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.Update_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.Add_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.Search_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.ProcessWork_dgv = new Com.Nidec.Mes.Framework.DataGridViewCommon();
            this.Process_lbl = new Com.Nidec.Mes.Framework.LabelCommon();
            this.Process_cmb = new Com.Nidec.Mes.Framework.ComboBoxCommon();
            this.ProcessWorkCode_txt = new Com.Nidec.Mes.Framework.TextBoxCommon();
            this.ProcessWorkName_lbl = new Com.Nidec.Mes.Framework.LabelCommon();
            this.ProcessWorkName_txt = new Com.Nidec.Mes.Framework.TextBoxCommon();
            this.ProcessWorkCode_lbl = new Com.Nidec.Mes.Framework.LabelCommon();
            this.colProcessWorkId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colProcessWorkCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colProcessWorkName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colProcess = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colIsPhantom = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colProcessId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLineMachineSelection = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDisplayOrder = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.ProcessWork_dgv)).BeginInit();
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
            // ProcessWork_dgv
            // 
            this.ProcessWork_dgv.AllowUserToAddRows = false;
            this.ProcessWork_dgv.AllowUserToDeleteRows = false;
            this.ProcessWork_dgv.AllowUserToOrderColumns = true;
            this.ProcessWork_dgv.AllowUserToResizeRows = false;
            resources.ApplyResources(this.ProcessWork_dgv, "ProcessWork_dgv");
            this.ProcessWork_dgv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(232)))), ((int)(((byte)(180)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.ProcessWork_dgv.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.ProcessWork_dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ProcessWork_dgv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colProcessWorkId,
            this.colProcessWorkCode,
            this.colProcessWorkName,
            this.colProcess,
            this.colIsPhantom,
            this.colProcessId,
            this.colLineMachineSelection,
            this.colDisplayOrder});
            this.ProcessWork_dgv.ControlId = null;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.ProcessWork_dgv.DefaultCellStyle = dataGridViewCellStyle2;
            this.ProcessWork_dgv.EnableHeadersVisualStyles = false;
            this.ProcessWork_dgv.MultiSelect = false;
            this.ProcessWork_dgv.Name = "ProcessWork_dgv";
            this.ProcessWork_dgv.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(232)))), ((int)(((byte)(180)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.ProcessWork_dgv.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.ProcessWork_dgv.RowHeadersVisible = false;
            this.ProcessWork_dgv.RowTemplate.Height = 21;
            this.ProcessWork_dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.ProcessWork_dgv.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.ProcessWork_dgv_CellClick);
            this.ProcessWork_dgv.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.ProcessWork_dgv_CellDoubleClick);
            this.ProcessWork_dgv.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.ProcessWork_dgv_ColumnHeaderMouseClick);
            // 
            // Process_lbl
            // 
            resources.ApplyResources(this.Process_lbl, "Process_lbl");
            this.Process_lbl.ControlId = null;
            this.Process_lbl.Name = "Process_lbl";
            // 
            // Process_cmb
            // 
            this.Process_cmb.ControlId = null;
            resources.ApplyResources(this.Process_cmb, "Process_cmb");
            this.Process_cmb.FormattingEnabled = true;
            this.Process_cmb.Name = "Process_cmb";
            // 
            // ProcessWorkCode_txt
            // 
            this.ProcessWorkCode_txt.ControlId = null;
            resources.ApplyResources(this.ProcessWorkCode_txt, "ProcessWorkCode_txt");
            this.ProcessWorkCode_txt.InputType = Com.Nidec.Mes.Framework.TextBoxCommon.InputTypeList.All;
            this.ProcessWorkCode_txt.Name = "ProcessWorkCode_txt";
            // 
            // ProcessWorkName_lbl
            // 
            resources.ApplyResources(this.ProcessWorkName_lbl, "ProcessWorkName_lbl");
            this.ProcessWorkName_lbl.ControlId = null;
            this.ProcessWorkName_lbl.Name = "ProcessWorkName_lbl";
            // 
            // ProcessWorkName_txt
            // 
            this.ProcessWorkName_txt.ControlId = null;
            resources.ApplyResources(this.ProcessWorkName_txt, "ProcessWorkName_txt");
            this.ProcessWorkName_txt.InputType = Com.Nidec.Mes.Framework.TextBoxCommon.InputTypeList.All;
            this.ProcessWorkName_txt.Name = "ProcessWorkName_txt";
            // 
            // ProcessWorkCode_lbl
            // 
            resources.ApplyResources(this.ProcessWorkCode_lbl, "ProcessWorkCode_lbl");
            this.ProcessWorkCode_lbl.ControlId = null;
            this.ProcessWorkCode_lbl.Name = "ProcessWorkCode_lbl";
            // 
            // colProcessWorkId
            // 
            this.colProcessWorkId.DataPropertyName = "ProcessWorkId";
            resources.ApplyResources(this.colProcessWorkId, "colProcessWorkId");
            this.colProcessWorkId.Name = "colProcessWorkId";
            this.colProcessWorkId.ReadOnly = true;
            // 
            // colProcessWorkCode
            // 
            this.colProcessWorkCode.DataPropertyName = "ProcessWorkCode";
            resources.ApplyResources(this.colProcessWorkCode, "colProcessWorkCode");
            this.colProcessWorkCode.Name = "colProcessWorkCode";
            this.colProcessWorkCode.ReadOnly = true;
            // 
            // colProcessWorkName
            // 
            this.colProcessWorkName.DataPropertyName = "ProcessWorkName";
            resources.ApplyResources(this.colProcessWorkName, "colProcessWorkName");
            this.colProcessWorkName.Name = "colProcessWorkName";
            this.colProcessWorkName.ReadOnly = true;
            // 
            // colProcess
            // 
            this.colProcess.DataPropertyName = "ProcessCode";
            resources.ApplyResources(this.colProcess, "colProcess");
            this.colProcess.Name = "colProcess";
            this.colProcess.ReadOnly = true;
            // 
            // colIsPhantom
            // 
            this.colIsPhantom.DataPropertyName = "IsPhantomDisplay";
            resources.ApplyResources(this.colIsPhantom, "colIsPhantom");
            this.colIsPhantom.Name = "colIsPhantom";
            this.colIsPhantom.ReadOnly = true;
            // 
            // colProcessId
            // 
            this.colProcessId.DataPropertyName = "ProcessId";
            resources.ApplyResources(this.colProcessId, "colProcessId");
            this.colProcessId.Name = "colProcessId";
            this.colProcessId.ReadOnly = true;
            // 
            // colLineMachineSelection
            // 
            this.colLineMachineSelection.DataPropertyName = "LineMachineSelectionDisplay";
            resources.ApplyResources(this.colLineMachineSelection, "colLineMachineSelection");
            this.colLineMachineSelection.Name = "colLineMachineSelection";
            this.colLineMachineSelection.ReadOnly = true;
            // 
            // colDisplayOrder
            // 
            this.colDisplayOrder.DataPropertyName = "DisplayOrder";
            resources.ApplyResources(this.colDisplayOrder, "colDisplayOrder");
            this.colDisplayOrder.Name = "colDisplayOrder";
            this.colDisplayOrder.ReadOnly = true;
            // 
            // ProcessWorkForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ControlId = "bpmf015";
            this.Controls.Add(this.Process_lbl);
            this.Controls.Add(this.Process_cmb);
            this.Controls.Add(this.ProcessWorkCode_txt);
            this.Controls.Add(this.ProcessWorkName_lbl);
            this.Controls.Add(this.ProcessWorkName_txt);
            this.Controls.Add(this.ProcessWorkCode_lbl);
            this.Controls.Add(this.Clear_btn);
            this.Controls.Add(this.Exit_btn);
            this.Controls.Add(this.Delete_btn);
            this.Controls.Add(this.Update_btn);
            this.Controls.Add(this.Add_btn);
            this.Controls.Add(this.Search_btn);
            this.Controls.Add(this.ProcessWork_dgv);
            this.Name = "ProcessWorkForm";
            this.TitleText = "FormCommon";
            this.Load += new System.EventHandler(this.ProcessWorkForm_Load);
            this.Controls.SetChildIndex(this.ProcessWork_dgv, 0);
            this.Controls.SetChildIndex(this.Search_btn, 0);
            this.Controls.SetChildIndex(this.Add_btn, 0);
            this.Controls.SetChildIndex(this.Update_btn, 0);
            this.Controls.SetChildIndex(this.Delete_btn, 0);
            this.Controls.SetChildIndex(this.Exit_btn, 0);
            this.Controls.SetChildIndex(this.Clear_btn, 0);
            this.Controls.SetChildIndex(this.ProcessWorkCode_lbl, 0);
            this.Controls.SetChildIndex(this.ProcessWorkName_txt, 0);
            this.Controls.SetChildIndex(this.ProcessWorkName_lbl, 0);
            this.Controls.SetChildIndex(this.ProcessWorkCode_txt, 0);
            this.Controls.SetChildIndex(this.Process_cmb, 0);
            this.Controls.SetChildIndex(this.Process_lbl, 0);
            ((System.ComponentModel.ISupportInitialize)(this.ProcessWork_dgv)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        protected Com.Nidec.Mes.Framework.ButtonCommon Clear_btn;
        protected Com.Nidec.Mes.Framework.ButtonCommon Exit_btn;
        protected Com.Nidec.Mes.Framework.ButtonCommon Delete_btn;
        protected Com.Nidec.Mes.Framework.ButtonCommon Update_btn;
        protected Com.Nidec.Mes.Framework.ButtonCommon Add_btn;
        protected Com.Nidec.Mes.Framework.ButtonCommon Search_btn;
        protected Com.Nidec.Mes.Framework.DataGridViewCommon ProcessWork_dgv;
        protected Com.Nidec.Mes.Framework.LabelCommon Process_lbl;
        protected Com.Nidec.Mes.Framework.ComboBoxCommon Process_cmb;
        protected Com.Nidec.Mes.Framework.TextBoxCommon ProcessWorkCode_txt;
        protected Com.Nidec.Mes.Framework.LabelCommon ProcessWorkName_lbl;
        protected Com.Nidec.Mes.Framework.TextBoxCommon ProcessWorkName_txt;
        protected Com.Nidec.Mes.Framework.LabelCommon ProcessWorkCode_lbl;
        protected System.Windows.Forms.DataGridViewTextBoxColumn colProcessWorkId;
        protected System.Windows.Forms.DataGridViewTextBoxColumn colProcessWorkCode;
        protected System.Windows.Forms.DataGridViewTextBoxColumn colProcessWorkName;
        protected System.Windows.Forms.DataGridViewTextBoxColumn colProcess;
        protected System.Windows.Forms.DataGridViewTextBoxColumn colIsPhantom;
        protected System.Windows.Forms.DataGridViewTextBoxColumn colProcessId;
        protected System.Windows.Forms.DataGridViewTextBoxColumn colLineMachineSelection;
        protected System.Windows.Forms.DataGridViewTextBoxColumn colDisplayOrder;
    }
}