using Com.Nidec.Mes.Framework;
using System.Windows.Forms.DataVisualization.Charting;
using System;
using System.Drawing;
using System.Windows.Forms;
using Com.Nidec.Mes.Common.Basic.MachineMaintenance.Vo;
using Com.Nidec.Mes.Common.Basic.MachineMaintenance.Cbm;
using Com.Nidec.Mes.Common.Basic.MachineMaintenance.Cbm.OvenBarcodeCbm.OvenBarcodeCbm;

namespace Com.Nidec.Mes.Common.Basic.MachineMaintenance.Form
{
    public partial class OvenBarcodeForm : FormCommonNCVP
    {
        public OvenBarcodeForm()
        {
            InitializeComponent();
        }

        private void OvenBarcodeForm_Load(object sender, EventArgs e)
        {
            timefrom_dtp.Value = timefrom_dtp.Value.AddDays(-30);
            ValueObjectList<OvenBarcodeVo> model = (ValueObjectList<OvenBarcodeVo>)DefaultCbmInvoker.Invoke(new GetModelOvenCbm(), new OvenBarcodeVo());
            model_cmb.DisplayMember = "Model";
            model_cmb.DataSource = model.GetList();
            model_cmb.Text = "";
        }

        private void model_cmb_SelectedIndexChanged(object sender, EventArgs e)
        {
            line_cmb.DataSource = null;
            ValueObjectList<OvenBarcodeVo> line = (ValueObjectList<OvenBarcodeVo>)DefaultCbmInvoker.Invoke(new GetLineOvenCbm(), new OvenBarcodeVo() { Model = model_cmb.Text, });
            line_cmb.DisplayMember = "Line";
            line_cmb.DataSource = line.GetList();
            line_cmb.Text = "";
        }

        private void line_cmb_SelectedIndexChanged(object sender, EventArgs e)
        {
            barcode_cmb.DataSource = null;
            ValueObjectList<OvenBarcodeVo> barcode = (ValueObjectList<OvenBarcodeVo>)DefaultCbmInvoker.Invoke(new GetBarcodeOvenCbm(), new OvenBarcodeVo() { Model = model_cmb.Text, Line = line_cmb.Text });
            barcode_cmb.DisplayMember = "Barcode";
            barcode_cmb.DataSource = barcode.GetList();
            barcode_cmb.Text = "";
        }

