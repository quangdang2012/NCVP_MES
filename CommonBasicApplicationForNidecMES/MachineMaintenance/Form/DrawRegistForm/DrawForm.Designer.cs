namespace Com.Nidec.Mes.Common.Basic.MachineMaintenance.Form
{
    partial class DrawForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DrawForm));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.model_cmb = new Com.Nidec.Mes.Framework.ComboBoxCommon();
            this.model_lbl = new Com.Nidec.Mes.Framework.LabelCommon();
            this.timefrom_lbl = new Com.Nidec.Mes.Framework.LabelCommon();
            this.draw_dgv = new Com.Nidec.Mes.Framework.DataGridViewCommon();
            this.col_device_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_device_code = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_model_code = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_machine = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_drawing = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colUserIncharge = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_time_record = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDeapartment = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_revision = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.update_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.add_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.clear_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.search_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.drawing_lbl = new Com.Nidec.Mes.Framework.LabelCommon();
            this.drawing_cmb = new Com.Nidec.Mes.Framework.ComboBoxCommon();
            this.timefrom_dtp = new Com.Nidec.Mes.Framework.DateTimePickerCommon();
            this.device_code_txt = new Com.Nidec.Mes.Framework.TextBoxCommon();
            this.device_code_lbl = new Com.Nidec.Mes.Framework.LabelCommon();
            this.version_lbl = new Com.Nidec.Mes.Framework.LabelCommon();
            this.version_cmb = new Com.Nidec.Mes.Framework.ComboBoxCommon();
            this.machine_lbl = new Com.Nidec.Mes.Framework.LabelCommon();
            this.Machine_cmb = new Com.Nidec.Mes.Framework.ComboBoxCommon();
            this.timeto_lbl = new Com.Nidec.Mes.Framework.LabelCommon();
            this.timeto_dtp = new Com.Nidec.Mes.Framework.DateTimePickerCommon();
            this.depart_lbl = new Com.Nidec.Mes.Framework.LabelCommon();
            this.depart_cmb = new Com.Nidec.Mes.Framework.ComboBoxCommon();
            this.user_lbl = new Com.Nidec.Mes.Framework.LabelCommon();
            this.user_cmb = new Com.Nidec.Mes.Framework.ComboBoxCommon();
            this.linksave_txt = new Com.Nidec.Mes.Framework.TextBoxCommon();
            this.exportexcel_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.browser_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.groupBoxCommon1 = new Com.Nidec.Mes.Framework.GroupBoxCommon();
            ((System.ComponentModel.ISupportInitialize)(this.draw_dgv)).BeginInit();
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
            // timefrom_lbl
            // 
            resources.ApplyResources(this.timefrom_lbl, "timefrom_lbl");
            this.timefrom_lbl.ControlId = null;
            this.timefrom_lbl.Name = "timefrom_lbl";
            // 
            // draw_dgv
            // 
            resources.ApplyResources(this.draw_dgv, "draw_dgv");
            this.draw_dgv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.draw_dgv.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(232)))), ((int)(((byte)(180)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.draw_dgv.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.draw_dgv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.col_device_id,
            this.col_device_code,
            this.col_model_code,
            this.col_machine,
            this.col_drawing,
            this.colUserIncharge,
            this.col_time_record,
            this.colDeapartment,
            this.col_revision});
            this.draw_dgv.ControlId = null;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.draw_dgv.DefaultCellStyle = dataGridViewCellStyle2;
            this.draw_dgv.Name = "draw_dgv";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(232)))), ((int)(((byte)(180)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.draw_dgv.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.draw_dgv.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.draw_dgv_CellContentClick);
            // 
            // col_device_id
            // 
            this.col_device_id.DataPropertyName = "DeviceId";
            resources.ApplyResources(this.col_device_id, "col_device_id");
            this.col_device_id.Name = "col_device_id";
            this.col_device_id.ReadOnly = true;
            // 
            // col_device_code
            // 
            this.col_device_code.DataPropertyName = "DeviceCode";
            resources.ApplyResources(this.col_device_code, "col_device_code");
            this.col_device_code.Name = "col_device_code";
            this.col_device_code.ReadOnly = true;
            // 
            // col_model_code
            // 
            this.col_model_code.DataPropertyName = "ModelCode";
            resources.ApplyResources(this.col_model_code, "col_model_code");
            this.col_model_code.Name = "col_model_code";
            this.col_model_code.ReadOnly = true;
            // 
            // col_machine
            // 
            this.col_machine.DataPropertyName = "MachineName";
            resources.ApplyResources(this.col_machine, "col_machine");
            this.col_machine.Name = "col_machine";
            this.col_machine.ReadOnly = true;
            // 
            // col_drawing
            // 
            this.col_drawing.DataPropertyName = "DrawCode";
            resources.ApplyResources(this.col_drawing, "col_drawing");
            this.col_drawing.Name = "col_drawing";
            this.col_drawing.ReadOnly = true;
            // 
            // colUserIncharge
            // 
            this.colUserIncharge.DataPropertyName = "RegistrationUserCode";
            resources.ApplyResources(this.colUserIncharge, "colUserIncharge");
            this.colUserIncharge.Name = "colUserIncharge";
            this.colUserIncharge.ReadOnly = true;
            // 
            // col_time_record
            // 
            this.col_time_record.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.col_time_record.DataPropertyName = "TimeFrom";
            resources.ApplyResources(this.col_time_record, "col_time_record");
            this.col_time_record.Name = "col_time_record";
            this.col_time_record.ReadOnly = true;
            // 
            // colDeapartment
            // 
            this.colDeapartment.DataPropertyName = "Department";
            resources.ApplyResources(this.colDeapartment, "colDeapartment");
            this.colDeapartment.Name = "colDeapartment";
            this.colDeapartment.ReadOnly = true;
            // 
            // col_revision
            // 
            this.col_revision.DataPropertyName = "Revision";
            resources.ApplyResources(this.col_revision, "col_revision");
            this.col_revision.Name = "col_revision";
            this.col_revision.ReadOnly = true;
            // 
            // update_btn
            // 
            resources.ApplyResources(this.update_btn, "update_btn");
            this.update_btn.BackColor = System.Drawing.SystemColors.Control;
            this.update_btn.ControlId = "mcfb004";
            this.update_btn.Name = "update_btn";
            this.update_btn.UseVisualStyleBackColor = false;
            this.update_btn.Click += new System.EventHandler(this.update_btn_Click);
            // 
            // add_btn
            // 
            resources.ApplyResources(this.add_btn, "add_btn");
            this.add_btn.BackColor = System.Drawing.SystemColors.Control;
            this.add_btn.ControlId = "mcfb003";
            this.add_btn.Name = "add_btn";
            this.add_btn.UseVisualStyleBackColor = false;
            this.add_btn.Click += new System.EventHandler(this.add_btn_Click);
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
            // search_btn
            // 
            resources.ApplyResources(this.search_btn, "search_btn");
            this.search_btn.BackColor = System.Drawing.SystemColors.Control;
            this.search_btn.ControlId = null;
            this.search_btn.Name = "search_btn";
            this.search_btn.UseVisualStyleBackColor = false;
            this.search_btn.Click += new System.EventHandler(this.search_btn_Click);
            // 
            // drawing_lbl
            // 
            resources.ApplyResources(this.drawing_lbl, "drawing_lbl");
            this.drawing_lbl.ControlId = null;
            this.drawing_lbl.Name = "drawing_lbl";
            // 
            // drawing_cmb
            // 
            this.drawing_cmb.ControlId = null;
            resources.ApplyResources(this.drawing_cmb, "drawing_cmb");
            this.drawing_cmb.FormattingEnabled = true;
            this.drawing_cmb.Name = "drawing_cmb";
            this.drawing_cmb.SelectedIndexChanged += new System.EventHandler(this.drawing_cmb_SelectedIndexChanged);
            // 
            // timefrom_dtp
            // 
            this.timefrom_dtp.BackColor = System.Drawing.SystemColors.Control;
            this.timefrom_dtp.Checked = false;
            this.timefrom_dtp.ControlId = null;
            resources.ApplyResources(this.timefrom_dtp, "timefrom_dtp");
            this.timefrom_dtp.DisplayFormat = Com.Nidec.Mes.Framework.DateTimePickerCommon.DisplayFormatList.ShortDatePattern;
            this.timefrom_dtp.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.timefrom_dtp.Name = "timefrom_dtp";
            // 
            // device_code_txt
            // 
            this.device_code_txt.ControlId = null;
            resources.ApplyResources(this.device_code_txt, "device_code_txt");
            this.device_code_txt.InputType = Com.Nidec.Mes.Framework.TextBoxCommon.InputTypeList.All;
            this.device_code_txt.Name = "device_code_txt";
            // 
            // device_code_lbl
            // 
            resources.ApplyResources(this.device_code_lbl, "device_code_lbl");
            this.device_code_lbl.ControlId = null;
            this.device_code_lbl.Name = "device_code_lbl";
            // 
            // version_lbl
            // 
            resources.ApplyResources(this.version_lbl, "version_lbl");
            this.version_lbl.ControlId = null;
            this.version_lbl.Name = "version_lbl";
            // 
            // version_cmb
            // 
            this.version_cmb.ControlId = null;
            resources.ApplyResources(this.version_cmb, "version_cmb");
            this.version_cmb.FormattingEnabled = true;
            this.version_cmb.Name = "version_cmb";
            // 
            // machine_lbl
            // 
            resources.ApplyResources(this.machine_lbl, "machine_lbl");
            this.machine_lbl.ControlId = null;
            this.machine_lbl.Name = "machine_lbl";
            // 
            // Machine_cmb
            // 
            this.Machine_cmb.ControlId = null;
            resources.ApplyResources(this.Machine_cmb, "Machine_cmb");
            this.Machine_cmb.FormattingEnabled = true;
            this.Machine_cmb.Name = "Machine_cmb";
            // 
            // timeto_lbl
            // 
            resources.ApplyResources(this.timeto_lbl, "timeto_lbl");
            this.timeto_lbl.ControlId = null;
            this.timeto_lbl.Name = "timeto_lbl";
            // 
            // timeto_dtp
            // 
            this.timeto_dtp.BackColor = System.Drawing.SystemColors.Control;
            this.timeto_dtp.Checked = false;
            this.timeto_dtp.ControlId = null;
            resources.ApplyResources(this.timeto_dtp, "timeto_dtp");
            this.timeto_dtp.DisplayFormat = Com.Nidec.Mes.Framework.DateTimePickerCommon.DisplayFormatList.ShortDatePattern;
            this.timeto_dtp.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.timeto_dtp.Name = "timeto_dtp";
            // 
            // depart_lbl
            // 
            resources.ApplyResources(this.depart_lbl, "depart_lbl");
            this.depart_lbl.ControlId = null;
            this.depart_lbl.Name = "depart_lbl";
            // 
            // depart_cmb
            // 
            this.depart_cmb.ControlId = null;
            resources.ApplyResources(this.depart_cmb, "depart_cmb");
            this.depart_cmb.FormattingEnabled = true;
            this.depart_cmb.Name = "depart_cmb";
            // 
            // user_lbl
            // 
            resources.ApplyResources(this.user_lbl, "user_lbl");
            this.user_lbl.ControlId = null;
            this.user_lbl.Name = "user_lbl";
            // 
            // user_cmb
            // 
            this.user_cmb.ControlId = null;
            resources.ApplyResources(this.user_cmb, "user_cmb");
            this.user_cmb.FormattingEnabled = true;
            this.user_cmb.Name = "user_cmb";
            // 
            // linksave_txt
            // 
            this.linksave_txt.ControlId = null;
            resources.ApplyResources(this.linksave_txt, "linksave_txt");
            this.linksave_txt.InputType = Com.Nidec.Mes.Framework.TextBoxCommon.InputTypeList.All;
            this.linksave_txt.Name = "linksave_txt";
            // 
            // exportexcel_btn
            // 
            this.exportexcel_btn.BackColor = System.Drawing.SystemColors.Control;
            this.exportexcel_btn.ControlId = null;
            resources.ApplyResources(this.exportexcel_btn, "exportexcel_btn");
            this.exportexcel_btn.Name = "exportexcel_btn";
            this.exportexcel_btn.UseVisualStyleBackColor = false;
            this.exportexcel_btn.Click += new System.EventHandler(this.exportexcel_btn_Click);
            // 
            // browser_btn
            // 
            this.browser_btn.BackColor = System.Drawing.SystemColors.Control;
            this.browser_btn.ControlId = null;
            resources.ApplyResources(this.browser_btn, "browser_btn");
            this.browser_btn.Name = "browser_btn";
            this.browser_btn.UseVisualStyleBackColor = false;
            this.browser_btn.Click += new System.EventHandler(this.browser_btn_Click);
            // 
            // groupBoxCommon1
            // 
            resources.ApplyResources(this.groupBoxCommon1, "groupBoxCommon1");
            this.groupBoxCommon1.ControlId = null;
            this.groupBoxCommon1.Controls.Add(this.browser_btn);
            this.groupBoxCommon1.Controls.Add(this.linksave_txt);
            this.groupBoxCommon1.Controls.Add(this.add_btn);
            this.groupBoxCommon1.Controls.Add(this.exportexcel_btn);
            this.groupBoxCommon1.Controls.Add(this.update_btn);
            this.groupBoxCommon1.Controls.Add(this.clear_btn);
            this.groupBoxCommon1.Controls.Add(this.search_btn);
            this.groupBoxCommon1.Name = "groupBoxCommon1";
            this.groupBoxCommon1.TabStop = false;
            // 
            // DrawForm
            // 
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.groupBoxCommon1);
            this.Controls.Add(this.device_code_txt);
            this.Controls.Add(this.device_code_lbl);
            this.Controls.Add(this.timeto_dtp);
            this.Controls.Add(this.timefrom_dtp);
            this.Controls.Add(this.timeto_lbl);
            this.Controls.Add(this.draw_dgv);
            this.Controls.Add(this.timefrom_lbl);
            this.Controls.Add(this.user_cmb);
            this.Controls.Add(this.user_lbl);
            this.Controls.Add(this.depart_cmb);
            this.Controls.Add(this.depart_lbl);
            this.Controls.Add(this.Machine_cmb);
            this.Controls.Add(this.machine_lbl);
            this.Controls.Add(this.version_cmb);
            this.Controls.Add(this.version_lbl);
            this.Controls.Add(this.drawing_cmb);
            this.Controls.Add(this.drawing_lbl);
            this.Controls.Add(this.model_cmb);
            this.Controls.Add(this.model_lbl);
            this.Name = "DrawForm";
            this.TitleText = "FormCommon";
            this.Load += new System.EventHandler(this.JigDrawForm_Load);
            this.Controls.SetChildIndex(this.model_lbl, 0);
            this.Controls.SetChildIndex(this.model_cmb, 0);
            this.Controls.SetChildIndex(this.drawing_lbl, 0);
            this.Controls.SetChildIndex(this.drawing_cmb, 0);
            this.Controls.SetChildIndex(this.version_lbl, 0);
            this.Controls.SetChildIndex(this.version_cmb, 0);
            this.Controls.SetChildIndex(this.machine_lbl, 0);
            this.Controls.SetChildIndex(this.Machine_cmb, 0);
            this.Controls.SetChildIndex(this.depart_lbl, 0);
            this.Controls.SetChildIndex(this.depart_cmb, 0);
            this.Controls.SetChildIndex(this.user_lbl, 0);
            this.Controls.SetChildIndex(this.user_cmb, 0);
            this.Controls.SetChildIndex(this.timefrom_lbl, 0);
            this.Controls.SetChildIndex(this.draw_dgv, 0);
            this.Controls.SetChildIndex(this.timeto_lbl, 0);
            this.Controls.SetChildIndex(this.timefrom_dtp, 0);
            this.Controls.SetChildIndex(this.timeto_dtp, 0);
            this.Controls.SetChildIndex(this.device_code_lbl, 0);
            this.Controls.SetChildIndex(this.device_code_txt, 0);
            this.Controls.SetChildIndex(this.groupBoxCommon1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.draw_dgv)).EndInit();
            this.groupBoxCommon1.ResumeLayout(false);
            this.groupBoxCommon1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Framework.ComboBoxCommon model_cmb;
        private Framework.LabelCommon model_lbl;
        private Framework.LabelCommon timefrom_lbl;
        private Framework.DataGridViewCommon draw_dgv;
        private Framework.ButtonCommon update_btn;
        private Framework.ButtonCommon add_btn;
        private Framework.ButtonCommon clear_btn;
        private Framework.ButtonCommon search_btn;
        private Framework.LabelCommon drawing_lbl;
        private Framework.ComboBoxCommon drawing_cmb;
        private Framework.DateTimePickerCommon timefrom_dtp;
        private Framework.TextBoxCommon device_code_txt;
        private Framework.LabelCommon device_code_lbl;
        private Framework.LabelCommon version_lbl;
        private Framework.ComboBoxCommon version_cmb;
        private Framework.LabelCommon machine_lbl;
        private Framework.ComboBoxCommon Machine_cmb;
        private Framework.LabelCommon timeto_lbl;
        private Framework.DateTimePickerCommon timeto_dtp;
        private Framework.LabelCommon depart_lbl;
        private Framework.ComboBoxCommon depart_cmb;
        private Framework.LabelCommon user_lbl;
        private Framework.ComboBoxCommon user_cmb;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_device_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_device_code;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_model_code;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_machine;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_drawing;
        private System.Windows.Forms.DataGridViewTextBoxColumn colUserIncharge;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_time_record;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDeapartment;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_revision;
        private Framework.TextBoxCommon linksave_txt;
        private Framework.ButtonCommon exportexcel_btn;
        private Framework.ButtonCommon browser_btn;
        private Framework.GroupBoxCommon groupBoxCommon1;
    }
}
