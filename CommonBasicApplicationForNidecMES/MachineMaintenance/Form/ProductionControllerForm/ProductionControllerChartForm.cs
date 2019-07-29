using Com.Nidec.Mes.Framework;

using System;
using System.Drawing;
using Com.Nidec.Mes.Common.Basic.MachineMaintenance.Vo;
using System.Windows.Forms.DataVisualization.Charting;



namespace Com.Nidec.Mes.Common.Basic.MachineMaintenance.Form
{
    public partial class ProductionControllerChartForm : FormCommonNCVP
    {
        public ProductionControllerChartForm()
        {
            InitializeComponent();
        }
        public ProductionControllerVo vochart = new ProductionControllerVo();
        public DataGridViewCommon dgv;
        public string model;
        public string line;
        public DateTime datefrom;
        public DateTime dateto;
        public int confirm_status;
        public ProductionControllerChartForm(ref DataGridViewCommon _dgv, string _model, string _line, DateTime _datefrom, DateTime _dateto, int _confirm_status) : this()
        {
            dgv = _dgv;
            model = _model;
            line = _line;
            datefrom = _datefrom;
            dateto = _dateto;
            confirm_status = _confirm_status; //=0 la date, =1 la time
        }
        private void ProductionControllerChartForm_Load(object sender, EventArgs e)
        {
            model_lbl.Text = model;
            line_lbl.Text = line;
            datetimefrom_lbl.Text = datefrom.ToString();
            datetimeto_lbl.Text = dateto.ToString();
            if (confirm_status == 0) //=0 la date, =1 la time
            {
                chartIONG.ResetAutoValues();
                chartIONG.ResumeLayout();
                chartIONG.Series.Clear();
                ShowChartTotalNG();
                chartdata_cmb.Visible = false;
                //combox hided
                //chartdata_cmb.Items.Add("Input");
                //chartdata_cmb.Items.Add("Output");
                //chartdata_cmb.Items.Add("Total NG");
            }
            else if (confirm_status == 1)
            {
                chartIONG.ResetAutoValues();
                chartIONG.ResumeLayout();
                chartIONG.Series.Clear();
                // chartIONG.ChartAreas.Clear();

                chartname_lbl.Visible = false;
                chartdata_cmb.DataSource = null;
                chartdata_cmb.Visible = false;
                datetimeto_lbl.Visible = false;
                to_lbl.Visible = false;
                from_lbl.Text = "DATE";
                ShowChartTime();
            }
            else if (confirm_status == 2)
            {
                chartdata_cmb.DataSource = null;
                chartdata_cmb.Items.Add("Input");
                chartdata_cmb.Items.Add("Output");
                chartdata_cmb.Items.Add("Rate NG");
                chartdata_cmb.Visible = true;
                datetimeto_lbl.Visible = true;
            }
        }

        public void showchartNGTimeAllLine_Input()
        {

            chartIONG.Titles[0].Text = "CHART SHOW COMPARE INPUT DATA";
            chartIONG.Titles[0].Font = new Font("Arial", 16, FontStyle.Bold);

            chartIONG.ChartAreas[0].AxisX.LabelStyle.Format = "dd - MM HH: mm";
            chartIONG.ChartAreas[0].AxisX.MajorGrid.Enabled = false;
            chartIONG.ChartAreas[0].AxisX.IntervalAutoMode = IntervalAutoMode.VariableCount;
            chartIONG.ChartAreas[0].AxisX.LabelStyle.Angle = -60;
            chartIONG.ChartAreas[0].AxisY.Title = "INPUT [PCS]";
            chartIONG.ChartAreas[0].AxisY.Maximum = double.NaN;

            DrawChart("Input_Line01", "L01", "colInput", 9, 9, 225);
            DrawChart("Input_Line02", "L02", "colInput", 128, 64, 64);
            DrawChart("Input_Line03", "L03", "colInput", 192, 0, 192);
            DrawChart("Input_Line04", "L04", "colInput", 0, 192, 192);
            DrawChart("Input_Line05", "L05", "colInput", 0, 192, 0);
            DrawChart("Input_Line06", "L06", "colInput", 192, 192, 0);
            DrawChart("Input_Line07", "L07", "colInput", 255, 192, 128);

        }

