namespace Com.Nidec.Mes.Common.Basic.MachineMaintenance.Form
{
    partial class ReportDownTimeForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReportDownTimeForm));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.model_lbl = new Com.Nidec.Mes.Framework.LabelCommon();
            this.process_lbl = new Com.Nidec.Mes.Framework.LabelCommon();
            this.model_cmb = new Com.Nidec.Mes.Framework.ComboBoxCommon();
            this.assy_cmb = new Com.Nidec.Mes.Framework.ComboBoxCommon();
            this.line_lbl = new Com.Nidec.Mes.Framework.LabelCommon();
            this.line_cmb = new Com.Nidec.Mes.Framework.ComboBoxCommon();
            this.machine_lbl = new Com.Nidec.Mes.Framework.LabelCommon();
            this.cause_lbl = new Com.Nidec.Mes.Framework.LabelCommon();
            this.machine_cmb = new Com.Nidec.Mes.Framework.ComboBoxCommon();
            this.action_cmb = new Com.Nidec.Mes.Framework.ComboBoxCommon();
            this.cause_cmb = new Com.Nidec.Mes.Framework.ComboBoxCommon();
            this.action_lbl = new Com.Nidec.Mes.Framework.LabelCommon();
            this.timeto_lbl = new Com.Nidec.Mes.Framework.LabelCommon();
            this.timefrom_lbl = new Com.Nidec.Mes.Framework.LabelCommon();
            this.reportdowntime_dgv = new Com.Nidec.Mes.Framework.DataGridViewCommon();
            this.col_downtime_report_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_model_cd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_line_cd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_assy = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_process_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_machine_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_time_from = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_time_to = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_cause = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_action = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_username = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.search_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.clear_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.export_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.update_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.add_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.Search_tbpnl = new System.Windows.Forms.TableLayoutPanel();
            this.timeto_dtp = new System.Windows.Forms.DateTimePicker();
            this.timefrom_dtp = new System.Windows.Forms.DateTimePicker();
            this.Delete_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            ((System.ComponentModel.ISupportInitialize)(this.reportdowntime_dgv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.Search_tbpnl.SuspendLayout();
            this.SuspendLayout();
            // 
            // model_lbl
            // 
            resources.ApplyResources(this.model_lbl, "model_lbl");
            this.model_lbl.ControlId = null;
            this.model_lbl.Name = "model_lbl";
            // 
            // process_lbl
            // 
            resources.ApplyResources(this.process_lbl, "process_lbl");
            this.process_lbl.ControlId = null;
            this.process_lbl.Name = "process_lbl";
            // 
            // model_cmb
            // 
            this.model_cmb.ControlId = null;
            resources.ApplyResources(this.model_cmb, "model_cmb");
            this.model_cmb.FormattingEnabled = true;
            this.model_cmb.Name = "model_cmb";
            this.model_cmb.SelectedIndexChanged += new System.EventHandler(this.model_cmb_SelectedIndexChanged);
            // 
            // assy_cmb
            // 
            this.assy_cmb.ControlId = null;
            resources.ApplyResources(this.assy_cmb, "assy_cmb");
            this.assy_cmb.FormattingEnabled = true;
            this.assy_cmb.Name = "assy_cmb";
            // 
            // line_lbl
            // 
            resources.ApplyResources(this.line_lbl, "line_lbl");
            this.line_lbl.ControlId = null;
            this.line_lbl.Name = "line_lbl";
            // 
            // line_cmb
            // 
            this.line_cmb.ControlId = null;
            resources.ApplyResources(this.line_cmb, "line_cmb");
            this.line_cmb.FormattingEnabled = true;
            this.line_cmb.Name = "line_cmb";
            // 
            // machine_lbl
            // 
            resources.ApplyResources(this.machine_lbl, "machine_lbl");
            this.machine_lbl.ControlId = null;
            this.machine_lbl.Name = "machine_lbl";
            // 
            // cause_lbl
            // 
            resources.ApplyResources(this.cause_lbl, "cause_lbl");
            this.cause_lbl.ControlId = null;
            this.cause_lbl.Name = "cause_lbl";
            // 
            // machine_cmb
            // 
            this.machine_cmb.ControlId = null;
            resources.ApplyResources(this.machine_cmb, "machine_cmb");
            this.machine_cmb.FormattingEnabled = true;
            this.machine_cmb.Name = "machine_cmb";
            this.machine_cmb.SelectedIndexChanged += new System.EventHandler(this.machine_cmb_SelectedIndexChanged);
            // 
            // action_cmb
            // 
            this.action_cmb.ControlId = null;
            resources.ApplyResources(this.action_cmb, "action_cmb");
            this.action_cmb.FormattingEnabled = true;
            this.action_cmb.Name = "action_cmb";
            // 
            // cause_cmb
            // 
            this.cause_cmb.ControlId = null;
            resources.ApplyResources(this.cause_cmb, "cause_cmb");
            this.cause_cmb.FormattingEnabled = true;
            this.cause_cmb.Name = "cause_cmb";
            // 
            // action_lbl
            // 
            resources.ApplyResources(this.action_lbl, "action_lbl");
            this.action_lbl.ControlId = null;
            this.action_lbl.Name = "action_lbl";
            // 
            // timeto_lbl
            // 
            resources.ApplyResources(this.timeto_lbl, "timeto_lbl");
            this.timeto_lbl.ControlId = null;
            this.timeto_lbl.Name = "timeto_lbl";
            // 
            // timefrom_lbl
            // 
            resources.ApplyResources(this.timefrom_lbl, "timefrom_lbl");
            this.timefrom_lbl.ControlId = null;
            this.timefrom_lbl.Name = "timefrom_lbl";
            // 
            // reportdowntime_dgv
            // 
            this.reportdowntime_dgv.AllowUserToAddRows = false;
            this.reportdowntime_dgv.AllowUserToDeleteRows = false;
            resources.ApplyResources(this.reportdowntime_dgv, "reportdowntime_dgv");
            this.reportdowntime_dgv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.reportdowntime_dgv.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(232)))), ((int)(((byte)(180)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.reportdowntime_dgv.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.reportdowntime_dgv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.col_downtime_report_id,
            this.col_model_cd,
            this.col_line_cd,
            this.col_assy,
            this.col_process_name,
            this.col_machine_name,
            this.col_time_from,
            this.col_time_to,
            this.col_cause,
            this.col_action,
            this.col_username});
            this.reportdowntime_dgv.ControlId = null;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.reportdowntime_dgv.DefaultCellStyle = dataGridViewCellStyle2;
            this.reportdowntime_dgv.Name = "reportdowntime_dgv";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(232)))), ((int)(((byte)(180)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.reportdowntime_dgv.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.reportdowntime_dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            // 
            // col_downtime_report_id
            // 
            this.col_downtime_report_id.DataPropertyName = "DowntimeReportId";
            resources.ApplyResources(this.col_downtime_report_id, "col_downtime_report_id");
            this.col_downtime_report_id.Name = "col_downtime_report_id";
            this.col_downtime_report_id.ReadOnly = true;
            // 
            // col_model_cd
            // 
            this.col_model_cd.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.col_model_cd.DataPropertyName = "ModelCode";
            resources.ApplyResources(this.col_model_cd, "col_model_cd");
            this.col_model_cd.Name = "col_model_cd";
            this.col_model_cd.ReadOnly = true;
            // 
            // col_line_cd
            // 
            this.col_line_cd.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.col_line_cd.DataPropertyName = "LineCode";
            resources.ApplyResources(this.col_line_cd, "col_line_cd");
            this.col_line_cd.Name = "col_line_cd";
            this.col_line_cd.ReadOnly = true;
            // 
            // col_assy
            // 
            this.col_assy.DataPropertyName = "ProcessName";
            resources.ApplyResources(this.col_assy, "col_assy");
            this.col_assy.Name = "col_assy";
            this.col_assy.ReadOnly = true;
            // 
            // col_process_name
            // 
            this.col_process_name.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.col_process_name.DataPropertyName = "ProcessWorkName";
            resources.ApplyResources(this.col_process_name, "col_process_name");
            this.col_process_name.Name = "col_process_name";
            this.col_process_name.ReadOnly = true;
            // 
            // col_machine_name
            // 
            this.col_machine_name.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.col_machine_name.DataPropertyName = "MachineName";
            resources.ApplyResources(this.col_machine_name, "col_machine_name");
            this.col_machine_name.Name = "col_machine_name";
            this.col_machine_name.ReadOnly = true;
            // 
            // col_time_from
            // 
            this.col_time_from.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.col_time_from.DataPropertyName = "TimeFrom";
            resources.ApplyResources(this.col_time_from, "col_time_from");
            this.col_time_from.Name = "col_time_from";
            this.col_time_from.ReadOnly = true;
            // 
            // col_time_to
            // 
            this.col_time_to.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.col_time_to.DataPropertyName = "TimeTo";
            resources.ApplyResources(this.col_time_to, "col_time_to");
            this.col_time_to.Name = "col_time_to";
            this.col_time_to.ReadOnly = true;
            // 
            // col_cause
            // 
            this.col_cause.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.col_cause.DataPropertyName = "DefectiveReasonName";
            resources.ApplyResources(this.col_cause, "col_cause");
            this.col_cause.Name = "col_cause";
            this.col_cause.ReadOnly = true;
            // 
            // col_action
            // 
            this.col_action.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.col_action.DataPropertyName = "ProductionWorkContentName";
            resources.ApplyResources(this.col_action, "col_action");
            this.col_action.Name = "col_action";
            this.col_action.ReadOnly = true;
            // 
            // col_username
            // 
            this.col_username.DataPropertyName = "RegistrationUserCode";
            resources.ApplyResources(this.col_username, "col_username");
            this.col_username.Name = "col_username";
            this.col_username.ReadOnly = true;
            // 
            // search_btn
            // 
            resources.ApplyResources(this.search_btn, "search_btn");
            this.search_btn.BackColor = System.Drawing.SystemColors.Control;
            this.search_btn.ControlId = null;
            this.search_btn.Name = "search_btn";
            this.search_btn.UseVisualStyleBackColor = false;
            this.search_btn.Click += new System.EventHandler(this.search_btn_Click);
            // 
            // clear_btn
            // 
            resources.ApplyResources(this.clear_btn, "clear_btn");
            this.clear_btn.BackColor = System.Drawing.SystemColors.Control;
            this.clear_btn.ControlId = null;
            this.clear_btn.Name = "clear_btn";
            this.clear_btn.UseVisualStyleBackColor = false;
            this.clear_btn.Click += new System.EventHandler(this.clear_btn_Click);
            // 
            // export_btn
            // 
            resources.ApplyResources(this.export_btn, "export_btn");
            this.export_btn.BackColor = System.Drawing.SystemColors.Control;
            this.export_btn.ControlId = "mcfb008";
            this.export_btn.Name = "export_btn";
            this.export_btn.UseVisualStyleBackColor = false;
            this.export_btn.Click += new System.EventHandler(this.export_btn_Click);
            // 
            // update_btn
            // 
            resources.ApplyResources(this.update_btn, "update_btn");
            this.update_btn.BackColor = System.Drawing.SystemColors.Control;
            this.update_btn.ControlId = "mcfb008";
            this.update_btn.Name = "update_btn";
            this.update_btn.UseVisualStyleBackColor = false;
            this.update_btn.Click += new System.EventHandler(this.update_btn_Click);
            // 
            // add_btn
            // 
            resources.ApplyResources(this.add_btn, "add_btn");
            this.add_btn.BackColor = System.Drawing.SystemColors.Control;
            this.add_btn.ControlId = "mcfb007";
            this.add_btn.Name = "add_btn";
            this.add_btn.UseVisualStyleBackColor = false;
            this.add_btn.Click += new System.EventHandler(this.add_btn_Click);
            // 
            // splitContainer1
            // 
            resources.ApplyResources(this.splitContainer1, "splitContainer1");
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.Search_tbpnl);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.export_btn);
            this.splitContainer1.Panel2.Controls.Add(this.reportdowntime_dgv);
            this.splitContainer1.Panel2.Controls.Add(this.add_btn);
            this.splitContainer1.Panel2.Controls.Add(this.search_btn);
            this.splitContainer1.Panel2.Controls.Add(this.update_btn);
            this.splitContainer1.Panel2.Controls.Add(this.Delete_btn);
            this.splitContainer1.Panel2.Controls.Add(this.clear_btn);
            // 
            // Search_tbpnl
            // 
            resources.ApplyResources(this.Search_tbpnl, "Search_tbpnl");
            this.Search_tbpnl.Controls.Add(this.model_lbl, 0, 0);
            this.Search_tbpnl.Controls.Add(this.cause_lbl, 4, 0);
            this.Search_tbpnl.Controls.Add(this.action_cmb, 5, 1);
            this.Search_tbpnl.Controls.Add(this.cause_cmb, 5, 0);
            this.Search_tbpnl.Controls.Add(this.action_lbl, 4, 1);
            this.Search_tbpnl.Controls.Add(this.line_lbl, 0, 1);
            this.Search_tbpnl.Controls.Add(this.timefrom_lbl, 0, 2);
            this.Search_tbpnl.Controls.Add(this.model_cmb, 1, 0);
            this.Search_tbpnl.Controls.Add(this.line_cmb, 1, 1);
            this.Search_tbpnl.Controls.Add(this.timeto_lbl, 0, 3);
            this.Search_tbpnl.Controls.Add(this.timeto_dtp, 1, 3);
            this.Search_tbpnl.Controls.Add(this.timefrom_dtp, 1, 2);
            this.Search_tbpnl.Controls.Add(this.process_lbl, 2, 0);
            this.Search_tbpnl.Controls.Add(this.machine_lbl, 2, 1);
            this.Search_tbpnl.Controls.Add(this.assy_cmb, 3, 0);
            this.Search_tbpnl.Controls.Add(this.machine_cmb, 3, 1);
            this.Search_tbpnl.Name = "Search_tbpnl";
            // 
            // timeto_dtp
            // 
            resources.ApplyResources(this.timeto_dtp, "timeto_dtp");
            this.timeto_dtp.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.timeto_dtp.Name = "timeto_dtp";
            // 
            // timefrom_dtp
            // 
            resources.ApplyResources(this.timefrom_dtp, "timefrom_dtp");
            this.timefrom_dtp.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.timefrom_dtp.Name = "timefrom_dtp";
            // 
            // Delete_btn
            // 
            resources.ApplyResources(this.Delete_btn, "Delete_btn");
            this.Delete_btn.BackColor = System.Drawing.SystemColors.Control;
            this.Delete_btn.ControlId = null;
            this.Delete_btn.Name = "Delete_btn";
            this.Delete_btn.UseVisualStyleBackColor = false;
            this.Delete_btn.Click += new System.EventHandler(this.Delete_btn_Click);
            // 
            // ReportDownTimeForm
            // 
            resources.ApplyResources(this, "$this");
            this.ControlId = "";
            this.Controls.Add(this.splitContainer1);
            this.Name = "ReportDownTimeForm";
            this.TitleText = "FormCommon";
            this.Load += new System.EventHandler(this.ReportDownTimeForm_Load);
            this.Controls.SetChildIndex(this.splitContainer1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.reportdowntime_dgv)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.Search_tbpnl.ResumeLayout(false);
            this.Search_tbpnl.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Framework.LabelCommon model_lbl;
        private Framework.LabelCommon process_lbl;
        private Framework.ComboBoxCommon model_cmb;
        private Framework.ComboBoxCommon assy_cmb;
        private Framework.LabelCommon line_lbl;
        private Framework.ComboBoxCommon line_cmb;
        private Framework.LabelCommon machine_lbl;
        private Framework.LabelCommon cause_lbl;
    
        private Framework.ComboBoxCommon machine_cmb;
        private Framework.ComboBoxCommon action_cmb;
        private Framework.ComboBoxCommon cause_cmb;
        private Framework.LabelCommon action_lbl;
        private Framework.LabelCommon timeto_lbl;
        private Framework.LabelCommon timefrom_lbl;
        private Framework.DataGridViewCommon reportdowntime_dgv;
        private Framework.ButtonCommon search_btn;
        private Framework.ButtonCommon clear_btn;
        private Framework.ButtonCommon add_btn;
        private Framework.ButtonCommon update_btn;
        private Framework.ButtonCommon export_btn;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TableLayoutPanel Search_tbpnl;
        private Framework.ButtonCommon Delete_btn;
        private System.Windows.Forms.DateTimePicker timeto_dtp;
        private System.Windows.Forms.DateTimePicker timefrom_dtp;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_downtime_report_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_model_cd;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_line_cd;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_assy;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_process_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_machine_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_time_from;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_time_to;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_cause;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_action;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_username;
    }
}