        private void search_btn_Click(object sender, EventArgs e)
        {
            GridBind();
            Chart();
        }
        private void Chart()
        {

            chartOven.ResetAutoValues();
            chartOven.ResumeLayout();
            chartOven.Series.Clear();

            chartOven.Titles[0].Text = "CHART SHOW TEMPERATURE DATA";
            chartOven.Titles[0].Font = new Font("Arial", 16, FontStyle.Bold);
            chartOven.ChartAreas[0].AxisX.LabelStyle.Format = "dd-MM HH:mm";
            chartOven.ChartAreas[0].AxisX.MajorGrid.Enabled = false;
            chartOven.ChartAreas[0].AxisX2.MajorGrid.Enabled = false;
            chartOven.ChartAreas[0].AxisY.MajorGrid.Enabled = false;
            chartOven.ChartAreas[0].AxisY2.MajorGrid.Enabled = false;
            chartOven.ChartAreas[0].AxisX.IntervalAutoMode = IntervalAutoMode.VariableCount;
            chartOven.ChartAreas[0].AxisX.LabelStyle.Angle = -60;
            chartOven.ChartAreas[0].AxisY.Title = "Temperature";
            
            chartOven.Series.Add("Temperature");
            chartOven.Series["Temperature"].ChartType = SeriesChartType.Point;
            chartOven.Series["Temperature"].XValueType = ChartValueType.DateTime;
            chartOven.Series["Temperature"].Color = Color.FromArgb(0, 192, 0); //blue
            chartOven.Series["Temperature"].XValueMember = "Date";
            chartOven.Series["Temperature"].YValueMembers = "Temperature";
            chartOven.Series["Temperature"].BorderWidth = 3;

            upper_txt.ResetText();
            lower_txt.ResetText();
            if (barcode_cmb.Text.Length > 0)
            {
                //get temp range in cmb
                OvenBarcodeVo upper = (OvenBarcodeVo)DefaultCbmInvoker.Invoke(new GetUpperOvenCbm(), new OvenBarcodeVo() { Model = model_cmb.Text, Line = line_cmb.Text, Barcode = barcode_cmb.Text });
                int Upper = int.Parse(upper.Upper);
                upper_txt.Text = Upper.ToString();

                OvenBarcodeVo lower = (OvenBarcodeVo)DefaultCbmInvoker.Invoke(new GetLowerOvenCbm(), new OvenBarcodeVo() { Model = model_cmb.Text, Line = line_cmb.Text, Barcode = barcode_cmb.Text });
                int Lower = int.Parse(lower.Lower);
                lower_txt.Text = Lower.ToString();
                
                //add range temp
                chartOven.Series.Add("Lower");
                chartOven.Series["Lower"].ChartType = SeriesChartType.Line;
                chartOven.Series["Lower"].Color = Color.FromArgb(9, 9, 226);//red
                chartOven.Series["Lower"].Points.AddXY(timefrom_dtp.Value, Lower);
                chartOven.Series["Lower"].Points.AddXY(timeto_dtp.Value, Lower);
                chartOven.Series["Lower"].BorderWidth = 2;
                
                chartOven.Series.Add("Upper");
                chartOven.Series["Upper"].ChartType = SeriesChartType.Line;
                chartOven.Series["Upper"].Color = Color.FromArgb(9, 9, 226);//red
                chartOven.Series["Upper"].Points.AddXY(timefrom_dtp.Value, Upper);
                chartOven.Series["Upper"].Points.AddXY(timeto_dtp.Value, Upper);
                chartOven.Series["Upper"].BorderWidth = 2;

                TempAlarm();
            }

            chartOven.DataSource = oven_dgv.DataSource;
        }
        private void GridBind()
        {
            oven_dgv.DataSource = null;
            try
            {
                OvenBarcodeVo vo = new OvenBarcodeVo
                {
                    Model = model_cmb.Text,
                    Line = line_cmb.Text,
                    Barcode = barcode_cmb.Text,
                    Lower = lower_txt.Text,
                    Upper = upper_txt.Text,
                    DateTimeForm = timefrom_dtp.Value,
                    DateTimeTo = timeto_dtp.Value,
                };

                ValueObjectList<OvenBarcodeVo> volist = (ValueObjectList<OvenBarcodeVo>)DefaultCbmInvoker.Invoke(new SearchOvenCbm(), vo);
                if (volist.GetList() != null && volist.GetList().Count > 0)
                {
                    oven_dgv.AutoGenerateColumns = false;
                    BindingSource bindingsource = new BindingSource(volist.GetList(), null);
                    
                    oven_dgv.DataSource = bindingsource;
                }
                else
                {
                    messageData = new MessageData("mmci00006", Properties.Resources.mmci00006, null);
                    logger.Info(messageData);
                    popUpMessage.Information(messageData, Text);
                }
                oven_dgv.ClearSelection();
            }
            catch (Framework.ApplicationException exception)
            {
                popUpMessage.ApplicationError(exception.GetMessageData(), Text);
                logger.Error(exception.GetMessageData());
            }
        }
        private void TempAlarm()
        {
            if (oven_dgv.RowCount > 0)
            {
                //colTemperature
                for (int i = 0; i < oven_dgv.RowCount; i++)
                {
                    double temp = double.Parse(oven_dgv.Rows[i].Cells["colTemperature"].Value.ToString());
                    double tempLower = double.Parse(lower_txt.Text);
                    double tempUpper = double.Parse(upper_txt.Text);
                    if (temp < tempLower || temp > tempUpper)
                    {
                        oven_dgv.Rows[i].Cells["colTemperature"].Style.BackColor = Color.Red;
                    }
                }
            }
        }
    }
}