        public void showchartNGTimeAllLine_Output()
        {

            chartIONG.Titles[0].Text = "CHART SHOW COMPARE OUTPUT DATA";
            chartIONG.Titles[0].Font = new Font("Arial", 16, FontStyle.Bold);

            chartIONG.ChartAreas[0].AxisX.LabelStyle.Format = "dd - MM HH: mm";
            chartIONG.ChartAreas[0].AxisX.MajorGrid.Enabled = false;
            chartIONG.ChartAreas[0].AxisX.IntervalAutoMode = IntervalAutoMode.VariableCount;
            chartIONG.ChartAreas[0].AxisX.LabelStyle.Angle = -60;
            chartIONG.ChartAreas[0].AxisY.Title = "OUTPUT [PCS]";
            chartIONG.ChartAreas[0].AxisY.Maximum = double.NaN;

            DrawChart("Output_Line01", "L01", "colOutput", 9, 9, 225);
            DrawChart("Output_Line02", "L02", "colOutput", 128, 64, 64);
            DrawChart("Output_Line03", "L03", "colOutput", 192, 0, 192);
            DrawChart("Output_Line04", "L04", "colOutput", 0, 192, 192);
            DrawChart("Output_Line05", "L05", "colOutput", 0, 192, 0);
            DrawChart("Output_Line06", "L06", "colOutput", 192, 192, 0);
            DrawChart("Output_Line07", "L07", "colOutput", 255, 192, 128);

        }
        //colRateNG
        public void showchartNGTimeAllLine_TotalNG()
        {
            chartIONG.Titles[0].Text = "CHART SHOW COMPARE TOTAL NG";
            chartIONG.Titles[0].Font = new Font("Arial", 16, FontStyle.Bold);


            chartIONG.ChartAreas[0].AxisX.LabelStyle.Format = "dd - MM HH: mm";
            chartIONG.ChartAreas[0].AxisX.MajorGrid.Enabled = false;
            chartIONG.ChartAreas[0].AxisX.IntervalAutoMode = IntervalAutoMode.VariableCount;
            chartIONG.ChartAreas[0].AxisX.LabelStyle.Angle = -60;
            chartIONG.ChartAreas[0].AxisY.Title = "NG [%]";
            chartIONG.ChartAreas[0].AxisY.Maximum = 20;

            DrawChart("Rate NG_Line01", "L01", "colRateNG", 9, 9, 225);
            DrawChart("Rate NG_Line02", "L02", "colRateNG", 128, 64, 64);
            DrawChart("Rate NG_Line03", "L03", "colRateNG", 192, 0, 192);
            DrawChart("Rate NG_Line04", "L04", "colRateNG", 0, 192, 192);
            DrawChart("Rate NG_Line05", "L05", "colRateNG", 0, 192, 0);
            DrawChart("Rate NG_Line06", "L06", "colRateNG", 192, 192, 0);
            DrawChart("Rate NG_Line07", "L07", "colRateNG", 255, 192, 128);



        }
        public void DrawChart(string nameChart, string nameLine, string colYvalue, int red, int green, int blue)
        {
            chartIONG.Series.Add(nameChart);
            chartIONG.Series[nameChart].ChartType = SeriesChartType.Line;
            chartIONG.Series[nameChart].XValueType = ChartValueType.DateTime;
            chartIONG.Series[nameChart].Color = Color.FromArgb(red, green, blue);
            chartIONG.Series[nameChart].BorderWidth = 2;
            for (int i = 0; i < dgv.Rows.Count; i++)
            {
                if (dgv.Rows[i].Cells["colLine"].Value.ToString() == nameLine)
                {
                    DateTime XValue = DateTime.Parse(dgv.Rows[i].Cells["colEndday"].Value.ToString());
                    double yValue = double.Parse(dgv.Rows[i].Cells[colYvalue].Value.ToString());
                    chartIONG.Series[nameChart].Points.AddXY(XValue, yValue);
                }
            }
        }

