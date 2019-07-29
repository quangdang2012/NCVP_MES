namespace Com.Nidec.Mes.Common.Basic.MachineMaintenance.Form
{
    partial class ProductionControllerChart_CNCVCForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProductionControllerChart_CNCVCForm));
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title1 = new System.Windows.Forms.DataVisualization.Charting.Title();
            this.model_lbl = new Com.Nidec.Mes.Framework.LabelCommon();
            this.line_lbl = new Com.Nidec.Mes.Framework.LabelCommon();
            this.setting_gbc = new Com.Nidec.Mes.Framework.GroupBoxCommon();
            this.process_lbl = new Com.Nidec.Mes.Framework.LabelCommon();
            this.processn_lbl = new Com.Nidec.Mes.Framework.LabelCommon();
            this.labelCommon4 = new Com.Nidec.Mes.Framework.LabelCommon();
            this.dateN_lbl = new Com.Nidec.Mes.Framework.LabelCommon();
            this.labelCommon3 = new Com.Nidec.Mes.Framework.LabelCommon();
            this.date_lbl = new Com.Nidec.Mes.Framework.LabelCommon();
            this.chartNG = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.setting_gbc.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartNG)).BeginInit();
            this.SuspendLayout();
            // 
            // model_lbl
            // 
            resources.ApplyResources(this.model_lbl, "model_lbl");
            this.model_lbl.BackColor = System.Drawing.Color.Aqua;
            this.model_lbl.ControlId = null;
            this.model_lbl.Name = "model_lbl";
            // 
            // line_lbl
            // 
            resources.ApplyResources(this.line_lbl, "line_lbl");
            this.line_lbl.BackColor = System.Drawing.Color.Aqua;
            this.line_lbl.ControlId = null;
            this.line_lbl.Name = "line_lbl";
            // 
            // setting_gbc
            // 
            this.setting_gbc.BackColor = System.Drawing.Color.CornflowerBlue;
            this.setting_gbc.ControlId = null;
            this.setting_gbc.Controls.Add(this.process_lbl);
            this.setting_gbc.Controls.Add(this.processn_lbl);
            this.setting_gbc.Controls.Add(this.labelCommon4);
            this.setting_gbc.Controls.Add(this.dateN_lbl);
            this.setting_gbc.Controls.Add(this.labelCommon3);
            this.setting_gbc.Controls.Add(this.model_lbl);
            this.setting_gbc.Controls.Add(this.date_lbl);
            this.setting_gbc.Controls.Add(this.line_lbl);
            resources.ApplyResources(this.setting_gbc, "setting_gbc");
            this.setting_gbc.Name = "setting_gbc";
            this.setting_gbc.TabStop = false;
            // 
            // process_lbl
            // 
            resources.ApplyResources(this.process_lbl, "process_lbl");
            this.process_lbl.BackColor = System.Drawing.Color.Aqua;
            this.process_lbl.ControlId = null;
            this.process_lbl.Name = "process_lbl";
            // 
            // processn_lbl
            // 
            resources.ApplyResources(this.processn_lbl, "processn_lbl");
            this.processn_lbl.BackColor = System.Drawing.Color.CornflowerBlue;
            this.processn_lbl.ControlId = null;
            this.processn_lbl.ForeColor = System.Drawing.Color.Black;
            this.processn_lbl.Name = "processn_lbl";
            // 
            // labelCommon4
            // 
            resources.ApplyResources(this.labelCommon4, "labelCommon4");
            this.labelCommon4.BackColor = System.Drawing.Color.CornflowerBlue;
            this.labelCommon4.ControlId = null;
            this.labelCommon4.ForeColor = System.Drawing.Color.Black;
            this.labelCommon4.Name = "labelCommon4";
            // 
            // dateN_lbl
            // 
            resources.ApplyResources(this.dateN_lbl, "dateN_lbl");
            this.dateN_lbl.BackColor = System.Drawing.Color.CornflowerBlue;
            this.dateN_lbl.ControlId = null;
            this.dateN_lbl.ForeColor = System.Drawing.Color.Black;
            this.dateN_lbl.Name = "dateN_lbl";
            // 
            // labelCommon3
            // 
            resources.ApplyResources(this.labelCommon3, "labelCommon3");
            this.labelCommon3.BackColor = System.Drawing.Color.CornflowerBlue;
            this.labelCommon3.ControlId = null;
            this.labelCommon3.ForeColor = System.Drawing.Color.Black;
            this.labelCommon3.Name = "labelCommon3";
            // 
            // date_lbl
            // 
            resources.ApplyResources(this.date_lbl, "date_lbl");
            this.date_lbl.BackColor = System.Drawing.Color.Aqua;
            this.date_lbl.ControlId = null;
            this.date_lbl.Name = "date_lbl";
            // 
            // chartNG
            // 
            chartArea1.AxisX.IntervalAutoMode = System.Windows.Forms.DataVisualization.Charting.IntervalAutoMode.VariableCount;
            chartArea1.AxisX.MajorGrid.Enabled = false;
            chartArea1.Name = "ChartArea1";
            this.chartNG.ChartAreas.Add(chartArea1);
            resources.ApplyResources(this.chartNG, "chartNG");
            legend1.Name = "Legend1";
            this.chartNG.Legends.Add(legend1);
            this.chartNG.Name = "chartNG";
            this.chartNG.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Excel;
            series1.BorderWidth = 5;
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.BoxPlot;
            series1.IsXValueIndexed = true;
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            series1.YValuesPerPoint = 6;
            this.chartNG.Series.Add(series1);
            title1.Name = "Title1";
            this.chartNG.Titles.Add(title1);
            // 
            // ProductionControllerChart_CNCVCForm
            // 
            resources.ApplyResources(this, "$this");
            this.ControlId = "";
            this.Controls.Add(this.chartNG);
            this.Controls.Add(this.setting_gbc);
            this.Name = "ProductionControllerChart_CNCVCForm";
            this.TitleText = "Production Controller";
            this.Load += new System.EventHandler(this.ProductionControllerChart_CForm_Load);
            this.Controls.SetChildIndex(this.setting_gbc, 0);
            this.Controls.SetChildIndex(this.chartNG, 0);
            this.setting_gbc.ResumeLayout(false);
            this.setting_gbc.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartNG)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Framework.LabelCommon model_lbl;
        private Framework.LabelCommon line_lbl;
        private Framework.GroupBoxCommon setting_gbc;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartNG;
        private Framework.LabelCommon processn_lbl;
        private Framework.LabelCommon labelCommon4;
        private Framework.LabelCommon labelCommon3;
        private Framework.LabelCommon dateN_lbl;
        private Framework.LabelCommon date_lbl;
        private Framework.LabelCommon process_lbl;
    }
}
