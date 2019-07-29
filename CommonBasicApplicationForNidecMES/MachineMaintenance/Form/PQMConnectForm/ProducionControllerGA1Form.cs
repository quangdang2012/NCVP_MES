using Com.Nidec.Mes.Framework;
using System.Windows.Forms.DataVisualization.Charting;
using System;
using System.Linq;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Com.Nidec.Mes.Common.Basic.MachineMaintenance.Vo;
using Com.Nidec.Mes.Common.Basic.MachineMaintenance.Cbm;
using System.IO.Ports;
using Com.Nidec.Mes.Common.Basic.MachineMaintenance.Cbm.PQMConnectCbm.ProductionControllerGA1Cbm;

namespace Com.Nidec.Mes.Common.Basic.MachineMaintenance.Form
{
    public partial class ProducionControllerGA1Form : FormCommonNCVP
    {
        public ProducionControllerGA1Form()
        {
            InitializeComponent();
        }
        public string[] portName;
        public static readonly string connection = "Server=192.168.145.12;Port=5432;UserId=pqm;Password=dbuser;Database=pqmdb;;";
        public static readonly string connectionmes = "Server=192.168.145.12;Port=5432;UserId=mes;Password=dbuser;Database=mesdb;;";
        public string tablename;
        public void loadTime()
        {
            Yearlbl.Text = DateTime.Now.Year.ToString();
            monthlbl.Text = DateTime.Now.Month.ToString();
            daylbl.Text = DateTime.Now.Day.ToString();
            timelbl.Text = DateTime.Now.ToString("HH:mm:ss");
        }
        private void ProducionControllerGA1Form_Load(object sender, EventArgs e)
        {
            tabControl1.TabPages.Remove(tabPage8);
            tabControl1.TabPages.Remove(tabPage9);
            DateTimelbl();
            cmbSeriport.DataSource = SerialPort.GetPortNames();
            cmbSeriport.Text = "";
            callModel();
            loadTime();
            timerDateTimeNow.Enabled = true;
            txtrateNGAlarmFrame.Text = RatioRate("Rate_Frame");
            txtrateNGAlarmGear.Text = RatioRate("Rate_Gear");
            txtrateNGAlarmMotor.Text = RatioRate("Rate_Motor");
        }
        public string RatioRate(string code)
        {
            try
            {
                RateNGVo rate = (RateNGVo)DefaultCbmInvoker.Invoke(new GetProductionRateNGRatioCbm(), new RateNGVo { RateModel = cmb_model.Text, RateLine = cmb_line.Text, RateCode = code }, connectionmes);
                return rate.RateRatio;
            }
            catch (Framework.ApplicationException exception)
            {
                popUpMessage.ApplicationError(exception.GetMessageData(), Text);
                logger.Error(exception.GetMessageData());
                return "0";
            }
        }
        private void timerDateTimeNow_Tick(object sender, EventArgs e)
        {
            loadTime();
        }
        void callModel()
        {
            //ValueObjectList<ModelVo> modelvolist = (ValueObjectList<ModelVo>)DefaultCbmInvoker.Invoke(new GetModelCbm(), new ModelVo());
            ValueObjectList<ProductionControllerGA1Vo> modelvolist = (ValueObjectList<ProductionControllerGA1Vo>)DefaultCbmInvoker.Invoke(new GetProductionModelCbm(), new ProductionControllerGA1Vo(), connection);
            cmb_model.DisplayMember = "ModelCode";
            BindingSource b1 = new BindingSource(modelvolist.GetList(), null);
            cmb_model.DataSource = b1;
            cmb_model.Text = "";
        }
        void callLine()
        {
            ValueObjectList<ProductionControllerGA1Vo> assetvoinvoice = (ValueObjectList<ProductionControllerGA1Vo>)DefaultCbmInvoker.Invoke(new GetProductionLineCbm(), new ProductionControllerGA1Vo { ModelCode = cmb_model.Text }, connection);
            cmb_line.DisplayMember = "LineCode";
            cmb_line.DataSource = assetvoinvoice.GetList();
            cmb_line.Text = "";
        }

        private void cmb_model_SelectedIndexChanged(object sender, EventArgs e)
        {
            callLine();
            cmb_process.Text = "";
            cmb_item.Text = "";
        }

