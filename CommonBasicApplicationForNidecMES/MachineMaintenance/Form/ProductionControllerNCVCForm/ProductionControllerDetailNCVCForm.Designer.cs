namespace Com.Nidec.Mes.Common.Basic.MachineMaintenance.Form
{
    partial class ProductionControllerDetailNCVCForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProductionControllerDetailForm));
            this.production_controller_detail_dgv = new Com.Nidec.Mes.Framework.DataGridViewCommon();
            this.colModel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLine = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.model_lbl = new Com.Nidec.Mes.Framework.LabelCommon();
            this.line_lbl = new Com.Nidec.Mes.Framework.LabelCommon();
            this.model_txt = new Com.Nidec.Mes.Framework.TextBoxCommon();
            this.line_txt = new Com.Nidec.Mes.Framework.TextBoxCommon();
            this.groupBoxCommon1 = new Com.Nidec.Mes.Framework.GroupBoxCommon();
            this.process_txt = new Com.Nidec.Mes.Framework.TextBoxCommon();
            this.labelCommon1 = new Com.Nidec.Mes.Framework.LabelCommon();
            this.groupBoxCommon2 = new Com.Nidec.Mes.Framework.GroupBoxCommon();
            this.chart_ng = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.linksave_txt = new Com.Nidec.Mes.Framework.TextBoxCommon();
            this.browser_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.exportexcel_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.search_grb = new Com.Nidec.Mes.Framework.GroupBoxCommon();
            this.timeto_dtp = new Com.Nidec.Mes.Framework.DateTimePickerCommon();
            this.timefrom_dtp = new Com.Nidec.Mes.Framework.DateTimePickerCommon();
            this.search_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.labelCommon3 = new Com.Nidec.Mes.Framework.LabelCommon();
            this.labelCommon4 = new Com.Nidec.Mes.Framework.LabelCommon();
            ((System.ComponentModel.ISupportInitialize)(this.production_controller_detail_dgv)).BeginInit();
            this.groupBoxCommon1.SuspendLayout();
            this.groupBoxCommon2.SuspendLayout();
            this.search_grb.SuspendLayout();
            this.SuspendLayout();
            // 
            // production_controller_detail_dgv
            // 
            this.production_controller_detail_dgv.AllowUserToAddRows = false;
            this.production_controller_detail_dgv.AllowUserToResizeRows = false;
            this.production_controller_detail_dgv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(232)))), ((int)(((byte)(180)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.production_controller_detail_dgv.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.production_controller_detail_dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.production_controller_detail_dgv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colModel,
            this.colLine,
            this.colTime});
            this.production_controller_detail_dgv.ControlId = null;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.production_controller_detail_dgv.DefaultCellStyle = dataGridViewCellStyle2;
            resources.ApplyResources(this.production_controller_detail_dgv, "production_controller_detail_dgv");
            this.production_controller_detail_dgv.Name = "production_controller_detail_dgv";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(232)))), ((int)(((byte)(180)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.production_controller_detail_dgv.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.production_controller_detail_dgv.RowHeadersVisible = false;
            // 
            // colModel
            // 
            this.colModel.DataPropertyName = "ProModel";
            resources.ApplyResources(this.colModel, "colModel");
            this.colModel.Name = "colModel";
            // 
            // colLine
            // 
            this.colLine.DataPropertyName = "ProLine";
            resources.ApplyResources(this.colLine, "colLine");
            this.colLine.Name = "colLine";
            // 
            // colTime
            // 
            this.colTime.DataPropertyName = "TimeHour";
            resources.ApplyResources(this.colTime, "colTime");
            this.colTime.Name = "colTime";
            // 
            // model_lbl
            // 
            resources.ApplyResources(this.model_lbl, "model_lbl");
            this.model_lbl.ControlId = null;
            this.model_lbl.Name = "model_lbl";
            // 
            // line_lbl
            // 
            resources.ApplyResources(this.line_lbl, "line_lbl");
            this.line_lbl.ControlId = null;
            this.line_lbl.Name = "line_lbl";
            // 
            // model_txt
            // 
            this.model_txt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.model_txt.ControlId = null;
            resources.ApplyResources(this.model_txt, "model_txt");
            this.model_txt.InputType = Com.Nidec.Mes.Framework.TextBoxCommon.InputTypeList.Numeric;
            this.model_txt.Name = "model_txt";
            this.model_txt.ReadOnly = true;
            // 
            // line_txt
            // 
            this.line_txt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.line_txt.ControlId = null;
            resources.ApplyResources(this.line_txt, "line_txt");
            this.line_txt.InputType = Com.Nidec.Mes.Framework.TextBoxCommon.InputTypeList.Numeric;
            this.line_txt.Name = "line_txt";
            this.line_txt.ReadOnly = true;
            // 
            // groupBoxCommon1
            // 
            this.groupBoxCommon1.ControlId = null;
            this.groupBoxCommon1.Controls.Add(this.process_txt);
            this.groupBoxCommon1.Controls.Add(this.labelCommon1);
            this.groupBoxCommon1.Controls.Add(this.model_txt);
            this.groupBoxCommon1.Controls.Add(this.line_txt);
            this.groupBoxCommon1.Controls.Add(this.model_lbl);
            this.groupBoxCommon1.Controls.Add(this.line_lbl);
            resources.ApplyResources(this.groupBoxCommon1, "groupBoxCommon1");
            this.groupBoxCommon1.Name = "groupBoxCommon1";
            this.groupBoxCommon1.TabStop = false;
            // 
            // process_txt
            // 
            this.process_txt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.process_txt.ControlId = null;
            resources.ApplyResources(this.process_txt, "process_txt");
            this.process_txt.InputType = Com.Nidec.Mes.Framework.TextBoxCommon.InputTypeList.Numeric;
            this.process_txt.Name = "process_txt";
            this.process_txt.ReadOnly = true;
            // 
            // labelCommon1
            // 
            resources.ApplyResources(this.labelCommon1, "labelCommon1");
            this.labelCommon1.ControlId = null;
            this.labelCommon1.Name = "labelCommon1";
            // 
            // groupBoxCommon2
            // 
            this.groupBoxCommon2.ControlId = null;
            this.groupBoxCommon2.Controls.Add(this.chart_ng);
            this.groupBoxCommon2.Controls.Add(this.linksave_txt);
            this.groupBoxCommon2.Controls.Add(this.browser_btn);
            this.groupBoxCommon2.Controls.Add(this.exportexcel_btn);
            resources.ApplyResources(this.groupBoxCommon2, "groupBoxCommon2");
            this.groupBoxCommon2.Name = "groupBoxCommon2";
            this.groupBoxCommon2.TabStop = false;
            // 
            // chart_ng
            // 
            this.chart_ng.BackColor = System.Drawing.SystemColors.Control;
            this.chart_ng.ControlId = null;
            resources.ApplyResources(this.chart_ng, "chart_ng");
            this.chart_ng.Name = "chart_ng";
            this.chart_ng.UseVisualStyleBackColor = false;
            this.chart_ng.Click += new System.EventHandler(this.chart_ng_Click);
            // 
            // linksave_txt
            // 
            this.linksave_txt.ControlId = null;
            resources.ApplyResources(this.linksave_txt, "linksave_txt");
            this.linksave_txt.InputType = Com.Nidec.Mes.Framework.TextBoxCommon.InputTypeList.All;
            this.linksave_txt.Name = "linksave_txt";
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
            // exportexcel_btn
            // 
            this.exportexcel_btn.BackColor = System.Drawing.SystemColors.Control;
            this.exportexcel_btn.ControlId = null;
            resources.ApplyResources(this.exportexcel_btn, "exportexcel_btn");
            this.exportexcel_btn.Name = "exportexcel_btn";
            this.exportexcel_btn.UseVisualStyleBackColor = false;
            this.exportexcel_btn.Click += new System.EventHandler(this.exportexcel_btn_Click);
            // 
            // search_grb
            // 
            this.search_grb.ControlId = null;
            this.search_grb.Controls.Add(this.timeto_dtp);
            this.search_grb.Controls.Add(this.timefrom_dtp);
            this.search_grb.Controls.Add(this.search_btn);
            this.search_grb.Controls.Add(this.labelCommon3);
            this.search_grb.Controls.Add(this.labelCommon4);
            resources.ApplyResources(this.search_grb, "search_grb");
            this.search_grb.Name = "search_grb";
            this.search_grb.TabStop = false;
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
            // timefrom_dtp
            // 
            this.timefrom_dtp.BackColor = System.Drawing.SystemColors.Control;
            this.timefrom_dtp.ControlId = null;
            resources.ApplyResources(this.timefrom_dtp, "timefrom_dtp");
            this.timefrom_dtp.DisplayFormat = Com.Nidec.Mes.Framework.DateTimePickerCommon.DisplayFormatList.ShortDatePattern;
            this.timefrom_dtp.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.timefrom_dtp.Name = "timefrom_dtp";
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
            // labelCommon3
            // 
            resources.ApplyResources(this.labelCommon3, "labelCommon3");
            this.labelCommon3.ControlId = null;
            this.labelCommon3.Name = "labelCommon3";
            // 
            // labelCommon4
            // 
            resources.ApplyResources(this.labelCommon4, "labelCommon4");
            this.labelCommon4.ControlId = null;
            this.labelCommon4.Name = "labelCommon4";
            // 
            // ProductionControllerDetailForm
            // 
            resources.ApplyResources(this, "$this");
            this.ControlId = "";
            this.Controls.Add(this.search_grb);
            this.Controls.Add(this.groupBoxCommon2);
            this.Controls.Add(this.groupBoxCommon1);
            this.Controls.Add(this.production_controller_detail_dgv);
            this.Name = "ProductionControllerDetailForm";
            this.TitleText = "Production Controller";
            this.Load += new System.EventHandler(this.ProductionControllerForm_Load);
            this.Controls.SetChildIndex(this.production_controller_detail_dgv, 0);
            this.Controls.SetChildIndex(this.groupBoxCommon1, 0);
            this.Controls.SetChildIndex(this.groupBoxCommon2, 0);
            this.Controls.SetChildIndex(this.search_grb, 0);
            ((System.ComponentModel.ISupportInitialize)(this.production_controller_detail_dgv)).EndInit();
            this.groupBoxCommon1.ResumeLayout(false);
            this.groupBoxCommon1.PerformLayout();
            this.groupBoxCommon2.ResumeLayout(false);
            this.groupBoxCommon2.PerformLayout();
            this.search_grb.ResumeLayout(false);
            this.search_grb.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private Framework.LabelCommon model_lbl;
        private Framework.LabelCommon line_lbl;
        private Framework.TextBoxCommon model_txt;
        private Framework.TextBoxCommon line_txt;
        private Framework.GroupBoxCommon groupBoxCommon1;
        private Framework.TextBoxCommon process_txt;
        private Framework.LabelCommon labelCommon1;
        private Framework.GroupBoxCommon groupBoxCommon2;
        private Framework.TextBoxCommon linksave_txt;
        private Framework.ButtonCommon browser_btn;
        private Framework.ButtonCommon exportexcel_btn;
        private Framework.ButtonCommon chart_ng;
        private System.Windows.Forms.DataGridViewTextBoxColumn colModel;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLine;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTime;
        internal Framework.DataGridViewCommon production_controller_detail_dgv;
        private Framework.GroupBoxCommon search_grb;
        private Framework.ButtonCommon search_btn;
        private Framework.LabelCommon labelCommon3;
        private Framework.LabelCommon labelCommon4;
        private Framework.DateTimePickerCommon timeto_dtp;
        private Framework.DateTimePickerCommon timefrom_dtp;
    }
}