        private void chartdata_cmb_SelectedIndexChanged(object sender, EventArgs e)
        {
            chartIONG.ResetAutoValues();
            chartIONG.ResumeLayout();
            chartIONG.Series.Clear();
            // chartIONG.ChartAreas.Clear();

            
            if (chartdata_cmb.Text == "Input" && confirm_status == 2)
            {
                showchartNGTimeAllLine_Input();
            }
            if (chartdata_cmb.Text == "Output" && confirm_status == 2)
            {
                showchartNGTimeAllLine_Output();
            }
            if (chartdata_cmb.Text == "Rate NG" && confirm_status == 2)
            {
                showchartNGTimeAllLine_TotalNG();
            }

        }

        
        public void ShowChartTotalNG()
        {
            chartIONG.Titles[0].Text = "CHART SHOW PROGRESS DATA"; //ten
            chartIONG.Titles[0].Font = new Font("Arial", 16, FontStyle.Bold);
            chartIONG.ChartAreas[0].AxisX.LabelStyle.Format = "dd-MM";
            chartIONG.ChartAreas[0].AxisX.MajorGrid.Enabled = false;
            chartIONG.ChartAreas[0].AxisX2.MajorGrid.Enabled = false;
            chartIONG.ChartAreas[0].AxisY.MajorGrid.Enabled = false;
            chartIONG.ChartAreas[0].AxisY2.MajorGrid.Enabled = false;
            chartIONG.ChartAreas[0].AxisX.IntervalAutoMode = IntervalAutoMode.VariableCount;
            chartIONG.ChartAreas[0].AxisY.Title = "TOTAL[PCS]"; //sua ten truc

            chartIONG.Series.Add("Output");
            chartIONG.Series["Output"].XValueType = ChartValueType.Date;
            chartIONG.Series["Output"].ChartType = SeriesChartType.Line;
            chartIONG.Series["Output"].Color = Color.FromArgb(0, 192, 0); //green
            chartIONG.Series["Output"].XValueMember = "StartDay";
            chartIONG.Series["Output"].YValueMembers = "ProOutput";
            chartIONG.Series["Output"].BorderWidth = 5;
            chartIONG.Series["Output"].CustomProperties = "LabelStyle=Bottom"; //chua nhu chó
            chartIONG.Series["Output"].IsValueShownAsLabel = true;

            chartIONG.Series.Add("Input");
            chartIONG.Series["Input"].XValueType = ChartValueType.Date;
            chartIONG.Series["Input"].ChartType = SeriesChartType.Line;
            chartIONG.Series["Input"].Color = Color.FromArgb(9, 9, 226); //blue
            chartIONG.Series["Input"].XValueMember = "StartDay";
            chartIONG.Series["Input"].CustomProperties = "LabelStyle=Top";
            chartIONG.Series["Input"].YValueMembers = "ProInput";
            chartIONG.Series["Input"].BorderWidth = 5;
            chartIONG.Series["Input"].IsValueShownAsLabel = true;

            chartIONG.Series.Add("NG");
            chartIONG.Series["NG"].ChartType = SeriesChartType.Line;
            chartIONG.Series["NG"].Color = Color.FromArgb(226, 0, 0); //red    
            chartIONG.Series["NG"].BorderWidth = 3;
            chartIONG.Series["NG"].IsValueShownAsLabel = true;
            chartIONG.Series["NG"].CustomProperties = "LabelStyle=Top";

            chartIONG.ChartAreas[0].AxisY2.Enabled = AxisEnabled.True;
            chartIONG.Series["NG"].YAxisType = AxisType.Secondary;
            chartIONG.ChartAreas[0].AxisX2.Enabled = AxisEnabled.True;
            chartIONG.Series["NG"].XAxisType = AxisType.Secondary;
            chartIONG.Series["NG"].XValueType = ChartValueType.DateTime;
            chartIONG.ChartAreas[0].AxisX2.LabelStyle.Format = "HH:mm";
            chartIONG.ChartAreas[0].AxisX2.LabelStyle.Angle = 0;
            chartIONG.ChartAreas[0].AxisY2.Maximum = 100;
            chartIONG.ChartAreas[0].AxisY2.Title = "NG [%]"; //nG . 

            int max = 0;
            for (int i = 1; i < dgv.RowCount; i++)
            {
                
                if (i > 0)
                {
                    if (double.Parse(dgv.Rows[i].Cells["colInput"].Value.ToString()) > double.Parse(dgv.Rows[i-1].Cells["colInput"].Value.ToString()))
                    {
                        max = i;
                    }
                }
                double yvalue = double.Parse(dgv.Rows[i].Cells["colRateNG"].Value.ToString());
                DateTime xvalue = DateTime.Parse(dgv.Rows[i].Cells["colStarDay"].Value.ToString());
                chartIONG.Series["NG"].Points.AddXY(xvalue, yvalue); // = yvalue

            }

            chartIONG.ChartAreas[0].AxisY.Maximum = double.Parse(dgv.Rows[max].Cells["colInput"].Value.ToString()) + 5000;
                if (line_lbl.Text == "All Line") { chartIONG.ChartAreas[0].AxisY.Maximum = double.Parse(dgv.Rows[max].Cells["colInput"].Value.ToString()) + 15000; }
         

            chartIONG.DataSource = dgv.DataSource;
            chartIONG.DataBind();
        }
        public void ShowChartOutput()
        {
            chartIONG.Titles[0].Text = "CHART SHOW OUTPUT DATA";
            chartIONG.Titles[0].Font = new Font("Arial", 16, FontStyle.Bold);
            chartIONG.ChartAreas[0].AxisX.LabelStyle.Format = "dd-MM";
            chartIONG.ChartAreas[0].AxisX.MajorGrid.Enabled = false;
            chartIONG.ChartAreas[0].AxisX.IntervalAutoMode = IntervalAutoMode.VariableCount;
            chartIONG.ChartAreas[0].AxisX.LabelStyle.Angle = -60;
            chartIONG.ChartAreas[0].AxisY.Title = "OUTPUT [PCS]";

            chartIONG.Series.Add("Output");
            chartIONG.Series["Output"].XValueType = ChartValueType.Date;
            chartIONG.Series["Output"].ChartType = SeriesChartType.Line;
            chartIONG.Series["Output"].Color = Color.FromArgb(0, 192, 0); //blue
            chartIONG.Series["Output"].XValueMember = "StartDay";
            chartIONG.Series["Output"].YValueMembers = "ProOutput";
            chartIONG.Series["Output"].IsValueShownAsLabel = true;
            chartIONG.DataSource = dgv.DataSource;
            chartIONG.DataBind();
            //end chart
        }
        public void ShowChartTime() //using line chart
        {
            chartIONG.Titles[0].Text = "CHART SHOW  PROGRESS DATA";
            chartIONG.Titles[0].Font = new Font("Arial", 16, FontStyle.Bold);
            chartIONG.ChartAreas[0].AxisX.LabelStyle.Format = "dd-MM HH:mm";
            chartIONG.ChartAreas[0].AxisX.MajorGrid.Enabled = false;
            chartIONG.ChartAreas[0].AxisX2.MajorGrid.Enabled = false;
            chartIONG.ChartAreas[0].AxisY.MajorGrid.Enabled = false;
            chartIONG.ChartAreas[0].AxisY2.MajorGrid.Enabled = false;
            chartIONG.ChartAreas[0].AxisX.IntervalAutoMode = IntervalAutoMode.VariableCount;
            chartIONG.ChartAreas[0].AxisX.LabelStyle.Angle = -60;
            chartIONG.ChartAreas[0].AxisY.Title = "DATA [PCS]";

            chartIONG.Series.Add("Output");
            chartIONG.Series["Output"].ChartType = SeriesChartType.Line;
            chartIONG.Series["Output"].XValueType = ChartValueType.DateTime;
            chartIONG.Series["Output"].Color = Color.FromArgb(0, 192, 0); //blue
            chartIONG.Series["Output"].XValueMember = "TimeHour";
            chartIONG.Series["Output"].YValueMembers = "ProOutput";
            chartIONG.Series["Output"].BorderWidth = 5;
            chartIONG.Series["Output"].IsValueShownAsLabel = true;
            chartIONG.Series["Output"].CustomProperties = "LabelStyle=Bottom";


            chartIONG.Series.Add("Input");
            chartIONG.Series["Input"].ChartType = SeriesChartType.Line;
            chartIONG.Series["Input"].XValueType = ChartValueType.DateTime;
            chartIONG.Series["Input"].Color = Color.FromArgb(9, 9, 226);
            chartIONG.Series["Input"].YValueMembers = "ProInput";
            chartIONG.Series["Input"].XValueMember = "TimeHour";
            chartIONG.Series["Input"].BorderWidth = 4;
            //chartIONG.Series["Input"].IsValueShownAsLabel = true;


            chartIONG.Series.Add("YEILD");
            chartIONG.Series["YEILD"].ChartType = SeriesChartType.Line;
            chartIONG.Series["YEILD"].Color = Color.FromArgb(192, 100, 0); //yellow    
            chartIONG.Series["YEILD"].BorderWidth = 1;
            chartIONG.Series["YEILD"].IsValueShownAsLabel = true;

            chartIONG.ChartAreas[0].AxisY2.Enabled = AxisEnabled.True;
            chartIONG.Series["YEILD"].YAxisType = AxisType.Secondary;
            chartIONG.ChartAreas[0].AxisX2.Enabled = AxisEnabled.True;
            chartIONG.Series["YEILD"].XAxisType = AxisType.Secondary;
            chartIONG.Series["YEILD"].XValueType = ChartValueType.DateTime;
            chartIONG.ChartAreas[0].AxisX2.LabelStyle.Format = "HH:mm";
            chartIONG.ChartAreas[0].AxisX2.LabelStyle.Angle = 0;
            chartIONG.ChartAreas[0].AxisY2.Maximum = 100;
            chartIONG.ChartAreas[0].AxisY2.Title = "YEILD [%]";
           

            for (int i = 0; i < dgv.RowCount; i++)
            {
                double yvalue = double.Parse(dgv.Rows[i].Cells["colRateNG"].Value.ToString());
                DateTime xvalue = DateTime.Parse(dgv.Rows[i].Cells["colEndday"].Value.ToString());
                chartIONG.Series["YEILD"].Points.AddXY(xvalue, 100 - yvalue);
                chartIONG.ChartAreas[0].AxisY.Maximum = double.Parse(dgv.Rows[i].Cells["colInput"].Value.ToString()) + 5000;
            }
            chartIONG.Series["YEILD"].CustomProperties = "LabelStyle=Bottom";
            chartIONG.DataSource = dgv.DataSource;
            chartIONG.DataBind();


        }

    }
}