        private void cmb_process_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                tablename = cmb_model.Text + DateTime.Now.ToString("yyyyMM");
                ValueObjectList<ProductionControllerGA1Vo> assetvoinvoice = (ValueObjectList<ProductionControllerGA1Vo>)DefaultCbmInvoker.Invoke(new GetProductionItemCbm(), new ProductionControllerGA1Vo { ModelCode = cmb_model.Text, LineCode = cmb_line.Text, TableName = tablename, ProcessCode = cmb_process.Text }, connection);
                cmb_item.DisplayMember = "ItemCode";
                cmb_item.DataSource = assetvoinvoice.GetList();
                cmb_item.Text = "";
            }
            catch (Framework.ApplicationException exception)
            {
                popUpMessage.ApplicationError(exception.GetMessageData(), Text);
                logger.Error(exception.GetMessageData());
            }
        }
        private void btn_SearchData_Click(object sender, EventArgs e)//button Run
        {
            dgvRate.Rows.Clear();
            funtion();
            dgvRate.Sort(dgvRate.Columns["colrate"], ListSortDirection.Descending);
            grbSearchData.Visible = false;
            tblLayoutData.Dock = DockStyle.Fill;
            chbViData.Text = "Online";
            chbViData.Checked = false;

            tblLayoutChart.Dock = DockStyle.Fill;
            chbViChart.Text = "Online";
            chbViChart.Checked = false;
            GridBind();
            showchartLine("FA_IP", "FA_OP", "RateNG_Frame", "Total_NG_Frame", chr_main, lblInputFrame, lblOutputFrame, lblTotalNGFrame); // frame
            showchartLine("GC_IP", "GC_OP", "RateNG_Gear", "Total_NG_Gear", chartGear, lblInputGear, lblOutputGear, lblTotalNGGear); // gear 
            showchartLine("MC_IP", "OUTPUT", "RateNG_Motor", "Total_NG_Motor", chartMotor, lblInputMotor, lblOutputMotor, lblTotalNGMotor); // motor
            alarmNG();
            showchartProcess();

            btn_Run.Enabled = false;
            btnStop.Enabled = true;
            timer1.Interval = int.Parse(txtTimer.Text);
            timer1.Enabled = true;
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            btn_Run.Enabled = true;
            btnStop.Enabled = false;
            timer1.Enabled = false;
        }
        DataTable dtRate;
        public string NGRate(double ng, double ngTotal, double output, string header)
        {
            string n = "";
            if (header != "NA")
            {
                string value = Math.Round((ng / (ngTotal + output)) * 100, 2).ToString();
                if (value == "NaN" || value == "Infinity" || value == "-Infinity") { value = "0"; }
                dgvRate.Rows.Add(header, double.Parse(value), ng);
            }
            return n = (Math.Round((ng / (ngTotal + output)) * 100, 2)).ToString() + "%";
        }
        public string Yield(double ng, double output)
        {
            string n = "";
            return n = (Math.Round(100 - (ng / (output + ng)) * 100, 2)).ToString() + "%";
        }

        private string GridBindNG_NOICHK(bool t)
        {
            try
            {
                tablename = cmb_model.Text + DateTime.Now.ToString("yyyyMM");
                ValueObjectList<ProductionControllerGA1Vo> inspecdata = (ValueObjectList<ProductionControllerGA1Vo>)DefaultCbmInvoker.Invoke(new SearchNGNOICHKfromMesdbCbm(), new ProductionControllerGA1Vo { ModelCode = cmb_model.Text, LineCode = cmb_line.Text, DateFrom = dtp_dateFromdata.Value, DateTo = dtp_dateTodata.Value, change = t }, connectionmes);
                if (inspecdata.GetList()[0].InspecData != "")
                {
                    return inspecdata.GetList()[0].InspecData;
                }
                else return "0";
            }
            catch (Framework.ApplicationException exception)
            {
                popUpMessage.ApplicationError(exception.GetMessageData(), Text);
                logger.Error(exception.GetMessageData());
                return "0";
            }
        }
        private string GridBindQtyNOICHK(bool t)
        {
            try
            {
                ValueObjectList<ProductionControllerGA1Vo> inspecdata = (ValueObjectList<ProductionControllerGA1Vo>)DefaultCbmInvoker.Invoke(new SearchQtyNOICHKfromMesdbCbm(), new ProductionControllerGA1Vo { ModelCode = cmb_model.Text, LineCode = cmb_line.Text, DateFrom = dtp_dateFromdata.Value, DateTo = dtp_dateTodata.Value, change = t }, connectionmes);
                if (inspecdata.GetList()[0].InspecData != "")
                {
                    return inspecdata.GetList()[0].InspecData;
                }
                else return "0";
            }
            catch (Framework.ApplicationException exception)
            {
                popUpMessage.ApplicationError(exception.GetMessageData(), Text);
                logger.Error(exception.GetMessageData());
                return "0";
            }
        }
        void showchart()
        {
            chr_main.ResetAutoValues();
            chr_main.ResumeLayout();
            chr_main.Series.Clear();

            chr_main.Titles[0].Text = "CHART SHOW PROGRESS DATA"; //ten
            chr_main.Titles[0].Font = new Font("Arial", 16, FontStyle.Bold);
            chr_main.ChartAreas[0].AxisX.LabelStyle.Format = "dd-MM HH:mm";
            chr_main.ChartAreas[0].AxisX.MajorGrid.Enabled = false;
            chr_main.ChartAreas[0].AxisX2.MajorGrid.Enabled = false;
            chr_main.ChartAreas[0].AxisY.MajorGrid.Enabled = true;
            chr_main.ChartAreas[0].AxisY2.MajorGrid.Enabled = false;
            chr_main.ChartAreas[0].AxisX.IntervalAutoMode = IntervalAutoMode.VariableCount;
            chr_main.ChartAreas[0].AxisY.Title = "TOTAL[PCS]"; //sua ten truc
            chr_main.ChartAreas[0].AxisX.LabelStyle.Angle = -60;

            chr_main.Series.Add("Output");
            chr_main.Series["Output"].XValueType = ChartValueType.Date;
            chr_main.Series["Output"].ChartType = SeriesChartType.Line;
            chr_main.Series["Output"].Color = Color.FromArgb(0, 192, 0); //green
            chr_main.Series["Output"].BorderWidth = 5;
            chr_main.Series["Output"].CustomProperties = "LabelStyle=Bottom"; //chua nhu chó
            chr_main.Series["Output"].IsValueShownAsLabel = true;

            chr_main.Series.Add("Input");
            chr_main.Series["Input"].XValueType = ChartValueType.Date;
            chr_main.Series["Input"].ChartType = SeriesChartType.Line;
            chr_main.Series["Input"].Color = Color.FromArgb(192, 192, 0); //green
            chr_main.Series["Input"].BorderWidth = 5;
            chr_main.Series["Input"].CustomProperties = "LabelStyle=Bottom"; //chua nhu chó
            chr_main.Series["Input"].IsValueShownAsLabel = true;

            chr_main.Series.Add("YEILD");
            chr_main.Series["YEILD"].ChartType = SeriesChartType.Line;
            chr_main.Series["YEILD"].Color = Color.FromArgb(192, 100, 0); //yellow    
            chr_main.Series["YEILD"].BorderWidth = 1;
            chr_main.Series["YEILD"].IsValueShownAsLabel = true;
            chr_main.ChartAreas[0].AxisY2.Enabled = AxisEnabled.True;
            chr_main.Series["YEILD"].YAxisType = AxisType.Secondary;
            chr_main.ChartAreas[0].AxisX2.Enabled = AxisEnabled.True;
            chr_main.Series["YEILD"].XAxisType = AxisType.Secondary;
            chr_main.Series["YEILD"].XValueType = ChartValueType.DateTime;
            chr_main.ChartAreas[0].AxisX2.LabelStyle.Format = "HH:mm";
            chr_main.ChartAreas[0].AxisX2.LabelStyle.Angle = 0;
            chr_main.ChartAreas[0].AxisY2.Maximum = 100;
            chr_main.ChartAreas[0].AxisY2.Title = "YEILD [%]";

            if (dgv.RowCount > 8)
            {
                int refa = dgv.RowCount / 8;
                double dataOut = 0;
                double dataIn = 0;
                double dataNG = 0;
                for (int i = 0; i < dgv.RowCount; i++)
                {
                    if (dgv.Columns.Contains("OUTPUT")) { dataOut += double.Parse(dgv.Rows[i].Cells["OUTPUT"].Value.ToString()); }
                    if (dgv.Columns.Contains("INPUT")) { dataOut += double.Parse(dgv.Rows[i].Cells["INPUT"].Value.ToString()); }
                    dataNG += double.Parse(dgv.Rows[i].Cells["Total_NG"].Value.ToString());
                    if (i % refa == 0)
                    {
                        chr_main.Series["Output"].Points.AddXY(dgv.Rows[i].Cells["Date"].Value.ToString(), dataOut);
                        chr_main.Series["Input"].Points.AddXY(dgv.Rows[i].Cells["Date"].Value.ToString(), dataIn);
                        chr_main.Series["YEILD"].Points.AddXY(dgv.Rows[i].Cells["Date"].Value.ToString(), Math.Round(((dataNG / dataOut) * 100) < 100 ? ((dataNG / dataOut) * 100) : 100, 2));
                    }
                }
            }
        }
        void showchartProcess()
        {
            chart_pie.ResetAutoValues();
            chart_pie.ResumeLayout();
            chart_pie.Series.Clear();

            chart_pie.Titles[0].Text = "Top 5 All Process (%)"; //ten
            chart_pie.Titles[0].Font = new Font("Arial", 16, FontStyle.Bold);
            chart_pie.Series.Add("Ratio");
            chart_pie.Series["Ratio"].ChartType = SeriesChartType.Column;
            chart_pie.Series["Ratio"].IsValueShownAsLabel = true;
            chart_pie.ChartAreas[0].AxisX.LabelStyle.Angle = -40;
            chart_pie.ChartAreas[0].AxisX.LabelStyle.Font = new Font("Arial", 10);
            chart_pie.ChartAreas[0].AxisY.Title = "Ratio (%)";
            chart_pie.ChartAreas[0].AxisY2.Title = "Quantity (pcs)";
            chart_pie.Series.Add("Pcs");
            chart_pie.Series["Pcs"].ChartType = SeriesChartType.Column;
            chart_pie.Series["Pcs"].Color = Color.Brown;
            chart_pie.Series["Pcs"].IsValueShownAsLabel = true;
            chart_pie.ChartAreas[0].AxisY2.Enabled = AxisEnabled.True;
            chart_pie.Series["Pcs"].YAxisType = AxisType.Secondary;
            chart_pie.Series["Pcs"].CustomProperties = "LabelStyle=Bottom";
            chart_pie.Series["Pcs"].LabelForeColor = Color.Black;

            string header = "";

            for (int j = 0; j < 5; j++)
            {
                header = dgvRate.Rows[j].Cells[0].Value.ToString();
                string value = "0";
                string pcs = "0";
                value = dgvRate.Rows[j].Cells[1].Value.ToString();
                pcs = dgvRate.Rows[j].Cells[2].Value.ToString();
                chart_pie.Series["Ratio"].Points.AddXY(header, value);
                chart_pie.Series["Pcs"].Points.AddXY(header, pcs);
                //chart_pie.Series["Pcs"].y;

            }
        }
        void showchartLine(string input, string output, string rateNG_, string totalNG_, Chart chr, Label lblinput, Label lbloutput, Label lbltotalNG)
        {
            chr.ResetAutoValues();
            chr.ResumeLayout();
            chr.Series.Clear();

            chr.Titles[0].Text = "CHART SHOW PROGRESS DATA"; //ten
            chr.Titles[0].Font = new Font("Arial", 16, FontStyle.Bold);
            chr.ChartAreas[0].AxisX.LabelStyle.Format = "dd-MM HH:mm";
            chr.ChartAreas[0].AxisX.MajorGrid.Enabled = false;
            chr.ChartAreas[0].AxisX2.MajorGrid.Enabled = false;
            chr.ChartAreas[0].AxisY.MajorGrid.Enabled = true;
            chr.ChartAreas[0].AxisY2.MajorGrid.Enabled = false;
            chr.ChartAreas[0].AxisX.IntervalAutoMode = IntervalAutoMode.VariableCount;
            chr.ChartAreas[0].AxisY.Title = "TOTAL[PCS]"; //sua ten truc
            chr.ChartAreas[0].AxisX.LabelStyle.Angle = -60;

            chr.Series.Add("Output (pcs)");
            chr.Series["Output (pcs)"].XValueType = ChartValueType.Date;
            chr.Series["Output (pcs)"].ChartType = SeriesChartType.Line;
            chr.Series["Output (pcs)"].Color = Color.FromArgb(0, 192, 0); //green
            chr.Series["Output (pcs)"].BorderWidth = 5;
            chr.Series["Output (pcs)"].CustomProperties = "LabelStyle=Bottom"; //chua nhu chó
            chr.Series["Output (pcs)"].IsValueShownAsLabel = true;

            chr.Series.Add("Input (pcs)");
            chr.Series["Input (pcs)"].XValueType = ChartValueType.Date;
            chr.Series["Input (pcs)"].ChartType = SeriesChartType.Line;
            chr.Series["Input (pcs)"].Color = Color.FromArgb(192, 192, 0); //green
            chr.Series["Input (pcs)"].BorderWidth = 5;
            chr.Series["Input (pcs)"].CustomProperties = "LabelStyle=Bottom"; //chua nhu chó
            chr.Series["Input (pcs)"].IsValueShownAsLabel = true;

            chr.Series.Add("YEILD (%)");
            chr.Series["YEILD (%)"].ChartType = SeriesChartType.Line;
            chr.Series["YEILD (%)"].Color = Color.FromArgb(192, 100, 0); //yellow    
            chr.Series["YEILD (%)"].BorderWidth = 1;
            chr.Series["YEILD (%)"].IsValueShownAsLabel = true;
            chr.ChartAreas[0].AxisY2.Enabled = AxisEnabled.True;
            chr.Series["YEILD (%)"].YAxisType = AxisType.Secondary;
            chr.ChartAreas[0].AxisX2.Enabled = AxisEnabled.True;
            chr.Series["YEILD (%)"].XAxisType = AxisType.Secondary;
            chr.Series["YEILD (%)"].XValueType = ChartValueType.DateTime;
            chr.ChartAreas[0].AxisX2.LabelStyle.Format = "HH:mm";
            chr.ChartAreas[0].AxisX2.LabelStyle.Angle = 0;
            chr.ChartAreas[0].AxisY2.Maximum = 100;
            chr.ChartAreas[0].AxisY2.Title = "YEILD [%]";

            //if (dt)//time
            //{
            //    if (dgv.RowCount > 8)
            //    {
            //        int refa = dgv.RowCount / 8;
            //        double dataOut = 0;
            //        double dataIn = 0;
            //        double dataNG = 0;
            //        for (int i = 0; i < dgv.RowCount; i++)
            //        {
            //            if (dgv.Columns.Contains("OUTPUT")) { dataOut += double.Parse(dgv.Rows[i].Cells["OUTPUT"].Value.ToString()); }
            //            if (dgv.Columns.Contains("INPUT")) { dataOut += double.Parse(dgv.Rows[i].Cells["INPUT"].Value.ToString()); }
            //            dataNG = double.Parse(dgv.Rows[i].Cells["Total_NG"].Value.ToString());
            //            if (i % refa == 0)
            //            {
            //                chr.Series["Output"].Points.AddXY(dgv.Rows[i].Cells["Date"].Value.ToString(), dataOut);
            //                chr.Series["Input"].Points.AddXY(dgv.Rows[i].Cells["Date"].Value.ToString(), dataIn);
            //                chr.Series["YEILD"].Points.AddXY(dgv.Rows[i].Cells["Date"].Value.ToString(), Math.Round((100 - (dataNG / dataOut) * 100), 2));
            //            }
            //        }
            //    }
            //}
            if (dgv.RowCount > 0)
            {
                double dataOut = 0;
                double dataIn = 0;
                double rateNG = 0;
                double totalNG = 0;
                for (int i = 0; i < dgv.RowCount - 1; i++)
                {
                    if (dgv.Columns.Contains(output))
                    {
                        if (dgv.Rows[i].Cells[output].Value.ToString() != "")
                        {
                            dataOut += double.Parse(dgv.Rows[i].Cells[output].Value.ToString());
                        }
                    }
                    if (dgv.Columns.Contains(input)) { dataIn += double.Parse(dgv.Rows[i].Cells[input].Value.ToString()); }
                    if (dgv.Columns.Contains(totalNG_)) { totalNG += double.Parse(dgv.Rows[i].Cells[totalNG_].Value.ToString()); }

                    if (dataOut > 0) { rateNG = (totalNG / (dataOut + totalNG)) * 100; }////////quan trong
                    else rateNG = 0;

                    chr.Series["Output (pcs)"].Points.AddXY(dgv.Rows[i].Cells["Date"].Value.ToString(), dataOut);
                    chr.Series["Input (pcs)"].Points.AddXY(dgv.Rows[i].Cells["Date"].Value.ToString(), dataIn);
                    //if (rateNG > 100) { rateNG = 0; }
                    chr.Series["YEILD (%)"].Points.AddXY(dgv.Rows[i].Cells["Date"].Value.ToString(), 100 - Math.Round(rateNG, 2));
                    lblinput.Text = dataIn.ToString();
                    lbloutput.Text = dataOut.ToString();
                    lbltotalNG.Text = totalNG.ToString();
                }
            }
        }

        private void GridBind()
        {
            tablename = cmb_model.Text + DateTime.Now.ToString("yyyyMM");
            try
            {
                ProductionControllerGA1Vo dgvVo = new ProductionControllerGA1Vo()
                {
                    TableName = tablename,
                    ModelCode = cmb_model.Text,
                    LineCode = cmb_line.Text,
                    ProcessCode = cmb_process.Text,
                    ItemCode = cmb_item.Text,
                    DateFrom = DateTime.Parse(dtp_dateFromdata.Text),
                    DateTo = DateTime.Parse(dtp_dateTodata.Text),
                    grDate = false,
                    Date = DateTime.Parse(dtp_dateTodata.Text).ToShortDateString(),
                };

                ProductionControllerGA1Vo listvo = (ProductionControllerGA1Vo)DefaultCbmInvoker.Invoke(new SearchProductionINPUTCbm(), dgvVo, connection);

                ProductionControllerGA1Vo outputvo = (ProductionControllerGA1Vo)DefaultCbmInvoker.Invoke(new SearchProductionOUTPUTCbm(), new ProductionControllerGA1Vo()
                {
                    ModelCode = cmb_model.Text,
                    LineCode = cmb_line.Text,
                    DateFrom = DateTime.Parse(dtp_dateFromdata.Text),
                    DateTo = DateTime.Parse(dtp_dateTodata.Text),
                    Date = DateTime.Parse(dtp_dateTodata.Text).ToShortDateString(),
                    change = true,
                }, connectionmes);

                ProductionControllerGA1Vo outputFinalvo = (ProductionControllerGA1Vo)DefaultCbmInvoker.Invoke(new SearchOUTPUTByHourCbm(), new ProductionControllerGA1Vo()
                {
                    ModelCode = cmb_model.Text,
                    LineCode = cmb_line.Text,
                    DateFrom = DateTime.Parse(dtp_dateFromdata.Text),
                    DateTo = DateTime.Parse(dtp_dateTodata.Text),
                    Date = DateTime.Parse(dtp_dateTodata.Text).ToShortDateString(),
                }, connectionmes);

                ProductionControllerGA1Vo ngThurstVo = (ProductionControllerGA1Vo)DefaultCbmInvoker.Invoke(new SearchNGThurstChartCbm(), new ProductionControllerGA1Vo()
                {
                    ModelCode = cmb_model.Text,
                    LineCode = cmb_line.Text,
                    DateFrom = DateTime.Parse(dtp_dateFromdata.Text),
                    DateTo = DateTime.Parse(dtp_dateTodata.Text),
                    Date = DateTime.Parse(dtp_dateTodata.Text).ToShortDateString(),
                }, connectionmes);//lay ng thurst tu mesdb

                ProductionControllerGA1Vo ngNOICHKVo = (ProductionControllerGA1Vo)DefaultCbmInvoker.Invoke(new SearchProductionNGNOICHKCbm(), new ProductionControllerGA1Vo()
                {
                    ModelCode = cmb_model.Text,
                    LineCode = cmb_line.Text,
                    DateFrom = DateTime.Parse(dtp_dateFromdata.Text),
                    DateTo = DateTime.Parse(dtp_dateTodata.Text),
                    Date = DateTime.Parse(dtp_dateTodata.Text).ToShortDateString(),
                    change = false,
                }, connectionmes);

                var distinctProcess = (from row in listvo.dt.AsEnumerable() orderby row["process"] select row.Field<string>("process")).Distinct();
                DataTable dt = new DataTable();
                dt.Columns.Add("Model");
                dt.Columns.Add("Line");
                dt.Columns.Add("Date");
                dt.Columns.Add("Total_NG_Frame");
                dt.Columns.Add("Total_NG_Gear");
                dt.Columns.Add("Total_NG_Motor");
                dt.Columns.Add("OUTPUT");
                dt.Columns.Add("RateNG_Frame");
                dt.Columns.Add("RateNG_Gear");
                dt.Columns.Add("RateNG_Motor");
                dt.Columns.Add("MC_THUCHK");
                dt.Columns.Add("MC_NOICHK");
                foreach (var a in distinctProcess)
                {
                    dt.Columns.Add(a.ToString());
                }

                var distinctTime = (from row in listvo.dt.AsEnumerable() orderby row["times"] select row.Field<string>("times")).Distinct();
                foreach (var times in distinctTime)
                {
                    if (listvo.dt.Rows.Count > 0)
                    {
                        var info = (from row in listvo.dt.AsEnumerable() where row.Field<string>("times") == times.ToString() select row).ToList();

                        var inspectdata = (from row in listvo.dt.AsEnumerable() where row.Field<string>("times") == times.ToString() select row).ToList();

                        DataRow dr = dt.NewRow();

                        dr[0] = info[0]["model"].ToString();
                        dr[1] = info[0]["line"].ToString();
                        dr[2] = info[0]["times"].ToString();
                        int j = 0;
                        for (int i = 0; i < dt.Columns.Count - 11; i++)
                        {
                            if (j < inspectdata.Count)
                            {
                                if (dt.Columns[i + 11].ColumnName == inspectdata[j]["process"].ToString())
                                {
                                    dr[i + 11] = inspectdata[j]["inspectdata"].ToString();
                                    j++;
                                }
                                else
                                {
                                    dr[i + 11] = "0";
                                }
                            }
                            else dr[i + 11] = "0";
                        }
                        dt.Rows.Add(dr);
                    }
                }

                //sum hang cuoi
                DataRow dr1 = dt.NewRow();
                for (int i = 11; i < dt.Columns.Count; i++)
                {
                    double sum = 0;
                    for (int j = 0; j < dt.Rows.Count; j++)
                    {
                        sum += double.Parse(dt.Rows[j][i].ToString());
                        dr1[i] = sum;
                    }
                }
                dt.Rows.Add(dr1);

                dgv.DataSource = dt;
                //int t = 0;
                for (int i = 0; i < dgv.RowCount - 1; i++)
                {
                    double totalNGFrame = 0;
                    double rateNGFrame = 0;
                    double totalNGGear = 0;
                    double rateNGGear = 0;
                    double totalNGMoTor = 0;
                    double rateNGMotor = 0;
                    double outputRow = 0;
                    for (int t = 0; t < outputvo.dt.Rows.Count; t++)//insert output motor tu mesdb
                    {
                        if (dgv.Rows[i].Cells["Date"].Value.ToString() == outputvo.dt.Rows[t]["times"].ToString())
                        {
                            outputRow = double.Parse(outputFinalvo.dt.Rows[t]["count"].ToString());
                            dgv.Rows[i].Cells["OUTPUT"].Value = outputRow;
                        }
                    }
                    for (int t = 0; t < ngThurstVo.dt.Rows.Count; t++)//insert ngThurst tu mesdb
                    {
                        if (dgv.Rows[i].Cells["Date"].Value.ToString() == ngThurstVo.dt.Rows[t]["times"].ToString())
                        {
                            outputRow = double.Parse(ngThurstVo.dt.Rows[t]["count"].ToString());
                            dgv.Rows[i].Cells["MC_THUCHK"].Value = outputRow;
                        }
                    }
                    for (int t = 0; t < ngNOICHKVo.dt.Rows.Count; t++)//insert ngNOICHK tu mesdb
                    {
                        if (dgv.Rows[i].Cells["Date"].Value.ToString() == ngNOICHKVo.dt.Rows[t]["times"].ToString())
                        {
                            outputRow = double.Parse(ngNOICHKVo.dt.Rows[t]["count"].ToString());
                            dgv.Rows[i].Cells["MC_NOICHK"].Value = outputRow;
                        }
                    }
                    for (int j = 0; j < dgv.ColumnCount; j++)
                    {
                        if (dgv.Columns[j].HeaderText != "FA_IP" && dgv.Columns[j].HeaderText != "FA_OP" && dgv.Columns[j].HeaderText != "GC_IP" && dgv.Columns[j].HeaderText != "GC_OP" && dgv.Columns[j].HeaderText != "MC_IP" && dgv.Columns[j].HeaderText != "OUTPUT")
                        {
                            if (dgv.Columns[j].HeaderText == "FA_APP" || dgv.Columns[j].HeaderText == "FA_BallB" || dgv.Columns[j].HeaderText == "FA_Caulk")
                            { totalNGFrame += double.Parse(dgv[j, i].Value.ToString()); }

                            if (dgv.Columns[j].HeaderText == "GC_Bear" || dgv.Columns[j].HeaderText == "GC_C" || dgv.Columns[j].HeaderText == "GC_FGASS"
                                || dgv.Columns[j].HeaderText == "GC_FGCHK" || dgv.Columns[j].HeaderText == "GC_OSW" || dgv.Columns[j].HeaderText == "GC_PD" || dgv.Columns[j].HeaderText == "GC_PU")
                            { totalNGGear += double.Parse(dgv[j, i].Value.ToString()); }

                            if (dgv.Columns[j].HeaderText == "MC_FWCHK" || dgv.Columns[j].HeaderText == "MC_STMASS" || dgv.Columns[j].HeaderText == "MC_FPC"
                                || dgv.Columns[j].HeaderText == "MC_Mark" || dgv.Columns[j].HeaderText == "MC_THUCHK" || dgv.Columns[j].HeaderText == "MC_NOICHK" || dgv.Columns[j].HeaderText == "MC_APPCHK")
                            { totalNGMoTor += double.Parse(dgv[j, i].Value.ToString()); }
                        }
                    }
                    double outputFrame = 0;
                    double outputGear = 0;
                    double outputMotor = 0;
                    if (dgv.Columns.Contains("FA_OP")) { outputFrame = double.Parse(dgv.Rows[i].Cells["FA_OP"].Value.ToString()); }
                    if (dgv.Columns.Contains("GC_OP")) { outputGear = double.Parse(dgv.Rows[i].Cells["GC_OP"].Value.ToString()); }
                    if (dgv.Columns.Contains("OUTPUT")) { outputMotor = double.Parse(dgv.Rows[i].Cells["OUTPUT"].Value.ToString()); }

                    if (outputFrame == 0) { rateNGFrame = 0; } else rateNGFrame = Math.Round((totalNGFrame / outputFrame) * 100, 3);
                    if (outputGear == 0) { rateNGGear = 0; } else rateNGGear = Math.Round((totalNGGear / outputGear) * 100, 3);
                    if (outputMotor == 0) { rateNGMotor = 0; } else rateNGMotor = Math.Round((totalNGMoTor / outputMotor) * 100, 3);

                    dgv["RateNG_Frame", i].Value = rateNGFrame;
                    dgv["Total_NG_Frame", i].Value = totalNGFrame;
                    dgv["RateNG_Gear", i].Value = rateNGGear;
                    dgv["Total_NG_Gear", i].Value = totalNGGear;
                    dgv["RateNG_Motor", i].Value = rateNGMotor;
                    dgv["Total_NG_Motor", i].Value = totalNGMoTor;
                }
                double sumThurst = 0;
                double sumNoichk = 0;
                for (int j = 0; j < dt.Rows.Count; j++)
                {
                    if (j < dt.Rows.Count - 1)
                    {
                        sumThurst += double.Parse(dgv.Rows[j].Cells["MC_THUCHK"].Value.ToString());
                        sumNoichk += double.Parse(dgv.Rows[j].Cells["MC_NOICHK"].Value.ToString());
                    }
                    else if (j == dt.Rows.Count - 1)
                    {
                        dgv.Rows[j].Cells["MC_THUCHK"].Value = sumThurst;
                        dgv.Rows[j].Cells["MC_NOICHK"].Value = sumNoichk;
                    }
                }
            }
            catch (Framework.ApplicationException exception)
            {
                popUpMessage.ApplicationError(exception.GetMessageData(), Text);
                logger.Error(exception.GetMessageData());
            }
        }
        //private void GridBind()
        //{
        //    tablename = cmb_model.Text + DateTime.Now.ToString("yyyyMM");
        //    try
        //    {
        //        ProductionControllerGA1Vo dgvVo = new ProductionControllerGA1Vo()
        //        {
        //            TableName = tablename,
        //            ModelCode = cmb_model.Text,
        //            LineCode = cmb_line.Text,
        //            ProcessCode = cmb_process.Text,
        //            ItemCode = cmb_item.Text,
        //            DateFrom = DateTime.Parse(dtp_from.Text),
        //            DateTo = DateTime.Parse(dtp_to.Text),
        //            grDate = false,
        //        };

        //        ProductionControllerGA1Vo listvo = (ProductionControllerGA1Vo)DefaultCbmInvoker.Invoke(new Cbm.SearchProductionINPUTCbm(), dgvVo, connection);
        //        ProductionControllerGA1Vo outputvo = (ProductionControllerGA1Vo)DefaultCbmInvoker.Invoke(new Cbm.SearchProductionOUTPUTCbm(), dgvVo, connectionmes);
        //        var distinctProcess = (from row in listvo.dt.AsEnumerable() orderby row["process"] select row.Field<string>("process")).Distinct();
        //        DataTable dt = new DataTable();
        //        dt.Columns.Add("Model");
        //        dt.Columns.Add("Line");
        //        dt.Columns.Add("Star");
        //        dt.Columns.Add("End");
        //        dt.Columns.Add("Total_NG");
        //        dt.Columns.Add("OUTPUT");
        //        foreach (var a in distinctProcess)
        //        {
        //            dt.Columns.Add(a.ToString());
        //        }

        //        //var distinctId = (from row in listvo.dt.AsEnumerable() select row.Field<int>("id")).Distinct();
        //        //foreach (var serno in distinctId)
        //        if (listvo.dt.Rows.Count > 0)
        //        {
        //            //var infoSerno = (from row in listvo.dt.AsEnumerable() where row.Field<int>("id") == int.Parse(serno.ToString()) select row).ToList();

        //            var inspectdata = (from row in listvo.dt.AsEnumerable() orderby row["process"] select row).ToList();

        //            DataRow dr = dt.NewRow();

        //            dr[0] = listvo.dt.Rows[0]["model"].ToString();
        //            dr[1] = listvo.dt.Rows[0]["line"].ToString();
        //            dr[2] = dtp_from.Text;
        //            dr[3] = dtp_to.Text;
        //            int j = 0;
        //            for (int i = 0; i < dt.Columns.Count - 6; i++)
        //            {
        //                //dr[5] = outputvo.dt.Rows[0][1].ToString();
        //                if (j < inspectdata.Count)
        //                {
        //                    if (dt.Columns[i + 6].ColumnName == inspectdata[j]["process"].ToString())
        //                    {
        //                        dr[i + 6] = inspectdata[j]["inspectdata"].ToString();
        //                        j++;
        //                    }
        //                    else
        //                    {
        //                        dr[i + 6] = "0";
        //                    }
        //                }
        //            }
        //            dt.Rows.Add(dr);
        //        }
        //        dgv.DataSource = dt;
        //        for (int i = 0; i < dgv.RowCount; i++)
        //        {
        //            double a = 0;
        //            dgv.Rows[i].Cells["OUTPUT"].Value = outputvo.dt.Rows[0]["output"].ToString();
        //            for (int j = 6; j < dgv.ColumnCount; j++)
        //            {
        //                string b = dgv[j, i].Value.ToString();
        //                if (dgv.Columns[j].HeaderText != "INPUT" && dgv.Columns[j].HeaderText != "OUTPUT")
        //                {
        //                    if (dgv[j, i].Value.ToString() != "")
        //                    {
        //                        a += double.Parse(dgv[j, i].Value.ToString());
        //                    }
        //                }
        //            }
        //            dgv[4, i].Value = a;
        //        }
        //    }
        //    catch (Framework.ApplicationException exception)
        //    {
        //        popUpMessage.ApplicationError(exception.GetMessageData(), Text);
        //        logger.Error(exception.GetMessageData());
        //    }
        //}
        //private void GridBindByDate()
        //{
        //    tablename = cmb_model.Text + DateTime.Now.ToString("yyyyMM");
        //    try
        //    {
        //        ProductionControllerGA1Vo dgvVo = new ProductionControllerGA1Vo()
        //        {
        //            TableName = tablename,
        //            ModelCode = cmb_model.Text,
        //            LineCode = cmb_line.Text,
        //            ProcessCode = cmb_process.Text,
        //            ItemCode = cmb_item.Text,
        //            DateFrom = DateTime.Parse(dtp_from.Text),
        //            DateTo = DateTime.Parse(dtp_to.Text),
        //            grDate = true,
        //        };

        //        ProductionControllerGA1Vo listvo = (ProductionControllerGA1Vo)DefaultCbmInvoker.Invoke(new Cbm.SearchProductionInputByDateCbm(), dgvVo, connection);
        //        ProductionControllerGA1Vo outputvo = (ProductionControllerGA1Vo)DefaultCbmInvoker.Invoke(new Cbm.SearchProductionOUTPUTCbm(), dgvVo, connectionmes);
        //        var distinctProcess = (from row in listvo.dt.AsEnumerable() orderby row["process"] select row.Field<string>("process")).Distinct();
        //        DataTable dt = new DataTable();
        //        dt.Columns.Add("Model");
        //        dt.Columns.Add("Line");
        //        dt.Columns.Add("Date");
        //        dt.Columns.Add("Total_NG");
        //        dt.Columns.Add("OUTPUT");
        //        foreach (var a in distinctProcess)
        //        {
        //            dt.Columns.Add(a.ToString());
        //        }

        //        var distinctId = (from row in listvo.dt.AsEnumerable() select row.Field<DateTime>("dates")).Distinct();
        //        foreach (var serno in distinctId)
        //        {
        //            var infoSerno = (from row in listvo.dt.AsEnumerable() where row.Field<DateTime>("dates") == DateTime.Parse(serno.ToString()) select row).ToList();

        //            var inspectdata = (from row in listvo.dt.AsEnumerable() orderby row["process"] where row.Field<DateTime>("dates") == DateTime.Parse(serno.ToString()) select row).ToList();

        //            DataRow dr = dt.NewRow();

        //            dr[0] = infoSerno[0]["model"].ToString();
        //            dr[1] = infoSerno[0]["line"].ToString();
        //            dr[2] = DateTime.Parse(infoSerno[0]["dates"].ToString()).ToShortDateString();
        //            int j = 0;
        //            for (int i = 0; i < dt.Columns.Count - 5; i++)
        //            {
        //                if (j < inspectdata.Count)
        //                {
        //                    if (dt.Columns[i + 5].ColumnName == inspectdata[j]["process"].ToString())
        //                    {
        //                        dr[i + 5] = inspectdata[j]["inspectdata"].ToString();
        //                        j++;
        //                    }
        //                    else
        //                    {
        //                        dr[i + 5] = "0";
        //                    }
        //                }
        //            }
        //            dt.Rows.Add(dr);
        //        }
        //        dgv.DataSource = dt;
        //        int k = 0;
        //        for (int i = 0; i < dgv_main.RowCount; i++)
        //        {
        //            if (dgv_main.Rows[i].Cells["Date"].Value.ToString() == DateTime.Parse(outputvo.dt.Rows[k]["datetimes"].ToString()).ToShortDateString())
        //            {
        //                dgv_main.Rows[i].Cells["OUTPUT"].Value = outputvo.dt.Rows[k]["output"].ToString();
        //                k++;
        //            }
        //            double a = 0;
        //            for (int j = 5; j < dgv_main.ColumnCount; j++)
        //            {
        //                string b = dgv_main[j, i].Value.ToString();
        //                if (dgv_main.Columns[j].HeaderText != "INPUT" && dgv_main.Columns[j].HeaderText != "OUTPUT")
        //                {
        //                    if (dgv_main[j, i].Value.ToString() != "")
        //                    {
        //                        a += double.Parse(dgv_main[j, i].Value.ToString());
        //                    }
        //                }
        //            }
        //            dgv_main[3, i].Value = a;
        //        }
        //    }
        //    catch (Framework.ApplicationException exception)
        //    {
        //        popUpMessage.ApplicationError(exception.GetMessageData(), Text);
        //        logger.Error(exception.GetMessageData());
        //    }
        //}
        private void GridBindProcess()
        {
            tablename = cmb_model.Text + DateTime.Now.ToString("yyyyMM");
            try
            {
                ProductionControllerGA1Vo dgvVo = new ProductionControllerGA1Vo()
                {
                    TableName = tablename,
                    ModelCode = cmb_model.Text,
                    LineCode = cmb_line.Text,
                    ProcessCode = cmb_process.Text,
                    ItemCode = cmb_item.Text,
                    DateFrom = DateTime.Parse(dtp_from.Text),
                    DateTo = DateTime.Parse(dtp_to.Text)
                };

                ProductionControllerGA1Vo listvo = (ProductionControllerGA1Vo)DefaultCbmInvoker.Invoke(new SearchProductionProcessCbm(), dgvVo, connection);
                var distinctProcess = (from row in listvo.dt.AsEnumerable() orderby row["inspect"] select row.Field<string>("inspect")).Distinct();
                DataTable dt = new DataTable();
                dt.Columns.Add("Model");
                dt.Columns.Add("Line");
                dt.Columns.Add("Process");
                dt.Columns.Add("Total_NG");
                foreach (var a in distinctProcess)
                {
                    dt.Columns.Add(a.ToString());
                }

                var infoSerno = (from row in listvo.dt.AsEnumerable() select row).ToList();

                var inspectdata = (from row in listvo.dt.AsEnumerable() orderby row["inspect"] select row.Field<double>("inspectdata")).ToList();

                DataRow dr = dt.NewRow();

                if (inspectdata.Count > 0)
                {
                    dr[0] = infoSerno[0]["model"].ToString();
                    dr[1] = infoSerno[0]["line"].ToString();
                    dr[2] = infoSerno[0]["process"].ToString();
                }

                for (int i = 0; i < inspectdata.Count; i++)
                {
                    dr[i + 4] = inspectdata[i];
                }
                dt.Rows.Add(dr);
                dgv.DataSource = dt;
                for (int i = 0; i < dgv.RowCount; i++)
                {
                    double a = 0;
                    for (int j = 4; j < dgv.ColumnCount; j++)
                    {
                        a += double.Parse(dgv[j, i].Value.ToString());
                    }
                    dgv[3, i].Value = a;
                }
            }
            catch (Framework.ApplicationException exception)
            {
                popUpMessage.ApplicationError(exception.GetMessageData(), Text);
                logger.Error(exception.GetMessageData());
            }
        }

        private void search_cmb_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            funtion();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label55_Click(object sender, EventArgs e)
        {

        }
        public void ResetLabel(Control Parent)
        {
            foreach (Control item in Parent.Controls)
            {
                int a = 0;
                if (item is Label && int.TryParse((item as Label).Text, out a))
                {
                    (item as Label).Text = "0";
                }
            }
        }
        private void btnSearchData_Click(object sender, EventArgs e)
        {
            dgvRate.Rows.Clear();

            funtion();
            dgvRate.Sort(dgvRate.Columns["colrate"], ListSortDirection.Descending);
            //ve chart
            GridBind();
            showchartLine("FA_IP", "FA_OP", "RateNG_Frame", "Total_NG_Frame", chr_main, lblInputFrame, lblOutputFrame, lblTotalNGFrame); // frame
            showchartLine("GC_IP", "GC_OP", "RateNG_Gear", "Total_NG_Gear", chartGear, lblInputGear, lblOutputGear, lblTotalNGGear); // gear 
            showchartLine("MC_IP", "OUTPUT", "RateNG_Motor", "Total_NG_Motor", chartMotor, lblInputMotor, lblOutputMotor, lblTotalNGMotor); // motor
            alarmNG();
            showchartProcess();
            //end chart
        }

        private string GridBindNew(string ProcessName_)
        {
            try
            {
                tablename = cmb_model.Text + DateTime.Now.ToString("yyyyMM");
                ValueObjectList<ProductionControllerGA1Vo> inspecdata = (ValueObjectList<ProductionControllerGA1Vo>)DefaultCbmInvoker.Invoke(new SearchProductionGA1Cbm(), new ProductionControllerGA1Vo { ModelCode = cmb_model.Text, LineCode = cmb_line.Text, TableName = tablename, DateFrom = dtp_dateFromdata.Value, DateTo = dtp_dateTodata.Value, ProcessName = ProcessName_ }, connection);
                if (inspecdata.GetList()[0].InspecData != "")
                {
                    return inspecdata.GetList()[0].InspecData;
                }
                else return "0";
            }
            catch (Framework.ApplicationException exception)
            {
                popUpMessage.ApplicationError(exception.GetMessageData(), Text);
                logger.Error(exception.GetMessageData());
                return "0";
            }
        }
        private void funtion()
        {
            try
            {
                ResetLabel(tblFrame); ResetLabel(tblGear); ResetLabel(tblMotor);

                tablename = cmb_model.Text + DateTime.Now.ToString("yyyyMM");
                ValueObjectList<ProductionControllerGA1Vo> processVo = (ValueObjectList<ProductionControllerGA1Vo>)DefaultCbmInvoker.Invoke(new SearchProductionGA1Cbm(), new ProductionControllerGA1Vo { ModelCode = cmb_model.Text, LineCode = cmb_line.Text, TableName = tablename, DateFrom = dtp_dateFromdata.Value, DateTo = dtp_dateTodata.Value, }, connection);

                for (int i = 0; i < processVo.GetList().Count; i++)
                {
                    //FRAME ASSY
                    if (processVo.GetList()[i].ProcessName == "FA_IP") { lblInput1.Text = processVo.GetList()[i].InspecData; }
                    if (processVo.GetList()[i].ProcessName == "FA_OP") { lblOutput1.Text = processVo.GetList()[i].InspecData; }
                    if (processVo.GetList()[i].ProcessName == "FA_BallB") { lblF1.Text = processVo.GetList()[i].InspecData; }
                    if (processVo.GetList()[i].ProcessName == "FA_Caulk") { lblF2.Text = processVo.GetList()[i].InspecData; }
                    if (processVo.GetList()[i].ProcessName == "FA_APP") { lblF3.Text = processVo.GetList()[i].InspecData; }
                    //GEAR CASE ASSY
                    if (processVo.GetList()[i].ProcessName == "GC_IP") { lblInput2.Text = processVo.GetList()[i].InspecData; }
                    if (processVo.GetList()[i].ProcessName == "GC_OP") { lblOutput2.Text = processVo.GetList()[i].InspecData; }
                    if (processVo.GetList()[i].ProcessName == "GC_Bear") { lblG1.Text = processVo.GetList()[i].InspecData; }
                    if (processVo.GetList()[i].ProcessName == "GC_OSW") { lblG2.Text = processVo.GetList()[i].InspecData; }
                    if (processVo.GetList()[i].ProcessName == "GC_PD") { lblG3.Text = processVo.GetList()[i].InspecData; }
                    if (processVo.GetList()[i].ProcessName == "GC_C") { lblG4.Text = processVo.GetList()[i].InspecData; }
                    if (processVo.GetList()[i].ProcessName == "GC_PU") { lblG5.Text = processVo.GetList()[i].InspecData; }
                    if (processVo.GetList()[i].ProcessName == "GC_FGASS") { lblG6.Text = processVo.GetList()[i].InspecData; }
                    if (processVo.GetList()[i].ProcessName == "GC_FGCHK") { lblG7.Text = processVo.GetList()[i].InspecData; }
                    //MOTOR ASSY
                    if (processVo.GetList()[i].ProcessName == "MC_IP") { lblInput3.Text = processVo.GetList()[i].InspecData; }
                    if (processVo.GetList()[i].ProcessName == "MC_FWCHK") { lblM1.Text = processVo.GetList()[i].InspecData; }
                    if (processVo.GetList()[i].ProcessName == "MC_STMASS") { lblM2.Text = processVo.GetList()[i].InspecData; }
                    if (processVo.GetList()[i].ProcessName == "MC_FPC") { lblM3.Text = processVo.GetList()[i].InspecData; }
                    if (processVo.GetList()[i].ProcessName == "MC_Mark") { lblM4.Text = processVo.GetList()[i].InspecData; }
                    if (processVo.GetList()[i].ProcessName == "MC_APPCHK") { lblM7.Text = processVo.GetList()[i].InspecData; }
                }

                lblOutputThurst.Text = GridBindOutputMotor(true);//lay output thurst tu mesdb
                lblM5.Text = GridBindOutputMotor(false);//lay hang arging tu mesdb
                lblNGThurst.Text = GridBindNGThurst();//lay ng thurst tu mesdb
                lblM6.Text = GridBindNG_NOICHK(false); //lay ng noise tu mesdb

                lblNg1.Text = (int.Parse(lblF1.Text) + int.Parse(lblF2.Text) + int.Parse(lblF3.Text)).ToString();//total NG Frame
                if (lblOutput1.Text == "0")
                {
                    lbl_NGRateFrame.Visible = false;
                    lblNGRateF1.Visible = false;
                    lblNGRateF2.Visible = false;
                    lblNGRateF3.Visible = false;
                    lblYF.Visible = false;
                }
                else
                {
                    lbl_NGRateFrame.Visible = true;
                    lblNGRateF1.Visible = true;
                    lblNGRateF2.Visible = true;
                    lblNGRateF3.Visible = true;
                    lblYF.Visible = true;
                }
                lblNGRateF1.Text = NGRate(double.Parse(lblF1.Text), double.Parse(lblNg1.Text), double.Parse(lblOutput1.Text), lblBall.Text);
                lblNGRateF2.Text = NGRate(double.Parse(lblF2.Text), double.Parse(lblNg1.Text), double.Parse(lblOutput1.Text), lblFrame.Text);
                lblNGRateF3.Text = NGRate(double.Parse(lblF3.Text), double.Parse(lblNg1.Text), double.Parse(lblOutput1.Text), lblApearance.Text);
                lbl_NGRateFrame.Text = NGRate(double.Parse(lblNg1.Text), double.Parse(lblNg1.Text), double.Parse(lblOutput1.Text), "NA");
                lblYF.Text = Yield(double.Parse(lblNg1.Text), double.Parse(lblOutput1.Text));

                lblNG2.Text = (int.Parse(lblG1.Text) + int.Parse(lblG2.Text) + int.Parse(lblG3.Text) + int.Parse(lblG4.Text) + int.Parse(lblG5.Text) + int.Parse(lblG6.Text) + int.Parse(lblG7.Text)).ToString();
                if (lblOutput2.Text == "0")
                {
                    lbl_NGRateGear.Visible = false;
                    lblNGRateG1.Visible = false;
                    lblNGRateG2.Visible = false;
                    lblNGRateG3.Visible = false;
                    lblNGRateG4.Visible = false;
                    lblNGRateG5.Visible = false;
                    lblNGRateG6.Visible = false;
                    lblNGRateG7.Visible = false;
                    lblYG.Visible = false;
                }
                else
                {
                    lbl_NGRateGear.Visible = true;
                    lblNGRateG1.Visible = true;
                    lblNGRateG2.Visible = true;
                    lblNGRateG3.Visible = true;
                    lblNGRateG4.Visible = true;
                    lblNGRateG5.Visible = true;
                    lblNGRateG6.Visible = true;
                    lblNGRateG7.Visible = true;
                    lblYG.Visible = true;
                }

                lblNGRateG1.Text = NGRate(double.Parse(lblG1.Text), double.Parse(lblNG2.Text), double.Parse(lblOutput2.Text), "Gear Case & Bearing");
                lblNGRateG2.Text = NGRate(double.Parse(lblG2.Text), double.Parse(lblNG2.Text), double.Parse(lblOutput2.Text), "OutputShaft");
                lblNGRateG3.Text = NGRate(double.Parse(lblG3.Text), double.Parse(lblNG2.Text), double.Parse(lblOutput2.Text), "P Gear Down");
                lblNGRateG4.Text = NGRate(double.Parse(lblG4.Text), double.Parse(lblNG2.Text), double.Parse(lblOutput2.Text), "C Gear");
                lblNGRateG5.Text = NGRate(double.Parse(lblG5.Text), double.Parse(lblNG2.Text), double.Parse(lblOutput2.Text), "P Gear Up");
                lblNGRateG6.Text = NGRate(double.Parse(lblG6.Text), double.Parse(lblNG2.Text), double.Parse(lblOutput2.Text), "Pinion & Flange");
                lblNGRateG7.Text = NGRate(double.Parse(lblG7.Text), double.Parse(lblNG2.Text), double.Parse(lblOutput2.Text), "Pinion Flange + App");

                lbl_NGRateGear.Text = NGRate(double.Parse(lblNG2.Text), double.Parse(lblNG2.Text), double.Parse(lblOutput2.Text), "NA");
                lblYG.Text = Yield(double.Parse(lblNG2.Text), double.Parse(lblOutput2.Text));

                lblNG3.Text = (int.Parse(lblM1.Text) + int.Parse(lblM2.Text) + int.Parse(lblM3.Text) + int.Parse(lblM4.Text) + int.Parse(lblNGThurst.Text) + int.Parse(lblM6.Text) + int.Parse(lblM7.Text)).ToString();

                //TOTAL
                lblTotalNoiModel.Text = OutputFinal(""); //lay tong ng noise tu mesdb
                lblTotalNoiLine.Text = GridBindQtyNOICHK(true);//lay ng noise theo line tu mesdb

                lblOutput3.Text = OutputFinal(cmb_line.Text);

                if (lblOutput3.Text == "0")
                {
                    lbl_NGRateMotor.Visible = false;
                    lblNGRateM1.Visible = false;
                    lblNGRateM2.Visible = false;
                    lblNGRateM3.Visible = false;
                    lblNGRateM4.Visible = false;
                    lblNGRateM5.Visible = false;
                    lblNGRateM6.Visible = false;
                    lblNGRateM7.Visible = false;
                    lblYM.Visible = false;
                }
                else
                {
                    lbl_NGRateMotor.Visible = true;
                    lblNGRateM1.Visible = true;
                    lblNGRateM2.Visible = true;
                    lblNGRateM3.Visible = true;
                    lblNGRateM4.Visible = true;
                    lblNGRateM5.Visible = true;
                    lblNGRateM6.Visible = true;
                    lblNGRateM7.Visible = true;
                    lblYM.Visible = true;
                }

                lblNGRateM1.Text = NGRate(double.Parse(lblM1.Text), double.Parse(lblNG3.Text), double.Parse(lblOutput3.Text), "Gear Case + Frame");
                lblNGRateM2.Text = NGRate(double.Parse(lblM2.Text), double.Parse(lblNG3.Text), double.Parse(lblOutput3.Text), "STM");
                lblNGRateM3.Text = NGRate(double.Parse(lblM3.Text), double.Parse(lblNG3.Text), double.Parse(lblOutput3.Text), "FPC");
                lblNGRateM4.Text = NGRate(double.Parse(lblM4.Text), double.Parse(lblNG3.Text), double.Parse(lblOutput3.Text), "Hand Aging");
                lblNGRateM5.Text = NGRate(double.Parse(lblNGThurst.Text), double.Parse(lblNG3.Text), double.Parse(lblOutput3.Text), "Thurst");
                lblNGRateM6.Text = NGRate(double.Parse(lblM6.Text), double.Parse(lblNG3.Text), double.Parse(lblOutput3.Text), "Noise");
                lblNGRateM7.Text = NGRate(double.Parse(lblM7.Text), double.Parse(lblNG3.Text), double.Parse(lblOutput3.Text), "Appearance");

                lbl_NGRateMotor.Text = NGRate(double.Parse(lblNG3.Text), double.Parse(lblNG3.Text), double.Parse(lblOutput3.Text), "NA");
                lblYM.Text = Yield(double.Parse(lblNG3.Text), double.Parse(lblOutput3.Text));
            }
            catch (Framework.ApplicationException exception)
            {
                popUpMessage.ApplicationError(exception.GetMessageData(), Text);
                logger.Error(exception.GetMessageData());
            }
        }
        //private void funtion()
        //{
        //    //FRAME ASSY
        //    lblInput1.Text = GridBindNew("FA_IP");
        //    lblOutput1.Text = GridBindNew("FA_OP");
        //    lblF1.Text = GridBindNew("FA_BallB");
        //    lblF2.Text = GridBindNew("FA_Caulk");
        //    lblF3.Text = GridBindNew("FA_APP");
        //    lblNg1.Text = (int.Parse(lblF1.Text) + int.Parse(lblF2.Text) + int.Parse(lblF3.Text)).ToString();//total NG Frame
        //    if (lblOutput1.Text == "0")
        //    {
        //        lbl_NGRateFrame.Visible = false;
        //        lblNGRateF1.Visible = false;
        //        lblNGRateF2.Visible = false;
        //        lblNGRateF3.Visible = false;
        //        lblYF.Visible = false;
        //    }
        //    else
        //    {
        //        lbl_NGRateFrame.Visible = true;
        //        lblNGRateF1.Visible = true;
        //        lblNGRateF2.Visible = true;
        //        lblNGRateF3.Visible = true;
        //        lblYF.Visible = true;
        //    }
        //    lblNGRateF1.Text = NGRate(double.Parse(lblF1.Text), double.Parse(lblOutput1.Text), lblBall.Text);
        //    lblNGRateF2.Text = NGRate(double.Parse(lblF2.Text), double.Parse(lblOutput1.Text), lblFrame.Text);
        //    lblNGRateF3.Text = NGRate(double.Parse(lblF3.Text), double.Parse(lblOutput1.Text), lblApearance.Text);
        //    lbl_NGRateFrame.Text = NGRate(double.Parse(lblNg1.Text), double.Parse(lblOutput1.Text), "NA");
        //    lblYF.Text = Yield(double.Parse(lblNg1.Text), double.Parse(lblOutput1.Text));

        //    //GEAR CASE ASSY
        //    lblInput2.Text = GridBindNew("GC_IP");
        //    lblOutput2.Text = GridBindNew("GC_OP");
        //    lblG1.Text = GridBindNew("GC_Bear");
        //    lblG2.Text = GridBindNew("GC_OSW");
        //    lblG3.Text = GridBindNew("GC_PD");
        //    lblG4.Text = GridBindNew("GC_C");
        //    lblG5.Text = GridBindNew("GC_PU");
        //    lblG6.Text = GridBindNew("GC_FGASS");
        //    lblG7.Text = GridBindNew("GC_FGCHK");
        //    lblNG2.Text = (int.Parse(lblG1.Text) + int.Parse(lblG2.Text) + int.Parse(lblG3.Text) + int.Parse(lblG4.Text) + int.Parse(lblG5.Text) + int.Parse(lblG6.Text) + int.Parse(lblG7.Text)).ToString();
        //    if (lblOutput2.Text == "0")
        //    {
        //        lbl_NGRateGear.Visible = false;
        //        lblNGRateG1.Visible = false;
        //        lblNGRateG2.Visible = false;
        //        lblNGRateG3.Visible = false;
        //        lblNGRateG4.Visible = false;
        //        lblNGRateG5.Visible = false;
        //        lblNGRateG6.Visible = false;
        //        lblNGRateG7.Visible = false;
        //        lblYG.Visible = false;
        //    }
        //    else
        //    {
        //        lbl_NGRateGear.Visible = true;
        //        lblNGRateG1.Visible = true;
        //        lblNGRateG2.Visible = true;
        //        lblNGRateG3.Visible = true;
        //        lblNGRateG4.Visible = true;
        //        lblNGRateG5.Visible = true;
        //        lblNGRateG6.Visible = true;
        //        lblNGRateG7.Visible = true;
        //        lblYG.Visible = true;
        //    }

        //    lblNGRateG1.Text = NGRate(double.Parse(lblG1.Text), double.Parse(lblOutput2.Text), "Gear Case & Bearing");
        //    lblNGRateG2.Text = NGRate(double.Parse(lblG2.Text), double.Parse(lblOutput2.Text), "OutputShaft");
        //    lblNGRateG3.Text = NGRate(double.Parse(lblG3.Text), double.Parse(lblOutput2.Text), "P Gear Down");
        //    lblNGRateG4.Text = NGRate(double.Parse(lblG3.Text), double.Parse(lblOutput2.Text), "C Gear");
        //    lblNGRateG5.Text = NGRate(double.Parse(lblG3.Text), double.Parse(lblOutput2.Text), "P Gear Up");
        //    lblNGRateG6.Text = NGRate(double.Parse(lblG3.Text), double.Parse(lblOutput2.Text), "Pinion & Flange");
        //    lblNGRateG7.Text = NGRate(double.Parse(lblG3.Text), double.Parse(lblOutput2.Text), "Pinion Flange + App");

        //    lbl_NGRateGear.Text = NGRate(double.Parse(lblNG2.Text), double.Parse(lblOutput2.Text), "NA");
        //    lblYG.Text = Yield(double.Parse(lblNG2.Text), double.Parse(lblOutput2.Text));

        //    //MOTOR ASSY
        //    lblInput3.Text = GridBindNew("MC_IP");
        //    lblOutputThurst.Text = GridBindOutputMotor(true);//lay output thurst tu mesdb
        //    lblM1.Text = GridBindNew("MC_FWCHK");
        //    lblM2.Text = GridBindNew("MC_STMASS");
        //    lblM3.Text = GridBindNew("MC_FPC");
        //    lblM4.Text = GridBindNew("MC_Mark");
        //    lblM5.Text = GridBindOutputMotor(false);//lay ng thurst tu mesdb
        //    lblNGThurst.Text = GridBindNGThurst();
        //    lblM6.Text = GridBindNG_NOICHK(false); //lay ng noise tu mesdb
        //    lblM7.Text = GridBindNew("MC_APPCHK");

        //    lblNG3.Text = (int.Parse(lblM1.Text) + int.Parse(lblM2.Text) + int.Parse(lblM3.Text) + int.Parse(lblM4.Text) + int.Parse(lblNGThurst.Text) + int.Parse(lblM6.Text) + int.Parse(lblM7.Text)).ToString();

        //    //TOTAL
        //    lblTotalNoiModel.Text = OutputFinal(""); //lay tong ng noise tu mesdb
        //    lblTotalNoiLine.Text = GridBindQtyNOICHK(true);//lay ng noise theo line tu mesdb

        //    lblOutput3.Text = OutputFinal(cmb_line.Text);

        //    if (lblOutput3.Text == "0")
        //    {
        //        lbl_NGRateMotor.Visible = false;
        //        lblNGRateM1.Visible = false;
        //        lblNGRateM2.Visible = false;
        //        lblNGRateM3.Visible = false;
        //        lblNGRateM4.Visible = false;
        //        lblNGRateM5.Visible = false;
        //        lblNGRateM6.Visible = false;
        //        lblNGRateM7.Visible = false;
        //        lblYM.Visible = false;
        //    }
        //    else
        //    {
        //        lbl_NGRateMotor.Visible = true;
        //        lblNGRateM1.Visible = true;
        //        lblNGRateM2.Visible = true;
        //        lblNGRateM3.Visible = true;
        //        lblNGRateM4.Visible = true;
        //        lblNGRateM5.Visible = true;
        //        lblNGRateM6.Visible = true;
        //        lblNGRateM7.Visible = true;
        //        lblYM.Visible = true;
        //    }

        //    lblNGRateM1.Text = NGRate(double.Parse(lblM1.Text), double.Parse(lblOutput3.Text), "Gear Case + Frame");
        //    lblNGRateM2.Text = NGRate(double.Parse(lblM2.Text), double.Parse(lblOutput3.Text), "STM");
        //    lblNGRateM3.Text = NGRate(double.Parse(lblM3.Text), double.Parse(lblOutput3.Text), "FPC");
        //    lblNGRateM4.Text = NGRate(double.Parse(lblM4.Text), double.Parse(lblOutput3.Text), "Hand Aging");
        //    lblNGRateM5.Text = NGRate(double.Parse(lblNGThurst.Text), double.Parse(lblOutput3.Text), "Thurst");
        //    lblNGRateM6.Text = NGRate(double.Parse(lblM6.Text), double.Parse(lblOutput3.Text), "Noise");
        //    lblNGRateM7.Text = NGRate(double.Parse(lblM7.Text), double.Parse(lblOutput3.Text), "Appearance");

        //    lbl_NGRateMotor.Text = NGRate(double.Parse(lblNG3.Text), double.Parse(lblOutput3.Text), "NA");
        //    lblYM.Text = Yield(double.Parse(lblNG3.Text), double.Parse(lblOutput3.Text));
        //}
        private string OutputFinal(string Line)
        {
            try
            {
                ValueObjectList<ProductionControllerGA1Vo> inspecdata = (ValueObjectList<ProductionControllerGA1Vo>)DefaultCbmInvoker.Invoke(new SearchOutputFinalCbm(), new ProductionControllerGA1Vo
                { ModelCode = cmb_model.Text, LineCode = Line, DateFrom = dtp_dateFromdata.Value, DateTo = dtp_dateTodata.Value, }, connectionmes);
                if (inspecdata.GetList()[0].InspecData != "")
                {
                    return inspecdata.GetList()[0].InspecData;
                }
                else return "0";
            }
            catch (Framework.ApplicationException exception)
            {
                popUpMessage.ApplicationError(exception.GetMessageData(), Text);
                logger.Error(exception.GetMessageData());
                return "0";
            }
        }
        private string GridBindOutputMotor(bool t)
        {
            try
            {
                tablename = cmb_model.Text + DateTime.Now.ToString("yyyyMM");
                ValueObjectList<ProductionControllerGA1Vo> inspecdata = (ValueObjectList<ProductionControllerGA1Vo>)DefaultCbmInvoker.Invoke(new SearchProductionoOutputMotorCbm(), new ProductionControllerGA1Vo { ModelCode = cmb_model.Text, LineCode = cmb_line.Text, TableName = tablename, DateFrom = dtp_dateFromdata.Value, DateTo = dtp_dateTodata.Value, change = t }, connectionmes);
                if (inspecdata.GetList()[0].InspecData != "")
                {
                    return inspecdata.GetList()[0].InspecData;
                }
                else return "0";
            }
            catch (Framework.ApplicationException exception)
            {
                popUpMessage.ApplicationError(exception.GetMessageData(), Text);
                logger.Error(exception.GetMessageData());
                return "0";
            }
        }
        private string GridBindNGThurst()//lay ng thúrst from mesdb
        {
            try
            {
                ValueObjectList<ProductionControllerGA1Vo> inspecdata = (ValueObjectList<ProductionControllerGA1Vo>)DefaultCbmInvoker.Invoke(new SearchProductionNGThurstCbm(), new ProductionControllerGA1Vo { ModelCode = cmb_model.Text, LineCode = cmb_line.Text, DateFrom = dtp_dateFromdata.Value, DateTo = dtp_dateTodata.Value }, connectionmes);
                if (inspecdata.GetList()[0].InspecData != "")
                {
                    return inspecdata.GetList()[0].InspecData;
                }
                else return "0";
            }
            catch (Framework.ApplicationException exception)
            {
                popUpMessage.ApplicationError(exception.GetMessageData(), Text);
                logger.Error(exception.GetMessageData());
                return "0";
            }
        }

        private void groupBox5_Enter(object sender, EventArgs e)
        {

        }

        private void cmb_line_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            try
            {
                lblLine.Text = cmb_line.Text;
                tablename = cmb_model.Text + DateTime.Now.ToString("yyyyMM");
                ValueObjectList<ProductionControllerGA1Vo> assetvoinvoice = (ValueObjectList<ProductionControllerGA1Vo>)DefaultCbmInvoker.Invoke(new GetProductionProcessCbm(), new ProductionControllerGA1Vo { ModelCode = cmb_model.Text, LineCode = cmb_line.Text, TableName = tablename }, connection);
                cmb_process.DisplayMember = "ProcessCode";
                cmb_process.DataSource = assetvoinvoice.GetList();
                cmb_process.Text = "";
                cmb_item.Text = "";
            }
            catch (Framework.ApplicationException exception)
            {
                popUpMessage.ApplicationError(exception.GetMessageData(), Text);
                logger.Error(exception.GetMessageData());
            }
        }

        private void cmb_model_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            callLine();
            cmb_process.Text = "";
            cmb_item.Text = "";
        }


        private void timerChart_Tick(object sender, EventArgs e)
        {
            GridBind();
            //dgv["RateNG_Frame", i].Value = rateNGFrame;
            //dgv["Total_NG_Frame", i].Value = totalNGFrame;
            //dgv["RateNG_Gear", i].Value = rateNGGear;
            //dgv["Total_NG_Gear", i].Value = totalNGGear;
            //dgv["RateNG_Motor", i].Value = rateNGMotor;
            //dgv["Total_NG_Motor", i].Value = totalNGMoTor;
            showchartLine("FA_IP", "FA_OP", "RateNG_Frame", "Total_NG_Frame", chr_main, lblInputFrame, lblOutputFrame, lblTotalNGFrame); // frame
            showchartLine("GC_IP", "GC_OP", "RateNG_Gear", "Total_NG_Gear", chartGear, lblInputGear, lblOutputGear, lblTotalNGGear); // gear 
            showchartLine("MC_IP", "OUTPUT", "RateNG_Motor", "Total_NG_Motor", chartMotor, lblInputMotor, lblOutputMotor, lblTotalNGMotor); // motor
            showchartProcess();
            alarmNG();
        }
        private void btn_search_Click(object sender, EventArgs e)
        {
            //GridBind();
            //showchartLine("FA_IP", "FA_OP", "RateNG_Frame", "Total_NG_Frame", chr_main, lblInputFrame, lblOutputFrame, lblTotalNGFrame); // frame
            //showchartLine("GC_IP", "GC_OP", "RateNG_Gear", "Total_NG_Gear", chartGear, lblInputGear, lblOutputGear, lblTotalNGGear); // gear 
            //showchartLine("MC_IP", "OUTPUT", "RateNG_Motor", "Total_NG_Motor", chartMotor, lblInputMotor, lblOutputMotor, lblTotalNGMotor); // motor
            //alarmNG();
            //showchartProcess();
        }
        public void alarmNG()
        {
            double rateNGFrame = 0;
            double rateNGGear = 0;
            double rateNGMotor = 0;
            double outputF = 0;
            double outputG = 0;
            double outputM = 0;
            double NGF = 0;
            double NGG = 0;
            double NGM = 0;
            double rateNGFrametxt = 0;
            double rateNGGeartxt = 0;
            double rateNGMotortxt = 0;
            if (double.TryParse(txtrateNGAlarmFrame.Text, out rateNGFrametxt)) { rateNGFrametxt = double.Parse(txtrateNGAlarmFrame.Text); }
            if (double.TryParse(txtrateNGAlarmGear.Text, out rateNGGeartxt)) { rateNGGeartxt = double.Parse(txtrateNGAlarmGear.Text); }
            if (double.TryParse(txtrateNGAlarmMotor.Text, out rateNGMotortxt)) { rateNGMotortxt = double.Parse(txtrateNGAlarmMotor.Text); }

            if (dgv.RowCount > 1)
            {
                //rateNGFrame = double.Parse(dgv.Rows[dgv.RowCount - 2].Cells["RateNG_Frame"].Value.ToString());
                //rateNGGear = double.Parse(dgv.Rows[dgv.RowCount - 2].Cells["RateNG_Gear"].Value.ToString());
                //rateNGMotor = double.Parse(dgv.Rows[dgv.RowCount - 2].Cells["RateNG_Motor"].Value.ToString());
                for (int i = 0; i < dgv.RowCount - 1; i++)
                {
                    NGF += double.Parse(dgv.Rows[i].Cells["Total_NG_Frame"].Value.ToString());
                    NGG += double.Parse(dgv.Rows[i].Cells["Total_NG_Gear"].Value.ToString());
                    NGM += double.Parse(dgv.Rows[i].Cells["Total_NG_Motor"].Value.ToString());

                    if (dgv.Columns.Contains("FA_OP"))
                        outputF += double.Parse(dgv.Rows[i].Cells["FA_OP"].Value.ToString());
                    if (dgv.Columns.Contains("GC_OP"))
                        outputG += double.Parse(dgv.Rows[i].Cells["GC_OP"].Value.ToString());
                    if (dgv.Columns.Contains("OUTPUT"))
                        outputM += double.Parse(dgv.Rows[i].Cells["OUTPUT"].Value.ToString());
                }
                if (outputF > 0 || NGF > 0) { rateNGFrame = ((NGF / (outputF + NGF)) * 100); }
                if (outputG > 0 || NGG > 0) { rateNGGear = ((NGG / (outputG + NGF)) * 100); }
                if (outputM > 0 || NGM > 0) { rateNGMotor = ((NGM / (outputM + NGM)) * 100); }
            }
            int a = 0;
            if (rateNGFrame > rateNGFrametxt || rateNGGear > rateNGGeartxt || rateNGMotor > rateNGMotortxt)//rateNG > rateNG text box => bao red
            {
                a = 1;
                led("5", "2", "7");
            }
            else if ((((rateNGFrame >= rateNGFrametxt * (0.7)) && rateNGFrame <= rateNGFrametxt) || ((rateNGGear >= rateNGGeartxt * (0.7)) && rateNGGear <= rateNGGeartxt) || ((rateNGMotor >= rateNGMotortxt * (0.7)) && rateNGMotor <= rateNGMotortxt)) && a == 0)//bao vang
            {
                a = 2;
                led("5", "6", "3");
            }
            else
            {
                a = 3;
                led("1", "6", "7");
            }
            if (rateNGFrame >= 0 && (rateNGFrame < rateNGFrametxt * (0.7))) { grbFrame.BackColor = Color.LightGreen; lblAlarmFrame.Visible = false; }
            else lblAlarmFrame.Visible = true;
            if (rateNGGear >= 0 && (rateNGGear < rateNGGeartxt * (0.7))) { grbGear.BackColor = Color.LightGreen; lblAlarmGear.Visible = false; }
            else lblAlarmGear.Visible = true;
            if (rateNGMotor >= 0 && (rateNGMotor < rateNGMotortxt * (0.7))) { grbMotor.BackColor = Color.LightGreen; lblAlarmMotor.Visible = false; }
            else lblAlarmMotor.Visible = true;

            if (rateNGFrame > rateNGFrametxt) { grbFrame.BackColor = Color.Red; lblAlarmFrame.BackColor = Color.Red; }
            if (rateNGGear > rateNGGeartxt) { grbGear.BackColor = Color.Red; lblAlarmGear.BackColor = Color.Red; }
            if (rateNGMotor > rateNGMotortxt) { grbMotor.BackColor = Color.Red; lblAlarmMotor.BackColor = Color.Red; }
            if ((rateNGFrame >= rateNGFrametxt * (0.7)) && rateNGFrame <= rateNGFrametxt) { grbFrame.BackColor = Color.Yellow; lblAlarmFrame.BackColor = Color.Yellow; }
            if ((rateNGGear >= rateNGGeartxt * (0.7)) && rateNGGear <= rateNGGeartxt) { grbGear.BackColor = Color.Yellow; lblAlarmGear.BackColor = Color.Yellow; }
            if ((rateNGMotor >= rateNGMotortxt * (0.7)) && rateNGMotor <= rateNGMotortxt) { grbMotor.BackColor = Color.Yellow; lblAlarmMotor.BackColor = Color.Yellow; }
        }
        public void led(string green, string red, string yellow)
        {
            if (cmbSeriport.Text != "")
            {
                serialCom.Write(green);//1on 5off
                serialCom.Write(red);//2on 6off
                serialCom.Write(yellow);//3on 7off
            }
        }
        private void btnRunChart_Click(object sender, EventArgs e)
        {
            grbSearchChart.Visible = false;
            tblLayoutChart.Dock = DockStyle.Fill;
            chbViChart.Text = "Online";
            chbViChart.Checked = false;

            timerChart.Interval = int.Parse(txtTimerChart.Text);
            btnRunChart.Enabled = false;
            btnStop.Enabled = true;
            timerChart.Enabled = true;
            GridBind();
            showchartLine("FA_IP", "FA_OP", "RateNG_Frame", "Total_NG_Frame", chr_main, lblInputFrame, lblOutputFrame, lblTotalNGFrame); // frame
            showchartLine("GC_IP", "GC_OP", "RateNG_Gear", "Total_NG_Gear", chartGear, lblInputGear, lblOutputGear, lblTotalNGGear); // gear 
            showchartLine("MC_IP", "OUTPUT", "RateNG_Motor", "Total_NG_Motor", chartMotor, lblInputMotor, lblOutputMotor, lblTotalNGMotor); // motor
            showchartProcess();
        }

        private void btnStopChart_Click(object sender, EventArgs e)
        {
            btnRunChart.Enabled = true;
            btnStopChart.Enabled = false;
            timerChart.Enabled = false;
        }

        private void cmbSeriport_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (!serialCom.IsOpen)
            {
                serialCom.PortName = cmbSeriport.Text;
                serialCom.Open();
            }
        }

        private void btnShowgrbData_Click(object sender, EventArgs e)
        {
            grbSearchData.Visible = true;
            tblLayoutData.Dock = DockStyle.Bottom;
        }

        private void btnShowgrbChart_Click(object sender, EventArgs e)
        {
            grbSearchChart.Visible = true;
            tblLayoutChart.Dock = DockStyle.Bottom;
        }

        private void btnSearchProcess_Click(object sender, EventArgs e)
        {
            GrindByProcess();
            showchartInspect();
        }
        private void GrindByProcess()
        {
            tablename = cmb_model.Text + DateTime.Now.ToString("yyyyMM");
            grbdgvProcess.Text = cmb_process.Text;
            try
            {
                ProductionControllerGA1Vo dgvVo = new ProductionControllerGA1Vo()
                {
                    TableName = tablename,
                    ModelCode = cmb_model.Text,
                    LineCode = cmb_line.Text,
                    ProcessCode = cmb_process.Text,
                    ItemCode = cmb_item.Text,
                    DateFrom = DateTime.Parse(dtpFromProcess.Text),
                    DateTo = DateTime.Parse(dtpToProcess.Text),
                };

                ProductionControllerGA1Vo processvo = (ProductionControllerGA1Vo)DefaultCbmInvoker.Invoke(new SearchProductionProcessCbm(), dgvVo, connection);
                dgvProcess.Columns.Clear();
                dgvProcess.DataSource = processvo.dt;
            }
            catch (Framework.ApplicationException exception)
            {
                popUpMessage.ApplicationError(exception.GetMessageData(), Text);
                logger.Error(exception.GetMessageData());
            }
        }
        public void showchartInspect()
        {
            chartProcess.ResetAutoValues();
            chartProcess.ResumeLayout();
            chartProcess.Series.Clear();

            chartProcess.Titles[0].Text = cmb_process.Text + " Process Comparison (pcs)"; //ten
            chartProcess.Titles[0].Font = new Font("Arial", 16, FontStyle.Bold);
            chartProcess.Series.Add("Pie");
            chartProcess.Series["Pie"].ChartType = SeriesChartType.Pie;
            chartProcess.Series["Pie"].IsValueShownAsLabel = true;

            string inspect = "";
            string data = "";
            for (int i = 0; i < dgvProcess.RowCount; i++)
            {
                inspect = dgvProcess.Rows[i].Cells["inspect"].Value.ToString();
                data = dgvProcess.Rows[i].Cells["inspectdata"].Value.ToString();
                chartProcess.Series["Pie"].Points.AddXY(inspect, data);
            }
        }
        private void chbViProcess_CheckedChanged(object sender, EventArgs e)
        {
            if (chbViProcess.Checked)//hien
            {
                grbSearchProcess.Visible = true;
                tblLayoutProcess.Dock = DockStyle.Bottom;
                chbViProcess.Text = "Setting";
            }
            else//false
            {
                btnRunProcess_Click(sender, e);
                grbSearchProcess.Visible = false;
                tblLayoutProcess.Dock = DockStyle.Fill;
                chbViProcess.Text = "Online";
            }
        }

        private void chbViChart_CheckedChanged(object sender, EventArgs e)
        {
            if (chbViChart.Checked)//hien
            {
                grbSearchChart.Visible = true;
                tblLayoutChart.Dock = DockStyle.Bottom;
                chbViChart.Text = "Setting";
            }
            else//false
            {
                btnRunChart_Click(sender, e);
                grbSearchChart.Visible = false;
                tblLayoutChart.Dock = DockStyle.Fill;
                chbViChart.Text = "Online";
            }
        }

        private void ProducionControllerGA1Form_FormClosing(object sender, FormClosingEventArgs e)
        {
            timer1.Enabled = false;
            timerChart.Enabled = false;
            timerProcess.Enabled = false;
            timerDateTimeNow.Enabled = false;
            timerMain.Enabled = false;
            serialCom.Close();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (chbViData.Checked)//hien
            {
                grbSearchData.Visible = true;
                tblLayoutData.Dock = DockStyle.Bottom;
                chbViData.Text = "Setting";
            }
            else//false
            {
                btn_SearchData_Click(sender, e);
                grbSearchData.Visible = false;
                tblLayoutData.Dock = DockStyle.Fill;
                chbViData.Text = "Online";
            }
        }

        private void btnRunProcess_Click(object sender, EventArgs e)
        {
            grbSearchProcess.Visible = false;
            tblLayoutProcess.Dock = DockStyle.Fill;
            chbViProcess.Text = "Online";
            chbViProcess.Checked = false;

            timerProcess.Interval = int.Parse(txtTimerProcess.Text);
            btnRunProcess.Enabled = false;
            btnStopProcess.Enabled = true;
            timerProcess.Enabled = true;

            GrindByProcess();
            showchartInspect();
        }
        int intRunTimerProcess = 0;
        private void timerProcess_Tick(object sender, EventArgs e)
        {
            if (intRunTimerProcess < cmb_process.Items.Count)
            {
                cmb_process.SelectedIndex = intRunTimerProcess;
                intRunTimerProcess++;
            }
            else intRunTimerProcess = 0;

            GrindByProcess();
            showchartInspect();
        }

        private void btnStopProcess_Click(object sender, EventArgs e)
        {
            btnRunProcess.Enabled = true;
            btnStopProcess.Enabled = false;
            timerProcess.Enabled = false;
        }
        private string directorySave = "";
        private void browser_btn_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fl = new FolderBrowserDialog();
            fl.SelectedPath = "D:\\";
            fl.ShowNewFolderButton = true;
            if (fl.ShowDialog() == DialogResult.OK)
            {
                linksave_txt.Text = fl.SelectedPath;
                directorySave = linksave_txt.Text;
            }
        }

        private void exportexcel_btn_Click(object sender, EventArgs e)
        {
            Common.Excel_Class ex = new Common.Excel_Class();
            ex.exportexcelGA1(ref dgvExport, directorySave, "Report", cmb_model.Text, cmb_line.Text, dtpFromExport.Text, dtpToExport.Text);
        }

        private void btnSearchExcel_Click(object sender, EventArgs e)
        {
            GrindExcel();
        }
        private void GrindExcel()
        {
            tablename = cmb_model.Text + DateTime.Now.ToString("yyyyMM");
            try
            {
                ProductionControllerGA1Vo dgvVo = new ProductionControllerGA1Vo()
                {
                    TableName = tablename,
                    ModelCode = cmb_model.Text,
                    LineCode = cmb_line.Text,
                    ProcessCode = cmb_process.Text,
                    ItemCode = cmb_item.Text,
                    DateFrom = DateTime.Parse(dtpFromExport.Text),
                    DateTo = DateTime.Parse(dtpToExport.Text),
                };

                ProductionControllerGA1Vo Exportvo = (ProductionControllerGA1Vo)DefaultCbmInvoker.Invoke(new SearchProductionExportDataCbm(), dgvVo, connection);

                ValueObjectList<ProductionControllerGA1Vo> OutputExportvo = (ValueObjectList<ProductionControllerGA1Vo>)DefaultCbmInvoker.Invoke(new SearchProductionoOutputMotorCbm(), new ProductionControllerGA1Vo
                {
                    change = true,
                    LineCode = cmb_line.Text,
                    DateFrom = DateTime.Parse(dtpFromExport.Text),
                    DateTo = DateTime.Parse(dtpToExport.Text),
                }, connectionmes);//lấy output bên mes

                ValueObjectList<ProductionControllerGA1Vo> ThuchkExportvo = (ValueObjectList<ProductionControllerGA1Vo>)DefaultCbmInvoker.Invoke(new SearchProductionoOutputMotorCbm(), new ProductionControllerGA1Vo
                {
                    change = false,
                    LineCode = cmb_line.Text,
                    DateFrom = DateTime.Parse(dtpFromExport.Text),
                    DateTo = DateTime.Parse(dtpToExport.Text),
                }, connectionmes);//lấy ng thurst bên mes

                dgvExport.Columns.Clear();
                dgvExport.DataSource = Exportvo.dt;
                int dm = 0;
                for (int i = 0; i < dgvExport.RowCount; i++)
                {
                    if (dgvExport.Rows[i].Cells["process"].Value.ToString() == "OUTPUT") { dgvExport.Rows[i].Cells["inspectdata"].Value = OutputExportvo.GetList()[0].InspecData; }
                    if (dgvExport.Rows[i].Cells["process"].Value.ToString() == "MC_THUCHK") { dgvExport.Rows[i].Cells["inspectdata"].Value = ThuchkExportvo.GetList()[0].InspecData; }
                    if (i < dgvExport.RowCount - 1)
                    {
                        int x = 0; int y = 0; int z = 0;
                        if (dm % 2 == 0) { x = 255; y = 255; z = 192; } //vang nhạt
                        else if (dm % 2 == 1) { x = 192; y = 255; z = 192; }//xanh nhạt

                        if (dgvExport.Rows[i].Cells["process"].Value.ToString() == dgvExport.Rows[i + 1].Cells["process"].Value.ToString())
                        {
                            dgvExport.Rows[i].DefaultCellStyle.BackColor = Color.FromArgb(x, y, z);
                        }
                        else
                        {
                            dgvExport.Rows[i].DefaultCellStyle.BackColor = Color.FromArgb(x, y, z);
                            dm++;
                        }
                    }
                }
            }
            catch (Framework.ApplicationException exception)
            {
                popUpMessage.ApplicationError(exception.GetMessageData(), Text);
                logger.Error(exception.GetMessageData());
            }
        }

        private void cmb_process_DropDownClosed(object sender, EventArgs e)
        {
            GrindByProcess();
            showchartInspect();
        }

        private void dtp_dateFromdata_ValueChanged(object sender, EventArgs e)
        {
            DateTimelbl();
        }
        public void DateTimelbl()
        {
            YearFromlbl.Text = dtp_dateFromdata.Value.ToString("yyyy");
            MonthFromlbl.Text = dtp_dateFromdata.Value.ToString("MM");
            DateFromlbl.Text = dtp_dateFromdata.Value.ToString("dd");
            TimeFromlbl.Text = dtp_dateFromdata.Value.ToString("HH:mm:ss");
        }

        private void btnSearchMain_Click_1(object sender, EventArgs e)
        {
            try
            {
                tblpanelMain.Controls.Clear();
                for (int i = 0; i < cmb_line.Items.Count; i++)
                {
                    GridDGVMain(((ProductionControllerGA1Vo)this.cmb_line.Items[i]).LineCode, DGV(((ProductionControllerGA1Vo)this.cmb_line.Items[i]).LineCode));
                }
            }
            catch (Framework.ApplicationException exception)
            {
                popUpMessage.ApplicationError(exception.GetMessageData(), Text);
                logger.Error(exception.GetMessageData());
            }
        }

        private void btnRunMain_Click_1(object sender, EventArgs e)
        {
            try
            {
                chbMain.Text = "Online";
                chbMain.Checked = false;
                tblpanelMain.Dock = DockStyle.Fill;
                grbMain.Visible = false;

                tblpanelMain.Controls.Clear();
                for (int i = 0; i < cmb_line.Items.Count; i++)
                {
                    GridDGVMain(((ProductionControllerGA1Vo)this.cmb_line.Items[i]).LineCode, DGV(((ProductionControllerGA1Vo)this.cmb_line.Items[i]).LineCode));
                }
                timerMain.Interval = int.Parse(txtTimerMain.Text);
                timerMain.Enabled = true;
            }
            catch (Framework.ApplicationException exception)
            {
                popUpMessage.ApplicationError(exception.GetMessageData(), Text);
                logger.Error(exception.GetMessageData());
            }
        }
        public void GridDGVMain(string line, DataGridView dgvMain)
        {
            try
            {
                tablename = cmb_model.Text + DateTime.Now.ToString("yyyyMM");
                ProductionControllerGA1Vo dgvVo = new ProductionControllerGA1Vo()
                {
                    TableName = tablename,
                    ModelCode = cmb_model.Text,
                    LineCode = line,
                    DateFrom = DateTime.Parse(dtp_FromMain.Text),
                    DateTo = DateTime.Parse(dtp_ToMain.Text),
                };

                ProductionControllerGA1Vo Exportvo = (ProductionControllerGA1Vo)DefaultCbmInvoker.Invoke(new SearchtabMainDGVCbm(), dgvVo, connection);
                dgvMain.DataSource = Exportvo.dt;

                ValueObjectList<ProductionControllerGA1Vo> inspecdata = (ValueObjectList<ProductionControllerGA1Vo>)DefaultCbmInvoker.Invoke(new SearchOutputFinalCbm(), dgvVo, connectionmes);

                ValueObjectList<ProductionControllerGA1Vo> inspectngThurst = (ValueObjectList<ProductionControllerGA1Vo>)DefaultCbmInvoker.Invoke(new SearchProductionNGThurstCbm(), dgvVo, connectionmes);

                ValueObjectList<ProductionControllerGA1Vo> inspectngNoise = (ValueObjectList<ProductionControllerGA1Vo>)DefaultCbmInvoker.Invoke(new SearchNGNOICHKfromMesdbCbm(), new ProductionControllerGA1Vo { ModelCode = cmb_model.Text, LineCode = line, DateFrom = dtp_FromMain.Value, DateTo = dtp_ToMain.Value, change = false }, connectionmes);

                if (dgvMain.ColumnCount > 0)
                {
                    dgvMain.Columns[0].HeaderText = "Inspect";
                    dgvMain.Columns[1].HeaderText = "Frame";
                    dgvMain.Columns[2].HeaderText = "Gear";
                    dgvMain.Columns[3].HeaderText = "Motor";

                    dgvMain.Rows[0].DefaultCellStyle.ForeColor = Color.Blue;
                    dgvMain.Rows[1].DefaultCellStyle.ForeColor = Color.Green;
                    dgvMain.Rows[2].DefaultCellStyle.ForeColor = Color.Red;
                    double output;
                    double ngThurst;
                    double ngNoise;
                    double ngMotor;
                    if (double.TryParse(inspecdata.GetList()[0].InspecData, out output))
                    { dgvMain.Rows[1].Cells["motor"].Value = output; }
                    if (double.TryParse(inspectngThurst.GetList()[0].InspecData, out ngThurst))
                    {
                        if (double.TryParse(dgvMain.Rows[2].Cells["motor"].Value.ToString(), out ngMotor))
                        {
                            ngThurst += ngMotor;
                        }
                        if (double.TryParse(inspectngNoise.GetList()[0].InspecData, out ngNoise))
                        {
                            ngThurst += ngNoise;
                        }
                        dgvMain.Rows[2].Cells["motor"].Value = ngThurst;
                    }

                    dgvMain.ClearSelection();
                }
            }
            catch (Framework.ApplicationException exception)
            {
                popUpMessage.ApplicationError(exception.GetMessageData(), Text);
                logger.Error(exception.GetMessageData());
            }
        }
        public DataGridView DGV(string name)
        {
            GroupBox gr = new GroupBox();
            DataGridView dgvMain = new DataGridView();

            gr.Dock = DockStyle.Fill;
            tblpanelMain.Controls.Add(gr);
            gr.Controls.Add(dgvMain);
            gr.Text = name;
            gr.Font = new Font("Arial", 12, FontStyle.Bold);

            dgvMain.Dock = DockStyle.Fill;
            dgvMain.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvMain.RowHeadersVisible = false;
            dgvMain.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvMain.AllowUserToAddRows = false;
            dgvMain.ColumnHeadersHeight = 30;
            dgvMain.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvMain.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 13, FontStyle.Bold);
            dgvMain.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvMain.DefaultCellStyle.Font = new Font("Arial", 13, FontStyle.Bold);
            dgvMain.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgvMain.ReadOnly = true;
            dgvMain.AllowUserToResizeColumns = false;
            dgvMain.AllowUserToResizeRows = false;
            dgvMain.BackgroundColor = Color.FromArgb(192, 255, 192);

            return dgvMain;
        }
        private void btnStopMain_Click_1(object sender, EventArgs e)
        {
            timerMain.Enabled = false;
        }
        private void timerMain_Tick(object sender, EventArgs e)
        {
            timerMain.Interval = int.Parse(txtTimerMain.Text);
            try
            {
                tblpanelMain.Controls.Clear();
                for (int i = 0; i < cmb_line.Items.Count; i++)
                {
                    GridDGVMain(((ProductionControllerGA1Vo)this.cmb_line.Items[i]).LineCode, DGV(((ProductionControllerGA1Vo)this.cmb_line.Items[i]).LineCode));
                }
            }
            catch (Framework.ApplicationException exception)
            {
                popUpMessage.ApplicationError(exception.GetMessageData(), Text);
                logger.Error(exception.GetMessageData());
            }
        }

        private void chbMain_CheckedChanged(object sender, EventArgs e)
        {
            if (chbMain.Checked)
            {
                grbMain.Visible = true;
                tblpanelMain.Dock = DockStyle.Bottom;
                chbMain.Text = "Setting";
            }
            else
            {
                btnSearchMain_Click_1(sender, e);
                grbMain.Visible = false;
                tblpanelMain.Dock = DockStyle.Fill;
                chbMain.Text = "Online";
            }
        }

        private void btnSearchChartMain_Click(object sender, EventArgs e)
        {
            try
            {
                tblChartMain.Controls.Clear();
                for (int i = 0; i < cmb_line.Items.Count; i++)
                {
                    ChartMain(((ProductionControllerGA1Vo)this.cmb_line.Items[i]).LineCode, GridBindChartMain(((ProductionControllerGA1Vo)this.cmb_line.Items[i]).LineCode));
                }
            }
            catch (Framework.ApplicationException exception)
            {
                popUpMessage.ApplicationError(exception.GetMessageData(), Text);
                logger.Error(exception.GetMessageData());
            }
            //for (int i = 0; i < cmb_line.Items.Count; i++)
            //{
            //    ChartMain(((ProductionControllerGA1Vo)this.cmb_line.Items[i]).LineCode, GridBindChartMain(((ProductionControllerGA1Vo)this.cmb_line.Items[i]).LineCode));
            //}
        }


        public DataTable GridBindChartMain(string line)
        {
            tablename = cmb_model.Text + DateTime.Now.ToString("yyyyMM");
            DataTable dtChartMain = new DataTable();
            try
            {
                ProductionControllerGA1Vo dgvVo = new ProductionControllerGA1Vo()
                {
                    TableName = tablename,
                    ModelCode = cmb_model.Text,
                    LineCode = line,
                    DateFrom = DateTime.Parse(dtp_dateFromChartMain.Text),
                    DateTo = DateTime.Parse(dtp_dateToChartMain.Text),
                    grDate = false,
                    Date = DateTime.Parse(dtp_dateToChartMain.Text).ToShortDateString(),
                };

                ProductionControllerGA1Vo listvo = (ProductionControllerGA1Vo)DefaultCbmInvoker.Invoke(new SearchProductionINPUTCbm(), dgvVo, connection);

                ProductionControllerGA1Vo outputvo = (ProductionControllerGA1Vo)DefaultCbmInvoker.Invoke(new SearchProductionOUTPUTCbm(), new ProductionControllerGA1Vo()
                {
                    ModelCode = cmb_model.Text,
                    LineCode = line,
                    DateFrom = DateTime.Parse(dtp_dateFromChartMain.Text),
                    DateTo = DateTime.Parse(dtp_dateToChartMain.Text),
                    Date = DateTime.Parse(dtp_dateToChartMain.Text).ToShortDateString(),
                    change = true,
                }, connectionmes);

                ProductionControllerGA1Vo vo = new ProductionControllerGA1Vo
                {
                    ModelCode = cmb_model.Text,
                    LineCode = line,
                    DateFrom = DateTime.Parse(dtp_dateFromChartMain.Text),
                    DateTo = DateTime.Parse(dtp_dateToChartMain.Text),
                    Date = DateTime.Parse(dtp_dateToChartMain.Text).ToShortDateString(),
                };
                ProductionControllerGA1Vo outputFinalvo = (ProductionControllerGA1Vo)DefaultCbmInvoker.Invoke(new SearchOUTPUTByHourCbm(), vo, connectionmes);

                ProductionControllerGA1Vo ngThurstVo = (ProductionControllerGA1Vo)DefaultCbmInvoker.Invoke(new SearchNGThurstChartCbm(), vo, connectionmes);//lay ng thurst tu mesdb

                ProductionControllerGA1Vo ngNOICHKVo = (ProductionControllerGA1Vo)DefaultCbmInvoker.Invoke(new SearchProductionNGNOICHKCbm(), vo, connectionmes);

                var distinctProcess = (from row in listvo.dt.AsEnumerable() orderby row["process"] select row.Field<string>("process")).Distinct();
                dtChartMain.Columns.Add("Model");
                dtChartMain.Columns.Add("Line");
                dtChartMain.Columns.Add("Date");
                dtChartMain.Columns.Add("Total_NG_Frame");
                dtChartMain.Columns.Add("Total_NG_Gear");
                dtChartMain.Columns.Add("Total_NG_Motor");
                dtChartMain.Columns.Add("OUTPUT");
                dtChartMain.Columns.Add("RateNG_Frame");
                dtChartMain.Columns.Add("RateNG_Gear");
                dtChartMain.Columns.Add("RateNG_Motor");
                dtChartMain.Columns.Add("MC_THUCHK");
                dtChartMain.Columns.Add("MC_NOICHK");
                foreach (var a in distinctProcess)
                {
                    dtChartMain.Columns.Add(a.ToString());
                }

                var distinctTime = (from row in listvo.dt.AsEnumerable() orderby row["times"] select row.Field<string>("times")).Distinct();
                foreach (var times in distinctTime)
                {
                    if (listvo.dt.Rows.Count > 0)
                    {
                        var info = (from row in listvo.dt.AsEnumerable() where row.Field<string>("times") == times.ToString() select row).ToList();

                        var inspectdata = (from row in listvo.dt.AsEnumerable() where row.Field<string>("times") == times.ToString() select row).ToList();

                        DataRow dr = dtChartMain.NewRow();

                        dr[0] = info[0]["model"].ToString();
                        dr[1] = info[0]["line"].ToString();
                        dr[2] = info[0]["times"].ToString();
                        int j = 0;
                        for (int i = 0; i < dtChartMain.Columns.Count - 11; i++)
                        {
                            if (j < inspectdata.Count)
                            {
                                if (dtChartMain.Columns[i + 11].ColumnName == inspectdata[j]["process"].ToString())
                                {
                                    dr[i + 11] = inspectdata[j]["inspectdata"].ToString();
                                    j++;
                                }
                                else
                                {
                                    dr[i + 11] = "0";
                                }
                            }
                            else dr[i + 11] = "0";
                        }
                        dtChartMain.Rows.Add(dr);
                    }
                }

                //sum hang cuoi
                DataRow dr1 = dtChartMain.NewRow();
                for (int i = 11; i < dtChartMain.Columns.Count; i++)
                {
                    double sum = 0;
                    for (int j = 0; j < dtChartMain.Rows.Count; j++)
                    {
                        sum += double.Parse(dtChartMain.Rows[j][i].ToString());
                        dr1[i] = sum;
                    }
                }
                dtChartMain.Rows.Add(dr1);
                
                //int t = 0;
                for (int i = 0; i < dtChartMain.Rows.Count - 1; i++)
                {
                    double totalNGMoTor = 0;
                    double rateNGMotor = 0;
                    double outputRow = 0;
                    for (int t = 0; t < outputvo.dt.Rows.Count; t++)//insert output motor tu mesdb
                    {
                        if (dtChartMain.Rows[i]["Date"].ToString() == outputvo.dt.Rows[t]["times"].ToString())
                        {
                            outputRow = double.Parse(outputFinalvo.dt.Rows[t]["count"].ToString());
                            dtChartMain.Rows[i]["OUTPUT"] = outputRow;
                        }
                    }
                    for (int t = 0; t < ngThurstVo.dt.Rows.Count; t++)//insert ngThurst tu mesdb
                    {
                        if (dtChartMain.Rows[i]["Date"].ToString() == ngThurstVo.dt.Rows[t]["times"].ToString())
                        {
                            outputRow = double.Parse(ngThurstVo.dt.Rows[t]["count"].ToString());
                            dtChartMain.Rows[i]["MC_THUCHK"] = outputRow;
                        }
                    }
                    for (int t = 0; t < ngNOICHKVo.dt.Rows.Count; t++)//insert ngNOICHK tu mesdb
                    {
                        if (dtChartMain.Rows[i]["Date"].ToString() == ngNOICHKVo.dt.Rows[t]["times"].ToString())
                        {
                            outputRow = double.Parse(ngNOICHKVo.dt.Rows[t]["count"].ToString());
                            dtChartMain.Rows[i]["MC_NOICHK"] = outputRow;
                        }
                    }
                    for (int j = 0; j < dtChartMain.Columns.Count; j++)
                    {
                        if (dtChartMain.Columns[j].ColumnName.Substring(0, 2) == "MC" && dtChartMain.Columns[j].ColumnName != "MC_IP")
                        { totalNGMoTor += double.Parse(dtChartMain.Rows[i][j].ToString()); }
                    }
                    double outputMotor = 0;
                    if (dtChartMain.Columns.Contains("OUTPUT")) { outputMotor = double.Parse(dtChartMain.Rows[i]["OUTPUT"].ToString()); }

                    if (outputMotor == 0) { rateNGMotor = 0; } else rateNGMotor = Math.Round((totalNGMoTor / outputMotor) * 100, 3);

                    dtChartMain.Rows[i]["RateNG_Motor"] = rateNGMotor;
                    dtChartMain.Rows[i]["Total_NG_Motor"] = totalNGMoTor;
                }
                //double sumThurst = 0;
                //double sumNoichk = 0;
                //for (int j = 0; j < dt.Rows.Count; j++)
                //{
                //    if (j < dt.Rows.Count - 1)
                //    {
                //        sumThurst += double.Parse(dgv.Rows[j].Cells["MC_THUCHK"].Value.ToString());
                //        sumNoichk += double.Parse(dgv.Rows[j].Cells["MC_NOICHK"].Value.ToString());
                //    }
                //    else if (j == dt.Rows.Count - 1)
                //    {
                //        dgv.Rows[j].Cells["MC_THUCHK"].Value = sumThurst;
                //        dgv.Rows[j].Cells["MC_NOICHK"].Value = sumNoichk;
                //    }
                //}
                return dtChartMain;
            }
            catch (Framework.ApplicationException exception)
            {
                popUpMessage.ApplicationError(exception.GetMessageData(), Text);
                logger.Error(exception.GetMessageData());
                return dtChartMain;
            }
        }

        public Chart ChartMain(string line, DataTable dt)
        {
            Chart chart = new Chart();
            tblChartMain.Controls.Add(chart);
            chart.Dock = DockStyle.Fill;

            chart.ResetAutoValues();
            chart.ResumeLayout();
            chart.Series.Clear();
            chart.Titles.Add("chart").Text = "CHART SHOW PROGRESS MOTOR " + line;
            chart.Titles[0].Font = new Font("Microsoft Sans Serif", 9, FontStyle.Bold);
            chart.Titles[0].Alignment = ContentAlignment.TopCenter;
            chart.Titles[0].ForeColor = Color.Green;

            chart.ChartAreas.Add("chart");
            chart.ChartAreas[0].AxisX.LabelStyle.Format = "HH:mm";
            chart.ChartAreas[0].AxisX.LabelStyle.Font = new Font("Arial", 7);
            chart.ChartAreas[0].AxisX.MajorGrid.Enabled = false;
            chart.ChartAreas[0].AxisX2.MajorGrid.Enabled = false;
            chart.ChartAreas[0].AxisY.MajorGrid.Enabled = true;
            chart.ChartAreas[0].AxisY2.MajorGrid.Enabled = false;
            chart.ChartAreas[0].AxisX.IntervalAutoMode = IntervalAutoMode.VariableCount;
            chart.ChartAreas[0].AxisY.Title = "TOTAL[PCS]"; //sua ten truc
            chart.ChartAreas[0].AxisX.LabelStyle.Angle = -20;
            chart.ChartAreas[0].AxisX.LabelStyle.Font = new Font("Arial", 7);

            chart.Series.Add("Output (pcs)");
            chart.Series["Output (pcs)"].XValueType = ChartValueType.Time;
            chart.Series["Output (pcs)"].ChartType = SeriesChartType.Line;
            chart.Series["Output (pcs)"].Color = Color.FromArgb(0, 192, 0); //green
            chart.Series["Output (pcs)"].BorderWidth = 5;
            chart.Series["Output (pcs)"].CustomProperties = "LabelStyle=Bottom"; //chua nhu chó
            chart.Series["Output (pcs)"].IsValueShownAsLabel = true;

            chart.Series.Add("YEILD (%)");
            chart.Series["YEILD (%)"].ChartType = SeriesChartType.Line;
            chart.Series["YEILD (%)"].Color = Color.FromArgb(192, 100, 0); //yellow    
            chart.Series["YEILD (%)"].BorderWidth = 1;
            chart.Series["YEILD (%)"].IsValueShownAsLabel = true;
            chart.ChartAreas[0].AxisY2.Enabled = AxisEnabled.True;
            chart.Series["YEILD (%)"].YAxisType = AxisType.Secondary;
            chart.ChartAreas[0].AxisX2.Enabled = AxisEnabled.True;
            chart.Series["YEILD (%)"].XAxisType = AxisType.Secondary;
            chart.Series["YEILD (%)"].XValueType = ChartValueType.Time;
            chart.Series["YEILD (%)"].CustomProperties = "LabelStyle=Center";
            chart.ChartAreas[0].AxisX2.LabelStyle.Enabled = false;
            chart.ChartAreas[0].AxisY2.Maximum = 100;
            chart.ChartAreas[0].AxisY2.Title = "YEILD [%]";

            if (dt.Rows.Count > 0)
            {
                double dataOut = 0;
                double rateNG = 0;
                double totalNG = 0;
                for (int i = 0; i < dt.Rows.Count - 1; i++)
                {
                    if (dt.Rows[i]["OUTPUT"].ToString() != "")
                    {
                        dataOut += double.Parse(dt.Rows[i]["OUTPUT"].ToString());
                    }
                    if (dt.Rows[i]["Total_NG_Motor"].ToString() != "")
                    {
                        totalNG += double.Parse(dt.Rows[i]["Total_NG_Motor"].ToString());
                    }

                    if (dataOut > 0) { rateNG = (totalNG / (dataOut + totalNG)) * 100; }////////quan trong
                    else rateNG = 0;

                    if (i % 2 == 0)
                    {
                        chart.Series["Output (pcs)"].Points.AddXY(DateTime.Parse(dt.Rows[i]["Date"].ToString()).ToString("HH:mm"), dataOut);
                        chart.Series["YEILD (%)"].Points.AddXY(DateTime.Parse(dt.Rows[i]["Date"].ToString()).ToString("HH:mm"), Math.Round((100 - rateNG), 2));
                    }
                }
            }
            return chart;
        }
    }
}
