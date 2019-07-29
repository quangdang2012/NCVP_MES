using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.Common.Basic.MachineMaintenance.Vo;
using System;
using Com.Nidec.Mes.Common.Basic.MachineMaintenance.Cbm;
using System.Drawing;
using Com.Nidec.Mes.Common.Basic.MachineMaintenance.Cbm.GA1ModelCbm.NoiseShow;

namespace Com.Nidec.Mes.Common.Basic.MachineMaintenance.Form
{
    public partial class ThusrtChartForm : FormCommonNCVP
    {
        public ThusrtChartForm()
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
            //  trans(pal_1, lbl_in1, lbl_out1, lbl_yield1, "1");
            //  trans(pal_2, lbl_in2, lbl_out2, lbl_yield2, "2");
            //L01
            trans(pal11, lbl_in11, lbl_out11, lbl_yield11, "MC1", "L01");
            trans(pal12, lbl_in12, lbl_out12, lbl_yield12, "MC2", "L01");
            trans(pal13, lbl_in13, lbl_out13, lbl_yield13, "MC3", "L01");
            trans(pal14, lbl_in14, lbl_out14, lbl_yield14, "MC4", "L01");
            trans(pal15, lbl_in15, lbl_out15, lbl_yield15, "MC5", "L01");
            trans(pal16, lbl_in16, lbl_out16, lbl_yield16, "MC6", "L01");
            trans(pal1m, lbl_in1m, lbl_out1m, lbl_yield1m, "380", "L01");
            double inL01 = In(lbl_in11) + In(lbl_in12) + In(lbl_in13) + In(lbl_in14) + In(lbl_in15) + In(lbl_in16) + In(lbl_in1m);
            double outL01 = Out(lbl_out11) + Out(lbl_out12) + Out(lbl_out13) + Out(lbl_out14) + Out(lbl_out15) + Out(lbl_out16) + Out(lbl_out1m);
            SumYieldlLine(pal1t, lbl_yield1t, lbl_in1t, lbl_out1t, inL01, outL01);

            ////L02
            trans(pal21, lbl_in21, lbl_out21, lbl_yield21, "MC1", "L02");
            trans(pal22, lbl_in22, lbl_out22, lbl_yield22, "MC2", "L02");
            trans(pal23, lbl_in23, lbl_out23, lbl_yield23, "MC3", "L02");
            trans(pal24, lbl_in24, lbl_out24, lbl_yield24, "MC4", "L02");
            trans(pal25, lbl_in25, lbl_out25, lbl_yield25, "MC5", "L02");
            trans(pal26, lbl_in26, lbl_out26, lbl_yield26, "MC6", "L02");
            trans(pal2m, lbl_in2m, lbl_out2m, lbl_yield2m, "380", "L02");
            double inL02 = In(lbl_in21) + In(lbl_in22) + In(lbl_in23) + In(lbl_in24) + In(lbl_in25) + In(lbl_in26) + In(lbl_in2m);
            double outL02 = Out(lbl_out21) + Out(lbl_out22) + Out(lbl_out23) + Out(lbl_out24) + Out(lbl_out25) + Out(lbl_out26) + Out(lbl_out2m);
            SumYieldlLine(pal2t, lbl_yield2t, lbl_in2t, lbl_out2t, inL02, outL02);

            ////L03
            trans(pal31, lbl_in31, lbl_out31, lbl_yield31, "MC1", "L03");
            trans(pal32, lbl_in32, lbl_out32, lbl_yield32, "MC2", "L03");
            trans(pal33, lbl_in33, lbl_out33, lbl_yield33, "MC3", "L03");
            trans(pal34, lbl_in34, lbl_out34, lbl_yield34, "MC4", "L03");
            trans(pal35, lbl_in35, lbl_out35, lbl_yield35, "MC5", "L03");
            trans(pal36, lbl_in36, lbl_out36, lbl_yield36, "MC6", "L03");
            trans(pal3m, lbl_in3m, lbl_out3m, lbl_yield3m, "380", "L03");
            double inL03 = In(lbl_in33) + In(lbl_in32) + In(lbl_in33) + In(lbl_in34) + In(lbl_in35) + In(lbl_in36) + In(lbl_in3m);
            double outL03 = Out(lbl_out33) + Out(lbl_out32) + Out(lbl_out33) + Out(lbl_out34) + Out(lbl_out35) + Out(lbl_out36) + Out(lbl_out3m);
            SumYieldlLine(pal3t, lbl_yield3t, lbl_in3t, lbl_out3t, inL03, outL03);

