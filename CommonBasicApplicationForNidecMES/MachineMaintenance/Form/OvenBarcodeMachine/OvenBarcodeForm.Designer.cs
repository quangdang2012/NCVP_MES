namespace Com.Nidec.Mes.Common.Basic.MachineMaintenance.Form
{
    partial class OvenBarcodeForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OvenBarcodeForm));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title1 = new System.Windows.Forms.DataVisualization.Charting.Title();
            this.model_lbl = new Com.Nidec.Mes.Framework.LabelCommon();
            this.model_cmb = new Com.Nidec.Mes.Framework.ComboBoxCommon();
            this.line_lbl = new Com.Nidec.Mes.Framework.LabelCommon();
            this.line_cmb = new Com.Nidec.Mes.Framework.ComboBoxCommon();
            this.search_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.setting_gbc = new Com.Nidec.Mes.Framework.GroupBoxCommon();
            this.shift_lbl = new Com.Nidec.Mes.Framework.LabelCommon();
            this.barcode_cmb = new Com.Nidec.Mes.Framework.ComboBoxCommon();
            this.timefrom_dtp = new Com.Nidec.Mes.Framework.DateTimePickerCommon();
            this.timefrom_lbl = new Com.Nidec.Mes.Framework.LabelCommon();
            this.oven_dgv = new Com.Nidec.Mes.Framework.DataGridViewCommon();
            this.colDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFactory = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colModel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLine = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBarcode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTemperature = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDrying = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBoxCommon2 = new Com.Nidec.Mes.Framework.GroupBoxCommon();
            this.linksave_txt = new Com.Nidec.Mes.Framework.TextBoxCommon();
            this.browser_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.exportexcel_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.timeto_dtp = new Com.Nidec.Mes.Framework.DateTimePickerCommon();
            this.timeto_lbl = new Com.Nidec.Mes.Framework.LabelCommon();
            this.upper_txt = new Com.Nidec.Mes.Framework.TextBoxCommon();
            this.lower_txt = new Com.Nidec.Mes.Framework.TextBoxCommon();
            this.groupBoxCommon1 = new Com.Nidec.Mes.Framework.GroupBoxCommon();
            this.upper_lbl = new Com.Nidec.Mes.Framework.LabelCommon();
            this.low_lbl = new Com.Nidec.Mes.Framework.LabelCommon();
            this.chartOven = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.setting_gbc.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.oven_dgv)).BeginInit();
            this.groupBoxCommon2.SuspendLayout();
            this.groupBoxCommon1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartOven)).BeginInit();
            this.SuspendLayout();
            // 
            // model_lbl
            // 
            resources.ApplyResources(this.model_lbl, "model_lbl");
            this.model_lbl.ControlId = null;
            this.model_lbl.Name = "model_lbl";
            // 
            // model_cmb
            // 
            this.model_cmb.ControlId = null;
            resources.ApplyResources(this.model_cmb, "model_cmb");
            this.model_cmb.FormattingEnabled = true;
            this.model_cmb.Name = "model_cmb";
            this.model_cmb.SelectedIndexChanged += new System.EventHandler(this.model_cmb_SelectedIndexChanged);
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
            this.line_cmb.SelectedIndexChanged += new System.EventHandler(this.line_cmb_SelectedIndexChanged);
            // 
            // search_btn
            // 
            this.search_btn.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.search_btn.ControlId = null;
            resources.ApplyResources(this.search_btn, "search_btn");
            this.search_btn.ForeColor = System.Drawing.Color.Black;
            this.search_btn.Name = "search_btn";
            this.search_btn.UseVisualStyleBackColor = false;
            this.search_btn.Click += new System.EventHandler(this.search_btn_Click);
            // 
            // setting_gbc
            // 
            this.setting_gbc.ControlId = null;
            this.setting_gbc.Controls.Add(this.model_cmb);
            this.setting_gbc.Controls.Add(this.model_lbl);
            this.setting_gbc.Controls.Add(this.shift_lbl);
            this.setting_gbc.Controls.Add(this.line_lbl);
            this.setting_gbc.Controls.Add(this.barcode_cmb);
            this.setting_gbc.Controls.Add(this.line_cmb);
            resources.ApplyResources(this.setting_gbc, "setting_gbc");
            this.setting_gbc.Name = "setting_gbc";
            this.setting_gbc.TabStop = false;
            // 
            // shift_lbl
            // 
            resources.ApplyResources(this.shift_lbl, "shift_lbl");
            this.shift_lbl.ControlId = null;
            this.shift_lbl.Name = "shift_lbl";
            // 
            // barcode_cmb
            // 
            this.barcode_cmb.ControlId = null;
            resources.ApplyResources(this.barcode_cmb, "barcode_cmb");
            this.barcode_cmb.FormattingEnabled = true;
            this.barcode_cmb.Name = "barcode_cmb";
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
            // timefrom_lbl
            // 
            resources.ApplyResources(this.timefrom_lbl, "timefrom_lbl");
            this.timefrom_lbl.ControlId = null;
            this.timefrom_lbl.Name = "timefrom_lbl";
            // 
            // oven_dgv
            // 
            this.oven_dgv.AllowUserToAddRows = false;
            this.oven_dgv.AllowUserToDeleteRows = false;
            this.oven_dgv.AllowUserToOrderColumns = true;
            this.oven_dgv.AllowUserToResizeRows = false;
            resources.ApplyResources(this.oven_dgv, "oven_dgv");
            this.oven_dgv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(232)))), ((int)(((byte)(180)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.oven_dgv.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.oven_dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.oven_dgv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colDate,
            this.colFactory,
            this.colModel,
            this.colLine,
            this.colBarcode,
            this.colTemperature,
            this.colDrying,
            this.colStatus});
            this.oven_dgv.ControlId = null;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.oven_dgv.DefaultCellStyle = dataGridViewCellStyle2;
            this.oven_dgv.Name = "oven_dgv";
            this.oven_dgv.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(232)))), ((int)(((byte)(180)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.oven_dgv.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.oven_dgv.RowHeadersVisible = false;
            this.oven_dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            // 
            // colDate
            // 
            this.colDate.DataPropertyName = "Date";
            resources.ApplyResources(this.colDate, "colDate");
            this.colDate.Name = "colDate";
            this.colDate.ReadOnly = true;
            // 
            // colFactory
            // 
            this.colFactory.DataPropertyName = "FactoryCode";
            resources.ApplyResources(this.colFactory, "colFactory");
            this.colFactory.Name = "colFactory";
            this.colFactory.ReadOnly = true;
            // 
            // colModel
            // 
            this.colModel.DataPropertyName = "Model";
            resources.ApplyResources(this.colModel, "colModel");
            this.colModel.Name = "colModel";
            this.colModel.ReadOnly = true;
            // 
            // colLine
            // 
            this.colLine.DataPropertyName = "Line";
            resources.ApplyResources(this.colLine, "colLine");
            this.colLine.Name = "colLine";
            this.colLine.ReadOnly = true;
            // 
            // colBarcode
            // 
            this.colBarcode.DataPropertyName = "Barcode";
            resources.ApplyResources(this.colBarcode, "colBarcode");
            this.colBarcode.Name = "colBarcode";
            this.colBarcode.ReadOnly = true;
            // 
            // colTemperature
            // 
            this.colTemperature.DataPropertyName = "Temperature";
            resources.ApplyResources(this.colTemperature, "colTemperature");
            this.colTemperature.Name = "colTemperature";
            this.colTemperature.ReadOnly = true;
            // 
            // colDrying
            // 
            this.colDrying.DataPropertyName = "Drying";
            resources.ApplyResources(this.colDrying, "colDrying");
            this.colDrying.Name = "colDrying";
            this.colDrying.ReadOnly = true;
            // 
            // colStatus
            // 
            this.colStatus.DataPropertyName = "Status";
            resources.ApplyResources(this.colStatus, "colStatus");
            this.colStatus.Name = "colStatus";
            this.colStatus.ReadOnly = true;
            // 
            // groupBoxCommon2
            // 
            this.groupBoxCommon2.ControlId = null;
            this.groupBoxCommon2.Controls.Add(this.linksave_txt);
            this.groupBoxCommon2.Controls.Add(this.browser_btn);
            this.groupBoxCommon2.Controls.Add(this.exportexcel_btn);
            resources.ApplyResources(this.groupBoxCommon2, "groupBoxCommon2");
            this.groupBoxCommon2.Name = "groupBoxCommon2";
            this.groupBoxCommon2.TabStop = false;
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
            // 
            // exportexcel_btn
            // 
            this.exportexcel_btn.BackColor = System.Drawing.SystemColors.Control;
            this.exportexcel_btn.ControlId = null;
            resources.ApplyResources(this.exportexcel_btn, "exportexcel_btn");
            this.exportexcel_btn.Name = "exportexcel_btn";
            this.exportexcel_btn.UseVisualStyleBackColor = false;
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
            // upper_txt
            // 
            this.upper_txt.ControlId = null;
            resources.ApplyResources(this.upper_txt, "upper_txt");
            this.upper_txt.InputType = Com.Nidec.Mes.Framework.TextBoxCommon.InputTypeList.Numeric;
            this.upper_txt.Name = "upper_txt";
            // 
            // lower_txt
            // 
            this.lower_txt.ControlId = null;
            resources.ApplyResources(this.lower_txt, "lower_txt");
            this.lower_txt.InputType = Com.Nidec.Mes.Framework.TextBoxCommon.InputTypeList.Numeric;
            this.lower_txt.Name = "lower_txt";
            // 
            // groupBoxCommon1
            // 
            this.groupBoxCommon1.ControlId = null;
            this.groupBoxCommon1.Controls.Add(this.search_btn);
            this.groupBoxCommon1.Controls.Add(this.upper_lbl);
            this.groupBoxCommon1.Controls.Add(this.low_lbl);
            this.groupBoxCommon1.Controls.Add(this.timeto_dtp);
            this.groupBoxCommon1.Controls.Add(this.timefrom_dtp);
            this.groupBoxCommon1.Controls.Add(this.timeto_lbl);
            this.groupBoxCommon1.Controls.Add(this.timefrom_lbl);
            this.groupBoxCommon1.Controls.Add(this.lower_txt);
            this.groupBoxCommon1.Controls.Add(this.upper_txt);
            resources.ApplyResources(this.groupBoxCommon1, "groupBoxCommon1");
            this.groupBoxCommon1.Name = "groupBoxCommon1";
            this.groupBoxCommon1.TabStop = false;
            // 
            // upper_lbl
            // 
            resources.ApplyResources(this.upper_lbl, "upper_lbl");
            this.upper_lbl.ControlId = null;
            this.upper_lbl.Name = "upper_lbl";
            // 
            // low_lbl
            // 
            resources.ApplyResources(this.low_lbl, "low_lbl");
            this.low_lbl.ControlId = null;
            this.low_lbl.Name = "low_lbl";
            // 
            // chartOven
            // 
            chartArea1.AxisX.IntervalAutoMode = System.Windows.Forms.DataVisualization.Charting.IntervalAutoMode.VariableCount;
            chartArea1.AxisX.MajorGrid.Enabled = false;
            chartArea1.Name = "ChartArea1";
            this.chartOven.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chartOven.Legends.Add(legend1);
            resources.ApplyResources(this.chartOven, "chartOven");
            this.chartOven.Name = "chartOven";
            this.chartOven.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Excel;
            series1.BorderWidth = 5;
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            series1.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Time;
            this.chartOven.Series.Add(series1);
            title1.Name = "Title1";
            this.chartOven.Titles.Add(title1);
            // 
            // OvenBarcodeForm
            // 
            resources.ApplyResources(this, "$this");
            this.ControlId = "";
            this.Controls.Add(this.chartOven);
            this.Controls.Add(this.groupBoxCommon1);
            this.Controls.Add(this.groupBoxCommon2);
            this.Controls.Add(this.setting_gbc);
            this.Controls.Add(this.oven_dgv);
            this.Name = "OvenBarcodeForm";
            this.TitleText = "Oven Form";
            this.Load += new System.EventHandler(this.OvenBarcodeForm_Load);
            this.Controls.SetChildIndex(this.oven_dgv, 0);
            this.Controls.SetChildIndex(this.setting_gbc, 0);
            this.Controls.SetChildIndex(this.groupBoxCommon2, 0);
            this.Controls.SetChildIndex(this.groupBoxCommon1, 0);
            this.Controls.SetChildIndex(this.chartOven, 0);
            this.setting_gbc.ResumeLayout(false);
            this.setting_gbc.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.oven_dgv)).EndInit();
            this.groupBoxCommon2.ResumeLayout(false);
            this.groupBoxCommon2.PerformLayout();
            this.groupBoxCommon1.ResumeLayout(false);
            this.groupBoxCommon1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartOven)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Framework.LabelCommon model_lbl;
        private Framework.ComboBoxCommon model_cmb;
        private Framework.LabelCommon line_lbl;
        private Framework.ComboBoxCommon line_cmb;
        private Framework.ButtonCommon search_btn;
        private Framework.GroupBoxCommon setting_gbc;
        internal Framework.DataGridViewCommon oven_dgv;
        private Framework.GroupBoxCommon groupBoxCommon2;
        private Framework.TextBoxCommon linksave_txt;
        private Framework.ButtonCommon browser_btn;
        private Framework.ButtonCommon exportexcel_btn;
        private Framework.LabelCommon timefrom_lbl;
        private Framework.DateTimePickerCommon timefrom_dtp;
        private Framework.LabelCommon shift_lbl;
        private Framework.ComboBoxCommon barcode_cmb;
        private Framework.DateTimePickerCommon timeto_dtp;
        private Framework.LabelCommon timeto_lbl;
        private Framework.TextBoxCommon upper_txt;
        private Framework.TextBoxCommon lower_txt;
        private Framework.GroupBoxCommon groupBoxCommon1;
        private Framework.LabelCommon upper_lbl;
        private Framework.LabelCommon low_lbl;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartOven;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFactory;
        private System.Windows.Forms.DataGridViewTextBoxColumn colModel;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLine;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBarcode;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTemperature;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDrying;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStatus;
    }
}
