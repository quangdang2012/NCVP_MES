using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.Common.Basic.MachineMaintenance.Vo;
using System;
using Com.Nidec.Mes.Common.Basic.MachineMaintenance.Cbm;
using System.Drawing;
using Com.Nidec.Mes.Common.Basic.MachineMaintenance.Cbm.GA1ModelCbm.NoiseShow;

namespace Com.Nidec.Mes.Common.Basic.MachineMaintenance.Form
{
    public partial class NoiseChartForm : FormCommonNCVP
    {
        public NoiseChartForm()
        {
            InitializeComponent();
        }

        private void NoiseChartForm_Load(object sender, EventArgs e)
        {

        }

        private void btnExport_Click(object sender, EventArgs e)
        {

        }

        private void btn_Seach_Click(object sender, EventArgs e)
        {
            trans(pal_1, lbl_in1, lbl_out1, lbl_yield1, "1");
            trans(pal_2, lbl_in2, lbl_out2, lbl_yield2, "2");
            //L01
            trans(pal_3, lbl_in3, lbl_out3, lbl_yield3, "3");//6
            trans(pal_4, lbl_in4, lbl_out4, lbl_yield4, "4");
            trans(pal_5, lbl_in5, lbl_out5, lbl_yield5, "5");
            trans(pal_6, lbl_in6, lbl_out6, lbl_yield6, "6");
            trans(pal_7, lbl_in7, lbl_out7, lbl_yield7, "7");
            double inL01 = In(lbl_in3) + In(lbl_in4) + In(lbl_in5) + In(lbl_in6) + In(lbl_in7);
            double outL01 = Out(lbl_out3) + Out(lbl_out4) + Out(lbl_out5) + Out(lbl_out6) + Out(lbl_out7);
            SumYieldlLine(pal_L01,lbl_yieldL01, lbl_inL01, lbl_outL01, inL01, outL01);

            //L02
            trans(pal_8, lbl_in8, lbl_out8, lbl_yield8, "8");
            trans(pal_9, lbl_in9, lbl_out9, lbl_yield9, "9");
            trans(pal_10, lbl_in10, lbl_out10, lbl_yield10, "10");
            trans(pal_11, lbl_in11, lbl_out11, lbl_yield11, "11");
            trans(pal_12, lbl_in12, lbl_out12, lbl_yield12, "12");
            double inL02 = In(lbl_in8) + In(lbl_in9) + In(lbl_in10) + In(lbl_in11) + In(lbl_in12);
            double outL02 = Out(lbl_out8) + Out(lbl_out9) + Out(lbl_out10) + Out(lbl_out11) + Out(lbl_out12);
            SumYieldlLine(pal_L02, lbl_yieldL02, lbl_inL02, lbl_outL02, inL02, outL02);

            //L03
            trans(pal_13, lbl_in13, lbl_out13, lbl_yield13, "13");
            trans(pal_14, lbl_in14, lbl_out14, lbl_yield14, "14");
            trans(pal_15, lbl_in15, lbl_out15, lbl_yield15, "15");
            trans(pal_16, lbl_in16, lbl_out16, lbl_yield16, "16");
            trans(pal_17, lbl_in17, lbl_out17, lbl_yield17, "17");
            double inL03 = In(lbl_in13) + In(lbl_in14) + In(lbl_in15) + In(lbl_in16) + In(lbl_in17);
            double outL03 = Out(lbl_out13) + Out(lbl_out14) + Out(lbl_out15) + Out(lbl_out16) + Out(lbl_out17);
            SumYieldlLine(pal_L03, lbl_yieldL03, lbl_inL03, lbl_outL03, inL03, outL03);

            //L04
            trans(pal_18, lbl_in18, lbl_out18, lbl_yield18, "18");
            trans(pal_19, lbl_in19, lbl_out19, lbl_yield19, "19");
            trans(pal_20, lbl_in20, lbl_out20, lbl_yield20, "20");
            trans(pal_21, lbl_in21, lbl_out21, lbl_yield21, "21");
            trans(pal_22, lbl_in22, lbl_out22, lbl_yield22, "22");
            double inL04 = In(lbl_in18) + In(lbl_in19) + In(lbl_in20) + In(lbl_in21) + In(lbl_in22);
            double outL04 = Out(lbl_out18) + Out(lbl_out19) + Out(lbl_out20) + Out(lbl_out21) + Out(lbl_out22);
            SumYieldlLine(pal_L04, lbl_yieldL04, lbl_inL04, lbl_outL04, inL04, outL04);

            //line repaire
            trans(pal_23, lbl_in23, lbl_out23, lbl_yield23, "23");
            trans(pal_24, lbl_in24, lbl_out24, lbl_yield24, "24");
            trans(pal_25, lbl_in25, lbl_out25, lbl_yield25, "25");
            trans(pal_26, lbl_in26, lbl_out26, lbl_yield26, "26");
            //trans(pal_27, lbl_in27, lbl_out27, lbl_yield27, "27");
            //trans(pal_28, lbl_in28, lbl_out28, lbl_yield28, "28");
            //trans(pal_29, lbl_in29, lbl_out29, lbl_yield29, "29");
            //trans(pal_30, lbl_in30, lbl_out30, lbl_yield30, "30");
        }
        public double In(LabelCommon lbl)
        {
            return double.Parse(lbl.Text.Substring(6, lbl.Text.Length - 6));
        }
        public double Out(LabelCommon lbl)
        {
            return double.Parse(lbl.Text.Substring(7, lbl.Text.Length - 7));
        }
        public void trans(PanelCommon panel,LabelCommon lblIn, LabelCommon lblOut, LabelCommon lblYeild, string eqid)
        {
            GA1ModelVo Input = (GA1ModelVo)DefaultCbmInvoker.Invoke(new GetCountNoiseCbm(), new GA1ModelVo() { Status = true, DateFrom = dtp_From.Value, DateTo = dtp_To.Value, Noise_eq_id = eqid });
            GA1ModelVo Output = (GA1ModelVo)DefaultCbmInvoker.Invoke(new GetCountNoiseCbm(), new GA1ModelVo() { Status = false, DateFrom = dtp_From.Value, DateTo = dtp_To.Value, Noise_eq_id = eqid });

            lblIn.Text = "INPUT: " + Input.AffectedCount.ToString();
            lblOut.Text = "OUTPUT: " + Output.AffectedCount.ToString();
            if (Input.AffectedCount > 0)
            {
                double yeild = (double.Parse(Output.AffectedCount.ToString()) / double.Parse(Input.AffectedCount.ToString())) * 100;
                lblYeild.Text = "YIELD: " + Math.Round(yeild, 3).ToString() + " %";
                if (yeild < 90)//NG
                {
                    panel.BackColor = Color.FromArgb(255, 60, 60);
                }
                else if (yeild >= 90 && yeild <= 95)
                {
                    panel.BackColor = Color.Yellow;
                }
                else
                    panel.BackColor = Color.LightGreen;
            }
            else
                panel.BackColor = Color.FromArgb(255, 192, 128);
        }
        public void SumYieldlLine(PanelCommon panel,LabelCommon lblyield, LabelCommon lblIn, LabelCommon lblOut, double input, double output)
        {
            double yield = Math.Round((output / input) * 100, 3);
            lblIn.Text = "INPUT: " + input.ToString();
            lblOut.Text = "OUTPUT: " + output.ToString();
            lblyield.Text = "YIELD: " + yield.ToString() + " %";

            if (yield < 90)
            {
                panel.BackColor = Color.FromArgb(255, 60, 60);
            }
            else if (yield >= 90 && yield <= 95)
            {
                panel.BackColor = Color.Yellow;
            }
            else
                panel.BackColor = Color.LightGreen;
        }
        private void btn_Run_Click(object sender, EventArgs e)
        {
            btn_Run.Text = "Running";
            btn_Seach_Click(sender, e);
            timer1.Enabled = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            btn_Seach_Click(sender, e);
            timer1.Interval = int.Parse(txtTimer.Text) * 1000;            
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            btn_Run.Text = "Run";
        }

       
    }
}