            ////L04
            trans(pal41, lbl_in41, lbl_out41, lbl_yield41, "MC1", "L04");
            trans(pal42, lbl_in42, lbl_out42, lbl_yield42, "MC2", "L04");
            trans(pal43, lbl_in43, lbl_out43, lbl_yield43, "MC3", "L04");
            trans(pal44, lbl_in44, lbl_out44, lbl_yield44, "MC4", "L04");
            trans(pal45, lbl_in45, lbl_out45, lbl_yield45, "MC5", "L04");
            trans(pal46, lbl_in46, lbl_out46, lbl_yield46, "MC6", "L04");
            trans(pal4m, lbl_in4m, lbl_out4m, lbl_yield4m, "380", "L04");
            double inL04 = In(lbl_in44) + In(lbl_in42) + In(lbl_in43) + In(lbl_in44) + In(lbl_in45) + In(lbl_in46) + In(lbl_in4m);
            double outL04 = Out(lbl_out44) + Out(lbl_out42) + Out(lbl_out43) + Out(lbl_out44) + Out(lbl_out45) + Out(lbl_out46) + Out(lbl_out4m);
            SumYieldlLine(pal4t, lbl_yield4t, lbl_in4t, lbl_out4t, inL04, outL04);

            //L05
          
            trans(pal5m, lbl_in5m, lbl_out5m, lbl_yield5m, "380", "LRP");
            
        }
        public double In(LabelCommon lbl)
        {
            return double.Parse(lbl.Text.Substring(6, lbl.Text.Length - 6));
        }
        public double Out(LabelCommon lbl)
        {
            return double.Parse(lbl.Text.Substring(7, lbl.Text.Length - 7));
        }
        public void trans(PanelCommon panel, LabelCommon lblIn, LabelCommon lblOut, LabelCommon lblYeild, string machine, string line)
        {
            GA1ModelVo Input = (GA1ModelVo)DefaultCbmInvoker.Invoke(new GetCountThurstCbm(), new GA1ModelVo() { Status = true, DateFrom = dtp_From.Value, DateTo = dtp_To.Value, Noise_eq_id = machine, LineCode = line });
            GA1ModelVo Output = (GA1ModelVo)DefaultCbmInvoker.Invoke(new GetCountThurstCbm(), new GA1ModelVo() { Status = false, DateFrom = dtp_From.Value, DateTo = dtp_To.Value, Noise_eq_id = machine, LineCode = line });

            lblIn.Text = "INPUT: " + Input.AffectedCount.ToString();
            lblOut.Text = "OUTPUT: " + Output.AffectedCount.ToString();
            if (Input.AffectedCount > 0)
            {
                double yeild = (double.Parse(Output.AffectedCount.ToString()) / double.Parse(Input.AffectedCount.ToString())) * 100;
                lblYeild.Text = "YIELD: " + Math.Round(yeild, 3).ToString() + " %";
                if (yeild < 50)//NG
                {
                    panel.BackColor = Color.FromArgb(255, 60, 60);
                }
                else if (yeild >= 50 && yeild <= 85)
                {
                    panel.BackColor = Color.Yellow;
                }
                else
                    panel.BackColor = Color.LightGreen;
            }
            else
            {
                panel.BackColor = Color.FromArgb(255, 192, 128);
                lblYeild.Text = "YIELD: 0";
            }

        }
        public void SumYieldlLine(PanelCommon panel, LabelCommon lblyield, LabelCommon lblIn, LabelCommon lblOut, double input, double output)
        {
            double yield = Math.Round((output / input) * 100, 3);
            lblIn.Text = "INPUT: " + input.ToString();
            lblOut.Text = "OUTPUT: " + output.ToString();
            lblyield.Text = "YIELD: " + yield.ToString() + " %";

            if (yield < 50)
            {
                panel.BackColor = Color.FromArgb(255, 60, 60);
            }
            else if (yield >= 50 && yield <= 85)
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