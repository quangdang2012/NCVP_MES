using Com.Nidec.Mes.Framework;

using System;
using System.Drawing;
using System.Windows.Forms.DataVisualization.Charting;


namespace Com.Nidec.Mes.Common.Basic.MachineMaintenance.Form
{
    public partial class ProductionControllerChart_CNCVCForm : FormCommonNCVP
    {
        public ProductionControllerChart_CNCVCForm()
        {
            InitializeComponent();
        }

        public string model;
        public string line;
        public DateTime datefrom;
        public string process;
        public int Holder_chart_C;
        public int AppCheck_chart_C;
        public int En2_chart_C;
        public int Fundou_chart_C;
        public int En1_chart_C;
        public int InsertCase_chart_C;
        public int RANG_chart_C;
        public int Solder_chart_C;
        public int SolderWire_chart_C;
        public int Wingding_chart_C;
        public int Welding_chart_C;
        public int Core_chart_C;
        public int confirm_status_C;
        public DataGridViewCommon dgv;
        public int rowselect;

        private void ProductionControllerChart_CForm_Load(object sender, EventArgs e)
        {
            model_lbl.Text = model;
            line_lbl.Text = line;
            date_lbl.Text = datefrom.ToString();
            if (confirm_status_C == 3) //start main chart
            {
                chartNG.ResetAutoValues();
                chartNG.ResumeLayout();
                chartNG.Series.Clear();
                process_lbl.Visible = false;
                processn_lbl.Visible = false;
                ShowChartNG();

            }
            if (confirm_status_C == 4) //start detail chart
            {
                chartNG.ResetAutoValues();
                chartNG.ResumeLayout();
                chartNG.Series.Clear();
                process_lbl.Visible = true;
                processn_lbl.Visible = true;
                ChartNGProcess();

            }
        }
        //main
        public ProductionControllerChart_CNCVCForm(string _model, string _line, string _process, ref DataGridViewCommon _dgv_C, int i, int _confirm_status_C) : this()
        {

            model = _model;
            line = _line;
            process = _process;
            dgv = _dgv_C;
            rowselect = i;
            confirm_status_C = _confirm_status_C;
            datefrom = DateTime.Parse(dgv.Rows[i].Cells["colStarday"].Value.ToString());



        }
        private void ShowChartNG()
        {

            chartNG.Series.Add("NGProcess");
            chartNG.Titles[0].Text = "Chart NG Process in date";
            chartNG.Titles[0].Font = new Font("Arial", 16, FontStyle.Bold);
            chartNG.Series["NGProcess"].ChartType = SeriesChartType.Pie;
            chartNG.Series["NGProcess"].IsValueShownAsLabel = true;
           
            string header = "";
            int value = 0;
            int a = dgv.ColumnCount;
            for (int j = 11; j < dgv.ColumnCount; j++)
            {
                header = dgv.Columns[j].HeaderText;
                value = int.Parse(dgv.Rows[rowselect].Cells[j].Value.ToString());
                chartNG.Series["NGProcess"].Points.AddXY(header, value);
            }


        }
        //detail
        public ProductionControllerChart_CNCVCForm(ref DataGridViewCommon _dgv_C, string _model_C, string _line_C, string _process_C, int _confirm_status_C) : this()
        {
            model = _model_C;
            line = _line_C; ;
            process = _process_C;
            dgv = _dgv_C;
            process_lbl.Text = _process_C;
            datefrom = DateTime.Parse(dgv.Rows[dgv.RowCount -1].Cells["colTime"].Value.ToString());
            date_lbl.Text = datefrom.ToString();
            process_lbl.Text = _process_C;
            confirm_status_C = _confirm_status_C;
        }
        private void ChartNGProcess()
        {
            chartNG.Series.Add("NGProcess");
            chartNG.Titles[0].Text = "NG Chart of " + process;
            chartNG.Titles[0].Font = new Font("Arial", 16, FontStyle.Bold);
            chartNG.Series["NGProcess"].ChartType = SeriesChartType.Pie;
            chartNG.Series["NGProcess"].IsValueShownAsLabel = true;
            int i = dgv.RowCount - 1;
            string header = "";
            int value = 0;
            for (int j = 3; j < dgv.ColumnCount; j++)
            {
                header = dgv.Columns[j].HeaderText;
                value = int.Parse(dgv.Rows[i].Cells[j].Value.ToString());
                chartNG.Series["NGProcess"].Points.AddXY(header, value);
            }
        }

       
    }
}
