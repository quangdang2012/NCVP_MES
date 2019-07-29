namespace Com.Nidec.Mes.Common.Basic.MachineMaintenance.Form
{
    partial class JigRepairInformationForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(JigRepairInformationForm));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.model_cmb = new Com.Nidec.Mes.Framework.ComboBoxCommon();
            this.model_lbl = new Com.Nidec.Mes.Framework.LabelCommon();
            this.process_cmb = new Com.Nidec.Mes.Framework.ComboBoxCommon();
            this.process_lbl = new Com.Nidec.Mes.Framework.LabelCommon();
            this.jigresponse_lbl = new Com.Nidec.Mes.Framework.LabelCommon();
            this.jigause_cmb = new Com.Nidec.Mes.Framework.ComboBoxCommon();
            this.jigresponse_cmb = new Com.Nidec.Mes.Framework.ComboBoxCommon();
            this.jigause_lbl = new Com.Nidec.Mes.Framework.LabelCommon();
            this.line_lbl = new Com.Nidec.Mes.Framework.LabelCommon();
            this.line_cmb = new Com.Nidec.Mes.Framework.ComboBoxCommon();
            this.timefrom_lbl = new Com.Nidec.Mes.Framework.LabelCommon();
            this.timefrom_dtp = new Com.Nidec.Mes.Framework.DateTimePickerCommon();
            this.timeto_dtp = new Com.Nidec.Mes.Framework.DateTimePickerCommon();
            this.timeto_lbl = new Com.Nidec.Mes.Framework.LabelCommon();
            this.jig_repair_information_dgv = new Com.Nidec.Mes.Framework.DataGridViewCommon();
            this.col_jig_repair_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_jig_code = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_model_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_line_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_process_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_jig_cause_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_response = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_time_from = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_time_to = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_before_status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_after_repair = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_repair_resuft = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_place = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.setting_gbc = new Com.Nidec.Mes.Framework.GroupBoxCommon();
            this.update_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.add_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.clear_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.search_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.jig_code_txt = new Com.Nidec.Mes.Framework.TextBoxCommon();
            this.jig_code_lbl = new Com.Nidec.Mes.Framework.LabelCommon();
            this.labelCommon1 = new Com.Nidec.Mes.Framework.LabelCommon();
            this.labelCommon2 = new Com.Nidec.Mes.Framework.LabelCommon();
            this.comboBoxCommon1 = new Com.Nidec.Mes.Framework.ComboBoxCommon();
            this.comboBoxCommon2 = new Com.Nidec.Mes.Framework.ComboBoxCommon();
            this.labelCommon3 = new Com.Nidec.Mes.Framework.LabelCommon();
            this.comboBoxCommon3 = new Com.Nidec.Mes.Framework.ComboBoxCommon();
            this.labelCommon4 = new Com.Nidec.Mes.Framework.LabelCommon();
            this.comboBoxCommon4 = new Com.Nidec.Mes.Framework.ComboBoxCommon();
            this.comboBoxCommon5 = new Com.Nidec.Mes.Framework.ComboBoxCommon();
            this.labelCommon5 = new Com.Nidec.Mes.Framework.LabelCommon();
            this.labelCommon6 = new Com.Nidec.Mes.Framework.LabelCommon();
            this.dateTimePickerCommon1 = new Com.Nidec.Mes.Framework.DateTimePickerCommon();
            this.dateTimePickerCommon2 = new Com.Nidec.Mes.Framework.DateTimePickerCommon();
            this.labelCommon7 = new Com.Nidec.Mes.Framework.LabelCommon();
            this.groupBoxCommon1 = new Com.Nidec.Mes.Framework.GroupBoxCommon();
            this.buttonCommon1 = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.buttonCommon2 = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.buttonCommon3 = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.buttonCommon4 = new Com.Nidec.Mes.Framework.ButtonCommon();
            ((System.ComponentModel.ISupportInitialize)(this.jig_repair_information_dgv)).BeginInit();
            this.setting_gbc.SuspendLayout();
            this.groupBoxCommon1.SuspendLayout();
            this.SuspendLayout();
            // 
            // model_cmb
            // 
            this.model_cmb.ControlId = null;
            resources.ApplyResources(this.model_cmb, "model_cmb");
            this.model_cmb.FormattingEnabled = true;
            this.model_cmb.Name = "model_cmb";
            this.model_cmb.SelectedIndexChanged += new System.EventHandler(this.model_cmb_SelectedIndexChanged);
            // 
            // model_lbl
            // 
            resources.ApplyResources(this.model_lbl, "model_lbl");
            this.model_lbl.ControlId = null;
            this.model_lbl.Name = "model_lbl";
            // 
            // process_cmb
            // 
            this.process_cmb.ControlId = null;
            resources.ApplyResources(this.process_cmb, "process_cmb");
            this.process_cmb.FormattingEnabled = true;
            this.process_cmb.Name = "process_cmb";
            // 
            // process_lbl
            // 
            resources.ApplyResources(this.process_lbl, "process_lbl");
            this.process_lbl.ControlId = null;
            this.process_lbl.Name = "process_lbl";
            // 
            // jigresponse_lbl
            // 
            resources.ApplyResources(this.jigresponse_lbl, "jigresponse_lbl");
            this.jigresponse_lbl.ControlId = null;
            this.jigresponse_lbl.Name = "jigresponse_lbl";
            // 
            // jigause_cmb
            // 
            this.jigause_cmb.ControlId = null;
            resources.ApplyResources(this.jigause_cmb, "jigause_cmb");
            this.jigause_cmb.FormattingEnabled = true;
            this.jigause_cmb.Name = "jigause_cmb";
            // 
            // jigresponse_cmb
            // 
            this.jigresponse_cmb.ControlId = null;
            resources.ApplyResources(this.jigresponse_cmb, "jigresponse_cmb");
            this.jigresponse_cmb.FormattingEnabled = true;
            this.jigresponse_cmb.Name = "jigresponse_cmb";
            // 
            // jigause_lbl
            // 
            resources.ApplyResources(this.jigause_lbl, "jigause_lbl");
            this.jigause_lbl.ControlId = null;
            this.jigause_lbl.Name = "jigause_lbl";
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
            // timefrom_lbl
            // 
            resources.ApplyResources(this.timefrom_lbl, "timefrom_lbl");
            this.timefrom_lbl.ControlId = null;
            this.timefrom_lbl.Name = "timefrom_lbl";
            // 
            // timefrom_dtp
            // 
            this.timefrom_dtp.BackColor = System.Drawing.SystemColors.Control;
            this.timefrom_dtp.ControlId = null;
            resources.ApplyResources(this.timefrom_dtp, "timefrom_dtp");
            this.timefrom_dtp.DisplayFormat = Com.Nidec.Mes.Framework.DateTimePickerCommon.DisplayFormatList.ShortDatePattern;
            this.timefrom_dtp.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.timefrom_dtp.Name = "timefrom_dtp";
            // 
            // timeto_dtp
            // 
            this.timeto_dtp.BackColor = System.Drawing.SystemColors.Control;
            this.timeto_dtp.ControlId = null;
            resources.ApplyResources(this.timeto_dtp, "timeto_dtp");
            this.timeto_dtp.DisplayFormat = Com.Nidec.Mes.Framework.DateTimePickerCommon.DisplayFormatList.ShortDatePattern;
            this.timeto_dtp.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.timeto_dtp.Name = "timeto_dtp";
            // 
            // timeto_lbl
            // 
            resources.ApplyResources(this.timeto_lbl, "timeto_lbl");
            this.timeto_lbl.ControlId = null;
            this.timeto_lbl.Name = "timeto_lbl";
            // 
            // jig_repair_information_dgv
            // 
            resources.ApplyResources(this.jig_repair_information_dgv, "jig_repair_information_dgv");
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(232)))), ((int)(((byte)(180)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.jig_repair_information_dgv.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.jig_repair_information_dgv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.col_jig_repair_id,
            this.col_jig_code,
            this.col_model_name,
            this.col_line_name,
            this.col_process_name,
            this.col_jig_cause_name,
            this.col_response,
            this.col_time_from,
            this.col_time_to,
            this.col_before_status,
            this.col_after_repair,
            this.col_repair_resuft,
            this.col_place});
            this.jig_repair_information_dgv.ControlId = null;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.jig_repair_information_dgv.DefaultCellStyle = dataGridViewCellStyle2;
            this.jig_repair_information_dgv.Name = "jig_repair_information_dgv";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(232)))), ((int)(((byte)(180)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.jig_repair_information_dgv.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            // 
            // col_jig_repair_id
            // 
            this.col_jig_repair_id.DataPropertyName = "JigRepairId";
            resources.ApplyResources(this.col_jig_repair_id, "col_jig_repair_id");
            this.col_jig_repair_id.Name = "col_jig_repair_id";
            this.col_jig_repair_id.ReadOnly = true;
            // 
            // col_jig_code
            // 
            this.col_jig_code.DataPropertyName = "JigRepairCode";
            resources.ApplyResources(this.col_jig_code, "col_jig_code");
            this.col_jig_code.Name = "col_jig_code";
            this.col_jig_code.ReadOnly = true;
            // 
            // col_model_name
            // 
            this.col_model_name.DataPropertyName = "ModelCode";
            resources.ApplyResources(this.col_model_name, "col_model_name");
            this.col_model_name.Name = "col_model_name";
            this.col_model_name.ReadOnly = true;
            // 
            // col_line_name
            // 
            this.col_line_name.DataPropertyName = "LineCode";
            resources.ApplyResources(this.col_line_name, "col_line_name");
            this.col_line_name.Name = "col_line_name";
            this.col_line_name.ReadOnly = true;
            // 
            // col_process_name
            // 
            this.col_process_name.DataPropertyName = "ProcessName";
            resources.ApplyResources(this.col_process_name, "col_process_name");
            this.col_process_name.Name = "col_process_name";
            this.col_process_name.ReadOnly = true;
            // 
            // col_jig_cause_name
            // 
            this.col_jig_cause_name.DataPropertyName = "JigCauseName";
            resources.ApplyResources(this.col_jig_cause_name, "col_jig_cause_name");
            this.col_jig_cause_name.Name = "col_jig_cause_name";
            this.col_jig_cause_name.ReadOnly = true;
            // 
            // col_response
            // 
            this.col_response.DataPropertyName = "JigResponseName";
            resources.ApplyResources(this.col_response, "col_response");
            this.col_response.Name = "col_response";
            this.col_response.ReadOnly = true;
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
            // col_before_status
            // 
            this.col_before_status.DataPropertyName = "JigCurrentStatus";
            resources.ApplyResources(this.col_before_status, "col_before_status");
            this.col_before_status.Name = "col_before_status";
            this.col_before_status.ReadOnly = true;
            // 
            // col_after_repair
            // 
            this.col_after_repair.DataPropertyName = "JigAfterRepairStatus";
            resources.ApplyResources(this.col_after_repair, "col_after_repair");
            this.col_after_repair.Name = "col_after_repair";
            this.col_after_repair.ReadOnly = true;
            // 
            // col_repair_resuft
            // 
            this.col_repair_resuft.DataPropertyName = "JigRepairResult";
            resources.ApplyResources(this.col_repair_resuft, "col_repair_resuft");
            this.col_repair_resuft.Name = "col_repair_resuft";
            this.col_repair_resuft.ReadOnly = true;
            // 
            // col_place
            // 
            this.col_place.DataPropertyName = "JigPlace";
            resources.ApplyResources(this.col_place, "col_place");
            this.col_place.Name = "col_place";
            this.col_place.ReadOnly = true;
            // 
            // setting_gbc
            // 
            this.setting_gbc.ControlId = null;
            this.setting_gbc.Controls.Add(this.update_btn);
            this.setting_gbc.Controls.Add(this.add_btn);
            this.setting_gbc.Controls.Add(this.clear_btn);
            this.setting_gbc.Controls.Add(this.search_btn);
            resources.ApplyResources(this.setting_gbc, "setting_gbc");
            this.setting_gbc.Name = "setting_gbc";
            this.setting_gbc.TabStop = false;
            // 
            // update_btn
            // 
            this.update_btn.BackColor = System.Drawing.SystemColors.Control;
            this.update_btn.ControlId = "mcfb006";
            resources.ApplyResources(this.update_btn, "update_btn");
            this.update_btn.Name = "update_btn";
            this.update_btn.UseVisualStyleBackColor = false;
            this.update_btn.Click += new System.EventHandler(this.update_btn_Click);
            // 
            // add_btn
            // 
            this.add_btn.BackColor = System.Drawing.SystemColors.Control;
            this.add_btn.ControlId = "mcfb005";
            resources.ApplyResources(this.add_btn, "add_btn");
            this.add_btn.Name = "add_btn";
            this.add_btn.UseVisualStyleBackColor = false;
            this.add_btn.Click += new System.EventHandler(this.add_btn_Click);
            // 
            // clear_btn
            // 
            this.clear_btn.BackColor = System.Drawing.SystemColors.Control;
            this.clear_btn.ControlId = null;
            resources.ApplyResources(this.clear_btn, "clear_btn");
            this.clear_btn.Name = "clear_btn";
            this.clear_btn.UseVisualStyleBackColor = false;
            this.clear_btn.Click += new System.EventHandler(this.clear_btn_Click);
            // 
            // search_btn
            // 
            this.search_btn.BackColor = System.Drawing.SystemColors.Control;
            this.search_btn.ControlId = null;
            resources.ApplyResources(this.search_btn, "search_btn");
            this.search_btn.Name = "search_btn";
            this.search_btn.UseVisualStyleBackColor = false;
            this.search_btn.Click += new System.EventHandler(this.search_btn_Click);
            // 
            // jig_code_txt
            // 
            this.jig_code_txt.ControlId = null;
            resources.ApplyResources(this.jig_code_txt, "jig_code_txt");
            this.jig_code_txt.InputType = Com.Nidec.Mes.Framework.TextBoxCommon.InputTypeList.All;
            this.jig_code_txt.Name = "jig_code_txt";
            // 
            // jig_code_lbl
            // 
            resources.ApplyResources(this.jig_code_lbl, "jig_code_lbl");
            this.jig_code_lbl.ControlId = null;
            this.jig_code_lbl.Name = "jig_code_lbl";
            // 
            // labelCommon1
            // 
            resources.ApplyResources(this.labelCommon1, "labelCommon1");
            this.labelCommon1.ControlId = null;
            this.labelCommon1.Name = "labelCommon1";
            // 
            // labelCommon2
            // 
            resources.ApplyResources(this.labelCommon2, "labelCommon2");
            this.labelCommon2.ControlId = null;
            this.labelCommon2.Name = "labelCommon2";
            // 
            // comboBoxCommon1
            // 
            this.comboBoxCommon1.ControlId = null;
            resources.ApplyResources(this.comboBoxCommon1, "comboBoxCommon1");
            this.comboBoxCommon1.FormattingEnabled = true;
            this.comboBoxCommon1.Name = "comboBoxCommon1";
            this.comboBoxCommon1.SelectedIndexChanged += new System.EventHandler(this.model_cmb_SelectedIndexChanged);
            // 
            // comboBoxCommon2
            // 
            this.comboBoxCommon2.ControlId = null;
            resources.ApplyResources(this.comboBoxCommon2, "comboBoxCommon2");
            this.comboBoxCommon2.FormattingEnabled = true;
            this.comboBoxCommon2.Name = "comboBoxCommon2";
            // 
            // labelCommon3
            // 
            resources.ApplyResources(this.labelCommon3, "labelCommon3");
            this.labelCommon3.ControlId = null;
            this.labelCommon3.Name = "labelCommon3";
            // 
            // comboBoxCommon3
            // 
            this.comboBoxCommon3.ControlId = null;
            resources.ApplyResources(this.comboBoxCommon3, "comboBoxCommon3");
            this.comboBoxCommon3.FormattingEnabled = true;
            this.comboBoxCommon3.Name = "comboBoxCommon3";
            // 
            // labelCommon4
            // 
            resources.ApplyResources(this.labelCommon4, "labelCommon4");
            this.labelCommon4.ControlId = null;
            this.labelCommon4.Name = "labelCommon4";
            // 
            // comboBoxCommon4
            // 
            this.comboBoxCommon4.ControlId = null;
            resources.ApplyResources(this.comboBoxCommon4, "comboBoxCommon4");
            this.comboBoxCommon4.FormattingEnabled = true;
            this.comboBoxCommon4.Name = "comboBoxCommon4";
            // 
            // comboBoxCommon5
            // 
            this.comboBoxCommon5.ControlId = null;
            resources.ApplyResources(this.comboBoxCommon5, "comboBoxCommon5");
            this.comboBoxCommon5.FormattingEnabled = true;
            this.comboBoxCommon5.Name = "comboBoxCommon5";
            // 
            // labelCommon5
            // 
            resources.ApplyResources(this.labelCommon5, "labelCommon5");
            this.labelCommon5.ControlId = null;
            this.labelCommon5.Name = "labelCommon5";
            // 
            // labelCommon6
            // 
            resources.ApplyResources(this.labelCommon6, "labelCommon6");
            this.labelCommon6.ControlId = null;
            this.labelCommon6.Name = "labelCommon6";
            // 
            // dateTimePickerCommon1
            // 
            this.dateTimePickerCommon1.BackColor = System.Drawing.SystemColors.Control;
            this.dateTimePickerCommon1.ControlId = null;
            resources.ApplyResources(this.dateTimePickerCommon1, "dateTimePickerCommon1");
            this.dateTimePickerCommon1.DisplayFormat = Com.Nidec.Mes.Framework.DateTimePickerCommon.DisplayFormatList.ShortDatePattern;
            this.dateTimePickerCommon1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePickerCommon1.Name = "dateTimePickerCommon1";
            // 
            // dateTimePickerCommon2
            // 
            this.dateTimePickerCommon2.BackColor = System.Drawing.SystemColors.Control;
            this.dateTimePickerCommon2.ControlId = null;
            resources.ApplyResources(this.dateTimePickerCommon2, "dateTimePickerCommon2");
            this.dateTimePickerCommon2.DisplayFormat = Com.Nidec.Mes.Framework.DateTimePickerCommon.DisplayFormatList.ShortDatePattern;
            this.dateTimePickerCommon2.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePickerCommon2.Name = "dateTimePickerCommon2";
            // 
            // labelCommon7
            // 
            resources.ApplyResources(this.labelCommon7, "labelCommon7");
            this.labelCommon7.ControlId = null;
            this.labelCommon7.Name = "labelCommon7";
            // 
            // groupBoxCommon1
            // 
            this.groupBoxCommon1.ControlId = null;
            this.groupBoxCommon1.Controls.Add(this.buttonCommon1);
            this.groupBoxCommon1.Controls.Add(this.buttonCommon2);
            this.groupBoxCommon1.Controls.Add(this.buttonCommon3);
            this.groupBoxCommon1.Controls.Add(this.buttonCommon4);
            resources.ApplyResources(this.groupBoxCommon1, "groupBoxCommon1");
            this.groupBoxCommon1.Name = "groupBoxCommon1";
            this.groupBoxCommon1.TabStop = false;
            // 
            // buttonCommon1
            // 
            this.buttonCommon1.BackColor = System.Drawing.SystemColors.Control;
            this.buttonCommon1.ControlId = "mcfb006";
            resources.ApplyResources(this.buttonCommon1, "buttonCommon1");
            this.buttonCommon1.Name = "buttonCommon1";
            this.buttonCommon1.UseVisualStyleBackColor = false;
            this.buttonCommon1.Click += new System.EventHandler(this.update_btn_Click);
            // 
            // buttonCommon2
            // 
            this.buttonCommon2.BackColor = System.Drawing.SystemColors.Control;
            this.buttonCommon2.ControlId = "mcfb005";
            resources.ApplyResources(this.buttonCommon2, "buttonCommon2");
            this.buttonCommon2.Name = "buttonCommon2";
            this.buttonCommon2.UseVisualStyleBackColor = false;
            this.buttonCommon2.Click += new System.EventHandler(this.add_btn_Click);
            // 
            // buttonCommon3
            // 
            this.buttonCommon3.BackColor = System.Drawing.SystemColors.Control;
            this.buttonCommon3.ControlId = null;
            resources.ApplyResources(this.buttonCommon3, "buttonCommon3");
            this.buttonCommon3.Name = "buttonCommon3";
            this.buttonCommon3.UseVisualStyleBackColor = false;
            this.buttonCommon3.Click += new System.EventHandler(this.clear_btn_Click);
            // 
            // buttonCommon4
            // 
            this.buttonCommon4.BackColor = System.Drawing.SystemColors.Control;
            this.buttonCommon4.ControlId = null;
            resources.ApplyResources(this.buttonCommon4, "buttonCommon4");
            this.buttonCommon4.Name = "buttonCommon4";
            this.buttonCommon4.UseVisualStyleBackColor = false;
            this.buttonCommon4.Click += new System.EventHandler(this.search_btn_Click);
            // 
            // JigRepairInformationForm
            // 
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.jig_code_txt);
            this.Controls.Add(this.jig_code_lbl);
            this.Controls.Add(this.groupBoxCommon1);
            this.Controls.Add(this.setting_gbc);
            this.Controls.Add(this.labelCommon7);
            this.Controls.Add(this.jig_repair_information_dgv);
            this.Controls.Add(this.dateTimePickerCommon2);
            this.Controls.Add(this.timefrom_lbl);
            this.Controls.Add(this.dateTimePickerCommon1);
            this.Controls.Add(this.timefrom_dtp);
            this.Controls.Add(this.labelCommon6);
            this.Controls.Add(this.timeto_dtp);
            this.Controls.Add(this.labelCommon5);
            this.Controls.Add(this.timeto_lbl);
            this.Controls.Add(this.comboBoxCommon5);
            this.Controls.Add(this.jigresponse_lbl);
            this.Controls.Add(this.comboBoxCommon4);
            this.Controls.Add(this.jigause_cmb);
            this.Controls.Add(this.labelCommon4);
            this.Controls.Add(this.jigresponse_cmb);
            this.Controls.Add(this.comboBoxCommon3);
            this.Controls.Add(this.jigause_lbl);
            this.Controls.Add(this.labelCommon3);
            this.Controls.Add(this.process_cmb);
            this.Controls.Add(this.comboBoxCommon2);
            this.Controls.Add(this.process_lbl);
            this.Controls.Add(this.comboBoxCommon1);
            this.Controls.Add(this.line_cmb);
            this.Controls.Add(this.labelCommon2);
            this.Controls.Add(this.model_cmb);
            this.Controls.Add(this.labelCommon1);
            this.Controls.Add(this.line_lbl);
            this.Controls.Add(this.model_lbl);
            this.Name = "JigRepairInformationForm";
            this.TitleText = "FormCommon";
            this.Load += new System.EventHandler(this.JigRepairInformationForm_Load);
            this.Controls.SetChildIndex(this.model_lbl, 0);
            this.Controls.SetChildIndex(this.line_lbl, 0);
            this.Controls.SetChildIndex(this.labelCommon1, 0);
            this.Controls.SetChildIndex(this.model_cmb, 0);
            this.Controls.SetChildIndex(this.labelCommon2, 0);
            this.Controls.SetChildIndex(this.line_cmb, 0);
            this.Controls.SetChildIndex(this.comboBoxCommon1, 0);
            this.Controls.SetChildIndex(this.process_lbl, 0);
            this.Controls.SetChildIndex(this.comboBoxCommon2, 0);
            this.Controls.SetChildIndex(this.process_cmb, 0);
            this.Controls.SetChildIndex(this.labelCommon3, 0);
            this.Controls.SetChildIndex(this.jigause_lbl, 0);
            this.Controls.SetChildIndex(this.comboBoxCommon3, 0);
            this.Controls.SetChildIndex(this.jigresponse_cmb, 0);
            this.Controls.SetChildIndex(this.labelCommon4, 0);
            this.Controls.SetChildIndex(this.jigause_cmb, 0);
            this.Controls.SetChildIndex(this.comboBoxCommon4, 0);
            this.Controls.SetChildIndex(this.jigresponse_lbl, 0);
            this.Controls.SetChildIndex(this.comboBoxCommon5, 0);
            this.Controls.SetChildIndex(this.timeto_lbl, 0);
            this.Controls.SetChildIndex(this.labelCommon5, 0);
            this.Controls.SetChildIndex(this.timeto_dtp, 0);
            this.Controls.SetChildIndex(this.labelCommon6, 0);
            this.Controls.SetChildIndex(this.timefrom_dtp, 0);
            this.Controls.SetChildIndex(this.dateTimePickerCommon1, 0);
            this.Controls.SetChildIndex(this.timefrom_lbl, 0);
            this.Controls.SetChildIndex(this.dateTimePickerCommon2, 0);
            this.Controls.SetChildIndex(this.jig_repair_information_dgv, 0);
            this.Controls.SetChildIndex(this.labelCommon7, 0);
            this.Controls.SetChildIndex(this.setting_gbc, 0);
            this.Controls.SetChildIndex(this.groupBoxCommon1, 0);
            this.Controls.SetChildIndex(this.jig_code_lbl, 0);
            this.Controls.SetChildIndex(this.jig_code_txt, 0);
            ((System.ComponentModel.ISupportInitialize)(this.jig_repair_information_dgv)).EndInit();
            this.setting_gbc.ResumeLayout(false);
            this.groupBoxCommon1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Framework.ComboBoxCommon model_cmb;
        private Framework.LabelCommon model_lbl;
        private Framework.ComboBoxCommon process_cmb;
        private Framework.LabelCommon process_lbl;
        private Framework.LabelCommon jigresponse_lbl;
        private Framework.ComboBoxCommon jigause_cmb;
        private Framework.ComboBoxCommon jigresponse_cmb;
        private Framework.LabelCommon jigause_lbl;
        private Framework.LabelCommon line_lbl;
        private Framework.ComboBoxCommon line_cmb;
        private Framework.LabelCommon timefrom_lbl;
        private Framework.DateTimePickerCommon timefrom_dtp;
        private Framework.DateTimePickerCommon timeto_dtp;
        private Framework.LabelCommon timeto_lbl;
        private Framework.DataGridViewCommon jig_repair_information_dgv;
        private Framework.GroupBoxCommon setting_gbc;
        private Framework.ButtonCommon update_btn;
        private Framework.ButtonCommon add_btn;
        private Framework.ButtonCommon clear_btn;
        private Framework.ButtonCommon search_btn;
        private Framework.TextBoxCommon jig_code_txt;
        private Framework.LabelCommon jig_code_lbl;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_jig_repair_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_jig_code;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_model_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_line_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_process_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_jig_cause_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_response;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_time_from;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_time_to;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_before_status;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_after_repair;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_repair_resuft;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_place;
        private Framework.LabelCommon labelCommon1;
        private Framework.LabelCommon labelCommon2;
        private Framework.ComboBoxCommon comboBoxCommon1;
        private Framework.ComboBoxCommon comboBoxCommon2;
        private Framework.LabelCommon labelCommon3;
        private Framework.ComboBoxCommon comboBoxCommon3;
        private Framework.LabelCommon labelCommon4;
        private Framework.ComboBoxCommon comboBoxCommon4;
        private Framework.ComboBoxCommon comboBoxCommon5;
        private Framework.LabelCommon labelCommon5;
        private Framework.LabelCommon labelCommon6;
        private Framework.DateTimePickerCommon dateTimePickerCommon1;
        private Framework.DateTimePickerCommon dateTimePickerCommon2;
        private Framework.LabelCommon labelCommon7;
        private Framework.GroupBoxCommon groupBoxCommon1;
        private Framework.ButtonCommon buttonCommon1;
        private Framework.ButtonCommon buttonCommon2;
        private Framework.ButtonCommon buttonCommon3;
        private Framework.ButtonCommon buttonCommon4;
    }
}
